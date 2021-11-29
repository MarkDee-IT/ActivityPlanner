using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Initialise list
        List<Activity> allActivities = new List<Activity>()
        {
            new Activity("Hiking", new DateTime(2022, 02, 28), Activity.ActivityType.Land, 59.95m, "Walk up mountainous terrain"),
            new Activity("Spelunking", new DateTime(2022, 04, 21), Activity.ActivityType.Land, 239.95m, "Explore deep and dark caves"),
            new Activity("Cycling", new DateTime(2022, 05, 07), Activity.ActivityType.Land, 79.95m, "Take a relaxing bike ride across the countryside"),

            new Activity("Kayaking", new DateTime(2022, 01, 10), Activity.ActivityType.Water, 199.95m, "Pilot a small craft down winding rivers"),
            new Activity("Surfing", new DateTime(2022, 03, 06), Activity.ActivityType.Water, 159.95m, "Ride the waves of the ocean"),
            new Activity("Diving", new DateTime(2022, 06, 14), Activity.ActivityType.Water, 119.95m, "Explore the ocean floor"),

            new Activity("Skydiving", new DateTime(2022, 08, 13), Activity.ActivityType.Air, 299.95m, "Experience the world the only we know how, by jumping out of an operational aircraft"),
            new Activity("Paragliding", new DateTime(2022, 02, 17), Activity.ActivityType.Air, 149.95m, "Relax by floating in the air behind a boat"),
            new Activity("Wingsuit", new DateTime(2022, 06, 14), Activity.ActivityType.Air, 249.95m, "Soar through the air at high speeds and low altitudes")
    };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AllActivities_Loaded(object sender, RoutedEventArgs e)
        {
            
            allActivities.Sort();

            AllActivities.ItemsSource = allActivities;
        }

        private void AllActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Defines the current activity selected as an activity, and displays the description in the description box
            var activity = (Activity)AllActivities.SelectedItem;
            Description.Text = activity.Description;
        }
    }
}
