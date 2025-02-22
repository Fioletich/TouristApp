﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace TouristApp.Web.Identity;

public class CustomAuthStateProvider(ProtectedLocalStorage localStorage) : AuthenticationStateProvider {

    public async override Task<AuthenticationState> GetAuthenticationStateAsync() {
        var token = (await localStorage.GetAsync<string>("authToken")).Value;
        
        var identity = string.IsNullOrEmpty(token) ? new ClaimsIdentity() : GetClaimsIdentity(token);
        
        var user = new ClaimsPrincipal(identity);
        
        return new AuthenticationState(user);
    }

    public async Task AuthUser(string token) {
        await localStorage.SetAsync("authToken", token);

        var identity = GetClaimsIdentity(token);
        var user = new ClaimsPrincipal(identity);
        
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    public ClaimsIdentity GetClaimsIdentity(string token) {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        var claims = jwtToken.Claims;
        
        return new ClaimsIdentity(claims, "jwt", "unique_name", "role");
    }

    public async Task LogoutUser() {
        await localStorage.DeleteAsync("authToken");
        
        var identity = new ClaimsIdentity();
        var user = new ClaimsPrincipal(identity);
        
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }
}