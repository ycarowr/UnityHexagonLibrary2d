using System.Collections.Generic;
using NUnit.Framework;

namespace Tools.GenericCollection.Editor
{
    //class used to execute tests
    public class TestUnit
    {
    }

    public class CollectionTest
    {
        [Test]
        public void ExceptionAddNull()
        {
            //create collection
            var collection = new Collection<TestUnit>();

            //create null instances
            TestUnit nullObj = null;
            List<TestUnit> nullList = null;

            void AddNull() => collection.Add(nullObj);

            void AddListNull() => collection.Add(nullList);

            //Assert add exceptions
            Assert.Throws<Collection<TestUnit>.CollectionArgumentException>(AddNull);
            Assert.Throws<Collection<TestUnit>.CollectionArgumentException>(AddListNull);
        }

        [Test]
        public void ExceptionDuplicatedElement()
        {
            //create collection
            var collection = new Collection<TestUnit>();

            //create object
            var obj = new TestUnit();

            //create duplicated object
            var duplicatedObj = obj;

            //add first object
            collection.Add(obj);

            //assert duplication exception
            void AddDuplicated() => collection.Add(duplicatedObj);

            Assert.Throws<Collection<TestUnit>.CollectionArgumentException>(AddDuplicated);

            //list with a duplicated element
            var listDuplicated = new List<TestUnit> {obj, duplicatedObj};

            //assert duplication exception
            void AddDuplicatedAgain() => collection.Add(listDuplicated);

            Assert.Throws<Collection<TestUnit>.CollectionArgumentException>(AddDuplicatedAgain);
        }


        [Test]
        public void AddObject()
        {
            //create collection
            var collection = new Collection<TestUnit>();

            //cache size
            var sizeBefore = collection.Count;

            //create object
            var testObj = new TestUnit();

            //add object
            collection.Add(testObj);

            //assert if the object is inside the list
            Assert.True(collection.Has(testObj));
            Assert.True(collection.Count == sizeBefore + 1);
        }

        [Test]
        public void Add100Objects()
        {
            for (var i = 0; i < 100; i++)
                AddObject();
        }

        [Test]
        public void RemoveObject()
        {
            //create collection
            var collection = new Collection<TestUnit>();

            //create object
            var testObj = new TestUnit();

            //add object
            collection.Add(testObj);

            //remove object
            Assert.True(collection.Remove(testObj));

            //assert if the object has been removed from the list
            Assert.False(collection.Has(testObj));
            Assert.True(collection.Count == 0);
        }


        [Test]
        public void RemoveNotAddedObject()
        {
            //create collection
            var collection = new Collection<TestUnit>();

            //create object
            var testObj = new TestUnit();

            //add object
            Assert.False(collection.Remove(testObj));

            //assert if the object has been removed from the list
            Assert.False(collection.Has(testObj));
            Assert.True(collection.Count == 0);
        }
    }
}