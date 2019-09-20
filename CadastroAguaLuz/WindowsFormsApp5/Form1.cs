using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFI_POO
{
    public partial class Form1 : Form
    {
        const int MAXCLIENT = 500000;
        string cadastro; //armazena o novo cpf/cnpj na criação de conta
        Conta[] c = new Conta[MAXCLIENT];
        int nVet, mes, op; // op: operação de criação, sendo o op 0 para executar o script de leitura do mês de dezembro do ano anterior
        //op 12: executa o script do mês de dezembro
        int[] valorDeLeitura = new int[13]; //valores referência das leituras;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileManager.CarregarDados(c);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBox3.Enabled = true;
            maskedTextBox4.Enabled = false;
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBox3.Enabled = false;
            maskedTextBox4.Enabled = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (maskedTextBox1.Enabled)
                {
                    if (Controller.Localizador(maskedTextBox1, c, ref nVet))
                    {
                        Controller.ImprimiDados(label5,label6, label7, label2, label14, label11, label13, label25, ref mes, numericUpDown1, c, nVet);
                        Controller.AtivaPaineis(panel1, panel2, panel3, panel4);
                        maskedTextBox1.Clear();
                        maskedTextBox6.Clear();
                        radioButton6.Checked = false;
                        radioButton5.Checked = false;
                        maskedTextBox1.Enabled = false;
                        maskedTextBox6.Enabled = false;
                        MessageBox.Show("Conta encontrada \nCPF/CNPJ: " + c[nVet].Cadastro, "Resultado da busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("CPF inválido ou inexistente", "Resultado da busca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else if (maskedTextBox6.Enabled)
                {
                    if (Controller.Localizador(maskedTextBox6, c, ref nVet))
                    {
                        Controller.ImprimiDados(label5, label6, label7, label2, label14, label11, label13, label25, ref mes, numericUpDown1, c, nVet);
                        Controller.AtivaPaineis(panel1, panel2, panel3, panel4);
                        maskedTextBox1.Clear();
                        maskedTextBox6.Clear();
                        radioButton6.Checked = false;
                        radioButton5.Checked = false;
                        maskedTextBox1.Enabled = false;
                        maskedTextBox6.Enabled = false;
                        MessageBox.Show("Conta encontrada \nCPF/CNPJ: " + c[nVet].Cadastro, "Resultado da busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("CNPJ inválido ou inexistente", "Resultado da busca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

            catch (FormatException)
            {
                MessageBox.Show("Erro: Número em formato inválido", "Resultado da busca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor da conta sem imposto: R$" + c[nVet].calcContaSemImpostos(mes).ToString() + "\nValor dos impostos: R$" + (c[nVet].calcConta(mes) - c[nVet].calcContaSemImpostos(mes)).ToString(), "CONTA SEM IMPOSTOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cadastro;

            if (maskedTextBox3.Enabled)
            {
                cadastro = maskedTextBox3.Text;
                cadastro = cadastro.Trim();

                if (cadastro.Length == 12)
                {
                    c[nVet].transfTitular(maskedTextBox3.Text);
                    FileManager.AlteraTitular(c, maskedTextBox3.Text);
                    Controller.ImprimiDados(label5, label6, label7, label2, label14, label11, label13, label25, ref mes, numericUpDown1, c, nVet);
                    maskedTextBox3.Clear();
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    maskedTextBox3.Enabled = false;
                    maskedTextBox4.Enabled = false;
                    MessageBox.Show("Títular foi alterado com sucesso", "Troca de títular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("Erro: CPF inválido", "Troca de títular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (maskedTextBox4.Enabled)
            {
                cadastro = maskedTextBox4.Text;
                cadastro.Trim();
                if (cadastro.Length == 16)
                {
                    c[nVet].transfTitular(maskedTextBox4.Text);
                    FileManager.AlteraTitular(c, maskedTextBox4.Text);
                    Controller.ImprimiDados(label5, label6, label7, label2, label14, label11, label13, label25, ref mes, numericUpDown1, c, nVet);
                    maskedTextBox4.Clear();
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    maskedTextBox3.Enabled = false;
                    maskedTextBox4.Enabled = false;
                    MessageBox.Show("Títular foi alterado com sucesso", "Troca de títular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("Erro: CNPJ inválido", "Troca de títular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

           
        }

        private void Panel4_EnabledChanged(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button5_Click(object sender, EventArgs e)
        {
            bool typeChecked;
            bool categoriaChecked;

            categoriaChecked = (radioButton9.Checked || radioButton10.Checked);
            typeChecked = (radioButton7.Checked || radioButton8.Checked);

            if (maskedTextBox2.Enabled)
            {
               cadastro = maskedTextBox2.Text;

                cadastro.Trim();

                if (cadastro.Length == 12)
                {

                    if (typeChecked)
                    {
                        if (categoriaChecked)
                        {
                            groupBox2.Enabled = true;
                            groupBox3.Enabled = false;
                            groupBox4.Enabled = false;
                            groupBox6.Enabled = false;
                            Controller.DesativaPaineis(panel1, panel2, panel3);
                            label18.Text = "Dezembro/Ano anterior";
                            MessageBox.Show("CPF válido: Agora adicione os valores de leitura no campo abaixo para cada mês, começando de dezembro do ano anterior", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {
                            MessageBox.Show("Selecione a categoria: Comercial ou Residencial", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Selecione o tipo da conta antes de prosseguir", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    MessageBox.Show("CPF inválido: Digite um CPF válido", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (maskedTextBox5.Enabled)
            {
               cadastro = maskedTextBox5.Text;

             cadastro.Trim();

                if (cadastro.Length == 16)
                {
                    if (typeChecked)
                    {
                        if (categoriaChecked)
                        {
                            groupBox2.Enabled = true;
                            groupBox3.Enabled = false;
                            groupBox4.Enabled = false;
                            Controller.DesativaPaineis(panel1, panel2, panel3);
                            label18.Text = "Dezembro/Ano anterior";
                            MessageBox.Show("CNPJ válido: Agora adicione os valores de leitura no campo abaixo para cada mês, começando de dezembro do ano anterior", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {
                            MessageBox.Show("Selecione a categoria: Comercial ou Residencial", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Selecione o tipo da conta antes de prosseguir", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    MessageBox.Show("CNPJ inválido: Digite um CPF válido", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Selecione o tipo de cadastro", "Criar conta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBox1.Enabled = true;
            maskedTextBox6.Enabled = false;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBox1.Enabled = false;
            maskedTextBox6.Enabled = true;
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBox2.Enabled = true;
            maskedTextBox5.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            maskedTextBox2.Enabled = false;
            maskedTextBox5.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (op != 12)
                {
                    Controller.ReadAndAction(valorDeLeitura, ref op, maskedTextBox7, label18, radioButton8, radioButton7,radioButton9, radioButton10, ref cadastro, c);
                    label23.Text = valorDeLeitura[op - 1].ToString();
                }
                else
                {
                    Controller.ReadAndAction(valorDeLeitura, ref op, maskedTextBox7, label18, radioButton8, radioButton7,radioButton9, radioButton10, ref cadastro, c);
                    Controller.AtivaPaineis(panel1, panel2, panel3, panel4);
                    groupBox3.Enabled = true;
                    groupBox4.Enabled = true;
                    groupBox6.Enabled = true;
                    groupBox2.Enabled = false;
                    FileManager.AdicionarDados(c[Conta.Contador]);
                    nVet = Conta.Contador;
                    Conta.Contador++;
                    label18.Text = "";
                    maskedTextBox7.Clear();
                    maskedTextBox7.Focus();
                    Controller.ImprimiDados(label5, label6, label7, label2, label14, label11, label13, label25, ref mes, numericUpDown1, c, nVet);
                    Controller.AtivaPaineis(panel1, panel2, panel3, panel4);
                    maskedTextBox5.Clear();
                    maskedTextBox2.Clear();
                    radioButton8.Checked = false;
                    radioButton7.Checked = false;
                    radioButton9.Checked = false;
                    radioButton10.Checked = false;
                    label23.Text = "";
                }
            }

            catch (FormatException)
            {
                MessageBox.Show("Valor inválido", "Nova Conta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Controller.RepresentaMesLabel(label20, numericUpDown2);
            Controller.CalcDif(label16, label19, c[nVet], numericUpDown2, numericUpDown3);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Controller.RepresentaMesLabel(label21, numericUpDown3);
            Controller.CalcDif(label16, label19, c[nVet], numericUpDown2, numericUpDown3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Controller.RepresentaMesLabel(label10, numericUpDown1);
            mes = Convert.ToInt32(numericUpDown1.Value);
            Controller.ImprimiDados(label5, label6, label7, label2, label14, label11, label13, label25, ref mes, numericUpDown1, c, nVet);
            Controller.AtivaPaineis(panel1, panel2, panel3, panel4);
        }
    }
    }
