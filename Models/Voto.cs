using AbaixoAsFakesApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbaixoAsFakesApi.Models
{
    public class Voto
    {
        //[Key]
        public int idVoto { get; set; }
        public int idade { get; set; }
        public int idNoticias { get; set; }
        public TiposVotoEnum idTipoVoto { get; set; }
        public FormacaoAcademicaEnum idFormacaoAcademica { get; set; }
    }
}
