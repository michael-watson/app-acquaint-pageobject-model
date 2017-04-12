using System;

using Xamarin.Forms;

using Acquaint.Models;

namespace Acquaint.XForms
{
	public partial class AcquaintanceViewCell : ViewCell
	{
		public AcquaintanceViewCell()
		{
			InitializeComponent();
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			var acquaintance = BindingContext as Acquaintance;

			NameLabel.Text = acquaintance.DisplayLastNameFirst;
			CompanyLabel.Text = acquaintance.Company;
			TitleLabel.Text = acquaintance.JobTitle;

			if (!string.IsNullOrEmpty(acquaintance.SmallPhotoUrl))
				PictureImage.Source = UriImageSource.FromUri(new Uri(acquaintance.SmallPhotoUrl));
			//else
			//	PictureImage.Source = "placeHolderProfileImage.png";
		}
	}
}