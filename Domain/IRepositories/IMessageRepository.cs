using Domain.Models;
using Domain.ViewModels.Message;

namespace Domain.IRepositories;

public interface IMessageRepository
{
      Task AddMessage(Message message);
     Task EditMessage(Message message);
     Task<Message> GetMessageById(int id);
     Task<bool> CreatedMessageBefor(int id);
     Task<int> MessageCount();
     Task SaveAsync();

}