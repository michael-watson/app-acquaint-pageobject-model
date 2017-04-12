using System;
using System.Threading;

using NUnit.Framework;

using Xamarin.UITest;

using Acquaint.UITest.Pages;

namespace Acquaint.UITest.Tests
{
	public class EditUserTests : AbstractSetup
	{
		AcquaintanceListPage UserListPage;
		AcquaintanceEditPage EditUserPage;
		AcquaintanceDetailPage UserDetailsPage;

		public EditUserTests(Platform platform) : base(platform)
		{
		}

		public override void BeforeEachTest()
		{
			base.BeforeEachTest();

			UserListPage = new AcquaintanceListPage(app, platform);
			UserDetailsPage = new AcquaintanceDetailPage(app, platform);
			EditUserPage = new AcquaintanceEditPage(app, platform);
		}

		[Test]
		public void ChangeFirstUserAddressAndSave_ShouldShowUpdateMapPosition()
		{
			//Arrange
			var street = "394 Pacific Ave.";
			var city = "San Francisco";
			var state = "CA";
			var zipCode = "94111";

			//Act
			UserListPage.WaitForPageNavigationToComplete();
			UserListPage.SelectFirstUserInList();

			//var currentStreet = UserDetailsPage.GetStreet();
			//var currentCity = UserDetailsPage.GetCity();
			//var currentStatePostal = UserDetailsPage.GetStatePostal();

			UserDetailsPage.EditUser();

			EditUserPage.ScrollDownToEntry(enums.To.Zip);
			EditUserPage.EnterStreet(street, true);
			EditUserPage.EnterCity(city, true);
			EditUserPage.EnterState(state, true);
			EditUserPage.EnterZip(zipCode, true);
			EditUserPage.SaveNewUser();

			//Wait for map to load
			Thread.Sleep(5000);

			//Assert
			app.Screenshot("Map should be updated to new location");

			//CleanUp
			//UserDetailsPage.EditUser();
			//EditUserPage.ScrollDownToEntry(enums.To.Zip);
			//EditUserPage.EnterStreet(currentStreet, true);
			//EditUserPage.EnterCity(currentCity, true);
			//EditUserPage.EnterState(currentStatePostal.Split(' ')[0], true);
			//EditUserPage.EnterZip(currentStatePostal.Split(' ')[1], true);
			//EditUserPage.SaveNewUser();
		}

		[Test]
		public void ChangeFirstUserPhoneNumberAndSave_ShouldSaveAppropriately()
		{
			//Arrange
			var phoneNumber = "555-555-5555";

			//Act
			UserListPage.SelectFirstUserInList();

			UserDetailsPage.EditUser();
			EditUserPage.EnterPhoneNumber(phoneNumber, true);
			EditUserPage.SaveNewUser();

			//Assert
			//Notice that we only check one element. Typically a save call is routed through an API. 
			//It is safe to assume that if 1 property of the object saves, than all properties were saved
			app.WaitForElement(x => x.Marked(phoneNumber), "Timed out waiting for saved phone number to appear", TimeSpan.FromSeconds(30));
		}

		[Test]
		public void ChangeFirstUserFirstNameAndSave_ShouldSaveAppropriately()
		{
			//Arrange
			var firstName = "!@#$%^&*()";

			//Act
			UserListPage.SelectFirstUserInList();
			UserDetailsPage.EditUser();
			EditUserPage.WaitForPageNavigationToComplete();

			var currentFirstName = EditUserPage.GetFirstName();
			var currentLastName = EditUserPage.GetLastName();

			EditUserPage.EnterFirstName(firstName, true);
			EditUserPage.SaveNewUser();
			EditUserPage.Back();
			UserListPage.WaitForIndicatorToDisappear();

			//Assert
			app.ScrollDownTo($"{currentLastName}, {firstName}");
		}

		[Test]
		public void DeleteFirstUserFirstNameAndSave_ShouldDisplayError()
		{
			//Arrange

			//Act
			UserListPage.SelectFirstUserInList();
			UserDetailsPage.EditUser();
			EditUserPage.EnterFirstName(" ", true);
			EditUserPage.SaveNewUser();

			//Assert
			Assert.IsTrue(EditUserPage.InvalidEntryDialogIsDisplayed);
		}

		[Test]
		public void DeleteFirstUserLastNameAndSave_ShouldDisplayError()
		{
			//Arrange

			//Act
			UserListPage.SelectFirstUserInList();
			UserDetailsPage.EditUser();
			EditUserPage.EnterLastName(" ", true);
			EditUserPage.SaveNewUser();

			//Assert
			Assert.IsTrue(EditUserPage.InvalidEntryDialogIsDisplayed);
		}
	}
}