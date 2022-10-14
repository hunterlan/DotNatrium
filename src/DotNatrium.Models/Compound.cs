namespace DotNatrium.Models;

public class Compound
{

    public int DataId {get; set;}
    
    public virtual Data Data { get; set;} = null!;
}