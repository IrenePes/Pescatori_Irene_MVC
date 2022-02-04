using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Core.Entities
{
    public class Piatto
    {
        public int PiattoID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descrizione { get; set; }
        [Required]
        public tipologia Tipologia { get; set; }
        [Required, Range(0, 999.99)]
        public decimal Prezzo { get; set; }

        //FK
        public int? MenuID { get; set; }
        public Menu? Menu { get; set; }
    }

    public enum tipologia
    {
        Antipasto,
        Primo,
        Secondo,
        Contorno,
        Dolce
    }
}
