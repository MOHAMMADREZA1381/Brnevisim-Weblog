using Application.Interfaces;
using Domain.ViewModels.Report;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.AdminPanel.Controllers
{
  
    public class ReportController : BaseController
    {
        #region Service

        private readonly IReportContentService _contentService;

        public ReportController(IReportContentService contentService)
        {
            _contentService = contentService;
        }

        #endregion
        public async Task<IActionResult> Index(FilterReportViewModel model)
        {
            var ReportedList = await _contentService.GetLisTask(model);

            return View(ReportedList);
        }

        public async Task<IActionResult> remove(int id )
        {
             await _contentService.RemoveReport(id);

            return RedirectToAction("Index");
        }
    }
}
