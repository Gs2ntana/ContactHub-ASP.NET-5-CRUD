using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "O Nome não pode estar em branco")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O e-mail não pode estar em branco")]
        [EmailAddress(ErrorMessage = "Insira um e-mail válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O Celular não pode estar em branco")]
        [Phone (ErrorMessage = "O número não é valido")]
        public string Celular { get; set; }
    }
}
