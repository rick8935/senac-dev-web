using MeuCorre.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace MeuCorre.Domain.Entities
{
    public class Categoria : Entidade 
    {
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public TipoTransacao TipoTransacao { get; private set; }
        public string? Cor { get; private set; }
        public string? Icone { get; private set; }
        public Guid? UsuarioId { get; private set; }
        public bool Ativo { get; private set; }

        public virtual Usuario Usuario { get; private set; }

        public Categoria(string nome, string? descricao, TipoTransacao tipoTransacao, string? cor, string? icone, Guid? usuarioId, bool ativo)
        {
            ValidarEntidadeCategoria(cor);

            Nome = nome.ToUpper();
            Descricao = descricao;
            Cor = cor;
            Icone = icone;
            UsuarioId = usuarioId;
            Ativo = true;
            TipoTransacao = tipoTransacao;
        }

        public void AtualizarInformacoes(string nome, string? descricao, string? cor, string? icone, TipoTransacao tipoTransacao)
        {
            Nome = nome.ToUpper();
            Descricao = descricao;
            Cor = cor;
            Icone = icone;;
            TipoTransacao = tipoTransacao;
            AtualizarDataMoficacao();
        }

        public void Ativar()
        {
            Ativo = true;
            AtualizarDataMoficacao();
        }

        public void Inativar()
        {
            Ativo = false;
            AtualizarDataMoficacao();
        }

        private void ValidarEntidadeCategoria(string cor)
        {
            if(string.IsNullOrEmpty(cor))
            {
                return;
            }

            var corRegex = new Regex(@"^#?([0-9a-fA-F]{3}){1,2}$");

            if(!corRegex.IsMatch(cor))
            {
                throw new Exception("A cor deve estar no formato hexadecimal");
            }
        }
    }
}
