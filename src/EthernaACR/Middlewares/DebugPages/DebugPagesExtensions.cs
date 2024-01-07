// Copyright 2021-present Etherna Sa
// 
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
// 
//       http://www.apache.org/licenses/LICENSE-2.0
// 
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System;

namespace Etherna.ACR.Middlewares.DebugPages
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseEthernaAcrDebugPages(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            return app.UseMiddleware<DebugPagesMiddleware>();
        }

        public static IApplicationBuilder UseEthernaAcrDebugPages(
            this IApplicationBuilder app,
            DebugPagesOptions options)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));
            ArgumentNullException.ThrowIfNull(options, nameof(options));

            return app.UseMiddleware<DebugPagesMiddleware>(Options.Create(options));
        }
    }
}
