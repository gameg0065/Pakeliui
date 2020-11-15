using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Reservation
{

    public Reservation(
        int id,
        int passengerID,
        int travelID,
        bool isVerified,
        bool isCanceled,
        string reservationInfo,
        DateTime reservationDate,
        int passengerRating,
        int driverRating)
    { 
        ID = id;
        PassengerID = passengerID;
        TravelID = travelID;
        IsVerified = isVerified;
        IsCanceled = isCanceled;
        ReservationInfo = reservationInfo;
        ReservationDate = reservationDate;
        PassengerRating = passengerRating;
        DriverRating = driverRating;
    } 
    public int ID { get; set; }
    public int PassengerID { get; set; }
    public int TravelID { get; set; }
    public bool IsVerified { get; set; }
    public bool IsCanceled { get; set; }
    public string ReservationInfo { get; set; }
    public DateTime ReservationDate { get; set; }
    public int PassengerRating { get; set; }
    public int DriverRating { get; set; }
    
    public void SetID(int id)
    {
        ID = id;
    }
    public void SetPassengerID(int passengerID)
    {
        PassengerID = passengerID;
    }
    public void SetTravelID(int travelID)
    {
        TravelID = travelID;
    }
    public void SetIsVerified(bool isVerified)
    {
        IsVerified = isVerified;
    }
    public void SetIsCanceled(bool isCanceled)
    {
        IsCanceled = isCanceled;
    }
    public void SetReservationInfo(string reservationInfo)
    {
        ReservationInfo = reservationInfo;
    }
    public void SetReservationDate(DateTime reservationDate)
    {
        ReservationDate = reservationDate;
    }
    public void SetPassengerRating(int passengerRating)
    {
        PassengerRating = passengerRating;
    }
    public void SetDriverRating(int driverRating)
    {
        DriverRating = driverRating;
    }
}