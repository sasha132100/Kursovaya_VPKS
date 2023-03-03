using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Kursovaya_VPKS.Classes;

namespace Kursovaya_VPKS.Windows
{
    /// <summary>
    /// Логика взаимодействия для PassportWindow.xaml
    /// </summary>
    public partial class PassportWindow : Window
    {
        public PassportWindow()
        {
            InitializeComponent();
            LoadContent();
            PassportsOutTextBlock.Text = SystemContext.Item.Title;
        }

        private void LoadContent()
        {
            if (SystemContext.isChange == "No")
                return;

        }

        private void BackWindowButtonImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DocumentViewingWindow documentViewingWindow = new DocumentViewingWindow();
            this.Close();
            documentViewingWindow.ShowDialog();
        }
    }
}
