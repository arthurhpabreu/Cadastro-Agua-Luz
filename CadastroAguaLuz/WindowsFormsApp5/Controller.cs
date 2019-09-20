using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFI_POO
{
   static class Controller
    {
        public static string retornaTipo(RadioButton radioButton8, RadioButton radioButton7)
        {
            if (radioButton8.Checked)
            {
                return "agua";
            }
            else if (radioButton7.Checked)
            {
                return "luz";
            }

            else
            {
                return "erro";
            }

        }

        public static bool Localizador(MaskedTextBox mascara, Conta [] c, ref int nVet)
        {
            string texto;
            texto = mascara.Text;
            texto.Trim();

            if (texto.Length != 16 && texto.Length != 12)
                return false;

            for (int i = 0; i < Conta.Contador; i++)
            {
                if (string.Equals(c[i].Cadastro, mascara.Text))
                {
                    nVet = i;
                    return true;
                }
            }

            return false;
        }

        public static void ImprimiDados(Label label5, Label label6, Label label7, Label label2, Label label14, Label label11, Label label13, Label label25, ref int mes, NumericUpDown numericUpDown1, Conta [] c, int nVet)
        {
            double consumo;

            label5.Text = "CPF/CNPJ: ";
            label6.Text = "Consumo: ";
            label7.Text = "Valor a pagar: R$";
            label2.Text = "Tipo: ";
            label25.Text = "Categoria: ";
            label14.Text = "Valor da conta sem impostos: R$ ";
            label11.Text = "Mês em que ocorreu maior pagamento: ";
            label13.Text = "Média das contas: R$";

            mes = (int)numericUpDown1.Value;
            consumo = c[nVet].Consumo[mes - 1];
            label2.Text += c[nVet].Tipo;
            label5.Text += c[nVet].Cadastro;
            switch (c[nVet].Tipo)
            {

                //o mes estar entre 1 e 12 é corrigido no próprio metódo de calculo de consumo
                case "agua":
                    label6.Text += c[nVet].calcConsumo(mes).ToString() + " m³";
                    break;

                case "luz":
                    label6.Text += c[nVet].calcConsumo(mes).ToString() + " KW/H";
                    break;
            }
            label7.Text += c[nVet].calcConta(mes).ToString();
            label14.Text += c[nVet].calcContaSemImpostos(mes);
            label11.Text += c[nVet].MesComMaiorConta().ToString();
            label13.Text += c[nVet].ValorMedio().ToString();
            label25.Text += c[nVet].Categoria;
        }

        public static void DesativaPaineis(Panel panel1, Panel panel2, Panel panel3)
        {
            panel1.Enabled = false;
            panel2.Enabled = false;
            panel3.Enabled = false;
        }

        public static void AtivaPaineis(Panel panel1, Panel panel2, Panel panel3, Panel panel4)
        {
            panel1.Enabled = true;
            panel2.Enabled = true;
            panel3.Enabled = true;
            panel4.Enabled = true;
        }

        public static void ReadAndAction(int[] valorDeLeitura, ref int op, MaskedTextBox maskedTextBox7, Label label18, RadioButton radioButton8, RadioButton radioButton7, RadioButton radioButton9, RadioButton radioButton10, ref string cadastro, Conta [] c )
        {
            switch (op)
            {
                case 0:
                    valorDeLeitura[0] = Convert.ToInt32(maskedTextBox7.Text);
                    label18.Text = "JANEIRO";
                        op++;
                    maskedTextBox7.Clear();
                    maskedTextBox7.Focus();

                    break;

                case 1:
                    valorDeLeitura[op] = Convert.ToInt32(maskedTextBox7.Text);

                    if (valorDeLeitura[op] > valorDeLeitura[op - 1])
                    {
                        if (radioButton9.Checked)
                            c[Conta.Contador] = new CResidencial(retornaTipo(radioButton8, radioButton7), valorDeLeitura[0], valorDeLeitura[1], cadastro, op);

                        else if (radioButton10.Checked)
                        c[Conta.Contador] = new CComercial(retornaTipo(radioButton8, radioButton7), valorDeLeitura[0], valorDeLeitura[1], cadastro, op);

                        op++;
                        maskedTextBox7.Clear();
                        label18.Text = "FEVEREIRO";
                        maskedTextBox7.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Leitura do mês atual deve ser maior do que a do mês anterior", "Leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case 2:
                    valorDeLeitura[op] = Convert.ToInt32(maskedTextBox7.Text);

                    if (valorDeLeitura[op] > valorDeLeitura[op - 1])
                    {
                        c[Conta.Contador].ValorDeLeitura[op] = valorDeLeitura[op];
                        op++;
                        label18.Text = "MARÇO";
                        maskedTextBox7.Clear();
                        maskedTextBox7.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Leitura do mês atual deve ser maior do que a do mês anterior", "Leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case 3:
                    valorDeLeitura[op] = Convert.ToInt32(maskedTextBox7.Text);


                    if (valorDeLeitura[op] > valorDeLeitura[op - 1])
                    {
                        c[Conta.Contador].ValorDeLeitura[op] = valorDeLeitura[op];
                        op++;
                        label18.Text = "ABRIL";
                        maskedTextBox7.Clear();
                        maskedTextBox7.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Leitura do mês atual deve ser maior do que a do mês anterior", "Leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case 4:
                    valorDeLeitura[op] = Convert.ToInt32(maskedTextBox7.Text);

                    if (valorDeLeitura[op] > valorDeLeitura[op - 1])
                    {
                        c[Conta.Contador].ValorDeLeitura[op] = valorDeLeitura[op];
                        op++;
                        label18.Text = "MAIO";
                        maskedTextBox7.Clear();
                        maskedTextBox7.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Leitura do mês atual deve ser maior do que a do mês anterior", "Leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case 5:
                    valorDeLeitura[op] = Convert.ToInt32(maskedTextBox7.Text);

                    if (valorDeLeitura[op] > valorDeLeitura[op - 1])
                    {
                        c[Conta.Contador].ValorDeLeitura[op] = valorDeLeitura[op];
                        op++;
                        label18.Text = "JUNHO";
                        maskedTextBox7.Clear();
                        maskedTextBox7.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Leitura do mês atual deve ser maior do que a do mês anterior", "Leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case 6:
                    valorDeLeitura[op] = Convert.ToInt32(maskedTextBox7.Text);

                    if (valorDeLeitura[op] > valorDeLeitura[op - 1])
                    {
                        c[Conta.Contador].ValorDeLeitura[op] = valorDeLeitura[op];
                        op++;
                        label18.Text = "JULHO";
                        maskedTextBox7.Clear();
                        maskedTextBox7.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Leitura do mês atual deve ser maior do que a do mês anterior", "Leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case 7:
                    valorDeLeitura[op] = Convert.ToInt32(maskedTextBox7.Text);

                    if (valorDeLeitura[op] > valorDeLeitura[op - 1])
                    {
                        c[Conta.Contador].ValorDeLeitura[op] = valorDeLeitura[op];
                        op++;
                        label18.Text = "AGOSTO";
                        maskedTextBox7.Clear();
                        maskedTextBox7.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Leitura do mês atual deve ser maior do que a do mês anterior", "Leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case 8:
                    valorDeLeitura[op] = Convert.ToInt32(maskedTextBox7.Text);

                    if (valorDeLeitura[op] > valorDeLeitura[op - 1])
                    {
                        c[Conta.Contador].ValorDeLeitura[op] = valorDeLeitura[op];
                        op++;
                        label18.Text = "SETEMBRO";
                        maskedTextBox7.Clear();
                        maskedTextBox7.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Leitura do mês atual deve ser maior do que a do mês anterior", "Leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case 9:
                    valorDeLeitura[op] = Convert.ToInt32(maskedTextBox7.Text);

                    if (valorDeLeitura[op] > valorDeLeitura[op - 1])
                    {
                        c[Conta.Contador].ValorDeLeitura[op] = valorDeLeitura[op];
                        op++;
                        label18.Text = "OUTUBRO";
                        maskedTextBox7.Clear();
                        maskedTextBox7.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Leitura do mês atual deve ser maior do que a do mês anterior", "Leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case 10:
                    valorDeLeitura[op] = Convert.ToInt32(maskedTextBox7.Text);

                    if (valorDeLeitura[op] > valorDeLeitura[op - 1])
                    {
                        c[Conta.Contador].ValorDeLeitura[op] = valorDeLeitura[op];
                        op++;
                        label18.Text = "NOVEMBRO";
                        maskedTextBox7.Clear();
                        maskedTextBox7.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Leitura do mês atual deve ser maior do que a do mês anterior", "Leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case 11:
                    valorDeLeitura[op] = Convert.ToInt32(maskedTextBox7.Text);

                    if (valorDeLeitura[op] > valorDeLeitura[op - 1])
                    {
                        c[Conta.Contador].ValorDeLeitura[op] = valorDeLeitura[op];
                        op++;
                        label18.Text = "DEZEMBRO";
                        maskedTextBox7.Clear();
                        maskedTextBox7.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Leitura do mês atual deve ser maior do que a do mês anterior", "Leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case 12:
                    valorDeLeitura[op] = Convert.ToInt32(maskedTextBox7.Text);
                    if (valorDeLeitura[op] > valorDeLeitura[op - 1])
                    {
                        c[Conta.Contador].ValorDeLeitura[op] = valorDeLeitura[op];
                        op = 0;
                        MessageBox.Show("Cliente adicionado com sucesso", "Nova conta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        MessageBox.Show("Leitura do mês atual deve ser maior do que a do mês anterior", "Leitura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

            }
        }

        public static void RepresentaMesLabel(Label label, NumericUpDown numericUpDown)
        {
            switch (numericUpDown.Value)
            {
                case 1:
                    label.Text = "JANEIRO";
                    break;

                case 2:
                    label.Text = "FEVEREIRO";
                    break;

                case 3:
                    label.Text = "MARÇO";
                    break;

                case 4:
                    label.Text = "ABRIL";
                    break;

                case 5:
                    label.Text = "MAIO";
                    break;

                case 6:
                    label.Text = "JUNHO";
                    break;

                case 7:
                    label.Text = "JULHO";
                    break;

                case 8:
                    label.Text = "AGOSTO";
                    break;

                case 9:
                    label.Text = "SETEMBRO";
                    break;

                case 10:
                    label.Text = "OUTUBRO";
                    break;

                case 11:
                    label.Text = "NOVEMBRO";
                    break;

                case 12:
                    label.Text = "DEZEMBRO";
                    break;
            }
        }

        public static void CalcDif(Label label16, Label label19, Conta c, NumericUpDown numericUpDown2, NumericUpDown numericUpDown3)
        {
            int monthA, monthB;

            monthA = Convert.ToInt32(numericUpDown2.Value);
            monthB = Convert.ToInt32(numericUpDown3.Value);

            label16.Text = "Diferença de consumo: ";
            label19.Text = "Diferença em reais: R$";
            label16.Text += c.CalcDifConsumo(monthA, monthB);
            label19.Text += c.CalcDifReais(monthA, monthB);
        }

    }
}