using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Gachkovsky.Model
{
    class Person
    {
        public int Id { get; set; }
        public int Shifer { get; set; } // Шифр
        public string Inn { get; set; } // Инн
        public bool Type { get; set; } //Физическое или Юридическое лицо
        public DateTime Data { get; set; } // Дата регистрации
        public Person() { }
        public Person(int Id, int Shifer,string Inn, bool Type, DateTime Data)
        {
            this.Id = Id;
            this.Shifer = Shifer;
            this.Inn = Inn;
            this.Type = Type;
            this.Data = Data;
        }
    }
}
