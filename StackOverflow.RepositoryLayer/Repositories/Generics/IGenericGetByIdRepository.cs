namespace StackOverflow.RepositoryLayer.Repositories.Generics
{
    public interface IGenericGetByIdRepository<out TModel> where TModel : class
    {
        TModel GetById(int id);
    }
}
