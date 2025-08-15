using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaDeCompras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Verificar se txbproduto está vazio:
            if (txbProduto.Text.Length == 0)
            {
                MessageBox.Show("O nome do produto não pode estar vazio!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Mudar a cor do fundo e a cor da letar:
                txbProduto.BackColor = Color.Red;
                txbProduto.ForeColor = Color.White;
            }
            // Verificar se txbproduto tem menos que 2 (duas) letras:
            else if (txbProduto.Text.Length < 2)
            {
                MessageBox.Show("O nome do produto não pode estar vazio!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Mudar a cor do fundo e a cor da letar:
                txbProduto.BackColor = Color.Red;
                txbProduto.ForeColor = Color.White;
            }
            else
            {
                // Verificar se o item ja existe na lista:
                if (libProdutos.Items.Contains(txbProduto.Text))
                {
                    MessageBox.Show($"Já existe {txbProduto.Text} na lista", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Limpar o campo
                    txbProduto.Clear();
                }
                else
                {
                    // Adicionar o item na lista:
                    libProdutos.Items.Add(txbProduto.Text);
                    MessageBox.Show($"{txbProduto.Text} foi adicionado na lista de compras!", "Show!", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Retornar o tbxProduto a cor normal
                    txbProduto.BackColor = Color.White;
                    txbProduto.ForeColor = Color.Black;

                    // Limpar o campo: ou pode ser txbProduto.Text = "";
                    txbProduto.Clear();
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Tem certeza que deseja apagar tudo?", "Atenção!", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Se a resposta for "sim", apagar:
            if (resposta == DialogResult.Yes)
            {
                libProdutos.Items.Clear();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Verificar se o usário não selecionou nada:
            if(libProdutos.SelectedIndex == -1)
            {
                MessageBox.Show($"Selecione um item para remover!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }  
            else
            {
                //Salvar temporariamente o nome do item que será removido:
                string itemRemovido = libProdutos.SelectedItem.ToString();

                // Remover o item selecionado:
                libProdutos.Items.RemoveAt(libProdutos.SelectedIndex);

                MessageBox.Show($"{itemRemovido} foi removido da lista!","Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void txbProduto_KeyDown(object sender, KeyEventArgs e)
        {
            // Pressionar o enter para não precisar clicar no botão ADD
            if (e.KeyCode == Keys.Enter)
            {
                // "Pressionar" o btnAdicionar
                btnAdicionar.PerformClick();
            }
        }
    }
}
