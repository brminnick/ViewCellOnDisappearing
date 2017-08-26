using System;
using Xamarin.Forms;

namespace ViewCellOnDisappearing
{
    public class FirstPage : ContentPage
    {
        readonly Button _listPageButton;

        public FirstPage()
        {
            _listPageButton = new Button { Text = "List Page" };

            Content = _listPageButton;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _listPageButton.Clicked += HandleListPageButtonClicked;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _listPageButton.Clicked -= HandleListPageButtonClicked;
        }

        void HandleListPageButtonClicked(object sender, EventArgs e) =>
            Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new ListPage()));
    }
}
