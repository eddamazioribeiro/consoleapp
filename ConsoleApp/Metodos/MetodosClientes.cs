using System;
using System.Collections.Generic;
using System.Text;


public static class MetodosExtensao
{
    public static double RetornaMetade(this int Valor)
    {
        return Valor / 2;
    }

    public static double DescontaImpostos(this double Valor)
    {
        // Desconta imposto
        return Valor - 10;
    }

    public static string LetraInicialMaiuscula(this string Texto)
    {
        return Texto.Substring(0, 1).ToUpper() +
               Texto.Substring(1, Texto.Length - 1).ToLower();

    }

    public static string LetraInicialMaiuscula(this string Texto,
                                               bool UltimaMinuscula)
    {
        if (UltimaMinuscula)
        {
            return Texto.Substring(0, 1).ToUpper() +
                  Texto.Substring(1, Texto.Length - 1).ToLower();
        }
        else
        {
            return Texto.Substring(0, 1).ToUpper() +
                  Texto.Substring(1, Texto.Length - 1);
        }
    }

}

namespace ConsoleApp.Classes

{
    public partial class Cliente : IDisposable
    {
        public Cliente()
        {

        }

        public Cliente(int Codigo)
        {
            // TODO: Criar o procedimento baseado no param Codigo
        }

        public void Dispose()
        {
            this.Gravar();
            
        }

        public void Gravar() { }

        public void Apagar() { }

    }

        
}
