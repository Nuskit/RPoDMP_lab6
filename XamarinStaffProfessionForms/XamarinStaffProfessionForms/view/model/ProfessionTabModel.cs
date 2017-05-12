using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XamarinStaffProfessionForms.data;

namespace XamarinStaffProfessionForms.view.model
{
    class ProfessionTabModel : INotifyPropertyChanged
    {
        public ObservableCollection<Profession> ProfessionItems { get; }

        public ProfessionTabModel(ProfessionManager professionManager)
        {
            ProfessionItems = professionManager.Professions;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void AddStaff(Profession profession)
        {
            ProfessionItems.Add(profession);
            OnPropertyChanged();
        }

        internal void InsertData(Profession addingProfession)
        {
            ProfessionItems.Add(addingProfession);
        }
    }

}
