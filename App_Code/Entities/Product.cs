public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public double Price { get; set; }
    public string Artist { get; set; }
    public string Size { get; set; }
    public string Image { get; set; }
    public string Review { get; set; }

    public Product(int id, string name, string type, double price, string artist, string size, string image, string review)
    {
        Id = id;
        Name = name;
        Type = type;
        Price = price;
        Artist = artist;
        Size = size;
        Image = image;
        Review = review;
    }

    public Product(string name, string type, double price, string artist, string size, string image, string review)
    {
        Name = name;
        Type = type;
        Price = price;
        Artist = artist;
        Size = size;
        Image = image;
        Review = review;
    }
}