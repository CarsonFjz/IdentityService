using IdentityServiceHost.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServiceHost.Extensions
{
    public static class IdentityServerBuilderExtensions
    {
        /// <summary>
        /// Adds test users.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddUsers(this IIdentityServerBuilder builder, List<UserBase> users)
        {
            builder.Services.AddSingleton(new UserStore(users));
            builder.AddProfileService<UserProfileService>();
            builder.AddResourceOwnerValidator<UserResourceOwnerPasswordValidator>();

            return builder;
        }
    }
}
