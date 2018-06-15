using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
    public partial class ListaCarro : Form
    {
        string nomeAntigo = string.Empty;
        List<Carro> carros = new List<Carro>();

        public ListaCarro()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Carro carro = new Carro()
                {
                    Nome = txtNome.Text,
                    Marca = txtMarca.Text,
                    Valor = Convert.ToDecimal(txtValor.Text),
                    AnoFabricacao = Convert.ToInt16(txtAnoFabricacao.Text)

                };
                if (nomeAntigo == "")
                {
                    carros.Add(carro);
                    MessageBox.Show("Cadastrado com sucesso");
                    AdicionarCarroTabela(carro);
                }
                else
                {
                   /* for (int i = 0; i < carros.Count(); i++)
                    {
                        Carro carroAux = carros[i];
                        if (carroAux.Nome == nomeAntigo)
                        {
                            carros[i] = carro;
                        }
                    }*/
                    int linha = carros.FindIndex(x => x.Nome == nomeAntigo);
                    carros[linha] = carro;
                    EditarCarroNaTabela(carro, linha);
                    MessageBox.Show("Alterado com sucesso");
                    nomeAntigo = string.Empty;
                    
                }
                
                AdicionarCarroTabela(carro);
                tabControl1.SelectedIndex = 0;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtMarca.Text = "";
            txtValor.Text = "";
            txtAnoFabricacao.Text = "";
        }

        private void AdicionarCarroTabela(Carro carro)
        {
            dataGridView1.Rows.Add(new Object[] { carro.Nome, carro.Marca, carro.Valor, carro.AnoFabricacao });
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Cadastre um carro");
                return;
            }

            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma linha");
                return;
            }

            int linhaSelecionada = dataGridView1.CurrentRow.Index;
            string nome = dataGridView1.Rows[linhaSelecionada].Cells[0].Value.ToString();

            for (int i = 0; i < carros.Count(); i ++)
            {
                Carro carro = new Carro();
                if (carro.Nome == nome)
                {
                    carros.RemoveAt(i);
                }
            }

            //carros.Remove(carros.Find(x => x.Nome == nome));
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int linhaSelecionada = dataGridView1.CurrentRow.Index;
            string nome = dataGridView1.Rows[linhaSelecionada].Cells[0].Value.ToString();
            foreach (Carro carro in carros)
            {
                if (carro.Nome == nome)
                {
                    txtNome.Text = carro.Nome;
                    txtMarca.Text = carro.Marca;
                    txtValor.Text = Convert.ToString(carro.Valor);
                    txtAnoFabricacao.Text = Convert.ToString(carro.AnoFabricacao);
                    nomeAntigo = carro.Nome;
                    tabControl1.SelectedIndex = 1;
                    break;
                }
            }
        }

        private void EditarCarroNaTabela(Carro carro, int linha)
        {
            dataGridView1.Rows[linha].Cells[0].Value = carro.Nome;
            dataGridView1.Rows[linha].Cells[1].Value = carro.Marca;
            dataGridView1.Rows[linha].Cells[2].Value = carro.Valor;
            dataGridView1.Rows[linha].Cells[3].Value = carro.AnoFabricacao;
        }
    }
}
