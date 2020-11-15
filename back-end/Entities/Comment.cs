using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Comment
{

    public Comment(
        int id,
        int userID,
        int travelID,
        string content)
    { 
        ID = id;
        UserID = userID;
        TravelID = travelID;
        Content = content;
    } 
    public int ID { get; set; }
    public int UserID { get; set; }
    public int TravelID { get; set; }
    public string Content { get; set; }
    
    public void SetID(int id)
    {
        ID = id;
    }
    public void SetUserID(int userID)
    {
        UserID = userID;
    }
    public void SetTravelID(int travelID)
    {
        TravelID = travelID;
    }
    public void SetContent(string content)
    {
        Content = content;
    }
}