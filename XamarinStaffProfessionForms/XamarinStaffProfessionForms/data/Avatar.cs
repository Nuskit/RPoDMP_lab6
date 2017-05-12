using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XamarinStaffProfessionForms.data
{
    public class Avatar : INotifyPropertyChanged
    {
        private string _imageName;
        public string ImageName { get => _imageName; set { _imageName = value; OnPropertyChanged(); } }

        public override string ToString()
        {
            return ImageName;
        }

        public Avatar()
        {
            ImageName = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
