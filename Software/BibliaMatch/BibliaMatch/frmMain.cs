using BMCommNet;
using System;
using System.IO;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace BibliaMatch
{
    public partial class frmMain : Form
    {
        int puntos1, puntos2, puntos3, puntos4, puntos5, puntos6;

        int EquipoRojo, EquipoAzul;

        bool primeroMalo;
        enum Equip
        {
            EquipoRojo,
            EquipoAzul
        }

        Equip Equipos;

        SoundPlayer Sound, Fondo;
        BMComm Pulsadores = new BMComm();
        Thread subProceso1;

        string[] orden = new string[] { "12", "34", "56", "14", "36", "25", "16", "35", "42", "15", "32", "64", "13", "26", "45", "12", "34", "56", "14", "36", "25", "16", "35", "42", "15", "32", "64", "13", "26", "45" };
        string[] arrayGrupos;
        string[] arrayPreguntas;

        int indexPrimero;

        TimeSpan tiempo;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAbrirPuerto_Click(object sender, EventArgs e)
        {


            try
            {
                if (Pulsadores.OpenPort(cbxPuertos.Text))
                {
                    gbxBotones.Enabled = true;
                    btnAbrirPuerto.Enabled = false;
                    btnCerrarPuerto.Enabled = true;
                }
            }
            catch
            {

            }

        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            if (Pulsadores.SendCmd("R"))
            {

                indexPrimero = 0;


                btnReset.Enabled = false;
                btnJugador.Enabled = true;
            }
            else
            {


                MessageBox.Show("Verificar Conexión.");
            }
        }



        private void btnPulsador_Click(object sender, EventArgs e)
        {
            //subProceso1 = new Thread(Competencia);
            //subProceso1.IsBackground = true;
            //subProceso1.Start();

            subProceso1 = new Thread(new ThreadStart(Competencia));
            subProceso1.IsBackground = true; // de este modo el hilo se cierra al cerrar el main form
            subProceso1.Start();

            btnTiempo.Enabled = false;
        }

        private void btnLed0_Click(object sender, EventArgs e)
        {
            Pulsadores.SendCmd("L0");
        }
        private void btnLed1_Click(object sender, EventArgs e)
        {
            Pulsadores.SendCmd("L1");
        }

        private void btnLed2_Click(object sender, EventArgs e)
        {
            Pulsadores.SendCmd("L2");
        }

        private void btnLed3_Click(object sender, EventArgs e)
        {
            Pulsadores.SendCmd("L3");
        }

        private void btnCerrarPuerto_Click(object sender, EventArgs e)
        {

            Pulsadores.ClosePort();
            gbxBotones.Enabled = false;
            btnAbrirPuerto.Enabled = true;
            btnCerrarPuerto.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbxPuertos.Items.Clear();

            string[] Puertos = System.IO.Ports.SerialPort.GetPortNames();
            Array.Sort(Puertos);





            cbxPuertos.Items.AddRange(Puertos);

            if (cbxPuertos.Items.Count > 0)
            {
                cbxPuertos.SelectedIndex = 0;
                Fondo = new SoundPlayer(Properties.Resources.variables);
                Fondo.PlayLooping();
            }
            else
            {

                MessageBox.Show("No se detectaron puertos seriales.");
                btnAbrirPuerto.Enabled = false;

            }


            StreamReader Grupos = new StreamReader("./grupos.txt", Encoding.GetEncoding("iso-8859-15"));

            arrayGrupos = Grupos.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);


            lblEquipo1.Text = arrayGrupos[0];
            lblEquipo2.Text = arrayGrupos[1];
            lblEquipo3.Text = arrayGrupos[2];
            lblEquipo4.Text = arrayGrupos[3];
            lblEquipo5.Text = arrayGrupos[4];
            lblEquipo6.Text = arrayGrupos[5];

            StreamReader Preguntas = new StreamReader("./preguntas1.txt", Encoding.GetEncoding("iso-8859-15"));

            arrayPreguntas = Preguntas.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            lblCompetidorRojo.Text = "?????";
            lblCompetidorAzul.Text = "?????";
            lblSiguienteRojo1.Text = "?????";
            lblSiguienteAzul1.Text = "?????";
            lblSiguienteRojo2.Text = "?????";
            lblSiguienteAzul2.Text = "?????";

            lblPuntosE1.Text = "0";
            lblPuntosE2.Text = "0";
            lblPuntosE3.Text = "0";
            lblPuntosE4.Text = "0";
            lblPuntosE5.Text = "0";
            lblPuntosE6.Text = "0";

        }

        void Competencia()
        {

            try
            {

                timer1.Enabled = true;

                if (Pulsadores.SendCmd("C" + textBox1.Text.PadLeft(2, '0')))
                {

                    Sound = new SoundPlayer(Properties.Resources.clock);
                    Sound.Play();

                    ButtonData Botones = Pulsadores.GetButton();


                    if (Botones.Botones == BOTONES.Boton1)
                    {
                        Sound.Stop();
                        Sound = new SoundPlayer(Properties.Resources.buzzer);
                        Sound.Play();


                        Equipos = Equip.EquipoRojo;
                        lblTiempo.Text = "EQUIP. ROJO";

                        EstablecerPropiedadControl(btnBien, "Enabled", true);
                        EstablecerPropiedadControl(btnMal, "Enabled", true);
                    }
                    if (Botones.Botones == BOTONES.Boton2)
                    {
                        Sound.Stop();
                        Sound = new SoundPlayer(Properties.Resources.buzzer);
                        Sound.Play();
                        lblTiempo.Text = "EQUIP. AZUL";

                        Equipos = Equip.EquipoAzul;
                        EstablecerPropiedadControl(btnBien, "Enabled", true);
                        EstablecerPropiedadControl(btnMal, "Enabled", true);
                    }

                    if (Botones.Botones == BOTONES.Empate)
                    {
                        Sound.Stop();
                        Sound = new SoundPlayer(Properties.Resources.buzzer);
                        Sound.Play();
                        lblTiempo.Text = "Empate";

                        EstablecerPropiedadControl(btnTiempo, "Enabled", true);

                    }

                    if (Botones.Botones == BOTONES.Adelantado1)
                    {
                        Sound.Stop();
                        Sound = new SoundPlayer(Properties.Resources.buzzer);
                        Sound.Play();
                        lblTiempo.Text = "ADELANT. - AZUL";

                        Equipos = Equip.EquipoAzul;

                        EstablecerPropiedadControl(btnBien, "Enabled", true);
                        EstablecerPropiedadControl(btnMal, "Enabled", true);

                    }

                    if (Botones.Botones == BOTONES.Adelantado2)
                    {
                        Sound.Stop();
                        Sound = new SoundPlayer(Properties.Resources.buzzer);
                        Sound.Play();
                        lblTiempo.Text = "ADELANT. - ROJO";
                        Equipos = Equip.EquipoRojo;


                        EstablecerPropiedadControl(btnBien, "Enabled", true);
                        EstablecerPropiedadControl(btnMal, "Enabled", true);
                    }

                    if (Botones.Botones == BOTONES.Ninguno)
                    {
                        Sound.Stop();
                        lblTiempo.Text = "TIEMPO!!!";

                        EstablecerPropiedadControl(lblPregunta, "Text", arrayPreguntas[indexPrimero].Split(new char[] { '\t', '|' }, StringSplitOptions.RemoveEmptyEntries)[2]);

                        indexPrimero++;

                        btnJugador.Enabled = true;
                        btnBien.Enabled = false;
                        btnMal.Enabled = false;

                    }
                }
                else
                {
                    MessageBox.Show("Error estableciendo timeout, verificar valor");

                    EstablecerPropiedadControl(btnTiempo, "Enabled", true);
                }
            }
            catch
            {
                Sound.Stop();
                MessageBox.Show("Error inesperado, verificar conexión.");
                btnTiempo.Enabled = true;
            }
            finally
            {
                Thread.Sleep(4000);
                Fondo.PlayLooping();
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Pulsadores.ClosePort();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblPregunta.Text = arrayPreguntas[indexPrimero].Split(new char[] { '\t', '|' }, StringSplitOptions.RemoveEmptyEntries)[1];
            lblNumeroResp.Text = arrayPreguntas[indexPrimero].Split(new char[] { '\t', '|' }, StringSplitOptions.RemoveEmptyEntries)[0];

            btnPregunta.Enabled = false;
            btnTiempo.Enabled = true;


        }

        void actualizarScore()
        {

            lblPuntosE1.Text = puntos1.ToString();
            lblPuntosE2.Text = puntos2.ToString();
            lblPuntosE3.Text = puntos3.ToString();
            lblPuntosE4.Text = puntos4.ToString();
            lblPuntosE5.Text = puntos5.ToString();
            lblPuntosE6.Text = puntos6.ToString();

        }

        void SoloNúmeros(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar == 8))
            {
                e.Handled = false;
                return;
            }
            else
            {
                e.Handled = true;
                return;
            }
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lblPuntosE1_Click(object sender, EventArgs e)
        {

        }

        private void lblPuntosE2_Click(object sender, EventArgs e)
        {

        }

        private void lblPuntosE3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            tiempo.Add(new TimeSpan(0, 0, -1));


            EstablecerPropiedadControl(lblTiempo, "Text", string.Format("{0:mm:ss u}", tiempo));

        }

        private void lblEquipo3_Click(object sender, EventArgs e)
        {

        }




        ///////////////////////////////////////////////////////////////////////
        //    Método para control de la GUI por medio de subprocesos


        private delegate void DelegadoEstablecerPropiedadControl(Control control, string nombrePropiedad, object valorPropiedad);

        public static void EstablecerPropiedadControl(Control control, string nombrePropiedad, object valorPropiedad)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new DelegadoEstablecerPropiedadControl(EstablecerPropiedadControl), new object[] { control, nombrePropiedad, valorPropiedad });
            }
            else
            {
                control.GetType().InvokeMember(nombrePropiedad, BindingFlags.SetProperty, null, control, new object[] { valorPropiedad });
            }
        }

        ///////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////
        //    Método para obtener valores de controles de la GUI por medio de subprocesos


        private delegate object DelegadoLeerPropiedadControl(Control control, string nombrePropiedad);

        public static object LeerPropiedadControl(Control control, string nombrePropiedad)
        {
            if (control.InvokeRequired)
            {
                return control.Invoke(new DelegadoLeerPropiedadControl(LeerPropiedadControl), new object[] { control, nombrePropiedad });
            }
            else
            {

                return control.GetType().InvokeMember(nombrePropiedad, BindingFlags.GetProperty, null, control, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sound.Stop();
            Sound = new SoundPlayer(Properties.Resources.bien);
            Sound.Play();

            if (Equipos == Equip.EquipoRojo)
            {
                switch (EquipoRojo)
                {
                    case 1:
                        puntos1 += 100;
                        break;
                    case 2:
                        puntos2 += 100;
                        break;
                    case 3:
                        puntos3 += 100;
                        break;
                    case 4:
                        puntos4 += 100;
                        break;
                    case 5:
                        puntos5 += 100;
                        break;
                    case 6:
                        puntos6 += 100;
                        break;

                    default:
                        break;
                }


            }
            else
            {
                switch (EquipoAzul)
                {
                    case 1:
                        puntos1 += 100;
                        break;
                    case 2:
                        puntos2 += 100;
                        break;
                    case 3:
                        puntos3 += 100;
                        break;
                    case 4:
                        puntos4 += 100;
                        break;
                    case 5:
                        puntos5 += 100;
                        break;
                    case 6:
                        puntos6 += 100;
                        break;

                    default:
                        break;
                }




            }

            actualizarScore();

            indexPrimero++;

            btnJugador.Enabled = true;
            btnBien.Enabled = false;
            btnMal.Enabled = false;

        }

        private void btnLoadPlayer_Click(object sender, EventArgs e)
        {

            primeroMalo = false;

            tiempo = new TimeSpan(0, 0, int.Parse(textBox1.Text));
            lblTiempo.Text = string.Format("{0} Segundos!", textBox1.Text);



            int i = indexPrimero;




            if (i < 30)
            {

                EquipoRojo = int.Parse(orden[i].Substring(0, 1));
                EquipoAzul = int.Parse(orden[i].Substring(1, 1));

                EstablecerPropiedadControl(lblCompetidorRojo, "Text", arrayGrupos[EquipoRojo - 1]);
                EstablecerPropiedadControl(lblCompetidorAzul, "Text", arrayGrupos[EquipoAzul - 1]);

                if ((i + 2) < 30)
                {
                    EstablecerPropiedadControl(lblSiguienteRojo2, "Text", arrayGrupos[int.Parse(orden[i + 2].Substring(0, 1)) - 1]);
                    EstablecerPropiedadControl(lblSiguienteAzul2, "Text", arrayGrupos[int.Parse(orden[i + 2].Substring(1, 1)) - 1]);
                }
                else
                {
                    EstablecerPropiedadControl(lblSiguienteRojo2, "Text", string.Empty);
                    EstablecerPropiedadControl(lblSiguienteAzul2, "Text", string.Empty);
                    EstablecerPropiedadControl(lblSig1, "Text", "Siguiente:");
                    EstablecerPropiedadControl(lblSig2, "Text", "Siguiente:");

                }

                if ((i + 1) < 30)
                {
                    EstablecerPropiedadControl(lblSiguienteRojo1, "Text", arrayGrupos[int.Parse(orden[i + 1].Substring(0, 1)) - 1]);
                    EstablecerPropiedadControl(lblSiguienteAzul1, "Text", arrayGrupos[int.Parse(orden[i + 1].Substring(1, 1)) - 1]);
                }
                else
                {
                    EstablecerPropiedadControl(lblSiguienteRojo1, "Text", string.Empty);
                    EstablecerPropiedadControl(lblSiguienteAzul1, "Text", string.Empty);
                    EstablecerPropiedadControl(lblSig1, "Text", string.Empty);
                    EstablecerPropiedadControl(lblSig2, "Text", string.Empty);
                }



                btnJugador.Enabled = false;
                btnPregunta.Enabled = true;

            }
            else
            {

                lblCompetidorRojo.Text = "ROJO";
                lblCompetidorAzul.Text = "AZUL";
                lblPregunta.Text = string.Format("Resultados finales: \n{0} {1} pts\n{2} {3} pts\n{4} {5} pts\n{6} {7} pts\n{8} {9} pts\n{10} {11} pts", arrayGrupos[0], puntos1, arrayGrupos[1], puntos2, arrayGrupos[2], puntos3, arrayGrupos[3], puntos4, arrayGrupos[4], puntos5, arrayGrupos[5], puntos6);
            }



        }

        private void btnMal_Click(object sender, EventArgs e)
        {

            Sound.Stop();
            Sound = new SoundPlayer(Properties.Resources.mal);
            Sound.Play();

            if (!primeroMalo)
            {

                if (Equipos == Equip.EquipoRojo)
                {

                    Equipos = Equip.EquipoAzul;
                    lblTiempo.Text = "EQUIP. AZUL";
                }
                else
                {

                    Equipos = Equip.EquipoRojo;
                    lblTiempo.Text = "EQUIP. ROJO";
                }

                primeroMalo = true;

            }
            else
            {
                EstablecerPropiedadControl(lblPregunta, "Text", arrayPreguntas[indexPrimero].Split(new char[] { '\t', '|' }, StringSplitOptions.RemoveEmptyEntries)[2]);


                indexPrimero++;

                btnJugador.Enabled = true;
                btnBien.Enabled = false;
                btnMal.Enabled = false;
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblEquipo1_Click(object sender, EventArgs e)
        {

        }

        private void lblEquipo2_Click(object sender, EventArgs e)
        {

        }

        private void lblEquipo3_Click_1(object sender, EventArgs e)
        {

        }

        private void lblPuntosE1_Click_1(object sender, EventArgs e)
        {

        }


        private void lblTiempo_Click(object sender, EventArgs e)
        {

        }

        private void lblPregunta_Click(object sender, EventArgs e)
        {

        }

        private void lblTiempo_Click_1(object sender, EventArgs e)
        {

        }

        private void lblSig2_Click(object sender, EventArgs e)
        {

        }



        ///////////////////////////////////////////////////////////////////////
    }
}
