using API_Proyect.Entities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace API_Proyect.DAO.Employee
{
    public class EmployeeDAOSQL : IEmployeeDAO
    {
        private SqlConnection conn = null;

        private ConnectionState GetConnection()
        {
            try
            {
                if (conn != null && (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Open))
                {
                    conn.Close();
                    conn.Dispose();
                }

                conn = new SqlConnection("Data Source=LAPTOP-I30TULD2\\SQLEXPRESS2019;Initial Catalog=Proyecto;User Id=sa;Password=QAZxsw123;");

                if (conn == null)
                {
                    return ConnectionState.Closed;
                }

                conn.Open();

            }
            catch (SqlException error)
            {
                throw new Exception("No se puede realizar la conexion a la BD: ", error);
            }
            catch (Exception error)
            {
                throw new Exception("No se puede realizar la conexion a la BD: ", error);
            }

            return ConnectionState.Open;
        }



        public int Delete(EmployeeVO employee)
        {
            int respuesta = 0;

            try
            {
                if (GetConnection() != ConnectionState.Open) return respuesta;

                using (SqlCommand cmd = new SqlCommand("Delete Empleados Where Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", employee.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                throw new Exception("No se puede realizar la consulta a la BD: ", e);
            }
            catch (Exception e)
            {
                throw new Exception("No se puede realizar la consulta a la BD: ", e);
            }
            finally
            {
                if (conn != null && (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Open)) { conn.Close(); conn.Dispose(); }
            }
            return respuesta;
        }


        public List<EmployeeVO> Get(EmployeeVO employee)
        {
            DataTable dt = new DataTable();
            List<EmployeeVO> list = new List<EmployeeVO>();
            try
            {
                if (GetConnection() != ConnectionState.Open) return list;

                using (SqlDataAdapter cmd = new SqlDataAdapter("select em.*, p.puesto, es.estado From Empleados em \tInner join Puestos p on p.idpuesto = em.PuestoId\tInner join Estados es on es.idestado = em.estadoid\r\n\t", conn))
                {
                    cmd.Fill(dt);

                    foreach (DataRow item in dt.Rows)
                    {
                        EmployeeVO emp = new EmployeeVO();
                        emp.Fotografia = item.IsNull("Fotografia") ? string.Empty : Convert.ToString(item["Fotografia"]);
                        emp.Nombre = item.IsNull("Nombre") ? string.Empty : Convert.ToString(item["Nombre"]);
                        emp.APaterno = item.IsNull("APaterno") ? string.Empty : Convert.ToString(item["APaterno"]);
                        emp.FechaNacimiento = Convert.ToString("FechaNacimiento");
                        emp.FechaContratacion = Convert.ToString(item["FechaContratacion"]);
                        emp.Direccion = item.IsNull("Direccion") ? string.Empty : Convert.ToString(item["Direccion"]);
                        emp.Telefono = item.IsNull("Telefono") ? string.Empty : Convert.ToString(item["Telefono"]);
                        emp.Email = item.IsNull("Email") ? string.Empty : Convert.ToString(item["Email"]);
                        emp.EstadoId = item.IsNull("EstadoId") ? 0 : Convert.ToInt32(item["EstadoId"]);
                        emp.PuestoId = item.IsNull("PuestoId") ? 0 : Convert.ToInt32(item["PuestoId"]);
                        list.Add(emp);
                    }

                }

            }
            catch (SqlException e)
            {
                throw new Exception("No se puede realizar la consulta a la BD: ", e);
            }
            catch (Exception e)
            {
                throw new Exception("No se puede realizar la consulta a la BD: ", e);
            }
            finally
            {
                if (conn != null && (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Open)) { conn.Close(); conn.Dispose(); }
            }

            return list;
        }

        public int Set(EmployeeVO employee)
        {

            int respuesta = 0;

            try
            {
                if (GetConnection() != ConnectionState.Open) return respuesta;


                using (SqlCommand cmd = new SqlCommand("SetEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", employee.Id);
                    cmd.Parameters.AddWithValue("@Fotografia", employee.Fotografia);
                    cmd.Parameters.AddWithValue("@Nombre", employee.Nombre);
                    cmd.Parameters.AddWithValue("@APaterno", employee.APaterno);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", employee.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@FechaContratacion", employee.FechaContratacion);
                    cmd.Parameters.AddWithValue("@Direccion", employee.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", employee.Telefono);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@EstadoId", employee.EstadoId);
                    cmd.Parameters.AddWithValue("@PuestoId", employee.PuestoId);
                    cmd.ExecuteNonQuery();
                }


            }
            catch (SqlException e)
            {
                throw new Exception("No se puede realizar la consulta a la BD: ", e);
            }
            catch (Exception e)
            {
                throw new Exception("No se puede realizar la consulta a la BD: ", e);
            }
            finally
            {
                if (conn != null && (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Open)) { conn.Close(); conn.Dispose(); }
            }

            return respuesta;
        }



    }
}
