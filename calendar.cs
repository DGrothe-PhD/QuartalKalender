using System;
using System.Globalization;
using System.Collections.Generic;

public class calx : calendarnames{
    public int year;
    int currHoliday, currCE, currLocHol, currevents;
    public List<celeb> holidays, events, customevents, localholidays;
    public myevents cuev; //imports seperately stored user events
    DateTime easter;

    void addvarceleb(int j, string name, bool isHoliday=true){
        // coupled to Easter
        if(isHoliday) holidays.Add(new celeb(easter.AddDays(j), calendarnames.getName(name)));
        else events.Add(new celeb(easter.AddDays(j), calendarnames.getName(name)));
    }
    void addceleb(int month, int day, string name, bool isHoliday=true){
        // independent of Easter
        if(isHoliday) holidays.Add(
            new celeb(new DateTime(year, month, day), calendarnames.getName(name))
        );
        else events.Add(
            new celeb(new DateTime(year, month, day), calendarnames.getName(name))
        );
    }

    void addceleb(DateTime when, string name, bool isHoliday=true){
        // independent of Easter
        if(isHoliday) holidays.Add(new celeb(when, calendarnames.getName(name)));
        else events.Add(new celeb(when, calendarnames.getName(name)));
    }

    void addlocalceleb(int month, int day, string name){
        try{
        localholidays.Add(
            new celeb(new DateTime(year, month, day), calendarnames.getName(name))
        );
        }
        catch(KeyNotFoundException){Console.WriteLine("Failed to add local event: "+name);}
    }
    void addlocalceleb(DateTime when, string name){
        localholidays.Add(new celeb(when, calendarnames.getName(name)));
    }

    
    public calx(int year) : base() {
        this.year = year;
        easter = EasterSunday(year);
        // initialize all event lists
        holidays = new List<celeb>();
        events = new List<celeb>();
        customevents = new List<celeb>();
        localholidays = new List<celeb>();
        // now add items
        addceleb(1, 1, "New Year");
        addlocalceleb(1, 6, "Epiphany");
        addvarceleb(-48,"Rose Monday", false);
        addlocalceleb(3, 8, "IWD");
        addceleb(NextSunday(year, 3, 25), "Start of CEST");
        addvarceleb(-2,"Good Friday");
        addvarceleb(0, "Easter Sunday");
        addvarceleb(1, "Easter Monday");
        addceleb(5, 1, "May Day");
        addceleb(NextSunday(year, 5, 8), "Mother's Day");
        addvarceleb(39, "Ascension");
        addvarceleb(49, "Whit Sunday");
        addvarceleb(50, "Whit Monday");
        addvarceleb(60, "Corpus Christi");
        addceleb(8, 15, "Assumption", false);
        addceleb(10, 3, "German Unity Day");
        addceleb(10, 31, "Reformation Day", false);
        addceleb(NextSunday(year, 10, 25), "End of CEST");
        addlocalceleb(11, 1, "All Saints");
        addceleb(NextSunday(year, 11, 13), "Memorial Day");
        addceleb(NextSunday(year, 11, 13).AddDays(3), "Penance Day", false);
        addceleb(NextSunday(year, 11, 20), "Sunday of the Dead");
        for(int i=0; i<4; i++){
            addceleb(NextSunday(year, 11, 27).AddDays(7*i), (i+1)+". Advent");
        }
        addceleb(12, 24, "Christmas Eve", false);
        addceleb(12, 25, "Christmas Day");
        addceleb(12, 26, "Boxing Day");
        addceleb(12, 31, "New Year's Eve");

        cuev = new myevents(year);
        customevents = cuev.customevents;
        // Sort nutzt IComparable Implementierung der Klassenobjekte
        holidays.Sort();
        localholidays.Sort();
        events.Sort();
        customevents.Sort();
        currHoliday = 0; currCE = 0; currLocHol = 0; currevents = 0;
    }

    public answer getDayInfo(DateTime date){
        /* accumulates day event strings for that particular day.
        * int status: prioritize public > local holidays > other events.
        */
        answer aw = new answer();
        string buf;
        aw.status = 0;
        aw.text = "";
        
        if(currHoliday<holidays.Count && holidays[currHoliday].Equals(date)){
            // Public Holiday
            aw.status = 2;
            aw.text += holidays[currHoliday].what;
            currHoliday++;
        }
        if(currLocHol<localholidays.Count && localholidays[currLocHol].Equals(date)){
            // Local holiday
            if(aw.status==0) aw.status = 1;
            buf = aw.text.Length>0?", ":"";
            aw.text += buf + localholidays[currLocHol].what;
            currLocHol++;
        }
        if(currevents<events.Count && events[currevents].Equals(date)){
            // other events
            buf = aw.text.Length>0?", ":"";
            aw.text += buf + events[currevents].what;
            currevents++;
        }
        if(currCE <customevents.Count && customevents[currCE].Equals(date)){
            buf = aw.text.Length>0?", ":"";
            aw.text += buf + customevents[currCE].what;
            currCE++;
        }
        return aw;
    }

    public int GetWeekNum(DateTime date) => ISOWeek.GetWeekOfYear(date);
    
    public DateTime GetDate(int month, int day) => new DateTime(year, month, day);

    public string GetWeekDay(DateTime dt) => dt.ToString("ddd", german);

    public string GetWeekDay(int month, int day) =>
        new DateTime(year,month, day).ToString("ddd", german);

    public int NumDays(int month){
        int j;
        switch(month){
            case 4:
            case 6:
            case 9:
            case 11:
                j = 30;
                break;
            case 2:
                j = DateTime.IsLeapYear(year)?29:28;
                break;
            default:
                j= 31;
                break;
        }
        return j;
    }

    static DateTime NextSunday(int year, int month, int day){
        // parameter: first possible sunday
        // for 'next Wednesday': [param first possible Wednesday -3].AddDays(3)
        DateTime md = new DateTime(year, month, day);
        int i;
        for(i=0; i<7; i++){
            if(md.AddDays(i).DayOfWeek == DayOfWeek.Sunday) break;
        }
        return md.AddDays(i);
    }
    static DateTime EasterSunday(int year){
        // Source: https://stackoverflow.com/a/2510411
        int day = 0, month = 0;

        int g = year % 19;
        int c = year / 100;
        int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
        int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

        day   = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
        month = 3;

        if (day > 31){
            month++;
            day -= 31;
        }

        return new DateTime(year, month, day);
    }
}

public class celeb : IComparable<celeb>, IEquatable<DateTime> {
    public celeb(DateTime _when, string _what){
        when=_when;
        what=_what;
    }

    public int CompareTo(celeb other){
        if (other == null) return 1;
        return this.when.CompareTo(other.when);
    }

    public bool Equals(DateTime somedate) => this.when == somedate;
    public DateTime when {get; set;}
    public string what {get; set;}
}

public class answer{//holiday-entry return type
        public int status;
        public string text;
}