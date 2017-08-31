using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlExplorer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        int count;
        private Effect _fontEffect;

        public MainPage()
        {
            InitializeComponent();

            _fontEffect = Effect.Resolve("Xamarin.CustomFontEffect");
            labelWelcome.Effects.Add(_fontEffect);
        }

        private void OnButtonClicked(object sender, System.EventArgs e)
        {
            buttonClick.Text = string.Format("Click Count = {0}", ++count);
        }

        private void OnSwitchToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                if (!labelWelcome.Effects.Contains(_fontEffect))
                    labelWelcome.Effects.Add(_fontEffect);
               
            }
            else
            {
                if (labelWelcome.Effects.Contains(_fontEffect))
                    labelWelcome.Effects.Remove(_fontEffect);
            }
        }

        private void OnSliderColorValueChanged(object sender, ValueChangedEventArgs e)
        {

        }
    }
}