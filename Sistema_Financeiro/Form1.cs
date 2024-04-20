using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Financeiro
{
    public partial class Form1 : Form
    {
        // Variáveis Globais do formulário
        int id = 0;
        public Form1()
        {
            InitializeComponent();
        }

        public void SelecionarDados()
        {
            try
            {
                // Conecata com o banco
                Conexao.Conectar();
                // Executar transação com o banco
                string sql = "SELECT * FROM tab_financas";
                MySqlCommand cmd = new MySqlCommand(sql, Conexao.conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                dgvLista.DataSource = dt;
                Conexao.Desconectar();


            }catch (Exception ex)
            {
                MessageBox.Show("Erro ao selecionar os dados da tabela Finanças");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Conexao.Conectar();

                double valor = double.Parse(txtValor.Text);
                string categoria = cbCategoria.Text;

                string sql = "UPDATE tab_financas SET valor = @valor, categoria = @categoria WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, Conexao.conn);

                cmd.Parameters.AddWithValue("valor", valor);
                cmd.Parameters.AddWithValue("categoria", categoria);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Atualização efetuada com sucesso");

                txtValor.Clear();
                cbCategoria.SelectedIndex = -1;
                SelecionarDados();

                Conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Errou ao tentar atualizar");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelecionarDados();
            txtValor.Clear();
            cbCategoria.SelectedIndex = -1;
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dgvLista.CurrentRow.Cells[0].Value.ToString());
            txtValor.Text = dgvLista.CurrentRow.Cells[1].Value.ToString();
            cbCategoria.Text = dgvLista.CurrentRow.Cells[2].Value.ToString();
            btnAtualizar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                Conexao.Conectar();

                double valor = double.Parse(txtValor.Text);
                string categoria = cbCategoria.Text;

                string sql = "INSERT INTO tab_financas(valor,categoria) VALUE(@valor, @categoria)";
                MySqlCommand cmd = new MySqlCommand(sql, Conexao.conn);

                cmd.Parameters.AddWithValue("valor", valor);
                cmd.Parameters.AddWithValue("categoria", categoria);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cadastrado com Sucesso!");
                
                txtValor.Clear();
                cbCategoria.SelectedIndex = -1;
                SelecionarDados();

                Conexao.Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                Conexao.Conectar();

                string sql = "DELETE FROM tab_financas WHERE id=@id;";
                MySqlCommand cmd = new MySqlCommand( sql, Conexao.conn);

                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Item excluido com sucesso!");
                
                txtValor.Clear();
                cbCategoria.SelectedIndex = -1;
                SelecionarDados();

                Conexao.Desconectar();
            }
            catch 
            {
                MessageBox.Show("Erro ao tentar excluir o item.");
            }
        }
    }
}
