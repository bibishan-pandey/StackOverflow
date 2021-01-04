namespace StackOverflow.RepositoryLayer.Repositories.Generics
{
    public interface IGenericUpdateRepository<in TModel> where TModel : class
    {
        void Update(TModel model);
    }
}
