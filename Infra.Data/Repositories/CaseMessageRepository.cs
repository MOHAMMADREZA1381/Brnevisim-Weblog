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
       await _context.AddAsync(caseMessage);
       return caseMessage;
    }


    public async Task EditCaseMessage(CaseMessage caseMessage)
    {
        _context.Update(caseMessage);
       await _context.SaveChangesAsync();
    }

    public async Task<CaseMessage> GetCaseMessage(int id)
    {
        return await _context.CaseMessages.Where(a => a.Id == id).FirstOrDefaultAsync();
    }

    public async Task<bool> IsCreatedBefor(int id)
    {
        return await _context.CaseMessages.AnyAsync(a => a.Id == id);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}