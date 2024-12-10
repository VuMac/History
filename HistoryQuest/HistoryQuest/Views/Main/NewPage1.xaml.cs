namespace HistoryQuest.Views.Main;

public partial class NewPage1 : FlyoutPage
{
	public NewPage1()
	{
		InitializeComponent();

        MenuItemsList.ItemSelected += (sender, e) =>
        {
            if (e.SelectedItem.ToString() == "Home")
            {
              //  Detail = new NavigationPage(new HomePage());
            }
            else if (e.SelectedItem.ToString() == "Settings")
            {
               // Detail = new NavigationPage(new SettingsPage());
            }

            IsPresented = false; // ?óng menu sau khi ch?n
        };
    }
}