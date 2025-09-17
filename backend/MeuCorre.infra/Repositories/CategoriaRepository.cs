using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Enums;
using MeuCorre.Domain.Interfaces.Repositories;
using MeuCorre.infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MeuCorre.infra.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly MeuDbContext _meuDbContext;
        public CategoriaRepository(MeuDbContext meuDbContext)
        {
            _meuDbContext = meuDbContext;
        }
        public Task AdicinarAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExisteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Categoria>> ListarTodasPorUsuarioAsync(Guid usuarioId)
        {
            var listaCategorias = _meuDbContext.Categorias.Where(c => c.UsuarioId == usuarioId);
            return listaCategorias;
        }

        public Task<bool> NomeExisteParaUsuarioAsync(string nome, Guid usuarioId, TipoTransacao tipoTransacao)
        {
            throw new NotImplementedException();
        }

        public async Task<Categoria?> ObterPorIdAsync(Guid categoriaId)
        {
            var categoria =
                await _meuDbContext.Categorias.FindAsync(categoriaId);
            return categoria;
        }

        public Task<Usuario?> ObterUsuarioPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> ObterUsuarioPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoverAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
