using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EncontroCampistas.Biblioteca.Entidades
{
    public class EmailPedido
    {
        private readonly EmailConfiguracoes _emailConfiguracoes;

        public EmailPedido(EmailConfiguracoes emailConfiguracoes)
        {
            _emailConfiguracoes = emailConfiguracoes;
        }


        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _emailConfiguracoes.UsarSsl;
                smtpClient.Host = _emailConfiguracoes.ServidorSmtp;
                smtpClient.Port = _emailConfiguracoes.ServidorPorta;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(
                    _emailConfiguracoes.Usuario, _emailConfiguracoes.ServidorSmtp
                    );

                if (_emailConfiguracoes.EscreverArquivo)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _emailConfiguracoes.PastaArquivo;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("Inscrições realizadas:")
                    .AppendLine("-------")
                    .AppendLine("Eventos");

                foreach (var item in carrinho.ItensCarrinho)
                {
                    body.AppendFormat("Evento\r\n{0}\r\n\r\nLocal\r\n{1}\r\n\r\nData e hora de realização\r\n{2}",
                        item.Descricao, item.Local, item.DataHoraRealizacao);
                }

                body.AppendFormat("--------------------")
                    .AppendLine("Enviar para:")
                    .AppendLine(pedido.NomeCliente)
                    .AppendLine(pedido.Email)
                    .AppendLine(pedido.Endereco ?? "")
                    .AppendLine(pedido.Cidade ?? "")
                    .AppendLine(pedido.Complemento ?? "")
                    .AppendLine("--------------------");

                MailMessage mailMessage = new MailMessage(
                    _emailConfiguracoes.De,
                    _emailConfiguracoes.Para,
                    "Novo peido", body.ToString());


                if (_emailConfiguracoes.EscreverArquivo)
                {
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                }

                smtpClient.Send(mailMessage);

            }
        }
    }
}
