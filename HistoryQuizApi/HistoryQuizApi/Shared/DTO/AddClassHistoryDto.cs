namespace HistoryQuizApi.Shared.DTO
{
    public class AddClassHistoryDto
    {
        // Khóa chính kiểu GUID
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
