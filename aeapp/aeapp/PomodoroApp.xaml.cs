using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aeapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PomodoroApp : ContentPage, ITimer
    {
        public Timer Timer;
        
        public PomodoroApp()
        {
            Timer = new Timer(this);
            InitializeComponent();
            Button.Text = "Turn On";
            Timer.Counter();
        }

        public void OnButtonClicked(object sender, EventArgs args)
        {
            Button.Text = Button.Text == "Turn On" ? "Turn OFF" : "Turn On";
            Timer.Flip();
        }

        public void Update(double min, double sec)
        {
            ValueText.Text = min + "m " + sec + "s";
            if (min <= 0 && sec <= 0) TimerFinished();
        }

        private void TimerFinished()
        {
            DisplayAlert("Alert", "You have been alerted", "OK");
        }
    }
}