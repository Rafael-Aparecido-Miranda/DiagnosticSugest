public class Symptom
{
    public int Id { get;set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Severity severity { get; set; }
    public Duration duration { get; set; }
    public Frequency frequency { get; set; }
}

public enum Frequency
{
    Constant,
    Intermittent
}

public enum Duration
{
    ShortTerm,
    Chronic
}

public enum Severity
{
    Mild,
    Moderate,
    Severe
}