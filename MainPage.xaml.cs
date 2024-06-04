using CommunityToolkit.Mvvm.ComponentModel;

namespace Dorisoy.RippleAnimation
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private RadarDrawable radarDrawable;

        public MainPageViewModel()
        {
            radarDrawable = new RadarDrawable();
        }
    }


    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();

            StartRippleAnimation();
        }

        async void StartRippleAnimation()
        {

            var vm = this.BindingContext as MainPageViewModel;

            graphicsView.Drawable = vm?.RadarDrawable;

            while (true)
            {
                vm?.RadarDrawable.Update();

                graphicsView.Invalidate();

                await Task.Delay(50);
            }
        }
    }

}
