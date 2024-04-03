using Application.Interfaces;
using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.Message;

namespace Application.Services;

public class CaseMessageService:ICaseMessageService
{
    #region Repository

    

    private readonly ICaseMessageRepository _caseMessage;
    public CaseMessageService(ICaseMessageRepository caseMessage)
    {
        _caseMessage = caseMessage;
    }
    #endregion

    public async Task<CaseMessageViewModel> CreateCaseMessage(CaseMessageViewModel caseMessage)
    {
        var Case = new CaseMessage()
        {
            ContentId = caseMessage.ContentId,
            UserId = caseMessage.UserId,
        };
        await _caseMessage.CreateCaseMessage(Case);
        await _caseMessage.SaveAsync();
        return caseMessage;
    }

    public Task EditCaseMessage(CaseMessageViewModel caseMessage)
    {
        throw new NotImplementedException();
    }

    public Task<CaseMessageViewModel> GetCaseMessage(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsCreatedBefor(int id)
    {
        throw new NotImplementedException();
    }
}