using System.ComponentModel;
using System.Windows.Input;

namespace maui_control_examples.ViewModels
{
    /// <summary>
    /// Controls the behaviour of the <see cref="MainPage"/>.
    /// </summary>
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _buttonText = "Press Me!";
        private int _buttonPressCount = 0;

        /// <summary>
        /// Handler for the PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Command that fires when the button is pressed.
        /// </summary>
        public ICommand? OnButtonPressCommand { get; }

        /// <summary>
        /// Initialises a new instance of the <see cref="MainPageViewModel"/>.
        /// </summary>
        public MainPageViewModel()
        {
            OnButtonPressCommand = new Command(OnButtonPress);
        }

        /// <summary>
        /// The text to display on the button.
        /// </summary>
        public string ButtonText
        {
            get => _buttonText;
            set
            {
                _buttonText = value;
                OnPropertyChanged(nameof(ButtonText));
            }
        }

        /// <summary>
        /// The amount of times the button has been pressed.
        /// </summary>
        public int ButtonPressCount
        {
            get => _buttonPressCount;
            set
            {
                if (_buttonPressCount != value)
                {
                    _buttonPressCount = value;
                    OnPropertyChanged(nameof(ButtonPressCount));
                }
            }
        }

        private void UpdateButtonText()
        {
            ButtonText = $"Button pressed {ButtonPressCount} times!";
        }

        private void OnButtonPress()
        {
            ButtonPressCount++;
        }

        //public void OnPropertyChanged([CallerMemberName] string name = "") =>
        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (propertyName == nameof(ButtonPressCount))
            {
                UpdateButtonText();
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
