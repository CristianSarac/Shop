using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Entities;
using System.Diagnostics;

public static class ConnectionClass
{
    private static SqlConnection conn;
    private static SqlCommand command;

    static ConnectionClass()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["productConnection"].ToString();
        conn = new SqlConnection(connectionString);
        command = new SqlCommand("", conn);
    }

    #region Product

    public static ArrayList GetProductTypes()
    {
        ArrayList list = new ArrayList();
        
        string query = string.Format("SELECT DISTINCT type FROM products ");

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                
                string type = reader.GetString(0);
                list.Add(type);
            }
        }
        finally
        {
            conn.Close();
        }

        return list;
    }

    public static List<Product> GetProductsByKeyword(string keyword)
    {
        List<Product> list = new List<Product>();
        Debug.WriteLine(keyword);
        string query = string.Format("SELECT * FROM products WHERE name LIKE '%{0}%' OR artist LIKE '%{0}%' OR type LIKE '%{0}%' OR review LIKE '%{0}%' ", keyword);

        try
        {
            conn.Open();
            
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
           
            while (reader.Read())
            {
                
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string type = reader.GetString(2);
                double price = reader.GetDouble(3);
                string artist = reader.GetString(4);
                string size = reader.GetString(5);
                string image = reader.GetString(6);
                string review = reader.GetString(7);

                Product product = new Product(id, name, type, price, artist, size, image, review);
                list.Add(product);
            }
        }
        finally
        {
            conn.Close();
        }

        return list;
    }

    public static List<Product> GetAllProducts()
    {
       List<Product> list = new List<Product>();

        string query = string.Format("SELECT * FROM products ");

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string type = reader.GetString(2);
                double price = reader.GetDouble(3);
                string artist = reader.GetString(4);
                string size = reader.GetString(5);
                string image = reader.GetString(6);
                string review = reader.GetString(7);

                Product product = new Product(id, name, type, price, artist, size, image, review);
                list.Add(product);
            }
        }
        finally
        {
            conn.Close();
        }

        return list;
    }

    public static ArrayList GetProductByType(string productType)
    {
        ArrayList list = new ArrayList();
        string query = string.Format("SELECT * FROM products WHERE type LIKE '{0}'", productType);

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string type = reader.GetString(2);
                double price = reader.GetDouble(3);
                string artist = reader.GetString(4);
                string size = reader.GetString(5);
                string image = reader.GetString(6);
                string review = reader.GetString(7);

                Product product = new Product(id, name, type, price, artist, size, image, review);
                list.Add(product);
            }
        }
        finally
        {
            conn.Close();
        }

        return list;
    }

    public static Product GetProductById(int id)
    {
        string query = String.Format("SELECT * FROM products WHERE id =  '{0}'", id);
        Product product = null;

        try
        {
            conn.Open();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(1);
                string type = reader.GetString(2);
                double price = reader.GetDouble(3);
                string artist = reader.GetString(4);
                string size = reader.GetString(5);
                string image = reader.GetString(6);
                string review = reader.GetString(7);

                product = new Product(name, type, price, artist, size, image, review);
            }
        }
        finally
        {
            conn.Close();
        }

        return product;
    }

    public static void AddProduct(Product product)
    {
        string query = string.Format(
            @"INSERT INTO products VALUES ('{0}', '{1}', @prices, '{2}', '{3}','{4}', '{5}')",
            product.Name, product.Type, product.Artist, product.Size, product.Image, product.Review);
        command.CommandText = query;
        command.Parameters.Add(new SqlParameter("@prices", product.Price));
        try
        {
            conn.Open();
            command.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }
    #endregion

    #region Users
    public static User LoginUser(string name, string password)
    {
        //Check if user exists
        string query = string.Format("SELECT COUNT(*) FROM ProductDB.dbo.users WHERE name = '{0}'", name);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers == 1)
            {
                //User exists, check if the passwords match
                query = string.Format("SELECT password FROM users WHERE name = '{0}'", name);
                command.CommandText = query;
                string dbPassword = command.ExecuteScalar().ToString();

                if (dbPassword == password)
                {
                    //Passwords match. Login and password data are known to us.
                    //Retrieve further user data from the database
                    query = string.Format("SELECT email, user_type FROM users WHERE name = '{0}'", name);
                    command.CommandText = query;

                    SqlDataReader reader = command.ExecuteReader();
                    User user = null;

                    while (reader.Read())
                    {
                        string email = reader.GetString(0);
                        string type = reader.GetString(1);

                        user = new User(name, password, email, type);
                    }
                    return user;
                }
                else
                {
                    //Passwords do not match
                    return null;
                }
            }
            else
            {
                //User does not exist
                return null;
            }
        }
        finally
        {
            conn.Close();
        }
    }

    public static User GetUserDetails(string userName)
    {
        string query = string.Format("SELECT * FROM users WHERE name = '{0}'", userName);
        command.CommandText = query;
        User user = null;

        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string password = reader.GetString(2);
                string email = reader.GetString(3);
                string userType = reader.GetString(4);

                user = new User(id, name, password, email, userType);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
        }
        return user;
    }

    public static string RegisterUser(User user)
    {
        //Check if user exists
        string query = string.Format("SELECT COUNT(*) FROM users WHERE email = '{0}'", user.Email);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers < 1)
            {
                //User does not exist, create a new user
                query = string.Format("INSERT INTO users VALUES ('{0}', '{1}', '{2}', '{3}')", user.Name, user.Password,
                                      user.Email, user.Type);
                command.CommandText = query;
                command.ExecuteNonQuery();
                return "User registered!";
            }
            else
            {
                //User exists
                return "A user with this email already exists";
            }
        }
        finally
        {
            conn.Close();
        }
    }

    #endregion

    #region Orders
    public static void AddOrders(ArrayList orders)
    {
        try
        {
            //Insert command using SQL Parameters
            command.CommandText = "INSERT INTO orders VALUES (@client, @product, @amount, @price, @date, @orderSent)";
            conn.Open();

            //Update values for each order in List
            foreach (Order order in orders)
            {
                command.Parameters.Add(new SqlParameter("@client", order.Client));
                command.Parameters.Add(new SqlParameter("@product", order.Product));
                command.Parameters.Add(new SqlParameter("@amount", order.Amount));
                command.Parameters.Add(new SqlParameter("@price", order.Price));
                command.Parameters.Add(new SqlParameter("@date", order.Date));
                command.Parameters.Add(new SqlParameter("@orderSent", order.OrderShipped));

                //Execute query and clear parameters
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
        }
        finally
        {
            conn.Close();
        }
    }

    public static void UpdateOrders(string client, DateTime date)
    {
        string query = string.Format(@"UPDATE [ProductDB].[dbo].[orders]
                                       SET orderShipped = 1
                                       WHERE client = @client
                                       AND date = @date");
        try
        {
            conn.Open();
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter("@client", client));
            command.Parameters.Add(new SqlParameter("@date", date));
            command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
    }

    public static ArrayList GetGroupedOrders(DateTime currentDate, DateTime endDate, Boolean shipped)
    {
        const string query = @"SELECT client, date, SUM(total) as total
                                FROM (
	                                    SELECT client, date, (amount * price) AS total
	                                    FROM [ProductDB].[dbo].[orders]
	                                    WHERE date >= @date1
	                                    AND date <= @date2
                                        AND orderShipped = @shipped
                                )as result
                                GROUP BY client, date";
        ArrayList orderList = new ArrayList();
        int lastDay;

        //Check if current date.month == enddate.month
        if (currentDate.Month == endDate.Month && currentDate.Year == endDate.Year)
        {
            //Yes, Last day to be displayed is the selected date in txtOpenOrders2. (Orders page)
            lastDay = endDate.Day;
        }
        else
        {
            //No, Other months will be displayed after this one. Last day = Last day of the month.
            lastDay = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
        }

        DateTime date2 = new DateTime(currentDate.Year, currentDate.Month, lastDay);

        try
        {
            conn.Open();
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter("@date1", currentDate));
            command.Parameters.Add(new SqlParameter("@date2", date2));
            command.Parameters.Add(new SqlParameter("@shipped", shipped));
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string client = reader.GetString(0);
                DateTime date = reader.GetDateTime(1);
                double total = reader.GetDouble(2);

                GroupedOrder groupedOrder = new GroupedOrder(client, date, total);
                orderList.Add(groupedOrder);
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }

        return orderList;
    }

    public static ArrayList GetDetailedOrders(string client, DateTime date)
    {
        const string query = @" SELECT id, product, amount, price, orderShipped
                                FROM orders WHERE client = @client AND date = @date";
        ArrayList orderList = new ArrayList();

        try
        {
            conn.Open();
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter("@client", client));
            command.Parameters.Add(new SqlParameter("@date", date));
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string product = reader.GetString(1);
                int amount = reader.GetInt32(2);
                double price = reader.GetDouble(3);
                bool orderShipped = reader.GetBoolean(4);

                Order order = new Order(id, client, product, amount, price, date, orderShipped);
                orderList.Add(order);
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
            command.Parameters.Clear();
        }
        return orderList;
    }

    #endregion

    #region Charts
    public static DataTable GetChartData(string query)
    {
        command.CommandText = query;
        DataTable dt = new DataTable();

        try
        {
            conn.Open();

            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                sda.SelectCommand = command;
                sda.Fill(dt);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        finally
        {
            conn.Close();
        }

        return dt;
    }
    #endregion
}