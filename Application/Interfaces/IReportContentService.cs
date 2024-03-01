using Domain.Models;
using Domain.ViewModels.Report;

namespace Application.Interfaces;

public interface IReportContentService
{
    public Task AddReport(AddReportViewModel content);
    public Task RemoveReport(int id);
    public Task<ReportContent> GetReport(int id);
    public Task<FilterReportViewModel> GetLisTask(FilterReportViewModel viewModel);
}