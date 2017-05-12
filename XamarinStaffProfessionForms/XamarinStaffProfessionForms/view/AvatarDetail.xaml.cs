using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinStaffProfessionForms.data;
using XamarinStaffProfessionForms.view.model;

namespace XamarinStaffProfessionForms.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AvatarDetail : ContentPage
    {
        private AvatarDetailModel imageDetailModel;

        public AvatarDetail(ObjectContainer<Avatar> currentImageContainer)
        {
            InitializeComponent();
            imageDetailModel = new AvatarDetailModel(AvatarManager.GetInstance(), currentImageContainer);
            BindingContext = imageDetailModel;
        }

        private async void image_selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(sender is ListView)) return;

            imageDetailModel.SetImage(e.SelectedItem as data.Avatar);

            await Navigation.PopAsync();
        }
    }
}
