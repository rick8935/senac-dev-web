using MediatR;
using MeuCorre.Application.UserCases.Usuarios.Commands;
using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace MeuCorre.Application.UserCases.Usuarios.Commands
{
    public class AtualizarUsuarioCommand :IRequest<(string, bool)>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }

    internal class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, (string, bool)>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public AtualizarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<(string, bool)> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var atualizarUsuario = new Usuario(request.Nome, request.Email, request.DataNascimento);

            await _usuarioRepository.AtualizarUsuarioAsync(atualizarUsuario);
            return ("Usuário atualizado com sucesso", true);
        }
    }
}


