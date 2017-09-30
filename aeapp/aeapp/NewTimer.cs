using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace aeapp
{
    public class NewTimer
    {
        public ITimer App;
        private int _totalTime = 25;
        private int _currentTime;
        private bool _cancellationRequested;
        private bool _timerOn;

        public NewTimer(ITimer app)
        {
            App = app;
            _currentTime = _totalTime * 60;
        }

        public void Start()
        {
            _timerOn = true;
            _cancellationRequested = false;
            Device.StartTimer(TimeSpan.FromSeconds(1), Counter);
        }

        public void Stop()
        {
            _timerOn = false;
            _cancellationRequested = true;
        }

        public void Flip()
        {
            if (!_timerOn) Start();
            else Stop();
        }

        public void Reset()
        {
            _currentTime = _totalTime * 60;
            Show();
        }

        public void Change(string time)
        {
            _totalTime = Convert.ToInt32(time);
            _currentTime = _totalTime * 60;
            Show();
        }

        private bool Counter()
        {
            if (_currentTime <= 0 || _cancellationRequested)
            {
                return false;
            }
            _currentTime--;
            Show();
            return true;
        }

        private void Show()
        {
            var minutes = Math.Floor(_currentTime / 60.0);
            var seconds = _currentTime - 60 * minutes;
            App.Update(minutes + "m " + seconds + "s");
        }
    }
}