using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testeDev
{
    public partial class index : System.Web.UI.Page
    {
        //Conexao con = new Conexao();
        string connectionString = @"SERVER = 127.0.0.1; DATABASE=joao; UID=root; PWD=usuario;";
        protected void Page_Load(object sender, EventArgs e)
        {
            //con.FecharConexao();

            if(!IsPostBack)
            {
                Limpar();
                GridFill();
            }
        }


        protected void btnSalvar_Click(object sender, EventArgs e)

        {
            if (txtnome.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo nome";
                return;
            }
            if (txtfone.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo telefone";
                return;
            }
            if (txtendereco.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo endereço";
                return;
            }
            if (txtuf.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo endereço";
                return;
            }
            if (txtcidade.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo endereço";
                return;
            }
            if (txtcpf.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo endereço";
                return;
            }
            if (txtemail.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo endereço";
                return;
            }
            Salvar();

        }

        private void Salvar()
        {

            try
            {
                using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
                {
                    sqlCon.Open();
                    MySqlCommand cmd = new MySqlCommand("ClienteAddEdit", sqlCon);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("_clienteid", Convert.ToInt32(idcliente.Value == "" ? "0" : idcliente.Value));
                    cmd.Parameters.AddWithValue("_nome", txtnome.Text.Trim());
                    cmd.Parameters.AddWithValue("_endereco", txtendereco.Text.Trim());
                    cmd.Parameters.AddWithValue("_uf", txtuf.Text.Trim());
                    cmd.Parameters.AddWithValue("_cidade", txtcidade.Text.Trim());
                    cmd.Parameters.AddWithValue("_cpf", txtcpf.Text.Trim());
                    cmd.Parameters.AddWithValue("_email", txtemail.Text.Trim());
                    cmd.Parameters.AddWithValue("_telefone", txtfone.Text.Trim());
                    cmd.ExecuteNonQuery();

                    GridFill();
                    Limpar();

                    lblMensagemOk.Text = "Salvo com Sucesso";
                }
            }
            catch(Exception ex)
            {
                lblMensagemErro.Text = ex.Message;
            }



 
        }
        void Limpar()
        {
            idcliente.Value = "";
            txtnome.Text = txtendereco.Text = txtuf.Text = txtcidade.Text = txtcpf.Text = txtemail.Text = txtfone.Text = "";
            btnSalvar.Text = "Salvar";
            btnDeletar.Enabled = false;
            lblMensagemErro.Text = lblMensagemOk.Text = "";
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        void GridFill()
        {

            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("VerTodosClientes", sqlCon);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                gvCliente.DataSource = dtbl;
                gvCliente.DataBind();

            }

        }

        protected void lnkSelect_OnClick(object sender, EventArgs e)
        {
            int clienteID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("VerPorID", sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("_clienteid", clienteID);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                txtnome.Text = dtbl.Rows[0][1].ToString();
                txtendereco.Text = dtbl.Rows[0][2].ToString();
                txtuf.Text = dtbl.Rows[0][3].ToString();
                txtcidade.Text = dtbl.Rows[0][4].ToString();
                txtcpf.Text = dtbl.Rows[0][5].ToString();
                txtemail.Text = dtbl.Rows[0][6].ToString();
                txtfone.Text = dtbl.Rows[0][7].ToString();

                idcliente.Value = dtbl.Rows[0][0].ToString();

                btnSalvar.Text = "Editar";
                btnDeletar.Enabled = true;

            }
        }
        protected void btnDeletar_Click(object sender, EventArgs e)
        {

            Deletar();
        }

        private void Deletar()
        {
            using (MySqlConnection sqlCon = new MySqlConnection(connectionString))
            {
                sqlCon.Open();
                MySqlCommand cmd = new MySqlCommand("DeletarPorID", sqlCon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("_clienteid", Convert.ToInt32(idcliente.Value == "" ? "0" : idcliente.Value));
                cmd.ExecuteNonQuery();

                GridFill();
                Limpar();

                lblMensagemOk.Text = "Deletado com Sucesso";
            }
        }
    }
}