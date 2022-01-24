//   Copyright 2021-present Etherna Sagl
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

using Microsoft.Extensions.Logging;
using System;

namespace Etherna.ACR.Extensions
{
    /*
     * Always group similar log delegates by type, always use incremental event ids.
     * Last event id is: 0
     */
    public static class LoggerExtensions
    {
        // Fields.
        //*** ERROR LOGS ***
        private static readonly Action<ILogger, string, Exception> _requestError =
            LoggerMessage.Define<string>(
                LogLevel.Error,
                new EventId(0, nameof(RequestError)),
                "Request {RequestId} throwed error");

        // Methods.
        public static void RequestError(this ILogger logger, string requestId) =>
            _requestError(logger, requestId, null!);
    }
}
