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
        public void AlterarStatus()
        {
            this.toolStripMenuCadastro.Enabled = true;
            this.toolStripAberto.Visible = true;
            this.toolStripFechado.Visible = false;
        }

        public  frm_MenuPrincipalMDI()
        {
            InitializeComponent();
            this.toolStripMenuCadastro.Enabled = false;
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

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form filha = new frm_Consulta();
            filha.MdiParent = this;
            filha.Show();
        }

      
        private void incluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form filha = new frm_Incluir();
            filha.MdiParent = this;
            filha.Show();
        }

        private void alterarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form filha = new frm_Altera();
            filha.MdiParent = this;
            filha.Show();
        }

        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form filha = new frm_Remove();
            filha.MdiParent = this;
            filha.Show();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripAberto_Click(object sender, EventArgs e)
        {
            this.toolStripMenuCadastro.Enabled = false;
            this.toolStripAberto.Visible = false;
            this.toolStripFechado.Visible = true;
            FecharFormulariosFilhos();
         

             //  ((frm_Consulta)Application.OpenForms["frm_Consulta"]).Close() ;

        }

        private void FecharFormulariosFilhos()
        {
            // percorre todos os formulários abertos
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                // se o formulário for filho
                if (Application.OpenForms[i].IsMdiChild)
                {
                    // fecha o formulário
                    Application.OpenForms[i].Close();
                }
            }
        }

    }
}
