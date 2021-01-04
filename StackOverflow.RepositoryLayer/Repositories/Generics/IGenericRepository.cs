using System;

namespace StackOverflow.RepositoryLayer.Repositories.Generics
{
    public interface IGenericRepository<TModel> :
        IGenericGetListRepository<TModel>,
        IGenericGetByIdRepository<TModel>,
        IGenericInsertRepository<TModel>,
        IGenericUpdateRepository<TModel>,
        IGenericDeleteRepository,
        IGenericSaveRepository,
        IDisposable
    where TModel : class
    {
    }
}
