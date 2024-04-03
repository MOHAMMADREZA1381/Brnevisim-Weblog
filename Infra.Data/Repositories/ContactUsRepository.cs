using Domain.IRepositories;
using Domain.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Infra.Data.Repositories;

public class ContactUsRepository:IContactUsRepository
{
    #region Context

    private readonly BlogContext _context;
    public ContactUsRepository(BlogContext context)
    {
        _context = context;
    }
    #endregion


    public async Task AddContactUs(ContactUs contactUs)
    {
        _context.Add(contactUs);
        
    }

    public async Task<ContactUs> GetContactUsById(int id)
    {
        var Contact =_context.ContactUs.Where(a => a.Id == id).FirstOrDefault();
        return Contact;

    }

    public async Task DeleteContactUs(ContactUs contactUs)
    {
        _context.Update(contactUs);
       
    }

    public async Task<ICollection<ContactUs>> GetAll()
    {
        return await _context.ContactUs.Where(a => a.IsDelete == false).ToListAsync();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}