using System;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace Etherna.RCL.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetEtherAddress(this ClaimsPrincipal user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            var claim = user.Claims.First(claim => claim.Type == UserClaimTypes.EtherAddress);
            return claim.Value;
        }

        public static string[] GetEtherPrevAddresses(this ClaimsPrincipal user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            var claim = user.Claims.First(claim => claim.Type == UserClaimTypes.EtherPreviousAddresses);
            return JsonSerializer.Deserialize<string[]>(claim.Value) ?? Array.Empty<string>();
        }

        public static string GetUsername(this ClaimsPrincipal user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            var claim = user.Claims.First(claim => claim.Type == UserClaimTypes.Username);
            return claim.Value;
        }

        public static string? TryGetEtherAddress(this ClaimsPrincipal user)
        {
            if (user is null) return null;

            var claim = user.Claims.FirstOrDefault(claim => claim.Type == UserClaimTypes.EtherAddress);
            return claim?.Value;
        }

        public static string[]? TryGetEtherPrevAddresses(this ClaimsPrincipal user)
        {
            if (user is null) return null;

            var claim = user.Claims.FirstOrDefault(claim => claim.Type == UserClaimTypes.EtherPreviousAddresses);
            return claim is null ? null : JsonSerializer.Deserialize<string[]>(claim.Value);
        }

        public static string? TryGetUsername(this ClaimsPrincipal user)
        {
            if (user is null) return null;

            var claim = user.Claims.FirstOrDefault(claim => claim.Type == UserClaimTypes.Username);
            return claim?.Value;
        }
    }
}
