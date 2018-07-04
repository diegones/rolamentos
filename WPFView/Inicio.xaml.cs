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
        RolamentoController rolamentoController = new RolamentoController();
        IList<Rolamento> listaRolamentos = new List<Rolamento>();

        public Inicio()
        {
            InitializeComponent();
            listaRolamentos = rolamentoController.ListarTodos();
            cbInterno.ItemsSource = cbExterno.ItemsSource = cbLargura.ItemsSource = listaRolamentos;

            cbExterno.IsEnabled = false;
            cbLargura.IsEnabled = false;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Rolamento rolamento = new Rolamento();


            //cbInterno.ItemsSource = rolamentoController.ListarTodos();
            //cbExterno.ItemsSource = rolamentoController.ListarTodos();
            //cbLargura.ItemsSource = rolamentoController.ListarTodos();

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
            cbInterno.ItemsSource = cbExterno.ItemsSource = cbLargura.ItemsSource = dtGrideRolamento.ItemsSource = listaRolamentos = rolamentoController.ListarTodos();
            cbInterno.IsEnabled = true;
            cbLargura.IsEnabled = false;

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
    
        private void cbInterno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rolamento rolSel = (Rolamento)cbInterno.SelectedItem;

            carregaRolamentoExterno(rolSel.Do);
            // carregaRolamentoDiametro(rolSel.W1);
            
        }

        private void cbExterno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Rolamento rolSel = (Rolamento)cbExterno.SelectedItem;

            if (rolSel != null)
            {
                carregaRolamentoDiametro(rolSel.W1);
                cbInterno.IsEnabled = false;

            }
        }

        private void cbLargura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbExterno.IsEnabled = false;
        }

        public void carregaRolamentoExterno(int valor)
        {
            //LINQ
            IEnumerable<Rolamento> rolamentosSelecionados = from rol in listaRolamentos
                                                          where rol.Do.Equals(valor)
                                                         select rol;
            cbExterno.ItemsSource = null;
            cbExterno.ItemsSource = rolamentosSelecionados;

            dtGrideRolamento.ItemsSource = null;
            dtGrideRolamento.ItemsSource = rolamentosSelecionados;
            dtGrideRolamento.Items.Refresh();

            cbExterno.IsEnabled = true;


        }

        public void carregaRolamentoInterno(int valor)
        {
            //LINQ
            IEnumerable<Rolamento> rolamentosSelecionados = from rol in listaRolamentos
                                                            where rol.Di.Equals(valor)
                                                            select rol;
            cbLargura.ItemsSource = null;
            cbLargura.ItemsSource = rolamentosSelecionados;

            dtGrideRolamento.ItemsSource = null;
            dtGrideRolamento.ItemsSource = rolamentosSelecionados;
            dtGrideRolamento.Items.Refresh();


        }

        public void carregaRolamentoDiametro(int valor)
        {
            //LINQ
            IEnumerable<Rolamento> rolamentosSelecionados = from rol in listaRolamentos
                                                            where rol.W1.Equals(valor)
                                                            select rol;
            cbLargura.ItemsSource = null;
            cbLargura.ItemsSource = rolamentosSelecionados;
            dtGrideRolamento.ItemsSource = rolamentosSelecionados;

            cbLargura.IsEnabled = true;

            dtGrideRolamento.ItemsSource = null;
            dtGrideRolamento.ItemsSource = rolamentosSelecionados;
            dtGrideRolamento.Items.Refresh();

        }

        public void atualizaLista()
        {
            dtGrideRolamento.ItemsSource = null;
            dtGrideRolamento.ItemsSource = listaRolamentos;
        }

    }
}
