using Domain.Models;
using Domain.ViewModels.Report;

namespace Domain.IRepositories;

public interface IReportRepository
{
     Task AddReport(ReportContent content);
     Task RemoveReport(ReportContent content);
     Task<ReportContent> GetReport(int id);
     Task<FilterReportViewModel> GetFilterReport(FilterReportViewModel model);
     Task SaveAsync();

}