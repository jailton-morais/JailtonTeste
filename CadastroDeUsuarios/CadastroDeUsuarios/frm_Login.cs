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
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void bt_entrar_Click(object sender, EventArgs e)
        {
            UsuarioDTO usuario = new UsuarioDTO();
            try
            {

                usuario.Usu_login =  tb_nome.Text;
                usuario.Usu_senha = tb_senha.Text;

                bool retorno = new UsuarioBLL().AutenticaUsuario(usuario);
                if (retorno.Equals(true))
                {
                    MessageBox.Show("Seja Bem Vindo!");

                    ((frm_MenuPrincipalMDI)Application.OpenForms["frm_MenuPrincipalMDI"]).AlterarStatus();


                    this.Close();

                }
                else
                {
                    MessageBox.Show("Login ou senha invalidos !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

          
        }
    }
}
