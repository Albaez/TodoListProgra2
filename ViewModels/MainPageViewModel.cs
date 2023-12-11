//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
//using System.Collections.ObjectModel;
//using System.Windows.Input;
//using static System.Net.Mime.MediaTypeNames;

//namespace ToDoListNew.ViewModels
//{
//    public partial class MainPageViewModel : ObservableObject
//    {
//        public MainPageViewModel()
//        {
//            Items = new ObservableCollection<string>();
//            //selectedColor = new Color();
//            //SelectedColor = Color.FromRgb(255,255, 255);
//        }

//        private Color frameColor;

//        public Color FrameColor
//        {
//            get => frameColor;
//            set => SetProperty(ref frameColor, value);
//        }



//        public Color selectedColor;
//        public Color SelectedColor
//        {
//            get => selectedColor;
//            set => SetProperty(ref selectedColor, value);
//        }
//        public ICommand CompleteCommand => new Command<string>(Complete);


//        [ObservableProperty]
//        private ObservableCollection<string> items;

//        [ObservableProperty]
//        private string text;


//        [RelayCommand]
//        private void Add()
//        {
//            Items.Add(Text);
//        }

//        [RelayCommand]
//        private void Delete(string s)
//        {
//            if (Items.Contains(s))
//                Items.Remove(s);
//        }

//        private void Complete(string item)
//        {
//            SelectedColor = Color.FromRgb(0, 255, 0);
//            Items.Move(Items.IndexOf(item), Items.Count - 1);
//            FrameColor = Color.FromRgb(0, 255, 0);
//            OnPropertyChanged(nameof(FrameColor));
//        }



//    }

//}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace ToDoListNew.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {

     
        public MainPageViewModel()
        {
            Items = new ObservableCollection<string>();
            completedItems= new ObservableCollection<string>();

        }
        public ICommand CompleteCommand => new Command<string>(Complete);

        [ObservableProperty]
        private ObservableCollection<string> items;

        [ObservableProperty]
        private string text;

        [RelayCommand]
        private void Add()
        {
            Items.Add(Text);
        }

        [RelayCommand]
        private void Delete(string s)
        {
            if (Items.Contains(s))
                Items.Remove(s);
        }
        private ObservableCollection<string> completedItems;

        public ObservableCollection<string> CompletedItems
        {
            get => completedItems;
            set => SetProperty(ref completedItems, value);
        }
        private void Complete(string item)
        {


            CompletedItems.Add(item);
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }

        }

        private bool showCompleted;

        public bool ShowCompleted
        {
            get => showCompleted;
            set
            {
                SetProperty(ref showCompleted, value);
                OnPropertyChanged(nameof(VisibleItems));
            }
        }

        public IEnumerable<string> VisibleItems
        {
            get
            {
                if (ShowCompleted)
                    return CompletedItems;
                else
                    return Items;
            }
        }

        public ICommand ShowCompletedCommand => new Command(ShowCompletedItems);

        private void ShowCompletedItems()
        {
            ShowCompleted = !ShowCompleted;
        }

    }
}
