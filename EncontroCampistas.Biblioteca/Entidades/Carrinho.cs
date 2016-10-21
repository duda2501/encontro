using System.Collections.Generic;
using System.Linq;

namespace EncontroCampistas.Biblioteca.Entidades
{
    public class Carrinho
    {
        private readonly List<Evento> _lstEventos = new List<Evento>();
        // Adicionar
        public void AdicionarEvento(Evento evento)
        {
            Evento novoEvento = _lstEventos.FirstOrDefault(e => e.EventoId == evento.EventoId);

            if (novoEvento == null)
            {
                _lstEventos.Add(evento);
            }
            else
            {
                // Inscrição já realizada para o evento
            }
        }

        // Remover
        public void RemoverEvento(Evento evento)
        {
            _lstEventos.RemoveAll(r => r.EventoId == evento.EventoId);
        }

        // Obter a quantidade de inscrições
        public int ObterQuantidadeIncricoes()
        {
            return _lstEventos.Count();
        }

        // Limpar carrinho
        public void LimparCarrinho()
        {
            _lstEventos.Clear();
        }

        // Itens do carrinho
        public List<Evento> ItensCarrinho
        {
            get { return _lstEventos; }
        }
    }
}
