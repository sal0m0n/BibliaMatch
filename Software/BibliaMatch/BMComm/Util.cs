using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMCommNet
{
  class Util
  {

    internal static double doValueDouble(string tramaString)
    {
      //////////////////////////////
      int size = tramaString.Length;
      int dif = size - 2;

      double valor = Double.Parse(tramaString.Substring(0, dif));
      // para evitar errores con numeros negativos...
      if (valor < 0)
        valor -= Double.Parse(tramaString.Substring(dif)) / 100;
      else
        valor += Double.Parse(tramaString.Substring(dif)) / 100;

      return valor;
    }

  }
}
