using System;
using System.Globalization;
using System.Collections.Generic;

public class monthnaming{
    public static string[] Months = new string[] {
        "Januar", "Februar", "März", "April", "Mai", "Juni", 
        "Juli", "August", "September", "Oktober", "November", "Dezember"
    };
}
public class calendarnames {
    // language-specific
    /*public static string[] Months = new string[] {
        "Januar", "Februar", "März", "April", "Mai", "Juni", 
        "Juli", "August", "September", "Oktober", "November", "Dezember"
    };*/
    public static Dictionary<string, string> holidaynames;
    //kein "= new" hier, Konstruktor muss leere Liste generieren.
        
    public calendarnames(){
        try{
        holidaynames = new Dictionary<string, string>();
        //
        holidaynames.Add("New Year", "Neujahr");
        holidaynames.Add("Epiphany", "Heilige drei Könige");
        holidaynames.Add("Rose Monday", "Rosenmontag");
        holidaynames.Add("IWD", "Weltfrauentag");
        holidaynames.Add("Beginn der Sommerzeit", "Beginn der Sommerzeit");
        holidaynames.Add("Good Friday", "Karfreitag");
        holidaynames.Add("Easter Sunday", "Ostersonntag");
        holidaynames.Add("Easter Monday", "Ostermontag");
        // May
        holidaynames.Add("May Day", "Maifeiertag");
        holidaynames.Add("Muttertag", "Muttertag");
        holidaynames.Add("Ascension", "Christi Himmelfahrt");
        holidaynames.Add("Pfingstsonntag", "Pfingstsonntag");
        holidaynames.Add("Pfingstmontag", "Pfingstmontag");
        holidaynames.Add("Corpus Christi", "Fronleichnam");
        // August
        holidaynames.Add("Assumption", "Mariä Himmelfahrt");
        // October
        holidaynames.Add("Tag der dt. Einheit", "Tag der dt. Einheit");
        holidaynames.Add("Ende der Sommerzeit", "Ende der Sommerzeit");
        holidaynames.Add("Reformationstag", "Reformationstag");
        holidaynames.Add("All Saints", "Allerheiligen");
        holidaynames.Add("Memorial Day", "Volkstrauertag");
        holidaynames.Add("Penance Day", "Buß- und Bettag");
        holidaynames.Add("Totensonntag", "Totensonntag");
        // November and December
        for(int i=0;i<4;i++){
            holidaynames.Add((i+1)+". Advent", (i+1)+". Advent");
        }
        holidaynames.Add("Christmas Eve", "Heiligabend");
        holidaynames.Add("Christmas Day", "1. Weihnachtsfeiertag");
        holidaynames.Add("Boxing Day", "2. Weihnachtsfeiertag");
        holidaynames.Add("New Years Eve", "Silvester");
        }
        catch(ArgumentException){Console.WriteLine("Argument exception in ");}
    }
    public static CultureInfo german = new CultureInfo("de-DE");
}