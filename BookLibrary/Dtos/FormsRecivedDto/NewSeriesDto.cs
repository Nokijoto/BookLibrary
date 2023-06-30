namespace BookLibrary.Dtos.FormsRecivedDto
{
    public class NewSeriesDto
    {
        public int SeriesId { get; set; }
        public Guid SeriesUuid { get; set; }
        public string SeriesName { get; set; }
        public string PublishedDate { get; set; }
        public string SeriesDescription { get; set; }
    }
}
