using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ItemStats : IEquatable<ItemStats>
{
    public string PartName { get; set; }

    public int PartId { get; set; }

    public override string ToString()
    {
        return "ID: " + PartId + "   Name: " + PartName;
    }
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        ItemStats objAsPart = obj as ItemStats;
        if (objAsPart == null) return false;
        else return Equals(objAsPart);
    }
    public override int GetHashCode()
    {
        return PartId;
    }
    public bool Equals(ItemStats other)
    {
        if (other == null) return false;
        return (this.PartId.Equals(other.PartId));
    }
}


