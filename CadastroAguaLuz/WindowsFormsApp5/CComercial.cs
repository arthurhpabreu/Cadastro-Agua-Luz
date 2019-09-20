using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFI_POO
{
    class CComercial : Conta
    {
        public override int calcConsumo(int mes)
        {
            consumo[mes - 1] = valorDeLeitura[mes] - valorDeLeitura[mes - 1];
            return consumo[mes - 1];
        }

        public override double calcConta(int mes)
        {
            double valorConsumo;

            if (tipo == "luz")
            {
                valorConsumo = (consumo[mes - 1] * 0.49) + (consumo[mes - 1] * 0.29);
                valorPagamento[mes - 1] = valorConsumo + ((valorConsumo * 25) / 75);
            }

            else if (tipo == "agua")
            {
                if (consumo[mes - 1] <= 5)
                    valorConsumo = (consumo[mes - 1] * 1.89) + (consumo[mes - 1] * 0.95);

                else if (consumo[mes - 1] > 5 && consumo[mes - 1] <= 10)
                    valorConsumo = (consumo[mes - 1] * 2.83) + (consumo[mes - 1] * 1.41);

                else if (consumo[mes - 1] > 10 && consumo[mes - 1] <= 20)
                    valorConsumo = (consumo[mes - 1] * 7.91) + (consumo[mes - 1] * 3.96);

                else if (consumo[mes - 1] > 20 && consumo[mes - 1] <= 40)
                    valorConsumo = (consumo[mes - 1] * 9.04) + (consumo[mes - 1] * 4.52);

                else if (consumo[mes -1] > 40 && consumo[mes -1] <= 200)
                {
                    valorConsumo = (consumo[mes - 1] * 9.41) + (consumo[mes - 1] * 4.71);
                }

                else
                {
                    valorConsumo = (consumo[mes - 1] * 9.98) + (consumo[mes - 1] * 4.99);
                }

                valorPagamento[mes - 1] = valorConsumo + 21.61 + 10.81;
            }

            return valorPagamento[mes - 1];
        }

        public override double calcContaSemImpostos(int mes)
        {
            if (tipo == "luz")
            {
                return (consumo[mes - 1] * 0.49) + (consumo[mes - 1] * 0.29);
            }

            else if (tipo == "agua")
            {
                if (consumo[mes - 1] <= 5)
                    return (consumo[mes - 1] * 1.89) + (consumo[mes - 1] * 0.95);

                else if (consumo[mes - 1] > 5 && consumo[mes - 1] <= 10)
                   return (consumo[mes - 1] * 2.83) + (consumo[mes - 1] * 1.41);

                else if (consumo[mes - 1] > 10 && consumo[mes - 1] <= 20)
                    return (consumo[mes - 1] * 7.91) + (consumo[mes - 1] * 3.96);

                else if (consumo[mes - 1] > 20 && consumo[mes - 1] <= 40)
                    return (consumo[mes - 1] * 9.04) + (consumo[mes - 1] * 4.52);

                else if (consumo[mes - 1] > 40 && consumo[mes - 1] <= 200)
                {
                   return (consumo[mes - 1] * 9.41) + (consumo[mes - 1] * 4.71);
                }

                else
                {
                   return (consumo[mes - 1] * 9.98) + (consumo[mes - 1] * 4.99);
                }
            }

            return 0;
            }

        public CComercial(string tipo, int leituraMesAnterior, int leituraMesAtual, string cadastro, int month)
        {
            this.tipo = tipo;
            valorDeLeitura[month - 1] = leituraMesAnterior;
            valorDeLeitura[month] = leituraMesAtual;
            this.cadastro = cadastro;
            nRegistro = Contador;
            categoria = "Comercial";
        }


    }
}
