using AbaixoAsFakesApi.Models.Enums;
using System;

namespace AbaixoAsFakesApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public FormacaoAcademicaEnum FormacaoAcademica { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
