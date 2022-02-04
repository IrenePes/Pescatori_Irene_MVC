using EsercitazioneFinale.Core.BusinessLayer;
using EsercitazioneFinale.Core.Entities;
using EsercitazioneFinale.MVC.Helper;
using EsercitazioneFinale.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EsercitazioneFinale.MVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMainbusinessLayer BL;

        public MenuController(IMainbusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Menu> menu = BL.GetAllMenu();

            List<MenuViewModel> menuVM = new List<MenuViewModel>();

            foreach (var item in menu)
                menuVM.Add(item.ToMenuViewModel());

            return View(menuVM);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Menu? menu = BL.GetAllMenu().FirstOrDefault(m => m.MenuID == id);
            MenuViewModel menuVM = menu.ToMenuViewModel();
            return View(menuVM);
        }

        [Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult Decouple(int id)
        {
            var piatto = BL.GetAllPiatti().FirstOrDefault(p => p.PiattoID == id);
            var piattoVM = piatto.ToPiattiViewModel();
            return View(piattoVM);
        }
        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Decouple(PiattiViewModel piattoVM)
        {
            if (ModelState.IsValid)
            {
                var piatto = piattoVM.ToPiatto();
                Piatto newPiatto = new Piatto()
                {
                    PiattoID = piatto.PiattoID,
                    Nome = piatto.Nome,
                    Descrizione = piatto.Descrizione,
                    Tipologia = piatto.Tipologia,
                    Prezzo = piatto.Prezzo,
                    MenuID = null
                };

                var esito = BL.ModificaPiatto(newPiatto);

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
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Create(MenuViewModel menuVM)
        {
            if (ModelState.IsValid)
            {
                var menu = menuVM.ToMenu();
                var esito = BL.AggiungiMenu(menu);

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
                return View(menuVM);
            }
        }

    }
}
