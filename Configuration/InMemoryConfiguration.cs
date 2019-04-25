using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enigma.OAuth.Configuration
{
    public class InMemoryConfiguration
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[] {
                new ApiResource("Enigma", "Enigma Resource")
            };
        }


        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new IdentityResource[] {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new[] {
                new Client
                {
                    ClientId = "Enigma",
                    ClientSecrets = new [] { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new [] { "Enigma" }
                },

                new Client
                {
                    ClientId = "Enigma_code",
                    ClientSecrets = new [] { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowedScopes = new [] {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "Enigma"
                    },
                    AllowOfflineAccess = true,
                    AccessTokenLifetime = 60,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new [] { "http://localhost:28849/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:28849/signout-callback-oidc" },
                }
            };
        }

        public static IEnumerable<TestUser> Users()
        {
            return new[] {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "user@mail.com",
                    Password = "password"
                }
            };
        }
    }
}
