using Tasky.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TaskyPro
{
    public partial class TaskDetailsPage : Page
    {
        public TaskDetailsPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.NavigationMode == NavigationMode.New)
            {
                TaskViewModel vm = new TaskViewModel();

                if (e.Parameter != null)
                {
                    var id = (int)e.Parameter;

                    var task = await TodoManager.GetTaskAsync(id);

                    if (task != null)
                        vm.Update(task);
                }

                DataContext = vm;
            }
        }

        private async void HandleSave(object sender, RoutedEventArgs e)
        {
            var taskvm = (TaskViewModel)DataContext;
            var task = taskvm.GetTask();
            await TodoManager.SaveTaskAsync(task);

            Frame.GoBack();
        }

        private async void HandleDelete(object sender, RoutedEventArgs e)
        {
            var taskvm = (TaskViewModel)DataContext;

            if (taskvm.ID >= 0)
            {
                await TodoManager.DeleteTaskAsync(taskvm.GetTask());
            }

            Frame.GoBack();
        }
    }
}