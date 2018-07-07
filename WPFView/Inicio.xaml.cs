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
            cbInterno.ItemsSource = listaRolamentos.GroupBy(r => r.Di);


                //cbExterno.ItemsSource = cbLargura.ItemsSource = listaRolamentos;

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


            this.Close();
            cadVeic.ShowDialog();

        }

        private void BtnRolamento_Click(object sender, RoutedEventArgs e)

        {

            MainWindow cadRol = new MainWindow();


            this.Close();
            cadRol.ShowDialog();
          

        }

        private void BtnLimparMedida_Click(object sender, RoutedEventArgs e)
        {
            cbInterno.ItemsSource = cbExterno.ItemsSource = cbLargura.ItemsSource = dtGrideRolamento.ItemsSource = listaRolamentos = rolamentoController.ListarTodos();
            cbInterno.IsEnabled = true;
            
            cbInterno.Text = "";
            cbExterno.Text = "";
            cbLargura.Text = "";
            cbExterno.IsEnabled = false;
            cbLargura.IsEnabled = false;
        }


        private void dtGrideRolamento_Initialized(object sender, EventArgs e)
        {
            RolamentoController rolamentoController = new RolamentoController();

            Rolamento rolamento = new Rolamento();

            dtGrideRolamento.ItemsSource = rolamentoController.ListarTodos();
        }
    
        private void cbInterno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IGrouping<int, Rolamento> grupo = (IGrouping<int, Rolamento>)cbInterno.SelectedItem;

            carregaRolamentoInterno(grupo.Key);
           
        }

        private void cbExterno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            IGrouping<int, Rolamento> grupo = (IGrouping<int, Rolamento>)cbExterno.SelectedItem;

       
            carregaRolamentoExterno(grupo.Key);
            cbInterno.IsEnabled = false;

            //Rolamento rolSel = (Rolamento)cbExterno.SelectedItem;

            // if (rolSel != null)
            {
           //     carregaRolamentoExterno(rolSel.Do);
               // cbInterno.IsEnabled = false;

            }
        }

        private void cbLargura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            IGrouping<int, Rolamento> grupo = (IGrouping<int, Rolamento>)cbLargura.SelectedItem;

            carregaRolamentoDiametro(grupo.Key);

            //Rolamento rolSel = (Rolamento)cbLargura.SelectedItem;

           // if (rolSel != null)
            {
                
            //    carregaRolamentoDiametro(rolSel.W1);
            }
        }

        public void carregaRolamentoExterno(int valor)
        {
            //LINQ
            IEnumerable<Rolamento> rolamentosSelecionados =  rolamentoController.ListarPorDiametroExterno(valor);

            //numerable<Rolamento> rolamentosSelecionados = rolamentoController.ListarPorDiametroExterno(valor);
             //   from rol in listaRolamentos
                                                      //    where rol.Do.Equals(valor)
                                                        // select rol;


            //cbExterno.ItemsSource = null;
            cbExterno.ItemsSource = rolamentosSelecionados;

            dtGrideRolamento.ItemsSource = null;
            dtGrideRolamento.ItemsSource = rolamentosSelecionados;
            dtGrideRolamento.Items.Refresh();

           
            cbLargura.IsEnabled = true;


        }

        public void carregaRolamentoInterno(int valor)
        {
            //LINQ

           // rolamentoController.ListarPorDiametroInterno(valor);
            IEnumerable<Rolamento> rolamentosSelecionados = rolamentoController.ListarPorDiametroInterno(valor);
            //                                                   from rol in listaRolamentos where rol.Di.Equals(valor)
            //                                                      select rol;
            //cbExterno.ItemsSource = null;
            cbExterno.ItemsSource = rolamentosSelecionados.GroupBy(r => r.Do);

            dtGrideRolamento.ItemsSource = null;
            dtGrideRolamento.ItemsSource = rolamentosSelecionados;
            dtGrideRolamento.Items.Refresh();

            cbExterno.IsEnabled = true;
        }

        public void carregaRolamentoDiametro(int valor)
        {
            //LINQ

            IEnumerable<Rolamento> rolamentosSelecionados = rolamentoController.ListarPorlargura(valor);
            //IEnumerable<Rolamento> rolamentosSelecionados = from rol in listaRolamentos
              //                                              where rol.W1.Equals(valor)
                //                                            select rol;
            //cbExterno.ItemsSource = null;
            cbExterno.ItemsSource = rolamentosSelecionados;
            dtGrideRolamento.ItemsSource = rolamentosSelecionados;

            

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
