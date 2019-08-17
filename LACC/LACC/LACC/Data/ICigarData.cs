using LACC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LACC.Data
{
    public interface ICigarData
    {
        IEnumerable<Cigar> GetAll();
        IEnumerable<Cigar> GetCigarsByName(string name);
        Cigar GetById(int id);
        Cigar Update(Cigar updatedCigar);
        Cigar Add(Cigar newCigar, IEnumerable<Cigar> cigars);
        Cigar Delete(int id, IEnumerable<Cigar> cigars);
    }
}
