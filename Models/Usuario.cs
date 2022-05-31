using AbaixoAsFakesApi.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public string DsForamacao 
        { 
            get
            {
                string retorno = string.Empty;

                if(FormacaoAcademica == FormacaoAcademicaEnum.DOUTORADO)
                {
                    retorno = "Doutorado";
                }

                else if (FormacaoAcademica == FormacaoAcademicaEnum.MESTRADO)
                {
                    retorno = "Mestrado";
                }

                else if (FormacaoAcademica == FormacaoAcademicaEnum.POSGRADUACAO)
                {
                    retorno = "Pós graduação";
                }

                else if (FormacaoAcademica == FormacaoAcademicaEnum.GRADUACAO)
                {
                    retorno = "Graduação";
                }

                else if (FormacaoAcademica == FormacaoAcademicaEnum.MEDIO)
                {
                    retorno = "Ensino médio";
                }

                else if (FormacaoAcademica == FormacaoAcademicaEnum.FUNDAMENTAL2)
                {
                    retorno = "Fundamental 2";
                }

                else
                {
                    retorno = "Fundamental 1";
                }


                return retorno;
            }
        }
    }
}
