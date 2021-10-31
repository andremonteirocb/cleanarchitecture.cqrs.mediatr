using AutoMapper;
using Fundamentos.CQRS.Vendas.Application.Queries.ViewModel;
using Fundamentos.CQRS.Vendas.Domain;

namespace Fundamentos.CQRS.Vendas.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //CreateMap<PedidoViewModel, Pedido>()
            //    .ConstructUsing(p =>
            //        new Pedido(new System.Guid(), false, 0, 100));

            CreateMap<EntidadeViewModel, Entidade>();
        }
    }
}