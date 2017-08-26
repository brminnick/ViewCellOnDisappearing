using Xamarin.Forms;

namespace ViewCellOnDisappearing
{
    public class App: Application
    {
        public App() => MainPage = new NavigationPage(new FirstPage());
    }
}
