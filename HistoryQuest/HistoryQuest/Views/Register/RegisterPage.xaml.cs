using System.Text.Json;
using System.Text;
using HistoryQuest.HTTP;
using System.Collections.ObjectModel;
using HistoryQuest.Models;
using System.Diagnostics;
using HistoryQuest.Utility;
using System.Net;

namespace HistoryQuest.Views
{
    public partial class RegisterPage : ContentPage
    {
        public ObservableCollection<User> User { get; set; }

        public RegisterPage()
        {
            try
            {
                InitializeComponent();
                BindingContext = this;
                User = [];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

       
        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            string Username = usernameEntry.Text;
            string Password = passwordEntry.Text;
            string Email = emailEntry.Text;
            string Address = AddressEntry.Text;
            string PhoneNumber = phoneNumberEntry.Text;
            string City = cityEntry.Text;
            string Region = regionEntry.Text;
            

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password) ||
        string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(PhoneNumber) ||
        string.IsNullOrWhiteSpace(City) || string.IsNullOrWhiteSpace(Region) || string.IsNullOrWhiteSpace(Address))
            {
                await DisplayAlert("Lỗi", "Vui lòng nhập đầy đủ tên đăng nhập, email và mật khẩu.", "OK");
                return;
            }

            // Tạo đối tượng chứa dữ liệu đăng ký
            var registerData = new
            {
                Username,
                Password,
                Email,
                Address,
                PhoneNumber,
                City,
                Region
            };

            var httpClient = new HttpClient(new CustomHttpClientHandler());
            try
            {
                string apiUrl = "https://192.168.1.6:5000/api/User/register"; // API đăng ký

                string json = JsonSerializer.Serialize(registerData);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Gửi yêu cầu POST
                var response = await httpClient.PostAsync(apiUrl, content);
                if(response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.Content);
                }
                else
                {
                    Console.WriteLine("Failed");
                }
                // In ra mã trạng thái và nội dung phản hồi
                Debug.WriteLine($"[API Request] URL: {apiUrl}");
                Debug.WriteLine($"[Request Body] {json}");
                Debug.WriteLine($"[Response Status Code] {response.StatusCode}");

                string responseContent = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"[Response Content] {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse>(responseBody);

                    Debug.WriteLine($"[API Response] {responseBody}");

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {



                        // Nếu đăng ký thành công, quay lại trang đăng nhập
                        await DisplayAlert("Thành công", "Đăng ký tài khoản thành công!", "OK");

                        // Quay lại trang đăng nhập
                        await Navigation.PopAsync(); // Quay lại trang đăng nhập
                    }
                    else
                    {
                        // Nếu API trả về lỗi
                        await DisplayAlert("Lỗi", apiResponse?.Message ?? "Đã xảy ra lỗi, vui lòng thử lại.", "OK");
                    }
                }
                else
                {
                    // In ra chi tiết lỗi HTTP nếu không phải 2xx status code
                    await DisplayAlert("Lỗi", $"Mã lỗi từ API: {response.StatusCode}. Vui lòng kiểm tra kết nối và thử lại.", "OK");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi kết nối hoặc lỗi hệ thống
                await DisplayAlert("Lỗi", $"Đã xảy ra lỗi: {ex.Message}", "OK");
                Debug.WriteLine($"[Exception] {ex.Message}");
            }
        }

        // Phương thức đăng nhập sau khi đăng ký thành công
        //private async Task LoginAfterRegistration(string username, string password)
        //{
        //    // Xoá bỏ phương thức này vì giờ không cần gọi đăng nhập tự động nữa
        //}
    }
}
