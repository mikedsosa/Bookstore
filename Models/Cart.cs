using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Mike05.Models
{
    public class Cart
    {
        //the Lines object is a list of CartLines
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //the Virtual keyword will allow you to override members of a class
        public virtual void AddItem(Book book, int qty)
        //public void AddItem(Book book, int qty, double price)
        {
            //the next block will check to see if you have the selected item in your cart
            CartLine line = Lines
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            //if you don't, it'll add it to the cart
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = qty
                    //Price = (decimal)price
                });
            }
            //if you do, it'll update the quantity rather than adding the item twice
            else
            {
                line.Quantity += qty;
            }
        }

        //remove ONE item from the cart
        public virtual void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookId == book.BookId);

        //remove ALL items from cart
        public virtual void Clear() => Lines.Clear();

        //Get total price for the items in the cart
        //price is hard coded here; for the assignment you will do e.Price or something like that
        public decimal ComputeTotalSum() => Lines.Sum(e => (decimal)e.Book.Price * e.Quantity);

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
            //????????????????????????????????????????????????????????????????????????????????????????????????
            //public int Price { get; set; }
        }
    }
}
