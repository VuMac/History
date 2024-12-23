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

        // Gọi API để tải danh sách lớp học
        await LoadClassesAsync("randomshit");
    }

    private async Task LoadClassesAsync(string userId)
    {
        try
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // URL API
            string apiUrl = "https://192.168.1.6:5000/api/ClassHistory/GetClassHistoryEnroll?idUser=33F18F75-8056-4E5E-86EF-08DD203B9422";

            // Gọi API
            using var httpClient = new HttpClient(clientHandler);
            var classList = await httpClient.GetFromJsonAsync<List<ClassHistoryResponse>>(apiUrl);

            // Kiểm tra và hiển thị dữ liệu
            if (classList != null)
            {
                // Xóa dữ liệu cũ trước khi thêm mới
                Classes.Clear();

                foreach (var classname in classList)
                {
                    Classes.Add(classname.Name); // Thêm tên lớp vào danh sách
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
