namespace MauiAppNSRI;

public partial class SessionsPage : ContentPage
{
    public SessionsPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Event handler for the "Save Session" button click.
    /// Captures all input data and processes it (e.g., saving locally or preparing for API submission).
    /// </summary>
    private async void OnSaveSessionClicked(object sender, EventArgs e)
    {
        try
        {
            // Collect session details from input fields
            string date = DateEntry.Text;
            string time = TimeEntry.Text;
            string location = LocationEntry.Text;
            string numParticipants = ParticipantsEntry.Text;
            string sessionGoals = GoalsEditor.Text;
            string observations = ObservationsEditor.Text;

            // Check selected skills
            bool coveredFloating = FloatingCheckbox.IsChecked;
            bool coveredBreathing = BreathingCheckbox.IsChecked;
            bool coveredArmMovement = ArmMovementCheckbox.IsChecked;
            bool coveredLegMovement = LegMovementCheckbox.IsChecked;

            // Retrieve overall assessment from picker
            string assessment = AssessmentPicker.SelectedItem?.ToString();

            // Validate mandatory fields (e.g., date and time) before saving
            if (string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(time) || string.IsNullOrWhiteSpace(location))
            {
                await DisplayAlert("Missing Information", "Please ensure Date, Time, and Location are filled out.", "OK");
                return;
            }

            // Placeholder for actual save logic (local database, API call, etc.)
            bool isSaved = await SaveSessionAsync(date, time, location, numParticipants, sessionGoals, observations,
                                                   coveredFloating, coveredBreathing, coveredArmMovement, coveredLegMovement, assessment);

            if (isSaved)
            {
                // Notify user of success and clear fields if saved successfully
                await DisplayAlert("Success", "Session details saved successfully.", "OK");
                ClearFields();
            }
            else
            {
                await DisplayAlert("Error", "An error occurred while saving the session. Please try again.", "OK");
            }
        }
        catch (Exception ex)
        {
            // Handle unexpected errors and display message
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }

    /// <summary>
    /// Asynchronously saves session data.
    /// This placeholder method can be replaced with actual logic to save to a local database or API.
    /// </summary>
    private Task<bool> SaveSessionAsync(string date, string time, string location, string numParticipants, string sessionGoals,
                                        string observations, bool coveredFloating, bool coveredBreathing, bool coveredArmMovement,
                                        bool coveredLegMovement, string assessment)
    {
        // Placeholder: Here you would add code to save data, such as database integration or API calls
        // For now, we simulate successful save by returning true
        return Task.FromResult(true);
    }

    /// <summary>
    /// Clears all fields after a successful save to reset the form for a new entry.
    /// </summary>
    private void ClearFields()
    {
        DateEntry.Text = string.Empty;
        TimeEntry.Text = string.Empty;
        LocationEntry.Text = string.Empty;
        ParticipantsEntry.Text = string.Empty;
        GoalsEditor.Text = string.Empty;
        ObservationsEditor.Text = string.Empty;
        FloatingCheckbox.IsChecked = false;
        BreathingCheckbox.IsChecked = false;
        ArmMovementCheckbox.IsChecked = false;
        LegMovementCheckbox.IsChecked = false;
        AssessmentPicker.SelectedItem = null;
    }
}
