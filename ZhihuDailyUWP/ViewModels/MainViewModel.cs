using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;
using ZhihuDaily.ApiLib;
using ZhihuDailyUwp.Common;

namespace ZhihuDailyUwp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public string Title => "MyFirstApp";
        public List<Scenario> Scenarios { get; }
        public bool IsLoggedIn { get; set; }

        public MainViewModel()
        {
            Scenarios = new List<Scenario>
                {
                    new Scenario() {Title = "首页",ClassType = typeof(Scenario1_Home),IconSymbol = Symbol.Home},
                    //new Scenario() {Title = "发现",ClassType = typeof(Scenario2_Discover),IconSymbol = Symbol.View},
                    //new Scenario() {Title = "关注",ClassType = typeof(Scenario3_Follow),IconSymbol = Symbol.People},
                    //new Scenario() {Title = "收藏",ClassType = typeof(Scenario4_Favorite),IconSymbol = Symbol.Favorite},
                    //new Scenario() {Title = "草稿",ClassType = typeof(Scenario5_Draft),IconSymbol = Symbol.Edit},
                    //new Scenario() {Title = "提问",ClassType = typeof(Scenario6_AddStory),IconSymbol = Symbol.Add},
                    //new Scenario() {Title = "设置",ClassType = typeof(Scenario7_Settings),IconSymbol = Symbol.Repair},
                };
            IsLoggedIn = false;
            ZhihuDailyWebClient client = new ZhihuDailyWebClient();
            client.Login();
        }
    }
}
