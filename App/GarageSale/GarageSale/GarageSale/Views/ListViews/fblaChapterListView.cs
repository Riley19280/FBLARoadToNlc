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
		CustomImageView imageView;
		public fblaChapterListView()
		{
			SeparatorColor = Constants.palette.divider;
			Label schoolLabel = null;
			Label locLabel = null;
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

				imageView = new CustomImageView
				{
					HeightRequest = 75,
					WidthRequest = 75,

				};


				// Return an assembled ViewCell.
				return new ViewCell
				{
					View = new StackLayout
					{
						Padding = new Thickness(5, 5, 5, 5),
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

			ItemAppearing += async (s, e) =>
			 {
				 if (e.Item == null)
					 return;

				 myDataTypes.fblaChapter i = e.Item as myDataTypes.fblaChapter;


				 locLabel.Text = i.city + ", " + i.state;
				 schoolLabel.Text = i.school;

				 IImageProcessing processer = DependencyService.Get<IImageProcessing>();
				 imageView.SetImageBitmap(await processer.ScaleBitmap(i.picture, await processer.GetBitmapOptionsOfImageAsync(i.picture), 200, 200));

			 };
		}

	}
}

