using DZ_LAB1.Models;
using DZ_LAB1.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DZ_3.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckWorkshopControllerAPI : ControllerBase
    {

        private readonly UsersDBContext _usersDBContext;

        public TruckWorkshopControllerAPI(UsersDBContext usersDBContext)
        {
            _usersDBContext = usersDBContext;
        }


        // GET: api/<TruckWorkshopControllerAPI>
        [HttpGet]
        public IEnumerable<TruckWorkshop> Get() => (IEnumerable<TruckWorkshop>)_usersDBContext.TruckWorkshop.ToList();



        // GET api/<TruckWorkshopControllerAPI>/5
        [HttpGet("{id}")]
        public TruckWorkshop Get(int id)
        {
            if (id == 0)
            {
                Console.WriteLine("This is not valid.");
                return null;
            }

            return _usersDBContext.TruckWorkshop.Find(id);

        }

        // POST api/<TruckWorkshopControllerAPI>
        [HttpPost]
        public void Post([FromBody] TruckWorkshop truckWorkshop)
        {
            _usersDBContext.TruckWorkshop.Add(new TruckWorkshop
            {
                WorkOrderID = truckWorkshop.WorkOrderID,
                WorkDescription = truckWorkshop.WorkDescription,
                WorkOrderCost = truckWorkshop.WorkOrderCost,
                TruckId = truckWorkshop.TruckId
            });
            _usersDBContext.SaveChanges();
        }


        // PUT api/<TruckWorkshopControllerAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TruckWorkshop value)
        {
            var TruckWorkshop = _usersDBContext.TruckWorkshop.Find(id);
            if (TruckWorkshop != null)
            {
                TruckWorkshop.TruckId = value.TruckId;
                TruckWorkshop.WorkOrderCost = value.WorkOrderCost;
                TruckWorkshop.WorkDescription = value.WorkDescription;
                _usersDBContext.SaveChanges();
            }
        }

        // DELETE api/<TruckWorkshopControllerAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var truckWorkshop = _usersDBContext.TruckWorkshop.Find(id);
            _usersDBContext.TruckWorkshop.Remove(truckWorkshop);
            _usersDBContext.SaveChanges();
        }
    }
}
