namespace PXLAlertApp
{
    public enum Severity
    {
        Low,
        Medium,
        High
    }
    public class PXLAlertMessage
    {
        public int Id { get; private set; }
        public Severity Severity { get; private set; }
        public string Content { get; private set; }
        public DateTime Date { get; private set; }
        public PXLAlertMessage(int id, Severity severity, string content, DateTime date)
        {
            Id = id;
            Severity = severity;
            Content = content;
            Date = date;
        }
        public override string ToString()
        {
            return $"PXL Alert (Id: {Id}, Severity: {Severity}, Content: {Content}, Date: {Date})";
        }
    }

}
