namespace TrackingSystem.ViewModels
{
    using TrackingSystem.Common.Mapping;
    using TrackingSystem.Models;

    public class GroupViewModel : IMapFrom<Group>
    {
        public int Id
        {
            get;
            set;
        }

        public int MaxDistance
        {
            get;
            set;
        }

    }
}