namespace WebAPI.Models
{
    public class vdCompetition
    {
        public int CID { get; set; }
        public int ParentID { get; set; }
        public string? Organizer { get; set; }
        public string? CompetitionItem { get; set;}
        public string? ItemDescription { get; set; }
        public int nLevel { get; set; }
        public int AID { get; set; }
        public string? FileName { get; set; }
    }
    public class CompetitionModel
    {
        public int CCID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int NewCID { get; set; }
    }
}
