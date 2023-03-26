using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Models
{
    /// <summary>
    /// this is a Recipe item model
    /// </summary>
    public class RecipeItem
    {
        public string TypeName { get; set; }

        public string FullName { get; set; }

        public string Image { get; set; }

        public string CookTime { get; set; }

        //public bool Favorite { get; set; }

        public string BriefDescription { get; set; }

        //public string DetailsInformation { get; set; }

       
    }
}
