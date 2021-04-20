using System;
using System.Globalization;
using System.Collections.Generic;

public record myevents {
    public List<celeb> customevents;
    public int year {get; set;}
    public myevents(int year){
        this.year = year;
        customevents = new List<celeb>();
        fill();
    }

    void addCustomDay(int month, int day, string name){
        // custom entries
        customevents.Add(new celeb(new DateTime(year, month, day), name));
    }

    void fill(){
        addCustomDay(6, 21, "Sommeranfang");
        addCustomDay(2, 14, "Valentine");
        //... add yours.
    }
}