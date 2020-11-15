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
        FromCityID = fromCityID;
        ToCityID = toCityID;
        TravelDate = travelDate;
        CreateDate = travelDate;
        LastUpdate = lastUpdate;
        IsCanceled = isCanceled;
        TwoPassengersBackseat = twoPassengersBackseat;
        Price = price;
        TravelInfo = travelInfo;
        MaxPassengerNo = maxPassengerNo;
    } 

    public int ID { get; set; }
    public int DriverID { get; set; }
    public int CarID { get; set; }
    public int FromCityID { get; set; }
    public int ToCityID { get; set; }
    public DateTime TravelDate { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool IsCanceled { get; set; }
    public bool TwoPassengersBackseat { get; set; }
    public int Price { get; set; }
    public string TravelInfo { get; set; }
    public int MaxPassengerNo { get; set; }

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
        FromCityID = fromCityID;
    }
    public void SetToCityID(int toCityID)
    {
        ToCityID = toCityID;
    }
    public void SetTravelDate(DateTime travelDate)
    {
        TravelDate = travelDate;
    }
    public void SetCreateDate(DateTime createDate)
    {
        CreateDate = createDate;
    }
    public void SetLastUpdate(DateTime lastUpdate)
    {
        LastUpdate = lastUpdate;
    }
    public void SetIsCanceled(bool isCanceled)
    {
        IsCanceled = isCanceled;
    }
    public void SetTwoPassengersBackseat(bool twoPassengersBackseat)
    {
        TwoPassengersBackseat = twoPassengersBackseat;
    }
    public void SetPrice(int price)
    {
        Price = price;
    }
    public void SetTravelInfo(string travelInfo)
    {
        TravelInfo = travelInfo;
    }
    public void SetMaxPassengerNo(int maxPassengerNo)
    {
        MaxPassengerNo = maxPassengerNo;
    }

}