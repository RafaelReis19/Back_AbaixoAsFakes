using AbaixoAsFakesApi.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AbaixoAsFakesApi.Models
{
    public class Voto
    {
        public int Id { get; set; }

        public int IdNoticia { get; set; }

        [JsonIgnore]
        public Noticia Noticia { get; set; }

        public int IdUsuario { get; set; }

        //[JsonIgnore]
        public Usuario Usuario { get; set; }

        public TiposVotoEnum TipoVoto { get; set; }

        [NotMapped]
        [JsonIgnore]
        public int Formacao { get; set; }



    }
}
