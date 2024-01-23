using API_Proyect.DAO;
using API_Proyect.DAO.Employee;
using API_Proyect.Entities;
using System.Data;

namespace API_Proyect.Repository
{
    public class Repository : IRepository
    {
        public async Task<int> Delete(EmployeeVO employee)
        {
            return await Task.FromResult(DAOFactory.GetEmployeeDAO().Delete(employee));
        }

        public async Task<List<EmployeeVO>> Get(EmployeeVO employee)
        {
            return await Task.FromResult(DAOFactory.GetEmployeeDAO().Get(employee));
        }

        public async Task<int> Set(EmployeeVO employee)
        {
            return await Task.FromResult(DAOFactory.GetEmployeeDAO().Set(employee));
        }

        public async Task<List<StatesVO>> GetStates()
        {
            return await Task.FromResult(DAOFactory.GetCatalogDAO().GetStates());
        }

        public async Task<List<PositionVO>> GetPosition()
        {
            return await Task.FromResult(DAOFactory.GetCatalogDAO().GetPosition());
        }
    }
}
