using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace ViewCellOnDisappearing
{
    public class ListPage : ContentPage
    {
        public ListPage()
        {
            var listViewItemSource = new ObservableCollection<LabelTextModel>();
            for (int i = 0; i < 25; i++)
                listViewItemSource.Add(new LabelTextModel { LabelText = "Hello" });

            var listView = new ListView
            {
                ItemTemplate = new DataTemplate(typeof(LabelViewCell)),
                ItemsSource = listViewItemSource
            };

            Content = listView;
        }

        class LabelViewCell : ViewCell
        {
            public LabelViewCell()
            {
                var model = BindingContext as LabelTextModel;

                var label = new Label
                {
                    VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    HorizontalTextAlignment = TextAlignment.Center
                };
                label.SetBinding(Label.TextProperty, nameof(model.LabelText));

                View = label;
            }

            protected override void OnAppearing()
            {
                base.OnAppearing();

                Debug.WriteLine("OnAppearing Fired");
            }

			protected override void OnDisappearing()
			{
				base.OnAppearing();

				Debug.WriteLine("OnDisappearing Fired");
			}
        }

        class LabelTextModel
        {
            public string LabelText { get; set; }
        }
    }
}
