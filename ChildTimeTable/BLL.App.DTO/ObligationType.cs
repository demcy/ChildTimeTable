using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
{
    public enum ObligationType
    {
        [Display(Name="Household duties")]
        Home,
        [Display(Name="School responsibilities")]
        School,
        [Display(Name="Sections")]
        Hobbies,
        [Display(Name="Free time")]
        Entertainment
    }
}