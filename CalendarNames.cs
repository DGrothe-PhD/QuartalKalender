using System;
using System.Globalization;
using System.Collections.Generic;

public class calendarnames {
    // language-specific

    public static Dictionary<string, holidaylist> holidaynames 
        = new Dictionary<string, holidaylist>() {
        {"de", new holidaylist(new string[]{
            "Valentinstag", "Frühlingsanfang", "Sommeranfang",
            "Herbstanfang", "Winteranfang",
            "Neujahr", "Heilige drei Könige", "Rosenmontag", "Weltfrauentag",
            "Beginn der Sommerzeit", "Karfreitag", "Ostersonntag", "Ostermontag",
            "Maifeiertag", "Muttertag", "Christi Himmelfahrt", "Pfingstsonntag",
            "Pfingstmontag", "Fronleichnam", "Mariä Himmelfahrt", "Tag der dt. Einheit",
            "Ende der Sommerzeit", "Reformationstag", "Allerheiligen", 
            "Volkstrauertag", "Buß- und Bettag", "Totensonntag",
            "1. Advent", "2. Advent", "3. Advent", "4. Advent", 
            "Heiligabend", "1. Weihnachtsfeiertag", "2. Weihnachtsfeiertag",
            "Silvester"
        })},
        //nl
        {"fr", new holidaylist(new string[]{
            "La Saint-Valentin", "Début du printemps", "Début de l'été",
             "Début de l'automne", "Début d'hiver",
            "Le jour de l'an", "Fête des Rois", "Lundi gras", "Journée mondiale de la femme",
            "Passage à l'heure d'été", "Vendredi saint", "Dimanche de Pâques", "Lundi de Pâques",
            "Fête du travail", "Fête des mères", "Ascension", "Dimanche de Pentecôte",
            "Lundi de Pentecôte", "Fête-Dieu", "L'Assomption", "Jour de l'unité allemande",
            "Passage à l'heure d'hiver", "	Fête de la Réformation", "Toussaint", 
            "Jour de deuil national", "Jour de Pénitence et de Prières", "Fête des morts",
            "1. Avent", "2. Avent", "3. Avent", "4. Avent",
            "Le réveillon de Noël", "Fête de Noël", "Fête de Noël", "Le réveillon du nouvel an"

        })},
        {"en", new holidaylist(new string[]{
            "Valentine's Day", "Start of spring", "Start of summer",
            "Start of autumn", "Start of winter",
            "New Year", "Epiphany", "Rose Monday",
            "IWD", "Start of CEST", "Good Friday", "Easter Sunday", "Easter Monday", 
            "May Day", "Mother's Day", "Ascension", "Whit Sunday", "Whit Monday",
            "Corpus Christi", "Assumption", "German Unity Day", "End of CEST",
            "Reformation Day", "All Saints", "Memorial Day", "Penance Day",
            "Sunday of the Dead", "1. Advent", "2. Advent", "3. Advent", "4. Advent",
            "Christmas Eve", "Christmas Day", "Boxing Day", "New Year's Eve"
        })},
        //es
        //it
        //pt
        //pl
        {"uk", new holidaylist(new string[]{
            "Valentine's Day", "Start of spring", "Start of summer",
             "Start of autumn", "Start of winter",
            "Новий рік", "Три царі", "Rose Monday",
            "IWD", "Start of CEST", "Good Friday", "Easter Sunday", "Easter Monday", 
            "May Day", "Mother's Day", "Ascension", "Whit Sunday", "Whit Monday",
            "Corpus Christi", "Assumption", "German Unity Day", "End of CEST",
            "Reformation Day", "All Saints", "Memorial Day", "Penance Day",
            "Sunday of the Dead", "1. Advent", "2. Advent", "3. Advent", "4. Advent",
            "Christmas Eve", "Christmas Day", "Boxing Day", "New Year's Eve"
        })}
    };
    public static String language;
    

    public static string getName(string name){
        return holidaynames[language].getName(name);
    }

    public static CultureInfo german = new CultureInfo("de-DE");
}

public class holidaylist{
    String[] Names;
    //public String Language {get; set;}
    
    static String[] Keys = {
        "Valentine's Day", "Start of spring", "Start of summer",
        "Start of autumn", "Start of winter",
        "New Year", "Epiphany", "Rose Monday",
        "IWD", "Start of CEST", "Good Friday", "Easter Sunday", "Easter Monday", 
        "May Day", "Mother's Day", "Ascension", "Whit Sunday", "Whit Monday",
        "Corpus Christi", "Assumption", "German Unity Day", "End of CEST",
        "Reformation Day", "All Saints", "Memorial Day", "Penance Day",
        "Sunday of the Dead", "1. Advent", "2. Advent", "3. Advent", "4. Advent",
        "Christmas Eve", "Christmas Day", "Boxing Day", "New Year's Eve"
    };

    public holidaylist(string[] items)
    {
        //Language = language;
        Names = items;
    }


    public string getName(string name){
        string result = "";
        try{
            
            int index = Array.IndexOf(Keys, name);
            return index>-1?Names[index]:"~~~ "+name+" ~~~";
        }
        catch(Exception){
            Console.WriteLine(String.Format("Translation of {0} wasn't found.", name));
        }
        return result;
    }
}