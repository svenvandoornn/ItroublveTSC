using System;
using System.Net;

namespace StealerExt
{
    /// <summary>
    /// This wasn't made by me. Google ExtendedWebClient and you'll find it (somewhere on github)
    /// </summary>
    public class ExtendedWebClient : WebClient
    {
        public int Timeout { get; set; }
        public new bool AllowWriteStreamBuffering { get; set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (request != null)
            {
                request.Timeout = Timeout;
                if (request is HttpWebRequest httpRequest)
                {
                    httpRequest.AllowWriteStreamBuffering = AllowWriteStreamBuffering;
                }
            }
            return request;
        }

        public ExtendedWebClient()
        {
            Timeout = int.MaxValue;
        }
    }
}
