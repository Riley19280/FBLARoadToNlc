using GarageSale.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GarageSale.Views.ListViews
{
	class fblaChapterListView : ListView
	{

		public fblaChapterListView()
		{
			Label schoolLabel=null;
			Label locLabel=null;
			// Source of data items.
			VerticalOptions = LayoutOptions.FillAndExpand;
			HorizontalOptions = LayoutOptions.FillAndExpand;

			RowHeight = 75;
			// Define template for displaying each item.
			// (Argument of DataTemplate constructor is called for 
			//      each item; it must return a Cell derivative.)
			ItemTemplate = new DataTemplate(() =>
			{
				// Create views with bindings for displaying each property.
				schoolLabel = new Label { FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) };
				locLabel = new Label();
				schoolLabel.SetBinding(Label.TextProperty, "school");

				Image imageView = new Image
				{
					HeightRequest = 75,
					WidthRequest = 75,

				};
				imageView.SetBinding(Image.SourceProperty, "pic_url");



				// Return an assembled ViewCell.
				return new ViewCell
				{
					View = new StackLayout
					{
						Padding = new Thickness(5, 5, 5, 0),
						Orientation = StackOrientation.Horizontal,
						Children =
							{
									imageView,
									new StackLayout
									{
										//VerticalOptions = LayoutOptions.Center,
										Spacing = 5,
										Children =
										{
											schoolLabel,
											locLabel,
										}
									}
							}
					}
				};
			});

			this.ItemSelected += ((sender, eventArgs) =>
			{
				if (this.SelectedItem != null)
				{
					var c = SelectedItem as myDataTypes.fblaChapter;
					var chapterView = new fblaChapterPage(c);
					this.SelectedItem = null;
					Navigation.PushAsync(chapterView);
				}
			});

			ItemAppearing += (s, e) =>
			{
				myDataTypes.fblaChapter i = e.Item as myDataTypes.fblaChapter;
				
				locLabel.Text = i.city + ", " + i.state;
			};
		}

	}
}

