using System.Linq;
using StackOverflow.DomainModels.Models;
using StackOverflow.RepositoryLayer.Repositories.Interfaces;
using StackOverflow.ServiceLayers.Helpers;
using StackOverflow.ViewModels.ViewModels;

namespace StackOverflow.ServiceLayers.Services
{
    public interface IVotesService
    {
        IQueryable<VoteViewModel> GetList();
        VoteViewModel GetById(int id);
        void Insert(VoteViewModel model);
        void Update(VoteViewModel model);
        void Delete(int? id);
    }

    public class VotesService : IVotesService
    {
        private readonly IVotesRepository _votesRepository;

        public VotesService(IVotesRepository votesRepository)
        {
            _votesRepository = votesRepository;
        }

        public IQueryable<VoteViewModel> GetList()
        {
            var votes = _votesRepository.GetList();
            var mapper = CustomMapperConfiguration.ConfigCreateMapper<Vote, VoteViewModel>();
            return mapper.Map<IQueryable<Vote>, IQueryable<VoteViewModel>>(votes);
        }

        public VoteViewModel GetById(int id)
        {
            var vote = _votesRepository.GetById(id);
            if (vote == null) return null;

            var mapper = CustomMapperConfiguration.ConfigCreateMapper<Vote, VoteViewModel>();
            return mapper.Map<Vote, VoteViewModel>(vote);
        }

        public void Insert(VoteViewModel model)
        {
            var mapper = CustomMapperConfiguration.ConfigCreateMapper<VoteViewModel, Vote>();
            var vote = mapper.Map<VoteViewModel, Vote>(model);
            _votesRepository.Insert(vote);
        }

        public void Update(VoteViewModel model)
        {
            var mapper = CustomMapperConfiguration.ConfigCreateMapper<VoteViewModel, Vote>();
            var vote = mapper.Map<VoteViewModel, Vote>(model);
            _votesRepository.Update(vote);
        }

        public void Delete(int? id)
        {
            _votesRepository.Delete(id);
        }
    }
}
