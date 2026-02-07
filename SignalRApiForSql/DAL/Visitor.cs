namespace SignalRApiForSql.DAL
{

    public enum ECity //Enum dizisi oluşturuyoruz.
    {
        Bayburt = 1,
        Istanbul = 2,
        Ankara = 3,
        Edirne = 4,
        Bursa = 5

    }
    public class Visitor
    {
        public int VisitorID { get; set; }
        public ECity City { get; set; }
        public int CityVisitCount { get; set; }
        public DateTime VisitDate { get; set; }
    }

}
