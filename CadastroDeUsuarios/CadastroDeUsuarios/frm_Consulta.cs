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
using CadastroDeUsuarios.DTO;

namespace CadastroDeUsuarios
{
    public partial class frm_Consulta : Form
    {
        public frm_Consulta()
        {
            InitializeComponent();
        }

        private void bt_atualizar_Click(object sender, EventArgs e)
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

        private void frm_Consulta_Load(object sender, EventArgs e)
        {

        }
    }
}
