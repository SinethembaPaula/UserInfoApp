namespace UserInfoApp.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }
        public Info Info { get; set; }
    }
}
