using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace IntershipExamProject {
    public partial class TestZed : Form {
        ZedGraphControl zgc;
        System.Windows.Forms.Label lbl;
        //  - - - - - - - - - 10,000 maximum number of point pair - - - - - - -//
        RollingPointPairList voltage = new RollingPointPairList(1000);
        RollingPointPairList movingAverageVoltage = new RollingPointPairList(100);
        RollingPointPairList current = new RollingPointPairList(100);
        int pointPairCount;

        CancellationTokenSource cts = new CancellationTokenSource();
        public TestZed() {
            InitializeComponent();

            // - -- -- - - custom - - - -//
            var myPane = zedGraphTest.GraphPane;
            myPane.Title.Text = "IV-Curve Test";
            myPane.XAxis.Title.Text = "Voltage (V)";
            myPane.X2Axis.Title.Text = "Current (I)";
            myPane.YAxis.Title.Text = "Time (seconds";
            myPane.XAxis.Scale.MaxAuto = true;

            // - - - - - - - - - - - three line a chasrt - - - - - - - - - - - - - - //
            //- - - - - - - - - - - - the signal(n) is the data input  - - - - - - -//
            var myCurve1 = myPane.AddCurve("Voltage (V)", voltage, Color.Blue, SymbolType.None);
            myCurve1.YAxisIndex = 0;
            var myCurve2 = myPane.AddCurve("Moving Average Voltage (Vbar)", movingAverageVoltage, Color.Red, SymbolType.None);
            myCurve2.YAxisIndex = 1;
            var myCurve3 = myPane.AddCurve("Current (i)", current, Color.Green, SymbolType.None);
            myCurve3.YAxisIndex = 2;

            myCurve1.Symbol.Fill = new Fill(Color.White);
            myCurve1.Line.Width = 3;

            myCurve2.Symbol.Fill = new Fill(Color.White);
            myCurve2.Line.Width = 3;

            myCurve3.Symbol.Fill = new Fill(Color.White);
            myCurve3.Line.Width = 3;

            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);


            //lbl.Click += (sender, arg) => {
            //    cts.Cancel();
            //    cts.Token.WaitHandle.WaitOne();
            //};
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
            voltage.Add(x, y1);
            movingAverageVoltage.Add(x, y2);
            current.Add(x, y3);
            var xaxis = zgc.GraphPane.XAxis;
            xaxis.Scale.Min = voltage[0].X;
            xaxis.Scale.Max = voltage[voltage.Count - 1].X;
            zgc.AxisChange();
            zgc.Invalidate();
        }
    }
}
