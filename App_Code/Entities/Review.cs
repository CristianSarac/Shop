using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Review
/// </summary>
public class Review
{
    public User User { get; set; }
    public Product Product { get; set; }
    public String ReviewText { get; set; }
    public int Rating { get; set; }

    public Review(User user, Product product, string reviewText, int rating)
    {
        User = user;
        Product = product;
        ReviewText = reviewText;
        Rating = rating;
    }
}