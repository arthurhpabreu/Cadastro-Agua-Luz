using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFI_POO
{
   static class Comparador
    {
        public static int Compara(List<string> listaCadastros, List<string> listaTipos, string cadastro, string type, ref int refX)
        {
            for (int x = 0; x < listaCadastros.Count; x++)
            {
                if (string.Equals(listaCadastros.ElementAt(x), cadastro) && string.Equals(listaTipos.ElementAt(x), type))
                {
                    refX = x;
                    return 0; //permissao para criar objeto
                }
            }

            if (cadastro.Length == 16)
                return 16;

            else if (cadastro.Length == 12)
                return 12;

            else
                return 0;
        }
    }
}
