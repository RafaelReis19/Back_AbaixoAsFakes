using AbaixoAsFakesApi.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbaixoAsFakesApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public byte[] SenhaSalt { get; set; }
        public byte[] SenhaHash { get; set; }
        public FormacaoAcademicaEnum idFormacaoAcademica { get; set; }
        public string email { get; set; }
        [NotMapped]
        public string senhaString { get; set; }
        public string Role { get; set; }
    }
}
