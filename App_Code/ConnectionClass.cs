using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;

public static class ConnectionClass
{
    private static SqlConnection conn;
    private static SqlCommand command;

    static ConnectionClass()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["productConnection"].ToString() + ";MultipleActiveResultSets=True";
       
        conn = new SqlConnection(connectionString);
        command = new SqlCommand("", conn);
    }

    #region Product

    public static ArrayList GetProductTypes()
    {
        ArrayList list = new ArrayList();

        string query = "SELECT DISTINCT type FROM products ";


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

        string query = "SELECT DISTINCT size FROM products ";

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
        string query = "SELECT * FROM products WHERE (name LIKE '%'+ @keyword +'%') OR (artist LIKE '%' + @keyword + '%') OR (type LIKE '%' + @keyword + '%') OR (description LIKE '%' + @keyword + '%')";

        try
        {
            conn.Open();
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter("@keyword",  keyword));
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
                string description = reader.GetString(7);

                Product product = new Product(id, name, type, price, artist, size, image, description);
                list.Add(product);
            }
        }
        finally
        {
            command.Parameters.Clear();
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
                string description = reader.GetString(7);

                Product product = new Product(id, name, type, price, artist, size, image, description);
                list.Add(product);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error retrieving all products: " +ex.Message);
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
        string query = "SELECT * FROM products WHERE type LIKE @product_type";

        try
        {
            conn.Open();
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter("@product_type",productType));
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
                string description = reader.GetString(7);

                Product product = new Product(id, name, type, price, artist, size, image, description);
                list.Add(product);
            }
        }
        finally
        {
            command.Parameters.Clear();
            conn.Close();
        }

        return list;
    }

    public static Product GetProductById(int id)
    {
        string query = "SELECT * FROM products WHERE id =  @id";
        Product product = null;

        try
        {
            conn.Open();
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(1);
                string type = reader.GetString(2);
                double price = reader.GetDouble(3);
                string artist = reader.GetString(4);
                string size = reader.GetString(5);
                string image = reader.GetString(6);
                string description = reader.GetString(7);

                product = new Product(name, type, price, artist, size, image, description);
            }
        }
        finally
        {
            command.Parameters.Clear();
            conn.Close();
        }

        return product;
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

        string query = "SELECT * FROM products,wishlist WHERE wishlist.userID= @user_id AND products.id=wishlist.productID";

        try
        {
            conn.Open();
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter("@user_id",user_id));
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
                string description = reader.GetString(7);

                Product product = new Product(id, name, type, price, artist, size, image, description);
                list.Add(product);
            }
        }
        finally
        {
            command.Parameters.Clear();
            conn.Close();
        }

        return list;
    }

    public static void RemoveFromWishlist(Product product, int user_id)
    {
        string query = "DELETE FROM wishlist WHERE userID=@userID AND productID=@productID";
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

    public static bool CheckWishList(int productId, int userId)
    {
        try
        {
            command.CommandText = "Select COUNT (*) FROM wishlist WHERE userID= @user_id AND productID=@product_id";
            conn.Open();
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@product_id", productId));
            command.Parameters.Add(new SqlParameter("@user_id", userId));
            int amount = (int)command.ExecuteScalar();
            if (amount > 0)
            {
                return true;
            }

        }
        finally
        {
            command.Parameters.Clear();
            conn.Close();
        }

        return false;
    }

    #endregion

    #region Users

    public static String UpdatePassword(String email,string password)
    { 
        int col=-1;
        try
        {
            string query = "Update Product.dbo.users set password=@user_password WHERE email=@user_email ";
            command = new SqlCommand(query, conn);
            command.Parameters.Clear();
            conn.Open();
            command.Parameters.Add("@user_password", password);
            command.Parameters.Add("@user_email", email);
            col = command.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            command.Parameters.Clear();
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        if (col == -1)
        {
            return "Update password failed";
        }
       
        return "Password update successfuly";
       

    }

    public static User LoginUser(string email, string password)
    {
        //Check if user exists
        string query = "SELECT COUNT(*) FROM ProductDB.dbo.users WHERE email = @email";
        command.CommandText = query;

        try
        {
            conn.Open();
            command.Parameters.Add(new SqlParameter("@email", email));
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers == 1)
            {
                //User exists, check if the passwords match
                query = "SELECT password FROM users WHERE email = @email";
                command.CommandText = query;

                string dbPassword = command.ExecuteScalar().ToString();

                if (dbPassword == password)
                {
                    //Passwords match. Login and password data are known to us.
                    //Retrieve further user data from the database
                    query = "SELECT name, user_type,id FROM users WHERE email = @email";
                    command.CommandText = query;

                    SqlDataReader reader = command.ExecuteReader();
                    User user = null;

                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
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
            command.Parameters.Clear();
            conn.Close();
        }
    }

    public static User GetUserDetails(string userName)
    {
        string query = string.Format("SELECT * FROM users WHERE name = @user_name", userName);
        command.CommandText = query;
        command.Parameters.Add(new SqlParameter("@user_name", userName));
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
            command.Parameters.Clear();
            conn.Close();
        }
        return user;
    }

    public static string RegisterUser(User user)
    {
        //Check if user exists
        string query = "SELECT COUNT(*) FROM users WHERE email = @email";
        command.CommandText = query;
        command.Parameters.Add(new SqlParameter("@email", user.Email));

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();
            if (amountOfUsers < 1)
            {
                //User does not exist, create a new user
                query = "INSERT INTO users VALUES (@name, @password, @email, @type)";

                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@name", user.Name));
                command.Parameters.Add(new SqlParameter("@password", user.Password));
                command.Parameters.Add(new SqlParameter("@email", user.Email));
                command.Parameters.Add(new SqlParameter("@type", user.Type));
                command.ExecuteNonQuery();
                return "User registered!";
            }
            else
            {
                //User exists
                return "A user with this email already exists";
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error registering user: " + ex.Message);
            return null;
        }
        finally
        {
            command.Parameters.Clear();
            conn.Close();
        }
    }
    // To do Metoda asta nu e identica cu cea de jos 
    public static bool searchUser(String email)
    {
        string query = "SELECT COUNT(*) FROM users WHERE email = @email";
        command.CommandText = query;
        command.Parameters.Add(new SqlParameter("@email", email));

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers < 1)
            {

                return false;
            }
            else
            {

                return true;
            }

        }
        finally
        {
            command.Parameters.Clear();
            conn.Close();
        }
    }

    public static User GetUserByEmail(string email)
    {
        string query = string.Format("SELECT * FROM users WHERE email = @email");
        command.CommandText = query;
        command.Parameters.Add(new SqlParameter("@email", email));
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
            command.Parameters.Clear();
            conn.Close();
        }
        return user;
    }
    public static User GetUserById(int id)
    {
        string query = "SELECT * FROM users WHERE id = @id";
        command.CommandText = query;
         command.Parameters.Add(new SqlParameter("@id", id));
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
            command.Parameters.Clear();
            conn.Close();
        }
        return user;
    }

    #endregion

    #region Review


    public static List<Review> GetProductReviews(Product product)
    {
        List<Review> list = new List<Review>();

        string query = "SELECT *  FROM review WHERE product_id= @product_id";

        try
        {
            conn.Open();
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter("@product_id", product.Id));

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                string reviewText = reader.GetString(1);
                int rating = reader.GetInt32(2);
                int user_id = reader.GetInt32(3);

                User user = null;

                //------ get user by id--------
                string query2 = "SELECT * FROM users WHERE id = @user_id";
                SqlCommand cmd2 = new SqlCommand("", conn);
                cmd2.CommandText = query2;
                cmd2.Parameters.Add(new SqlParameter("@user_id", user_id));



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
                cmd2.Parameters.Clear();
                // --- user retrived


                Review r = new Review(user, product, reviewText, rating);
                list.Add(r);
            }
        }
        finally
        {
            conn.Close();
        }
        command.Parameters.Clear();
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