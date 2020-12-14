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

        [DisplayName("Ultima Visualização")] 
        public DateTime DataNascimento { get; set; } //trocar nome da entidade e depois subir as mudanças para as dependencias do Az e a App Service//

        [DisplayName("Online?")]
        public bool Online { get; set; }

        [DisplayName("Foto")]
        public string ImageUri { get; set; }
        
    }
}
