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
        {"nl", new string[] {
        "januari", "februari", "maart", "april", "mei", "juni",
        "juli", "augustus", "september", "oktober", "november", "december"
        }},
        { "fr", new string[] {
        "Janvier", "Février", "Mars", "Avril", "Mai", "Juin", 
        "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre"}},
        { "en", new string[] {
        "January", "February", "March", "April", "May", "June", 
        "July", "August", "September", "October", "November", "December"}},
        { "es", new string[] {
        "Enero ", "Febrero ", "Marzo ", "Abril ", "Mayo ", "Junio ",
        "Julio ", "Agosto ", "Septiembre ", "Octubre ", "Noviembre ", "Diciembre "}},
        { "it", new string[] {
        "gennaio", "febbraio", "marzo", "aprile", "maggio", "giugno",
        "luglio", "agosto", "settembre", "ottobre", "novembre", "dicembre"}},
        {"pt", new string[] {
        "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho",
        "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"
        }},
        {"pl", new string[] {
        "styczeń", "luty", "marzec", "kwiecień", "maj", "czerwiec",
        "lipiec", "sierpień", "wrzesień", "październik", "listopad", "grudzień"
        }},
        {"uk", new string[] {
        "Січень", "Лютий", "Березень", "Квітень", "Травень", "Червень", 
        "Липень", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень"
        }}
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