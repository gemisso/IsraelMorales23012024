using API_Proyect.Entities;
using System.Data;

namespace API_Proyect.Repository
{
    public interface IRepository
    {
        Task<int> Set(EmployeeVO employee);

        Task<int> Delete(EmployeeVO employee);

        Task<List<EmployeeVO>> Get(EmployeeVO employee);


        Task<List<StatesVO>> GetStates();

        Task<List<PositionVO>> GetPosition();
    }
}
