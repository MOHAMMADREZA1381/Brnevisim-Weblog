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

        #region ContentsBanner
        public static string ContentBannerOrgin = "/images/ContentBannerImages/origin/";
        public static string ContentBannerOrginServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/ContentBannerImages/origin/");
        public static string ContentBannerThumb = "/images/ContentBannerImages/thumb/";
        public static string ContentBannerThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/ContentBannerImages/thumb/");
        #endregion

        #region InsideImagesContent
        public static string ContentImgOrgin = "/images/ContentImages/origin/";
        public static string ContentImgOrginServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/ContentImages/origin/");
        public static string ContentImgThumb = "/images/ContentImages/thumb/";
        public static string ContentImgThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/ContentImages/thumb/");
        #endregion
    }
}
