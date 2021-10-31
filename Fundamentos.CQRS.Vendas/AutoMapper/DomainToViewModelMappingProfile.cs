using AutoMapper;
using Fundamentos.CQRS.Vendas.Application.Queries.ViewModel;
using Fundamentos.CQRS.Vendas.Domain;

namespace Fundamentos.CQRS.Vendas.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Entidade, EntidadeViewModel>();
        }
    }
}
