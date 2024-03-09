using Domain.Models;
using Domain.ViewModels.Message;

namespace Domain.IRepositories;

public interface IMessageRepository
{
    public  Task AddMessage(Message message);
    public Task EditMessage(Message message);
    public Task<Message> GetMessageById(int id);
    public Task<bool> CreatedMessageBefor(int id);
    public Task<int> MessageCount();

}