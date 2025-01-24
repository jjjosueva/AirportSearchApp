using AirportSearchApp.ViewModels;

namespace AirportSearchApp.Views
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = new AirportViewModel(); // Asignamos el BindingContext al ViewModel
        }
    }
}
