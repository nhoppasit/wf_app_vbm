using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ZedGraph_Real_time_Simulation {
    public partial class ZedGraphRealTimeSimulationForm : Form {

        const int pointCount = 100_000;
        double[] xs = new double[pointCount];
        double[] ys1 = new double[pointCount];
        double[] ys2 = new double[pointCount];
        Stopwatch sw = Stopwatch.StartNew();

        public ZedGraphRealTimeSimulationForm() {
            InitializeComponent();

            AttachFormEvent();
        }

        void AttachFormEvent() {

            FormClosed += (sender, args) => {
                timerDataUpdate?.Stop();
                timerChartUpdate?.Stop();
            };

            timerDataUpdate.Interval = 50;
            timerChartUpdate.Interval = 10;

            timerDataUpdate.Tick += (sender, args) => {
                UpdateData();
            };

            timerChartUpdate.Tick += (sender, args) => {
                UpdateChart();
            };

            btnRun.Click += (sender, args) => {
                timerDataUpdate?.Start();
                timerChartUpdate?.Start();
            };

            btnStop.Click += (sender, args) => {
                timerDataUpdate?.Stop();
                timerChartUpdate?.Stop();
            };
        }

        int nextValueIndex = -1;
        Random rnd = new Random();
        void UpdateData() {
            double x = sw.Elapsed.TotalSeconds;
            double y1 = rnd.NextDouble() * 100;

            nextValueIndex = (nextValueIndex < ys1.Length - 1) ? nextValueIndex + 1 : 0;
            if (nextValueIndex == 0) {
                sw.Restart();
                x = 0;
            }
            xs[nextValueIndex] = x;
            ys1[nextValueIndex] = y1;
        }

        void UpdateChart() {

            // clear old curves
            zedGraphControl1.GraphPane.CurveList.Clear();

            // plot the data as curves
            var curve1 = zedGraphControl1.GraphPane.AddCurve("Series A", xs, ys1, Color.Blue);
            curve1.Line.IsAntiAlias = true;
            curve1.Symbol.IsVisible = false;

            var curve2 = zedGraphControl1.GraphPane.AddCurve("Series B", xs, ys2, Color.Red);
            curve2.Line.IsAntiAlias = true;
            curve2.Symbol.IsVisible = false;

            // style the plot
            zedGraphControl1.GraphPane.Title.Text = $"Scatter Plot ({pointCount:n0} points)";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Horizontal Axis Label";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Vertical Axis Label";

            // auto-axis and update the display
            zedGraphControl1.GraphPane.XAxis.ResetAutoScale(zedGraphControl1.GraphPane, CreateGraphics());
            zedGraphControl1.GraphPane.YAxis.ResetAutoScale(zedGraphControl1.GraphPane, CreateGraphics());
            zedGraphControl1.Refresh();
        }

    }
}
