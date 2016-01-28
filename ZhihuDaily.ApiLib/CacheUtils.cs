using System;
using System.Reflection;
using Windows.Foundation;
using Windows.Storage;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace ZhihuDaily.ApiLib
{
    public class CachedAttribute : Attribute,IOnMethodBoundaryAspect
    {
        private string _fileName;
        private CacheType _cacheType;
        public IAsyncOperation<StorageFolder> ImgCacheFolder
            =>
                ApplicationData.Current.LocalFolder.CreateFolderAsync("image_cache",
                    CreationCollisionOption.OpenIfExists);

        public IAsyncOperation<StorageFolder> DataCacheFolder
            =>
                ApplicationData.Current.LocalFolder.CreateFolderAsync("data_cache",
                    CreationCollisionOption.OpenIfExists);

        public CachedAttribute(string fileName, CacheType cacheType)
        {
            this._fileName = fileName;
            this._cacheType = cacheType;
        }

        public void RuntimeInitialize(MethodBase method)
        {
            throw new NotImplementedException();
        }

        public void OnEntry(MethodExecutionArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnExit(MethodExecutionArgs args)
        {
            if (args.ReturnValue == null)
            {
                if (NetworkManager.Current.Network == 4) //无网络
                {
                    switch (_cacheType)
                    {
                        case CacheType.Image:
                            break;
                        case CacheType.Data:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        public void OnSuccess(MethodExecutionArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnException(MethodExecutionArgs args)
        {
            throw new NotImplementedException();
        }
    }

    public enum CacheType
    {
        Image = 0,
        Data = 1
    }
}
