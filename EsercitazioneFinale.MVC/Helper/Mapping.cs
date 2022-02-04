using EsercitazioneFinale.Core.Entities;
using EsercitazioneFinale.MVC.Models;

namespace EsercitazioneFinale.MVC.Helper
{
    public static class Mapping
    {
        public static MenuViewModel ToMenuViewModel(this Menu menu)
        {
            List<PiattiViewModel> piattiViewModel = new List<PiattiViewModel>();

            foreach (var item in menu.Piatti)
            {
                piattiViewModel.Add(ToPiattiViewModel(item));
            }

            return new MenuViewModel
            {
                MenuID = menu.MenuID,
                Nome = menu.Nome,
                Piatti = piattiViewModel
            };
        }

        public static Menu ToMenu(this MenuViewModel menuViewModel)
        {
            List<Piatto> piatti = new List<Piatto>();
            foreach(var item in menuViewModel.Piatti)
            {
                piatti.Add(ToPiatto(item));
            }

            return new Menu
            {
                MenuID = menuViewModel.MenuID,
                Nome = menuViewModel.Nome,
                Piatti = piatti
            };
        }

        public static PiattiViewModel ToPiattiViewModel(this Piatto piatto)
        {
            return new PiattiViewModel
            {
                PiattoID = piatto.PiattoID,
                Nome = piatto.Nome,
                Descrizione = piatto.Descrizione,
                Tipologia = piatto.Tipologia,
                Prezzo = piatto.Prezzo,
                MenuID = piatto.MenuID
            };
        }

        public static Piatto ToPiatto(this PiattiViewModel piattoViewModel)
        {
            return new Piatto
            {
                PiattoID = piattoViewModel.PiattoID,
                Nome = piattoViewModel.Nome,
                Descrizione = piattoViewModel.Descrizione,
                Tipologia = piattoViewModel.Tipologia,
                Prezzo = piattoViewModel.Prezzo,
                MenuID = piattoViewModel.MenuID
            };
        }


    }
}
