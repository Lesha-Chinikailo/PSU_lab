namespace asp_SPP_pract_3.Models
{
    public class Carriage
    {
        public int CarriageId { get; set; }
        public int NumberOfSeats { get; set; }

        public int TrainId { get; set; }
        public virtual Train Train { get; set; }
    }
}
