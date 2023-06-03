using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SOS_Buscas_V2.Repositorio;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOS_Buscas_V2.Models
{
    public class DesaparecidoModel
    {
        //------------------------------------------------------------------
        //Modelo para a tabela de Desaparecidos

        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(35)")]
        public string Nome { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Sobrenome { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Roupa { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Estilocabelo { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string CorPele { get; set; }

        [Column(TypeName = "varchar(5)")]
        public double? Altura { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Tatoagem { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string? Observacoes { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? CaminhoImagem { get; set; }


        [Column(TypeName = "DateTime")]
        public DateTime DataHoraDesaparecimento { get; set; }

        [ForeignKey("Email")]
        [Column(TypeName = "varchar(45)")]
        public string EmailUsuario { get; set; }

        public UsuarioModel Email { get; set; } 
    }
}
