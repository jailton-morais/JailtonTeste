using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroDeUsuarios.DTO;
using System.Data.SqlClient;
using System.Data;

namespace CadastroDeUsuarios.DAL
{
    public class UsuarioDAL
    {
        public bool AutenticaUsuario(UsuarioDTO usuario)
        {
            bool logado = false;
            try
            {
                SqlConnection conexao = new SqlConnection();
                conexao.ConnectionString = Properties.Settings.Default.str_conexao;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from usuario where usu_login=@login and usu_senha=@senha ";
                cmd.Parameters.Add("@login", SqlDbType.NVarChar).Value = usuario.Usu_login;
                cmd.Parameters.Add("@senha", SqlDbType.NVarChar).Value = usuario.Usu_senha;
                cmd.Connection = conexao;

                SqlDataReader ER;
               
                conexao.Open();

                ER = cmd.ExecuteReader();
                if (ER.HasRows)
                {
                    logado = true;
                }


                return logado;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
