using System;
using System.Linq;

using Xamarin.UITest;

using Acquaint.UITest.enums;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Acquaint.UITest.Pages
{
	public class AcquaintanceEditPage : BasePage
	{
		//These variables will be identified separately per platform into the contructor above
		Query FirstNameEntry, LastNameEntry, CompanyEntry, TitleEntry, PhoneEntry, EmailEntry, StreetEntry, CityEntry, StateEntry, ZipEntry, InvalidEntryDialog;

		Query SaveButton = x => x.Marked("SaveButton");

		public AcquaintanceEditPage(IApp app, Platform platform) : base(app, platform)
		{
			if (OnAndroid)
			{
				InvalidEntryDialog = x => x.Marked("button2");

				FirstNameEntry = x => x.Marked("FirstNameEntry").Child(1);
				LastNameEntry = x => x.Marked("LastNameEntry").Child(1);
				CompanyEntry = x => x.Marked("CompanyEntry").Child(1);
				TitleEntry = x => x.Marked("TitleEntry").Child(1);
				PhoneEntry = x => x.Marked("PhoneEntry").Child(1);
				EmailEntry = x => x.Marked("EmailEntry").Child(1);
				StreetEntry = x => x.Marked("StreetEntry").Child(1);
				CityEntry = x => x.Marked("CityEntry").Child(1);
				StateEntry = x => x.Marked("StateEntry").Child(1);
				ZipEntry = x => x.Marked("ZipEntry");
			}
			else if (OniOS)
			{
				InvalidEntryDialog = x => x.Class("UITransitionView");

				FirstNameEntry = x => x.Marked("FirstNameEntry");
				LastNameEntry = x => x.Marked("LastNameEntry");
				CompanyEntry = x => x.Marked("CompanyEntry");
				TitleEntry = x => x.Marked("TitleEntry");
				PhoneEntry = x => x.Marked("PhoneEntry");
				EmailEntry = x => x.Marked("EmailEntry");
				StreetEntry = x => x.Marked("StreetEntry");
				CityEntry = x => x.Marked("CityEntry");
				StateEntry = x => x.Marked("StateEntry");
				ZipEntry = x => x.Marked("ZipEntry");
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:Acquaint.UITest.Pages.AcquaintanceEditPage"/> invalid entry
		/// dialog is displayed.
		/// </summary>
		/// <value><c>true</c> if invalid entry dialog is displayed; otherwise, <c>false</c>.</value>
		public bool InvalidEntryDialogIsDisplayed
		{
			get
			{
				if (app.Query(InvalidEntryDialog).Any())
					return true;
				return false;
			}
		}

		/// <summary>
		/// Simple app.Back() that is utilized if necessary. Takes you to the previous screen
		/// </summary>
		public void Back()
		{
			app.Back();
			app.Screenshot("Go back");
		}
		/// <summary>
		/// Verifies test is currently on the Acquaintance Edit Page. This should be called before interacting with any fields.
		/// It can be assumed that all fields have loaded after making this call.
		/// </summary>
		public void VerifyOnPage()
		{
			app.WaitForElement(FirstNameEntry, "Timed out waiting for page to appear", TimeSpan.FromSeconds(3));
		}
		/// <summary>
		/// Gets the first name.
		/// </summary>
		/// <returns>The first name currently entererd.</returns>
		public string GetFirstName()
		{
			app.WaitForElement(FirstNameEntry);
			return app.Query(FirstNameEntry).First().Text;
		}
		/// <summary>
		/// Gets the last name.
		/// </summary>
		/// <returns>The last name currently entered.</returns>
		public string GetLastName()
		{
			return app.Query(LastNameEntry).First().Text;
		}
		/// <summary>
		/// Scrolls down to a specific entry.
		/// </summary>
		/// <param name="entryToScrollDownTo">Entry to scroll down to.</param>
		public void ScrollDownToEntry(To entryToScrollDownTo)
		{
			switch (entryToScrollDownTo)
			{
				case To.FirstName:
					app.ScrollDownTo(FirstNameEntry);
					break;
				case To.LastName:
					app.ScrollDownTo(LastNameEntry);
					break;
				case To.Company:
					app.ScrollDownTo(CompanyEntry);
					break;
				case To.Title:
					app.ScrollDownTo(TitleEntry);
					break;
				case To.Phone:
					app.ScrollDownTo(PhoneEntry);
					break;
				case To.Email:
					app.ScrollDownTo(EmailEntry);
					break;
				case To.Street:
					app.ScrollDownTo(StreetEntry);
					break;
				case To.City:
					app.ScrollDownTo(CityEntry);
					break;
				case To.State:
					app.ScrollDownTo(StateEntry);
					break;
				case To.Zip:
					app.ScrollDownTo(ZipEntry);
					break;
			}
		}
		/// <summary>
		/// Scrolls up to a specific entry.
		/// </summary>
		/// <param name="entryToScrollDownTo">Entry to scroll down to.</param>
		public void ScrollUpToEntry(To entryToScrollDownTo)
		{
			switch (entryToScrollDownTo)
			{
				case To.FirstName:
					app.ScrollUpTo(FirstNameEntry);
					break;
				case To.LastName:
					app.ScrollUpTo(LastNameEntry);
					break;
				case To.Company:
					app.ScrollUpTo(CompanyEntry);
					break;
				case To.Title:
					app.ScrollUpTo(TitleEntry);
					break;
				case To.Phone:
					app.ScrollUpTo(PhoneEntry);
					break;
				case To.Email:
					app.ScrollUpTo(EmailEntry);
					break;
				case To.Street:
					app.ScrollUpTo(StreetEntry);
					break;
				case To.City:
					app.ScrollUpTo(CityEntry);
					break;
				case To.State:
					app.ScrollUpTo(StateEntry);
					break;
				case To.Zip:
					app.ScrollUpTo(ZipEntry);
					break;
			}

			app.Screenshot($"Scrolled down to {entryToScrollDownTo.ToString()}");
		}
		/// <summary>
		/// Enters the first name.
		/// </summary>
		/// <param name="firstName">First name.</param>
		/// <param name="clearText">If set to <c>true</c> clear text before entering text.</param>
		public void EnterFirstName(string firstName, bool clearText)
		{
			//app.Tap(FirstNameEntry);

			if (clearText)
			{
				app.ClearText(FirstNameEntry);
			}

			app.EnterText(FirstNameEntry, firstName);
			app.DismissKeyboard();
		}
		/// <summary>
		/// Enters the last name.
		/// </summary>
		/// <param name="lastName">Last name.</param>
		/// <param name="clearText">If set to <c>true</c> clear text before entering text.</param>
		public void EnterLastName(string lastName, bool clearText)
		{
			app.Tap(LastNameEntry);

			if (clearText)
				app.ClearText();
			if (!string.IsNullOrEmpty(lastName))
				app.EnterText(lastName);
			app.DismissKeyboard();
		}
		/// <summary>
		/// Enters the name of the company.
		/// </summary>
		/// <param name="companyName">Company name.</param>
		/// <param name="clearText">If set to <c>true</c> clear text before entering text.</param>
		public void EnterCompanyName(string companyName, bool clearText)
		{
			app.Tap(CompanyEntry);

			if (clearText)
				app.ClearText();
			if (!string.IsNullOrEmpty(companyName))
				app.EnterText(companyName);
			app.DismissKeyboard();
		}
		/// <summary>
		/// Enters the title.
		/// </summary>
		/// <param name="title">Title.</param>
		/// <param name="clearText">If set to <c>true</c> clear text before entering text.</param>
		public void EnterTitle(string title, bool clearText)
		{
			app.Tap(TitleEntry);

			if (clearText)
				app.ClearText();
			app.EnterText(title);
			app.DismissKeyboard();
		}
		/// <summary>
		/// Enters the phone number.
		/// </summary>
		/// <param name="phoneNumber">Phone number.</param>
		/// <param name="clearText">If set to <c>true</c> clear text before entering text.</param>
		public void EnterPhoneNumber(string phoneNumber, bool clearText)
		{
			app.Tap(PhoneEntry);

			if (clearText)
				app.ClearText();
			app.EnterText(phoneNumber);
			app.DismissKeyboard();
		}
		/// <summary>
		/// Enters the email address.
		/// </summary>
		/// <param name="emailAddress">Email address.</param>
		/// <param name="clearText">If set to <c>true</c> clear text before entering text.</param>
		public void EnterEmailAddress(string emailAddress, bool clearText)
		{
			app.Tap(EmailEntry);

			if (clearText)
				app.ClearText();
			app.EnterText(emailAddress);
			app.DismissKeyboard();
		}
		/// <summary>
		/// Enters the street.
		/// </summary>
		/// <param name="street">Street.</param>
		/// <param name="clearText">If set to <c>true</c> clear text before entering text.</param>
		public void EnterStreet(string street, bool clearText)
		{
			app.Tap(StreetEntry);

			if (clearText)
				app.ClearText();
			app.EnterText(street);
			app.DismissKeyboard();
		}
		/// <summary>
		/// Enters the city.
		/// </summary>
		/// <param name="city">City.</param>
		/// <param name="clearText">If set to <c>true</c> clear text before entering text.</param>
		public void EnterCity(string city, bool clearText)
		{
			app.Tap(CityEntry);

			if (clearText)
				app.ClearText();
			app.EnterText(city);
			app.DismissKeyboard();
		}
		/// <summary>
		/// Enters the state.
		/// </summary>
		/// <param name="state">State.</param>
		/// <param name="clearText">If set to <c>true</c> clear text before entering text.</param>
		public void EnterState(string state, bool clearText)
		{
			app.Tap(StateEntry);

			if (clearText)
				app.ClearText();
			app.EnterText(state);
			app.DismissKeyboard();
		}
		/// <summary>
		/// Enters the zip.
		/// </summary>
		/// <param name="zipCode">Zip code.</param>
		/// <param name="clearText">If set to <c>true</c> clear text before entering text.</param>
		public void EnterZip(string zipCode, bool clearText)
		{
			app.Tap(ZipEntry);

			if (clearText)
				app.ClearText();
			app.EnterText(zipCode);
			app.DismissKeyboard();
		}
		/// <summary>
		/// Saves the new user.
		/// </summary>
		public void SaveNewUser()
		{
			app.Tap(SaveButton);
			app.Screenshot("Clicked Save User");
		}
	}
}