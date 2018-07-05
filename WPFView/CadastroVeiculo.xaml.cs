using Controller;
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
    /// Lógica interna para CadastroVeiculo.xaml
    /// </summary>
    public partial class CadastroVeiculo : Window

        
    {
        Veiculo veicTemp = new Veiculo();
        IList<Veiculo> listaVeiculos = new List<Veiculo>();
        VeiculoController veiculoController = new VeiculoController();

    public CadastroVeiculo()
        {   
            InitializeComponent();
        
        }

        private void BtnCadastrarVeic_Click(object sender, RoutedEventArgs e)
        {
           try

            {
                VeiculoController veiculoController = new VeiculoController();
            Veiculo veiculo = new Veiculo();
                if (string.IsNullOrEmpty(txtMarca.Text))
                
            throw new NullReferenceException("ALOWWW!!! Os campos marca e modelo são obrigatórios.");
                if (string.IsNullOrEmpty(txtModelo.Text))

                throw new NullReferenceException("ALOWWWW!!! Os campos marca e modelo são obrigatórios.");

                veiculo.Marca = txtMarca.Text;
                veiculo.Modelo = txtModelo.Text;
                
                veiculoController.Incluir(veiculo);
        
                MessageBox.Show("Você é Demais! Veiculo Salvo com sucesso!");

                dtGrideVeiculos.ItemsSource = veiculoController.ListarTodos();
                txtMarca.Text = "";
                txtModelo.Text = "";
            }

            catch (Exception ex)
            {
                MessageBox.Show("tsc tsc tsc Erro ao salvar (" + ex.Message + ")");
            }
      
        }
        private void BtnAtualizarVeic_Click (object sender, RoutedEventArgs e)
        {
            veicTemp.Marca = txtMarca.Text;
            veicTemp.Modelo = txtModelo.Text;
            veiculoController.Editar(veicTemp);

            dtGrideVeiculos.ItemsSource = veiculoController.ListarTodos();
            txtMarca.Text = "";
            txtModelo.Text = "";

            MessageBox.Show("Boaaa...Veículo atualizado com sucesso");

            BtnDeletarVeic.IsEnabled = false;
            BtnAtualizarVeic.IsEnabled = false;
            BtnCadastrarVeic.IsEnabled = true;
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Inicio inicio = new Inicio();
            this.Close();
            inicio.ShowDialog();
        }

        private void dtGrideVeiculos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            veicTemp = (Veiculo)dtGrideVeiculos.SelectedItem;

            if(veicTemp != null)
            {
                txtMarca.Text = veicTemp.Marca;
                txtModelo.Text = veicTemp.Modelo;

                BtnDeletarVeic.IsEnabled = true;
                BtnAtualizarVeic.IsEnabled = true;
                BtnCadastrarVeic.IsEnabled = false;
            }
        }

        private void dtGrideVeiculos_Initialized(object sender, EventArgs e)
        {
            VeiculoController veiculoController   = new VeiculoController();

            Veiculo veiculo = new Veiculo();


            dtGrideVeiculos.ItemsSource = veiculoController.ListarTodos();

        }

        private void BtnDeletarVeic_Click(object sender, RoutedEventArgs e)
        {
          
            veiculoController.Excluir (veicTemp.IdVeiculo);
            dtGrideVeiculos.UnselectAllCells();
            txtMarca.Text = "";
            txtModelo.Text = "";

            dtGrideVeiculos.ItemsSource = veiculoController.ListarTodos();

            BtnDeletarVeic.IsEnabled = false;
            BtnAtualizarVeic.IsEnabled = false;
            BtnCadastrarVeic.IsEnabled = true;

            MessageBox.Show("Xo Lata velha! Sai pra lá! Exclusão efetuada com sucesso");

          
        }
    }
}
