using System.Linq;
using StackOverflow.DomainModels.Models;
using StackOverflow.RepositoryLayer.Repositories.Interfaces;
using StackOverflow.ServiceLayers.Helpers;
using StackOverflow.ViewModels.ViewModels;

namespace StackOverflow.ServiceLayers.Services
{
    public interface IVoteTypesService
    {
        IQueryable<VoteTypeViewModel> GetList();
        VoteTypeViewModel GetById(int id);
        void Insert(VoteTypeViewModel model);
        void Update(VoteTypeViewModel model);
        void Delete(int? id);
    }

    public class VoteTypesService : IVoteTypesService
    {
        private readonly IVoteTypesRepository _voteTypesRepository;

        public VoteTypesService(IVoteTypesRepository voteTypesRepository)
        {
            _voteTypesRepository = voteTypesRepository;
        }

        public IQueryable<VoteTypeViewModel> GetList()
        {
            var voteTypes = _voteTypesRepository.GetList();
            var mapper = CustomMapperConfiguration.ConfigCreateMapper<VoteType, VoteViewModel>();
            return mapper.Map<IQueryable<VoteType>, IQueryable<VoteTypeViewModel>>(voteTypes);
        }

        public VoteTypeViewModel GetById(int id)
        {
            var voteType = _voteTypesRepository.GetById(id);
            if (voteType == null) return null;

            var mapper = CustomMapperConfiguration.ConfigCreateMapper<VoteType, VoteTypeViewModel>();
            return mapper.Map<VoteType, VoteTypeViewModel>(voteType);
        }

        public void Insert(VoteTypeViewModel model)
        {
            var mapper = CustomMapperConfiguration.ConfigCreateMapper<VoteTypeViewModel, VoteType>();
            var voteType = mapper.Map<VoteTypeViewModel, VoteType>(model);
            _voteTypesRepository.Insert(voteType);
        }

        public void Update(VoteTypeViewModel model)
        {
            var mapper = CustomMapperConfiguration.ConfigCreateMapper<VoteTypeViewModel, VoteType>();
            var voteType = mapper.Map<VoteTypeViewModel, VoteType>(model);
            _voteTypesRepository.Update(voteType);
        }

        public void Delete(int? id)
        {
            _voteTypesRepository.Delete(id);
        }
    }
}
