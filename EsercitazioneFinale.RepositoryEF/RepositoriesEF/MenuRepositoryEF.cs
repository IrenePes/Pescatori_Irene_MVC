using EsercitazioneFinale.Core.Entities;
using EsercitazioneFinale.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.RepositoryEF.RepositoriesEF
{
    public class MenuRepositoryEF : IMenuRepository
    {

        private readonly Context _ctx;
        public MenuRepositoryEF(Context ctx)
        {
            _ctx = ctx;
        }

        public Menu AggiungiMenu(Menu menu)
        {
            _ctx.Menu.Add(menu);
            _ctx.SaveChanges();
            return menu;
        }

        public bool CancellaMenu(Menu menuToDelete)
        {
            _ctx.Menu.Remove(menuToDelete);
            _ctx.SaveChanges();
            return true;
        }

        public List<Menu> GetAllMenu()
        {
            return _ctx.Menu.Include(m => m.Piatti).ToList();
        }

        public Menu ModificaMenu(Menu menuUpdated)
        {
            _ctx.Menu.Update(menuUpdated);
            _ctx.SaveChanges();
            return menuUpdated;
        }
    }
}
