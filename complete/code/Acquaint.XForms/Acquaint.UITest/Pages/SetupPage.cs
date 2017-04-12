using System;

using Xamarin.UITest;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Acquaint.UITest.Pages
{
	public class SetupPage : BasePage
	{
		public SetupPage(IApp app, Platform platform) : base(app, platform)
		{
		}

		Query UniquePhraseEntry = x => x.Marked("UniquePhraseEntry");
		Query ContinuteButton = x => x.Marked("ContinuteButton");

		public void EnterUniquePhrase(string phrase)
		{
			app.WaitForElement(UniquePhraseEntry, "Timed out waiting for the setup page to appear", TimeSpan.FromSeconds(10));
			app.EnterText(UniquePhraseEntry, phrase);
			app.Tap(ContinuteButton);
		}
	}
}