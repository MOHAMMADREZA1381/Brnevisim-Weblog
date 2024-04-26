using Domain.Models;
using Domain.ViewModels.Message;

namespace Application.Interfaces;

public interface ICaseMessageService
{
     Task<CaseMessageViewModel> CreateCaseMessage(CaseMessageViewModel caseMessage);
     Task EditCaseMessage(CaseMessageViewModel caseMessage);
     Task<CaseMessageViewModel> GetCaseMessage(int id);
     Task<bool> IsCreatedBefor(int id);
}