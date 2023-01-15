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
        Plus=0, Minus, Multiply, Divide
    }
    public partial class MainWindow : Window
    {
        private List<double> _numbers;
        private string _currentNumber = "";
        private string _history = "";
        private bool _isDotPressed = false;
        private MathOperator _operator;
        private double _sum;
        public MainWindow()
        {
            InitializeComponent();
            _numbers = new List<double>();
        }
        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            _currentNumber += Seven.Content.ToString();
            UpdateMonitor();
        }
        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            _currentNumber += Eight.Content.ToString();
            UpdateMonitor();
        }
        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            _currentNumber += Nine.Content.ToString();
            UpdateMonitor();
        }
        private void Four_Click(object sender, RoutedEventArgs e)
        {
            _currentNumber += Four.Content.ToString();
            UpdateMonitor();
        }
        private void Five_Click(object sender, RoutedEventArgs e)
        {
            _currentNumber += Five.Content.ToString();
            UpdateMonitor();
        }
        private void Six_Click(object sender, RoutedEventArgs e)
        {
            _currentNumber += Six.Content.ToString();
            UpdateMonitor();
        }
        private void One_Click(object sender, RoutedEventArgs e)
        {
            _currentNumber += One.Content.ToString();
            UpdateMonitor();
        }
        private void Two_Click(object sender, RoutedEventArgs e)
        {
            _currentNumber += Two.Content.ToString();
            UpdateMonitor();
        }
        private void Three_Click(object sender, RoutedEventArgs e)
        {
            _currentNumber += Three.Content.ToString();
            UpdateMonitor();
        }
        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            _currentNumber += Zero.Content.ToString();
            UpdateMonitor();
        }
        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            if(!_isDotPressed)
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
            UpdateHistory();
            _operator = MathOperator.Plus;
        }
        public void DoMath()
        {
            switch(_operator)
            {
                case MathOperator.Plus:
                    _sum = _numbers[0] + _numbers[1];
                    break;
                case MathOperator.Minus:
                    break;
                case MathOperator.Multiply:
                    break;
                case MathOperator.Divide:
                    break;
            }
            _currentNumber = _sum.ToString();
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
        }
    }
}
