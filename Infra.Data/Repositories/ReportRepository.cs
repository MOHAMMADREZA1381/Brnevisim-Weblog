using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.Report;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class ReportRepository:IReportRepository
{
    #region Context

    

    private readonly BlogContext _blogContext;

    public ReportRepository(BlogContext blogContext)
    {
        _blogContext = blogContext;
    }
    #endregion
    public async Task AddReport(ReportContent content)
    {
        await _blogContext.AddAsync(content);
      
    }

    public async Task RemoveReport(ReportContent content)
    {
         _blogContext.Remove(content);
    }

    public async Task<ReportContent> GetReport(int id)
    {
      return  await _blogContext.ReportContents.Where(a => a.id == id).Include(a=>a.Content).FirstOrDefaultAsync();
    }

    public async Task<FilterReportViewModel> GetFilterReport(FilterReportViewModel model)
    {
        var list =  _blogContext.ReportContents.Include(a=>a.Content).AsQueryable();
        await model.Paging(list.Select(a => new ReportViewModel()
        {
            Id = a.id,
            ReportText = a.ReportText,
            Title = a.Content.Title,
            contentId = a.ContentId
        }));
        return model;
    }
    public async Task SaveAsync()
    {
        await _blogContext.SaveChangesAsync();
    }
}