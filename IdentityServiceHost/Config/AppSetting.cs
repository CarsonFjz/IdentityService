using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace IdentityServiceHost.Config
{
    public static class AppSetting
    {
        public static string AppSettingValue([CallerMemberName]string key = null)
        {
            //開發期間json值可能改變,做成這樣方便熱更
            var builder = new ConfigurationBuilder().AddJsonFile("url.json");

            var conf = builder.Build();

            return conf[key];
        }

        public static string IndentityServiceHostUrl
        {
            get
            {
                return AppSettingValue();
            }
        }

        public static string HybridClient
        {
            get
            {
                return AppSettingValue();
            }
        }
        public static string ImplicitClient
        {
            get
            {
                return AppSettingValue();
            }
        }
        public static string JsClient
        {
            get
            {
                return AppSettingValue();
            }
        }
        public static string AuthorizationCodeClient
        {
            get
            {
                return AppSettingValue();
            }
        }
        public static string ClientCredentialsClient
        {
            get
            {
                return AppSettingValue();
            }
        }
    }
}

