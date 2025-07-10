namespace UserInfoApp.Domain.Entities
{
    public class Info
    {
        public int PersonId { get; set; }
        public string TellNo { get; set; }
        public string CellNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressCode { get; set; }
        public string PostalAddress1 { get; set; }
        public string PostalAddress2 { get; set; }
        public string PostalCode { get; set; }
        public Person Person { get; set; }
    }
}
