using MeuCorre.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Domain.Entities
{
    public class Categoria : Entidade 
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoTransacao Tipo { get; set; }
        public string Cor { get; set; }
        public string Icone { get; set; }
        public Guid? UsuarioId { get; set; }
        public bool Ativo { get; set; }


        public Categoria(string nome, string descricao, TipoTransacao tipo, string cor, string icone, Guid? usuarioId, bool ativo)
        {
            Nome = nome;
            Descricao = descricao;
            Tipo = tipo;
            Cor = cor;
            Icone = icone;
            UsuarioId = usuarioId;
            Ativo = ativo;
        }
    }
}
