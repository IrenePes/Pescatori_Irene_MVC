using EsercitazioneFinale.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace EsercitazioneFinale.MVC.Models
{
    public class PiattiViewModel
    {
        [Display(Name = "Codice del piatto")]
        public int PiattoID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descrizione { get; set; }
        [Required]
        public tipologia Tipologia { get; set; }
        [Required, Range(0, 999.99)]
        public decimal Prezzo { get; set; }

        public int? MenuID { get; set; }
        public MenuViewModel? Menu { get; set; }
    }
}
