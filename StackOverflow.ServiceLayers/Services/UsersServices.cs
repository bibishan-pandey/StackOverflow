using System.Linq;
using StackOverflow.DomainModels.Models;
using StackOverflow.RepositoryLayer.Repositories.Interfaces;
using StackOverflow.ServiceLayers.Helpers;
using StackOverflow.ViewModels.ViewModels;

namespace StackOverflow.ServiceLayers.Services
{
    public interface IUsersServices
    {
        IQueryable<UserViewModel> GetList();
        UserViewModel GetById(int id);
        int Insert(RegisterViewModel model);
        void UpdateDetail(UserViewModel model);
        void UpdatePassword(UserPasswordViewModel model);
        void Delete(int? id);
        UserViewModel GetByEmail(string email);
        UserViewModel GetByEmailPassword(string email, string password);
    }

    public class UsersServices : IUsersServices
    {
        private readonly IUsersRepository _usersRepository;

        public UsersServices(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IQueryable<UserViewModel> GetList()
        {
            var users = _usersRepository.GetList();
            var mapper = CustomMapperConfiguration.ConfigCreateMapper<User, UserViewModel>();
            //var config = new MapperConfiguration(c =>
            //{
            //    c.CreateMap<User, UserViewModel>();
            //    c.IgnoreUnmapped();
            //});
            //var mapper = config.CreateMapper();

            return mapper.Map<IQueryable<User>, IQueryable<UserViewModel>>(users);
        }

        public UserViewModel GetById(int id)
        {
            var user = _usersRepository.GetById(id);
            if (user == null) return null;

            var mapper = CustomMapperConfiguration.ConfigCreateMapper<User, UserViewModel>();
            //var config = new MapperConfiguration(c =>
            //{
            //    c.CreateMap<User, UserViewModel>();
            //    c.IgnoreUnmapped();
            //});
            //var mapper = config.CreateMapper();

            return mapper.Map<User, UserViewModel>(user);
        }

        public int Insert(RegisterViewModel model)
        {
            var mapper = CustomMapperConfiguration.ConfigCreateMapper<RegisterViewModel, User>();
            //var config = new MapperConfiguration(c =>
            //{
            //    c.CreateMap<RegisterViewModel, User>();
            //    c.IgnoreUnmapped();
            //});
            //var mapper = config.CreateMapper();
            var user = mapper.Map<RegisterViewModel, User>(model);
            user.Password = Sha256HashGenerator.GenerateHash(model.Password);
            _usersRepository.Insert(user);
            _usersRepository.Save();
            return _usersRepository.GetRecentUser();
        }

        public void UpdateDetail(UserViewModel model)
        {
            var mapper = CustomMapperConfiguration.ConfigCreateMapper<UserViewModel, User>();
            //var config = new MapperConfiguration(c =>
            //{
            //    c.CreateMap<UserViewModel, User>();
            //    c.IgnoreUnmapped();
            //});
            //var mapper = config.CreateMapper();
            var user = mapper.Map<UserViewModel, User>(model);
            _usersRepository.Update(user);
            _usersRepository.Save();
        }

        public void UpdatePassword(UserPasswordViewModel model)
        {
            var mapper = CustomMapperConfiguration.ConfigCreateMapper<UserPasswordViewModel, User>();
            //var config = new MapperConfiguration(c =>
            //{
            //    c.CreateMap<UserPasswordViewModel, User>();
            //    c.IgnoreUnmapped();
            //});
            //var mapper = config.CreateMapper();
            var user = mapper.Map<UserPasswordViewModel, User>(model);
            user.Password = Sha256HashGenerator.GenerateHash(model.Password);
            _usersRepository.UpdatePassword(user);
            _usersRepository.Save();
        }

        public void Delete(int? id)
        {
            _usersRepository.Delete(id);
        }

        public UserViewModel GetByEmail(string email)
        {
            var user = _usersRepository.GetByEmail(email);
            if (user == null) return null;

            var mapper = CustomMapperConfiguration.ConfigCreateMapper<User, UserViewModel>();
            //var config = new MapperConfiguration(c =>
            //{
            //    c.CreateMap<User, UserViewModel>();
            //    c.IgnoreUnmapped();
            //});
            //var mapper = config.CreateMapper();

            return mapper.Map<User, UserViewModel>(user);
        }

        public UserViewModel GetByEmailPassword(string email, string password)
        {
            var user = _usersRepository.GetByEmailPassword(email, Sha256HashGenerator.GenerateHash(password));
            if (user == null) return null;

            var mapper = CustomMapperConfiguration.ConfigCreateMapper<User, UserViewModel>();
            //var config = new MapperConfiguration(c =>
            //{
            //    c.CreateMap<User, UserViewModel>();
            //    c.IgnoreUnmapped();
            //});
            //var mapper = config.CreateMapper();

            return mapper.Map<User, UserViewModel>(user);

        }
    }
}
