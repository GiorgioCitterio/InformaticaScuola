using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _00_Calcolatrice.ViewModel
{
    #region esempioNuovo
    [ObservableObject]
    public partial class CalculatorViewModel
    {
        private string _inputString = "";
        [ObservableProperty]
        private string _displayText = "";
        private char[] _specialChars = { '*', '#' };
        public string InputString
        {
            get => _inputString;
            private set
            {
                if (_inputString != value)
                {
                    _inputString = value;
                    DisplayText = FormatText(_inputString);
                }
            }
        }
        [RelayCommand]
        void AddChar(string key)
        {
            InputString = key;
        }
        [RelayCommand]
        void DeleteChar(string key)
        {
            InputString = key;
        }
        string FormatText(string str)
        {
            bool hasNonNumbers = str.IndexOfAny(_specialChars) != -1;
            string formatted = str;

            if (hasNonNumbers || str.Length < 4 || str.Length > 10)
            { }

            else if (str.Length < 8)
                formatted = string.Format("{0}-{1}", str.Substring(0, 3), str.Substring(3));

            else
                formatted = string.Format("({0}) {1}-{2}", str.Substring(0, 3), str.Substring(3, 3), str.Substring(6));

            return formatted;
        }
    }
    #endregion
}

