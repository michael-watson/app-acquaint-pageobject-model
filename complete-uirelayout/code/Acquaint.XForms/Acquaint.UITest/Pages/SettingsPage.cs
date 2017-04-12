using System;

using Xamarin.UITest;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Acquaint.UITest.Pages
{
	public class SettingsPage : BasePage
	{
		Query DoNoSaveButton, SaveButton;
		Query DataPartitionPhraseEntry = x => x.Marked("DataPartitionPhraseEntry");
		Query BackendUrlEntry = x => x.Marked("BackendUrlEntry");
		Query ImageCacheDurationEntry = x => x.Marked("ImageCacheDurationEntry");
		Query ClearCacheSwitchEntry = x => x.Marked("ClearCacheSwitchEntry");
		Query ResetToDefaultsSwitchEntry = x => x.Marked("ResetToDefaultsSwitchEntry");
		Query SettingsPageId = x => x.Marked("SettingsPageId");

		public SettingsPage(IApp app, Platform platform) : base(app, platform)
		{
			if (OnAndroid)
			{
				DoNoSaveButton = x => x.Marked("Cancel");
				SaveButton = x => x.Marked("Save");
			}
		}

		public void OnCurrentPage()
		{
			app.WaitForElement(SettingsPageId, "Timed out waiting for the page to appear. Was the settings page supposed to display?", TimeSpan.FromSeconds(3));
		}

		public void ChangeDataPartition(string partitionNameToEnter, bool takeScreenShot = true)
		{
			app.ClearText(DataPartitionPhraseEntry);
			app.EnterText(DataPartitionPhraseEntry, partitionNameToEnter);
			app.DismissKeyboard();

			if (takeScreenShot)
				app.Screenshot($"Changed Data Partition Phrase to {partitionNameToEnter}");
		}

		public void Save()
		{
			app.Tap(SaveButton);
			app.Screenshot("Save");
		}

		public void DoNotSave()
		{
			app.Tap(DoNoSaveButton);
			app.Screenshot("Don't save");
		}

		public void ChangeBackendUrl(string urlToEnter, bool takeScreenShot = true)
		{
			app.ClearText(BackendUrlEntry);
			app.EnterText(BackendUrlEntry, urlToEnter);
			app.DismissKeyboard();

			if (takeScreenShot)
				app.Screenshot($"Changed Backend URL to {urlToEnter}");
		}

		public void ChangeCacheDuration(string cacheDuration, bool takeScreenShot = true)
		{
			app.ClearText(BackendUrlEntry);
			app.EnterText(BackendUrlEntry, cacheDuration);
			app.DismissKeyboard();

			if (takeScreenShot)
				app.Screenshot($"Changed Image Cache Duration to {cacheDuration}");
		}

		public void ToggleClearImageCacheSwitch(bool takeScreenshot = false)
		{
			app.Tap(ClearCacheSwitchEntry);

			if (takeScreenshot)
				app.Screenshot("Toggled 'Clear image cache' switch");
		}

		public void ToggleResetToDefaultsSwitch(bool takeScreenshot = false)
		{
			app.Tap(ResetToDefaultsSwitchEntry);

			if (takeScreenshot)
				app.Screenshot("Toggled 'Reset to defaults' switch");
		}
	}
}
