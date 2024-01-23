using System.Data.SqlClient;
using System.Data;
using API_Proyect.Entities;

namespace API_Proyect.DAO.Catalog
{
    public class CatalogDAOSQL: ICatalog
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


        public List<StatesVO> GetStates()
        {
            DataTable dt = new DataTable();
            List<StatesVO> list = new List<StatesVO>();
            try
            {
                if (GetConnection() != ConnectionState.Open) return list;

                using (SqlDataAdapter cmd = new SqlDataAdapter("select IdEstado, Estado from Estados", conn))
                {
                    cmd.Fill(dt);

                    foreach (DataRow item in dt.Rows)
                    {
                        StatesVO emp = new StatesVO();
                        emp.Id = item.IsNull("IdEstado") ? 0 : Convert.ToInt32(item["IdEstado"]);
                        emp.Description = item.IsNull("Estado") ? string.Empty : Convert.ToString(item["Estado"]);
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

        public List<PositionVO> GetPosition()
        {
            DataTable dt = new DataTable();
            List<PositionVO> list = new List<PositionVO>();
            try
            {
                if (GetConnection() != ConnectionState.Open) return list;

                using (SqlDataAdapter cmd = new SqlDataAdapter("select IdPuesto, Puesto from Puestos Order by 1", conn))
                {
                    cmd.Fill(dt);

                    foreach (DataRow item in dt.Rows)
                    {
                        PositionVO emp = new PositionVO();
                        emp.Id = item.IsNull("IdPuesto") ? 0 : Convert.ToInt32(item["IdPuesto"]);
                        emp.Description = item.IsNull("Puesto") ? string.Empty : Convert.ToString(item["Puesto"]);
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




    }
}
