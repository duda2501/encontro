using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncontroCampistas.Biblioteca.Entidades
{
    [Table("Eventos", Schema = "public")]
    public class Evento
    {
        [Key]
        public int EventoId { get; set; }

        public string Descricao { get; set; }

        public DateTime DataHoraRealizacao { get; set; }

        public string Local { get; set; }

        public int Duracao { get; set; }

        public int TipoEvento { get; set; }
    }
}
