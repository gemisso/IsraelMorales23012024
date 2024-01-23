using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using Proyecto.Models;
using Microsoft.AspNetCore.Authorization;
using Proyecto.Models.Entities;

namespace Proyecto.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConectorAPI conectorAPI;
        public EmployeeController(IConectorAPI conectorAPI)
        {
            this.conectorAPI = conectorAPI;
        }

  
        // GET: EmployeeController
        public ActionResult Index()
        {

            return View();
        }

              
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public int Delete(string employee)
        {

            return conectorAPI.DeleteEmployee(employee);
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public int Set(string employee)
        {

            return conectorAPI.SetEmployee(employee);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public List<EmployeeVO> Get(string employee)
        {

            return conectorAPI.GetEmployes(employee);

        }
    }
}
