using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Runtime.InteropServices; // para el ComVisible

namespace BMCommNet
{
    /// <summary>
    /// Clase de uso interno de la biblioteca BMCommNet
    /// </summary>
    [ComVisible(true)]
    public abstract class BMCommCommon : BMCommSerialPortControl
    {



        #region Constructores
  
      
        /// <summary>
        /// Inicializa una nueva instancia de la clase BMComm con sus valores por defecto.
        /// </summary>
        public BMCommCommon()
        {
            tempBuffer = new byte[1000];
            PortReceiveStatus = _SerialPortReceiveStatus.Espera;
            _dataReady = false;
            _bytesRecibidos = 0;
            _auxBytesRecibidos = 0;
            SerialPortReceiveTimeout = 20; // El timeout por defecto se aumentó de 10 a 20
            SendCmdRetryAttempts = 0;   // Por defecto no se intenta reenviar un comando fallido
            SendCmdRetryInterval = 1000; // Tiempo en milisegundos a esperan antes de reenviar un comando fallido por NAK
            UsandoLineasControl = false; // Esto sólo para iniciar la propiedad, realemnte se sabrá si se usan líneas de control a abrir el puerto
        }

        #endregion

        #region Métodos Públicos
       
      /// <summary>
        /// Método para la apertura del Puerto
        /// </summary>
        /// <param name="Puerto">Nombre del Puerto Serial</param>
        /// 
        public bool OpenPort(string Puerto)
        {
            try
            {
                Port.PortName = Puerto;
                Port.BaudRate = 9600; // Por defecto.
                Port.DataBits = 8;
                Port.StopBits = StopBits.One;
                Port.Parity = Parity.None;
                Port.ReadBufferSize = 256;
                Port.WriteBufferSize = 256;
                //      Port.Encoding = Encoding.GetEncoding(1252); // Encoding usado en latinoamérica, necesario para envío de letras con acentos y dieresis
                Port.Encoding = Encoding.GetEncoding("iso-8859-15");

                //Inicializo los controladores de eventos
                Port.DataReceived += new SerialDataReceivedEventHandler(SerialPortReceiveEvent);
                Port.PinChanged += new SerialPinChangedEventHandler(pin_changedEvent); // Manejo de eventos de cambio de las señales de control del puerto

                Port.Open();
                Port.Handshake = Handshake.None;
                this.comPort = Port.PortName;
                UsandoLineasControl = false;


                return true;

     


            }
            catch (System.IO.IOException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }



        /// <summary>
        /// Método para la apertura del Puerto
        /// </summary>
        /// <param name="Puerto">Nombre del Puerto Serial</param>
        /// 
        public bool OpenPort(string Puerto,int BaudRate, Parity Parity)
        {
          try
          {
            Port.PortName = Puerto;
            Port.BaudRate = BaudRate;
            Port.DataBits = 8;
            Port.StopBits = StopBits.One;
            Port.Parity = Parity;
            Port.ReadBufferSize = 256;
            Port.WriteBufferSize = 256;
            //      Port.Encoding = Encoding.GetEncoding(1252); // Encoding usado en latinoamérica, necesario para envío de letras con acentos y dieresis
            Port.Encoding = Encoding.GetEncoding("iso-8859-15");

            //Inicializo los controladores de eventos
            Port.DataReceived += new SerialDataReceivedEventHandler(SerialPortReceiveEvent);
            Port.PinChanged += new SerialPinChangedEventHandler(pin_changedEvent); // Manejo de eventos de cambio de las señales de control del puerto

            Port.Open();
            Port.Handshake = Handshake.None;
            this.comPort = Port.PortName;
            UsandoLineasControl = false;


            return true;




          }
          catch (System.IO.IOException)
          {
            return false;
          }
          catch (ArgumentException)
          {
            return false;
          }
          catch (UnauthorizedAccessException)
          {
            return false;
          }
        }


        /// <summary>
        /// Método para Cerrar el Puerto Serial
        /// </summary>
        public void ClosePort()
        {
            Port.Close();
        }

   
       

        /// <summary>
        /// Método para el Envío de Comandos
        /// </summary>
        /// <param name="cmd">Comando o trama</param>
        public bool SendCmd(string sCMD)
        {
            if (sCMD != null)
            {
              Mensaje = STX + sCMD + ETX ; 

                char[] cCMD = Mensaje.ToCharArray();
                byte[] bResp;
                int bytesRecibidos = 0;
                int Reintentos = 0;
         

                // Se envía el mensaje                        
                bytesRecibidos = SerialPortWriteAndRead(cCMD, out bResp, true, true);

                if ((bytesRecibidos == 1) && (bResp[0] == (byte)ACK)) // bien, ACK
                {

                    return true;
                }
                else
                {
                  if (bytesRecibidos == 0)
                  {
                    return false;
                  }

                  while (((bResp[0] == (byte)NAK) || (bytesRecibidos == -2)) && (Reintentos < SendCmdRetryAttempts)) // OJO ByetsRecibidos puede ser 0 aca y dar excepción.
                  {
                        Thread.Sleep(SendCmdRetryInterval); // Esperamos unos pocos milisegundos antes de reintentar enviar el comando por NAK

                        // Se reenvía el mensaje                        
                        bytesRecibidos = SerialPortWriteAndRead(cCMD, out bResp, true, true);
                        ++Reintentos;
                    }

              

                    if ((bytesRecibidos == 1) && (bResp[0] == (byte)ACK)) // bien, ACK
                    {
                        return true;
                    }
                    else
                    {
                        //   this.envio = "Status: 00  Error: 89";
                        return false;
                    }

                }
            }
            else
            {
                return false;
            }

        }

        

        /// <summary>
        /// Subes los Distintos Status de la Impresora al PC y lo copia en un archivo .txt
        /// </summary>
        /// <param name="Cmd">Comando o trama</param>
        /// <param name="file">Ruta ó Nombre del archivo.txt ó .dat</param>
        public bool UploadStatusCmd(string Cmd, string file)
        {
            int interv = 0;
            string sBuffer;


            try
            {
                StreamWriter pongo = new StreamWriter(file);

                interv = this.SubirDataStatus(Cmd, out sBuffer);
                
                pongo.WriteLine(sBuffer);
                pongo.Close();

                if (interv > 0)
                {
                    this.estado = "OK";
                     
                    return true;
                }
                else
                {
                    this.estado = "Sin repuesta.";
                     
                    return false;
                }

            }
            catch (IOException ioe)
            {
                estado = "Error... " + ioe.Message;
                 
                return false;
            }
            catch (ArgumentNullException nlle)
            {
                estado = "Error... " + nlle.Message;
                 
                return false;
            }

        }

        /// <summary>
        /// Sube un Reporte al PC y lo carga en un archivo .txt o .dat
        /// </summary>
        /// <param name="Cmd">Comando o trama</param>
        /// <param name="file">Ruta o Nombre del archivo .txt o .dat</param>
        public bool UploadReportCmd(string Cmd, string file)
        {
            int numeroDeLineasProcesadas = 0;
            string lineaReporte = "";

            try
            {
                StreamWriter escritorArchivoSalida = new StreamWriter(file);
                // Envio comando de reporte "U..."
                numeroDeLineasProcesadas = this.SubirDataReport(Cmd);

                int x = 0;
                while (x < numeroDeLineasProcesadas)
                {
                    lineaReporte += this.dataLectorFisc[x] + "\r\n";
                    ++x;
                }

                escritorArchivoSalida.Write(lineaReporte);
                escritorArchivoSalida.Close();
                if (numeroDeLineasProcesadas > 0)
                {
                    this.estado = "OK";
                     
                    return true;
                }
                else
                {
                    this.estado = "Sin repuesta.";
                     
                    return false;
                }

            }
            catch (IOException ioe)
            {
                estado = "Error... " + ioe.Message;
                 
                return false;
            }
            catch (ArgumentNullException nlle)
            {
                estado = "Error... " + nlle.Message;
                 
                return false;
            }
        }

        ///// <summary>
        ///// Lee el Status y Error de la Impresora Fiscal
        ///// </summary>
        //public bool ReadFpStatus()
        //{

        //  byte[] resp = new byte[20];
        //  int bytesRecibidos = 0;
        //  try
        //  {

        //    int timeoutActual = _SerialPortReceiveTimeout;

        //    _SerialPortReceiveTimeout = 2;

        //    bytesRecibidos = SerialPortWriteAndRead(new char[] { ENQ }, out resp, false, false);

        //    if (bytesRecibidos < 0) // timeout...
        //    {
        //      bytesRecibidos = SerialPortWriteAndRead(new char[] { ENQ }, out resp, false, false);
        //    }

        //    _SerialPortReceiveTimeout = timeoutActual;

        //    int st = 0, er = 0, lrc = 0;

        //    if (bytesRecibidos == 5)
        //    {
        //      for (int i = 0; i < 5; ++i)
        //      {
        //        if (i == 1)
        //        {
        //          st = (int)resp[i];
        //        }
        //        else if (i == 2)
        //        {
        //          er = (int)resp[i];
        //        }
        //        else if (i == 4)
        //        {
        //          lrc = (int)resp[i];
        //        }

        //      }

        //      if ((st ^ er ^ 0x03) != lrc)
        //      {
        //        DarStatus_Error(0, 144);
        //      }
        //      else
        //      {
        //        DarStatus_Error(st, er);
        //      }

        //      if (status != null && error != null)
        //      {
        //        this.estado = "OK";
        //         
        //        return true;
        //      }
        //      else
        //      {
        //        this.estado = "No hay Repuesta";
        //        this.ErroValid = false;
        //        this.descripStatus = "No Answer";
        //        this.descripError = "No Answer";
        //         
        //        return false;
        //      }
        //    }
        //    else
        //    {
        //      DarStatus_Error(0, 137);
        //       
        //      return false;
        //    }
        //  }
        //  catch (IOException e)
        //  {
        //    estado = "Error... " + e.Message;
        //     
        //    return false;
        //  }
        //  catch (ArgumentNullException e1)
        //  {
        //    estado = "Error... " + e1.Message;
        //     
        //    return false;
        //  }
        //}


        #endregion
    }
}
