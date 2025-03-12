namespace TCC_Backend.Domain.Models.Reports
{
    public class Report : BaseEntity
    {
        public Report()
        {
        }

        public Report(string reportType,
                      string errorCategory,
                      string suggestionCategory,
                      string description,
                      bool wantsContact,
                      string? contactEmail,
                      int rating)
        {
            ReportType = reportType;
            ErrorCategory = errorCategory;
            SuggestionCategory = suggestionCategory;
            Description = description;
            WantsContact = wantsContact;
            ContactEmail = contactEmail;
            Rating = rating;
        }

        public string ReportType { get; private set; } = string.Empty;

        public string? ErrorCategory { get; private set; } = string.Empty;
        
        public string? SuggestionCategory { get; private set; } = string.Empty;
        
        public string Description { get; private set; } = string.Empty;

        public bool WantsContact { get; private set; }

        public string? ContactEmail { get; private set; } = string.Empty;

        public int Rating { get; private set; }
    }
}
