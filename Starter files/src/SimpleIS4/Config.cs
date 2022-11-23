// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace SimpleIS4
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResource(
                    "roles",
                    "Your role(s)",
                    new List<string>() {"role"}),
                new IdentityResource(
                    "country",
                    "The country you're living in",
                    new List<string> { "country" }),
                new IdentityResource(
                    "subscriptionlevel",
                    "Your subscription level",
                    new List<string> { "subscriptionlevel" })
            };

        public static IEnumerable<ApiScope> Apis =>
            new ApiScope[]
            {
                new ApiScope(
                    "imagegalleryapi",
                    "Image Gallery API")
            };

        public static IEnumerable<ApiResource> ApisResources =>
            new ApiResource[]
            {
                new ApiResource(
                    "imagegalleryapi",
                    "Image Gallery API",
                    new List<string> { "role"})
                    {
                        Scopes = new [] { "imagegalleryapi" }
                    }
            };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
                new Client
                {                    
                    AccessTokenLifetime = 120,
                    AllowOfflineAccess = true,
                    //RefreshTokenExpiration = TokenExpiration.Sliding,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    ClientName = "Image Gallery",
                    ClientId = "imagegalleryclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireConsent = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:5001/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:5001/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        "roles",
                        "imagegalleryapi",
                        "country",
                        "subscriptionlevel"
                    },
                    ClientSecrets=
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
    }
}