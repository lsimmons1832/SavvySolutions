namespace Savvy.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Minutes { get; set; }
        public double Price { get; set; }
        public virtual Stylist Stylist { get; set; }
    }
}