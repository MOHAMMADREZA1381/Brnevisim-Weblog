using Domain.Models;
using Domain.ViewModels.Message;

namespace Application.Interfaces;

public interface ICaseMessageService
{
    public Task<CaseMessageViewModel> CreateCaseMessage(CaseMessageViewModel caseMessage);
    public Task EditCaseMessage(CaseMessageViewModel caseMessage);
    public Task<CaseMessageViewModel> GetCaseMessage(int id);
    public Task<bool> IsCreatedBefor(int id);
}