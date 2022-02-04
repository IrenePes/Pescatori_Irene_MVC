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
    public class PiattiRepositoryEF : IPiattiRepository
    {

        private readonly Context _ctx;
        public PiattiRepositoryEF(Context ctx)
        {
            _ctx = ctx;
        }

        public Piatto AggiungiPiatto(Piatto piatto)
        {
            _ctx.Piatti.Add(piatto);
            _ctx.SaveChanges();
            return piatto;
        }

        public bool CancellaPiatto(Piatto piattoToDelete)
        {
            _ctx.Piatti.Remove(piattoToDelete);
            _ctx.SaveChanges();
            return true;
        }

        public List<Piatto> GetAllPiatti()
        {
            return _ctx.Piatti.ToList();
        }

        public Piatto ModificaPiatto(Piatto piattoUpdated)
        {
            _ctx.Piatti.Update(piattoUpdated);
            _ctx.SaveChanges();
            return piattoUpdated;
        }
    }
}
