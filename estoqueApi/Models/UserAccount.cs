using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace estoqueApi.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage ="Nome obrigatório")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Sobrenome obrigatório")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email brigatório")]
        [RegularExpression(@"^([\w-\.]+)@(([[0-9]{1,3}.\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Digite um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Login obrigatorio")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Senha Obrigatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirme a senha")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}