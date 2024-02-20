using Domain.Models;

namespace Domain.IRepositories;

public interface IMessageRepository
{
    public  Task AddMessage(Message message);
    public Task EditMessage(Message message);
    public Task<Message> GetMessageById(int id);
}