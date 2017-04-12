using NUnit.Framework;

using Xamarin.UITest;

using Acquaint.UITest.Pages;
using System;

namespace Acquaint.UITest
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public abstract class AbstractSetup
	{
		protected IApp app;
		protected Platform platform;

		protected AbstractSetup(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public virtual void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App Start");

			//new SetupPage(app, platform).EnterUniquePhrase("xambrew");
			new SetupPage(app, platform).EnterUniquePhrase("UseLocalDataSource");
		}
	}
}