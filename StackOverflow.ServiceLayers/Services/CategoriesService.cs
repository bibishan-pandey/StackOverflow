using System.Linq;
using StackOverflow.DomainModels.Models;
using StackOverflow.RepositoryLayer.Repositories.Interfaces;
using StackOverflow.ServiceLayers.Helpers;
using StackOverflow.ViewModels.ViewModels;

namespace StackOverflow.ServiceLayers.Services
{
    public interface ICategoriesService
    {
        IQueryable<CategoryViewModel> GetList();
        CategoryViewModel GetById(int id);
        void Insert(CategoryViewModel model);
        void Update(CategoryViewModel model);
        void Delete(int? id);
    }

    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public IQueryable<CategoryViewModel> GetList()
        {
            var categories = _categoriesRepository.GetList();
            var mapper = CustomMapperConfiguration.ConfigCreateMapper<Category, CategoryViewModel>();
            return mapper.Map<IQueryable<Category>, IQueryable<CategoryViewModel>>(categories);
        }

        public CategoryViewModel GetById(int id)
        {
            var category = _categoriesRepository.GetById(id);
            if (category == null) return null;

            var mapper = CustomMapperConfiguration.ConfigCreateMapper<Category, CategoryViewModel>();
            return mapper.Map<Category, CategoryViewModel>(category);
        }

        public void Insert(CategoryViewModel model)
        {
            var mapper = CustomMapperConfiguration.ConfigCreateMapper<CategoryViewModel, Category>();
            var category = mapper.Map<CategoryViewModel, Category>(model);
            _categoriesRepository.Insert(category);
        }

        public void Update(CategoryViewModel model)
        {
            var mapper = CustomMapperConfiguration.ConfigCreateMapper<CategoryViewModel, Category>();
            var category = mapper.Map<CategoryViewModel, Category>(model);
            _categoriesRepository.Update(category);
        }

        public void Delete(int? id)
        {
            _categoriesRepository.Delete(id);
        }
    }
}
