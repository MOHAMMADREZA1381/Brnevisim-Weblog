using Application.Interfaces;
using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.Report;

namespace Application.Services;

public class ReportContentService:IReportContentService
{
    #region Repositories
    private readonly IReportRepository _repository;

    public ReportContentService(IReportRepository repository)
    {
        _repository = repository;
    }

    #endregion
    public async Task AddReport(AddReportViewModel content)
    {
        var Report = new ReportContent()
        {
            ContentId = content.ContentId,
            ReportText = content.ReportText,
        };
        await _repository.AddReport(Report);
    }

    public async Task RemoveReport(int id)
    {
        var Report =await GetReport(id);
        await _repository.RemoveReport(Report);
    }

    public async Task<ReportContent> GetReport(int id)
    {
          var Report=  await _repository.GetReport(id);
    
          return Report;
    }

    public async Task<FilterReportViewModel> GetLisTask(FilterReportViewModel viewModel)
    {
       return await _repository.GetFilterReport(viewModel);
    }
}