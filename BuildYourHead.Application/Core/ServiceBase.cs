using BuildYourHead.Persistence;

namespace BuildYourHead.Application.Core
{
    public class ServiceBase
    {
        public ServiceBase(IUnitOfWork uow)
        {
            Uow = uow;
        }

        protected IUnitOfWork Uow { get; }
    }
}
