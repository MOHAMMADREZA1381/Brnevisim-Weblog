using Domain.IRepositories;
using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories;

public class MessageRepository:IMessageRepository
{
    private readonly BlogContext _context;
    private readonly ICaseMessageRepository _case;
    public MessageRepository(BlogContext context, ICaseMessageRepository caseMessage)
    {
        _context = context;
        _case = caseMessage;
    }


    public async Task AddMessage(Message message)
    {

        await _context.AddAsync(message); 
        await _context.SaveChangesAsync();
    }

    public async Task EditMessage(Message message)
    {
         _context.Update(message);
       await _context.SaveChangesAsync();
    }

    public async Task<Message> GetMessageById(int id)
    {
        var Message = _context.Messages.Where(a => a.Id == id).FirstOrDefault();
        return Message;
    }
}