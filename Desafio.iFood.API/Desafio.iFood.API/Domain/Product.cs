using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.iFood.API.Domain
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do produto é obrigatório")]
        [MaxLength(60, ErrorMessage = "Nome deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Nome deve conter entre 3 e 60 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Preço é obrigatório")]
        [Range(0.01, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "A imagem é obrigatória")]
        public string Image { get; set; }

    }
}
