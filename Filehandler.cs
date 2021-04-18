using System;
using System.IO;
using System.Text;

/** 
* This class produces quarterly calendar sheets of HTML format.
*/
public class FileOut {
    string path;

    public FileOut(int quarter){
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
        string wd;
        DateTime dt;
        for(i=0; i<calx.NumDays(month); i++){
            // string casting `""+` :o)
                dt = calx.GetDate(month, i+1);
                wd ="";
                switch(calx.GetWeekDay(dt)){
                  case "So":
                    AddText(target, "\r\n"+String.Format(HTML.SundayFormat, i+1,
                    calx.GetWeekDay(month, i+1), wd));
                    break;
                  case "Sa":
                    AddText(target, "\r\n"+String.Format(HTML.SaturdayFormat, i+1,
                    calx.GetWeekDay(month, i+1), wd));
                    break;
                  case "Mo":
                    wd = ""+calx.GetWeekNum(dt);
                    goto default;// no silent fall-through as c++
                  default:
                    AddText(target, "\r\n"+String.Format(HTML.LineFormat, i+1,
                    calx.GetWeekDay(month, i+1), wd));
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