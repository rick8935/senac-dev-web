using MeuCorre.core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.core.Entities
{
    public class Categoria : Entidade 
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoTransacao Tipo { get; set; }
        public string Cor { get; set; }
        public string Icone { get; set; }
        public Usuario UsuarioId { get; set; }
        public bool Ativo { get; set; }


        public Categoria(string nome, string descricao, Enum tipo, string cor, string icone, Usuario.Id usuarioId, bool ativo)
        {
            
        }
    }
}
