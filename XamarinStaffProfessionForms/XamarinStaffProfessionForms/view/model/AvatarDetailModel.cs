using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XamarinStaffProfessionForms.data;

namespace XamarinStaffProfessionForms.view.model
{
    internal class AvatarDetailModel
    {
        public ObservableCollection<data.Avatar> ImageItems { get; }

        private ObjectContainer<Avatar> updateImageContainer;

        public AvatarDetailModel(AvatarManager imageManager, ObjectContainer<Avatar> updatedImageContainer)
        {
            ImageItems = new ObservableCollection<data.Avatar>(imageManager.Images);
            updateImageContainer = updatedImageContainer;
        }

        internal void SetImage(data.Avatar newImage)
        {
            updateImageContainer.Container = newImage;
        }
    }
}