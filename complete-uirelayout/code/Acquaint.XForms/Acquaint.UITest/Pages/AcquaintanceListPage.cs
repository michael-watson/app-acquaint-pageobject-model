using System;
using System.Linq;
using System.Threading;

using Xamarin.UITest;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Acquaint.UITest.Pages
{
	public class AcquaintanceListPage : BasePage
	{
		//These variables will be identified separately per platform into the contructor above
		Query FirstUserInList, AddUserButton;

		Query SettingsGearIcon = x => x.Marked("SettingsGearIcon");
		Query UserListPage = x => x.Marked("UserListPage");
		Query RefreshIndicator = x => x.Class("ProgressBar");

		public AcquaintanceListPage(IApp app, Platform platform) : base(app, platform)
		{
			if (OnAndroid)
			{
				FirstUserInList = x => x.Class("ViewCellRenderer_ViewCellContainer").Index(0);
				AddUserButton = x => x.Marked("AddNewUserButton");
			}
			else if (OniOS)
			{
				FirstUserInList = x => x.Marked("UserViewCell").Index(0);
				//AddUserButton = x => x.Id("AddNewUserButton");
				AddUserButton = x => x.Class("UINavigationButton").Index(1);
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:Acquaint.UITest.Pages.AcquaintanceListPage"/> loading indicator
		/// is displayed.
		/// </summary>
		/// <value><c>true</c> if loading indicator is displayed; otherwise, <c>false</c>.</value>
		public bool LoadingIndicatorIsDisplayed
		{
			get
			{
				if (OnAndroid)
					return (bool)app.Query(x => x.Class("SwipeRefreshLayout").Invoke("isRefreshing")).First();
				else if (OniOS)
					return (bool)app.Query(x => x.Class("UIRefreshControl")).Any();

				throw new Exception();
			}
		}

		/// <summary>
		/// Waits for list refreshing indicator to disappear.
		/// </summary>
		public void WaitForIndicatorToDisappear()
		{
			WaitForPageNavigationToComplete();

			int counter = 0;
			while (LoadingIndicatorIsDisplayed)
			{
				Thread.Sleep(1000);
				counter++;

				if (counter == 10)
					throw new Exception("Took too long to re-load the list.");
			}
		}
		/// <summary>
		/// Verifies the on user list page.
		/// </summary>
		public void WaitForPageNavigationToComplete()
		{
			app.WaitForElement(AddUserButton, "Timed our waiting for the Acquantance List Page to appear. If adding a new user, it was not saved.", TimeSpan.FromSeconds(10));
			app.Screenshot("On User List Page");
		}
		/// <summary>
		/// Selects the first user in list.
		/// </summary>
		public void SelectFirstUserInList()
		{
			app.WaitForElement(FirstUserInList, "Timed our waiting for the first user to appear", TimeSpan.FromSeconds(30));
			app.Tap(FirstUserInList);
			Thread.Sleep(3000); // Give three seconds for map to load before screenshot is taken
			app.Screenshot("Selected first user in list");
		}
		/// <summary>
		/// Navigates to settings.
		/// </summary>
		public void NavigateToSettings()
		{
			app.WaitForElement(SettingsGearIcon, "Timed out waiting for the settings navigation icon", TimeSpan.FromSeconds(3));
			app.Tap(SettingsGearIcon);
			app.Screenshot("Selected first user in list");
		}
		/// <summary>
		/// Taps the on add new user.
		/// </summary>
		public void TapOnAddNewUser()
		{
			app.WaitForElement(AddUserButton, "Timed out waiting for the 'Add New User' button", TimeSpan.FromSeconds(10));
			app.Tap(AddUserButton);
			app.Screenshot("Add a new user to the database");
		}
	}
}