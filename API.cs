using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class API
    {
        private citizensContext _context;

        public API(citizensContext context) {
            _context = context;
        }

        public List<citizens> GetCitizens(string citizensSex = null, int lowAge = 0, int highAge = int.MaxValue) {
            if (citizensSex != null && citizensSex != "female" && citizensSex != "male") throw new Exception("Incorrect citizens sex value");
            if (lowAge > highAge) throw new Exception("Incorrect age range");
            var citizens = _context.Citizens.ToList();
            var result = from c in citizens where (c.sex == citizensSex || citizensSex == null) && c.age >= lowAge && c.age <= highAge select c;
            return result.ToList();
        }

        public citizens GetCitizen(string citizenId)
        {
            var citizens = _context.Citizens.ToList();
            var result = from c in citizens where c.id == citizenId select c;
            if (result.Count() != 1) throw new Exception("There is no citizen with same id");
            return result.First();
        }
    }
}
