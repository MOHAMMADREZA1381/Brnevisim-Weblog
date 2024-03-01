using Domain.Models;
using Domain.ViewModels.Report;

namespace Domain.IRepositories;

public interface IReportRepository
{
    public Task AddReport(ReportContent content);
    public Task RemoveReport(ReportContent content);
    public Task<ReportContent> GetReport(int id);
    public Task<FilterReportViewModel> GetFilterReport(FilterReportViewModel model);
}