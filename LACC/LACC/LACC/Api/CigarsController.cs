using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LACC.Data;
using LACC.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LACC.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CigarsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICigarData _cigarData;
        public LACCDbContext _context;
        public IEnumerable<Cigar> cigars;

        public CigarsController(IConfiguration config, ICigarData cigarData, LACCDbContext context)
        {
            _config = config;
            _cigarData = cigarData;
            _context = context;
        }

        // GET api/Cigars
        [HttpGet]
        public DbSet<Cigar> GetCigars()
        {
            if (!_context.Cigars.Any())
            {
                cigars = _cigarData.GetAll();
                foreach (Cigar cigar in cigars)
                {
                    if (!CigarExists(cigar.Id))
                    {
                        _context.Cigars.Add(cigar);
                    }
                }
                _context.SaveChanges();
            }
            return _context.Cigars;
        }

        // GET api/Cigars/Cuaba
        [HttpGet("{name}")]
        [ActionName("GetGigarByName")]
        public IEnumerable<Cigar> GetCigar(string name)
        {
            return _cigarData.GetCigarsByName(name);
        }

        // POST api/Cigars
        [HttpPost]
        public IActionResult PostCigar(Cigar cigar)
        {
            Cigar ciggy = _cigarData.Add(cigar, _context.Cigars);
            if (ciggy.Id == 0)
            {
                return Ok("Already exists!");
            }
            else
            {
                _context.Add(ciggy);
                _context.SaveChanges();
                return Ok("Item added!");
            }
        }

        // DELETE: api/Cigars/2
        [HttpDelete("{id}")]
        public IActionResult DeleteCigar(int id)
        {
            Cigar ciggy = _cigarData.Delete(id, _context.Cigars);
            _context.Cigars.Remove(ciggy);
            _context.SaveChanges();
            return Ok("Item removed!");
        }

        private bool CigarExists(int id)
        {
            return _context.Cigars.Any(e => e.Id == id);
        }
    }
}
