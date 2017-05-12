using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using XamarinStaffProfessionForms.data;

namespace XamarinStaffProfessionForms.data
{
    public class Staff : INotifyPropertyChanged
    {
        private Avatar _image;
        public Avatar Image { get => _image; set { _image = value; OnPropertyChanged(); OnPropertyChanged(nameof(Title)); } }
        public string Title { get => _image.ImageName; }
        private Profession profession;
        public Profession Profession { get => profession; set { profession = value; OnPropertyChanged(); } }
        private string description;
        public string Description { get => description ; set { description = value; OnPropertyChanged(); } }

        public Staff()
        {
            Profession = new Profession();
            Image = new Avatar();
            Description = string.Empty;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public bool IsFilling()
        {
            return !(Image  == null || string.IsNullOrEmpty(Image.ImageName)
                || string.IsNullOrEmpty(Title) 
                || Profession == null  || string.IsNullOrEmpty(Profession.Name)
                || string.IsNullOrEmpty(Description));
        }
    }
}
