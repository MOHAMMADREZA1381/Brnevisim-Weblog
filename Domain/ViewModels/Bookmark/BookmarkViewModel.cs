
namespace Domain.ViewModels.Bookmark
{
    public class BookmarkViewModel
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public string ImageBanner { get; set; }
        public string Title { get; set; }
        public int  UserId { get; set; }
        public int ViewCount { get; set; }
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
