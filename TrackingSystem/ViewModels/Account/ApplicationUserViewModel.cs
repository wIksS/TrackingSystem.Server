namespace TrackingSystem.ViewModels
{
    using TrackingSystem.Common.Mapping;
    using TrackingSystem.Models;

    public class ApplicationUserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }

        public bool? IsInExcursion
        {
            get;
            set;
        }
    }
}