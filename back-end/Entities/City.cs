using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class City
{

    public City(
        int id,
        string cityName,
        int countryID)
    { 
        ID = id;
        CityName = cityName;
        CountryID = countryID;
    } 
    public int ID { get; set; }
    public string CityName { get; set; }
    public int CountryID { get; set; }
    
    public void SetID(int id)
    {
        ID = id;
    }
    public void SetCityName(string cityName)
    {
        CityName = cityName;
    }
    public void SetCountryID(int countryID)
    {
        CountryID = countryID;
    }
}