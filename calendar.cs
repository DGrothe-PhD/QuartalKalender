using System;
using System.Globalization;
using System.Linq;

/*
[TODO]  implement leap year, week numbers, Feiertage
*/
public class calx{
    public static int theyear = 2021;
    public static string[] Months = new string[] {
        "Januar", "Februar", "März", "April", "Mai", "Juni", 
        "Juli", "August", "September", "Oktober", "November", "Dezember"
    };

    public static int GetWeekNum(DateTime date){
        return ISOWeek.GetWeekOfYear(date);
    }
    static CultureInfo german = new CultureInfo("de-DE");

    public static DateTime GetDate(int month, int day){
        return new DateTime(theyear,month, day);
    }

    public static string GetWeekDay(DateTime dt){
        //datetime object creation just once
        return dt.ToString("ddd", german);
    }

    public static string GetWeekDay(int month, int day){
        return new DateTime(theyear,month, day).ToString("ddd", german);
    }
    /*    
        dayName = DateTime.Now.ToString("dddd", german);
        now_hour = DateTime.Now.Hour;
    */
    public static int NumDays(int month){
        int j;
        switch(month){
            case 4:
            case 6:
            case 9:
            case 11:
                j = 30;
                break;
            case 2:
                j = 28;
                break;
            default:
                j= 31;
                break;
        }
        return j;
    }
}