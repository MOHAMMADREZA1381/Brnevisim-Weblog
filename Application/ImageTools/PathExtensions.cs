namespace Application.ImageTools
{
    public static class PathExtensions
    {
        #region Avatar
        public static string UserAvatarOrgin= "/images/userAvatar/origin/";
        public static string UserAvatarOrginServer=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/userAvatar/origin/");
        public static string UserAvatarThumb = "/images/userAvatar/thumb/";
        public static string UserAvatarThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/userAvatar/thumb/");
        #endregion

       
    }
}
