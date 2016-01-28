using System;
using Windows.Foundation;
using Windows.Storage;

namespace ZhihuDaily.ApiLib
{
    public class CachedAttribute : Attribute
    {
        public IAsyncOperation<StorageFolder> ImgCacheFolder
            =>
                ApplicationData.Current.LocalFolder.CreateFolderAsync("image_cache",
                    CreationCollisionOption.OpenIfExists);

        public IAsyncOperation<StorageFolder> DataCacheFolder
            =>
                ApplicationData.Current.LocalFolder.CreateFolderAsync("data_cache",
                    CreationCollisionOption.OpenIfExists);

        public CachedAttribute(string fileName)
        {
            throw new NotImplementedException();
        }
    }

    public enum CacheType
    {
        Image=0,
        Data=1
    }
}
