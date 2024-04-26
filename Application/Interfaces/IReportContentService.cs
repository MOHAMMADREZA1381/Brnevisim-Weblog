using Domain.Models;
using Domain.ViewModels.Report;

namespace Application.Interfaces;

public interface IReportContentService
{
     Task AddReport(AddReportViewModel content);
     Task RemoveReport(int id);
     Task<ReportContent> GetReport(int id);
     Task<FilterReportViewModel> GetLisTask(FilterReportViewModel viewModel);
}