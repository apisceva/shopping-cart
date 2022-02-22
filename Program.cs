using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    class Program
    {
        private const string CategoryName = "Category Name";
        private const string V = "Product Name";

        static void Main(string[] args)
        {
            string queryString = @"select
cat.Name as 'Category Name',
pr.Name as 'Product Name'
from
dbo.Category cat
left join dbo.Product pr on pr.CategoryID = cat.ID
where pr.Name is not null
order by
cat.Name";
//                                    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ShoppingCart;Integrated Security=True"
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Initial Catalog=ShoppingCart";
            //string connectionString = @"Source=STONE037\SQLEXPRESS;Initial Catalog=ShopingCart;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
               // command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}",
                        reader[CategoryName], reader[V])); 
                      
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            Console.ReadLine();
        }
    }
}
