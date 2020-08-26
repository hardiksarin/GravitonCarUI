using GravitonCarLibrary;
using GravitonCarLibrary.Models;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GravitonCar
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : UserControl
    {
        IScreenRequester callingForm;
        List<UserModel> allUsers = new List<UserModel>();
        public AdminPanel(IScreenRequester caller)
        {
            InitializeComponent();
            callingForm = caller;
            LoadUserList();
            UserListBuilder();
        }

        private void LoadUserList()
        {
            allUsers = GlobalConfig.Connection.GetUser_All();
        }

        private void UserListBuilder()
        {
            foreach (UserModel u in allUsers)
            {
                CreateCard(u);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            callingForm.NewUser();
        }

        private void CreateCard(UserModel user)
        {
            Card card = new Card();
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = GridLength.Auto;
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = GridLength.Auto;
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = GridLength.Auto;
            RowDefinition gridRow4 = new RowDefinition();
            gridRow4.Height = GridLength.Auto;
            RowDefinition gridRow5 = new RowDefinition();
            gridRow5.Height = GridLength.Auto;

            card.HorizontalAlignment = HorizontalAlignment.Left;
            card.Margin = new Thickness(10, 10, 10, 10);
            card.Background = new SolidColorBrush(Color.FromRgb(3, 169, 244));
            card.Foreground = Brushes.White;
            card.Width = 200;
            //card.Height = 200;
            Grid cardGrid = new Grid();
            card.Content = cardGrid;
            cardGrid.RowDefinitions.Add(gridRow1);
            cardGrid.RowDefinitions.Add(gridRow2);
            cardGrid.RowDefinitions.Add(gridRow3);
            cardGrid.RowDefinitions.Add(gridRow4);
            cardGrid.RowDefinitions.Add(gridRow5);

            Grid.SetColumn(card, 1);

            /*< Label Content = "Hardik Sarin" FontSize = "30" HorizontalAlignment = "Left" Foreground = "White" FontWeight = "UltraLight" >
         
            < Label Grid.Row = "1" Content = "CEO" FontSize = "20" HorizontalAlignment = "Left" VerticalAlignment = "Bottom" Foreground = "White" FontWeight = "UltraLight" >
            < Separator Grid.Row = "2"
                Style = "{StaticResource MaterialDesignLightSeparator}" />
             < TextBlock Grid.Row = "3" Text = "Today : 10" FontSize = "20" FontWeight = "UltraLight" HorizontalAlignment = "left" Margin = "10" ></ TextBlock >
             < materialDesign:PackIcon Grid.Row = "3" Kind = "Delete" HorizontalAlignment = "Right" VerticalAlignment = "Center" Height = "20" Width = "20" Margin = "10" Cursor = "Hand" Background = "Transparent" ></ materialDesign:PackIcon >
             < materialDesign:PackIcon Grid.Row = "3" Kind = "Lock" HorizontalAlignment = "Right" VerticalAlignment = "Center" Height = "20" Width = "20" Margin = "10,10,40,10" Cursor = "Hand" Background = "Transparent" ></ materialDesign:PackIcon >*/

            Label label1 = new Label();
            label1.Content = user.full_name;
            label1.FontSize = 30;
            label1.HorizontalAlignment = HorizontalAlignment.Left;
            label1.Foreground = Brushes.White;
            label1.FontWeight = FontWeights.UltraLight;
            cardGrid.Children.Add(label1);


            Label label2 = new Label();
            label2.Content = user.designation;
            label2.FontSize = 20;
            label2.FontWeight = FontWeights.UltraLight;
            label2.HorizontalAlignment = HorizontalAlignment.Left;
            label2.Foreground = Brushes.White;
            label2.VerticalAlignment = VerticalAlignment.Bottom;
            Grid.SetRow(label2, 1);
            cardGrid.Children.Add(label2);

            Separator separator = new Separator();
            separator.Style = (Style)Application.Current.Resources["MaterialDesignLightSeparator"];
            Grid.SetRow(separator, 2);
            cardGrid.Children.Add(separator);

            TextBlock textBlock1 = new TextBlock();
            textBlock1.Text = "Today : 10";
            textBlock1.FontSize = 20;
            textBlock1.FontWeight = FontWeights.UltraLight;
            textBlock1.HorizontalAlignment = HorizontalAlignment.Left;
            textBlock1.Margin = new Thickness(10, 10, 10, 10);
            Grid.SetRow(textBlock1, 3);
            cardGrid.Children.Add(textBlock1);

            PackIcon deleteIcon = new PackIcon();
            string name = user.full_name.Split(' ').First();
            deleteIcon.Name = $"{name}_{user.designation}_delete";
            deleteIcon.Kind = PackIconKind.Delete;
            deleteIcon.HorizontalAlignment = HorizontalAlignment.Right;
            deleteIcon.VerticalAlignment = VerticalAlignment.Center;
            deleteIcon.Height = 20;
            deleteIcon.Width = 20;
            deleteIcon.Margin = new Thickness(10, 10, 5, 10);
            deleteIcon.Cursor = Cursors.Hand;
            deleteIcon.Background = Brushes.Transparent;
            deleteIcon.MouseDown += new MouseButtonEventHandler(deleteIconOnClick);
            Grid.SetRow(deleteIcon, 3);
            cardGrid.Children.Add(deleteIcon);

            PackIcon lockIcon = new PackIcon();
            lockIcon.Name = $"{name}_{user.designation}_lock";
            lockIcon.Kind = PackIconKind.Lock;
            lockIcon.HorizontalAlignment = HorizontalAlignment.Right;
            lockIcon.VerticalAlignment = VerticalAlignment.Center;
            lockIcon.Height = 20;
            lockIcon.Width = 20;
            lockIcon.Margin = new Thickness(10, 10, 40, 10);
            lockIcon.Cursor = Cursors.Hand;
            lockIcon.Background = Brushes.Transparent;
            lockIcon.MouseDown += new MouseButtonEventHandler(lockIconOnClick);
            Grid.SetRow(lockIcon, 3);
            cardGrid.Children.Add(lockIcon);

            CardsWrapper.Children.Add(card);
        }

        void deleteIconOnClick(object sender, MouseButtonEventArgs e)
        {
            PackIcon icon = (PackIcon)sender;
            string iconName = icon.Name.Split('_').First();
            UserModel thisUser = new UserModel();
            foreach (UserModel user in allUsers)
            {
                string name = user.full_name.Split(' ').First();
                if (name.Equals(iconName))
                {
                    thisUser = user;
                }
            }
            //Delete thisUser
            if (MessageBox.Show($"Do you want to delete {thisUser.full_name} as user", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                GlobalConfig.Connection.DeleteUser(thisUser);
                LoadUserList();
                UserListBuilder();
            }
        }

        void lockIconOnClick(object sender, MouseButtonEventArgs e)
        {
            PackIcon icon = (PackIcon)sender;
            string iconName = icon.Name.Split('_').First();
            UserModel thisUser = new UserModel();
            foreach (UserModel user in allUsers)
            {
                string name = user.full_name.Split(' ').First();
                if (name.Equals(iconName))
                {
                    thisUser = user;
                }
            }
            
        }
    }
}
