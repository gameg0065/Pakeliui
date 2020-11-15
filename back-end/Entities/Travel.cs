using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Travel
{

    public Travel(
        int id,
        int driverID,
        int carID,
        int fromCityID,
        int toCityID,
        DateTime travelDate,
        DateTime createDate,
        DateTime lastUpdate,
        bool isCanceled,
        bool twoPassengersBackseat,
        int price,
        string travelInfo,
        int maxPassengerNo)
    { 
        ID = id;
        DriverID = driverID;
        CarID = carID;
        From_CityID = fromCityID;
        To_CityID = toCityID;
        Travel_Date = travelDate;
        Create_Date = travelDate;
        Last_Update = lastUpdate;
        Is_Canceled = isCanceled;
        Two_Passengers_Backseat = twoPassengersBackseat;
        Price = price;
        Travel_Info = travelInfo;
        Max_Passenger_No = maxPassengerNo;
    } 

    public int ID { get; set; }
    public int DriverID { get; set; }
    public int CarID { get; set; }
    public int From_CityID { get; set; }
    public int To_CityID { get; set; }
    public DateTime Travel_Date { get; set; }
    public DateTime Create_Date { get; set; }
    public DateTime Last_Update { get; set; }
    public bool Is_Canceled { get; set; }
    public bool Two_Passengers_Backseat { get; set; }
    public int Price { get; set; }
    public string Travel_Info { get; set; }
    public int Max_Passenger_No { get; set; }

    public void SetID(int id)
    {
        ID = id;
    }
    public void SetDriverID(int driverID)
    {
        DriverID = driverID;
    }
    public void SetCarID(int carID)
    {
        CarID = carID;
    }
    public void SetFromCityID(int fromCityID)
    {
        From_CityID = fromCityID;
    }
    public void SetToCityID(int toCityID)
    {
        To_CityID = toCityID;
    }
    public void SetTravelDate(DateTime travelDate)
    {
        Travel_Date = travelDate;
    }
    public void SetCreateDate(DateTime createDate)
    {
        Create_Date = createDate;
    }
    public void SetLastUpdate(DateTime lastUpdate)
    {
        Last_Update = lastUpdate;
    }
    public void SetIsCanceled(bool isCanceled)
    {
        Is_Canceled = isCanceled;
    }
    public void SetTwoPassengersBackseat(bool twoPassengersBackseat)
    {
        Two_Passengers_Backseat = twoPassengersBackseat;
    }
    public void SetPrice(int price)
    {
        Price = price;
    }
    public void SetTravelInfo(string travelInfo)
    {
        Travel_Info = travelInfo;
    }
    public void SetMaxPassengerNo(int maxPassengerNo)
    {
        Max_Passenger_No = maxPassengerNo;
    }

}