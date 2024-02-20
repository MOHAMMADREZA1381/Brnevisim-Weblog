using Domain.IRepositories;
using Domain.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class CaseMessageRepository:ICaseMessageRepository
{
    #region Context

    

    private readonly BlogContext _context;
    public CaseMessageRepository(BlogContext context)
    {
        _context = context;
    }
    #endregion

    public async Task<CaseMessage> CreateCaseMessage(CaseMessage caseMessage)
    {
        _context.Add(caseMessage);
        _context.SaveChanges();
        return caseMessage;
    }


    public async Task EditCaseMessage(CaseMessage caseMessage)
    {
        _context.Update(caseMessage);
        _context.SaveChanges();
    }

    public async Task<CaseMessage> GetCaseMessage(int id)
    {
        return _context.CaseMessages.Where(a => a.Id == id).FirstOrDefault();
    }

    public async Task<bool> IsCreatedBefor(int id)
    {
        return _context.CaseMessages.Any(a => a.Id == id);
    }
}