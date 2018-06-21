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
        }

        private void BtnCadastrarRol(object sender, RoutedEventArgs e)
        {
            try

            {
                RolamentoController rolamentoController = new RolamentoController();
                               
                if (string.IsNullOrEmpty(txtSku.Text))

                    throw new NullReferenceException("O campo SKU é obrigatório.");

                Rolamento rolamento = new Rolamento();

                rolamento.Sku = txtSku.Text;                    
                rolamentoController.Incluir(rolamento);                        
                MessageBox.Show("Usuário Salvo com sucesso!");
            }

            catch(NullReferenceException nre)
            {
                // excecao mais especifica
            }        
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar (" + ex.Message + ")");
            }
        }

        private void BtnBuscarRol(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancelarRol(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
