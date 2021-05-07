using NerdStore.Core.DomainObjects;
using System;

namespace NerdStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public Guid CategoriaId { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Categoria Categoria { get; private set; }
        public Dimensoes Dimensoes { get; private set; }

        protected Produto() { }
        public Produto(string nome, string descricao, bool ativo, decimal valor, Guid categoriaId, DateTime dataCadastro, string imagem, Dimensoes dimensoes)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            CategoriaId = categoriaId;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            Dimensoes = dimensoes;

            Validar();
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
        public void AlterarDescricao(string descricao) => Descricao = descricao;
        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0)
                quantidade = quantidade *= -1;

            QuantidadeEstoque -= quantidade;
        }
        public void ReporEstoque(int quantidade) => QuantidadeEstoque += quantidade;
        public bool PossuiEstoque(int quantidade) => QuantidadeEstoque >= quantidade;
        public void Validar()
        {
            AssertionConcern.ValidarSeVazio(Nome, "O campo Nome não pode ser vazio.");
            AssertionConcern.ValidarSeVazio(Descricao, "O campo Descricao não pode ser vazio.");
            AssertionConcern.ValidarSeIgual(CategoriaId, Guid.Empty, "O campo CategoriaId não pode ser vazio.");
            AssertionConcern.ValidarSeMenorQue(Valor, 1, "O campo valor não pode ser menor que zero.");
            AssertionConcern.ValidarSeVazio(Imagem, "O campo Imagem não pode ser vazio.");
        }
    }
}
