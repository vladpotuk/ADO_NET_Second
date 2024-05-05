using System.Windows;
using Data;

namespace WarehouseApp
{
    public partial class MainWindow : Window
    {
        DBManager dbManager;

        public MainWindow()
        {
            InitializeComponent();
            dbManager = new DBManager();
            LoadWarehouseItems();
        }

        private void LoadWarehouseItems()
        {
            try
            {
                dgWarehouseItems.ItemsSource = dbManager.SelectAllItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
