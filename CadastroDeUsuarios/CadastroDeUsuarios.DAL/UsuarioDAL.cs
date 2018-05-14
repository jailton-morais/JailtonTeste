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
        public int insereUsuario(UsuarioDTO usuario)
        {
            try
            {
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings.Default.str_conexao ;
                SqlCommand CM = new SqlCommand();
                CM.CommandType = CommandType.Text;
                CM.CommandText = "INSERT INTO USUARIO ( usu_nome,usu_sexo,usu_login,usu_senha,usu_datanascimento ) " +
                                             " VALUES ( @usu_nome,@usu_sexo,@usu_login,@usu_senha,@usu_datanascimento )";

                CM.Parameters.Add("@usu_datanascimento", SqlDbType.DateTime).Value = usuario.Usu_dataNascimento ;
                CM.Parameters.Add("@usu_nome", SqlDbType.VarChar).Value = usuario.Usu_nome;
                CM.Parameters.Add("@usu_sexo", SqlDbType.VarChar).Value = usuario.Usu_sexo;
                CM.Parameters.Add("@usu_login", SqlDbType.VarChar).Value = usuario.Usu_login;
                CM.Parameters.Add("@usu_senha", SqlDbType.VarChar).Value = usuario.Usu_senha;
                CM.Connection = CON;

                CON.Open();
                int qtd = CM.ExecuteNonQuery();

                return qtd;

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
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings.Default.str_conexao ;
                SqlCommand CM = new SqlCommand();
                CM.CommandType = CommandType.Text;
                CM.CommandText = 
   " UPDATE Usuario "+
   "    SET usu_nome = @usu_nome " +
   "   ,usu_sexo = @usu_sexo " +
   "   ,usu_login = @usu_login " +
   "   ,usu_senha = @usu_senha " +
   "   ,usu_dataNascimento = @usu_dataNascimento " +
   " WHERE usu_id=@usu_id ";

                CM.Parameters.Add("@usu_datanascimento", SqlDbType.DateTime).Value = usuario.Usu_dataNascimento;
                CM.Parameters.Add("@usu_nome", SqlDbType.VarChar).Value = usuario.Usu_nome;
                CM.Parameters.Add("@usu_sexo", SqlDbType.VarChar).Value = usuario.Usu_sexo;
                CM.Parameters.Add("@usu_login", SqlDbType.VarChar).Value = usuario.Usu_login;
                CM.Parameters.Add("@usu_senha", SqlDbType.VarChar).Value = usuario.Usu_senha;
                CM.Parameters.Add("@usu_id", SqlDbType.Int).Value = usuario.Usu_id;
                CM.Connection = CON;

                CON.Open();
                int qtd = CM.ExecuteNonQuery();

                return qtd;

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
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings.Default.str_conexao;
                SqlCommand CM = new SqlCommand();
                CM.CommandType = CommandType.Text;
                CM.CommandText = "DELETE USUARIO  WHERE USU_ID = @USU_ID";

                CM.Parameters.Add("@USU_ID", SqlDbType.VarChar).Value = usuario.Usu_id;
                CM.Connection = CON;

                CON.Open();
                int qtd = CM.ExecuteNonQuery();

                return qtd;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

        public IList<UsuarioDTO> carregaUsuario()
        {
  
                try
                {
                    SqlConnection conexao = new SqlConnection();
                    conexao.ConnectionString = Properties.Settings.Default.str_conexao;
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from usuario";
                    cmd.Connection = conexao;

                    SqlDataReader Lendo;
                    IList<UsuarioDTO> listaUsuarioDTO = new List<UsuarioDTO>();
                    conexao.Open();

                    Lendo = cmd.ExecuteReader();
                    if (Lendo.HasRows)
                    {
                        while (Lendo.Read())
                        {
                            UsuarioDTO usuario = new UsuarioDTO();
                            usuario.Usu_id = Convert.ToInt32(Lendo["USU_ID"]);
                            usuario.Usu_login = Convert.ToString(Lendo["USU_LOGIN"]);
                            usuario.Usu_nome = Convert.ToString(Lendo["USU_NOME"]);
                            usuario.Usu_senha = Convert.ToString(Lendo["USU_SENHA"]);
                            usuario.Usu_sexo = Convert.ToString(Lendo["USU_SEXO"]);
                            usuario.Usu_dataNascimento = Convert.ToDateTime(Lendo["USU_DATANASCIMENTO"]);
                            listaUsuarioDTO.Add(usuario);
                        }
                    }


                    return listaUsuarioDTO;
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
        }
}
