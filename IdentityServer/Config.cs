﻿using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // Hybrid Flow
                //new Client
                //{
                //    ClientId = "movieClient",
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    AllowedScopes = { "movieAPI" }
                //},
                new Client
                {
                    ClientId = "movies_mvc_client",
                    ClientName = "Movies MVC Web App",
                    //AllowedGrantTypes = GrantTypes.Code,
                    // Hybrid Flow - 2 lines more
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RequirePkce = false,
                    AllowRememberConsent = false,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:5002/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:5002/signout-callback-oidc"
                    },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile, "movieAPI",
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Email,
                        "roles"      
                    }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
           new ApiScope[]
           {
               new ApiScope("movieAPI", "Movie API")
           };

        public static IEnumerable<ApiResource> ApiResources =>
           new ApiResource[]
           {
           };

        public static IEnumerable<IdentityResource> IdentityResources =>
          new IdentityResource[]
          {
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
              new IdentityResources.Address(),
              new IdentityResources.Email(),
              new IdentityResource(
                  "roles",
                  "Your role(s)",
                  new List<string>() { "role" })
          };

        public static List<TestUser> TestUsers =>
        new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "70A4DF29-17CB-4250-B480-C1ED75F84CE9",
                Username = "lafouine",
                Password = "lafouine",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.GivenName, "lafouine"),
                    new Claim(JwtClaimTypes.FamilyName, "lechat")
                }
            }
        };
    }
}