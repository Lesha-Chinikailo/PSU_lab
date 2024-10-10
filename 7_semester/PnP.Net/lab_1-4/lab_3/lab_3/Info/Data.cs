using lab_3;
using lab_3.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Info
{
    public static class Data
    {
        private static List<Ship> ships = new List<Ship>();
        private static Dictionary<string, CabinCategory> categories = new Dictionary<string, CabinCategory>();
        private static Dictionary<string, ShipType> types = new Dictionary<string, ShipType>();

        static Data()
        {
            categories.Add(CabinCategory.InsideCabin.ToString(), CabinCategory.InsideCabin);
            categories.Add(CabinCategory.OutsideCabinWithWindow.ToString(), CabinCategory.OutsideCabinWithWindow);
            categories.Add(CabinCategory.OutsideCabinWithBalcony.ToString(), CabinCategory.OutsideCabinWithBalcony);
            categories.Add(CabinCategory.Luxury.ToString(), CabinCategory.Luxury);

            types.Add(ShipType.CargoShip.ToString(), ShipType.CargoShip);
            types.Add(ShipType.PassengerShip.ToString(), ShipType.PassengerShip);
            types.Add(ShipType.IndustrialShip.ToString(), ShipType.IndustrialShip);
        }

        public static List<Ship> GetShips() 
        { 
            return ships; 
        }
        public static Dictionary<string, CabinCategory> getCabinCategories()
        {
            return categories;
        }
        public static Dictionary<string, ShipType> getShipTypes()
        {
            return types;
        }

    }
}
