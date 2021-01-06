using System.Linq;
using AutoMapper;
using StackOverflow.DomainModels.Models;
using StackOverflow.RepositoryLayer.Repositories.Interfaces;
using StackOverflow.ServiceLayers.Extensions;
using StackOverflow.ServiceLayers.Helpers;
using StackOverflow.ViewModels.ViewModels;

namespace StackOverflow.ServiceLayers.Services
{
    public interface IDiscussionsService
    {
        IQueryable<DiscussionViewModel> GetList();
        DiscussionViewModel GetById(int id);
        void Insert(NewDiscussionViewModel model);
        void Update(EditDiscussionViewModel model);
        int CountDiscussionVotes(int discussionId);
        int CountDiscussionComments(int discussionId);
        int CountDiscussionViews(int discussionId, int value);
        void Delete(int? id);
    }

    public class DiscussionsService : IDiscussionsService
    {
        private readonly IDiscussionsRepository _discussionsRepository;

        public DiscussionsService(IDiscussionsRepository discussionsRepository)
        {
            _discussionsRepository = discussionsRepository;
        }

        public IQueryable<DiscussionViewModel> GetList()
        {
            var discussions = _discussionsRepository.GetList();
            var mapper = new MapperConfiguration(c =>
            {
                c.CreateMap<Discussion, DiscussionViewModel>();
                c.IgnoreUnmapped();
                c.CreateMap<User, UserViewModel>();
                c.IgnoreUnmapped();
                c.CreateMap<Category, CategoryViewModel>();
                c.IgnoreUnmapped();
            }).CreateMapper();
            return mapper.Map<IQueryable<Discussion>, IQueryable<DiscussionViewModel>>(discussions);
        }

        public DiscussionViewModel GetById(int id)
        {
            var discussion = _discussionsRepository.GetById(id);
            if (discussion == null) return null;

            var mapper = new MapperConfiguration(c =>
            {
                c.CreateMap<Discussion, DiscussionViewModel>();
                c.IgnoreUnmapped();
                c.CreateMap<User, UserViewModel>();
                c.IgnoreUnmapped();
                c.CreateMap<Category, CategoryViewModel>();
                c.IgnoreUnmapped();
            }).CreateMapper();
            return mapper.Map<Discussion, DiscussionViewModel>(discussion);
        }

        public void Insert(NewDiscussionViewModel model)
        {
            var mapper = new MapperConfiguration(c =>
            {
                c.CreateMap<NewDiscussionViewModel, Discussion>();
                c.IgnoreUnmapped();
                c.CreateMap<UserViewModel, User>();
                c.IgnoreUnmapped();
                c.CreateMap<CategoryViewModel, Category>();
                c.IgnoreUnmapped();
            }).CreateMapper();
            var discussion = mapper.Map<NewDiscussionViewModel, Discussion>(model);
            _discussionsRepository.Insert(discussion);
        }

        public void Update(EditDiscussionViewModel model)
        {
            var mapper = new MapperConfiguration(c =>
            {
                c.CreateMap<EditDiscussionViewModel, Discussion>();
                c.IgnoreUnmapped();
                c.CreateMap<UserViewModel, User>();
                c.IgnoreUnmapped();
                c.CreateMap<CategoryViewModel, Category>();
                c.IgnoreUnmapped();
            }).CreateMapper();
            var discussion = mapper.Map<EditDiscussionViewModel, Discussion>(model);
            _discussionsRepository.Update(discussion);
        }

        public int CountDiscussionVotes(int discussionId)
        {
            return _discussionsRepository.CountDiscussionVotes(discussionId);
        }

        public int CountDiscussionComments(int discussionId)
        {
            return _discussionsRepository.CountDiscussionComments(discussionId);
        }

        public int CountDiscussionViews(int discussionId, int value)
        {
            return _discussionsRepository.CountDiscussionViews(discussionId, value);
        }

        public void Delete(int? id)
        {
            _discussionsRepository.Delete(id);
        }
    }
}
