using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinStaffProfessionForms.data
{
    public class AvatarManager
    {
        public List<Avatar> Images { get; }

        private static readonly AvatarManager instance = new AvatarManager();

        public static AvatarManager GetInstance()
        {
            return instance;
        }

        private AvatarManager()
        {
            Images = new List<Avatar>(StaffManager.GetInstance().Staffs.Select(x => x.Image));
            Images.Add(new Avatar() { ImageName = "User_12.jpg" });
        }
    }
}
