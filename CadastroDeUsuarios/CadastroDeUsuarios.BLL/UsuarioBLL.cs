using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroDeUsuarios.DAL;
using CadastroDeUsuarios.DTO;

namespace CadastroDeUsuarios.BLL
{
    public class UsuarioBLL
    {
        public bool AutenticaUsuario(UsuarioDTO usuario)
        {
            try
            {
                return new UsuarioDAL().AutenticaUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
