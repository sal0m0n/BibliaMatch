using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.IO;
using System.Reflection;

namespace BMCommNet
{
  public class SerialPortEx : SerialPort // extensión de la clase SerialPort para evitar errores en el manejo del puerto.
  {

    #region Constructor

    public SerialPortEx(): base() // constructor por defecto
    {

    }

    #endregion

    #region Dispose nuevo
    /// <summary>
    /// Para evitar errores de acceso no autorizado en el puerto cuando se desconecta alguna impresora con cable USB mientras se tiene el puerto abierto.
    /// </summary>
    /// <param name="disposing"></param>
    protected override void Dispose(bool disposing)
    {
      // our variant for
      // 
      // http://social.msdn.microsoft.com/Forums/en-US/netfxnetcom/thread/8b02d5d0-b84e-447a-b028-f853d6c6c690
      // http://connect.microsoft.com/VisualStudio/feedback/details/140018/serialport-crashes-after-disconnect-of-usb-com-port

      var stream = (Stream)typeof(SerialPort).GetField("internalSerialStream", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this);

      if (stream != null)
      {
        try
        {
          stream.Dispose();
        }
        catch
        {
        }
      }

      base.Dispose(disposing);
    }

    #endregion

  }
}
