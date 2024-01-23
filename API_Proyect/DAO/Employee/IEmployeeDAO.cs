using API_Proyect.Entities;
using System.Data;

namespace API_Proyect.DAO.Employee
{
    public interface IEmployeeDAO
    {
        int Set(EmployeeVO employee);

        int Delete(EmployeeVO employee);

        List<EmployeeVO> Get(EmployeeVO employee);
        
    }
}
