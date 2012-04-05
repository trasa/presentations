using System;
using System.Data.SqlClient;
using System.Linq;

namespace LinqConcurrency
{
    internal class Program
    {
        private const string ConnectionString = @"Data Source=(local);Initial Catalog=LinqConcurrencyTest;Integrated Security=True";


        private static void Main()
        {
            MakeLotsOfData();

            ShowNumberOfRowsProcessed();

            Console.WriteLine("First Run:");
            RunTests();
            Console.WriteLine("===========");
            Console.WriteLine("Second Run:");
            RunTests();
            Console.WriteLine("===========");
            Console.WriteLine("Third Run:");
            RunTests();

            Console.WriteLine("[Hit Enter]");
            Console.ReadLine();
        }

        private static void RunTests()
        {
            Console.WriteLine("\nFind distinct categories via SQL:");
            FindDistinctCategoriesSql();

            Console.WriteLine("\nFind Distinct Categories via LINQ:");
            FindDistinctCategoriesLinq();

            Console.WriteLine("\nFind Distinct Categories via LINQ from DataReader:");
            FindDistinctCategoriesDataReaderLinq();
        }


        /// <summary>
        /// Use plain old boring SQL to get the distinct set of category ids.
        /// This is going to be the fastest (typically) because its what SQL is very, 
        /// very good at.
        /// </summary>
        private static void FindDistinctCategoriesSql()
        {
            var watch = new Stopwatch();
            watch.Start();
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                int i = 0;
                var cmd = new SqlCommand("SELECT DISTINCT ResultCategoryID FROM SearchResults", conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        i += dr.GetInt32(0);
                    }
                }
            }
            long result = watch.Stop();
            ReportResult(watch, result);
        }

        /// <summary>
        /// Use LinqToSql to retrieve a collection of objects, then turn that into a 
        /// distinct set (which might all be done within one SQL statement, explaining 
        /// the performance)
        /// </summary>
        private static void FindDistinctCategoriesLinq()
        {
            var watch = new Stopwatch();
            watch.Start();
            var db = new SearchResultsContext();
            int i = 0;
            // figure out how many distinct categories we can find in the entire table:
            var distinctCategories = (from sr in db.SearchResults select new {sr.ResultCategoryID}).Distinct();
            foreach (var cat in distinctCategories)
            {
                i += cat.ResultCategoryID;
            }

            long result = watch.Stop();
            ReportResult(watch, result);
        }



        /// <summary>
        /// Get a plain old DataReader, then feed that into the DBContext to retrieve
        /// objects, then operate on the collection of objects.
        /// </summary>
        private static void FindDistinctCategoriesDataReaderLinq()
        {
            var watch = new Stopwatch();
            watch.Start();
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                int i = 0;
                var cmd = new SqlCommand("SELECT * FROM SearchResults", conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    var db = new SearchResultsContext();
                    var results = db.Translate<SearchResult>(dr);
                    // figure out how many distinct categories we can find in the entire table:
                    var distinctCategories = (from sr in results select new { sr.ResultCategoryID }).Distinct();
                    foreach (var cat in distinctCategories)
                    {
                        i += cat.ResultCategoryID;
                    }
                }
            }
            long result = watch.Stop();
            ReportResult(watch, result);
        }

        private static void ShowNumberOfRowsProcessed()
        {
            // using boring ADO.Net to get this so we don't skew the initial LinqToSql numbers.
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT COUNT(0) FROM SearchResults", conn);
                var count = (int)cmd.ExecuteScalar();
                Console.WriteLine("There are " + count + " rows in the target table.");
            }
        }


        private static void MakeLotsOfData()
        {
            const int RecordsToCreate = 10000;

            Console.WriteLine("Writing another " + RecordsToCreate + " records into the target table.");
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO SearchResults (ResultName, ResultCategoryID) VALUES ('blah.doc', @catId)", conn);
                for (int i = 0; i < RecordsToCreate; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@catId", (i%5) + 1);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void ReportResult(Stopwatch watch, long result)
        {
            Console.WriteLine("Total Time: " + watch.ConvertToMs(result) + " ms.");
        }
    }
}