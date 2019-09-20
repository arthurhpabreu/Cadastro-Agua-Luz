using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFI_POO
{
    class CResidencial : Conta
    {
        public override int calcConsumo(int mes)
        {
            consumo[mes - 1] = valorDeLeitura[mes] - valorDeLeitura[mes -1];
            return consumo[mes - 1];
        }

        public override double calcConta(int mes)
        {
            double valorConsumo;

           if (tipo == "luz")
            {
                if (consumo[mes - 1] <= 30)
                    valorConsumo = (consumo[mes - 1] * 0.16) + (consumo[mes - 1] * 0.29);

                else if (consumo[mes - 1] >= 31 && consumo[mes -1] <= 100)
                    valorConsumo = (consumo[mes - 1] * 0.28) + (consumo[mes - 1] * 0.29);

                else if (consumo[mes -1] >= 101 && consumo[mes -1] <= 220)
                    valorConsumo = (consumo[mes - 1] * 0.42) + (consumo[mes - 1] * 0.29);

                else
                    valorConsumo = (consumo[mes - 1] * 0.47) + (consumo[mes - 1] * 0.29);

                valorPagamento[mes - 1] = valorConsumo + ((valorConsumo * 30) / 70);
            }

           else if (tipo == "agua")
            {
              if (consumo[mes - 1] <= 5)
                    valorConsumo = (consumo[mes - 1] * 1.67) + (consumo[mes - 1] * 0.42);

              else if (consumo[mes -1] > 5 && consumo[mes - 1] <= 10)
                    valorConsumo = (consumo[mes - 1] * 2.51) + (consumo[mes - 1] * 0.62);

              else if (consumo[mes - 1] > 10 && consumo[mes - 1] <= 15)
                    valorConsumo = (consumo[mes - 1] * 4.81) + (consumo[mes - 1] * 1.20);

                else if (consumo[mes - 1] > 15 && consumo[mes - 1] <= 20)
                    valorConsumo = (consumo[mes - 1] * 6.69) + (consumo[mes - 1] * 1.67);

              else if (consumo[mes -1] > 20 && consumo[mes -1] <= 40)
                    valorConsumo = (consumo[mes - 1] * 9.20) + (consumo[mes - 1] * 2.30);

              else
                    valorConsumo = (consumo[mes - 1] * 12.97) + (consumo[mes - 1] * 3.24);

                valorPagamento[mes - 1] = valorConsumo + 14.29 + 3.57;
            }


            return valorPagamento[mes - 1];
        }

        public override double calcContaSemImpostos(int mes)
        {
            calcConsumo(mes);

            if (tipo == "luz")
            {
                if (consumo[mes - 1] <= 30)
                return  (consumo[mes - 1] * 0.16) + (consumo[mes - 1] * 0.29);

                else if (consumo[mes - 1] >= 31 && consumo[mes - 1] <= 100)
                  return (consumo[mes - 1] * 0.28) + (consumo[mes - 1] * 0.29);

                else if (consumo[mes - 1] >= 101 && consumo[mes - 1] <= 220)
                   return (consumo[mes - 1] * 0.42) + (consumo[mes - 1] * 0.29);

                else
                  return (consumo[mes - 1] * 0.47) + (consumo[mes - 1] * 0.29);
            }

            else if (tipo == "agua")
            {
                if (consumo[mes - 1] <= 5)
                   return (consumo[mes - 1] * 1.67) + (consumo[mes - 1] * 0.42);

                else if (consumo[mes - 1] > 5 && consumo[mes - 1] <= 10)
                   return (consumo[mes - 1] * 2.51) + (consumo[mes - 1] * 0.62);

                else if (consumo[mes - 1] > 10 && consumo[mes - 1] <= 15)
                    return (consumo[mes - 1] * 4.81) + (consumo[mes - 1] * 1.20);

                else if (consumo[mes - 1] > 15 && consumo[mes - 1] <= 20)
                    return (consumo[mes - 1] * 6.69) + (consumo[mes - 1] * 1.67);

                else if (consumo[mes - 1] > 20 && consumo[mes - 1] <= 40)
                    return (consumo[mes - 1] * 9.20) + (consumo[mes - 1] * 2.30);

                else
                    return (consumo[mes - 1] * 12.97) + (consumo[mes - 1] * 3.24);
            }

            return 0;
            }

        public CResidencial(string tipo, int leituraMesAnterior, int leituraMesAtual, string cadastro, int month)
        {
            this.tipo = tipo;
            valorDeLeitura[month -1] = leituraMesAnterior;
            valorDeLeitura[month] = leituraMesAtual;
            this.cadastro = cadastro;
            nRegistro = Contador;
            categoria = "Residencial";
        }

    }
}
