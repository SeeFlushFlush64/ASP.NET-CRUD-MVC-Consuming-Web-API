using CRUDMVCusingWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CRUDMVCusingWebAPI.Controllers
{
    public class EmployeeController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7000/api");
        private readonly HttpClient _httpClient;
        public EmployeeController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(_httpClient.BaseAddress + "/employees/GetAllEmployees");
            if (responseMessage.IsSuccessStatusCode)
            { 
                string data = responseMessage.Content.ReadAsStringAsync().Result;
                employeeList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data); 
            }
            return View(employeeList);
        }

        [HttpGet]
        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await _httpClient.PostAsync(_httpClient.BaseAddress + "/employees/AddEmployee", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Employee Added.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }
    }
}
