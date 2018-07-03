using Controllers;
using Modelos;
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
using System.Windows.Shapes;

namespace WPFView
{
    /// <summary>
    /// Lógica interna para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RolamentoController rolamentoController = new RolamentoController();
            Rolamento rolamento = new Rolamento();


            cbInterno.ItemsSource = rolamentoController.ListarTodos();
            cbExterno.ItemsSource = rolamentoController.ListarTodos();
            cbLargura.ItemsSource = rolamentoController.ListarTodos();

        }

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void BtnVeiculo_Click(object sender, RoutedEventArgs e)

        {

            CadastroVeiculo cadVeic = new CadastroVeiculo();

            

            cadVeic.ShowDialog();

        }

        private void BtnRolamento_Click(object sender, RoutedEventArgs e)

        {

            MainWindow cadRol = new MainWindow();



            cadRol.ShowDialog();

        }

        private void BtnBuscarMedida_Click(object sender, RoutedEventArgs e)
        {

            

        }

        private void dtGrideRolamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
                RolamentoController rolamentoController = new RolamentoController();

                Rolamento a = (Rolamento)dtGrideRolamento.SelectedItem;

                       
        }
        private void dtGrideRolamento_Initialized(object sender, EventArgs e)
        {
            RolamentoController rolamentoController = new RolamentoController();

            Rolamento rolamento = new Rolamento();

            dtGrideRolamento.ItemsSource = rolamentoController.ListarTodos();
        }
    }
}
