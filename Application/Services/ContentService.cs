using Application.Interfaces;
using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.Content;

namespace Application.Services;

public class ContentService : IContentService
{
    #region Repository

    private readonly IContentRepository _contentRepository;

    public ContentService(IContentRepository contentRepository)
    {
        _contentRepository = contentRepository;
    }

    #endregion

    public async Task CreateContenTask(ContentViewModel content)
    {
        var Content = new Content()
        {
            UserId = content.UserId,
            CategoryId = content.CategoryId,
            Banner = content.Banner,
            ContentText = content.ContentText,
            CreateDate = content.CreateDate,
            SubTitle = content.SubTitle,
            Tag = content.Tag,

        };
        await _contentRepository.CreateContenTask(Content);
    }

    public async Task Edit(ContentViewModel content)
    {
        var Content = await _contentRepository.GetContentById(content.id);
        Content.IsDeleted = content.IsDeleted;
        Content.Title = content.Title;
        Content.ContentText = content.ContentText;
        Content.SubTitle = content.SubTitle;
        Content.Tag = content.Tag;
        Content.CategoryId = content.CategoryId;
        Content.Banner = content.Banner;
        Content.id = content.id;
        Content.UserId= content.UserId;
        await _contentRepository.Edit(Content);
    }

    public async Task<ContentViewModel> GetContentById(int id)
    {
        var Content = await _contentRepository.GetContentById(id);
        var ContentViewModel = new ContentViewModel()
        {
            id = Content.id,
            Banner = Content.Banner,
            CategoryId = Content.CategoryId,
            ContentText = Content.ContentText,
            CreateDate = Content.CreateDate,
            SubTitle = Content.SubTitle,
            Tag = Content.Tag,
            Title = Content.Title,
            UserId = Content.UserId,
            ViewCount = Content.ViewCount,
            UserName = Content.User.UserName,
        };
        return ContentViewModel;
    }

    public async Task<ICollection<ContentViewModel>> AllContents()
    {
        var ListViewModel = new List<ContentViewModel>();
        var Contents = await _contentRepository.AllContents();
        foreach (var Content in Contents)
        {
            var ContentViewModel = new ContentViewModel()
            {
                id = Content.id,
                Banner = Content.Banner,
                CategoryId = Content.CategoryId,
                ContentText = Content.ContentText,
                CreateDate = Content.CreateDate,
                SubTitle = Content.SubTitle,
                Tag = Content.Tag,
                Title = Content.Title,
                UserId = Content.UserId,
                UserName = Content.User.UserName,
                ViewCount = Content.ViewCount,
            };
            ListViewModel.Add(ContentViewModel);
        }

        return ListViewModel;
    }
}