using Domain.IRepositories;
using Domain.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class UseFulLinksRepository:IUseFulLinksRepository
{
    #region Context
    private readonly BlogContext _blogContext;

    public UseFulLinksRepository(BlogContext blogContext)
    {
        _blogContext = blogContext;
    }

    #endregion
    public async Task AddLink(UseFulLink link)
    {
        await _blogContext.AddAsync(link);
    }

    public async Task Delete(int id)
    {
        var Links = await Get(id);
        _blogContext.Remove(Links);
        
    }

    public async Task<UseFulLink> Get(int id)
    {
        var link = await _blogContext.UseFulLinks.Where(a => a.id == id).FirstOrDefaultAsync();
        return link;
    }

    public async Task<ICollection<UseFulLink>> GetLinks()
    {
        return await _blogContext.UseFulLinks.ToListAsync();
    }

    public async Task<ICollection<UseFulLink>> GetFooterLinks()
    {
        return await _blogContext.UseFulLinks.Where(a => a.Footer == true).ToListAsync();
    }
    public async Task SaveAsync()
    {
        await _blogContext.SaveChangesAsync();
    }
    public async Task<ICollection<UseFulLink>> GetHeaderLinks()
    {
        return await _blogContext.UseFulLinks.Where(a => a.Footer == false).ToListAsync();

    }
}