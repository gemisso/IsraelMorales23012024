using API_Proyect.Entities;
using API_Proyect.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API_Proyect.Controllers
{
    [ApiController]
    [Route("[controller]")]
  
    public class APIController : ControllerBase
    {

        private readonly IRepository respository;
        public APIController(IRepository respository)
        {
            this.respository = respository;
        }


        [HttpPost]
        [Route("GetEmployee")]
        public async Task<List<EmployeeVO>> GetEmployee(EmployeeVO employee)
        {
            return await respository.Get(employee);
        }

        [HttpPost]
        [Route("SetEmployee")]
        ///Metodo para actualizar e insertar
        public async Task<int> SetEmployee(EmployeeVO employee)
        {
            return await respository.Set(employee);
        }

        [HttpPost]
        [Route("DeleteEmployee")]
        public async Task<int> DeleteEmployee(EmployeeVO employee)
        {
            return await respository.Delete(employee);
        }

        [HttpPost]
        [Route("GetStates")]
        public async Task<List<StatesVO>> GetStates()
        {
            return await respository.GetStates();
        }

        [HttpPost]
        [Route("GetPosition")]
        public async Task<List<PositionVO>> GetPosition()
        {
            return await respository.GetPosition();
        }
    }
}