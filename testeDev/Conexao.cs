using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testeDev
{
    public class Conexao
    {
        public string conec = "SERVER=127.0.0.1; DATABASE=joao; UID=root; PWD=usuario; PORT=3306;";
        public MySqlConnection con = null;

        public void AbrirConexao()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Open();
            }
            catch (Exception ex)
            {

                HttpContext.Current.Response.Write("Erro ao conectar" + ex);
            }
        }

        public void FecharConexao()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Close();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Erro ao encerrar" + ex);
            }
        }

    }
}