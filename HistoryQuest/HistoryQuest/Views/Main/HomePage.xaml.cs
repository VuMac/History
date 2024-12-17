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

    private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null) return;

        var selectedItem = e.SelectedItem.ToString();
        Page targetPage = null;

        // Điều hướng đến các trang dựa trên mục được chọn
        if (selectedItem == "Home")
        {
            targetPage = new HomePage(); // Trang chính của Home
        }
        else if (selectedItem == "Thông Tin")
        {
            targetPage = new UserInfo(); // Trang thông tin người dùng
        }
        else if (selectedItem == "Bài học")
        {
            targetPage = new LessonPage(); // Trang bài học
        }
        else if (selectedItem == "Bài thi")
        {
            targetPage = new ExamPage(); // Trang bài thi
        }
        else if (selectedItem == "Đăng xuất")
        {
            // Xử lý logic đăng xuất
            Application.Current.MainPage = new LoginPage();
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
