using System.ComponentModel.DataAnnotations;

namespace EsercitazioneFinale.MVC.Models
{
    public class MenuViewModel
    {
        [Display(Name = "Codice del Menu")]
        public int MenuID { get; set; }


        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Nome { get; set; }


        public List<PiattiViewModel> Piatti { get; set; }
    }
}
