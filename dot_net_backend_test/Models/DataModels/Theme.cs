namespace dot_net_backend_test.Models.DataModels
{
    public class Theme: BaseEntity
    {
        public int ChaptersId { get; set; }
        public virtual Chapters? Chapters { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
