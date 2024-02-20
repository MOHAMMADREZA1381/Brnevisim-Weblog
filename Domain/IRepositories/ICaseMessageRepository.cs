using Domain.Models;

namespace Domain.IRepositories;

public interface ICaseMessageRepository
{
    public Task<CaseMessage> CreateCaseMessage(CaseMessage caseMessage);
    public Task EditCaseMessage(CaseMessage caseMessage);
    public Task<CaseMessage> GetCaseMessage(int id);
    public Task<bool> IsCreatedBefor(int id);
}