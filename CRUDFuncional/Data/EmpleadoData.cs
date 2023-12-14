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
                            Cargo = (dr["IdEmpleado"].ToString())
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
                        oContacto.Cargo = (dr["IdEmpleado"].ToString());
                       
                    }
                }
            }
                return oContacto;
        }


    }
}
