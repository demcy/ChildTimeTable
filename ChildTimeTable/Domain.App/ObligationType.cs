using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.App
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