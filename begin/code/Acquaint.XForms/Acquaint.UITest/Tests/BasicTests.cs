using NUnit.Framework;

using Xamarin.UITest;

namespace Acquaint.UITest
{
	public class BasicTests : AbstractSetup
	{
		public BasicTests(Platform platform)
			: base(platform)
		{
		}

		public override void BeforeEachTest()
		{
			base.BeforeEachTest();
		}

		[Test]
		public void Repl()
		{
			app.Repl();
		}
	}
}