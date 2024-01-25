namespace Application.ImageTools
{
    public static class PathExtensions
    {
        #region BodyBlogImages

        public static string UserAvatarOrgin= "/images/blog/origin/";
        public static string UserAvatarOrginServer=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/userAvatar/origin/");

        public static string UserAvatarThumb = "/images/blog/thumb/";
        public static string UserAvatarThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/userAvatar/thumb/");

        #endregion

       
    }
}
