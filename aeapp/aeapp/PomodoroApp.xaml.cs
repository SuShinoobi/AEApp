using System;
using Android.App;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aeapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PomodoroApp : ContentPage, ITimer
    {
        public NewTimer Timer;
        

        public PomodoroApp()
        {
            InitializeComponent();
            Timer = new NewTimer(this);
        }

        public void OnButtonClickedFlip(object sender, EventArgs args)
        {
            Button.Text = Button.Text == "Turn On" ? "Turn OFF" : "Turn On";
            Timer.Flip();
        }

        public void OnButtonClickedReset(object sender, EventArgs args)
        {
            Timer.Reset();
        }

        public void Update(string timerValue)
        {
            ValueText.Text = timerValue;
        }

        /* TO DO:
        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Timer.Change((string)picker.ItemsSource[selectedIndex]);
            }
        }
        */
    }
}