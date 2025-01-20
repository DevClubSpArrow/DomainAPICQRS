namespace HindalcoBackend.Application.DataModels
{
    public class NotificationModel
    {
        #region Metadata

        public string? Sender { get; set; }
        public string? PrimaryHost { get; set; }

        #endregion Metadata

        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? IconUrl { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public string? Action { get; set; }
        public string? Route { get; set; }
    }
}