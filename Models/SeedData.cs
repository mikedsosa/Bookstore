using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mike05.Models.ViewModels;
namespace Mike05.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            //setup context
            BookDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<BookDbContext>();

            //do any migrations that are pending
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //if context doesn't have any books yet, put them in using book objects
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        TotalPages = 1488
                    },

                    new Book
                    {
                        Title = "Team of Rivals",
                        AuthorFirst = "Doris",
                        AuthorMiddle = "Kearns",
                        AuthorLast = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58,
                        TotalPages = 944
                    },

                    new Book
                    {
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorLast = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54,
                        TotalPages = 832
                    },

                    new Book
                    {
                        Title = "American Ulysses",
                        AuthorFirst = "Ronald",
                        AuthorMiddle = "C.",
                        AuthorLast = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61,
                        TotalPages = 864
                    },

                    new Book
                    {
                        Title = "Unbroken",
                        AuthorFirst = "Laura",
                        AuthorLast = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33,
                        TotalPages = 528
                    },

                    new Book
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirst = "Michael",
                        AuthorLast = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95,
                        TotalPages = 288
                    },

                    new Book
                    {
                        Title = "Deep Work",
                        AuthorFirst = "Cal",
                        AuthorLast = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99,
                        TotalPages = 304
                    },

                    new Book
                    {
                        Title = "It's Your Ship",
                        AuthorFirst = "Michael",
                        AuthorLast = "Abarashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66,
                        TotalPages = 240
                    },

                    new Book
                    {
                        Title = "The Virgin Way",
                        AuthorFirst = "Richard",
                        AuthorLast = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16,
                        TotalPages = 400
                    },

                    new Book
                    {
                        Title = "Sycamore Row",
                        AuthorFirst = "John",
                        AuthorLast = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03,
                        TotalPages = 642
                    },

                    //bring in 3 of my own favorite books. Give them a cover image to be placed on their card
                    new Book
                    {
                        Title = "Ender in Exile",
                        AuthorFirst = "Orson",
                        AuthorMiddle = "Scott",
                        AuthorLast = "Card",
                        Publisher = "St. Martins Press-3PL",
                        ISBN = "978-0765304964",
                        Classification = "Fiction",
                        Category = "Science Fiction",
                        Price = 8.69,
                        TotalPages = 369,
                        CoverImg = "https://th.bing.com/th/id/R181ee4567dfb35864967a4e3bf95e1a6?rik=l9tpRClhr9%2bv1A&riu=http%3a%2f%2ftheabsolutemag.com%2fwp-content%2fuploads%2f2015%2f06%2fender-in-exile-976x448.jpg&ehk=a48wFqry2DSVOPAGU8bo3XTIvA1Aa31OSy%2bSRM%2bNAoc%3d&risl=&pid=ImgRaw"
                    },

                    new Book
                    {
                        Title = "Magnus Chase and the Gods of Asgard: The Sword of Summer",
                        AuthorFirst = "Rick",
                        AuthorLast = "Riordan",
                        Publisher = "Disney-Hyperion Books",
                        ISBN = "978-1423160915",
                        Classification = "Fiction",
                        Category = "Fantasy",
                        Price = 8.99,
                        TotalPages = 499,
                        CoverImg = "https://bookstacked.com/wp-content/uploads/2015/10/MAGNUS-CHASE_jacket_FINAL2.jpg"
                    },

                    new Book
                    {
                        Title = "Pendragon: The Merchant of Death",
                        AuthorFirst = "D.J.",
                        AuthorLast = "MacHale",
                        Publisher = "Aladdin Paperbacks",
                        ISBN = "978-0743437318",
                        Classification = "Fiction",
                        Category = "Fantasy",
                        Price = 9.99,
                        TotalPages = 375,
                        CoverImg = "https://m.media-amazon.com/images/I/51fRfpkOZEL._SL500_.jpg"
                    }
                );

                //save books to context
                context.SaveChanges();
            }
        }
    }
}

