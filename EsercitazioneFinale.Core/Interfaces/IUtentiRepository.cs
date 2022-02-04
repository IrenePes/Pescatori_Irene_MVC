using EsercitazioneFinale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Core.Interfaces
{
    public interface IUtentiRepository
    {
        public Utente GetUtenteByUsername(string username);
    }
}
