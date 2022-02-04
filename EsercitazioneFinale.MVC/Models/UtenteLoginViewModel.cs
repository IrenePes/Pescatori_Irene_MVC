using System.ComponentModel.DataAnnotations;

namespace EsercitazioneFinale.MVC.Models
{
    public class UtenteLoginViewModel
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
