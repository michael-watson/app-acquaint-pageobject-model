using Xamarin.UITest;

namespace Acquaint.UITest
{
	public class AppInitializer
	{
		public static IApp StartApp(Platform platform)
		{
			// TODO: If the iOS or Android app being tested is included in the solution 
			// then open the Unit Tests window, right click Test Apps, select Add App Project
			// and select the app projects that should be tested.
			//
			// The iOS project should have the Xamarin.TestCloud.Agent NuGet package
			// installed. To start the Test Cloud Agent the following code should be
			// added to the FinishedLaunching method of the AppDelegate:
			//
			//    #if ENABLE_TEST_CLOUD
			//    Xamarin.Calabash.Start();
			//    #endif
			if (platform == Platform.Android)
			{
				return ConfigureApp
					.Android
					// TODO: Update this path to point to your Android app and uncomment the
					// code if the app is not included in the solution.
					.ApkFile("../../../Acquaint.XForms.Droid/bin/AnyCPU/Debug/com.xamarin.acquaintforms-Signed.apk")
					.EnableLocalScreenshots()
					.StartApp();
			}

			return ConfigureApp
				.iOS
				// TODO: Update this path to point to your iOS app and uncomment the
				// code if the app is not included in the solution.
				//.AppBundle("../../../Acquaint.XForms.iOS/bin/iPhoneSimulator/Debug/AcquaintXFormsiOS.app")
				.InstalledApp("com.xamarin.acquaint-forms")
				.EnableLocalScreenshots()
				.StartApp();
		}
	}
}