// Copyright 2021-present Etherna SA
// This file is part of Etherna ACR.
// 
// Etherna ACR is free software: you can redistribute it and/or modify it under the terms of the
// GNU Lesser General Public License as published by the Free Software Foundation,
// either version 3 of the License, or (at your option) any later version.
// 
// Etherna ACR is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License along with Etherna ACR.
// If not, see <https://www.gnu.org/licenses/>.

using Etherna.ACR.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Etherna.ACR
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEthernaServicesSharedLibrary(this IServiceCollection services)
        {
            // Register services.
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IRazorViewRenderer, RazorViewRenderer>();
        }
    }
}
