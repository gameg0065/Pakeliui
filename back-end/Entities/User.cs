using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{

    public User(
        int id,
        string firstName,
        string lastName,
        string email,
        string password,
        string phoneNumber,
        DateTime createDate,
        DateTime lastUpdate,
        int cityID,
        int carID,
        string userInfo,
        int rating,
        int preferences,
        string facebookLink,
        string picturePath)
    { 
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        CreateDate = createDate;
        LastUpdate = lastUpdate;
        CityID = cityID;
        CarID = carID;
        UserInfo = userInfo;
        Rating = rating;
        Preferences = preferences;
        FacebookLink = facebookLink;
        PicturePath = picturePath;
    } 
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdate { get; set; }
    public int CityID { get; set; }
    public int CarID { get; set; }
    public string UserInfo { get; set; }
    public int Rating { get; set; }
    public int Preferences { get; set; } // ??
    public string FacebookLink { get; set; }
    public string PicturePath { get; set; }

    public void SetID(int id)
    {
        ID = id;
    }
    public void SetFirstName(string firstName)
    {
        FirstName = firstName;
    }
    public void SetLastName(string lastName)
    {
        LastName = lastName;
    }
    public void SetEmail (string email)
    {
        Email = email;
    }
    public void SetPassword (string password)
    {
        Password = password;
    }
    public void SetPhoneNumber (string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }
    public void SetCreateDate (DateTime createDate)
    {
        CreateDate = createDate;
    }
    public void SetLastUpdate (DateTime lastUpdate)
    {
        LastUpdate = lastUpdate;
    }
    public void SetCityID(int cityID)
    {
        CityID = cityID;
    }
    public void SetCarID(int carID)
    {
        CarID = carID;
    }
    public void SetUserInfo(string userInfo)
    {
        UserInfo = userInfo;
    }
    public void SetRating(int rating)
    {
        Rating = rating;
    }
    public void SetPreferences(int preferences)
    {
        Preferences = preferences;
    }

    public void SetRatinFacebookLink(string facebookLink)
    {
        FacebookLink = facebookLink;
    }

    public void SetPicturePath(string picturePath)
    {
        PicturePath = picturePath;
    }


}