using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{ 
    public interface ISpecialRepository
    {
        int GetDemandOfObject(int objectID, DateTime from, DateTime to);
        List<Tuple<Person, int>> GetSatisfiedClients(float lowerArea, float higherArea, float deltaArea, DateTime from, DateTime to);
    }
}
