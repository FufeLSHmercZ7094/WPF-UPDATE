using System;
using System.Collections.Generic;
using System.Data;
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
using PRAKTIKA.BASDANDataSetTableAdapters;

namespace PRAKTIKA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CLINICTableAdapter clinic = new CLINICTableAdapter();
        PATIENTTableAdapter patient = new PATIENTTableAdapter();
        STAFFTableAdapter staff = new STAFFTableAdapter();

        int id = 1;
        int phone= 0;
        int del = 0;
        

        public MainWindow()
        {
            InitializeComponent();
            BASDANGrid.ItemsSource = clinic.GetData();
            GridComboBox.ItemsSource = patient.GetData();
            GridComboBox.ItemsSource = staff.GetData();
            GridComboBox.DisplayMemberPath = "ADDRESS";
        }

        private void GridComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (GridComboBox.SelectedItem as DataRowView).Row[0];
            id = (int)cell;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int phone = Convert.ToInt32(TxtboxCopy.Text);
            clinic.InsertQuery1(Txtbox.Text,phone ,id);
            BASDANGrid.ItemsSource = clinic.GetData();
            
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            Window2 aboba = new Window2();
            aboba.Show();
            this.Close();
        }

        private void DeleteStaff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object del = (BASDANGrid.SelectedItem as DataRowView).Row[0];
                clinic.DeleteQuery3(Convert.ToInt32(del));
                BASDANGrid.ItemsSource = clinic.GetData();
            }
            catch 
            {
                MessageBox.Show("Осечка! Невозможно удалить данные.");
            }
            finally
            {
                
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int phone = Convert.ToInt32(TxtboxCopy.Text);
            object up = (BASDANGrid.SelectedItem as DataRowView).Row[0];
            clinic.UpdateQuery1(Txtbox.Text, phone, id, Convert.ToInt32(up));
            BASDANGrid.ItemsSource = clinic.GetData();
        }

        private void BASDANGrid_sel(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Txtbox.Text = (BASDANGrid.SelectedItem as DataRowView).Row[1].ToString();
                TxtboxCopy.Text = (BASDANGrid.SelectedItem as DataRowView).Row[2].ToString();
            }
            catch
            {
                Txtbox.Text = null;
                TxtboxCopy.Text = null;
            }
        }
    }
}
