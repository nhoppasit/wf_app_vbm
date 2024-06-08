using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace ZedGraph_Real_time_Simulation {
    public partial class Sim3_by_task : Form {

        ZedGraphControl zgc;
        System.Windows.Forms.Label lbl;
        //  - - - - - - - - - 10,000 maximum number of point pair - - - - - - -//
        RollingPointPairList signal1 = new RollingPointPairList(1000);
        RollingPointPairList signal2 = new RollingPointPairList(100);
        RollingPointPairList signal3 = new RollingPointPairList(100);
        int pointPairCount;

        CancellationTokenSource cts = new CancellationTokenSource();

        public Sim3_by_task() {
            InitializeComponent();
            // - - - - - -- 
            this.WindowState = FormWindowState.Maximized;

            // - - - - - - Create label lbl to dock screen at the bottom  - - - - - - //
            lbl = new System.Windows.Forms.Label {
                Parent = this,
                Dock = DockStyle.Bottom,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // - - - -- - - create chart to plot - - - - - - -//
            zgc = new ZedGraphControl {
                Parent = this,
                Dock = DockStyle.Fill,
                Margin = new Padding(10)
            };

            // - -- -- - - custom - - - -//
            var myPane = zgc.GraphPane;
            myPane.Title.Text = "Test";
            myPane.XAxis.Title.Text = "X Value";
            myPane.YAxis.Title.Text = "Y Axis";
            myPane.XAxis.Scale.MaxAuto = true;

            // - - - - - - - - - - - three line a chasrt - - - - - - - - - - - - - - //
            //- - - - - - - - - - - - the signal(n) is the data input  - - - - - - -//
            var myCurve1 = myPane.AddCurve("Curve 1", signal1, Color.Blue, SymbolType.None);
            var myCurve2 = myPane.AddCurve("Curve 2", signal2, Color.Red, SymbolType.None);
            var myCurve3 = myPane.AddCurve("Curve 3", signal3, Color.Green, SymbolType.None);

            myCurve1.Symbol.Fill = new Fill(Color.White);
            myCurve1.Line.Width = 3;

            myCurve2.Symbol.Fill = new Fill(Color.White);
            myCurve2.Line.Width = 3;

            myCurve3.Symbol.Fill = new Fill(Color.White);
            myCurve3.Line.Width = 3;

            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);


            lbl.Click += (sender, arg) => {
                cts.Cancel();
                cts.Token.WaitHandle.WaitOne();
            };
        }

        int delay = 20;
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            // - - - - - - UPDATE LABEL that 1000 ms has number of point per sec - - - - //
            var t = new System.Timers.Timer { Interval = 1000 };
            t.Elapsed += (sender, eventargs) => {
                this.BeginInvoke(new Action(() => {
                    lbl.Text = "Dot per seconds: " + pointPairCount.ToString(); pointPairCount = 0;
                }));
            };
            t.Start();

            // - - - - - - เพื่อให้ Data ไม่แหว่ง ให้ดู flow 100 ms ขึ้นไป - - - - - - - //
            Task.Run(() => {
                var r = new Random();
                while (!cts.IsCancellationRequested) {
                    TimerEventProcessor();
                    Thread.Sleep(delay);
                };
            });

        }

        protected override void OnClosing(CancelEventArgs e) {
            cts.Cancel();
            cts.Token.WaitHandle.WaitOne();
            base.OnClosing(e);
        }

        Random rnd = new Random();
        Stopwatch sw = Stopwatch.StartNew();
        double freq = 0.1;
        double ampl = 2.0;
        double noiseSize = 1.0;
        double offset = 11.0;
        void TimerEventProcessor() {
            double y1 = 0;
            double y2 = 0;
            double y3 = 0;
            double x = sw.Elapsed.TotalSeconds;
            pointPairCount++;
            y1 = offset + ampl * Math.Cos(2 * Math.PI * freq * x) + noiseSize * rnd.NextDouble();
            y2 = offset + ampl * Math.Sin(2 * Math.PI * freq * x);
            y3 = offset + ampl * Math.Sin(2 * Math.PI * freq * x) + ampl / 3 * Math.Sin(2 * Math.PI * freq * 5 * x); ;
            signal1.Add(x, y1);
            signal2.Add(x, y2);
            signal3.Add(x, y3);
            var xaxis = zgc.GraphPane.XAxis;
            xaxis.Scale.Min = signal1[0].X;
            xaxis.Scale.Max = signal1[signal1.Count - 1].X;
            zgc.AxisChange();
            zgc.Invalidate();
        }
    }
}
