using CalculateMVVM.ViewModels;
using System.Windows;

namespace CalculateMVVM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();

            closeButton.Click += (s, e) => { this.Close(); };

            minimizeButton.Click += (s, e) => { this.WindowState = WindowState.Minimized; };

            dragMove.MouseDown += (s, e) => 
            {
                if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                    this.DragMove();
            };
        }
    }
}
