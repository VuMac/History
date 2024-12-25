using HistoryQuest.HTTP;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace HistoryQuest.Views.ClassList;
public class HistoryClass
{
    public string name { get; set; }
    public Guid id { get; set; }
    public string description { get; set; }
}
public class HistoryClassList
{
    public List<HistoryClass> items { get; set; }
    public int totalCount { get; set; }
    public int pageIndex { get; set; }
    public int pageSize { get; set; }
}
public partial class ClassList : ContentPage
{
    // ObservableCollection để tự động cập nhật UI
    public ObservableCollection<HistoryClass> HistoryList { get; set; }

    public ClassList()
    {
        InitializeComponent();

        // Khởi tạo danh sách
        HistoryList = new ObservableCollection<HistoryClass>();

        // Gán BindingContext
        BindingContext = this;

        // Gọi API để lấy danh sách lớp học
        GetListClass();
    }

  
    // Phương thức gọi API lấy danh sách lớp học
    private async void GetListClass()
    {
        try
        {
            // Lấy JWT từ Preferences
            var jwtString = Preferences.Get("tokenJWT", string.Empty);
            if (string.IsNullOrEmpty(jwtString))
            {
                Console.WriteLine("JWT Token is missing");
                return;
            }

            // Cấu hình HttpClient
            using var httpClient = new HttpClient(new CustomHttpClientHandler());
            string apiUrlGetList = "https://192.168.1.6:5000/api/ClassHistory/GetAll?index=1&size=20";
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtString);

            // Gửi yêu cầu GET
            HttpResponseMessage response = await httpClient.GetAsync(apiUrlGetList);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize JSON response
                var items = JsonSerializer.Deserialize<List<HistoryClass>>(responseBody);

                // Kiểm tra dữ liệu trả về và cập nhật danh sách
                if (items.Count() != 0)
                {
                    HistoryList.Clear(); // Xóa dữ liệu cũ nếu có
                    foreach (var item in items)
                    {
                        if(!HistoryList.Contains(item))
                        {
                            HistoryList.Add(item);
                        }   
                    }
                }
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception occurred: {ex.Message}");
        }
    }
}