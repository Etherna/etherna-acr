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
