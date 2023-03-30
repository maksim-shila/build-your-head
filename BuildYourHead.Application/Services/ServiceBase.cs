using AutoMapper;
using BuildYourHead.Persistence;

namespace BuildYourHead.Application.Services
{
    public class ServiceBase
    {
        public ServiceBase(IMapper mapper, IUnitOfWork uow)
        {
            Mapper = mapper;
            Uow = uow;
        }

        protected IMapper Mapper { get; }
        protected IUnitOfWork Uow { get; }
    }
}
