using System;
using System.Collections.Generic;
using System.Linq;
using Tipalty.Core;
using Xunit;

namespace Tipalty.Tests
{
    public class RelationUtilityTest
    {
        [Fact]
        public void PersonNotFoundTest()
        {
            var utility = CreateAndInitUtility();
            var firstPerson = Person.Create("Grace", "Hopper", "", "New York");
            var secondPerson = Person.Create("Alan", "Turing", "", "Bletchley park");
            
            var res = utility.FindMinRelationLevel(firstPerson, secondPerson);

            Assert.True(res == -1);
        }


        [Fact]
        public void FistLevelTest()
        {
            var utility = CreateAndInitUtility();
            var firstPerson = Person.Create("Alan", "Turing", "", "Bletchley park");
            var secondPerson = Person.Create("Joan", "Clark", "", "Bletchley park");

            var res = utility.FindMinRelationLevel(firstPerson, secondPerson);

            Assert.True(res == 1);
        }

        [Fact]
        public void SecondLevelTest()
        {

            var utility = CreateAndInitUtility();
            var firstPerson = Person.Create("Alan", "Turing", "", "Bletchley park");
            var secondPerson = Person.Create("Joan", "Clark", "", "London");

            var res = utility.FindMinRelationLevel(firstPerson, secondPerson);

            Assert.True(res == 2);
        }

        [Fact]
        public void ThirdLevelTest()
        {

            var utility = CreateAndInitUtility();
            var firstPerson = Person.Create("Alan", "Turing", "", "Cambridge");
            var secondPerson = Person.Create("Joan", "Clark", "", "London");

            var res = utility.FindMinRelationLevel(firstPerson, secondPerson);

            Assert.True(res == 3);
        }

        public static IRelationUtility CreateAndInitUtility()
        {
            var persons = PopulateData().ToArray();
            var instance = new RelationUtility();

            instance.Init(persons);

            return instance;
        }

        public static IEnumerable<Person> PopulateData()
        {
            yield return Person.Create("Grace", "Hopper", "", "New York");
            yield return Person.Create("Alan", "Turing", "", "Bletchley park");
            yield return Person.Create("Alan", "Turing", "", "Cambridge");
            yield return Person.Create("Joan", "Clark", "", "Bletchley park");
            yield return Person.Create("Joan", "Clark", "", "London");
        }
    }
}
