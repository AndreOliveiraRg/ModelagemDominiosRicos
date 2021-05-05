using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }
        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;

            Validar();
        }

        private void Validar()
        {
            AssertionConcern.ValidarSeMenorQue(Altura, 1, "O campo Altura deve ser maior que 1.");
            AssertionConcern.ValidarSeMenorQue(Largura, 1, "O campo Largura deve ser maior que 1.");
            AssertionConcern.ValidarSeMenorQue(Profundidade, 1, "O campo Profundidade deve ser maior que 1.");
        }

        public override string ToString() => $"LxAxP: {Largura} x {Altura} x {Profundidade}";
    }
}
