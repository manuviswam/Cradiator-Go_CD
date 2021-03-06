using Cradiator.Config;
using Cradiator.Model;
using NUnit.Framework;
using Rhino.Mocks;

namespace Cradiator.Tests.Model
{
	[TestFixture]
	public class BuildBusterImageDecorator_Tests
	{
		BuildBusterImageDecorator _buildBusterDecorator;
		IBuildBuster _buildBuster;
		IAppLocation _appLocation;
		const string DirectoryName = @"c:\dummy\DirectoryName\file\system\is\not\used";

		[SetUp]
		public void SetUp()
		{
			_buildBuster = MockRepository.GenerateStub<IBuildBuster>();
			_appLocation = MockRepository.GenerateStub<IAppLocation>();

			// it is very important that we don't rely on (and therefore retest) the 'decorated' BuildBuster object
			// If we did, then that class failing would fail this test too (a classic case of fickle (and therefore bad) tests
			_buildBuster.Stub(b => b.FindBreaker(Arg<string>.Is.Anything)).Return("bob");
			_appLocation.Stub(a => a.DirectoryName).Return(DirectoryName);

			_buildBusterDecorator = new BuildBusterImageDecorator(_buildBuster, _appLocation);
		}

		[Test]
		public void CanDecorate_WithImageExtension()
		{
			// we want to test the decoration of the string 'bob' - nothing else
			var breaker = _buildBusterDecorator.FindBreaker("don't care - the internal BuildBuster is stubbed to return 'bob'");

			Assert.That(breaker, Is.EqualTo(DirectoryName + @"\images\bob.jpg"));
		}
	}
}