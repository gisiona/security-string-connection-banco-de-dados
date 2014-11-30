using System;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CriptografarDescriptografarDados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            try
            {
                ConexaoCriptografada.ConexaoBancoDados cs = new ConexaoCriptografada.ConexaoBancoDados();
                conn = new SqlConnection(cs.DecryptConnectionString());
                conn.Open();
                MessageBox.Show("Conectado com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConexaoCriptografada.ConexaoBancoDados cs = new ConexaoCriptografada.ConexaoBancoDados();
            txtDescriptografar.Text = txtCriptografar.Text;
            txtCriptografar.Text = cs.EncryptConnectionString(txtCriptografar.Text);
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtDescriptografar.Text.Length != 0)
            {
                ConexaoCriptografada.ConexaoBancoDados cs = new ConexaoCriptografada.ConexaoBancoDados();
                txtCriptografar.Text = txtDescriptografar.Text;
                txtDescriptografar.Text = cs.DecryptConnectionString();
            }
        }
    }
}
