using Microsoft.AspNetCore.Components.Authorization;

using System.Security.Claims;


namespace Turismos.Web.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimous = new ClaimsIdentity();
            var oapUser = new ClaimsIdentity(new List<Claim>
    {
        new Claim("FirstName", "Orlando"),
        new Claim("LastName", "Oap"),
        new Claim(ClaimTypes.Name, "oap@yopmail.com"),
        new Claim(ClaimTypes.Role, "Admin")
    },
    authenticationType: "test");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(oapUser)));
        }

    }
}

