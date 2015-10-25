using System;
using System.Net;
using System.Text;

namespace Cradiator.Services
{
	public class HttpWebClient : IWebClient
	{
		readonly WebClient _webClient;

		public HttpWebClient()
		{
			_webClient = new WebClient();
		}

	    public HttpWebClient(string username, string password)
        {
            _webClient = new WebClient();
            const string userName = "go";
            const string passWord = "C0mplexPwd";
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + ":" + passWord));
            _webClient.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
	    }

	    public string DownloadString(Uri uri)
		{
			return _webClient.DownloadString(uri);
		}
	}
}