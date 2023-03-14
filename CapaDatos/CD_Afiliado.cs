using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
namespace CapaDatos
{
    public class CD_Afiliado
    {
        public List<Afiliado> listar()
        {
            List<Afiliado> lista = new List<Afiliado>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select IdAfiliado, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, FechaNacimiento, Sexo, CorreoElectronico, NoIdentificacion, Clave, Direccion, Telefono, Activo, FechaUltimoPago, FechaProximoPago, PagoVencido from Tbl_Afiliado";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {

                            lista.Add(
                                new Afiliado()
                                {
                                    IdAfiliado = Convert.ToInt32(dr["IdAfiliado"]),
                                    PrimerNombre = dr["PrimerNombre"].ToString(),
                                    SegundoNombre = dr["SegundoNombre"].ToString(),
                                    PrimerApellido = dr["PrimerApellido"].ToString(),
                                    SegundoApellido = dr["SegundoApellido"].ToString(),
                                    FechaNacimiento = dr["FechaNacimiento"].ToString(),
                                    Sexo = dr["Sexo"].ToString(),
                                    CorreoElectronico = dr["CorreoElectronico"].ToString(),
                                    NoIdentificacion = dr["NoIdentificacion"].ToString(),
                                    Clave = dr["Clave"].ToString(),
                                    Direccion = dr["Direccion"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Activo = Convert.ToBoolean(dr["Activo"]),
                                    FechaUltimoPago = dr["FechaUltimoPago"].ToString(),
                                    FechaProximoPago = dr["FechaProximoPago"].ToString(),
                                    PagoVencido = Convert.ToBoolean(dr["PagoVencido"])

                                });

                        }
                    }



                }

            }
            catch
            {
                lista = new List<Afiliado>();
            }


            return lista;

        }

        public int Registrar(Afiliado obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = String.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarAfiliado", oconexion);
                    cmd.Parameters.AddWithValue("PrimerNombre", obj.PrimerNombre);
                    cmd.Parameters.AddWithValue("SegundoNombre", obj.SegundoNombre);
                    cmd.Parameters.AddWithValue("PrimerApellido", obj.PrimerApellido);
                    cmd.Parameters.AddWithValue("SegundoApellido", obj.SegundoApellido);
                    cmd.Parameters.AddWithValue("FechaNacimiento", obj.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Sexo", obj.Clave);
                    cmd.Parameters.AddWithValue("CorreoElectronico", obj.CorreoElectronico);
                    cmd.Parameters.AddWithValue("NoIdentificacion", obj.NoIdentificacion);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.AddWithValue("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("Mensaje", SqlDbType.VarChar).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;
            }
            return idautogenerado;

        }

        public bool Editar(Afiliado obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarAfiliado", oconexion);
                    cmd.Parameters.AddWithValue("IdAfiliado", obj.IdAfiliado);
                    cmd.Parameters.AddWithValue("PrimerNombre", obj.PrimerNombre);
                    cmd.Parameters.AddWithValue("SegundoNombre", obj.SegundoNombre);
                    cmd.Parameters.AddWithValue("PrimerApellido", obj.PrimerApellido);
                    cmd.Parameters.AddWithValue("SegundoApellido", obj.SegundoApellido);
                    cmd.Parameters.AddWithValue("FechaNacimiento", obj.FechaNacimiento);
                    cmd.Parameters.AddWithValue("Sexo", obj.Sexo);
                    cmd.Parameters.AddWithValue("CorreoElectronico", obj.CorreoElectronico);
                    cmd.Parameters.AddWithValue("NoIdentificacion", obj.NoIdentificacion);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.AddWithValue("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("Mensaje", SqlDbType.VarChar).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;

        }

        public bool Eliminar(int id, out string Mensaje)
        {

            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top (1) from Tbl_Afiliado where IdAfiliado =@Id", oconexion);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        public bool EditarPago(Afiliado obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarPago", oconexion);
                    cmd.Parameters.AddWithValue("IdAfiliado", obj.IdAfiliado);
                    cmd.Parameters.AddWithValue("FechaUltimoPago", obj.FechaUltimoPago);
                    cmd.Parameters.AddWithValue("FechaProximoPago", obj.FechaProximoPago);
                    cmd.Parameters.AddWithValue("PagoVencido", obj.PagoVencido);
                    cmd.Parameters.AddWithValue("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("Mensaje", SqlDbType.VarChar).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;

        }
    }
}
