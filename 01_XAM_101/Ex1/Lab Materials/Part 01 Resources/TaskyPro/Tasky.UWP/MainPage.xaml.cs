using TaskyPro;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Tasky.UWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            DataContext = new TaskListViewModel();
            Loaded += MainPage_Loaded;
        }
        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ((TaskListViewModel)DataContext).BeginUpdate();
        }

        private void HandleAdd(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TaskDetailsPage));
        }

        private void HandleTaskTap(object sender, RoutedEventArgs e)
        {
            TaskViewModel item = (TaskViewModel)((ListView)sender).SelectedItem;
                
            if (item != null)
                Frame.Navigate(typeof(TaskDetailsPage), item.ID);
        }
    }
}