using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Enums;

namespace MeuCorre.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Categoria>> ListarTodasPorUsuarioAsync(Guid usuarioId);
        Task<bool> ExisteAsync(Guid id);
        Task<bool> NomeExisteParaUsuarioAsync(string nome, Guid usuarioId, TipoTransacao tipoTransacao);
        Task AdicinarAsync(Categoria categoria);
        Task AtualizarAsync(Categoria categoria);
        Task RemoverAsync(Categoria categoria);
        Task<Usuario?> ObterUsuarioPorEmail(string email);
        Task<Usuario?> ObterUsuarioPorId(Guid id);
    }
}
