using HistoryQuest.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace HistoryQuest.Views;

public partial class MainPage : ContentPage
{
    public ObservableCollection<string> Classes { get; set; }

    public MainPage()
    {
        InitializeComponent();

        // Khởi tạo danh sách lớp học
        Classes = new ObservableCollection<string>();

        // Gán BindingContext
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var userID = Preferences.Get("userID", "");
        // Gọi API để tải danh sách lớp học
        await LoadClassesAsync(userID);
    }

    private async Task LoadClassesAsync(string userID)
    {
        if (!String.IsNullOrEmpty(userID))
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                // URL API
                string apiUrl = $"https://192.168.1.6:5000/api/ClassHistory/GetClassHistoryEnroll?idUser={userID}";

                // Gọi API
                using var httpClient = new HttpClient(clientHandler);
                var classList = await httpClient.GetFromJsonAsync<List<ClassHistoryResponse>>(apiUrl);

                // Kiểm tra và hiển thị dữ liệu
                if (classList != null)
                {
                    // Xóa dữ liệu cũ trước khi thêm mới
                    foreach (var classname in classList)
                    {
                        // Kiem tra neu ObserverColleciton khong chua name truoc day thi add vao
                        if (!Classes.Contains(classname.Name))
                        {
                            // Thêm tên lớp vào danh sách
                            Classes.Add(classname.Name);
                        }
                    }

                    // Gán danh sách lớp vào CollectionView (nếu cần)
                    ClassListView.ItemsSource = Classes;
                }

                Console.WriteLine("Done");
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu cần
                await DisplayAlert("Lỗi", $"Không thể tải danh sách lớp học: {ex.Message}", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", "Please log in first! You dumb pig!", "Failure");
        }
        
    }

    private async void OnAddClassClicked(object sender, EventArgs e)
    {
        // Xử lý sự kiện khi nhấn nút "+"
        await Navigation.PushAsync(new Views.ClassList.ClassList());
    }

    private void OnClassSelected(object sender, SelectionChangedEventArgs e)
    {
        // Kiểm tra lớp học được chọn
        var selectedClass = e.CurrentSelection.FirstOrDefault() as string;
        if (selectedClass != null)
        {
            // Đặt HomeFlyoutPage làm trang chính của ứng dụng
            Application.Current.MainPage = new Views.Main.HomePage();
        }
    }
}
