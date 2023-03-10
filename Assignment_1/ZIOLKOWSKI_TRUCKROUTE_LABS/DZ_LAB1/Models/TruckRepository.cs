namespace DZ_LAB1.Models
{
    public class TruckRepository
    {
        public static List<Truck> _TruckList = new List<Truck>();

        public static void AddTruckProfile(Truck truckItem)
        {
            _TruckList.Add(truckItem);
        }

        public static void GetTruckProfile(Truck truckItem)
        {

        }

    }
}
