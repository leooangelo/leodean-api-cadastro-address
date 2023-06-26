using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Address.Domain.ViewModels
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "A rua não pode ser vazio.")]
        [MinLength(2, ErrorMessage = "A rua deve ter no mínimo 2 caracteres.")]
        [MaxLength(100, ErrorMessage = "A rua deve ter no máximo 100 caracteres.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "O numero não pode ser vazio.")]
        [MinLength(1, ErrorMessage = "O numero deve ter no mínimo 1 caracteres.")]
        [MaxLength(10, ErrorMessage = "O numero deve ter no máximo 10 caracteres.")]
        public string Number { get; set; }

        [Required(ErrorMessage = "O bairro não pode ser vazio.")]
        [MinLength(2, ErrorMessage = "O bairro deve ter no mínimo 2 caracteres.")]
        [MaxLength(100, ErrorMessage = "O bairro deve ter no máximo 100 caracteres.")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "A cidade não pode ser vazio.")]
        [MinLength(2, ErrorMessage = "A cidade deve ter no mínimo 2 caracteres.")]
        [MaxLength(100, ErrorMessage = "A cidade deve ter no máximo 100 caracteres.")]
        public string City { get; set; }

        [Required(ErrorMessage = "O estado não pode ser vazio.")]
        [MinLength(2, ErrorMessage = "O estado deve ter no mínimo 2 caracteres.")]
        [MaxLength(100, ErrorMessage = "O estado deve ter no máximo 100 caracteres.")]
        public string State { get; set; }

        [Required(ErrorMessage = "O CEP não pode ser vazio.")]
        [MinLength(5, ErrorMessage = "O CEP deve ter no mínimo 5 caracteres.")]
        [MaxLength(10, ErrorMessage = "O CEP deve ter no máximo 10 caracteres.")]
        public string ZipCode { get; set; }

        public string Complement { get; set; }

        public bool Favorite { get; set; }

        public string Name { get; set; }

        public string? CustomerID { get; set; }

        public string? EstablishmentID { get; set; }
    }
}
