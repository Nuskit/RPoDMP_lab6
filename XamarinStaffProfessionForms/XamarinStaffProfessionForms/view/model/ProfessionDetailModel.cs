using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XamarinStaffProfessionForms.data;

namespace XamarinStaffProfessionForms.view.model
{
    class ProfessionDetailModel:INotifyPropertyChanged
    {
        public String Name { get; set; }
        private ObjectContainer<Profession> professionContainer;
        private Profession tempProfession;

        public ProfessionDetailModel(ObjectContainer<Profession> professionContainer)
        {
            this.professionContainer = professionContainer;
            tempProfession = professionContainer.Container ?? new Profession();
            Name = tempProfession.Name;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public void UpdateModel()
        {
            tempProfession.Name = Name;
            professionContainer.Container = tempProfession;
        }
    }
}
