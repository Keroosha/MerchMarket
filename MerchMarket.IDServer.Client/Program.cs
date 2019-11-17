using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace MerchMarket.IDServer.Client
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var client = new HttpClient();
      var discovery = await client.GetDiscoveryDocumentAsync("http://localhost:5000");
      if (discovery.IsError)
      {
        Console.WriteLine("Nahooi di");
        return;
      }

      var token = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
      {
        Address = discovery.TokenEndpoint,
        ClientId = "MerchClient",
        ClientSecret = "secret",
        Scope = "MerchMarket"
      });

      if (token.IsError)
      {
        Console.WriteLine("Nahooi di");
        return;
      }
      
      Console.WriteLine(token.Json);
    }
  }
}