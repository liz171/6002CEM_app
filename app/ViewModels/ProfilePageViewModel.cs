using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace app.ViewModels
{
    public partial class ProfilePageViewModel: ObservableObject
    {
        [ObservableProperty]
        string name;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsGirl))]
        bool isBoy;

        public bool IsGirl
        {
            get => !isBoy;
        }

        [ObservableProperty]
        bool likeBreakfast;

        [ObservableProperty]
        bool likeLunch;

        [ObservableProperty]
        bool likeDinner;

        [ObservableProperty]
        int cookTime;



    }
}
