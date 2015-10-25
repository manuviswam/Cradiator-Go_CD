using Cradiator.Model;
using log4net;

namespace Cradiator.Services
{
	public interface IWebClientFactory
	{
		IWebClient GetWebClient(string url, string username, string password);
	}

	public class WebClientFactory : IWebClientFactory
	{
		static readonly ILog _log = LogManager.GetLogger(typeof(WebClientFactory).Name);

		public IWebClient GetWebClient(string url, string username, string password)
		{
			IWebClient webClient;

			var cruiseAddress = new CruiseAddress(url);
			if (cruiseAddress.IsDebug)
			{
				webClient = new SandboxWebClient();
			}
			else
			{
				webClient = new HttpWebClient(username, password);
			}

			_log.InfoFormat("Using WebClient->[{0}]", webClient.GetType());
			return webClient;
		}
	}
}