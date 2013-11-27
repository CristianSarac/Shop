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
        string connectionString = ConfigurationManager.ConnectionStrings["productConnection"].ToString() + ";MultipleActiveResultSets=True";
        Debug.WriteLine(connectionString);
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

    public static ArrayList GetProductSizes()
    {
        ArrayList list = new ArrayList();

        string query = string.Format("SELECT DISTINCT size FROM products ");

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
            product.Name, product.Type, product.Artist, product.Size, product.Image, product.Description);
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

    public static void AddToWishlist(Product product, int user_id)
    {
        string query = @"INSERT INTO wishlist VALUES (@productID, @userID)";
        command.CommandText = query;
        command.Parameters.Add(new SqlParameter("@productID", product.Id));
        command.Parameters.Add(new SqlParameter("@userID", user_id));
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
    public static List<Product> GetWishlist(int user_id)
    {
        List<Product> list = new List<Product>();

        string query = string.Format("SELECT * FROM products,wishlist WHERE wishlist.userID='{0}' AND products.id=wishlist.productID", user_id);

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

    public static void RemoveFromWishlist(Product product, int user_id)
    {
        string query = @"DELETE FROM wishlist WHERE userID=@userID AND productID=@productID";
        command.CommandText = query;
        command.Parameters.Add(new SqlParameter("@userID", user_id));
        command.Parameters.Add(new SqlParameter("@productID", product.Id));
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
                    query = string.Format("SELECT email, user_type,id FROM users WHERE name = '{0}'", name);
                    command.CommandText = query;

                    SqlDataReader reader = command.ExecuteReader();
                    User user = null;

                    while (reader.Read())
                    {
                        string email = reader.GetString(0);
                        string type = reader.GetString(1);
                        int id = reader.GetInt32(2);

                        user = new User(id, name, password, email, type);
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

    public static bool searchUser(String email)
    {
        string query = string.Format("SELECT COUNT(*) FROM users WHERE email = '{0}'", email);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers < 1)
            {
                Debug.WriteLine(" nui Gasit");
                return false;
            }
            else
            {
                Debug.WriteLine("Exista");
                return true;
            }

        }
        finally
        {
            conn.Close();
        }
    }

    public static User GetUserByEmail(string email)
    {
        string query = string.Format("SELECT * FROM users WHERE email = '{0}'", email);
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
                string userEmail = reader.GetString(3);
                string userType = reader.GetString(4);

                user = new User(id, name, password, userEmail, userType);
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
    public static User GetUserById(int id)
    {
        string query = string.Format("SELECT * FROM users WHERE id = '{0}'", id);
        command.CommandText = query;
        User user = null;

        try
        {
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                string name = reader.GetString(1);
                string password = reader.GetString(2);
                string userEmail = reader.GetString(3);
                string userType = reader.GetString(4);

                user = new User(id, name, password, userEmail, userType);
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

    #endregion

   

    #region Review


    public static List<Review> GetProductReviews(Product product)
    {
        List<Review> list = new List<Review>();

        string query = string.Format("SELECT *  FROM review WHERE product_id= '{0}'", product.Id);

        try
        {
            conn.Open();
            command.CommandText = query;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                string reviewText = reader.GetString(1);
                int rating = reader.GetInt32(2);
                int user_id = reader.GetInt32(3);

                User user = null;

                //------ get user by id--------
                string query2 = string.Format("SELECT * FROM users WHERE id = '{0}'", user_id);
                SqlCommand cmd2 = new SqlCommand("", conn);
                cmd2.CommandText = query2;


                try
                {
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {

                        string name = reader2.GetString(1);
                        string password = reader2.GetString(2);
                        string userEmail = reader2.GetString(3);
                        string userType = reader2.GetString(4);

                        user = new User(user_id, name, password, userEmail, userType);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                // --- user retrived


                Review r = new Review(user, product, reviewText, rating);
                list.Add(r);
            }
        }
        finally
        {
            conn.Close();
        }

        return list;
    }




    public static void AddReview(Review review)
    {
        try
        {
            //Insert command using SQL Parameters
            command.CommandText = "INSERT INTO review VALUES (@reviewText, @rating, @userId, @productId)";
            conn.Open();


            command.Parameters.Add(new SqlParameter("@reviewText", review.ReviewText));
            command.Parameters.Add(new SqlParameter("@rating", review.Rating));
            command.Parameters.Add(new SqlParameter("@userId", review.User.Id));
            command.Parameters.Add(new SqlParameter("@productId", review.Product.Id));

            //Execute query and clear parameters
            command.ExecuteNonQuery();
            command.Parameters.Clear();

        }
        finally
        {
            conn.Close();
        }
    }

    #endregion




   
}