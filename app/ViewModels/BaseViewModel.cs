using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;

namespace app.ViewModels
{
    public partial class BaseViewModel: ObservableObject
    {
        /// <summary>
        /// this is the title of each page
        /// </summary>
        [ObservableProperty]
        string title;

        /// <summary>
        /// if a page is busy
        /// </summary>
        [ObservableProperty]
        bool isBusy;
    }
}
