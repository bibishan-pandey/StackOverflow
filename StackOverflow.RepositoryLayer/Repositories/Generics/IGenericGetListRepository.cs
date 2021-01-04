using System.Linq;

namespace StackOverflow.RepositoryLayer.Repositories.Generics
{
    public interface IGenericGetListRepository<out TModel> where TModel : class
    {
        IQueryable<TModel> GetList();
    }
}
