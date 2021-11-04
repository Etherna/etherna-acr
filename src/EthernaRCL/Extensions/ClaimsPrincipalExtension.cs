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
    }
}
