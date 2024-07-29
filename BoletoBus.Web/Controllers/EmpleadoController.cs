using BoletoBus.Empleado.Application.Dtos;
using BoletoBus.Web.Models.EmpleadosModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

                        if (!empleadoGetList.Success)
                        {
                            ViewBag.Massage = empleadoGetList;
                            return View();
                        }
                    }
                }
            }
            return View(empleadoGetList.Data);
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

                        if (!empleadoGetResult.Success)
                        {
                            ViewBag.Message = empleadoGetResult.Message;
                            return View();
                        }
                    }
                }
            }

            return View(empleadoGetResult.Data);
        }





        // GET: EmpleadoController/Create
        public ActionResult Create()
    {
        return View();
    }

    // POST: EmpleadoController/Create
    [HttpPost]
        [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(EmpleadosGuardar empleadoGuardar)
    {
        try
        {
                EmpleadoGuardarResult empleadoGuardarResult = new EmpleadoGuardarResult();

                using (var httpClient = new HttpClient(this.httpHandler))
                {
                    var url = $"http://localhost:5297/api/Empleado/GuardarEmpleado";


                    using (var response = await httpClient.PostAsJsonAsync<EmpleadosGuardar>(url, empleadoGuardar))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            empleadoGuardarResult = JsonConvert.DeserializeObject<EmpleadoGuardarResult>(apiResponse);

                            if (!empleadoGuardarResult.Success)
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
        public async Task<ActionResult> Edit(int id)
        {
            EmpleadoEditarGetResult empleadoEditarGetResult = new EmpleadoEditarGetResult();

            using (var httpClient = new HttpClient(this.httpHandler))
            {
                var url = $"http://localhost:5297/api/Empleado/GetEmpleadoById?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        empleadoEditarGetResult = JsonConvert.DeserializeObject<EmpleadoEditarGetResult>(apiResponse);

                        if (!empleadoEditarGetResult.Success)
                        {
                            ViewBag.Message = empleadoEditarGetResult.Message;
                            return View();
                        }
                    }
                }
            }

            return View(empleadoEditarGetResult.Data);
        }



        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
 
        public async Task<ActionResult> Edit(int id, EmpleadosEditar empleadoActualizar)
        {
            try
            {
                EmpleadoEditarGetResult empleadoGuardarResult = new EmpleadoEditarGetResult();

                using (var httpClient = new HttpClient(this.httpHandler))
                {
                    var url = $"http://localhost:5297/api/Empleado/ActualizarEmpleado";

                    using (var response = await httpClient.PutAsJsonAsync(url, empleadoActualizar))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            empleadoGuardarResult = JsonConvert.DeserializeObject<EmpleadoEditarGetResult>(apiResponse);

                            if (!empleadoGuardarResult.Success)
                            {
                                ViewBag.Message = empleadoGuardarResult.Message;
                                return View(empleadoActualizar);
                            }
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(empleadoActualizar);
            }
        }

    }
}
