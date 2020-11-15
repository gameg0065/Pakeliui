using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Country
{

    public Country(
        int id,
        string countryName)
    { 
        ID = id;
        CountryName = countryName;
    } 
    public int ID { get; set; }
    public string CountryName { get; set; }
    
    public void SetID(int id)
    {
        ID = id;
    }
    public void SetCountryName(string countryName)
    {
        CountryName = countryName;
    }
}