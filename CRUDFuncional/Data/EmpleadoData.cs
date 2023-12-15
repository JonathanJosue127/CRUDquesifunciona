using CRUDFuncional.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace CRUDFuncional.Data
{
    public class EmpleadoData
    {
        public List<EmpleadosModel> Listar()
        {
            var oLista = new List<EmpleadosModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        
                        oLista.Add(new EmpleadosModel() { 
                            IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                            NombreEmpleado = (dr["NombreEmpleado"].ToString()),
                            Cargo = (dr["Cargo"].ToString())
                        });
                    }
                }
                            return oLista;
            }
        }

        public EmpleadosModel Obtener(int IdEmpleado)
        {
            var oContacto = new  EmpleadosModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdEmpleado", IdEmpleado);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oContacto.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]);
                        oContacto.NombreEmpleado = (dr["NombreEmpleado"].ToString());
                        oContacto.Cargo = (dr["Cargo"].ToString());
                       
                    }
                }
            }
                return oContacto;
        }

        public bool Guardar(EmpleadosModel oempleado)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("IdEmpleado",oempleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("NombreEmpleado",oempleado.NombreEmpleado);
                    cmd.Parameters.AddWithValue("Cargo", oempleado.Cargo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            
            return rpta;
        }

        public bool Editar(EmpleadosModel oempleado)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdEmpleado", oempleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("NombreEmpleado", oempleado.NombreEmpleado);
                    cmd.Parameters.AddWithValue("Cargo", oempleado.Cargo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Eliminar (int IdEmpleado)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdEmpleado", IdEmpleado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }

            return rpta;
        }

        
    }
}
