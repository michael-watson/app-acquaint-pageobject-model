using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using Acquaint.XForms.iOS.Renderers;

#if DEBUG
[assembly: ExportRenderer(typeof(EntryCell), typeof(EntryCellAutomationRenderer))]
#endif

namespace Acquaint.XForms.iOS.Renderers
{
#if DEBUG
	public class EntryCellAutomationRenderer : EntryCellRenderer
	{
		public override UIKit.UITableViewCell GetCell(Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
		{
			var view = base.GetCell(item, reusableCell, tv);

			if (!string.IsNullOrEmpty(item.AutomationId))
			{
				var cellContentView = view.Subviews[0];
				var textField = cellContentView.Subviews[0];

				textField.AccessibilityIdentifier = item.AutomationId;
			}

			return view;
		}
	}
#endif
}