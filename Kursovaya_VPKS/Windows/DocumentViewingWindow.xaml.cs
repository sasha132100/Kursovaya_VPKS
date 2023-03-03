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
    /// Логика взаимодействия для DocumentViewingWindow.xaml
    /// </summary>
    public partial class DocumentViewingWindow : Window
    {
        public DocumentViewingWindow()
        {
            InitializeComponent();
            CheckIsGuest();
            LoadContent();
        }

        private void CheckIsGuest()
        {
            if (SystemContext.isGuest == "Yes")
            {
                EmailOutTextBlock.Text = "Гость";
            }
            else
            {
                EmailOutTextBlock.Text = SystemContext.User.Login;
            }
        }

        private void LoadContent()
        {
            using (var db = new myDocxAppContext())
            {
                List<Items> items = null;
                try
                {
                    items = (from i in db.Items 
                             where i.UserId == SystemContext.User.Id
                             select i).ToList<Items>();
                }
                catch
                {
                    MessageBox.Show("Ошибка при загрузке документов");
                    return;
                }
                foreach(var item in items)
                {
                    AddNewDocument(item);
                }
            }
        }

        private void AddNewDocument( Items item)
        {
            var borderPanel = new Border() { BorderBrush = Brushes.LightGray, BorderThickness = new Thickness(2), Style = (Style)DocumentsViewGrid.Resources["ContentBorderStyle"] };
            var mainGrid = new Grid() { };
            var bottomDarkeningBorder = new Border() { Style = (Style)DocumentsViewGrid.Resources["BottomBorderProperties"] };

            ImageBrush imageBrush = new ImageBrush();
            Image image = new Image();
            if (SystemContext.isGuest == "Yes" || item.Image.ToString() != "rgfjigjrigrj"/*null*/)
                image.Source = new BitmapImage(new Uri("C:\\Users\\sasha\\source\\repos\\Kursovaya_VPKS\\Kursovaya_VPKS\\Resources\\DocumentPlugImage.png"));
            else
                image.Source = new BitmapImage(new Uri(""));
            imageBrush.ImageSource = image.Source;
            imageBrush.Stretch = Stretch.UniformToFill;
            mainGrid.Background = imageBrush;

            bottomDarkeningBorder.VerticalAlignment = VerticalAlignment.Bottom;
            TextBlock itemName = new TextBlock() { Text = item.Title, Style = (Style)DocumentsViewGrid.Resources["DocumentTextBlockPropeties"] };

            borderPanel.Tag = item;
            bottomDarkeningBorder.Tag = item;
            itemName.Tag = item;

            borderPanel.MouseLeftButtonUp += ChangeItemButton_Click;
            bottomDarkeningBorder.MouseLeftButtonUp += ChangeTitleNameButton_Click;

            mainGrid.Children.Add(bottomDarkeningBorder);
            mainGrid.Children.Add(itemName);
            borderPanel.Child = mainGrid;
            DocumentsViewGrid.Children.Add(borderPanel);
        }

        private void ChangeItemButton_Click(object sender, MouseButtonEventArgs e)
        {
            using (var db = new myDocxAppContext())
            {
                SystemContext.Item = (sender as Border).Tag as Items;
                SystemContext.isChange = "Yes";
                if (SystemContext.Item.Type == "Passport")
                {
                    PassportWindow passportWindow = new PassportWindow();
                    this.Close();
                    passportWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("В данный момент возможно взаимодействовать только с паспортом.");
                }
            } 
        }

        private void ChangeTitleNameButton_Click(object sender, MouseButtonEventArgs e)
        {
            SystemContext.Item = (sender as Border).Tag as Items;
        }

        private void CreateNewItemButton_Click(object sender, MouseButtonEventArgs e)
        {
            SystemContext.isChange = "No";
            PassportWindow passportWindow = new PassportWindow();
            this.Close();
            passportWindow.ShowDialog();
        }

        private void OpenSettingPageButtonImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }
    }
}
