using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    class Activity : IComparable<Activity>
    {
        public enum ActivityType { Air, Water, Land }

        public string Name { get; set; }

        public DateTime ActivityDate { get; set; }

        public decimal Cost { get; set; }

        private string _description;

        // Description automatically appends the cost to the end
        public string Description
        {
            get { return _description + $" Cost - {Cost:C}"; }
            set { _description = value; }
        }

        // Private attribute for the sake of allowing the activity type enum to be in the constructor
        public ActivityType TypeOfActivity;

        // Parameter constructor
        public Activity(string name, DateTime date, ActivityType typeOfActivity, decimal cost, string description)
        {
            Name = name;
            ActivityDate = date;
            TypeOfActivity = typeOfActivity;
            Cost = cost;
            _description = description;
        }

        // Blank constructor
        public Activity() { }

        public int CompareTo(Activity that)
        {
            if (this.ActivityDate < that.ActivityDate) return -1;
            if (this.ActivityDate == that.ActivityDate) return 0;
            return 1;
        }

        public override string ToString()
        {
            return $"{Name} - {ActivityDate.ToShortDateString()}";
        }
    }
}
