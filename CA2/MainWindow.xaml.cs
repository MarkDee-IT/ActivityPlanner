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
        // Initialise list of chosen activites
        List<Activity> chosenActivities = new List<Activity>();

        // Initialise list of all activities and add the activites
        List<Activity> allActivities = new List<Activity>()
        {
            new Activity("Hiking", new DateTime(2022, 02, 28), Activity.ActivityType.Land , 59.95m, "Walk up mountainous terrain"),
            new Activity("Spelunking", new DateTime(2022, 04, 21), Activity.ActivityType.Land, 239.95m, "Explore deep and dark caves"),
            new Activity("Cycling", new DateTime(2022, 05, 07), Activity.ActivityType.Land, 79.95m, "Take a relaxing bike ride across the countryside"),

            new Activity("Kayaking", new DateTime(2022, 01, 10), Activity.ActivityType.Water, 199.95m, "Pilot a small craft down winding rivers"),
            new Activity("Surfing", new DateTime(2022, 03, 06), Activity.ActivityType.Water, 159.95m, "Ride the waves of the ocean"),
            new Activity("Diving", new DateTime(2022, 06, 14), Activity.ActivityType.Water, 119.95m, "Explore the ocean floor"),

            new Activity("Skydiving", new DateTime(2022, 08, 13), Activity.ActivityType.Air, 299.95m, "Experience the world the only we know how, by jumping out of an operational aircraft"),
            new Activity("Paragliding", new DateTime(2022, 02, 17), Activity.ActivityType.Air, 149.95m, "Relax by floating in the air behind a boat"),
            new Activity("Wingsuit", new DateTime(2022, 06, 14), Activity.ActivityType.Air, 249.95m, "Soar through the air at high speeds and low altitudes")
        };

        // Sub lists for each category
        List<Activity> landActivities = new List<Activity>();
        List<Activity> waterActivities = new List<Activity>();
        List<Activity> airActivities = new List<Activity>();

        // Maybe not perfect practice, but holding totalCost here to easily add and remove from
        decimal totalCost = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        // All Activities on load
        private void AllActivities_Loaded(object sender, RoutedEventArgs e)
        {
            allActivities.Sort();

            AllActivities.ItemsSource = allActivities;

            // Sneaking in filling up the sublists here
            foreach (Activity activity in allActivities)
            {
                if (activity.TypeOfActivity == Activity.ActivityType.Land)
                {
                    landActivities.Add(activity);
                }

                if (activity.TypeOfActivity == Activity.ActivityType.Water)
                {
                    waterActivities.Add(activity);
                }

                if (activity.TypeOfActivity == Activity.ActivityType.Air)
                {
                    airActivities.Add(activity);
                }
            }
        }

        // Chosen Activities on load
        private void SelectedActivities_Loaded(object sender, RoutedEventArgs e)
        {
            SelectedActivities.ItemsSource = chosenActivities;
        }

        private void AllActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllActivities.SelectedItem != null)
            {
                // Defines the current activity selected as an activity, and displays the description in the description box
                var activity = (Activity)AllActivities.SelectedItem;
                Description.Text = activity.Description;
            }

            if (AllActivities.SelectedItem == null)
                Description.Text = "";
        }

        private void AddToActivities_Click(object sender, RoutedEventArgs e)
        {
            // Make sure it's not null
            if (AllActivities.SelectedItem != null)
            {
                // Set the chosen item as an Activity object
                var selectedActivity = (Activity)AllActivities.SelectedItem;

                // Check for date conflict
                bool isConflict = DateCheck(selectedActivity, chosenActivities);

                if (isConflict == false)
                {
                    // Add and remove from appropriate lists
                    allActivities.Remove(selectedActivity);
                    chosenActivities.Add(selectedActivity);

                    // Add cost to total cost
                    totalCost += selectedActivity.Cost;
                    TotalCost.Text = totalCost.ToString();
                }

                
            }

            // Essentially an exception handling thing, but all it really does is not run the above code and shows a message
            if (AllActivities.SelectedItem == null)
                MessageBox.Show("No item selected...");

            // Refresh lists
            AllActivities.Items.Refresh();
            SelectedActivities.Items.Refresh();
        }

        // Essentially the above method, but reverse, and date checking would be a bug in this instance
        private void RemoveFromActivities_Click(object sender, RoutedEventArgs e)
        {
            // Make sure it's not null
            if (SelectedActivities.SelectedItem != null)
            {
                // Set the chosen item as an Activity object
                var selectedActivity = (Activity)SelectedActivities.SelectedItem;

                // Add and remove from appropriate lists
                allActivities.Add(selectedActivity);
                chosenActivities.Remove(selectedActivity);

                // Remove cost from total cost
                totalCost -= selectedActivity.Cost;
                TotalCost.Text = totalCost.ToString();


            }

            // Essentially an exception handling thing, but all it really does is not run the above code and shows a message
            if (SelectedActivities.SelectedItem == null)
                MessageBox.Show("No item selected...");

            // Refresh lists
            AllActivities.Items.Refresh();
            SelectedActivities.Items.Refresh();
        }

        // Simply checks for date conflicts. I'm making a decision to not allow them, as all these activities are full day experiences
        private static bool DateCheck(Activity selectedActivity, List<Activity> activityList)
        {
            bool result = false;

            foreach (Activity activity in activityList)
            {
                if (activity.ActivityDate == selectedActivity.ActivityDate)
                {
                    MessageBox.Show($"Date conflict found! {activity.Name} and {selectedActivity.Name}");
                    result = true;
                }
            }

            return result;
        }

        // All these are filtering options, which just changes the list displayed. I likely could have done some sort of list of lists, but wrapping my head around that
        // every time seemed to be overengineering the problem, this spells out what's being done very clearly, I think
        private void RadAll_Checked(object sender, RoutedEventArgs e)
        {
            AllActivities.ItemsSource = allActivities;
            AllActivities.Items.Refresh();
        }

        private void RadLand_Checked(object sender, RoutedEventArgs e)
        {
            AllActivities.ItemsSource = landActivities;
            AllActivities.Items.Refresh();
        }

        private void RadWater_Checked(object sender, RoutedEventArgs e)
        {
            AllActivities.ItemsSource = waterActivities;
            AllActivities.Items.Refresh();
        }

        private void RadAir_Checked(object sender, RoutedEventArgs e)
        {
            AllActivities.ItemsSource = airActivities;
            AllActivities.Items.Refresh();
        }
    }
}
