using Domain.ViewModels.Message;

namespace Application.Interfaces;

public interface IMessageService
{
     Task AddMessage(MessageViewModel message);
     Task EditMessage(MessageViewModel message);
     Task DeleteMessage(int id);
     Task<bool> CreatedBefor(int id);
     Task<bool> MessageBlongToUser(int UserId,int MessageId);
     Task<int> messageCount();
}