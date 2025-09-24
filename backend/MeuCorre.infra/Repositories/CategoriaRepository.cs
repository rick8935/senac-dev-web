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
        public async Task AdicinarAsync(Categoria categoria)
        {
            _meuDbContext.Categorias.Add(categoria);
            await _meuDbContext.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Categoria categoria)
        {
            _meuDbContext.Categorias.Update(categoria);
            await _meuDbContext.SaveChangesAsync();
        }

        public async Task<bool> ExisteAsync(Guid categoriaId)
        {
            var existe = await _meuDbContext.Categorias.AnyAsync(c => c.Id == categoriaId);
            return existe;
        }

        public async Task<IEnumerable<Categoria>> ListarTodasPorUsuarioAsync(Guid usuarioId)
        {
            var listaCategorias = _meuDbContext.Categorias.Where(c => c.UsuarioId == usuarioId);
            return listaCategorias;
        }

        public async Task<bool> NomeExisteParaUsuarioAsync(string nome, Guid usuarioId, TipoTransacao tipoTransacao)
        {
            var existe = await _meuDbContext.Categorias.AnyAsync(c => c.Nome == nome && c.UsuarioId == usuarioId && c.TipoTransacao == tipoTransacao);
            return existe;
        }

        public async Task<bool> NomeExisteParaUsuarioAsync(string nome, TipoTransacao tipoTransacao, Guid usuarioId)
        {
            var existe = await _meuDbContext.Categorias
                .AnyAsync(
                            c => c.Nome == nome &&
                            c.UsuarioId == usuarioId &&
                            c.TipoTransacao == tipoTransacao
                        );

            return existe;
        }

        public object NomeExisteParaUsuarioAsync(string nome, TipoTransacao tipoTransacao, Guid? usuarioId)
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
