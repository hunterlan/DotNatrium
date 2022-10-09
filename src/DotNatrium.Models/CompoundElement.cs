﻿namespace DotNatrium.Models;

public class CompoundElement
{
    public int Id {get; set;}

    public int? ElementId {get; set;}

    public Element Element {get; set;}

    public int? CompoundId {get; set;}

    public Compound Compound {get; set;}
}