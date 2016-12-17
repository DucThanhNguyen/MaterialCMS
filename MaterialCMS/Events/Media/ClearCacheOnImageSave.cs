using MaterialCMS.Entities.Documents.Media;
using MaterialCMS.Helpers;
using MaterialCMS.Website.Caching;

namespace MaterialCMS.Events.Media
{
    public class ClearCacheOnImageSave : IOnUpdated<MediaFile>
    {
        private readonly ICacheManager _cacheManager;

        public ClearCacheOnImageSave(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public void Execute(OnUpdatedArgs<MediaFile> args)
        {
            if (!args.Item.IsImage())
                return;

            if (!args.HasChanged(file => file.Title) && !args.HasChanged(file => file.Description))
                return;

            var prefix = string.Format("{0}{1}", MediaSettingExtensions.RenderImagePrefix, GetUrlWithoutExtension(args.Item.FileUrl));

            _cacheManager.Clear(prefix);
        }

        public string GetUrlWithoutExtension(string url)
        {
            return url.Substring(0, url.LastIndexOf("."));
        }
    }
}