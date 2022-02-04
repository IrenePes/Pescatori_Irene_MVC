using EsercitazioneFinale.Core.Entities;
using EsercitazioneFinale.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.RepositoryEF.RepositoriesEF
{
    public class UtentiRepositoryEF : IUtentiRepository
    {

        private readonly Context _ctx;
        public UtentiRepositoryEF(Context ctx)
        {
            _ctx = ctx;
        }
        public Utente? GetUtenteByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;
            return _ctx.Utenti.FirstOrDefault(u => u.Username == username);
        }
    }
}
