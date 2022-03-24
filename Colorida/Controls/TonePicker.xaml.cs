using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Colorida.Controls
{
    /// <summary>
    /// Логика взаимодействия для TonePicker.xaml
    /// </summary>
    public partial class TonePicker : UserControl
    {
        BasePalette basePalette = new BasePalette();
        RenderControl renderControl;
        public Action<Point, Color> ColorChanged;

        public TonePicker()
        {
            InitializeComponent();
            InitializeComponent();
            this.Loaded += (o, e) =>
            {
                renderControl = new RenderControl(this);
                renderControl.Render();
            };
            this.SizeChanged += (o, e) =>
            {
                renderControl?.SizeUpdate();
                renderControl?.Render();
            };
            rcg.MouseMove += (o, e) =>
            {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    select(e);
                    _event();
                }
            };
            this.MouseDown += (o, e) =>
            {
                select(e);
                _event();
            };
        }
        void select(MouseEventArgs e)
        {
            basePalette.CURSOR_POSITION = e.GetPosition(rcg);
            basePalette.SELECT_COLOR_ARGB = renderControl.GetColorPoint(basePalette.CURSOR_POSITION);
            bc.Background = new SolidColorBrush(basePalette.SELECT_COLOR_ARGB);
        }
        void _event (){
            if (ColorChanged != null)
                ColorChanged(basePalette.CURSOR_POSITION, basePalette.SELECT_COLOR_ARGB);
        }
    }
}
