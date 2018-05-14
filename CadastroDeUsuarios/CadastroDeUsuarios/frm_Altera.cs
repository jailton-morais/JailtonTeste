using CadastroDeUsuarios.BLL;
using CadastroDeUsuarios.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroDeUsuarios
{
    public partial class frm_Altera : Form
    {
        int codUsuSelecionado = -1;

        public frm_Altera()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sel = dataGridView1.CurrentRow.Index;
            tb_nome.Text = Convert.ToString(dataGridView1["NOME", sel].Value);
            cb_sexo.Text = Convert.ToString(dataGridView1["SEXO", sel].Value);
            tb_login.Text = Convert.ToString(dataGridView1["LOGIN", sel].Value);
            tb_senha.Text = Convert.ToString(dataGridView1["SENHA", sel].Value);
            tb_data_nascimento.Text = Convert.ToString(dataGridView1["DATA_NASCIMENTO", sel].Value);
            codUsuSelecionado = Convert.ToInt32(dataGridView1["ID", sel].Value);
        }

        private void frm_Altera_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }


        private void CarregarGrid()
        {
            try
            {
                IList<UsuarioDTO> listaUsuarioDTO = new List<UsuarioDTO>();
                listaUsuarioDTO = new UsuarioBLL().CarregarUsuario();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = listaUsuarioDTO;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_alterar_Click(object sender, EventArgs e)
        {
            habilitaCampos();
        }

        private void bt_confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (codUsuSelecionado < 0)
                {
                    MessageBox.Show( "Selecione um usuario antes" );
                    return;
                }

                UsuarioDTO usuario = new UsuarioDTO();

                usuario.Usu_nome = tb_nome.Text;
                usuario.Usu_login = tb_login.Text;
                usuario.Usu_id = codUsuSelecionado;
                usuario.Usu_sexo = cb_sexo.Text;
                usuario.Usu_dataNascimento = Convert.ToDateTime( tb_data_nascimento.Text);
                usuario.Usu_senha = tb_senha.Text;
                

                int x = new UsuarioBLL().alteraUsuario(usuario);
                if (x > 0)
                {
                    MessageBox.Show("Gravado com sucesso!");
                 
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message);
            }
        }


        private void habilitaCampos()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox || c is ComboBox) (c as Control).Enabled = true;
            }

        }

        private void desabilitaCampos()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox || c is ComboBox) (c as Control).Enabled = false;
            }

        }


        private void limpaCampos()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox) (c as TextBox).Text = "";
            }

        }

    }
}
