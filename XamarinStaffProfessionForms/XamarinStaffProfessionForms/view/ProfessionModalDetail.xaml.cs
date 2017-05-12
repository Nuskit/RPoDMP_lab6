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
    public partial class ProfessionModalDetail : ContentPage
    {
        private ProfessionDetailModel professionModel;
        public ProfessionModalDetail(ObjectContainer<Profession> detailProfession)
        {
            InitializeComponent();
            this.professionModel = new ProfessionDetailModel(detailProfession);
            BindingContext = professionModel;

        }
        async void OnEditButtonClicked(object sender, EventArgs args)
        {
            professionModel.UpdateModel();
            await Navigation.PopModalAsync();
        }

        private async void Editor_Completed(object sender, EventArgs e)
        {
            if (!(sender is Editor)) return;

            string message = ((Editor)sender).Text;
            if (String.IsNullOrEmpty(message))
                await DisplayAlert("Empty field", "Field is empty", "Ok");
            else
                professionModel.Name = ((Editor)sender).Text;
        }

        async void cancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
