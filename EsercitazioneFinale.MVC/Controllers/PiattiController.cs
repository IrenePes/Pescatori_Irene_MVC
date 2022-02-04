using EsercitazioneFinale.Core.BusinessLayer;
using EsercitazioneFinale.Core.Entities;
using EsercitazioneFinale.MVC.Helper;
using EsercitazioneFinale.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EsercitazioneFinale.MVC.Controllers
{
    public class PiattiController : Controller
    {
        private readonly IMainbusinessLayer BL;
        public PiattiController(IMainbusinessLayer bl)
        {
            BL = bl;
        }

        public IActionResult Index()
        {
            List<Piatto> piatti = BL.GetAllPiatti();
            List<PiattiViewModel> piattiVM = new List<PiattiViewModel>();
            foreach (Piatto piatto in piatti)
                piattiVM.Add(piatto.ToPiattiViewModel());

            return View(piattiVM);
        }
        [Authorize(Policy = "Adm")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Create(PiattiViewModel piattiVM)
        {
            if (ModelState.IsValid)
            {
                var piatto = piattiVM.ToPiatto();
                var esito = BL.AggiungiPiatto(piatto);

                if (esito.IsOk == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = esito.Messaggio;
                    return View("ErroriDiBusiness");
                }
            }
            else
            {
                return View(piattiVM);
            }
        }
        [Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var piatto = BL.GetAllPiatti().FirstOrDefault(p => p.PiattoID == id);
            var piattoVM = piatto.ToPiattiViewModel();

            return View(piattoVM);
        }

        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Edit(PiattiViewModel piattoVM)
        {
            if (ModelState.IsValid)
            {
                var piatto = piattoVM.ToPiatto();
                var esito = BL.ModificaPiatto(piatto);

                if (esito.IsOk == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = esito.Messaggio;
                    return View("ErroriDiBusiness");
                }
            }
            return View(piattoVM);
        }

        [Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var piatto = BL.GetAllPiatti().FirstOrDefault(p => p.PiattoID == id);
            var piattoVM = piatto.ToPiattiViewModel();
            return View(piattoVM);
        }

        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Delete(PiattiViewModel piattoVM)
        {
            var piatto = piattoVM.ToPiatto();
            var esito = BL.CancellaPiatto(piatto);

            if (esito.IsOk == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.MessaggioErrore = esito.Messaggio;
                return View("ErroriDiBusiness");
            }
        }



    }
}
