using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XamarinStaffProfessionForms.data
{
    public class Profession : INotifyPropertyChanged
    {
        private string name;
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }

        public override string ToString()
        {
            return Name;
        }

        public Profession()
        {
            Name = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public bool IsFilling()
        {
            return !(string.IsNullOrEmpty(Name));
        }
    }
}
