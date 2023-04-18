using DZ_LAB1.Data;
using DZ_LAB1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DZ_3.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesControllerAPI : ControllerBase
    {
        private readonly UsersDBContext _usersDBContext;

        public RoutesControllerAPI(UsersDBContext usersDBContext)
        {
            _usersDBContext = usersDBContext;
        }

        // GET: api/<RoutesControllerAPI>
        [HttpGet]
        public IEnumerable<RoutePath> Get() => (IEnumerable<RoutePath>)_usersDBContext.Routes.ToList();



        // GET api/<RoutesControllerAPI>/5
        [HttpGet("{id}")]
        public RoutePath Get(int id)
        {
            if (id == 0)
            {
                Console.WriteLine("This is not valid.");
                return null;
            }

            return _usersDBContext.Routes.Find(id);

        }

        // POST api/<RoutesControllerAPI>
        [HttpPost]
        public void Post([FromBody] RoutePath route)
        {
            _usersDBContext.Routes.Add(new RoutePath
            {
                Id = route.Id,
                routeNumber = route.routeNumber,
                routeName = route.routeName,
                routeLength = route.routeLength,
                routePayPerKM = route.routePayPerKM
            });
            _usersDBContext.SaveChanges();
        }


        // PUT api/<RoutesControllerAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] RoutePath value)
        {
            var Route = _usersDBContext.Routes.Find(id);
            if (Route != null)
            {
                Route.routeNumber = value.routeNumber;
                Route.routeLength = value.routeLength;
                Route.routeName = value.routeName;
                Route.routePayPerKM = value.routePayPerKM;
                _usersDBContext.SaveChanges();
            }
        }

        // DELETE api/<RoutesControllerAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var RoutePath = _usersDBContext.Routes.Find(id);
            _usersDBContext.Routes.Remove(RoutePath);
            _usersDBContext.SaveChanges();
        }
    }
}
