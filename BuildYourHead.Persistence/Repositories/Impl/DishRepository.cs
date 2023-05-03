using BuildYourHead.Persistence.Entities;
using BuildYourHead.Persistence.Repositories.Interfaces;

namespace BuildYourHead.Persistence.Repositories.Impl
{
    internal class DishRepository : RepositoryBase<DishEntity, int>, IDishRepository
    {
        public DishRepository(ApplicationContext context) : base(context) { }
    }
}
