namespace HistoryQuest.Views.Main;

public partial class HomePage : FlyoutPage
{
    public HomePage()
    {
        InitializeComponent();

        // Đặt trang Home mặc định
        //Detail = new NavigationPage(new HomePage());

        MenuItemsList.ItemSelected += OnMenuItemSelected;
    }

    private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null) return;

        var selectedItem = e.SelectedItem.ToString();
        Page targetPage = null;

        // Điều hướng đến các trang dựa trên mục được chọn
        if (selectedItem == "Trang Chủ")
        {
            targetPage = new HomePage(); // Trang chính của Home
        }
        else if (selectedItem == "Thông Tin")
        {
            targetPage = new UserInfo(); // Trang thông tin người dùng
        }
        else if (selectedItem == "Lớp Học")
        {
            targetPage = new Views.ClassPage.ClassPage(); // Trang lớp học
        }
        else if (selectedItem == "Đăng xuất")
        {
            bool confirmLogout = await DisplayAlert("Đăng xuất", "Bạn có chắc chắn muốn đăng xuất không?", "Có", "Không");
            if (confirmLogout)
            {
                // Xử lý logic đăng xuất
                SecureStorage.Remove("AuthToken"); // Xóa thông tin đăng nhập (ví dụ)
                Application.Current.MainPage = new LoginPage(); // Điều hướng đến trang đăng nhập
            }

            // Đảm bảo đóng menu và bỏ chọn mục
            IsPresented = false;
            MenuItemsList.SelectedItem = null;
            return;
        }

        // Kiểm tra nếu trang cần điều hướng khác với trang hiện tại
        if (targetPage != null && !(Detail is NavigationPage navigationPage && navigationPage.CurrentPage.GetType() == targetPage.GetType()))
        {
            Detail = new NavigationPage(targetPage);
        }

        // Đóng menu
        IsPresented = false;

        // Bỏ chọn mục đã chọn
        MenuItemsList.SelectedItem = null;

    }
}
