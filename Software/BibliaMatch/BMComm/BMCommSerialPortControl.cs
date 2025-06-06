using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Collections;
using System.Threading;
using System.Diagnostics; // Para el cronómetro del timeOut

namespace BMCommNet
{
  /// <summary>
  /// Clase de uso interno de la biblioteca BMCommNet
  /// </summary>
    public abstract class BMCommSerialPortControl
    {

        #region Variables Globales

        protected enum _SerialPortReceiveStatus { Espera, Recibiendo, Listo, Trash };
        protected _SerialPortReceiveStatus PortReceiveStatus;
        protected int _SerialPortReceiveTimeout;
        protected int _SendCmdRetryAttempts;
        protected int _SendCmdRetryInterval;
        protected bool UsandoLineasControl;
        protected bool _dataReady;
        protected int _bytesRecibidos; // Exclusivo para el evento de recepción de datos
        protected int _auxBytesRecibidos;
        protected byte[] tempBuffer;
        protected byte[] _dataBuffer;
        protected byte[] _emptyBuffer = new byte[20]; //Debe estar vacío, por eso su nombre "_emptyBuffer"

        protected SerialPortEx Port = new SerialPortEx();


        // Caracteres de control
        internal char
            STX = (char)02,
            ETX = (char)03,
            EOT = (char)04,
            ENQ = (char)05,
            ACK = (char)06,
            SO  = (char)14,
            NAK = (char)21,
            ETB = (char)23;

        protected string Mensaje, estado, status_Error, comPort;
        protected string status, error, descripStatus, descripError;
        protected ArrayList dataLectorFisc = new ArrayList();
        protected bool CTS = false, DSR = false, CD = false, ErroValid = false;

        #endregion

        #region Manejadores de Eventos
        /// <summary>
        /// Función que atiende el evento de recepción de datos desde el puerto serial.
        /// ejemplo de uso:
        ///     Port.DataReceived += new SerialDataReceivedEventHandler(SerialPortReceiveEvent);
        /// </summary>
        internal void SerialPortReceiveEvent(object sender, SerialDataReceivedEventArgs e)
        {
          SerialPortEx Puerto = sender as SerialPortEx;

            // Si el puerto está cerrado, no hace nada
            if (!Puerto.IsOpen) return;
            byte rcvdByte;


            while (Puerto.BytesToRead != 0)
            {

                switch (PortReceiveStatus)
                {
                    case _SerialPortReceiveStatus.Espera:
                        _auxBytesRecibidos = 0;
                        rcvdByte = (byte)Puerto.ReadChar();
                        tempBuffer[_auxBytesRecibidos] = rcvdByte;
                        if (rcvdByte == (byte)STX) // STX
                        {
                            PortReceiveStatus++;
                            _auxBytesRecibidos++;
                            Thread.Sleep(2); // Tiempo suficiente para recibir 6 caracteres
                        }
                        else if ((rcvdByte == (byte)ACK) || (rcvdByte == (byte)NAK) || (rcvdByte == (byte)ENQ) || (rcvdByte == (byte)EOT))
                        {	// ACK NAK ENQ EOT 	
                            _auxBytesRecibidos++;
                            PortReceiveStatus = _SerialPortReceiveStatus.Listo;
                        }
                        else
                        {
                            PortReceiveStatus = _SerialPortReceiveStatus.Espera;
                        }

                        break;

                    case _SerialPortReceiveStatus.Recibiendo:

                        // Recibe los bytes que estén por leerse desde el buffer de entrada
                        _auxBytesRecibidos += Puerto.Read(tempBuffer, _auxBytesRecibidos, Puerto.BytesToRead);

                         if (tempBuffer[_auxBytesRecibidos - 1] == (byte)ETX)  // ETX y ETB respectivamente, este código no sirve con paquetes grandes if ((Array.IndexOf(tempBuffer, (byte)ETX, 0, _auxBytesRecibidos) >= 0) || (Array.IndexOf(tempBuffer, (byte)ETB, 0, _auxBytesRecibidos) >= 0))
                        {

                            PortReceiveStatus = _SerialPortReceiveStatus.Listo;
                        }
                        else
                        {
                            Thread.Sleep(10); // 10ms -> Tiempo suficiente para recibir aprox 30 caracteres
                        }

                        break;

             

                    default:
                        try
                        {
                          Puerto.DiscardInBuffer();
                        }catch
                        {
                        }
                        break;
                }


                if (PortReceiveStatus == _SerialPortReceiveStatus.Listo)
                {
                    _dataBuffer = new byte[_auxBytesRecibidos];
                    Array.Copy(tempBuffer, 0, _dataBuffer, 0, _auxBytesRecibidos);
                    _bytesRecibidos = _auxBytesRecibidos;
                    _auxBytesRecibidos = 0;
                    _dataReady = true;
                    PortReceiveStatus = _SerialPortReceiveStatus.Trash; // Para evitar que data nueva llegue hasta que no estemos listos para recibir
                }
            }

        }

        /// <summary>
        /// Método Exclusivo para actualizar el estado de las líneas de control del puerto serial
        /// </summary>
        /// <param name="sender">objeto</param>
        /// <param name="e">evento</param>
        internal void pin_changedEvent(object sender, SerialPinChangedEventArgs e)
        {
            if (!Port.IsOpen) return;

            // Show the state of the pins
            UpdatePinState();
        }


        #endregion 

        #region Propiedades
        /// <summary>
        /// Propiedad para establecer/consultar el tiempo EN SEGUNDOS máximo a esperar por una respuesta de la impresora.
        /// Rango permitido: 5 - 180.
        /// Nota: Si el cable no trabaja con señales de control RTS y CTS el valor de la propiedad siempre será "60".
        /// </summary>
        public int SerialPortReceiveTimeout
        {
            set
            {
                if (value >= 5 && value <= 180)  // El tiempo de espera o Timeout configurable está en un rango de 5 - 180 segundos
                {
                    _SerialPortReceiveTimeout = value;
                }
            }
            get
            {
               
                    return _SerialPortReceiveTimeout;
               
            }
        }

        /// <summary>
        /// Propiedad para establecer/consultar la cantidad de veces que se intenta reenviar un comando fallido por NAK (para SendCmd y SendFileCmd).
        /// Rango permitido: 0 - 5
        /// Nota: Si el cable no trabaja con señales de control RTS y CTS el valor de la propiedad siempre será "5".
        /// </summary>
        public int SendCmdRetryAttempts
        {
            set
            {
                if (value >= 0 && value <= 5)
                {
                    _SendCmdRetryAttempts = value;
                }
            }
            get
            {
               
                    return _SendCmdRetryAttempts;
                
            }
        }

        /// <summary>
        /// Propiedad para establecer/consultar el tiempo EN MILISEGUNDOS a esperar antes de reenviar un comando fallido por NAK (para SendCmd y SendFileCmd).
        /// Rengo permitido: 50 - 10000 (0,05 a 10 segundos).
        /// Nota: Si el cable no trabaja con señales de control RTS y CTS el valor de la propiedad siempre será "10000" (10 seg).
        /// </summary>
        public int SendCmdRetryInterval
        {
            set
            {
                if (value >= 50 && value <= 10000)
                {
                    _SendCmdRetryInterval = value;
                }
            }
            get
            {
                if (UsandoLineasControl)
                {
                    return _SendCmdRetryInterval;
                }
                else
                {
                    return 10000;
                }
            }
        }

        /// <summary>
        /// Propiedad para obtener el buffer de datos en binario de la última recepción del puerto serial.
        /// </summary>
        public byte[] SerialPortInputBuffer
        {
            get
            {
                _dataReady = false; // Si leemos datos en el buffer serial de forma manual, para casos extremadamente extraños.
                return _dataBuffer;
            }
        }

        /// <summary>
        /// Propiedad para saber si hay datos no leídos en el buffer de entrada del puerto serial (SerialPortInputBuffer).
        /// </summary>
        public bool SerialPortDataReady
        {
            get
            {
                return _dataReady;
            }
        }


        /// <summary>
        /// Retorna el nombre del Puerto en uso
        /// </summary>
        public string ComPort
        {
            get { return comPort; }
        }

        /// <summary>
        /// Retorna  si el puerto está Abierto  o Cerrado
        /// </summary>
        public bool StatusPort
        {
            get { return Port.IsOpen; }
        }




        #endregion

        #region Métodos Privados

       

        /// <summary>
        /// Función privada de uso exclusivo de la función "SerialPortWriteAndRead" que lee el buffer de datos 
        /// recibidos por el metodo SerialPortReceiveEvent y retorna la cantidad de bytes recibidos
        /// </summary>
        /// <param name="OutByteBuffer">Buffer donde se colocará lo recibido de la impresora (Requiere el uso de la palabra clave "out")</param>
        protected int getAnswer(out byte[] OutByteBuffer, bool TimeoutSegunPropiedad)
        {

            int LocalBytesRecibidos;
            int timeOutLocal;

            if (TimeoutSegunPropiedad)
            {
                timeOutLocal = SerialPortReceiveTimeout; // Propiedad
            }
            else
            {
                timeOutLocal = _SerialPortReceiveTimeout; // Variable Privada
            }

            bool timeExpired = false;
            Stopwatch cronometro = new Stopwatch();

            cronometro.Start();
            // Espera mientras los datos están listos o se acabe el tiempo
            while ((!_dataReady) && (!timeExpired))
            {

                if (cronometro.ElapsedMilliseconds > timeOutLocal * 1000) //  * 1000 porque es en milisegundos
                {
                    timeExpired = true; // Se venció el  tiempo
                }

            }

            if (cronometro.IsRunning)
            {
                cronometro.Stop(); // Detengo cuenta del cronometro
            }

            if (timeExpired)
            {
                OutByteBuffer = _emptyBuffer;
                return -1; // -1 significa timeOut
            }
            else
            {

                OutByteBuffer = _dataBuffer;
                _dataReady = false;

                LocalBytesRecibidos = _bytesRecibidos;
                _bytesRecibidos = 0;
                PortReceiveStatus = _SerialPortReceiveStatus.Espera;

                return LocalBytesRecibidos;
            }
        }
        /// <summary>
        /// Función que escribe la trama a la impresora y retorna la cantidad de bytes leídos y un Array de bytes con la respuesta
        /// (Depende de getAnswer)
        /// </summary>
        /// <param name="bResp">Buffer donde se colocará lo recibido de la impresora (Requiere el uso de la palabra clave "out")</param>
        protected int SerialPortWriteAndRead(char[] cTrama, out byte[] bResp, bool bEsperarCTS, bool TimeoutSegunPropiedad)
        {
            if (!Port.IsOpen)
            { 
                bResp = _emptyBuffer;
                return 0;
            }

            int bytesRecibidos = -1;         // Cantidad de bytes recibidos, siempre se debe comparar con la cantidad esperada de bytes
            Port.DiscardInBuffer();         // Vacío los buffers de entrada / salida
            Port.DiscardOutBuffer();
            byte[] bTrama = new byte[cTrama.Length];
            Encoding LATIN9 = Encoding.GetEncoding("iso-8859-15");

            bTrama = LATIN9.GetBytes(cTrama);

       


            _dataReady = false;

            PortReceiveStatus = _SerialPortReceiveStatus.Espera;



            try
            {
                Port.Write(bTrama, 0, cTrama.Length);   // Escribimos el comando a la impresora (Aquí ya tienen STX, CMD, ETX y LRC)
            }
            catch (TimeoutException)
            {

                bResp = _emptyBuffer;
                return -2; // timeout por RTS/CTS
            }

            bytesRecibidos = getAnswer(out bResp, TimeoutSegunPropiedad);  // Recibimos la respuesta en bResp, junto con la cantidad de bytes recibidos
            // Si hubo timeout, bytesRecibidos contiene -1

            return bytesRecibidos;

        }
        /// <summary>
        /// Método Exclusivo para controlar el Evento Pinchanged
        /// </summary>
        protected void UpdatePinState()
        {

          try
          {
            // Show the state of the pins
            if (Port.IsOpen)
            {
              CD = Port.CDHolding;
              CTS = Port.CtsHolding;
              DSR = Port.DsrHolding;
            }
          }
          catch
          {

          }

        }


        /// <summary>
        /// Método Exclusivo para los métodos SendCmd y SendCmd_Archivos, calcula el LRC de una trama y lo retorna como un char
        /// </summary>
        /// <param name="cmd">Comando o trama a la cual se le calculará el LRC</param>
        protected char Do_XOR(string sCMD)
        {
          Encoding LATIN9 = Encoding.GetEncoding("iso-8859-15");

       //   char[] cCMD = sCMD.ToCharArray();   // cCMD = Comando en modo char   
          byte[] bCMD = LATIN9.GetBytes(sCMD);

            int LRC_AUX = -1;                // Acumulador para el checksum
            int CheckSum = 0;                // Checksum/LRC final

            for (int i = 0; i < bCMD.Length; i++)
            {
              if ((i == 0) && (bCMD[i] == STX))
                {
                    // no hacer nada, dejar LRC_AUX en cero...
                }
                else if (LRC_AUX == -1) // si no se ha inicializado LRC_AUX lo inciamos
                {
                  LRC_AUX = bCMD[i];
                }
              else if (bCMD[i] != ETX) // si LRC_AUX ya fue inicado y no es ETX
                {
                  LRC_AUX ^= bCMD[i];
                }
                else         // En caso de que se envíe el ETX dentro de la trama...
                {
                    CheckSum = LRC_AUX ^ ETX;    // Se asigna a CheckSum el último Xor con ETX (03)
                    return (char)CheckSum;      // Salgo de la función retornando el CheckSum
                }
            }

            CheckSum = LRC_AUX ^ ETX;    // Finalmente se asigna a CheckSum el último Xor, con ETX (03)

            // Tabla necesaria para lidiar con los bytes no implementados en la tabla Latin9 (iso-8859-15)

            if (CheckSum == (char)0xA4) CheckSum = (char)'€';
            else if (CheckSum == (char)0xA6) CheckSum = (char)'Š';
            else if (CheckSum == (char)0xA8) CheckSum = (char)'š';
            else if (CheckSum == (char)0xb4) CheckSum = (char)'Ž';
            else if (CheckSum == (char)0xb8) CheckSum = (char)'ž';
            else if (CheckSum == (char)0xbc) CheckSum = (char)'Œ';
            else if (CheckSum == (char)0xbd) CheckSum = (char)'œ';
            else if (CheckSum == (char)0xbe) CheckSum = (char)'Ÿ';

            return (char)CheckSum;      // Retorno el checksum por si no lo voy a tomar desde la variable global
        }

        /// <summary>
        /// Método Exclusivo para los métodos UploadStatus y UploadReport
        /// </summary>
        /// <param name="cmd">Comando o trama</param>
        /// <param name="bResp">Respuesta desde la impresora</param>
        protected int SendCmd_Archivos(string sCMD, out byte[] bResp)
        {
            

            Mensaje = STX + sCMD + ETX ;

            //////
            char[] cCMD = Mensaje.ToCharArray();

            int bytesRecibidos = 0;

           

            try
            {
                // Se envía el mensaje y recibe respuesta...                     
                bytesRecibidos = SerialPortWriteAndRead(cCMD, out bResp, true, true);

                //Retorno la cantidad de caracteres recibidos en la trama de repuesta de la impresora
                return bytesRecibidos;
            }
            catch (IOException e)
            {
                estado = "Error... " + e.Message;
                bResp = null;
                return 0;
            }
            catch (ArgumentNullException e1)
            {
                estado = "Error... " + e1.Message;
                bResp = null;
                return 0;
            }

        }

        /// <summary>
        /// Metodo para esperar que la señal CTS se ponga en true (Si lo hace en un tiempo determinado, sino, pues no).
        /// </summary>
        private bool Wait_CTS(int timeoutInMilliseconds)
        {
            if (!Port.IsOpen) return false;

            Port.RtsEnable = true;
            long tiempoEsperaCTS = timeoutInMilliseconds; // se esperan 4 segundos para que se coloque en TRUE la señal CTS antes de decir que no
            long lastTime = 0;
            Stopwatch crono = new Stopwatch();
            crono.Start();

            // Espera mientras se coloca en true el CTS o se acabe el tiempo
            while (!CTS)
            {
                if (crono.ElapsedMilliseconds > lastTime + 100) // Para que no se tire 3, cuando se monitorea el puerto
                {
                    lastTime = crono.ElapsedMilliseconds;
                    this.CTS = Port.CtsHolding;
                }

                if ((crono.ElapsedMilliseconds > tiempoEsperaCTS) && (CTS == false)) // 4 segundos
                {
                    CTS = false;
                    return false; // Se venció el  tiempo
                }

            }

            if (crono.IsRunning)
            {
                crono.Stop(); // Detengo cuenta del cronometro
            }

            return true;

        }

        /// <summary>
        /// Extae Data de los Reportes de la maquina  al PC y lo copia en el Array "dataLectorFisc"
        /// </summary>
        /// <param name="Cmd">Comando o trama</param>
        protected int SubirDataReport(string sCMD)
        {
            int lineasProcesadas = 0;
            int bytesLeidos;
            byte bitParada;
            string trama = "";
            int ascii = 0;
            int n1 = 0;
            byte[] bBloque;

            // Envio comando de reporte "U..."
            bytesLeidos = SendCmd_Archivos(sCMD, out bBloque);

            if ((bytesLeidos > 0) && (bBloque[0] == (byte)ENQ)) // Si llega el ENQ
            {
                 
                Thread.Sleep(100);
                bytesLeidos = SerialPortWriteAndRead(new char[] { ACK }, out bBloque, false, true); // --> ACK    

                while ((bytesLeidos > 0) && (bBloque[0] != EOT) && (bBloque[0] != NAK)) // si es 1, debería ser EOT
                {

                    int Pos_ETX = bytesLeidos - 2;
                    int Pos_LRC = bytesLeidos - 1;

                    for (n1 = 0; n1 < bytesLeidos; n1++)
                    {
                      ascii = bBloque[n1];

                      if (!(n1 == 0 || n1 == Pos_ETX || n1 == Pos_LRC || ascii == 03))
                      {
                        trama += (char)ascii;
                      }
                    }

                    this.dataLectorFisc.Add(trama);
                    trama = null;
                    bitParada = bBloque[Pos_ETX];
                    bBloque = null; // estaba comentado en dll panamá

                    if (bitParada == (byte)ETB)   // OJO 0A no es un caracter separador, es un erroe del firmware pero se tiene aca asi mientras lo corrigen
                    {
                        bytesLeidos = SerialPortWriteAndRead(new char[] { ACK }, out bBloque, false, true); // OJO ANTES DE ENVIAR ACK SE DEBERÍA CALCULAR EL CHECKSUM DE LA TRAMA RECIBIDA
                    }
                    else if (bitParada == (byte)ETX) // ETX es que ya se finalizó la recepción, puede que llegue o no, un EOT al final...
                    {
                        int timeoutActual = SerialPortReceiveTimeout;
                        _SerialPortReceiveTimeout = 1; // por si llega el EOT

                        bytesLeidos = SerialPortWriteAndRead(new char[] { ACK }, out bBloque, false, false); // IDEM arriba

                        _SerialPortReceiveTimeout = timeoutActual;

                    }

                    ++lineasProcesadas;

                }
            }

            return lineasProcesadas;
        }


        /// <summary>
        /// Extae Data de los Status (S1, S2 ... Sx) de la maquina  al PC y lo copia en una variable string
        /// </summary>
        /// <param name="Cmd">Comando o trama</param>
        protected int SubirDataStatus(string sCMD, out string sDataSubida)
        {

            int bytesLeidos;
            string trama = "";
            int ascii = 0;
            int n1 = 0;
            byte[] bBloque;


            bytesLeidos = SendCmd_Archivos(sCMD, out bBloque);

            if (bytesLeidos > 2)
            {
                 

                int Pos_ETX = bytesLeidos - 1;
                

                for (n1 = 0; n1 < bytesLeidos; n1++)
                {
                    ascii = bBloque[n1];

                    if (!(n1 == 0 || n1 == Pos_ETX  || ascii == 03))
                    {

                        //if (ascii != 10)
                        //{
                            trama += (char)ascii;
                        //}

                    }

                }
            }

            sDataSubida = trama;

            return n1;

        }

        //private static byte[] String2ByteArray(string str)
        //{
        //    System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
        //    return encoding.GetBytes(str);
        //}

        #endregion

    }

}
