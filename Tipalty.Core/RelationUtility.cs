using System;
using System.Collections.Generic;
using System.Linq;

namespace Tipalty.Core
{
    public class RelationUtility : IRelationUtility
    {

        private Dictionary<Person, Person[]> _relationIndex;

        public void Init(Person[] items)
        {
            items = items ?? new Person[0];

            _relationIndex = items.ToDictionary(k => k, v => new Person[0]);

            foreach (var item in items)
            {
                _relationIndex[item] = items.Where(x =>
                        !ReferenceEquals(x, item) &&

                        (Equals(x.FullName, item.FullName) ||
                         Equals(x.Address, item.Address)))
                    .ToArray();
            }
        }

        public int FindMinRelationLevel(Person personA, Person personB)
        {
            
            var idx = FindMinRelationLevel(personA, personB, null);

            return idx;
        }


        // Calculate minimal distance. parentNode - prevent cross references
        private int FindMinRelationLevel(Person personA, Person personB, Person parentNode = null)
        {
            personA = personA ?? throw new ArgumentNullException(nameof(personA));
            personB = personB ?? throw new ArgumentNullException(nameof(personB));

            // Person not have relations
            if (!_relationIndex[personA].Any() ||
                !_relationIndex[personB].Any())
            {
                return -1;
            }


            var idx = -1;
            var relatedPersons = parentNode == null
                ? _relationIndex[personA]
                : _relationIndex[personA].Where(x => !Equals(x, parentNode)).ToArray();

            if (relatedPersons.Contains(personB))
            {
                return 1;
            }

            foreach (var relatedPerson in relatedPersons)
            {
                idx = FindMinRelationLevel(relatedPerson, personB, personA);

                if (idx > 0)
                {
                    idx++;
                    break;
                }
            }

            return idx;
        }
    }
}