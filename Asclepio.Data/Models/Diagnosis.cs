public class Diagnosis
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }










    5 5
    public String CIDCode { get; set; }
    public string Treatment { get; set; }
    public Prognosis prognosis { get; set; }
}

public enum Prognosis
{
    Favorable,
    Guarded,
    Poor
}