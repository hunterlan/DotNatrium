namespace DotNatrium.Models;

public class CompoundChemicalReaction
{
    public int Id {get; set;}

    public int CompoundId {get; set;}
    
    public Compound Compound {get; set;}

    public int ChemicalReactionId {get; set;}

    public ChemicalReaction ChemicalReaction {get; set;}

    public int Count {get; set;}

    public int TypeMeasurementId {get; set;}

    public TypeMeasurement TypeMeasurement {get; set; }

    public int RoleReactionId {get; set;}

    public RoleReaction RoleReaction {get; set;}
}