using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace ZhihuDaily.ApiLib
{
    public class NetworkManager
    {
        private static NetworkManager _current;
        public static NetworkManager Current => _current ?? (_current = new NetworkManager());

        public string NetworkTitle
        {
            get
            {
                switch (_network)
                {
                    case 0:
                        return "2G";
                    case 1:
                        return "3G";
                    case 2:
                        return "4G";
                    case 3:
                        return "WIFI";
                    default:
                        return "无网络访问";
                }
            }
        }

        private int _network;

        public int Network => _network;

        public event NetworkStatusChangedEventHandler NetworkStatusChanged;

        public NetworkManager()
        {
            NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged;
            _network = GetConnectionGeneration();
        }

        private void NetworkInformation_NetworkStatusChanged(object sender)
        {
            _network = GetConnectionGeneration();
            NetworkStatusChanged?.Invoke(this);
        }

        /// <summary>
        ///  0:2G 1:3G 2:4G  3:wifi  4:无连接
        /// </summary>
        /// <returns></returns>
        private int GetConnectionGeneration()
        {
            try
            {
                ConnectionProfile profile = NetworkInformation.GetInternetConnectionProfile();
                if (profile.IsWwanConnectionProfile)
                {
                    WwanDataClass connectionClass = profile.WwanConnectionProfileDetails.GetCurrentDataClass();
                    switch (connectionClass)
                    {
                        //2G-equivalent
                        case WwanDataClass.Edge:
                        case WwanDataClass.Gprs:
                            return 0;
                        //3G-equivalent
                        case WwanDataClass.Cdma1xEvdo:
                        case WwanDataClass.Cdma1xEvdoRevA:
                        case WwanDataClass.Cdma1xEvdoRevB:
                        case WwanDataClass.Cdma1xEvdv:
                        case WwanDataClass.Cdma1xRtt:
                        case WwanDataClass.Cdma3xRtt:
                        case WwanDataClass.CdmaUmb:
                        case WwanDataClass.Umts:
                        case WwanDataClass.Hsdpa:
                        case WwanDataClass.Hsupa:
                            return 1;
                        //4G-equivalent
                        case WwanDataClass.LteAdvanced:
                            return 2;

                        //not connected
                        case WwanDataClass.None:
                            return 4;

                        //unknown
                        case WwanDataClass.Custom:
                        default:
                            return 4;
                    }
                }
                else if (profile.IsWlanConnectionProfile)
                {
                    return 3;
                }
                return 4;
            }
            catch (Exception)
            {
                return 4; //as default
            }
        }
    }
}
