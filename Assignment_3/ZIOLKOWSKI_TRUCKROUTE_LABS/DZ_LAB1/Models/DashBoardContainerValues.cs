namespace DZ_LAB1.Models
{
    public class DashBoardContainerValues
    {
        public List<RoutePath> routes { get; set; }

        public List<Truck> trucks { get; set; }

        public UserProfile profile { get; set; }

        public DashBoardContainerValues(List<RoutePath> routes, List<Truck> trucks, UserProfile profile)
        {
            this.routes = routes;
            this.trucks = trucks;
            this.profile = profile;
        }

        public DashBoardContainerValues()
        {
 
        }
    }
}
