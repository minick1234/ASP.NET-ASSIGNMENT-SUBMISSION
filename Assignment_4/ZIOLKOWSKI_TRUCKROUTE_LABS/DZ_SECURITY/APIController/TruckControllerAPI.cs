using DZ_LAB1.Data;
using DZ_LAB1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DZ_3.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckControllerAPI : ControllerBase
    {

        private readonly UsersDBContext _usersDBContext;

        public TruckControllerAPI(UsersDBContext usersDBContext)
        {
            _usersDBContext = usersDBContext;
        }


        // GET: api/<TruckControllerAPI>
        [HttpGet]
        public IEnumerable<Truck> Get() => (IEnumerable<Truck>)_usersDBContext.Trucks.ToList();

        // GET api/<TruckControllerAPI>/5
        [HttpGet("{id}")]
        public Truck Get(int id)
        {
            if (id == 0)
            {
                Console.WriteLine("This is not valid.");
                return null;
            }

            return _usersDBContext.Trucks.Find(id);

        }

        // POST api/<TruckControllerAPI>
        [HttpPost]
        public void Post([FromBody] Truck truck)
        {
            _usersDBContext.Trucks.Add(new Truck
            {
                Id = truck.Id,
                truckNum = truck.truckNum,
                truckModel = truck.truckModel,
                truckMake = truck.truckMake,
                truckRouteNumber = truck.truckRouteNumber
            });
            _usersDBContext.SaveChanges();
        }


        // PUT api/<TruckControllerAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Truck value)
        {
            var truck = _usersDBContext.Trucks.Find(id);
            if (truck != null)
            {
                truck.truckMake = value.truckMake;
                truck.truckModel = value.truckModel;
                truck.truckRouteNumber = value.truckRouteNumber;
                truck.truckNum = value.truckNum;
                _usersDBContext.SaveChanges();
            }
        }

        // DELETE api/<TruckControllerAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var truck = _usersDBContext.Trucks.Find(id);
            _usersDBContext.Trucks.Remove(truck);
            _usersDBContext.SaveChanges();
        }
    }
}
