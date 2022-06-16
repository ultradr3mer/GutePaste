namespace GutePaste.Models
{
  public class SessionModel
  {
    public DateTime Start { get; set; }
    public TimeSpan Interval { get; set; }
    public DateTime NextOccurence { get; set; }
  }
}
