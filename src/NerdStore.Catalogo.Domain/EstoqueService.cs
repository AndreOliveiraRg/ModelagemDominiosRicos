﻿using System;
using System.Threading.Tasks;
using NerdStore.Catalogo.Domain.Events;
using NerdStore.Core.Communication.Mediator;

namespace NerdStore.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatorHandler _mediator;
        private readonly int _quantidadeMinima = 10;

        public EstoqueService(IProdutoRepository produtoRepository, IMediatorHandler mediator)
        {
            _produtoRepository = produtoRepository;
            _mediator = mediator;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto is null)
                return false;

            if(!produto.PossuiEstoque(quantidade))
                return false;

            produto.DebitarEstoque(quantidade);

            if (produto.QuantidadeEstoque < _quantidadeMinima)
                await _mediator.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));

            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto is null)
                return false;

            produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitOfWork.Commit();
        }
    }
}
