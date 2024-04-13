using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Financeiro
{
    internal class Conexao
    {
        public static MySqlConnection conn;
        public static string conexao = 
            "server=localhost;" +
            "database=dbfn;" +
            "uid=root;" +
            "pwb=";
        public static void Conectar()
        {
            try 
            {
                conn = new MySqlConnection(conexao);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            finally 
            { 
                conn.Close();
            }

        }
        public static void Desconectar()
        {
            conn.Close();
        }
    }
}
