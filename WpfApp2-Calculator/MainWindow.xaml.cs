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
        Plus=0, Minus, Multiply, Divide, None
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
        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            if(_isEqualPressed)
            {
                Clear_Click(sender, e);
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
            _currentNumber += Eight.Content.ToString();
            UpdateMonitor();
        }
        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
            }
            _currentNumber += Nine.Content.ToString();
            UpdateMonitor();
        }
        private void Four_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
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
            _currentNumber += Five.Content.ToString();
            UpdateMonitor();
        }
        private void Six_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
            }
            _currentNumber += Six.Content.ToString();
            UpdateMonitor();
        }
        private void One_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
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
            _currentNumber += Two.Content.ToString();
            UpdateMonitor();
        }
        private void Three_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
            }
            _currentNumber += Three.Content.ToString();
            UpdateMonitor();
        }
        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            if (_isEqualPressed)
            {
                Clear_Click(sender, e);
            }
            _currentNumber += Zero.Content.ToString();
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
                _currentNumber += Dot.Content.ToString();
                UpdateMonitor();
                _isDotPressed = true;
            }
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
        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (_currentNumber.Length > 0)
            {
                _currentNumber = _currentNumber.Remove(_currentNumber.Length - 1);
                UpdateMonitor();
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
        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (_isDotPressed)
            {
                double temp;
                if(double.TryParse(_currentNumber,out temp))
                {
                    _numbers.Add(temp);
                    _history += temp + "+";
                    _currentNumber = "";
                }
            }
            else
            {
                int temp;
                if (int.TryParse(_currentNumber, out temp))
                {
                    _numbers.Add(temp);
                    _history += temp + "+";
                    _currentNumber = "";
                }
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
        public void DoMath()
        {
            switch(_operator)
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
            _numbers[1] = _sum;
            _numbers.RemoveAt(0);
            UpdateMonitor();
        }
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (_isDotPressed)
            {
                double temp;
                if (double.TryParse(_currentNumber, out temp))
                {
                    _numbers.Add(temp);
                    _history += temp + "=";
                    _currentNumber = "";
                }
            }
            else
            {
                int temp;
                if (int.TryParse(_currentNumber, out temp))
                {
                    _numbers.Add(temp);
                    _history += temp + "=";
                    _currentNumber = "";
                }
            }
            UpdateHistory();
            DoMath();
            _currentNumber = "";
            _isEqualPressed = true;
            _operator = MathOperator.None;
        }
        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (_isDotPressed)
            {
                double temp;
                if (double.TryParse(_currentNumber, out temp))
                {
                    _numbers.Add(temp);
                    _history += temp + "-";
                    _currentNumber = "";
                }
            }
            else
            {
                int temp;
                if (int.TryParse(_currentNumber, out temp))
                {
                    _numbers.Add(temp);
                    _history += temp + "-";
                    _currentNumber = "";
                }
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
            if (_isDotPressed)
            {
                double temp;
                if (double.TryParse(_currentNumber, out temp))
                {
                    _numbers.Add(temp);
                    _history += temp + "*";
                    _currentNumber = "";
                }
            }
            else
            {
                int temp;
                if (int.TryParse(_currentNumber, out temp))
                {
                    _numbers.Add(temp);
                    _history += temp + "*";
                    _currentNumber = "";
                }
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
            if (_isDotPressed)
            {
                double temp;
                if (double.TryParse(_currentNumber, out temp))
                {
                    _numbers.Add(temp);
                    _history += temp + "/";
                    _currentNumber = "";
                }
            }
            else
            {
                int temp;
                if (int.TryParse(_currentNumber, out temp))
                {
                    _numbers.Add(temp);
                    _history += temp + "/";
                    _currentNumber = "";
                }
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
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _numbers.Clear();
            _currentNumber = "";
            _history = "";
            _isDotPressed = false;
            _sum = 0.0;
            _operator = MathOperator.None;

            History.Text = "";
            Monitor.Text = "";
        }
    }
}
