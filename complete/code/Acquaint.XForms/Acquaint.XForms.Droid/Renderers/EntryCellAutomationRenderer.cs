using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Acquaint.XForms.Droid.Renderers;

#if DEBUG
[assembly: ExportRenderer(typeof(EntryCell), typeof(EntryCellAutomationRenderer))]
#endif

namespace Acquaint.XForms.Droid.Renderers
{
#if DEBUG
	public class EntryCellAutomationRenderer : EntryCellRenderer
	{
		protected override Android.Views.View GetCellCore(Xamarin.Forms.Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
		{
			var view = base.GetCellCore(item, convertView, parent, context);

			view.ContentDescription = item.AutomationId;

			return view;
		}
	}
#endif
}