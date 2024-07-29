using BoletoBus.Reserva.Application.Dtos;
using BoletoBus.Web.Service.Reserva;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BoletoBus.Web.Controllers
{
    public class ReservaController : Controller
    {
        private readonly IReservaService reservaService;

        public ReservaController(IReservaService reservaService)
        {
            this.reservaService = reservaService;
        }

        // GET: ReservaController
        public async Task<ActionResult> Index()
        {
            var reservaGetList = await reservaService.GetReservas();
            if (!reservaGetList.Success)
            {
                ViewBag.Message = reservaGetList.Message;
                return View();
            }

            return View(reservaGetList.Data);
        }

        // GET: ReservaController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var reservaGetById = await reservaService.GetReservaById(id);
            if (!reservaGetById.Success)
            {
                ViewBag.Message = reservaGetById.Message;
                return View();
            }

            return View(reservaGetById.Data);
        }

        // GET: ReservaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReservaGuardar reservaGuardar)
        {
            try
            {
                var reserva = await reservaService.GuardarReserva(reservaGuardar);
                if (!reserva.Success)
                {
                    ViewBag.Message = reserva.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservaController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var reservaGetById = await reservaService.GetReservaById(id);
            if (!reservaGetById.Success)
            {
                ViewBag.Message = reservaGetById.Message;
                return View();
            }

            return View(reservaGetById.Data);
        }

        // POST: ReservaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ReservaEditar reservaActualizar)
        {
            var result = await reservaService.ActualizarReserva(reservaActualizar);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View(reservaActualizar);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ReservaController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var reservaGetById = await reservaService.GetReservaById(id);
            if (!reservaGetById.Success)
            {
                ViewBag.Message = reservaGetById.Message;
                return View();
            }

            return View(reservaGetById.Data);
        }

        // POST: ReservaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                // Implement the delete functionality if necessary
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
