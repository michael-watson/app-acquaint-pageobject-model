using System.Linq;

using Xamarin.UITest;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Acquaint.UITest.Pages
{
	public class AcquaintanceDetailPage : BasePage
	{
		//These variables will be identified separately per platform into the contructor above
		Query CancelDialogButton, DeleteDialogButton;

		Query EditUserButton = x => x.Marked("EditUserButton");
		Query DeleteUserButton = x => x.Marked("DeleteUserButton");
		Query BeginNavigationButton = x => x.Marked("BeginNavigationButton");
		Query SendTextMessageButton = x => x.Marked("SendTextMessageButton");
		Query MakePhoneCallButton = x => x.Marked("MakePhoneCallButton");
		Query SendEmailButton = x => x.Marked("SendEmailButton");
		Query PhoneNumber = x => x.Marked("PhoneNumber");
		Query StreetEntry = x => x.Marked("StreetEntry");
		Query CityEntry = x => x.Marked("CityEntry");
		Query StatePostalEntry = x => x.Marked("StatePostalEntry");

		public AcquaintanceDetailPage(IApp app, Platform platform) : base(app, platform)
		{
			if (OnAndroid)
			{
				CancelDialogButton = x => x.Marked("button2");
				DeleteDialogButton = x => x.Marked("button1");
			}
			else if (OniOS)
			{
				CancelDialogButton = x => x.Class("UILabel").Text("Cancel");
				DeleteDialogButton = x => x.Class("UILabel").Text("Delete");
			}
		}

		/// <summary>
		/// Deletes the user.
		/// </summary>
		public void DeleteUser()
		{
			app.Tap(DeleteUserButton);
			app.Screenshot("Delete User Dialog Displayed");
			app.Tap(DeleteDialogButton);
			app.Screenshot("Deleted User");
		}
		/// <summary>
		/// Edits the user.
		/// </summary>
		public void EditUser()
		{
			app.Tap(EditUserButton);
			app.Screenshot("Edit user");
		}
		/// <summary>
		/// Begins the navigation. Should sent intent to native maps navigation.
		/// </summary>
		public void BeginNavigation()
		{
			app.Tap(BeginNavigationButton);
		}
		/// <summary>
		/// Opens native messanger to send a text to the phone number.
		/// </summary>
		public void SendTextMessage()
		{
			app.Tap(SendTextMessageButton);
		}
		/// <summary>
		/// Opens native phone to make a phone call to the phone number.
		/// </summary>
		public void MakePhoneCall()
		{
			app.Tap(MakePhoneCallButton);
		}
		/// <summary>
		/// Opens native email to send email to the displayed email address.
		/// </summary>
		public void SendEmail()
		{
			app.Tap(SendEmailButton);
		}
		/// <summary>
		/// Gets the phone number.
		/// </summary>
		/// <returns>The phone number.</returns>
		public string GetPhoneNumber()
		{
			return app.Query(PhoneNumber).First().Text;
		}
		/// <summary>
		/// Gets the street.
		/// </summary>
		/// <returns>The street.</returns>
		public string GetStreet()
		{
			return app.Query(StreetEntry).First().Text;
		}
		/// <summary>
		/// Gets the city.
		/// </summary>
		/// <returns>The city.</returns>
		public string GetCity()
		{
			return app.Query(CityEntry).First().Text;
		}
		/// <summary>
		/// Gets the state and postal zip code as one string. You can split this by new char[]{' '}, state will be at index 0 and zip code will be at index 1
		/// </summary>
		/// <returns>The state postal.</returns>
		public string GetStatePostal()
		{
			return app.Query(StatePostalEntry).First().Text;
		}
	}
}