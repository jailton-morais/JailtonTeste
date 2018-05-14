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
using CadastroDeUsuarios.BLL;



namespace CadastroDeUsuarios
{
    public partial class frm_Incluir : Form
    {
        public frm_Incluir()
        {
            InitializeComponent();
            cb_sexo.SelectedIndex = 0;
        }

        private void bt_novo_Click(object sender, EventArgs e)
        {
            habilitaCampos();
            bt_novo.Enabled = false;
            bt_confirmar.Enabled = true;
            tb_nome.Focus();
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

        private void bt_confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioDTO usuario = new UsuarioDTO();
                usuario.Usu_nome = tb_nome.Text;
                usuario.Usu_sexo = cb_sexo.Text;
                usuario.Usu_login = tb_login.Text;
                usuario.Usu_senha = tb_senha.Text;
                usuario.Usu_dataNascimento =Convert.ToDateTime( tb_data_nascimento.Text );

                int x = new UsuarioBLL().insereUsuario(usuario);
                if (x > 0)
                {
                    MessageBox.Show("Gravado com sucesso!");
                    desabilitaCampos();
                    limpaCampos();
                    bt_novo.Enabled = true;
                    bt_confirmar.Enabled = false;
                }
             
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message);
            }
        }
    }
}
