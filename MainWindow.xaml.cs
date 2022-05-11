using System.Windows;
using P2_Ap2_Melvin_2008_0385.UI.Registros;
using P2_Ap2_Melvin_2008_0385.UI.Consultas;

namespace P2_Ap2_Melvin_2008_0385
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistroProyectosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var rProyectos = new rProyectos();
            rProyectos.Show();
        }

        private void ConsultaProyectosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var cProyectos = new cProyectos();
            cProyectos.Show();
        }

        private void ConsultaTiposTareasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var cTiposTareas = new cTiposTareas();
            cTiposTareas.Show();
        }
    }
}
