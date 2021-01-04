namespace StackOverflow.RepositoryLayer.Repositories.Generics
{
    public interface IGenericInsertRepository<in TModel> where TModel : class
    {
        void Insert(TModel model);
    }
}
