using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Colorida.Controls
{
    internal class MBorder : Border
    {
        public void SetPos(int x , int y)
        {
            this.Margin = new System.Windows.Thickness(x - this.Width/2 , y - this.Height/2 , 0, 0);
        }
        public MBorder()
        {
            set();
            this.BorderThickness = new System.Windows.Thickness(1);
            this.BorderBrush = Brushes.White;
            this.SizeChanged += (o, e) =>
            {
                set();
            };
        }
        void set()
        {
            double r = (this.ActualWidth + this.ActualHeight) / 2;
            this.CornerRadius = new System.Windows.CornerRadius(r);
        }
    }
}
