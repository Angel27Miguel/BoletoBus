using BoletoBus.Viaje.Application.Dtos;
using BoletoBus.Web.Service.Viaje;
using Microsoft.AspNetCore.Mvc;

namespace BoletoBus.Web.Controllers
{
    public class ViajeController : Controller
    {
        private readonly IViajeServices viajeService;

        public ViajeController(IViajeServices viajeService)
        {
            this.viajeService = viajeService;
        }

        // GET: ViajeController
        public async Task<ActionResult> Index()
        {
            var viajeGetList = await viajeService.GetViajes();

            if (!viajeGetList.Success)
            {
                ViewBag.Message = viajeGetList.Message;
                return View();
            }

            return View(viajeGetList.Data);
        }

        // GET: ViajeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var viajeGetById = await viajeService.GetViajeaById(id);
            if (!viajeGetById.Success)
            {
                ViewBag.Message = viajeGetById.Message;
                return View();
            }

            return View(viajeGetById.Data);
        }

        // GET: ViajeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViajeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ViajeGuardar viajeGuardar)
        {
            try
            {
                var viaje = await viajeService.GuardarViaje(viajeGuardar);
                if (!viaje.Success)
                {
                    ViewBag.Message = viaje.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ViajeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var viajeGetById = await viajeService.GetViajeaById(id);
            if (!viajeGetById.Success)
            {
                ViewBag.Message = viajeGetById.Message;
                return View();
            }

            return View(viajeGetById.Data);
        }

        // POST: ViajeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ViajeEditar viajeEditar)
        {
            var result = await viajeService.ActualizarViaje(viajeEditar);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View(viajeEditar);
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
