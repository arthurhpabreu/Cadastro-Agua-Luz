using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TFI_POO
{
    static class FileManager
    {
        const string fileName = "contasV2.txt";

        static public void CarregarDados(Conta[] c)
        {
            StreamReader leitura = new StreamReader(fileName);
            string texto;
            string[] linhas;
            if (File.Exists(fileName))
            {
                texto = leitura.ReadToEnd();
                leitura.Close();
                linhas = texto.Split('\n');
                List<string> listaCadastros = new List<string>();
                List<string> listaTipos = new List<string>();

                try
                {

                    for (int i = 0; i < linhas.Length; i++)
                    {
                        string cadastro, type;
                        string[] monthS;
                        string[] tipos;
                        int month, mesanterior, mesatual, refX = 0, retornadoCompare;
                        tipos = linhas[i].Split(';');

                        //INFORMAÇÕES EM CADA VARIAVEL: tipos[x] = tipo da conta, cpf ou cnpj, mês/ano, leitura mpassaod, leitura matual;
                        type = tipos[0];
                        cadastro = tipos[1];
                        monthS = tipos[2].Split('/');
                        month = int.Parse(monthS[0]);
                        mesanterior = int.Parse(tipos[3]);
                        mesatual = int.Parse(tipos[4]);

                        retornadoCompare = Comparador.Compara(listaCadastros, listaTipos, cadastro, type, ref refX);

                        if (retornadoCompare == 16)
                        {
                            c[Conta.Contador] = new CComercial(type, mesanterior, mesatual, cadastro, month);
                            c[Conta.Contador].calcConsumo(month);
                            Conta.Contador++;
                            listaCadastros.Add(cadastro);
                            listaTipos.Add(type);
                        }
                        else if (retornadoCompare == 12)
                        {
                            c[Conta.Contador] = new CResidencial(type, mesanterior, mesatual, cadastro, month);
                            c[Conta.Contador].calcConsumo(month);
                            Conta.Contador++;
                            listaCadastros.Add(cadastro);
                            listaTipos.Add(type);
                        }
                        else
                        {
                            c[refX].ValorDeLeitura[month] = mesatual;
                            c[refX].ValorDeLeitura[month - 1] = mesanterior;
                            c[refX].calcConsumo(month);
                        }
                    }

                }

                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Base de dados vazia - Necessário incluir novos dados para o funcionamento correto do programa", "Nenhum resultado encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else
            {
                File.Create(fileName);
                MessageBox.Show("Base de dados vazia - Necessário incluir novos dados para o funcionamento correto do programa", "Nenhum resultado encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            }

        static public void AlteraTitular(Conta [] c, string newC)
        {
            StreamWriter escrita = new StreamWriter(fileName);
            for (int i = 0; i < Conta.Contador; i++)
            {
                string cadastro, type, mesAno;
                int mesAnterior, mesAtual;

                cadastro = c[i].Cadastro;
                type = c[i].Tipo;



                for (int x = 1; x < 13; x++)
                {
                    int xPlus = x;
                        mesAno = xPlus + "/2014";
                        mesAnterior = c[i].ValorDeLeitura[x - 1];
                        mesAtual = c[i].ValorDeLeitura[x];
                        if (x == 1 && i ==0)
                            escrita.Write(type + ";" + cadastro + ";" + mesAno + ";" + mesAnterior + ";" + mesAtual);
                        else
                            escrita.Write("\n" + type + ";" + cadastro + ";" + mesAno + ";" + mesAnterior + ";" + mesAtual);
                    
                }
            }

            escrita.Close();
        }

        static public void AdicionarDados(Conta c)
        {
            string cadastro, type, mesAno;
            int mesAnterior, mesAtual;
            StreamWriter escrita = new StreamWriter(fileName, true);

            for (int i = 1; i < 13; i++)
            {
                int xPlus = i;
                mesAno = xPlus + "/2014";
                cadastro = c.Cadastro;
                type = c.Tipo;
                mesAnterior = c.ValorDeLeitura[i - 1];
                mesAtual = c.ValorDeLeitura[i];
                escrita.Write("\n" + type + ";" + cadastro + ";" + mesAno + ";" + mesAnterior + ";" + mesAtual);
            }

            escrita.Close();

        }
    }
}
