using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Defaults
    {
        public const int CellSize = 10;
        public const int AreaWidth = 80;
        public const int AreaHeight = 60;
        public const int FigureIndex = 0;
        public static readonly Color LiveColor = Color.Blue;
        public static readonly Color DeadColor = Color.Black;
        public static readonly Color AreaBackgroundColor = Color.LightGray;
        public static readonly Color GridColor = Color.Black;
        public static readonly Dictionary<string, byte[]> Figures = new Dictionary<string, byte[]>
        {
            { "Dot", GameOfLife.Properties.Resources.Dot },
            { "Gleiter", GameOfLife.Properties.Resources.Gleiter1 },
            { "Blinker", GameOfLife.Properties.Resources.Blinker},
            { "Uhr", GameOfLife.Properties.Resources.Uhr},
            { "Segler", GameOfLife.Properties.Resources.Segler},
            { "Pulsator", GameOfLife.Properties.Resources.Pulsator},
            { "Kroete", GameOfLife.Properties.Resources.Kroete},
            { "Oktagon", GameOfLife.Properties.Resources.Oktagon},
            { "r_Pentomino", GameOfLife.Properties.Resources.r_Pentomino},
            { "Bipole", GameOfLife.Properties.Resources.Bipole}
        };
    }
}
