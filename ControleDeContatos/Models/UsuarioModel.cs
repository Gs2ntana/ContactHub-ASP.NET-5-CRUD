using ControleDeContatos.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome não pode estar em branco")]
        public string Nome { get; set; }

        public PerfilEnum Perfil { get; set; }

        [Required(ErrorMessage = "O e-mail não pode estar em branco")]
        [EmailAddress(ErrorMessage = "Insira um e-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Login não pode estar em branco")]
        public string Login { get; set; }
        [Required(ErrorMessage = "A senha não pode estar em branco")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

    }
}
