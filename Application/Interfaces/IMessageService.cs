using Domain.ViewModels.Message;

namespace Application.Interfaces;

public interface IMessageService
{
    public Task AddMessage(MessageViewModel message);
    public Task EditMessage(MessageViewModel message);
    public Task DeleteMessage(int id);
    public Task<bool> CreatedBefor(int id);
    public Task<bool> MessageBlongToUser(int UserId,int MessageId);
}