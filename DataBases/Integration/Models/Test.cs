namespace DataBases.Integration.Models
{
    public class TestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Status { get; set; }
        public string MethodName { get; set; }
        public int Project { get; set; }
        public int Session { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Env { get; set; }
        public string Browser { get; set; }
        public object AuthorId { get; set; }
    }
}
