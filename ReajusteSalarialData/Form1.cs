using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReajusteSalarialData
{
    public partial class ReajusteSalarial : Form
    {
        public ReajusteSalarial()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                RepositorioFuncionario repositorio = new RepositorioFuncionario();
                DataTable table = new DataTable();

                
                table.Columns.Add("Codigo", typeof(string));
                table.Columns.Add("Salario", typeof(double));
                table.Columns.Add("Percentual", typeof(double));
                table.Columns.Add("Novo salario", typeof(double));
                RepositorioFuncionario repos = new RepositorioFuncionario();

                foreach (string linha in File.ReadAllLines(ofd.FileName))
                {
                    table.Rows.Add(linha.Split(';'));
                    string[] dados = linha.Split(';');
                    int codigo = Convert.ToInt32(dados[0]);
                    double salario = Convert.ToDouble(dados[1]);
                    Funcionario func = new Funcionario(codigo,salario);
                    
                    repos.Inserir(func);
                    
                    
                }
                int count = 0;
                foreach (DataRow row in table.Rows)
                {
                    
                    row["Percentual"] = repos.ObterUmaPorcentagem(count);
                    row["Novo Salario"] = repos.NovoSalario(count);
                    count++;


                }
                lblTotalSemReajuste.Text = string.Format("{0:c}", repos.totalSemReajuste());

                lblTotalComReajuste.Text = string.Format("{0:c}", repos.totalComReajuste());

                lblPercentualReajuste.Text = string.Format("{0:n}%", repos.totalPercentual());

                // row["Percentual"] = percentual;
                // row["Novo Salario"] = novoSalario;





                dataGridView1.DataSource = table;

                
               
                
            }
               
            }

        }
    }

