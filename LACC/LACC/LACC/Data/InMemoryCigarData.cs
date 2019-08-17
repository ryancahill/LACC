using LACC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LACC.Data
{
    public class InMemoryCigarData : ICigarData
    {
        List<Cigar> cigars;

        public InMemoryCigarData()
        {
            cigars = new List<Cigar>()
            {
                new Cigar { Id = 99, Name = "Blank", Type="Blank", Description="Blank", QTY = 0 },
                new Cigar { Id = 1, Name = "Sinistro", Type="Dominican", Description="Light flavor. CT wrap.", QTY = 25 },
                new Cigar { Id = 2, Name = "Padron", Type="Nicarguan", Description="Medium flavor. Maduro wrap.", QTY = 10 },
                new Cigar { Id = 3, Name = "Cuaba", Type="Cuban", Description="Full body. Double wrap.", QTY = 15 }
            };
        }

        public IEnumerable<Cigar> GetAll()
        {
            return from c in cigars
                   orderby c.Name
                   select c;
        }

        public Cigar GetById(int id)
        {
            return cigars.SingleOrDefault(c => c.Id == id);
        }

        public Cigar Update(Cigar updatedCigar)
        {
            var cigar = cigars.SingleOrDefault(c => c.Id == updatedCigar.Id);
            if (cigar != null)
            {
                cigar.Name = updatedCigar.Name;
                cigar.Type = updatedCigar.Type;
                cigar.Description = updatedCigar.Description;
            }
            return cigar;
        }

        public IEnumerable<Cigar> GetCigarsByName(string name = null)
        {
            return from c in cigars
                   where string.IsNullOrEmpty(name) || c.Name.StartsWith(name)
                   orderby c.Name
                   select c;
        }

        public Cigar Add(Cigar newCigar, IEnumerable<Cigar> cigarList)
        {
            List<Cigar> ListofCigars = cigarList.ToList();
            Cigar duplicated = null;
            duplicated = ListofCigars.Find(c => c.Name == newCigar.Name);
            if (duplicated == null)
            {
                ListofCigars.Add(newCigar);
                newCigar.Id = ListofCigars.Max(c => c.Id) + 1;
            }
            return newCigar;
        }

        public Cigar Delete(int id, IEnumerable<Cigar> cigarList)
        {
            List<Cigar> ListofCigars = cigarList.ToList();
            Cigar cigar = ListofCigars.FirstOrDefault(c => c.Id == id);
            if (cigar != null)
            {
                ListofCigars.Remove(cigar);
            }
            return cigar;
        }
    }
}
