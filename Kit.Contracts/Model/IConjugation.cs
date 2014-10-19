namespace Kit.Contracts.Model
{
    public interface IConjugation
    {
        int ConjugationId { get; set; }
        int BeadID { get; set; }
        int ProbeID { get; set; }
    }
}