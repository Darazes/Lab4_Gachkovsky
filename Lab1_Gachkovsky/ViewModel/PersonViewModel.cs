using Lab1_Gachkovsky.Model;
using System;
using System.Collections.ObjectModel;

namespace Lab1_Gachkovsky.ViewModel
{
    class PersonViewModel
    {
        public ObservableCollection<Person> ListPerson { get; set; } = new ObservableCollection<Person>();
        public PersonViewModel()
        {
            ListPerson.Add(
            new Person
            {
                Id = 1,
                Shifer = 14214,
                Inn = "4444555566667777",
                Type = false,
                Data = new DateTime(1980, 02, 05)
            });
            ListPerson.Add(
            new Person
            {
                Id = 2,
                Shifer = 53534,
                Inn = "1111222233334444",
                Type = false,
                Data = new DateTime(1981, 08, 12)
            });
            ListPerson.Add(
             new Person
             {
                 Shifer = 63463,
                 Inn = "2222333344445555",
                 Type = false,
                 Data = new DateTime(1982, 04, 11)
             });
            ListPerson.Add(
            new Person
            {
                Id = 4,
                Shifer = 16515,
                Inn = "6666777788889999",
                Type = false,
                Data = new DateTime(1983, 05, 09)
            });
        }

        public int MaxId()
        {
            int max = 0;
            foreach (var p in this.ListPerson)
            {
                if (max < p.Id) max = p.Id;
            }
            return max;
        }
    }
}
