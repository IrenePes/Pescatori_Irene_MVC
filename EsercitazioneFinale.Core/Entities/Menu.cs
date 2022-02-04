using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Core.Entities
{
    public class Menu
    {
        public int MenuID { get; set; }
        [Required]
        public string Nome { get; set; }


        public List<Piatto> Piatti { get; set; }

    }
}
