namespace MicroMachines.Entities
{
    public interface IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Funds { get; set; }
    }
}
