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
    public partial class frm_Remove : Form
    {
        int codUsuSelecionado = -1;

        public frm_Remove()
        {
            InitializeComponent();
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


        private void bt_remover_Click(object sender, EventArgs e)
        {
            try
            {
                if (codUsuSelecionado < 0)
                {
                    MessageBox.Show( "Selecione um usuario antes");
                    return;
                }
                UsuarioDTO usuario = new UsuarioDTO();
                usuario.Usu_id = codUsuSelecionado;

                int x = new UsuarioBLL().excluiUsuario(usuario);
                if (x > 0)
                {
                   MessageBox.Show("Excluido com sucesso!");
                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message);
            }
        }

       

        private void frm_Remove_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int sel = dataGridView1.CurrentRow.Index;
            tb_nome.Text = Convert.ToString(dataGridView1["NOME", sel].Value);
            cb_sexo.Text = Convert.ToString(dataGridView1["SEXO", sel].Value);
            tb_login.Text = Convert.ToString(dataGridView1["LOGIN", sel].Value);
            tb_senha.Text = Convert.ToString(dataGridView1["SENHA", sel].Value);
            tb_data_nascimento.Text = Convert.ToString(dataGridView1["DATA_NASCIMENTO", sel].Value);
            codUsuSelecionado = Convert.ToInt32(dataGridView1["ID", sel].Value);
        }
    }
    }

