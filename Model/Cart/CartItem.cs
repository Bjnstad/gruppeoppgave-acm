namespace oslomet_film.Model
{
    public class CartItem
    {
        public int ID { get; set; } 
        public int Price { get; set; } // Prevents price change after added to cart
        public virtual Movie Movie { get; set; }
    }
}
