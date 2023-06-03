using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace SOS_Buscas_V2.Models
{
    //------------------------------------------------------------------
    //Modelo para a tabela de Avistamentos

    public class AvistamentoModel
    {
        [Column(TypeName = "DateTime")]
        public DateTime DiaHoraAvistamento { get; set; }


        [Column(TypeName = "varchar(20)")]
        public string? Rua { get; set; }


        [Column(TypeName = "varchar(20)")]
        public string? Bairro { get; set; }


        [Column(TypeName = "varchar(15)")]
        public string Municipio { get; set; }


        [Column(TypeName = "varchar(2)")]
        public string UF { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string PontoReferencia { get; set;}


        [ForeignKey("Id")]
        [Column(TypeName = "varchar(100)")]
        public string DesaparecidoId { get; set; }

        public DesaparecidoModel Id { get; set; }
    }
}
