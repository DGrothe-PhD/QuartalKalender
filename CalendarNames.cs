using System;
using System.Globalization;
using System.Collections.Generic;

public class monthnaming{

    static string lang = "de-DE";

    public static string Language {get => lang; set => lang = value;}

    private static Dictionary<string, string[]> monthnames = new Dictionary<string, string[]>(){
        { "de-DE", new string[] {
        "Januar", "Februar", "März", "April", "Mai", "Juni", 
        "Juli", "August", "September", "Oktober", "November", "Dezember"}},
        { "fr-FR", new string[] {
        "Janvier", "Février", "Mars", "Avril", "Mai", "Juin", 
        "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre"}},
        { "en-GB", new string[] {
        "January", "February", "March", "April", "May", "June", 
        "July", "August", "September", "October", "November", "December"}}
    };
    
    public static string Months(int number){
        try{
            return monthnames[lang][number];
        }
        catch(Exception e) {
            Console.WriteLine(e.ToString());
            Console.WriteLine("Language key "+lang+"is not available. German is used as default.");
            
            string keys ="";
            foreach(var element in monthnames){
                keys+= " "+element.Key;
            }
            Console.WriteLine("Try some of {0}.",keys);

            lang="de-DE";
            return monthnames[lang][number];
        }
    }

    public static string MonthsGlobal(int number){
        var name = String.Empty;
        foreach (var lang in monthnames.Keys){
            name += " " + monthnames[lang][number];
        }
        return name;
    }
}

public class calendarnames {
    // language-specific

    public static Dictionary<string, string> holidaynames;
        
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