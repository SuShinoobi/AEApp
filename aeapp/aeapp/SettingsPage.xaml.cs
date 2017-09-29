using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aeapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        public Timer Timer;

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker) sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                Timer.Change((string) picker.ItemsSource[selectedIndex]);
            }
        }
    }
}