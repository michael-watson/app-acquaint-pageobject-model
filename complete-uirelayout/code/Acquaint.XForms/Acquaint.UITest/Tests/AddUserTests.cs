using System;
using System.Threading;

using NUnit.Framework;

using Xamarin.UITest;

using Acquaint.UITest.Pages;
using Acquaint.UITest.enums;

namespace Acquaint.UITest.Tests
{
	public class AddUserTests : AbstractSetup
	{
		AcquaintanceListPage UserListPage;
		AcquaintanceEditPage NewUserPage;

		public AddUserTests(Platform platform) : base(platform)
		{
		}

		public override void BeforeEachTest()
		{
			base.BeforeEachTest();

			UserListPage = new AcquaintanceListPage(app, platform);
			NewUserPage = new AcquaintanceEditPage(app, platform);
		}

		[Test]
		public void SaveFullUserData_ShouldSaveSuccessfully()
		{
			//Arrange
			var firstName = "Michael Watson";
			var lastName = "Aaaaaaaaaaaaaaaaa";
			var completeName = $"{lastName}, {firstName}";
			var companyName = "Microsoft";
			var title = "Technical Solutions Professional";
			var phoneNumber = "555-555-5555";
			var emailAddress = "XtcRocks@xamarin.com";
			var streetAddress = "394 Pacific Ave.";
			var city = "San Francisco";
			var state = "CA";
			var zipCode = "94111";

			//Act
			UserListPage.WaitForPageNavigationToComplete();
			UserListPage.TapOnAddNewUser();

			NewUserPage.WaitForPageNavigationToComplete();
			NewUserPage.EnterFirstName(firstName, false);
			NewUserPage.EnterLastName(lastName, false);
			NewUserPage.EnterCompanyName(companyName, false);
			NewUserPage.EnterTitle(title, false);

			NewUserPage.ScrollDownToEntry(NewUserPage.PhoneEntry);
			NewUserPage.EnterPhoneNumber(phoneNumber, false);
			NewUserPage.EnterEmailAddress(emailAddress, false);

			NewUserPage.ScrollDownToEntry(NewUserPage.ZipEntry);
			NewUserPage.EnterStreet(streetAddress, false);
			NewUserPage.EnterCity(city, false);
			NewUserPage.EnterState(state, false);
			NewUserPage.EnterZip(zipCode, false);
			NewUserPage.SaveNewUser();

			UserListPage.WaitForPageNavigationToComplete();
			UserListPage.WaitForIndicatorToDisappear();
			//Assert
			//Notice that we only check one element. Typically a save call is routed through an API. 
			//It is safe to assume that if 1 property of the object saves, than all properties were saved
			app.WaitForElement(x => x.Text(completeName), "Timed out waiting for saved user to appear", TimeSpan.FromSeconds(30));
		}

		[Test]
		public void SaveMinimumAmountOfInformation_ShouldSaveSuccssfully()
		{
			//Arrange
			var firstName = "Michael Watson";
			var lastName = "Aaaaaaaaaaaaaaaaa";
			var completeName = $"{lastName}, {firstName}";

			//Act
			UserListPage.WaitForPageNavigationToComplete();
			UserListPage.TapOnAddNewUser();

			NewUserPage.WaitForPageNavigationToComplete();
			NewUserPage.EnterFirstName(firstName, false);
			NewUserPage.EnterLastName(lastName, false);
			NewUserPage.SaveNewUser();
			UserListPage.WaitForPageNavigationToComplete();

			//Assert
			app.WaitForElement(x => x.Text(completeName), "Timed out waiting for saved user to appear", TimeSpan.FromSeconds(30));
		}

		[Test]
		public void NoInformationEntered_ShouldDisplayError()
		{
			UserListPage.WaitForPageNavigationToComplete();
			UserListPage.TapOnAddNewUser();
			NewUserPage.WaitForPageNavigationToComplete();
			NewUserPage.SaveNewUser();

			Assert.IsTrue(NewUserPage.InvalidEntryDialogIsDisplayed);
		}

		[Test]
		public void NoFirstNameEntered_ShouldDisplayError()
		{
			UserListPage.WaitForPageNavigationToComplete();
			UserListPage.TapOnAddNewUser();
			NewUserPage.WaitForPageNavigationToComplete();
			NewUserPage.EnterFirstName("My First Name", false);
			NewUserPage.SaveNewUser();

			Assert.IsTrue(NewUserPage.InvalidEntryDialogIsDisplayed);
		}

		[Test]
		public void NoLastNameEntered_ShouldDisplayError()
		{
			UserListPage.WaitForPageNavigationToComplete();
			UserListPage.TapOnAddNewUser();
			NewUserPage.WaitForPageNavigationToComplete();
			NewUserPage.EnterLastName("My Last Name", false);
			NewUserPage.SaveNewUser();

			Assert.IsTrue(NewUserPage.InvalidEntryDialogIsDisplayed);
		}
	}
}