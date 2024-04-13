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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexao.Conectar();

            double valor = double.Parse(txtValor.Text);
            string categoria = cbCategoria.Text;

            string sql = "INSERT INTO tab_financas(valor,categoria) VALUE(@valor, @categoria)";
            MySqlCommand cmd = new MySqlCommand(sql, Conexao.conn);

            cmd.Parameters.AddWithValue("valor", valor);
            cmd.Parameters.AddWithValue("categoria", categoria);
            cmd.ExecuteNonQuery();
        }
    }
}
