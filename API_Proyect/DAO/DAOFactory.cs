using API_Proyect.DAO.Catalog;
using API_Proyect.DAO.Employee;
using Microsoft.Extensions.Logging;

namespace API_Proyect.DAO
{
    public sealed class DAOFactory
    {
        public static IEmployeeDAO GetEmployeeDAO()
        {
            IEmployeeDAO iemployeedao;

            try
            {
                iemployeedao = new EmployeeDAOSQL();
            }
            catch (Exception error)
            {
                
                throw new Exception("DAOFactory.GetEmployeeDAO no pudo crear la instancia de IEmployeeDAO : ", error);
            }

            return iemployeedao;
        }

        public static ICatalog GetCatalogDAO()
        {
            ICatalog icatalog;

            try
            {
                icatalog = new CatalogDAOSQL();
            }
            catch (Exception error)
            {

                throw new Exception("DAOFactory.GetCatalogDAO no pudo crear la instancia de ICatalog : ", error);
            }

            return icatalog;
        }
    }
}
