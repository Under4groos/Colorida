using System;
using System.Collections.Generic;
using System.IO;
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

namespace Colorida
{
   
    public partial class MainWindow : Window
    {
        
      
     
        public MainWindow()
        {
            InitializeComponent();

            tonep.ColorChanged += (p, c) =>
            {
                //Console.WriteLine($"{p} {c}");

                pal.SetColor(c);
                pal.UpdateLastPosition();
            };
            pal.ColorChanged += (p, c) =>
            {
                Console.WriteLine($"{p} {c}");

                 

            };




        }
      
        

 
        
    }
}
