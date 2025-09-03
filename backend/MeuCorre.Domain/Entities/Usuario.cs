using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Domain.Entities
{
    public class Usuario : Entidade
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public bool Ativo { get; private set; }

        public Usuario(string nome, string email, string senha, DateTime dataNascimento, bool ativo)
        {
            if(!TemIdadeMinima())
            {
                throw new Exception("Usuário deve ter no mínimo 13 anos.");
            }

            Nome = nome;
            Email = email;
            Senha = ValidarSenha(senha);
            DataNascimento = DataNascimento;
            Ativo = ativo;
        }

        private int CalcularIdade()
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - DataNascimento.Year;

            if (DataNascimento.Date > hoje.AddYears(-idade))
                idade--;

            return idade;
        }

        private bool TemIdadeMinima()
        {
            var resultado = CalcularIdade() >= 13;
            return resultado;
        }

        public string ValidarSenha(string senha)
        {
            if(senha.Length < 6)
            {

            }
            return senha;
        }

        public void AtivarUsuario()
        {
            Ativo = true;
            AtualizarDataModificacao();
        }

        public void InativarUsuario()
        {
            Ativo = false;
            AtualizarDataModificacao();
        }
    }
}
