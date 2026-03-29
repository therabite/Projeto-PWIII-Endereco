using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AplicacaoBanco.Models
{

    public class Endereco
    {
        [Display(Name = "Código", Description = "Código")]
        public int Id { get; set; }

        [Display(Name = "CEP", Description = "CEP")]
        [MaxLength(10, ErrorMessage = "Número de caracteres incorreto para CEP")]
        public int CEP { get; set; }

        [Display(Name = "Estado", Description = "Estado")]
        [Required(ErrorMessage = "O Estado é obrigatório")]
        public string Estado { get; set; }

        [Display(Name = "Cidade", Description = "Cidade")]
        [Required(ErrorMessage = "O Cidade é obrigatório")]
        public string Cidade { get; set; }

        [Display(Name = "Bairro", Description = "Bairro")]
        [Required(ErrorMessage = "O Bairro é obrigatório")]
        public string Bairro { get; set; }

        [Display(Name = "Endereço", Description = "Endereco")]
        [Required(ErrorMessage = "O Endereco é obrigatório")]
        public string Endereco { get; set; }

        [Display(Name = "Complemento", Description = "Complemento")]
        [Required(ErrorMessage = "O Complemento é obrigatório")]
        public string Complemento { get; set; }

        [Display(Name = "Numero", Description = "Numero")]
        [Required(ErrorMessage = "O Numero é obrigatório")]
        public int Numero { get; set; }
    }
}