using System.ComponentModel.DataAnnotations;

namespace GutePaste.Models
{
  public class StartModel : IValidatableObject
  {
    public string Interval { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if (string.IsNullOrEmpty(Interval))
      {
        yield return new ValidationResult(
            "Interval muss angegeben werden.",
            new[] { nameof(Interval) });
      }

      if (!TimeSpan.TryParse(Interval, out TimeSpan timeSpan))
      {
        yield return new ValidationResult(
            "Interval hat nicht das richtige Format.",
            new[] { nameof(Interval) });
      }

      if (timeSpan < new TimeSpan(0, 1, 0))
      {
        yield return new ValidationResult(
          "Interval muss mindestens eine Minute sein.",
          new[] { nameof(Interval) });
      }
    }
  }
}
