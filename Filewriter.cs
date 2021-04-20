using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

/** 
* This class produces quarterly calendar sheets of HTML format.
*/
public class TheYear{
    public int year {get; set;}
    public TheYear(int year) { 
        this.year = year;
        FileOut f1 = new FileOut(year);
    }

    public TheYear(int year, int quarter) { 
        this.year = year;
        FileOut f1 = new FileOut(year, quarter);
    }
}


public class FileOut {
    string path;
    public static calx year1; //= new calx(2021);

    public FileOut(int year) {
        year1 = new calx(year);
        for(int i=0;i<4;i++) Qile(i+1);
    }

    public FileOut(int year, int quarter) {
        year1 = new calx(year);
        path = @"results/Kalender_"+quarter+".html";
        HTMLPreamble(quarter);
        WriteinFile(quarter);
    }

    private void Qile(int quarter){
        path = @"results/Kalender_"+quarter+".html";
        HTMLPreamble(quarter);
        WriteinFile(quarter);
    }
    
    public void HTMLPreamble(int quarter){
        using (FileStream fs = File.Create(path)){
        AddText(fs, HTML.PreambleText(quarter));
        }
    }

    void AddMonth(FileStream target, int month){
        AddText(target, HTML.Column(month));
        int i;
        string daytext, week;
        //as year1.answer this was inaccessible as inner class
        answer item;
        DateTime dt;
        //
        for(i=0; i< year1.NumDays(month); i++){
            // year1 is instance of calx class.
            dt = year1.GetDate(month, i+1);
            item = year1.getDayInfo(dt);
            string st = year1.GetWeekDay(dt);
            daytext = ""; week = "";
            if(st == "Mo") week = ""+year1.GetWeekNum(dt);
            daytext += item.text;
            if(item.status == 2) st = "holiday";
            else if(item.status == 1) st = "event";

            switch(st){
                case "holiday":
                case "So":
                    AddText(target, String.Format(HTML.SundayFormat, i+1,
                    year1.GetWeekDay(month, i+1), week, daytext));
                    break;
                case "event":
                case "Sa":
                    AddText(target, String.Format(HTML.SaturdayFormat, i+1,
                    year1.GetWeekDay(month, i+1), week, daytext));
                    break;
                default:
                    AddText(target, String.Format(HTML.LineFormat, i+1,
                    year1.GetWeekDay(month, i+1), week, daytext));
                    break;
            }
        }
        if(i<31) AddText(target, HTML.EmptyLine(31-i));
        AddText(target, HTML.CloseColumn);
    }

    void AddMonth(FileStream target, int a, int b){
        for(int m=a; m<b+1; m++){ AddMonth(target, m);}
    }

    public void WriteinFile(int quarter){
        //Append to the file.
        using (FileStream fs = new FileStream(path, FileMode.Append)){
            AddText(fs, HTML.Year(2021));
            AddText(fs, HTML.StartRow);
            AddMonth(fs, 1+3*(quarter-1), 3+3*(quarter-1));
            AddText(fs, HTML.CloseRow + HTML.Finish);
        }

    }

    private static void AddText(FileStream fs, string value)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(value);
        fs.Write(info, 0, info.Length);
    }
}