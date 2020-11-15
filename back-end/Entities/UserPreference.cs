using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class UserPreference
{

    public UserPreference(
        int userID,
        int preferencesID)
    { 
        UserID = userID;
        PreferencesID = preferencesID;
    } 
    public int UserID { get; set; }
    public int PreferencesID { get; set; }
    
    public void SetUserID(int userID)
    {
        UserID = userID;
    }
    public void SetPreferencesID(int preferencesID)
    {
        PreferencesID = preferencesID;
    }
}