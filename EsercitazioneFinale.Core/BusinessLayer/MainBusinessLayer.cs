using EsercitazioneFinale.Core.Entities;
using EsercitazioneFinale.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Core.BusinessLayer
{
    public class MainBusinessLayer : IMainbusinessLayer
    {
        private readonly IMenuRepository _menuRepo;
        private readonly IPiattiRepository _piattiRepo;
        private readonly IUtentiRepository _utentiRepo;

        public MainBusinessLayer(IMenuRepository menuRepo, IPiattiRepository piattiRepo, IUtentiRepository utentiRepo)
        {
            _menuRepo = menuRepo;
            _piattiRepo = piattiRepo;
            _utentiRepo = utentiRepo;
        }

        #region MENU
        public Esito AggiungiMenu(Menu menu)
        {
            if(menu == null)
                return new Esito() { IsOk = false, Messaggio = "Entità passata non valida" };

            Menu menuEsistente = GetAllMenu().FirstOrDefault(m => m.MenuID == menu.MenuID);

            if (menuEsistente != null)
                return new Esito() { IsOk = false, Messaggio = $"Impossibile aggiungere il menu inserito poichè esiste già un menu con ID = {menu.MenuID}" };

            _menuRepo.AggiungiMenu(menu);
            return new Esito() { IsOk = true, Messaggio = "Menu aggiunto correttamente" };
        }

        public Esito CancellaMenu(Menu menuToDelete)
        {
            if (menuToDelete == null)
                return new Esito() { IsOk = false, Messaggio = "Entità passata non valida" };

            Menu menuEsistente = GetAllMenu().FirstOrDefault(m => m.MenuID == menuToDelete.MenuID);

            if(menuEsistente == null)
                return new Esito() { IsOk = false, Messaggio = $"Impossibile cancellare il menu scelto poichè non esiste un menu con ID = {menuToDelete.MenuID}" };

            _menuRepo.CancellaMenu(menuToDelete);
            return new Esito() { IsOk = true, Messaggio = "Menu cancellato correttamente" };
        }

        public List<Menu> GetAllMenu()
        {
            return _menuRepo.GetAllMenu();
        }

        public Esito ModificaMenu(Menu menuUpdated)
        {
            if (menuUpdated == null)
                return new Esito() { IsOk = false, Messaggio = "Entità passata non valida" };

            Menu menuToUpdate = GetAllMenu().FirstOrDefault(m => m.MenuID == menuUpdated.MenuID);

            if (menuToUpdate == null)
                return new Esito() { IsOk = false, Messaggio = $"Impossibile modificare il menu scelto poichè non esiste un menu con ID = {menuUpdated.MenuID}" };

            menuToUpdate.Nome = menuUpdated.Nome;

            _menuRepo.ModificaMenu(menuToUpdate);
            return new Esito() { IsOk = true, Messaggio = "Menu modificato correttamente" };

        }
        #endregion


        #region PIATTI
        public Esito AggiungiPiatto(Piatto piatto)
        {
            if (piatto == null)
                return new Esito() { IsOk = false, Messaggio = "Entità passata non valida" };

            Piatto piattoEsistente = GetAllPiatti().FirstOrDefault(p => p.PiattoID == piatto.PiattoID);

            if (piattoEsistente != null)
                return new Esito() { IsOk = false, Messaggio = $"Impossibile aggiungere il piatto inserito poichè esiste già un piatto con ID = {piatto.PiattoID}" };

            _piattiRepo.AggiungiPiatto(piatto);
            return new Esito() { IsOk = true, Messaggio = "Piatto aggiunto correttamente" };
        }

        public Esito CancellaPiatto(Piatto piattoToDelete)
        {
            if (piattoToDelete == null)
                return new Esito() { IsOk = false, Messaggio = "Entità passata non valida" };

            Piatto piattoEsistente = GetAllPiatti().FirstOrDefault(p => p.PiattoID == piattoToDelete.PiattoID);

            if (piattoEsistente == null)
                return new Esito() { IsOk = false, Messaggio = $"Impossibile cancellare il piatto scelto poichè non esiste un piatto con ID = {piattoToDelete.PiattoID}" };

            _piattiRepo.CancellaPiatto(piattoToDelete);
            return new Esito() { IsOk = true, Messaggio = "Piatto cancellato correttamente" };
        }

        public List<Piatto> GetAllPiatti()
        {
            return _piattiRepo.GetAllPiatti();
        }

        public Esito ModificaPiatto(Piatto piattoUpdated)
        {
            if (piattoUpdated == null)
                return new Esito() { IsOk = false, Messaggio = "Entità passata non valida" };

            Piatto piattoToUpdate = GetAllPiatti().FirstOrDefault(p => p.PiattoID == piattoUpdated.PiattoID);

            if (piattoToUpdate == null)
                return new Esito() { IsOk = false, Messaggio = $"Impossibile modificare il piatto scelto poichè non esiste un piatto con ID = {piattoUpdated.PiattoID}" };

            piattoToUpdate.Nome = piattoUpdated.Nome;
            piattoToUpdate.Descrizione = piattoUpdated.Descrizione;
            piattoToUpdate.Tipologia = piattoUpdated.Tipologia;
            piattoToUpdate.Prezzo = piattoUpdated.Prezzo;
            piattoToUpdate.Menu = piattoUpdated.Menu;

            _piattiRepo.ModificaPiatto(piattoToUpdate);
            return new Esito() { IsOk = true, Messaggio = "Piatto modificato correttamente" };
        }
        #endregion


        #region UTENTI
        public Utente GetUtenteByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            return _utentiRepo.GetUtenteByUsername(username);
        }
        #endregion

    }
}
