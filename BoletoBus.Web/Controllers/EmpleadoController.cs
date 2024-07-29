using BoletoBus.Empleado.Application.Dtos;
using BoletoBus.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace BoletoBus.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: EmpleadoController
        HttpClientHandler httpHandler = new HttpClientHandler();
        private readonly IEmpleadoService empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            this.empleadoService = empleadoService;
            this.httpHandler = new HttpClientHandler();
            this.httpHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };

        }
        public async Task<ActionResult> Index()
        {
            var empleadoGetList = await empleadoService.GetEmpleados();
            if (!empleadoGetList.Success)
            {
                ViewBag.Message = empleadoGetList.Message;
                return View();
            }

            //EmpleadoGetListResult empleadoGetList = new EmpleadoGetListResult();

            //using (var httpClient = new HttpClient(this.httpHandler))
            //{
            //    var url = "http://localhost:5297/api/Empleado/GetEmpleado";

            //    using (var response = await httpClient.GetAsync(url))
            //    {
            //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            string apiResponse = await response.Content.ReadAsStringAsync();

            //            empleadoGetList = JsonConvert.DeserializeObject<EmpleadoGetListResult>(apiResponse);

            //            if (!empleadoGetList.Success)
            //            {
            //                ViewBag.Massage = empleadoGetList;
            //                return View();
            //            }
            //        }
            //    }
            //}
            return View(empleadoGetList.Data);
        }



        // GET: EmpleadoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var empleadoGetById = await empleadoService.GetEmpleadoById(id);
            if (!empleadoGetById.Success)
            {
                ViewBag.Message = empleadoGetById.Message;
                return View();
            }


            //EmpleadoGetResult empleadoGetResult = new EmpleadoGetResult();

            //using (var httpClient = new HttpClient(this.httpHandler))
            //{
            //    var url = $"http://localhost:5297/api/Empleado/GetEmpleadoById?id={id}";

            //    using (var response = await httpClient.GetAsync(url))
            //    {
            //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            string apiResponse = await response.Content.ReadAsStringAsync();
            //            empleadoGetResult = JsonConvert.DeserializeObject<EmpleadoGetResult>(apiResponse);

            //            if (!empleadoGetResult.Success)
            //            {
            //                ViewBag.Message = empleadoGetResult.Message;
            //                return View();
            //            }
            //        }
            //    }
            //}

            return View(empleadoGetById.Data);
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
                var empleado = await empleadoService.GuardarEmpleado(empleadoGuardar);
                if (!empleado.Success)
                {
                ViewBag.Message = empleado.Message;
                return View();
                }



                //EmpleadoGuardarResult empleadoGuardarResult = new EmpleadoGuardarResult();

                //using (var httpClient = new HttpClient(this.httpHandler))
                //{
                //    var url = $"http://localhost:5297/api/Empleado/GuardarEmpleado";


                //    using (var response = await httpClient.PostAsJsonAsync<EmpleadosGuardar>(url, empleadoGuardar))
                //    {
                //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //        {
                //            string apiResponse = await response.Content.ReadAsStringAsync();

                //            empleadoGuardarResult = JsonConvert.DeserializeObject<EmpleadoGuardarResult>(apiResponse);

                //            if (!empleadoGuardarResult.Success)
                //            {
                //                ViewBag.Massage = empleadoGuardarResult;
                //                return View();
                //            }
                //        }
                //    }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

    

        // GET: EmpleadoController/Edit/5
        public async Task<ActionResult> Edit(int id)
    {
        var empleadoGetById = await empleadoService.GetEmpleadoById(id);
        if (!empleadoGetById.Success)
        {
            ViewBag.Message = empleadoGetById.Message;
            return View();
        }


        //EmpleadoEditarGetResult empleadoEditarGetResult = new EmpleadoEditarGetResult();

        //using (var httpClient = new HttpClient(this.httpHandler))
        //{
        //    var url = $"http://localhost:5297/api/Empleado/GetEmpleadoById?id={id}";

        //    using (var response = await httpClient.GetAsync(url))
        //    {
        //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            empleadoEditarGetResult = JsonConvert.DeserializeObject<EmpleadoEditarGetResult>(apiResponse);

        //            if (!empleadoEditarGetResult.Success)
        //            {
        //                ViewBag.Message = empleadoEditarGetResult.Message;
        //                return View();
        //            }
        //        }
        //    }
        //}

        return View(empleadoGetById.Data);
        }



        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
 
        public async Task<ActionResult> Edit(EmpleadosEditar empleadoActualizar)
        {
            var result = await empleadoService.ActualizarEmpleado(empleadoActualizar);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View(empleadoActualizar);
            }


            //try
            //{
            //    EmpleadoEditarGetResult empleadoGuardarResult = new EmpleadoEditarGetResult();

            //    using (var httpClient = new HttpClient(this.httpHandler))
            //    {
            //        var url = $"http://localhost:5297/api/Empleado/ActualizarEmpleado";

            //        using (var response = await httpClient.PutAsJsonAsync(url, empleadoActualizar))
            //        {
            //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //            {
            //                string apiResponse = await response.Content.ReadAsStringAsync();
            //                empleadoGuardarResult = JsonConvert.DeserializeObject<EmpleadoEditarGetResult>(apiResponse);

            //                if (!empleadoGuardarResult.Success)
            //                {
            //                    ViewBag.Message = empleadoGuardarResult.Message;
            //                    return View(empleadoActualizar);
            //                }
            //            }
            //        }
            //    }

            return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View(empleadoActualizar);
            //}
        }

    }
}
