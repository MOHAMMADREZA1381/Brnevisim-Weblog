﻿using Application.ImageTools;
using Application.ImageTools.Common;
using Application.Interfaces;
using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.Content;
using Ganss.Xss;

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

    public async Task CreateContentTask(ContentViewModel content)
    {
        var Content = new Content();

        //Sanitizer is a package for check ckeditor input for security
        var Sanity = new HtmlSanitizer();

        if (content.Banner.Length > 0)
        {
            var galleryImage = "";
            galleryImage = Guid.NewGuid().ToString("N") + Path.GetExtension(content.Banner.FileName);
            content.Banner.AddImageToServer(galleryImage, PathExtensions.ContentBannerOrginServer, 300, 300, PathExtensions.ContentBannerThumbServer);
            Content.Banner = galleryImage;
        }
        Content.UserId = content.UserId;
        Content.CategoryId = content.CategoryId;
        Content.ContentText =Sanity.Sanitize(content.ContentText);
        Content.CreateDate = DateTime.Now;
        Content.SubTitle = content.SubTitle;
        Content.Tag = content.Tag;
        Content.Title=content.Title;
        

        await _contentRepository.CreateContentTask(Content);
    }

    public async Task Edit(EditContentViewModel content)
    {
        var Content = await _contentRepository.GetContentById(content.id);

        //Sanitizer is a package for check ckeditor input for security
        var Sanity = new HtmlSanitizer();

        if (content.Banner !=null)
        {
            var galleryImage = "";
            galleryImage = Guid.NewGuid().ToString("N") + Path.GetExtension(content.Banner.FileName);
            content.Banner.AddImageToServer(galleryImage, PathExtensions.ContentBannerOrginServer, 300, 300, PathExtensions.ContentBannerThumbServer);
            Content.Banner = galleryImage;
        }
        Content.IsDeleted = content.IsDeleted;
        Content.Title = content.Title;
        Content.ContentText = Sanity.Sanitize(content.ContentText);
        Content.SubTitle = content.SubTitle;
        Content.Tag = content.Tag;
        Content.CategoryId = content.CategoryId;
        Content.id = content.id;
        Content.UserId = content.UserId;
        await _contentRepository.Edit(Content);
    }

    public async Task<ContentViewModel> GetContentById(int id)
    {
        var Content = await _contentRepository.GetContentById(id);

        //Sanitizer is a package for check ckeditor input for security
        var Sanity = new HtmlSanitizer();

        var ContentViewModel = new ContentViewModel()
        {
            id = Content.id,
            BannerName = Content.Banner,
            CategoryId = Content.CategoryId,
            ContentText = Sanity.Sanitize(Content.ContentText),
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

        //Sanitizer is a package for check ckeditor input for security
        var Sanity = new HtmlSanitizer();

        var Contents = await _contentRepository.AllContents();
        foreach (var Content in Contents)
        {
            var ContentViewModel = new ContentViewModel()
            {
                id = Content.id,
                BannerName = Content.Banner,
                CategoryId = Content.CategoryId,
                ContentText =Sanity.Sanitize(Content.ContentText),
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

    public async Task<FilterContentViewModel> GetContentWithFilter(FilterContentViewModel model)
    {
        return await _contentRepository.GetAllContentWithFilter(model);
    }

    public async Task<EditContentViewModel> GetContentForEdit(int id)
    {
        var content =await  GetContentById(id);
        var ContentEdit = new EditContentViewModel()
        {
            BannerName = content.BannerName,
            CategoryId = content.CategoryId,
            ContentText = content.ContentText,
            CreateDate = content.CreateDate,
            SubTitle = content.SubTitle,
            IsDeleted = content.IsDeleted,
            Tag = content.Tag,
            Title = content.Title,
            UserId = content.UserId,
            UserName = content.UserName,
            ViewCount = content.ViewCount,
            id = content.id,
        };
        return ContentEdit;

    }

    public async Task<State> DeletContent(int id, int UserId)
    {
        var Content = await GetContentForEdit(id);
        if (Content.UserId == UserId)
        {
            Content.IsDeleted = true;
            await Edit(Content);
            return State.Success;
        }

        return State.Failed;
    }
}