using IdentityServer4.Configuration;
using IdentityServiceHost.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServiceHost.Extensions
{
    public static class IndentityExtensions
    {
        public static void AddIds4(this IServiceCollection services)
        {
            services
                .AddIdentityServer(SetIdentityServerOptions)
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(Resources.AllIdentityResources)
                .AddInMemoryApiResources(Resources.AllApiResources)
                .AddInMemoryClients(Clients.All)
                .AddUsers(UserInit.All);
        }

        private static void SetIdentityServerOptions(IdentityServerOptions options)
        {
            options.IssuerUri = "http://localhost:63613";
            options.UserInteraction = new UserInteractionOptions
            {
                LoginUrl = "/account/login",
                LoginReturnUrlParameter = "resumeUrl",
                LogoutUrl = "/account/logout",
                LogoutIdParameter = "logoutId",
                ErrorUrl = "/ids4/error",
                ErrorIdParameter = "errorId"
            };
        }


        public static void UseIds4(this IApplicationBuilder app)
        {
            app.UseIdentityServer();
        }
    }
}
