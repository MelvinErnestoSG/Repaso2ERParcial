using P2_Ap2_Melvin_2008_0385.BLL;
using P2_Ap2_Melvin_2008_0385.Entidades;
using System.Collections.Generic;
using System.Windows;

namespace P2_Ap2_Melvin_2008_0385.UI.Registros
{
    /// <summary>
    /// Interaction logic for rProyectos.xaml
    /// </summary>
    public partial class rProyectos : Window
    {
        private Proyectos proyecto = new();

        public rProyectos()
        {
            InitializeComponent();
            this.DataContext = proyecto;

            //Llenando The ComboBox
            TipotareasComboBox.ItemsSource = TiposTareasBLL.GetTiposTareas();
            TipotareasComboBox.SelectedValuePath = "TipoId";
            TipotareasComboBox.DisplayMemberPath = "TipoTarea";
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = proyecto;
        }

        private void Limpiar()
        {
            ProyectoIdTextBox.Text = "0";
            DetalleDataGrid.ItemsSource = new List<ProyectosDetalle>();
            Actualizar();
        }

        private bool ExisteBD()
        {
            Proyectos esValido = ProyectosBLL.Buscar(proyecto.ProyectoId);
            return esValido != null;
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            _ = new ProyectosDetalle
            {
                ProyectoId = proyecto.ProyectoId,
                TiposTareas = (TiposTareas)TipotareasComboBox.SelectedItem
            };

            Actualizar();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var Buscado = ProyectosBLL.Buscar(proyecto.ProyectoId);

            if (Buscado != null)
            {
                proyecto = Buscado;
                Actualizar();
                MessageBox.Show("Fue Encontrado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No Fue Encontrado.", "Fallo.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {

            if (DetalleDataGrid.Items.Count > 0 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                
                DetalleDataGrid.Columns.Clear();
                Limpiar();
            }
            else
            {
                proyecto.ProyectoDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Actualizar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!string.IsNullOrWhiteSpace(ProyectoIdTextBox.Text = "0"))
            {
                paso = ProyectosBLL.Guardar(proyecto);
            }
            else
            {
                if (ExisteBD())
                {
                    MessageBox.Show("No se puede Modificar porque no existe.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (paso)
            {
                Actualizar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallo al guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProyectosBLL.Eliminar(Utilidades.ToInt(ProyectoIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show(ProyectoIdTextBox.Text, "No se puede eliminar por que no existe.");
        }
    }
}
