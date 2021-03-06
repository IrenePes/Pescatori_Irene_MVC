using EsercitazioneFinale.Core.BusinessLayer;
using EsercitazioneFinale.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EsercitazioneFinale.MVC.Controllers
{
    public class UtentiController : Controller
    {
        private readonly IMainbusinessLayer BL;
        public UtentiController(IMainbusinessLayer bl)
        {
            BL = bl;
        }


        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new UtenteLoginViewModel { ReturnUrl = returnUrl });
        }


        [HttpPost]
        public async Task<IActionResult> LoginAsync(UtenteLoginViewModel utenteLoginViewModel)
        {
            if (utenteLoginViewModel == null)
            {
                return View();
            }

            var utente = BL.GetUtenteByUsername(utenteLoginViewModel.Username);
            if (utente != null && ModelState.IsValid)
            {
                if (utente.Password == utenteLoginViewModel.Password)
                {
                    //l'utente è autenticato"
                    var claim = new List<Claim>{

                        new Claim (ClaimTypes.Name, utente.Username),
                        new Claim (ClaimTypes.Role, utente.Ruolo.ToString())
                    };

                    var properties = new AuthenticationProperties
                    {
                        RedirectUri = utenteLoginViewModel.ReturnUrl,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1) //logout dopo un'ora di inattività
                    };

                    var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity),
                        properties
                        );
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(nameof(utenteLoginViewModel.Password), "Password errata");
                    return View(utenteLoginViewModel);
                }
            }
            else
            {
                return View(utenteLoginViewModel);
            }

            return View();
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
