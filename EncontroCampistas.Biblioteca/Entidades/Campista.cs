using System;
using System.ComponentModel.DataAnnotations;

namespace EncontroCampistas.Biblioteca.Entidades
{
    public class Campista
    {
        #region propriedades  
        [Key]
        public int CampistaID { get; set; }
        
        public string Nome { get; set; }

        public string Cep { get; set; }

        public string Endereco { get; set; }

        public string Numero { get; set; }
        
        public string Bairro { get; set; }
        
        public string Cidade { get; set; }
        
        public DateTime DataNascimento { get; set; }
        
        public string Telefone { get; set; }
        
        public string Celular { get; set; }
        
        public bool PrimeiraComunhao { get; set; }
        
        public bool Batizado { get; set; }
        
        public bool Casado { get; set; }
        
        public bool Crismado { get; set; }
        
        public Byte[] Foto { get; set; }
        
        public int Acampamento { get; set; }
        
        public decimal Altura { get; set; }
        
        public string Complemento { get; set; }
        
        public string Email { get; set; }
        
        public string FormaPagamento { get; set; }
        
        public string Medicamentos { get; set; }
        
        public string Movimento { get; set; }
        
        public string NomeMae { get; set; }
        
        public string FoneMae { get; set; }
        
        public string NomePai { get; set; }
        
        public string FonePai { get; set; }
        
        public bool Pago { get; set; }
        
        public string Paroquia { get; set; }
        
        public decimal Peso { get; set; }
        
        public string Pratos { get; set; }
        
        public string Responsavel { get; set; }
        
        public string FoneResponsavel { get; set; }
        
        public string RG { get; set; }
        
        public string TamanhoCamiseta { get; set; }
        
        public string TipoCamiseta { get; set; }
        
        public int Tribo { get; set; }
        
        public double ValorPago { get; set; }
        #endregion

        #region Construtores
        public Campista() { }
        /// <summary>
        /// Instancia um campista através do seu código
        /// </summary>
        public Campista(int codigoCliente)
        {
        }
        #endregion
    }
}
