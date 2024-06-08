using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace ZedGraph_Real_time_Simulation
{
    public partial class Store : Form
    {
        private readonly ZedGraphControl _zedGraphControl;
        private readonly ZedGraphHelper _zedGraphHelper;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly Stopwatch _sw = Stopwatch.StartNew();
        private int _pointPairCount;
        private bool _flagThreading;
        public Store()
        {
            InitializeComponent();

            _zedGraphControl = zedGraphTest;
            _zedGraphHelper = new ZedGraphHelper(_zedGraphControl);
            _zedGraphHelper.ConfigureGraph();

            panelZedPlot.Click += (sender, arg) =>
            {
                _cts.Cancel();
                _cts.Token.WaitHandle.WaitOne();
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _cts.Cancel();
            _cts.Token.WaitHandle.WaitOne();
            base.OnClosing(e);
        }

        private void UpdateLabels()
        {
            var t = new System.Timers.Timer { Interval = 1000 };
            t.Elapsed += (sender, eventargs) =>
            {
                this.BeginInvoke(new Action(() =>
                {
                    panelZedPlot.Text = $"Dot per seconds: {_pointPairCount}"; _pointPairCount = 0;
                }));
            };
            t.Start();
        }

        private async Task UpdateDataAsync()
        {
            while (!_cts.IsCancellationRequested)
            {
                if (_flagThreading)
                {
                    _zedGraphHelper.TimerEventProcessor(_sw);
                    _pointPairCount++;
                    await Task.Delay(20);
                }
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            _flagThreading = true;
            UpdateLabels();
            await UpdateDataAsync();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _flagThreading = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _zedGraphHelper.Clear();
        }
    }
}
