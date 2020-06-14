using System.Collections.Generic;
using System.Text;

namespace Tipalty.Core
{
    public interface IRelationUtility
    {
        //  - Initialization of the utility with person instances.
        void Init(Person[] people);

        //  - Returns the
        // minimal level of relation between personA and personB.If they are not related, return -1.
        int FindMinRelationLevel(Person personA, Person personB);
    }
}
