using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Jogo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public bool Parente { get; set; }

        [DisplayName("Foto")]
        public string ImageUri { get; set; }
    }
}
