namespace asp_SPP_pract_3.Models
{
    public class Train
    {
        public int TrainId { get; set; }
        public string TrainName { get; set;}

        public virtual List<Carriage> Carriages { get; set; }
    }
}
