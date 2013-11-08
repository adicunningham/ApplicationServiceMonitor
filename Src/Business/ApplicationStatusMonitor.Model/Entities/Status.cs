namespace ApplicationStatusMonitor.Model.Entities
{
    public class Status : BaseEntity
    {
        public Status()
        {
            
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
