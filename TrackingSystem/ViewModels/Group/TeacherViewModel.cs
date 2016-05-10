namespace TrackingSystem.ViewModels
{
    using TrackingSystem.Common.Mapping;
    using TrackingSystem.Models;

    public class TeacherViewModel : IMapFrom<Teacher>
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

        public string ImageUrl
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