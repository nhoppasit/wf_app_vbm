﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace ZedGraph_Real_time_Simulation
{
    public class ZedGraphManager
    {
        private readonly ZedGraphControl _zedGraphControl;
        private readonly Random _rnd = new Random();
        private readonly RollingPointPairList _voltage = new RollingPointPairList(1000);
        private readonly RollingPointPairList _movingAverageVoltage = new RollingPointPairList(100);
        private readonly RollingPointPairList _current = new RollingPointPairList(100);
        private readonly RollingPointPairList _maxValue = new RollingPointPairList(1000);
        private readonly RollingPointPairList _minValue = new RollingPointPairList(1000);

        public ZedGraphManager(ZedGraphControl zedGraphControl)
        {
            _zedGraphControl = zedGraphControl;
        }

        public void ConfigureGraph()
        {
            var myPane = _zedGraphControl.GraphPane;
            myPane.Title.Text = "IV-Curve Test (In Nhop Project)";
            myPane.XAxis.Title.Text = "Time (seconds)";
            myPane.YAxis.Title.Text = "Voltage (V)";
            myPane.Y2Axis.Title.Text = "Current (I)";
            myPane.XAxis.Scale.MaxAuto = true;
            myPane.Y2AxisList[0].IsVisible = true;

            ConfigureCurves(myPane);

            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
        }

        private void ConfigureCurves(GraphPane myPane)
        {
            var curveConfigs = CurveConfigurationFactory.GetCurveConfigurations();

            foreach (var config in curveConfigs)
            {
                var curve = myPane.AddCurve(config.Label, GetPointPairList(config.Type), config.Color, config.SymbolType);
                curve.YAxisIndex = config.YAxisIndex;
                ConfigureCurveAppearance(curve);
            }
        }
        private RollingPointPairList GetPointPairList(CurveType type)
        {
            if (type == CurveType.Voltage)
                return _voltage;
            else if (type == CurveType.MovingAverage)
                return _movingAverageVoltage;
            else if (type == CurveType.Current) 
                return _current;
            else if (type == CurveType.MinValue)
                return _minValue;
            else if (type == CurveType.MaxValue) 
                return _maxValue;
            else
                throw new ArgumentOutOfRangeException(nameof(type), "Invalid curve type.");
        }

        private static void ConfigureCurveAppearance(LineItem curve)
        {
            curve.Symbol.Fill = new Fill(Color.White);
            curve.Line.Width = 3;
        }

        public async Task TimerEventProcessor(Stopwatch sw)
        {
             await Task.Run(() =>
            {
                double y1, y2, y3, yMax, yMin;
                double x = sw.Elapsed.TotalSeconds;

                (x, y1, y2, y3, yMax, yMin) = GenerateData(x);

                _maxValue.Add(x, yMax);
                _minValue.Add(x, yMin);
                _voltage.Add(x, y1);
                _movingAverageVoltage.Add(x, y2);
                _current.Add(x, y3);

                UpdateAxes();

                _zedGraphControl.AxisChange();
                _zedGraphControl.Invalidate();
            });
        }

        private (double x, double y1, double y2, double y3, double yMax, double yMin) GenerateData(double x)
        {
            double freq = 0.1;
            double ampl = 2.0;
            double noiseSize = 1.0;
            double offset = 11.0;

            double y1 = offset + ampl * Math.Cos(2 * Math.PI * freq * x) + noiseSize * _rnd.NextDouble();
            double y2 = offset + ampl * Math.Sin(2 * Math.PI * freq * x);
            double y3 = offset + ampl * Math.Sin(2 * Math.PI * freq * x) + ampl / 3 * Math.Sin(2 * Math.PI * freq * 5 * x);
            double yMax = 15;
            double yMin = 10;

            return (x, y1, y2, y3, yMax, yMin);
        }

        private void UpdateAxes()
        {
            var xaxis = _zedGraphControl.GraphPane.XAxis;
            xaxis.Scale.Min = _voltage[0].X;
            xaxis.Scale.Max = _voltage[_voltage.Count - 1].X;
        }

        public void Clear()
        {
            _zedGraphControl.GraphPane.CurveList.Clear();
            _zedGraphControl.GraphPane.GraphObjList.Clear();
            _zedGraphControl.Invalidate();
        }
    }
}
