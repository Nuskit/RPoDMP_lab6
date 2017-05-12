using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XamarinStaffProfessionForms.data;

namespace XamarinStaffProfessionForms.view.model
{
    public class StaffTabModel : INotifyPropertyChanged
    {
        public ObservableCollection<Staff> StaffItems { get; }

        public StaffTabModel(StaffManager staffManager)
        {
            StaffItems =staffManager.Staffs;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void AddStaff(Staff newStaff)
        {
            StaffItems.Add(newStaff);
            OnPropertyChanged();
        }

        internal void InsertData(Staff newStaff)
        {
            StaffItems.Add(newStaff);
        }
    }
}
