﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace ZedGraph_Real_time_Simulation {
    public partial class Sim2_by_task : Form {

        ZedGraphControl zgc;
        System.Windows.Forms.Label lbl;
        RollingPointPairList samp = new RollingPointPairList(105);
        int c;

        CancellationTokenSource cts = new CancellationTokenSource();

        public Sim2_by_task() {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            lbl = new System.Windows.Forms.Label { Parent = this, Dock = DockStyle.Bottom, AutoSize = false, TextAlign = ContentAlignment.MiddleCenter };
            zgc = new ZedGraphControl {
                Parent = this,
                Dock = DockStyle.Fill,
                Margin = new Padding(10)
            };

            var myPane = zgc.GraphPane;
            myPane.Title.Text = "Test";
            myPane.XAxis.Title.Text = "X Value";
            myPane.YAxis.Title.Text = "Y Axis";
            myPane.XAxis.Scale.MaxAuto = true;

            var myCurve = myPane.AddCurve("Curve 1", samp, Color.Blue, SymbolType.XCross);
            myCurve.Symbol.Fill = new Fill(Color.White);
            myCurve.Line.Fill = new Fill(Color.White, Color.Blue);

            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            var t = new System.Timers.Timer { Interval = 1000 };
            t.Elapsed += (sender, eventargs) => { this.BeginInvoke(new Action(() => { lbl.Text = "Dot per seconds: " + c.ToString(); c = 0; })); };
            t.Start();

            Task.Run(() => {
                var r = new Random();
                while (!cts.IsCancellationRequested) {
                    TimerEventProcessor(r.Next(-10, 10));
                };
            });

        }

        protected override void OnClosing(CancelEventArgs e) {
            cts.Cancel();
            cts.Token.WaitHandle.WaitOne();
            base.OnClosing(e);
        }

        int x1 = 0;

        void TimerEventProcessor(int d) {
            x1++; c++;
            samp.Add(d, x1);
            zgc.AxisChange();
            zgc.Invalidate();
        }
    }
}
