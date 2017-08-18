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
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace OverlayMemes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

        public MainWindow()
        {
            InitializeComponent();

            Burrito burrito = new Burrito();
            stkPanel.Children.Add(burrito);

            Process[] processes = Process.GetProcessesByName("EtG");
            foreach (Process p in processes)
            {
                if (p != null)
                {
                    RECT rect = new RECT();
                    GetWindowRect(p.MainWindowHandle, ref rect);
                    Point location = new Point(rect.Left, rect.Top);
                    Size size = new Size(rect.Right - rect.Left, rect.Bottom - rect.Top);
                    this.Width = size.Width;
                    this.Height = size.Height;
                    this.Left = location.X;
                    this.Top = location.Y ;
                }
            }
        }
    }
}
