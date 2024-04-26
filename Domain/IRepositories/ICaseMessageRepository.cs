using Domain.Models;

namespace Domain.IRepositories;

public interface ICaseMessageRepository
{
     Task<CaseMessage> CreateCaseMessage(CaseMessage caseMessage);
     Task EditCaseMessage(CaseMessage caseMessage);
     Task<CaseMessage> GetCaseMessage(int id);
     Task<bool> IsCreatedBefor(int id);
     Task SaveAsync();
}