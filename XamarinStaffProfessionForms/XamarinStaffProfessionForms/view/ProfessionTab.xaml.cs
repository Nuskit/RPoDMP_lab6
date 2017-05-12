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
    public partial class ProfessionTab : ContentPage
    {

        private ProfessionTabModel professionTabModel;
        private bool needToSelect;
        private ObjectContainer<Profession> editProfessionContainer;
        private ObjectContainer<Profession> addingProfessionContainer;

        public ProfessionTab()
        {
            InitializeComponent();
            professionTabModel = new ProfessionTabModel(ProfessionManager.GetInstance());
            BindingContext = professionTabModel;
        }

        public ProfessionTab(bool needToSelect, ObjectContainer<Profession> professionContainer):this()
        {
            this.needToSelect = needToSelect;
            this.editProfessionContainer = professionContainer;
        }

        private async void Button_AddClicked(object sender, EventArgs e)
        {
            addingProfessionContainer = new ObjectContainer<Profession>();
            await OpenDetail(addingProfessionContainer);
        }

        private static ProfessionModalDetail getDetailPage(ObjectContainer<Profession> profession)
        {
            return new ProfessionModalDetail(profession);
        }

        private async Task OpenDetail(ObjectContainer<Profession> profession)
        {
            await Navigation.PushModalAsync(getDetailPage(profession));
        }

        public async void profession_selected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            if (listView == null || e.SelectedItem == null) return;

            if (!needToSelect)
            {
                await OpenDetail(new ObjectContainer<Profession>(e.SelectedItem as Profession));

                listView.SelectedItem = null;
            }
            else
            {
                editProfessionContainer.Container = (e.SelectedItem as Profession);
                await Navigation.PopAsync();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (addingProfessionContainer != null)
            {
                if (addingProfessionContainer.Container != null)
                    professionTabModel.InsertData(addingProfessionContainer.Container);
                addingProfessionContainer = null;
            }
        }
    }
}
