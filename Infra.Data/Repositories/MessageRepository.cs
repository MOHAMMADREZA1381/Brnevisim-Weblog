﻿using Domain.IRepositories;
using Domain.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

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
        
    }

    public async Task EditMessage(Message message)
    {
         _context.Update(message);
      
    }

    public async Task<Message> GetMessageById(int id)
    {
        var Message = _context.Messages.Where(a => a.Id == id).FirstOrDefault();
        return Message;
    }

    public async Task<bool> CreatedMessageBefor(int id)
    {
         bool isThere = _context.Messages.Any(a => a.Id == id);
         return isThere;
    }

    public async Task<int> MessageCount()
    {
           var Message= await _context.Messages.Where(a => a.IsDelete == false).ToListAsync();
           return Message.Count;
    }
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}