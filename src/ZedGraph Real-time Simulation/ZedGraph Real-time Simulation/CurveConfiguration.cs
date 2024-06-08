using System.Drawing;
using ZedGraph;

namespace ZedGraph_Real_time_Simulation
{
    public class CurveConfiguration
    {
        public CurveType Type { get; set; }
        public string Label { get;set; }
        public Color Color { get; set; }
        public SymbolType SymbolType { get; set; }
        public int YAxisIndex { get; set; }
    }
}