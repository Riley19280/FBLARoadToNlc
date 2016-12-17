using GarageSale;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Platform.Services.Media;
using XPA_PickMedia_XLabs_XFP;

namespace GarageSale.Views.Pages
{
	public class CameraPage : basePage
	{
		CameraViewModel cameraOps = null;
		Button btnTakePicture;
		Button btnPickPicture;
		Button btnPickVideo;
		Image imgPicked;
		ExtendedEntry entDetails;
		public CameraPage()
		{
			btnTakePicture = new Button { Text = "Take Picture" };
			btnPickPicture = new Button { Text = "Select Image from Picture Library" };
			btnPickVideo = new Button { Text = "Select Video from Picture Library" };
			imgPicked = new Image { VerticalOptions = LayoutOptions.CenterAndExpand };
			entDetails = new ExtendedEntry { VerticalOptions = LayoutOptions.CenterAndExpand };
			btnTakePicture.Clicked += btnTakePicture_Clicked;
			btnPickPicture.Clicked += btnPickPicture_Clicked;
			btnPickVideo.Clicked += btnPickVideo_Clicked;

			Content = new StackLayout
			{
				Children = {
					btnTakePicture,
					btnPickPicture,
					btnPickVideo,
					imgPicked,
					entDetails
				}
			};

			cameraOps = new CameraViewModel();
		}

		private async void btnTakePicture_Clicked(object sender, EventArgs e)
		{
			await cameraOps.TakePicture();
			imgPicked.Source = cameraOps.ImageSource;
			entDetails.Text = cameraOps.VideoInfo;
		}

		private async void btnPickPicture_Clicked(object sender, EventArgs e)
		{
			await cameraOps.SelectPicture();
			imgPicked.Source = cameraOps.ImageSource;
			entDetails.Text = "";
		}

		private async void btnPickVideo_Clicked(object sender, EventArgs e)
		{
			await cameraOps.SelectVideo();
			imgPicked.Source = null;
			entDetails.Text = cameraOps.VideoInfo;
		}
	}
}

