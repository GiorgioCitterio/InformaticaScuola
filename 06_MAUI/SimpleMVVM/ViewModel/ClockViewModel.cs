﻿using CommunityToolkit.Mvvm.ComponentModel;
namespace SimpleMVVM.ViewModel
{
    public partial class ClockViewModel : ObservableObject
    {
        [ObservableProperty]
        private DateTime _dateTime;
        private Timer _timer;
        public ClockViewModel()
        {
            this.DateTime = DateTime.Now;
            // Update the DateTime property every second.
            _timer = new Timer(new TimerCallback((s) => this.DateTime = DateTime.Now),
                               null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }
        ~ClockViewModel() =>
            _timer.Dispose();
    }
}

