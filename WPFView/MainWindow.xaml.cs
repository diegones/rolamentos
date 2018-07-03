using Controller;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFView
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //cbModelo.IsEnabled = false;
        }

        private void BtnCadastrarRol_Click(object sender, RoutedEventArgs e)
        {
            try

            {
                RolamentoController rolamentoController = new RolamentoController();
                               
                if (string.IsNullOrEmpty(txtSku.Text))

                    throw new NullReferenceException("O campo SKU é obrigatório.");



                Rolamento rolamento = new Rolamento();

                
                rolamento.Sku = txtSku.Text;
                rolamento.Di = Convert.ToInt32(txtDi.Text);
                rolamento.Do = Convert.ToInt32(txtDo.Text);
                rolamento.W1 = Convert.ToInt32(txtW1.Text);
                rolamento.MarcaVeiculo = cbMarca.Text;
                rolamento.ModeloVeiculo = cbModelo.Text;

                rolamentoController.Incluir(rolamento);                        
                MessageBox.Show("Rolamento Salvo com sucesso!");
            }
     
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar (" + ex.Message + ")");
            }
        }

        private void BtnBuscarRol_Click (object sender, RoutedEventArgs e)
        {
            MainWindow cadRol = new MainWindow(); 

            cadRol.ShowDialog();
        }

        private void BtnCancelarRol_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            ;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           VeiculoController veiculoController = new VeiculoController();
            Veiculo veiculo = new Veiculo();
           

            cbMarca.ItemsSource = veiculoController.ListarTodos();
            cbModelo.ItemsSource = veiculoController.ListarPorNome(veiculo.Marca);

        }
        private void cbMarca_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
