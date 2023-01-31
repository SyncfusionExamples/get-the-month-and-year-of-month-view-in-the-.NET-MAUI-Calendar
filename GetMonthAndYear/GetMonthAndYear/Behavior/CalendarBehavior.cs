using Syncfusion.Maui.Calendar;

namespace GetMonthAndYear
{
    public class CalendarBehavior : Behavior<ContentPage>
    {
        private SfCalendar calendar;
        private Label monthLabel, yearLabel;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.calendar = bindable.FindByName<SfCalendar>("calendar");
            this.calendar.ViewChanged += Calendar_ViewChanged;
            this.monthLabel = bindable.FindByName<Label>("monthLabel");
            this.monthLabel.Text = "Month: " + this.calendar.DisplayDate.ToString("MMMM");
            this.yearLabel = bindable.FindByName<Label>("yearLabel");
            this.yearLabel.Text = "Year: " + this.calendar.DisplayDate.ToString("yyyy");
        }

        private void Calendar_ViewChanged(object sender, CalendarViewChangedEventArgs e)
        {
            this.monthLabel.Text = "Month: " + this.calendar.DisplayDate.ToString("MMMM");
            this.yearLabel.Text = "Year: " + this.calendar.DisplayDate.ToString("yyyy");
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.calendar != null)
            {
                this.calendar.ViewChanged -= Calendar_ViewChanged;
            }

            this.calendar = null;
            this.monthLabel = this.yearLabel = null;
        }
    }
}
