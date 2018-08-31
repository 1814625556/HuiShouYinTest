using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace NinjectExecrise
{
    public class LiteHelper
    {

        private static readonly LiteDatabase _repo;

        static LiteHelper()
        {
            _repo = new LiteDatabase(@"test.db");
        }

        public void Insert<T>(T customer,string collectionName="customer")
        {
            var collection = _repo.GetCollection<T>(collectionName);
            collection.Insert(customer);
        }

        public IEnumerable<T> Query<T>(Expression<Func<T, bool>> predicate, int skip = 0, int limit = 2147483647,string _collectionName="customer")
        {
            return _repo.GetCollection<T>(_collectionName).Find(predicate, skip, limit);
        }

        public static void Test()
        {
            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<Customer>("customers");

                // Create your new customer instance
                var customer = new Customer
                {
                    Name = "John Doe",
                    Phones = new string[] { "8000-0000", "9000-0000" },
                    IsActive = true
                };

                // Insert new customer document (Id will be auto-incremented)
                col.Insert(customer);

                // Update a document inside a collection
                customer.Name = "Joana Doe";

                col.Update(customer);

                // Index document using document Name property
                col.EnsureIndex(x => x.Name);

                // Use LINQ to query documents
                var results = col.Find(x => x.Name.StartsWith("Jo"));

                // Let's create an index in phone numbers (using expression). It's a multikey index
                col.EnsureIndex(x => x.Phones, "$.Phones[*]");

                // and now we can query phones
                var r = col.FindOne(x => x.Phones.Contains("8888-5555"));
            }
        }
        

    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string[] Phones { get; set; }
        public bool IsActive { get; set; }
    }
}
