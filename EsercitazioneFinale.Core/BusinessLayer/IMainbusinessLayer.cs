using EsercitazioneFinale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Core.BusinessLayer
{
    public interface IMainbusinessLayer
    {
        public List<Menu> GetAllMenu();
        public Esito AggiungiMenu(Menu menu);
        public Esito ModificaMenu(Menu menuUpdated);
        public Esito CancellaMenu(Menu menuToDelete);

        public List<Piatto> GetAllPiatti();
        public Esito AggiungiPiatto(Piatto piatto);
        public Esito ModificaPiatto(Piatto piattoUpdated);
        public Esito CancellaPiatto(Piatto piattoToDelete);

        public Utente GetUtenteByUsername(string username);
    }
}
