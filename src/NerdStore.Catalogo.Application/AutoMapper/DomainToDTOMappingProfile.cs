using AutoMapper;
using NerdStore.Catalogo.Application.DTO;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Produto, ProdutoDTO>()
                .ForMember(x => x.Largura, y => y.MapFrom(z => z.Dimensoes.Largura))
                .ForMember(x => x.Altura, y => y.MapFrom(z => z.Dimensoes.Altura))
                .ForMember(x => x.Profundidade, y => y.MapFrom(z => z.Dimensoes.Profundidade));

            CreateMap<Categoria, CategoriaDTO>();
        }
    }
}
