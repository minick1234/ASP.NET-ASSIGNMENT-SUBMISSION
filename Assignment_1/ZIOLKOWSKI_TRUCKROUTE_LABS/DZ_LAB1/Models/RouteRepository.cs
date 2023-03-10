namespace DZ_LAB1.Models
{
    public class RouteRepository
    {
        public static List<RoutePath> _RouteList = new List<RoutePath>();

        public static void AddRoutePath(RoutePath routeItem)
        {
            _RouteList.Add(routeItem);
        }

        public static void GetRoutePath(RoutePath routeItem)
        {

        }

    }
}
