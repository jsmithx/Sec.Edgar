using Microsoft.Extensions.Logging;
using Sec.Edgar.CikProviders;
using Sec.Edgar.Models.Edgar;
using Sec.Edgar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sec.Edgar.Providers
{
    internal class StreamProvider : BaseProvider
    {
        internal StreamProvider(ICikProvider cikProvider, ILogger? logger, CancellationToken ctx) : base(cikProvider, logger, ctx) { }

        internal async Task<Stream?> GetStream(Uri uri)
        {
            Logger?.LogInformation($"{GetLogPrefix}: Requested uri: {uri.OriginalString}, Uri: {uri.AbsoluteUri}");
            var response = await HttpClientWrapper.GetStreamAsync(uri, Ctx);
            return (response);
        }

        private static string GetLogPrefix([CallerMemberName] string caller = "") => $"{nameof(StreamProvider)}::{caller}";
    }
}
