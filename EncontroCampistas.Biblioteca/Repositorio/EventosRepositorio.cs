using EncontroCampistas.Biblioteca.Entidades;
using System.Collections.Generic;

namespace EncontroCampistas.Biblioteca.Repositorio
{
    public class EventosRepositorio
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<Evento> Eventos
        {
            get { return _context.Eventos; }
        }


        //Salvar Evento - Alterar Evento
        public void Salvar(Evento evento)
        {
            if (evento.EventoId == 0)
            {
                // Inclusão
                _context.Eventos.Add(evento);
            }
            else
            {
                //Alteração
                Evento evt = _context.Eventos.Find(evento.EventoId);

                if (evt != null)
                {
                    evt.Descricao = evento.Descricao;
                    evt.Local = evento.Local;
                    evt.DataHoraRealizacao = evento.DataHoraRealizacao;
                    evt.Duracao = evento.Duracao;
                    evt.iTipoEvento = evento.iTipoEvento;
                }

            }

            _context.SaveChanges();
        }


        //Excluir

        public Evento Excluir(int eventoId)
        {

            Evento evt = _context.Eventos.Find(eventoId);

            if (evt != null)
            {
                _context.Eventos.Remove(evt);
            }

            return evt;
        }
    }
}
