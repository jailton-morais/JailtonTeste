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

        public IList<UsuarioDTO> CarregarUsuario()
        {
                try
                {
                    return new UsuarioDAL().carregaUsuario();
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }

        public int insereUsuario(UsuarioDTO usuario)
        {
            try
            {
                return new UsuarioDAL().insereUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int alteraUsuario(UsuarioDTO usuario)
        {
            try
            {
                return new UsuarioDAL().alteraUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int excluiUsuario(UsuarioDTO usuario)
        {
            try
            {
                return new UsuarioDAL().excluiUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
