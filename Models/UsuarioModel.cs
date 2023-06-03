
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOS_Buscas_V2.Models
{
    
    public class UsuarioModel
    {
        //------------------------------------------------------------------
        //Modelo para a tabela 

        public Guid Id { get; set; }
        

        [Column(TypeName = "varchar(11)")]
        [Required]
        public string CPF { get; set; }
        

        [Column(TypeName = "varchar(35)")]
        public string Nome { get; set; }
        

        [Column(TypeName = "varchar(45)")]
        public string Sobrenome { get; set; }

        [Key]
        [Column(TypeName = "varchar(45)")]
        public string Email { get; set; }
        

        [Column(TypeName = "varchar(45)")]
        public string Senha { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime Nascimento { get; set; }

        //------------------------------------------------------------------
        //Função para verificar a senha
        public bool VerificarSenha(string senha)
        {
            return Senha == senha;
        }





    }
}
