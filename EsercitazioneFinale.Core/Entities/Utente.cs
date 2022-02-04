using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Core.Entities
{
    public class Utente
    {
        public int UtenteID { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public Ruolo Ruolo { get; set; }
    }

    public enum Ruolo
    {
        Administrator = 0,
        User = 1
    }
}

