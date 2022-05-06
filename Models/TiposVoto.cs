using AbaixoAsFakesApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbaixoAsFakesApi.Models
{
    public class TiposVoto
    {
        public int idTipoVoto { get; set; }

        public TiposVotoEnum dsTipoVoto { get; set; }
    }
}
