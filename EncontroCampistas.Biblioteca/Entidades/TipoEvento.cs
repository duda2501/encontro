using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncontroCampistas.Biblioteca.Entidades
{
    [Table("TipoEvento", Schema = "public")]
    public class TipoEvento
    {
        [Key]
        public int TipoEventoId { get; set; }

        public string DescricaoTipoEvento { get; set; }

        public bool PermiteInscricao { get; set; }
    }
}
