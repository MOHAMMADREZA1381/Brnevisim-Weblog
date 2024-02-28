using Domain.IRepositories;
using Domain.Models;
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
        await _blogContext.SaveChangesAsync();
    }

    public async Task RemoveReport(ReportContent content)
    {
         _blogContext.Remove(content);
         await _blogContext.SaveChangesAsync();
    }

    public async Task<ReportContent> GetReport(int id)
    {
      return  await _blogContext.ReportContents.Where(a => a.id == id).Include(a=>a.Content).FirstOrDefaultAsync();
    }
}