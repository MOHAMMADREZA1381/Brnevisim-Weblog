using System.Security.Claims;
using Application.Interfaces;
using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.Message;

namespace Application.Services;

public class MessageService : IMessageService
{
    #region Service
    private readonly IMessageRepository _messageRepository;
    private readonly ICaseMessageRepository _caseMessageRepository;
    private readonly IContentService _contentService;
    public MessageService(IMessageRepository messageRepository, ICaseMessageRepository caseMessageRepository, IContentService contentService)
    {
        _messageRepository = messageRepository;
        _caseMessageRepository = caseMessageRepository;
        _contentService = contentService;
    }
    #endregion
    public async Task AddMessage(MessageViewModel message)
    {
        bool isContentCreated = await _contentService.IsAnyContent(message.ContentId);
        if (isContentCreated == true)
        {
            ///Check is there any case before?
            /// true=> create a new case
            bool CreatedBefor = await _caseMessageRepository.IsCreatedBefor(message.CaseId);
            var AddCaseMessage = new CaseMessage();
            if (CreatedBefor == false)
            {
                AddCaseMessage.ContentId = message.ContentId;
                AddCaseMessage.UserId = message.UserId;
                AddCaseMessage.CreateDate = DateTime.Now;
                AddCaseMessage = await _caseMessageRepository.CreateCaseMessage(AddCaseMessage);
                await _caseMessageRepository.SaveAsync();
                message.IsFirstMessage = true;
                message.CaseId = AddCaseMessage.Id;
            }
            var MessageModel = new Message()
            {
                ContentId = message.ContentId,
                CaseId = message.CaseId,
                CreateTime = DateTime.Now,
                Text = message.text,
                UserId = message.UserId,
                IsFirstMesage = message.IsFirstMessage,
            };
            await _messageRepository.AddMessage(MessageModel);
            await _messageRepository.SaveAsync();
        }
    }

    public async Task EditMessage(MessageViewModel message)
    {
        var Message = await _messageRepository.GetMessageById(message.id);
        message.CaseId = Message.CaseId;
        Message.Text = message.text;
        await _messageRepository.EditMessage(Message);
        await _messageRepository.SaveAsync();

    }

    public async Task DeleteMessage(int id)
    {
        var Message = await _messageRepository.GetMessageById(id);
        if (Message.IsFirstMesage == true)
        {
            var Case = await _caseMessageRepository.GetCaseMessage(Message.CaseId);
            Case.IsDelete = true;
           await _caseMessageRepository.EditCaseMessage(Case);
           
        }

        Message.IsDelete = true;
        await _messageRepository.EditMessage(Message);
        await _caseMessageRepository.SaveAsync();
    }

    public async Task<bool> CreatedBefor(int id)
    {
        bool IsCreated = await _messageRepository.CreatedMessageBefor(id);
        return IsCreated;
    }

    public async Task<bool> MessageBlongToUser(int UserId,int MessageId)
    {
        var Message = await _messageRepository.GetMessageById(MessageId); 
        bool MessageBlongToUser=Message.UserId==UserId;
        return MessageBlongToUser;
    }

    public async Task<int> messageCount()
    {
        return await _messageRepository.MessageCount();
    }
}