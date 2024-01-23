using Proyecto.Models.Entities;

namespace Proyecto.Models
{
    public interface IConectorAPI
    {
        List<EmployeeVO> GetEmployes(string employee);

        int SetEmployee(string employee);

        int DeleteEmployee(string employee);

        List<StatesVO> GetStates();

        List<PositionVO> GetPositions();
    }
}
