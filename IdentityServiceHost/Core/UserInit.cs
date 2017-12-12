using IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServiceHost.Core
{
    //初始化用戶
    public class UserInit
    {
        public static List<UserBase> All = new List<UserBase>
        {
            new UserBase
            {
                Username = "lnh",
                Password = "123",
                SubjectId = "000001",
                Claims = new[]
                {
                    new Claim(JwtClaimTypes.NickName, "blackheart")
                }
            },
            new UserBase
            {
                Username = "Carson",
                Password = "123",
                SubjectId = "000002",
                Claims = new[]
                {
                    new Claim(JwtClaimTypes.NickName, "blackheart")
                }
            }
        };
    }
}
