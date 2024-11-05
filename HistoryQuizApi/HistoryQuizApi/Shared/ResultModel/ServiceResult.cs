namespace HistoryQuizApi.Shared.ResultModel
{
    public class ServiceResult
    {
        // Xác định liệu thao tác có thành công hay không
        public bool Success { get; set; }

        // Thông báo kèm theo kết quả (nếu có)
        public string Message { get; set; }

        // Kết quả (dữ liệu) trả về trong trường hợp cần thiết (tùy chọn)
        public object Data { get; set; }

        // Constructor mặc định
        public ServiceResult()
        {
        }

        // Constructor giúp khởi tạo ServiceResult dễ dàng
        public ServiceResult(bool success, string message = null, object data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }

}
