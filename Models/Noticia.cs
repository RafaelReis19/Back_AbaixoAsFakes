using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbaixoAsFakesApi.Models
{
    public class Noticia
    {
        //[Key]
        public int IdNoticia { get; set; }

        public string Link { get; set; }
        public string Fonte { get; set; }

        /* [JsonIgnore]
        public Usuario? idUsuario1 { get; set; } */

        //public string comentario { get; set; }

    }
}
