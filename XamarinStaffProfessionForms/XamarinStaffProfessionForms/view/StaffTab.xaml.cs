using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinStaffProfessionForms.data;
using XamarinStaffProfessionForms.view.model;

namespace XamarinStaffProfessionForms.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StaffTab : ContentPage
    {
        private StaffTabModel staffTabModel;
        private ObjectContainer<Staff> addingStaff;

        public StaffTab()
        {
            InitializeComponent();
            staffTabModel = new StaffTabModel(StaffManager.GetInstance());
            BindingContext = staffTabModel;
        }

        public async void Button_AddClicked(object sender, EventArgs e)
        {
            addingStaff = new ObjectContainer<Staff>();
            await openDetail(addingStaff, true);
        }

        private static StaffDetail getDetailPage(ObjectContainer<Staff> staff, bool isAdding)
        {
            return new StaffDetail(staff, isAdding);
        }

        private async Task openDetail(ObjectContainer<Staff> staff, bool isAdding = false)
        {
            await Navigation.PushAsync(getDetailPage(staff, isAdding));
        }

        public async void staff_selected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView staffs = sender as ListView;

            if (staffs == null || e.SelectedItem == null) return;

            await openDetail(new ObjectContainer<Staff>(e.SelectedItem as Staff));

            //disable selected
            staffs.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (addingStaff != null)
            {
                if (addingStaff.Container != null)
                    staffTabModel.InsertData(addingStaff.Container);
                addingStaff = null;
            }
        }
    }
}
