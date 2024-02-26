using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Bookmark
{
    public int id { get; set; }
    public int UserId { get; set; }
    public int  ContentId { get; set; }

    #region Relations
    [ForeignKey("UserId")]
    public User User { get; set; }
    [ForeignKey("ContentId")]
    public Content Content { get; set; }
    #endregion
}