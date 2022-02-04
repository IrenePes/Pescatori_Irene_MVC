using EsercitazioneFinale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Core.Interfaces
{
    public interface IPiattiRepository
    {
        public List<Piatto> GetAllPiatti();
        public Piatto AggiungiPiatto(Piatto piatto);
        public bool CancellaPiatto(Piatto piattoToDelete);
        public Piatto ModificaPiatto(Piatto piattoUpdated);
    }
}
