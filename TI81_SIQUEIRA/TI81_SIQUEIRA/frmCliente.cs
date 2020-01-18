using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TI81_SIQUEIRA
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            mskCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskTelefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            //EXTENSÃO DA CLASSE CLIENTE PARA O MÉTODO GRAVAR
            Cliente i = new Cliente(txtNome.Text, txtEndereco.Text, mskCEP.Text, mskCPF.Text, txtBairro.Text, mskTelefone.Text, txtCidade.Text, txtEstado.Text);
            txtCodigo.Text = i.gravar().ToString();

            MessageBox.Show("Usuário " + txtCodigo.Text + " gravado com sucesso", "Cadastro");

            //txtCodigo.Clear();
            //txtNome.Clear();
            //txtEndereco.Clear();
            //txtBairro.Clear();
            //txtCidade.Clear();
            //txtEstado.Clear();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            mskCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskTelefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            //EXTENSÃO DA CLASSE CLIENTE PARA O MÉTODO ALTERAR
            Cliente a = new Cliente(Convert.ToInt32(txtCodigo.Text), txtNome.Text, txtEndereco.Text, mskCEP.Text, mskCPF.Text, txtBairro.Text, mskTelefone.Text, txtCidade.Text, txtEstado.Text);
            a.alterar();

            MessageBox.Show("Usuário " + txtCodigo.Text + " alterado com sucesso", "Cadastro");

            //txtCodigo.Clear();
            //txtNome.Clear();
            //txtEndereco.Clear();
            //txtBairro.Clear();
            //txtCidade.Clear();
            //txtEstado.Clear();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            mskCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskTelefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            //EXTENSÃO DA CLASSE CLIENTE PARA O MÉTODO PESQUISAR
            Cliente c = new Cliente();
            c.consultar(Convert.ToInt32(txtCodigo.Text));
            txtNome.Text = c.Nome;
            txtEndereco.Text = c.Endereco;
            mskCEP.Text = c.CEP;
            mskCPF.Text = c.CPF;
            txtBairro.Text = c.Bairro;
            mskTelefone.Text = c.Telefone;
            txtCidade.Text = c.Cidade;
            txtEstado.Text = c.Estado;
        }


        

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            WebCEP(mskCEP.Text);
            txtBairro.Text = _bairro;
            txtCidade.Text = _cidade;
            txtEndereco.Text = _endereco;
            txtEstado.Text = _estado;
            //txtEndereco.Text = _tipo_logradouro;
        }


        string _estado, _cidade, _bairro, _endereco, _resultado;  //globais no frmCliente               //_tipo_logradouro, _resultado;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); //FECHAR FORMULARIO
        }

        //BUCAR O CEP
        public void WebCEP(string CEP)
        {
            _estado = ""; _cidade = ""; _bairro = ""; _endereco = "";      //_tipo_logradouro = ""; _endereco = "";
            _resultado = "Cep não encontrado";
            //criar um DataSet a partir de um XML(retorno do site)                //ADO .NET
            DataSet ds = new DataSet();
            //popular - encher -  carregar - preencher o dataset com o resultado XML
            ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + CEP.Replace("-", "").Trim() + "&formato=xml");
            string resultado = "0";
            if (ds != null)//se o dataset não estiver vazio (null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    resultado = ds.Tables[0].Rows[0]["resultado"].ToString();
                    switch (resultado)
                    {
                        case "1":
                            _estado = ds.Tables[0].Rows[0]["uf"].ToString();
                            _cidade = ds.Tables[0].Rows[0]["cidade"].ToString();
                            _bairro = ds.Tables[0].Rows[0]["bairro"].ToString();
                           // _tipo_logradouro = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString();
                            _endereco = ds.Tables[0].Rows[0]["logradouro"].ToString();
                            _resultado = "CEP Completo";
                            break;
                        case "2":
                            _estado = ds.Tables[0].Rows[0]["uf"].ToString();
                            _cidade = ds.Tables[0].Rows[0]["cidade"].ToString();
                            _bairro = "";
                            //_tipo_logradouro = "";
                            _endereco = "";
                            _resultado = "CEP único";
                            break;
                        default:
                            _estado = "";
                            _cidade = "";
                            _bairro = "";
                            //_tipo_logradouro = "";
                            _endereco = "";
                            _resultado = "CEP não Encontrado";
                            break;

                    }
                }
            }
        }

    }
}
