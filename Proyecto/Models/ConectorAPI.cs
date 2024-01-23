using Newtonsoft.Json;
using Proyecto.Models.Entities;
using System.Net;

namespace Proyecto.Models
{
    public class ConectorAPI : IConectorAPI
    {
        private readonly string BaseURL = "http://localhost:5241/API/";

        public List<EmployeeVO> GetEmployes(string employee)
        {
            List<EmployeeVO> respuesta = null;


            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = BaseURL;
                var url = "GetEmployee";
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                //var response =  webClient.UploadString(url, JsonConvert.SerializeObject(employee));
                var response = webClient.UploadString(url, employee);
                if (!string.IsNullOrEmpty(response))
                {
                    respuesta = JsonConvert.DeserializeObject<List<EmployeeVO>>(response);
                }
            }

            return respuesta;
        }

        public int SetEmployee(string employee)
        {
            int respuesta = -1;

            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = BaseURL;
                var url = "SetEmployee";
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                var response = webClient.UploadString(url, employee);
                if (!string.IsNullOrEmpty(response))
                {
                    respuesta = Convert.ToInt32(response);
                }
            }

            return respuesta;
        }

        public int DeleteEmployee(string employee)
        {
            int respuesta = -1;

            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = BaseURL;
                var url = "DeleteEmployee";
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                var response = webClient.UploadString(url, employee);
                if (!string.IsNullOrEmpty(response))
                {
                    respuesta = Convert.ToInt32(response);
                }
            }

            return respuesta;
        }

        public List<StatesVO> GetStates()
        {
            List<StatesVO> respuesta = null;

            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = BaseURL;
                var url = "GetStates";
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                var response = webClient.DownloadString(url);
                if (!string.IsNullOrEmpty(response))
                {
                    respuesta = JsonConvert.DeserializeObject<List<StatesVO>>(response);
                }
            }

            return respuesta;
        }

        public List<PositionVO> GetPositions()
        {
            List<PositionVO> respuesta = null;

            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = BaseURL;
                var url = "GetPosition";
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                var response = webClient.DownloadString(url);
                if (!string.IsNullOrEmpty(response))
                {
                    respuesta = JsonConvert.DeserializeObject<List<PositionVO>>(response);
                }
            }

            return respuesta;
        }



    
    }

}
