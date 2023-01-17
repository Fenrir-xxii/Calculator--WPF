using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum MathOperator
    {
        Plus = 0, Minus, Multiply, Divide, None
    }
    public partial class MainWindow : Window
    {
        private List<double> _numbers;
        private string _currentNumber = "";
        private string _history = "";
        private bool _isDotPressed = false;
        private bool _isEqualPressed = false;
        private MathOperator _operator = MathOperator.None;
        private double _sum;
        public MainWindow()
        {
            InitializeComponent();
            _numbers = new List<double>();
        }
        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
            }
            if (_currentNumber == "0")
            {
                _currentNumber = "";
            }
            _currentNumber += Zero.Content.ToString();
            UpdateMonitor();
        }
        private void One_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
            }
            if (_currentNumber == "0")
            {
                _currentNumber = "";
            }
            _currentNumber += One.Content.ToString();
            UpdateMonitor();
        }
        private void Two_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
            }
            if (_currentNumber == "0")
            {
                _currentNumber = "";
            }
            _currentNumber += Two.Content.ToString();
            UpdateMonitor();
        }
        private void Three_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
            }
            if (_currentNumber == "0")
            {
                _currentNumber = "";
            }
            _currentNumber += Three.Content.ToString();
            UpdateMonitor();
        }
        private void Four_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
            }
            if (_currentNumber == "0")
            {
                _currentNumber = "";
            }
            _currentNumber += Four.Content.ToString();
            UpdateMonitor();
        }
        private void Five_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
            }
            if (_currentNumber == "0")
            {
                _currentNumber = "";
            }
            _currentNumber += Five.Content.ToString();
            UpdateMonitor();
        }
        private void Six_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
            }
            if (_currentNumber == "0")
            {
                _currentNumber = "";
            }
            _currentNumber += Six.Content.ToString();
            UpdateMonitor();
        }
        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
            }
            if (_currentNumber == "0")
            {
                _currentNumber = "";
            }
            _currentNumber += Seven.Content.ToString();
            UpdateMonitor();
        }
        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
            }
            if (_currentNumber == "0")
            {
                _currentNumber = "";
            }
            _currentNumber += Eight.Content.ToString();
            UpdateMonitor();
        }
        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
            }
            if (_currentNumber == "0")
            {
                _currentNumber = "";
            }
            _currentNumber += Nine.Content.ToString();
            UpdateMonitor();
        }
        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
            }
            if (!_isDotPressed)
            {
                if (_currentNumber == "")
                {
                    _currentNumber = "0";
                }
                _currentNumber += ",";
                //_currentNumber += Dot.Content.ToString();
                UpdateMonitor();
                _isDotPressed = true;
            }
        }
        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            double temp;
            if (double.TryParse(_currentNumber, out temp))
            {
                _numbers.Add(temp);
                _history += temp + "+";
                _currentNumber = "";
                _isDotPressed = false;
            }
            if (_history.EndsWith('-') || _history.EndsWith('*') || _history.EndsWith('/'))
            {
                _history = _history.Remove(_history.Length - 1) + "+";
            }
            if (_isEqualPressed)
            {
                _history = _history.Remove(_history.Length - 1) + "+";
            }
            if (_numbers.Count > 1)
            {
                DoMath();
            }
            UpdateHistory();
            _operator = MathOperator.Plus;
            _currentNumber = "";
            _isEqualPressed = false;
        }
        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            double temp;
            if (double.TryParse(_currentNumber, out temp))
            {
                _numbers.Add(temp);
                _history += temp + "-";
                _currentNumber = "";
                _isDotPressed = false;
            }
            if (_history.EndsWith('+') || _history.EndsWith('*') || _history.EndsWith('/'))
            {
                _history = _history.Remove(_history.Length - 1) + "-";
            }
            if (_isEqualPressed)
            {
                _history = _history.Remove(_history.Length - 1) + "-";
            }
            if (_numbers.Count > 1)
            {
                DoMath();
            }
            UpdateHistory();
            _operator = MathOperator.Minus;
            _currentNumber = "";
            _isEqualPressed = false;
        }
        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            double temp;
            if (double.TryParse(_currentNumber, out temp))
            {
                _numbers.Add(temp);
                _history += temp + "*";
                _currentNumber = "";
                _isDotPressed = false;
            }
            if (_history.EndsWith('+') || _history.EndsWith('-') || _history.EndsWith('/'))
            {
                _history = _history.Remove(_history.Length - 1) + "*";
            }
            if (_isEqualPressed)
            {
                _history = _history.Remove(_history.Length - 1) + "*";
            }
            if (_numbers.Count > 1)
            {
                DoMath();
            }
            UpdateHistory();
            _operator = MathOperator.Multiply;
            _currentNumber = "";
            _isEqualPressed = false;
        }
        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            double temp;
            if (double.TryParse(_currentNumber, out temp))
            {
                _numbers.Add(temp);
                _history += temp + "/";
                _currentNumber = "";
                _isDotPressed = false;
            }
            if (_history.EndsWith('+') || _history.EndsWith('-') || _history.EndsWith('*'))
            {
                _history = _history.Remove(_history.Length - 1) + "/";
            }
            if (_isEqualPressed)
            {
                _history = _history.Remove(_history.Length - 1) + "/";
            }
            if (_numbers.Count > 1)
            {
                DoMath();
            }
            UpdateHistory();
            _operator = MathOperator.Divide;
            _currentNumber = "";
            _isEqualPressed = false;
        }
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            double temp;
            if (double.TryParse(_currentNumber, out temp))
            {
                _numbers.Add(temp);
                _history += temp + "=";
                _currentNumber = "";
                _isDotPressed = false;
            }
            UpdateHistory();
            DoMath();
            _currentNumber = "";
            _isEqualPressed = true;
            _operator = MathOperator.None;
        }
        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (_currentNumber.Length > 0)
            {
                _currentNumber = _currentNumber.Remove(_currentNumber.Length - 1);
                UpdateMonitor();
                if(!_currentNumber.Contains(','))
                {
                    _isDotPressed = false;
                }
            }
        }
        private void ClearEntry_Click(object sender, RoutedEventArgs e)
        {
            if (_currentNumber.Length > 0)
            {
                _currentNumber = "";
                UpdateMonitor();
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _numbers.Clear();
            _currentNumber = "";
            _history = "";
            _isDotPressed = false;
            _isEqualPressed = false;
            _sum = 0.0;
            _operator = MathOperator.None;

            History.Text = "";
            Monitor.Text = "";
        }
        public void UpdateMonitor()
        {
            Monitor.Text = _currentNumber;
            UpdateHistory();
        }
        public void UpdateHistory()
        {
            if (_history.Length > 0)
            {
                History.Text = _history;
            }
        }
        public void DoMath()
        {
            switch (_operator)
            {
                case MathOperator.Plus:
                    _sum = _numbers[0] + _numbers[1];
                    break;
                case MathOperator.Minus:
                    _sum = _numbers[0] - _numbers[1];
                    break;
                case MathOperator.Multiply:
                    _sum = _numbers[0] * _numbers[1];
                    break;
                case MathOperator.Divide:
                    _sum = _numbers[0] / _numbers[1];
                    break;
            }
            _currentNumber = _sum.ToString();
            if (_numbers.Count > 1)
            {
                _numbers[1] = _sum;
                _numbers.RemoveAt(0);
            }
            UpdateMonitor();
        }
    }
}