using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Car
{

    public Car(
        int id,
        int model,
        string manufacturer,
        int year,
        string color,
        string picturePath)
    { 
        ID = id;
        Model = model;
        Manufacturer = manufacturer;
        Year = year;
        Color = color;
        PicturePath = picturePath;
    } 
    public int ID { get; set; }
    public int Model { get; set; }
    public string Manufacturer { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public string PicturePath { get; set; }
    
    public void SetID(int id)
    {
        ID = id;
    }
    public void SetModel(int model)
    {
        Model = model;
    }
    public void SetManufacturer(string manufacturer)
    {
        Manufacturer = manufacturer;
    }
    public void SetYear(int year)
    {
        Year = year;
    }
    public void SetColor(string color)
    {
        Color = color;
    }
    public void SetPicturePath(string picturePath)
    {
        PicturePath = picturePath;
    }
}