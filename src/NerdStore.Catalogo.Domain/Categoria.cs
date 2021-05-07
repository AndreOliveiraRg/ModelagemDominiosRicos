using System.Collections.Generic;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        protected Categoria() { }
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public string Nome { get; private set; }
        public int Codigo { get; private set; }
        public override string ToString() => $"{Nome} {Codigo}";
        public ICollection<Produto> Produtos { get; private set; }
        public void Validar()
        {
            AssertionConcern.ValidarSeVazio(Nome, "O campo Nome não pode ser vazio.");
            AssertionConcern.ValidarSeMenorQue(Codigo, 1, "O campo Codigo não pode ser vazio.");
        }
    }
}