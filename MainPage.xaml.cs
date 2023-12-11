using ToDoListNew.ViewModels;

namespace ToDoListNew
{
    public partial class MainPage : ContentPage
    {
     
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

      
    }
}