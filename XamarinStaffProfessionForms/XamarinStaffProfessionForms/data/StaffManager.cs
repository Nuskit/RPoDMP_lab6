using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinStaffProfessionForms.data
{
    public class StaffManager
    {
        public ObservableCollection<Staff> Staffs { get; set; }

        private static readonly StaffManager instance = new StaffManager();

        public static StaffManager GetInstance()
        {
            return instance;
        }

        private StaffManager()
        {
            Staffs = new ObservableCollection<Staff>
            {
                new Staff()
                {
                    Image = new data.Avatar(){ImageName = "User_14.jpg" }, Description = "Elizabeth is a twenty-year-old girl with supernatural powers. It is enclosed in a tower-monument in Colombia. Protected by a winged creature, nicknamed Nightingale. Because of a long life locked up very much perceives everything around. Clever, well-read girl. He dreams of visiting Paris", Profession = new Profession(){Name = "Warper"}
                },
                new Staff()
                {
                    Image = new data.Avatar(){ImageName = "User_10.jpg" }, Description = "Assasins group", Profession = new Profession(){Name = "Killer"}
                },
                new Staff()
                {
                    Image = new data.Avatar(){ImageName = "User_7.jpg" }, Description = "Cat", Profession = new Profession(){Name = "Lucker"}
                }
            };
        }
    }
}
