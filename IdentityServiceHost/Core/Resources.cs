using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServiceHost.Core
{
    public static class Resources
    {
        public static IEnumerable<IdentityResource> AllIdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

        public static IEnumerable<ApiResource> AllApiResources => new List<ApiResource>
        {
            new ApiResource("my-api", "My API")
        };
    }
}
