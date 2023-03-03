using System;
using System.Data;
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
            using (var db = new myDocxAppContext())
            {
                var passport = (from p in db.Passport where p.Id == SystemContext.Item.Id select p).FirstOrDefault<Passport>();
                SerialAndNumberTextBlock.Text = passport.SeriaNumber;
                DivisionCodeTextBlock.Text = passport.DivisionCode;
                DateOfIssueTextBlock.Text = passport.GiveDate;
                IssuedByWhomTextBlock.Text = passport.ByWhom;
                FIOTextBlock.Text = passport.Fio;
                DateOfBirthTextBlock.Text = passport.BirthDate;
                if (passport.Gender == "M")
                    MaleChoiseRadioButton.IsChecked = true;
                else
                    FemaleChoiseRadioButton.IsChecked = true;
                PlaceOfBirthTextBlock.Text = passport.BirthPlace;
                PlaceOfResidenceTextBlock.Text = passport.ResidencePlace;
            }

        }

        private Passport CreatingPassportObject()
        {
            using (var db = new myDocxAppContext())
            {
                Passport passport = new Passport();
                passport.SeriaNumber = SerialAndNumberTextBlock.Text;
                passport.DivisionCode = DivisionCodeTextBlock.Text;
                passport.GiveDate = DateOfIssueTextBlock.Text;
                passport.ByWhom = IssuedByWhomTextBlock.Text;
                passport.Fio = FIOTextBlock.Text;
                passport.BirthDate = DateOfBirthTextBlock.Text;
                if (MaleChoiseRadioButton.IsChecked == true)
                    passport.Gender = "M";
                else
                    passport.Gender = "F";
                passport.BirthPlace = PlaceOfBirthTextBlock.Text;
                passport.ResidencePlace = PlaceOfResidenceTextBlock.Text;
                return passport;
            }
        }

        private string CheckingTheFullness()
        {
            if (SerialAndNumberTextBlock.Text != "" || DivisionCodeTextBlock.Text != "" || DateOfIssueTextBlock.Text != "" ||
                IssuedByWhomTextBlock.Text != "" || FIOTextBlock.Text != "" || DateOfBirthTextBlock.Text != "" ||
                PlaceOfBirthTextBlock.Text != "" || PlaceOfResidenceTextBlock.Text != "")
            {
                if (MaleChoiseRadioButton.IsChecked == false && FemaleChoiseRadioButton.IsChecked == false)
                {
                    MessageBox.Show("Заполните все поля для добавления!");
                    return "Не заполнены";
                }
                return "Заполнены";
            }
            else
            {
                MessageBox.Show("Заполните все поля для добавления!");
                return "Не заполнены";
            }
        }

        private string CheckingTheChanges()
        {
            Passport passport = new Passport();
            using (var db = new myDocxAppContext())
            {
                passport = (from p in db.Passport where p.Id == SystemContext.Item.Id select p).FirstOrDefault<Passport>();
            }
            if (SerialAndNumberTextBlock.Text == passport.SeriaNumber || DivisionCodeTextBlock.Text == passport.DivisionCode || DateOfIssueTextBlock.Text == passport.GiveDate ||
                IssuedByWhomTextBlock.Text == passport.ByWhom || FIOTextBlock.Text == passport.Fio || DateOfBirthTextBlock.Text == passport.BirthDate ||
                PlaceOfBirthTextBlock.Text == passport.BirthPlace || PlaceOfResidenceTextBlock.Text == passport.ResidencePlace)
            {
                if ((MaleChoiseRadioButton.IsChecked == true && passport.Gender == "M") || (FemaleChoiseRadioButton.IsChecked == true && passport.Gender == "F"))
                    return "Не изменено";
                return "Изменено";
            }
            else
                return "Не изменено";
        }

        private void AddNewPassport()
        {
            if (CheckingTheFullness() != "Заполнены")
                return;
            using (var db = new myDocxAppContext())
            {
                db.Passport.Add(CreatingPassportObject());
                db.SaveChanges();
            }
        }

        private void ChangePassport()
        {
            if (CheckingTheChanges() == "Изменено")
            {
                using (var db = new myDocxAppContext())
                {
                    db.Entry(CreatingPassportObject()).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        private void BackWindowButtonImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (SystemContext.isChange == "No")
                AddNewPassport();
            else
            {
                ChangePassport();
            }
            DocumentViewingWindow documentViewingWindow = new DocumentViewingWindow();
            this.Close();
            documentViewingWindow.ShowDialog();
        }
    }
}
