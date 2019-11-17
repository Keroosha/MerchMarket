// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace MerchMarket.IDServer
{
  public static class IdServerConfig
  {
    public static IEnumerable<IdentityResource> Ids =>
      new IdentityResource[]
      {
        new IdentityResources.OpenId()
      };

    public static IEnumerable<ApiResource> Apis =>
      new ApiResource[]
      {
        new ApiResource("MerchMarket", "Merch market"), 
      };

    public static IEnumerable<Client> Clients =>
      new Client[]
      {
        new Client
        {
          ClientId = "MerchClient",
          AllowedGrantTypes = GrantTypes.ClientCredentials,
          ClientSecrets =
          {
            new Secret("secret".Sha256())
          },
          AllowedScopes = { "MerchMarket" }
        },
      };
  }
}