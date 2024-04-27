using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Meres3
{
    public partial class Form1 : Form
    {
        private const string GetScreenValueCommand = ":VAL ?";
        
        private readonly SerialPort _serialPort = new SerialPort();
        private readonly Timer _timer = new Timer();
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly List<MeasuredValue> _measuredValues = new List<MeasuredValue>();

        private Unit _currentMode;
        private Unit? _nextMode = null;
        private FileStream _openFile = null;

        private bool IsSaving => _openFile != null;
        private bool IsModeChangeInProgress => _nextMode != null;

        public Form1()
        {
            InitializeComponent();
            InitializeSerialPort();
            _stopwatch.Start();
            
            _currentMode = Unit.KiloOhm;
            _chart.Series[0].ChartType = SeriesChartType.Line;
            _chart.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";
            _chart.ChartAreas[0].AxisX.Title = "seconds";
            _chart.ChartAreas[0].AxisY.Title = _currentMode.ToString();

            _toAuto.Click += (s, a) => _serialPort.WriteLine(_currentMode.GetCommand() + " 0");
            _toHalfButton.Click += (s, a) => _serialPort.WriteLine(_currentMode.GetCommand() + " 0.5");
            _toFiveButton.Click += (s, a) => _serialPort.WriteLine(_currentMode.GetCommand() + " 5");
            _isSavedCheckBox.CheckedChanged += (s, a) =>
            {
                if (_isSavedCheckBox.Checked)
                {
                    OnStartSavingToFile();
                    return;
                }
                OnStopSavingToFile();
            };
            _toResButton.Click += (s, a) => ChangeMode(Unit.KiloOhm);
            _toVoltButton.Click += (s, a) => ChangeMode(Unit.Volt);
            _timer.Tick += (s, a) => OnTick();
            
            _timer.Interval = 100;
            _timer.Start();
        }

        private void InitializeSerialPort()
        {
            _serialPort.PortName = "COM8";
            _serialPort.BaudRate = 9600;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;
            
            _serialPort.Open();
            _serialPort.WriteLine(_currentMode.GetCommand() + " 0");
        }

        private static string GenerateFileName() =>
            DateTime.Now
                .ToString(CultureInfo.InvariantCulture)
                .Replace(" ", "-")
                .Replace("/", "-")
                .Replace(":", "-") 
                + ".txt";

        private void OnStartSavingToFile()
        {
            _toResButton.Enabled = false;
            _toVoltButton.Enabled = false;
            _openFile = File.Open(GenerateFileName(), FileMode.Create);
            var info = new UTF8Encoding(true).GetBytes($"unit: {_currentMode.ToString()}\n\n");
            _openFile.Write(info, 0, info.Length);
            _measuredValues.Clear();
            _stopwatch.Restart();
        }

        private void OnStopSavingToFile()
        {
            _toResButton.Enabled = true;
            _toVoltButton.Enabled = true;
            _openFile?.Close();
            _openFile = null;
        }

        private void ChangeMode(Unit mode)
        {
            _nextMode = mode;
            _measuredValues.Clear();
            _chart.ChartAreas[0].AxisY.Title = mode.ToString();
        }
        private void OnTick()
        {
            if (IsModeChangeInProgress)
            {
                _currentMode = _nextMode.Value;
                _serialPort.WriteLine(_currentMode.GetCommand() + " 0");
                _nextMode = null;
                return;
            }

            _serialPort.WriteLine(GetScreenValueCommand);
            var value = _serialPort.ReadLine();
            _screenValueLabel.Text = value;

            var time = _stopwatch.Elapsed;
            string line;
            try
            {
                var valueDouble = double.Parse(value, CultureInfo.InvariantCulture);
                var measuredValue = new MeasuredValue(valueDouble, _currentMode, time.TotalSeconds);

                _measuredValues.Add(measuredValue);
                if (_measuredValues.Count > 100)
                {
                    _measuredValues.RemoveAt(0);
                }
                
                line = measuredValue.ToString();
            }
            catch (FormatException)
            {
                line = $"#, {time.TotalSeconds}\n";
            }
            
            _chart.Series[0].Points.DataBindXY(
                _measuredValues.Select(m => m.Seconds).ToList(), 
                _measuredValues.Select(m => m.Value).ToList());
            var buffer = new UTF8Encoding(true).GetBytes(line);
            _openFile?.Write(buffer, 0, buffer.Length);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _openFile?.Close();
        }
    }
}