using System;

public class HTML{
    public static string Year(int y) => "<h1>"+y+"</h1>\r\n";
    public static string PreambleText(int quarter) => "<!DOCTYPE html>\r\n"+
        "<html><head><title>Monatskalender "+
        quarter+"</title><meta charset=\"UTF-8\"></meta>\r\n"+
        "<link href=\"KalenderStyle.css\" rel=\"stylesheet\">\r\n<font face=\"Lucida Sans Unicode\">";
    public static string StartRow = "<div class=\"row\">\r\n";
    public static string CloseRow = "</div>\r\n";
    public static string Finish = "<footer></footer></font></body></html>";
    public static string Column(int month) => "\r\n<div class=\"column\">" +
        "<table border=\"1\"><th colspan=\"2\" width=\"20%\">" +
        "&nbsp;</th><th width=\"80%\">"+ monthnaming.Months[month-1] + "</th>";
    public static string LineFormat = "\r\n<tr><td>{0}<td/>{1}<td/>{2}&nbsp;{3}</td></tr>";
    public static string SundayFormat = "\r\n<tr class=\"sun\"><td>{0}<td/>{1}<td/>{2}&nbsp;{3}</td></tr>";
    public static string SaturdayFormat = "\r\n<tr class=\"sat\"><td>{0}<td/>{1}<td/>{2}&nbsp;{3}</td></tr>";
    public static string EmptyLine(int shift) => "<tr><td rowspan=\""+shift +"\" colspan=\"3\">&nbsp;</td></tr>";
    public static string CloseColumn = "\r\n</table><p/></div>";

    public static string Month(int month) => "<p>"+ monthnaming.Months[month-1] +"</p>\r\n";
}