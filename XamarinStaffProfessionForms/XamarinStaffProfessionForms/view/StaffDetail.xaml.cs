using System;
using System.Collections.Generic;
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
    public partial class StaffDetail : ContentPage
    {
        private StaffDetailModel staffDetailModel;

        public StaffDetail(ObjectContainer<Staff> detailStaffContainer, bool isAdding)
        {
            InitializeComponent();

            staffDetailModel = new StaffDetailModel(detailStaffContainer, isAdding);
            BindingContext = staffDetailModel;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            String message = staffDetailModel.SwitchEditState();
            if (!String.IsNullOrEmpty(message))
                await DisplayAlert("Empty field", message, "Ok");
            else if (!staffDetailModel.IsCanReturn)
                await Navigation.PopAsync();
        }

        private void Description_Completed(object sender, EventArgs e)
        {
            Editor editor = sender as Editor;

            if (editor == null) return;

            staffDetailModel.Description = editor.Text;
        }

        private ObjectContainer<Profession> professionContainer;

        private async void Profession_Tapped(object sender, EventArgs e)
        {
            if (staffDetailModel.IsEditing)
            {
                professionContainer = new ObjectContainer<Profession>(staffDetailModel.Profession);
                await Navigation.PushAsync(new ProfessionTab(true, professionContainer));
            }
        }


        private ObjectContainer<Avatar> avatarContainer;

        private async void Image_Tapped(object sender, EventArgs e)
        {
            if (staffDetailModel.IsEditing)
            {
                avatarContainer = new ObjectContainer<Avatar>(staffDetailModel.Image);
                await Navigation.PushAsync(new AvatarDetail(avatarContainer));
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (avatarContainer != null)
            {
                staffDetailModel.Image = avatarContainer.Container;
                avatarContainer = null;
            }

            if (professionContainer != null)
            {
                staffDetailModel.Profession = professionContainer.Container;
                professionContainer = null;
            }
        }
    }
}
