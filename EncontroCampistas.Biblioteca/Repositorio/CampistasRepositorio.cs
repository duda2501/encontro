using EncontroCampistas.Biblioteca.Entidades;
using System.Collections.Generic;

namespace EncontroCampistas.Biblioteca.Repositorio
{
    public class CampistasRepositorio
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<Campista> Campistas
        {
            get { return _context.Campistas; }
        }

        //Salvar Campista - Alterar Campista
        public void Salvar(Campista campista)
        {
            if (campista.CampistaId == 0)
            {
                // Inclusão
                _context.Campistas.Add(campista);
            }
            else
            {
                //Alteração
                Campista objCampista = _context.Campistas.Find(campista.CampistaId);

                if (objCampista != null)
                {
                    objCampista.Nome = campista.Nome;
                    objCampista.DataNascimento = campista.DataNascimento;
                    objCampista.Endereco = campista.Endereco;
                    objCampista.Numero = campista.Numero;
                    objCampista.Complemento = campista.Complemento;
                    objCampista.Bairro = campista.Bairro;
                    objCampista.Cidade = campista.Cidade;
                    objCampista.CEP = campista.CEP;
                    objCampista.Telefone = campista.Telefone;
                    objCampista.Celular = campista.Celular;
                    objCampista.Email = campista.Email;
                    objCampista.NomeMae = campista.NomeMae;
                    objCampista.FoneMae = campista.FoneMae;
                    objCampista.NomePai = campista.NomePai;
                    objCampista.Responsavel = campista.Responsavel;
                    objCampista.FoneResponsavel = campista.FoneResponsavel;
                    objCampista.Paroquia = campista.Paroquia;
                    objCampista.ParoquiaAcampamento = campista.ParoquiaAcampamento;
                    objCampista.Pastoral = campista.Pastoral;
                    objCampista.Batizado = campista.Batizado;
                    objCampista.PrimeiraComunhao = campista.PrimeiraComunhao;
                    objCampista.Crismado = campista.Crismado;
                    objCampista.Casado = campista.Casado;
                    objCampista.TamanhoCamiseta = campista.TamanhoCamiseta;
                }

            }

            _context.SaveChanges();
        }


        //Excluir

        public Campista Excluir(int campistaId)
        {

            Campista objCampista = _context.Campistas.Find(campistaId);

            if (objCampista != null)
            {
                _context.Campistas.Remove(objCampista);
                // _context.SaveChanges();
            }

            return objCampista;
        }
    }
}
