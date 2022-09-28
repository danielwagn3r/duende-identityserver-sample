using Duende.IdentityServer.Models;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new[]
        {
            new ApiScope("calc:double", "Calculate double"),
            new ApiScope("calc:square", "Calculate square")
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new[]
        {
            new ApiResource("http://calculator-api", "Calculator API")
            {
                Scopes = {"calc:double", "calc:square"}
            }
        };

    public static IEnumerable<Client> Clients =>
        new[]
        {
            new Client
            {
                ClientId = "WJZ8apZtVYl7Um5IhDiZyL4pf4Tvserf",
                ClientName = "Simple client",

                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                // secret for authentication
                ClientSecrets =
                {
                    new Secret("KfHj6AETs1hN9vs6TagMT-20CQd1xbkr-Csgbdc4ke_16Q8Gcqc3Gnxy5ebqYnD9".Sha256())
                },

                // scopes that client has access to
                AllowedScopes = {"calc:double"}
            },
            new Client
            {
                ClientId = "wqB2hYtfm2BVQ7GP07XPjO664uEKEthr",
                ClientName = "Advanced client",

                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                // secret for authentication
                ClientSecrets =
                {
                    new Secret("Lpj5AsJChxquoVitWJJLL_rpawjIZpHbSn8K4zP-vHUmDPNHE6jhIFo4WrZk5UbG".Sha256())
                },

                // scopes that client has access to
                AllowedScopes = {"calc:double", "calc:square"}
            },
            new Client
            {
                ClientId = "GiFWbUIwfGiHgoKa6F9ymXauPyQUxx7s",
                ClientName = "Device client",

                // use the clientid/secret and username/password for authentication
                AllowedGrantTypes = GrantTypes.DeviceFlow,

                // secret for authentication
                ClientSecrets =
                {
                    new Secret("4cmSGYADaAzY1pfqquBwg2sqxHLixAHuQm0FIlDRyXpRaU3eh8KD-VR9tK6HX-Ev".Sha256())
                },

                // scopes that client has access to
                AllowedScopes = {"calc:double", "calc:square", "openid", "email", "profile"}
            }
        };
}