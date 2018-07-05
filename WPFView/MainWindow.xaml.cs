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

        RolamentoController rolamentoController = new RolamentoController();
        VeiculoController veiculoContorller = new VeiculoController();
        IList<Veiculo> listaVeiculos = new List<Veiculo>();
        Rolamento rolTemp = new Rolamento();

        public MainWindow()
        {
            InitializeComponent();

            listaVeiculos = veiculoContorller.ListarTodos();

            //cbModelo.IsEnabled = false;
            cbMarca.ItemsSource = listaVeiculos;
        }

        private void dtGridRolamentos_Initialized(object sender, EventArgs e)
        {
            RolamentoController rolamentoController = new RolamentoController();

            Rolamento rolamento = new Rolamento();

           dtGridRolamentos.ItemsSource = rolamentoController.ListarTodos();
        }

        private void dtGridRolamentos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rolTemp = (Rolamento)dtGridRolamentos.SelectedItem;

            if (rolTemp != null)
            {
                txtSku.Text = rolTemp.Sku;
                txtDi.Text = rolTemp.Di.ToString();
                txtDo.Text = rolTemp.Do.ToString();
                txtW1.Text = rolTemp.W1.ToString();
                cbMarca.Text = rolTemp.MarcaVeiculo;
                cbModelo.Text = rolTemp.ModeloVeiculo;

                BtnDeletarRol.IsEnabled = true;
                BtnAtualizarRol.IsEnabled = true;
                BtnCadastrarRol.IsEnabled = false;
            }
        }

        private void BtnCadastrarRol_Click(object sender, RoutedEventArgs e)
        {
            try

            {

                if (string.IsNullOrEmpty(txtSku.Text) || string.IsNullOrEmpty(txtDi.Text) ||
                    string.IsNullOrEmpty(txtDo.Text) || string.IsNullOrEmpty(txtW1.Text) ||
                    string.IsNullOrEmpty(cbMarca.Text) || string.IsNullOrEmpty(cbModelo.Text))

                    throw new NullReferenceException("ABRE O OLHO!! Todos os campos devem ser preenchidos, VERIFIQUE!");



                Rolamento rolamento = new Rolamento();


                rolamento.Sku = txtSku.Text;
                rolamento.Di = Convert.ToInt32(txtDi.Text);
                rolamento.Do = Convert.ToInt32(txtDo.Text);
                rolamento.W1 = Convert.ToInt32(txtW1.Text);
                rolamento.MarcaVeiculo = cbMarca.Text;
                rolamento.ModeloVeiculo = cbModelo.Text;

                rolamentoController.Incluir(rolamento);
                MessageBox.Show("Rolamento Salvo com sucesso!");
                txtSku.Text = "";
                txtDi.Text = "";
                txtDo.Text = "";
                txtW1.Text = "";
                cbMarca.Text = "";
                cbModelo.Text = "";
                dtGridRolamentos.ItemsSource = rolamentoController.ListarTodos();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar (" + ex.Message + ")");
            }
        }


        private void BtnDeletar_Click (object sender, RoutedEventArgs e)
        {
      

            rolamentoController.Excluir(rolTemp.Id);
            dtGridRolamentos.UnselectAllCells();
            txtSku.Text = "";
            txtDi.Text = "";
            txtDo.Text = "";
            txtW1.Text = "";
            cbMarca.Text = "";
            cbModelo.Text = "";

        
            dtGridRolamentos.ItemsSource = rolamentoController.ListarTodos();
            BtnDeletarRol.IsEnabled = false;
            BtnAtualizarRol.IsEnabled = false;
            BtnCadastrarRol.IsEnabled = true;

            MessageBox.Show("Exclusão efetuada com sucesso");
        }
        

        private void BtnVoltarRol_Click(object sender, RoutedEventArgs e)
        {

            Inicio inicio = new Inicio();
            this.Close();
            inicio.ShowDialog();



        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //VeiculoController veiculoController = new VeiculoController();
            //Veiculo veiculo = new Veiculo();


            //cbMarca.ItemsSource = veiculoController.ListarTodos();
            //cbModelo.ItemsSource = veiculoController.ListarPorNome(veiculo.Marca);

        }
        private void cbMarca_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cbMarca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Veiculo marcaSel = (Veiculo)cbMarca.SelectedItem;

            //LINQ
            if (marcaSel != null)
            {
                IEnumerable<Veiculo> veiculosSelecionados = from a in listaVeiculos
                                                            where a.Marca.ToLower().Contains(marcaSel.Marca.ToLower())
                                                            select a;
                cbModelo.IsEnabled = true;
                cbModelo.ItemsSource = null;
                cbModelo.ItemsSource = veiculosSelecionados;

            }

        }

        private void BtnAtualizarRol_Click(object sender, RoutedEventArgs e)
        {
            
            rolTemp.Sku = txtSku.Text;
            rolTemp.Di = Convert.ToInt32(txtDi.Text);
            rolTemp.Do = Convert.ToInt32(txtDo.Text);
            rolTemp.W1 = Convert.ToInt32(txtW1.Text);
            rolTemp.MarcaVeiculo = cbMarca.Text;
            rolTemp.ModeloVeiculo = cbModelo.Text;
            rolamentoController.Editar(rolTemp);

            txtSku.Text = "";
            txtDi.Text = "";
            txtDo.Text = "";
            txtW1.Text = "";
            cbMarca.Text = "";
            cbModelo.Text = "";

            MessageBox.Show("Rolamento atualizado com sucesso");

            dtGridRolamentos.ItemsSource = rolamentoController.ListarTodos();
            BtnDeletarRol.IsEnabled = false;
            BtnAtualizarRol.IsEnabled = false;
            BtnCadastrarRol.IsEnabled = true;

        }
        // private void dtGrideRolamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //   RolamentoController rolamentoController = new RolamentoController();

        // Rolamento a = (Rolamento)dtGrideRolamento.SelectedItem;
        //}

    }
}
