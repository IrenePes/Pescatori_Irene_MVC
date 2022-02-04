using EsercitazioneFinale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Core.Interfaces
{
    public interface IMenuRepository
    {
        public List<Menu> GetAllMenu();
        public Menu AggiungiMenu(Menu menu);
        public Menu ModificaMenu(Menu menuUpdated);
        public bool CancellaMenu(Menu menuToDelete);
    }
}
