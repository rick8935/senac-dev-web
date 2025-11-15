namespace MeuCorre.Domain.Entities
{
    public abstract class Entidade
    {
        public Guid Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAtualizacao { get;  set; }

        protected Entidade()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
        }

        protected Entidade(Guid id)
        {
            Id = id;
            DataAtualizacao = DateTime.Now;
        }

        public void AtualizarDataMoficacao()
        {
            DataAtualizacao = DateTime.Now;
        }
    }
}