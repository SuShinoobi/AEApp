using System;
using Xamarin.Forms;

namespace aeapp
{
    public class Timer
    {
        private int TotalTime = 20;
        private int currentTime;
        private double minutes;
        private double seconds;
        public bool countdownRunning = false;
        public ITimer AppPage;

        public Timer(ITimer appPage)
        {
            AppPage = appPage;
        }

        public void Change(string time)
        {
            TotalTime = Convert.ToInt32(time);
            currentTime = TotalTime * 60;
        }

        public void Counter()
        {
            currentTime = TotalTime * 60;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (countdownRunning && currentTime > 0)
                {
                    minutes = Math.Floor(currentTime / 60.0);
                    seconds = currentTime - 60 * minutes;

                    AppPage.Update(minutes, seconds);

                    currentTime--;
                }
                if (currentTime <= 0 && countdownRunning)
                {
                    countdownRunning = false;
                    AppPage.Update(0, 0);
                }
                return true;
            });
        }

        public void Flip()
        {
            countdownRunning = !countdownRunning;
        }
    }
}