using Cradiator.Services;
using NUnit.Framework;

namespace Cradiator.Tests.Services
{
	[TestFixture]
	public class WebClientFactory_Tests
	{
		[Test]
		public void CanGet_SandboxWebClient()
		{
			var webClient = new WebClientFactory().GetWebClient("debughttp://cruise/ccnet", "dummy", "dummy");
			Assert.That(webClient, Is.TypeOf<SandboxWebClient>());
		}

		[Test]
		public void CanGet_HttpWebClient()
		{
            var webClient = new WebClientFactory().GetWebClient("http://cruise/ccnet", "dummy", "dummy");
			Assert.That(webClient, Is.TypeOf<HttpWebClient>());
		}

		[Test]
		public void WillIgnore_If_Url_IsEmpty()
		{
			var webClient = new WebClientFactory().GetWebClient("", "dummy", "dummy");
			Assert.That(webClient, Is.TypeOf<HttpWebClient>());
		}

		[Test]
		public void WillIgnore_If_Url_IsNull()
		{
			var webClient = new WebClientFactory().GetWebClient(null, "dummy", "dummy");
			Assert.That(webClient, Is.TypeOf<HttpWebClient>());
		}
	}
}