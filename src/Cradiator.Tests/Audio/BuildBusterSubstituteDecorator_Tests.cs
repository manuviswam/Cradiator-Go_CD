using System.Collections.Generic;
using Cradiator.Config;
using Cradiator.Model;
using NUnit.Framework;
using Rhino.Mocks;

namespace Cradiator.Tests.Audio
{
	[TestFixture]
	public class BuildBusterSubstituteDecorator_Tests
	{
		BuildBusterFullNameDecorator _buildBusterDecorator;
		IBuildBuster _buildBuster;

		[SetUp]
		public void SetUp()
		{
			_buildBuster = MockRepository.GenerateStub<IBuildBuster>();

			_buildBusterDecorator =
				new BuildBusterFullNameDecorator(_buildBuster, new ConfigSettings
				{
					UsernameMap = new Dictionary<string, string>
				    {
						{"jbloggs", "Joe Bloggs"},
						{"am", "Ace McAwesome"}
				    }
				                                                 }
				);
		}

		[Test]
		public void CanSubstitute_Username_1stEntry()
		{
			_buildBuster.Stub(b => b.FindBreaker(Arg<string>.Is.Anything)).Return("jbloggs");

			var breaker = _buildBusterDecorator.FindBreaker("ignored");

			Assert.That(breaker, Is.EqualTo("Joe Bloggs"));
		}

		[Test]
		public void CanSubstitute_Username_2ndEntry()
		{
			_buildBuster.Stub(b => b.FindBreaker(Arg<string>.Is.Anything)).Return("am");

			var breaker = _buildBusterDecorator.FindBreaker("ignored");

			Assert.That(breaker, Is.EqualTo("Ace McAwesome"));
		}
	}
}