using Lab1_Gachkovsky.Model;
using Lab1_Gachkovsky.ViewModel;
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

namespace Lab1_Gachkovsky.View
{
    public partial class WindowPerson : Window
    {
        private PersonViewModel vmPerson = new PersonViewModel();

        public WindowPerson()
        {
            InitializeComponent();
            ListPerson.ItemsSource = vmPerson.ListPerson;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewPerson windowNewPerson = new WindowNewPerson
            {
                Title = "Новый клиент",
                Owner = this
            };

            int maxIdPerson = vmPerson.MaxId() + 1;
            Person person = new Person
            {
                Id = maxIdPerson,
            };

            windowNewPerson.DataContext = person;
            if (windowNewPerson.ShowDialog() == true)
            {
                vmPerson.ListPerson.Add(person);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewPerson windowNewPerson = new WindowNewPerson
            {
                Title = "Редактирование клиента",
                Owner = this
            };

            Person person = ListPerson.SelectedItem as Person;

            if (person != null)
            {
                Person tempPerson = new Person
                {
                    Id = person.Id,
                    Shifer = person.Shifer,
                    Inn = person.Inn,
                    Type = person.Type,
                    Data = person.Data
                };

                windowNewPerson.DataContext = tempPerson;
                if (windowNewPerson.ShowDialog() == true)
                {
                    person.Id = tempPerson.Id;
                    person.Shifer = tempPerson.Shifer;
                    person.Inn = tempPerson.Inn;
                    person.Type = tempPerson.Type;
                    person.Data = tempPerson.Data;

                    ListPerson.ItemsSource = null;
                    ListPerson.ItemsSource = vmPerson.ListPerson;
                }
            }
            else 
            {
                MessageBox.Show("Необходимо выбрать клиента для редактирования",
                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Person person = (Person)ListPerson.SelectedItem;

            if (person != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по клиенту: [ "
                    + person.Id + " ]", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK) vmPerson.ListPerson.Remove(person);
                else MessageBox.Show("Необходимо выбрать клиента для удаления", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
    }
}
