using BoletoBus.Web.Models.EmpleadosModels;
using BoletoBus.Web.Models.Result;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BoletoBus.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: EmpleadoController
        HttpClientHandler httpHandler = new HttpClientHandler();

        public EmpleadoController()
        {
            this.httpHandler = new HttpClientHandler();
            this.httpHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };

        }
        public async Task<ActionResult> Index()
        {
            EmpleadoGetListResult empleadoGetList = new EmpleadoGetListResult();

            using (var httpClient = new HttpClient(this.httpHandler))
            {
                var url = "http://localhost:5297/api/Empleado/GetEmpleado";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        empleadoGetList = JsonConvert.DeserializeObject<EmpleadoGetListResult>(apiResponse);

                        if (!empleadoGetList.success)
                        {
                            ViewBag.Massage = empleadoGetList;
                            return View();
                        }
                    }
                }
            }
            return View(empleadoGetList.data);
        }
    


        // GET: EmpleadoController/Details/5
        public async Task<ActionResult> Details(int id)
        { 
            EmpleadoGetResult empleadoGetResult = new EmpleadoGetResult();

            using (var httpClient = new HttpClient(this.httpHandler))
            {
                var url = $"http://localhost:5297/api/Empleado/GetEmpleadoById?id={id}";
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        empleadoGetResult = JsonConvert.DeserializeObject<EmpleadoGetResult>(apiResponse);

                        if (!empleadoGetResult.success)
                        {
                            ViewBag.Massage = empleadoGetResult;
                            return View();
                        }
                    }
                }
            }
            return View(empleadoGetResult.data);
        }
    

    

    // GET: EmpleadoController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: EmpleadoController/Create
    [HttpPost]
        [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(EmpleadoGuardarModel empleadoGuardar)
    {
        try
        {
                EmpleadoGuardarResult empleadoGuardarResult = new EmpleadoGuardarResult();

                using (var httpClient = new HttpClient(this.httpHandler))
                {
                    var url = $"http://localhost:5297/api/Empleado/GuardarEmpleado";


                    using (var response = await httpClient.PostAsJsonAsync<EmpleadoGuardarModel>(url, empleadoGuardar))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            empleadoGuardarResult = JsonConvert.DeserializeObject<EmpleadoGuardarResult>(apiResponse);

                            if (!empleadoGuardarResult.success)
                            {
                                ViewBag.Massage = empleadoGuardarResult;
                                return View();
                            }
                        }
                    }
                }

                return RedirectToAction(nameof (Index));
        }

            
        catch
        {
            return View();
        }
    }

        // GET: EmpleadoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
