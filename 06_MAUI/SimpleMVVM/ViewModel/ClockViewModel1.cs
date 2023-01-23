using CommunityToolkit.Mvvm.ComponentModel;

namespace SimpleMVVM.ViewModel
{
    public partial class ClockViewModel1 : ObservableObject
    {
        [ObservableProperty]
        DateTime _dateTime;
        Timer _timer;

        public ClockViewModel1()
        {
            this.DateTime = DateTime.Now;
            _timer = new Timer(new TimerCallback((s) => this.DateTime = DateTime.Now),
                               null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }
        ~ClockViewModel1() =>
            _timer.Dispose();
    }
}
