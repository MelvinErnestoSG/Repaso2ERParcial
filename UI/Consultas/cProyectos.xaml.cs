using P2_Ap2_Melvin_2008_0385.BLL;
using P2_Ap2_Melvin_2008_0385.Entidades;
using System;
using System.Collections.Generic;
using System.Windows;

namespace P2_Ap2_Melvin_2008_0385.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cTiposTareas.xaml
    /// </summary>
    public partial class cProyectos : Window
    {
        public cProyectos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<TiposTareas>();

            if (FiltroTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = TiposTareasBLL.GetList(e => e.TipoId == Utilidades.ToInt(FiltroComboBox.Text));
                        break;

                    case 1:
                        listado = TiposTareasBLL.GetList(e => e.TipoTarea.ToLower().Contains(FiltroTextBox.Text.ToLower()));
                        break;

                    case 2:
                        listado = TiposTareasBLL.GetList(e => e.Requerimiento.ToLower().Contains(FiltroTextBox.Text.ToLower()));
                        break;

                    case 3:
                        listado = TiposTareasBLL.GetList(e => e.Tiempo == Utilidades.ToInt(FiltroTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = TiposTareasBLL.GetList(p => true);
            }

            DatosDataDrid.ItemsSource = null;
            DatosDataDrid.ItemsSource = listado;
        }
    }
}