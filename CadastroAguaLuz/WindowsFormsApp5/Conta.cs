using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFI_POO
{
    abstract class Conta
    {
        public static int Contador;

        /*/Current month deverá armazenar o mês em que se deseja executar as funções
         O mês deverá ser usado com padrão de 1 a 12 sendo 1 janeiro e 12 dezembro, pelo fato de que
         a variavel valorDeLeiutra ter 13 posições sendo a 0 para armazenar o KW/H de dezembro do ano de 2013.

            Já a variavel consumo deve seguir o padrão de 0 a 11, sendo 0 janeiro e 11 dezembro, pois
            há somente 12 posições no vetor
        */

        protected int nRegistro;
        protected double media;
        protected double[] valorPagamento = new double[12];
        protected string tipo, cadastro;
        protected int [] consumo = new int[12];
        protected int[] valorDeLeitura = new int[13];
        protected string categoria;


        public int MesComMaiorConta()
        {
            double biggestValue = 0, valor;
            int m = 0;

          for (int i = 1; i < 13; i++)
            {
                valor = calcConta(i);
                if (valor > biggestValue)
                {
                    biggestValue = valor;
                    m = i;
                }
            }

            return m;
        }

        public double ValorMedio()
        {
            double valores = 0;
            
            for (int i = 1; i < 13; i++)
            {
                valores += calcConta(i);
            }

            media = valores / 12;

            return media;
        }

        public string CalcDifReais(int monthA, int monthB)
        {
            double resultD;

            resultD =calcConta(monthA) - calcConta(monthB);

            if (resultD < 0)
                resultD *= -1;

            return resultD.ToString();
        }

        public string CalcDifConsumo(int monthA, int monthB)
        {
            double resultC;
            resultC = Consumo[monthA - 1] - Consumo[monthB - 1];

            if (resultC < 0)
                resultC *= -1;

           return resultC.ToString();
        }


        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }




        public string Cadastro
        {
            get
            {
                return cadastro;
            }

            set
            {
                cadastro = value;
            }
        }

        public int[] Consumo
        {
            get
            {
                return consumo;
            }

            set
            {
                consumo = value;
            }
        }

        public int NRegistro
        {
            get
            {
                return nRegistro;
            }

            set
            {
                nRegistro = value;
            }
        }

        public int[] ValorDeLeitura
        {
            get
            {
                return valorDeLeitura;
            }

            set
            {
                valorDeLeitura = value;
            }
        }

        public string Categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                categoria = value;
            }
        }


        public abstract double calcConta(int mes);
        public abstract int calcConsumo(int mes);
        public abstract double calcContaSemImpostos(int mes);


        public void transfTitular(string newC)
        {
            if (newC.Length < 16)
                cadastro = newC;

            else if (newC.Length == 16)
                cadastro = newC;
        }



    }
}
