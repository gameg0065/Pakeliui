using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Preference
{

    public Preference(
        int id,
        string name,
        string iconPath)
    { 
        ID = id;
        Name = name;
        IconPath = iconPath;
    } 
    public int ID { get; set; }
    public string Name { get; set; }
    public string IconPath { get; set; }
    
    public void SetID(int id)
    {
        ID = id;
    }
    public void SetName(string name)
    {
        Name = name;
    }
    public void SetIconPath(string iconPath)
    {
        IconPath = iconPath;
    }
}