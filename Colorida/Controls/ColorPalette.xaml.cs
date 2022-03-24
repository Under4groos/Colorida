using System;
using System.Collections.Generic;

using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
// using System.Drawing;
namespace Colorida.Controls
{
    /// <summary>
    /// Логика взаимодействия для ColorPalette.xaml
    /// </summary>
    public partial class ColorPalette : UserControl 
    {

        public Action<Point, Color> ColorChanged;

        RenderControl renderControl;
        BasePalette basePalette = new BasePalette();

        public void SetColor(Color c)
        {
            basePalette.COLOR_ARGB = c;

            gr_l.Color = basePalette.COLOR_ARGB;
        }

        public ColorPalette()
        {
            InitializeComponent();
            this.Loaded += (o, e) =>
            {
                renderControl = new RenderControl(render_);
                renderControl.Render();
            };

            this.SizeChanged += (o, e) =>
            {
               
            };
            this.MouseDown += (o, e) =>
            {
                select(e);
                _event();
            };
            this.MouseMove += (o, e) =>
            {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    select(e);
                    _event();
                }
            };
        }
        public void UpdateRender()
        {
            renderControl?.SizeUpdate();
            renderControl?.Render();
        }
        void select(MouseEventArgs e)
        {
            basePalette.CURSOR_POSITION = e.GetPosition(this);
            basePalette.SELECT_COLOR_ARGB = renderControl.GetColorPoint(basePalette.CURSOR_POSITION);

            cursor.SetPos((int)basePalette.CURSOR_POSITION.X, (int)basePalette.CURSOR_POSITION.Y);
        }
        public void UpdateLastPosition()
        {
            UpdateRender();
            basePalette.SELECT_COLOR_ARGB = renderControl.GetColorPoint(basePalette.CURSOR_POSITION);
            cursor.SetPos((int)basePalette.CURSOR_POSITION.X, (int)basePalette.CURSOR_POSITION.Y);
            _event();
        }
        void _event()
        {
            bc.Background = new SolidColorBrush(basePalette.SELECT_COLOR_ARGB);

            if (ColorChanged != null)
                ColorChanged(basePalette.CURSOR_POSITION, basePalette.SELECT_COLOR_ARGB);
        }
    }
}
