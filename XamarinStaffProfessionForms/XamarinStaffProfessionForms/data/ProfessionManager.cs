using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinStaffProfessionForms.data
{
    public class ProfessionManager
    {
        public ObservableCollection<Profession> Professions { get; set; }

        private static readonly ProfessionManager instance = new ProfessionManager();

        public static ProfessionManager GetInstance()
        {
            return instance;
        }

        private ProfessionManager()
        {
            Professions = new ObservableCollection<Profession>(StaffManager.GetInstance().Staffs.Select(x => x.Profession));
        }
    }
}
