namespace TrackingSystem.ViewModels
{
    using TrackingSystem.Common.Mapping;
    using TrackingSystem.Models;

    public class DistanceViewModel : IMapFrom<DistanceModel>
    {
        public CoordinatesViewModel Coordinate
        {
            get;
            set;
        }

        public double Distance
        {
            get;
            set;
        }

        public ApplicationUserViewModel User
        {
            get;
            set;
        }
    }
}