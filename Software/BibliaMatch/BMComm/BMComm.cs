using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BMCommNet
{
    public class BMComm : BMCommCommon
    {
       
      
        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase BMComm.
        /// </summary>
        public BMComm() : base()
        {

        }


        #endregion


        #region Metodos Publicos


   

        /// <summary>
        /// Sube el ButtonData y retorna un objeto de tipo ButtonData con los parámetros de información.
        
        /// </summary>
        public ButtonData GetButton()
        {
          ButtonData Status;
          int rep = 0;
          string sBuffer = string.Empty;

          rep = this.SubirDataStatus("P", out sBuffer);


          if (rep >= 3) // Mínimo debe tener 3 bytes para que el ButtonData sea válido.
          {
            Status = new ButtonData(sBuffer);
            
          }
          else
          {

          
            throw new Exception("Error");
          }

          return Status;
        }
  
        #endregion
    }
}
