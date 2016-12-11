using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace EncontroCampistas.Biblioteca.Entidades
{
    [Table("Eventos", Schema = "public")]
    public class Evento
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int EventoId { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Digite a descrição")]
        [StringLength(150)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a data e hora do evento")]
        public DateTime DataHoraRealizacao { get; set; }

        [Required(ErrorMessage = "Informe o local do evento")]
        public string Local { get; set; }

        public int Duracao { get; set; }

        [Column("TipoEvento")]
        [Required(ErrorMessage = "Informe o tipo do evento")]
        public int iTipoEvento { get; set; }

        //[ForeignKey("iTipoEvento")]
        //public virtual TipoEvento TipoEvento { get; set; }
    }
}
