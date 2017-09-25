using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasky.Core;
using Windows.UI.Xaml;

namespace TaskyPro
{
    public class TaskListViewModel : ViewModelBase
    {
        bool isUpdating;
        Visibility listVisibility;
        Visibility noDataVisibility;
        public ObservableCollection<TaskViewModel> Items { get; private set; }

        public bool IsUpdating
        {
            get { return isUpdating; }
            set
            {
                if (isUpdating != value)
                {
                    isUpdating = value;
                    OnPropertyChanged("UpdatingVisibility");
                    OnPropertyChanged();
                }
            }
        }

        public Visibility ListVisibility
        {
            get { return listVisibility; }
            set
            {
                if (listVisibility != value)
                {
                    listVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        public Visibility NoDataVisibility
        {
            get { return noDataVisibility; }
            set
            {
                if (noDataVisibility != value)
                {
                    noDataVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        public TaskListViewModel()
        {
            Items = new ObservableCollection<TaskViewModel>();
        }

        public Visibility UpdatingVisibility
        {
            get
            {
                return (IsUpdating || Items == null || Items.Count == 0) 
                    ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public async Task BeginUpdate()
        {
            IsUpdating = true;

            var entries = await TodoManager.GetTasksAsync();
            PopulateData(entries.ToList());

            IsUpdating = false;
        }

        void PopulateData(IEnumerable<TodoTask> entries)
        {
            Items.Clear();

            foreach (var item in entries)
                Items.Add(new TaskViewModel(item));

            ListVisibility = Items.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
            NoDataVisibility = Items.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}