using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace ZedGraph_Real_time_Simulation
{
    public class CurveConfigurationFactory
    {
        public static List<CurveConfiguration> GetCurveConfigurations()
        {
            return new List<CurveConfiguration>
        {
            new CurveConfiguration { Type = CurveType.Voltage, Label = "Voltage (V)", Color = Color.Blue, SymbolType = SymbolType.None, YAxisIndex = 0 },
            new CurveConfiguration { Type = CurveType.MovingAverage, Label = "Moving Average Voltage (Vbar)", Color = Color.Red, SymbolType = SymbolType.None, YAxisIndex = 0 },
            new CurveConfiguration { Type = CurveType.MaxValue, Label = "Max Value (V)", Color = Color.Black, SymbolType = SymbolType.None, YAxisIndex = 0 },
            new CurveConfiguration { Type = CurveType.MinValue, Label = "Min Value (V)", Color = Color.Bisque, SymbolType = SymbolType.None, YAxisIndex = 0 },
            new CurveConfiguration { Type = CurveType.Current, Label = "Current (i)", Color = Color.Green, SymbolType = SymbolType.None, YAxisIndex = 1 }
        };
        }
    }
}
