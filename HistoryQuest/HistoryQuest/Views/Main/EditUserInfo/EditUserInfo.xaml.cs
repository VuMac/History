namespace HistoryQuest.Views.Main.EditUserInfo;

public partial class EditUserInfo : ContentPage
{
    public EditUserInfo()
    {
        InitializeComponent();

        // Hiển thị thanh NavigationBar với nút "Back"
       
    }

    private async void OnChangePhotoClicked(object sender, EventArgs e)
    {
        try
        {
            // Mở picker để chọn ảnh
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Chọn một ảnh đại diện"
            });

            if (result != null)
            {
                // Hiển thị ảnh đã chọn
                var stream = await result.OpenReadAsync();
                ProfileImage.Source = ImageSource.FromStream(() => stream);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Lỗi", $"Không thể chọn ảnh: {ex.Message}", "OK");
        }
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        // Hiển thị thông báo khi lưu thành công
        await DisplayAlert("Thông báo", "Thông tin đã được lưu!", "OK");

        // Quay lại trang trước
        await Navigation.PopAsync();
    }

    private void OnBackButtonClicked(object sender, EventArgs e)
    {
        // Quay lại trang trước
        Application.Current.MainPage = new Views.Main.HomePage(); // Thay bằng trang bạn muốn quay lại
    }
}