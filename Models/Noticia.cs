using System.Text.Json.Serialization;

namespace AbaixoAsFakesApi.Models
{
    public class Noticia
    {
        public int Id { get; set; }

        public string Link { get; set; }

        public string Fonte { get; set; }

        public int IdUsuario{ get; set; }
        
        [JsonIgnore]
        public Usuario Usuario { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }
    }
}
