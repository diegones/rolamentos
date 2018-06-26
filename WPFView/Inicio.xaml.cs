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


    }
}
