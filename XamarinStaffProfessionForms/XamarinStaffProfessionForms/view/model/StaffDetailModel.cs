using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XamarinStaffProfessionForms.data;

namespace XamarinStaffProfessionForms.view.model
{
    public class StaffDetailModel : INotifyPropertyChanged
    {
        private string action;
        public string Action
        {
            get => action;
            private set
            {
                action = value;
                OnPropertyChanged();
            }
        }

        private bool isEditing;
        public bool IsEditing
        {
            get => isEditing;
            private set
            {
                isEditing = value;
                OnPropertyChanged();
            }
        }

        public bool IsCanReturn { get; }

        private Avatar image;
        public Avatar Image { get=> image; set { image = value; OnPropertyChanged(); OnPropertyChanged(nameof(Title)); } }
        public string Title { get=>image.ImageName; }
        private Profession profession;
        public Profession Profession { get => profession; set {profession =value; OnPropertyChanged(); } }
        public string Description { get; set; }
        private ObjectContainer<Staff> staffContainer;
        private Staff tempStaff;

        private static readonly string[] actionText = { "Save", "Edit" };

        public StaffDetailModel(ObjectContainer<Staff> staffContainer, bool isAdding)
        {
            this.staffContainer = staffContainer;

            IsCanReturn = !isAdding;
            IsEditing = isAdding;

            tempStaff = staffContainer.Container ?? new Staff() { Profession = new Profession(), Image = new Avatar() };

            Image = tempStaff.Image;
            Profession = tempStaff.Profession;
            Description = tempStaff.Description;
            UpdateActionText();
        }

        private void UpdateActionText()
        {
            Action = GetActionName(IsEditing);
        }

        private String GetActionName(bool editState)
        {
            return editState ? actionText[0] : actionText[1];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public string SwitchEditState()
        {
            string errorMessage = CheckSaveEdit(IsEditing);
            if (string.IsNullOrEmpty(errorMessage))
            {
                IsEditing = !IsEditing;
                UpdateActionText();
            }
            return errorMessage;
        }

        private string CheckSaveEdit(bool isSaving)
        {
            string message = string.Empty;
            if (isSaving)
            {
                if (Image == null || string.IsNullOrEmpty(Image.ToString()))
                    message = getErrorMessage(nameof(Image));
                else if (Profession == null || string.IsNullOrEmpty(Profession.ToString()))
                    message = getErrorMessage(nameof(Profession));
                else if (string.IsNullOrEmpty(Description))
                    message = getErrorMessage(nameof(Description));
                else
                {
                    tempStaff.Image = Image;
                    tempStaff.Description = Description;
                    tempStaff.Profession = Profession;
                    staffContainer.Container = tempStaff;
                }
            }
            return message;
        }

        private string getErrorMessage(string nameField)
        {
            return string.Format("Field '{0}' is empty", nameField);
        }
    }
}
