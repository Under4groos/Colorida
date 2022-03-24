using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Colorida.Controls
{
    public class BasePalette
    {
        public Color COLOR_ARGB
        {
            get; set;
        }
        public Color SELECT_COLOR_ARGB
        {
            get; set;
        }
        public Point CURSOR_POSITION
        {
            get;set;
        } = new Point(0, 0);
         
    }
}
