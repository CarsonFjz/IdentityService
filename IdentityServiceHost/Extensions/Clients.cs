using IdentityServer4;
using IdentityServer4.Models;
using IdentityServiceHost.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServiceHost.Extensions
{
    public static class Clients
    {
        private const string OidcLoginCallback = "/oidc/login-callback";
        private const string OidcFrontChannelLogoutCallback = "/oidc/front-channel-logout-callback";

        public static IEnumerable<Client> All => new[]
        {
            HybridClient,
            ImplicitClient,
            JsClient,
            AuthorizationCodeClient,
            ClientCredentialsClient
        };

        private static Client ImplicitClient
        {
            get
            {
                string home = AppSetting.ImplicitClient;


                return new Client
                {
                    ClientId = "implicit-client",
                    ClientName = "Implicit Client",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    RequireConsent = false,

                    RedirectUris = { home + OidcLoginCallback },
                    PostLogoutRedirectUris = { home },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email
                    },

                    FrontChannelLogoutUri = home + OidcFrontChannelLogoutCallback,
                    FrontChannelLogoutSessionRequired = true
                };
            }
        }

        private static Client HybridClient
        {
            get
            {
                string home = AppSetting.HybridClient;

                return new Client
                {
                    ClientId = "hybrid-client",
                    ClientName = "Hybrid Client",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("lnh".Sha256())
                    },

                    RequireConsent = false,

                    RedirectUris = { home + OidcLoginCallback },
                    PostLogoutRedirectUris = { home },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email
                    },

                    FrontChannelLogoutUri = home + OidcFrontChannelLogoutCallback,
                    FrontChannelLogoutSessionRequired = true
                };
            }
        }

        private static Client JsClient
        {
            get
            {
                string host = AppSetting.JsClient;

                return new Client
                {
                    ClientId = "js-client",
                    ClientName = "JS Client",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    RedirectUris =
                    {
                        $"{host}/oidc/login-callback.html",
                        $"{host}/oidc/refresh-token.html"
                    },
                    PostLogoutRedirectUris = { $"{host}/index.html" },

                    AllowedCorsOrigins = { host },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "my-api"
                    },
                    AccessTokenLifetime = 3600,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                };
            }
        }

        private static Client AuthorizationCodeClient
        {
            get
            {
                string home = AppSetting.AuthorizationCodeClient;

                return new Client
                {
                    ClientId = "oidc-authorization-code-client",
                    ClientName = "Oidc Authorization Code Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("lnh".Sha256())
                    },

                    RequireConsent = false,
                    AllowRememberConsent = true,

                    RedirectUris = { home + OidcLoginCallback },
                    PostLogoutRedirectUris = { home },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email
                    },

                    FrontChannelLogoutUri = home + OidcFrontChannelLogoutCallback,
                    FrontChannelLogoutSessionRequired = true
                };
            }
        }


        private static Client ClientCredentialsClient => new Client
        {
            ClientId = "client-credentials-client",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = { new Secret("lnh".Sha256()) },
            AllowedScopes = { "my-api" }
        };
    }
}
