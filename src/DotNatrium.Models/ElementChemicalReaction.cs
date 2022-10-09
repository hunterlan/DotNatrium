namespace DotNatrium.Models;

public class ElementChemicalReaction
{
    public int Id {get; set;}

    public int ElementId {get; set;}

    public Element Element {get; set;}

    public int ChemicalReactionId {get; set;}

    public ChemicalReaction ChemicalReaction { get; set; }

    public int Count {get; set;}

    public int TypeMeasurementId {get; set;}

    public TypeMeasurement TypeMeasurement {get; set;}

    public int RoleReactionId {get; set;}

    public RoleReaction RoleReaction {get; set;}
}