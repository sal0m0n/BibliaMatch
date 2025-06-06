using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMCommNet
{

  public enum BOTONES
  {
    Ninguno,
    Boton1,
    Boton2,
    Adelantado1,
    Adelantado2,
    Empate
  }

  public class ButtonData
  {

    public BOTONES Botones = BOTONES.Ninguno;

     /// <summary>
    /// Creates a new instance of ButtonData
        /// </summary>
        /// <param name="trama">Cadena de caracteres que contiene la data de reportes</param>   
    internal ButtonData(string trama)
        {
            if (trama != null)
            {
                if (trama.Length > 0)
                {
                    try
                    {
                            string[] arrayParameter = trama.Split((char)0X0A);
                            if (arrayParameter.Length > 0)
                            {
                              this.Botones = (BOTONES)  int.Parse(arrayParameter[0]);
                              
                              }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        return;
                    }
                }
             
            }
        }

  }
}
