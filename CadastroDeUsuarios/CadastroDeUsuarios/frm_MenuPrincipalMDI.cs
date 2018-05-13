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
    public partial class frm_MenuPrincipalMDI : Form
    {
       

        public frm_MenuPrincipalMDI()
        {
            InitializeComponent();
            toolStripMenuCadastro.Enabled = false;

        }

        private void toolStripFechado_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frm_Login>().Count() > 0)
            {

            }
            else
            {
                Form filha = new frm_Login();
                filha.MdiParent = this;
                filha.Show();
            }
        }

        private void sobreOSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form sobre = new frm_Sobre();
            sobre.MdiParent = this;
            sobre.Show();
        }
    }
}
