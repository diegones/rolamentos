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
        public CadastroVeiculo()
        {
            InitializeComponent();
        }

        private void BtnCadastrarVeic_Click(object sender, RoutedEventArgs e)
        {
            try

            {
                VeiculoController veiculoController = new VeiculoController();

                if (string.IsNullOrEmpty(txtMarca.Text))

                    throw new NullReferenceException("O campo SKU é obrigatório.");

                Veiculo veiculo = new Veiculo();

                veiculo.Marca = txtMarca.Text;
                veiculoController.Incluir(veiculo);
                MessageBox.Show("Veiculo Salvo com sucesso!");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar (" + ex.Message + ")");
            }
        }
    }
}
