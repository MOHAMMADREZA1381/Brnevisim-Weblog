using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.Content;

namespace Application.Services
{
    public class ViewCountService : IViewCountService
    {
        #region Repository
        private readonly IViewCountRepository _countRepository;

        public ViewCountService(IViewCountRepository countRepository)
        {
            _countRepository = countRepository;
        }
        #endregion
        public async Task AddView(ViewCountViewModel model)
        {
            bool ExistBeFore = await IsAnyIp(model.UserIp, model.ContentId);
            if (ExistBeFore == false)
            {
                var ViewCount = new ContentViews();
                ViewCount.ContentId = model.ContentId;
                ViewCount.UserIp = model.UserIp;
                await _countRepository.AddView(ViewCount);
            }
        }

        public async Task<bool> IsAnyIp(string UserIp, int ContentId)
        {
            return await _countRepository.IsAnyIp(UserIp, ContentId);
        }

    }
}
