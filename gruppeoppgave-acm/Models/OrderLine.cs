namespace gruppeoppgave_acm.Models
{
    public class OrderLine
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Order Order { get; set; }
    }
}