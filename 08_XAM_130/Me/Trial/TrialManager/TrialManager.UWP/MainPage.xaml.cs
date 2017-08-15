namespace TrialManager.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new TrialManager.App());
        }
    }
}