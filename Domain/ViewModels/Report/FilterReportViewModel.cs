using Domain.ViewModels.Paging.Pagination;

namespace Domain.ViewModels.Report;

public class FilterReportViewModel:Pagination<ReportViewModel>
{
    public int page { get; set; }  
}