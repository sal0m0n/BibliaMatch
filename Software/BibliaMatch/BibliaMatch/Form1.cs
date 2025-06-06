using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMCommNet;
using System.Threading;
using System.Media;
namespace BibliaMatch
{
  public partial class Form1 : Form
  {

    SoundPlayer Sound;
    BMComm Pulsadores = new BMComm();

    public Form1()
    {
      InitializeComponent();
    }

    private void btnAbrirPuerto_Click(object sender, EventArgs e)
    {


      try
      {
        if (Pulsadores.OpenPort("COM1"))
        {
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
      Pulsadores.SendCmd("R");
    }

    private void btnPulsador_Click(object sender, EventArgs e)
    {
      try
      {
        Sound = new SoundPlayer(Properties.Resources.clock);
        Sound.Play();

        var Botones = Pulsadores.GetButton();

        if (Botones.Botones == BOTONES.Boton1)
        {
          Sound.Stop();
          Sound = new SoundPlayer(Properties.Resources.buzzer);
          Sound.Play();
          MessageBox.Show("Botón 1");
          

        }
        if (Botones.Botones == BOTONES.Boton2)
        {
          Sound.Stop();
          Sound = new SoundPlayer(Properties.Resources.buzzer);
          Sound.Play();
          MessageBox.Show("Botón 2");
          

        }

        if (Botones.Botones == BOTONES.Empate)
        {
          Sound.Stop();
          Sound = new SoundPlayer(Properties.Resources.buzzer);
          Sound.Play();
          MessageBox.Show("Empate");
          

        }

        if (Botones.Botones == BOTONES.Adelantado1)
        {
          Sound.Stop();
          Sound = new SoundPlayer(Properties.Resources.buzzer);
          Sound.Play();
          MessageBox.Show("Botón 1 Adelantado");
          

        }

        if (Botones.Botones == BOTONES.Adelantado2)
        {
          Sound.Stop();
          Sound = new SoundPlayer(Properties.Resources.buzzer);
          Sound.Play();
          MessageBox.Show("Botón 2 Adelantado");
          

        }

      }
      catch
      {
        

        for (int i = 0; i < 5; i++)
        {

          Pulsadores.SendCmd("L3");
          Thread.Sleep(200);
          Pulsadores.SendCmd("L0");
          Thread.Sleep(200);
        }
        MessageBox.Show("Nadie presionó");
      }

     

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
      }
      else
      {

        MessageBox.Show("No se detectaron puertos seriales.");
        btnAbrirPuerto.Enabled = false;

      }

    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      Pulsadores.ClosePort();
    }

    private void button3_Click(object sender, EventArgs e)
    {

       

    }

    
  }
}
