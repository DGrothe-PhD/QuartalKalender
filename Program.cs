using System;

namespace Kalender
{
    class Program
    {
        static String language = "de-DE";
        static String[] SplitInput;
        static string input = "";
        static string name = "";

        static bool isWide = false;

        static void argParse(String s){
            
            if(s!= null){
                if (s.Contains("lang=")){ 
                    language = s.Substring(5); 
                    monthnaming.Language = language;
                    calendarnames.language =language;
                }
                if (s.Contains("wide=")){
                    isWide = s.Substring(5).Equals("true");
                }
            }
        }

        static void Main(string[] args)
        {
            int yearnumber=0; name = "";
            input="";
            
            if(args.Length == 0){
                Console.WriteLine("Usage: Kalender YYYY [optional: name]");
            }
            bool isOK = args.Length>0 && int.TryParse(args[0], out yearnumber);
            if(!isOK){
                Console.WriteLine("Please enter a year (four digits).");
                input = Console.ReadLine();
                SplitInput = input.Split(" ");

                var Naming = input.Length>4 ? input.Substring(4).Trim() : "";
                if(Naming!= "") name+="_"+Naming;

                isOK = int.TryParse(SplitInput[0], out yearnumber);
            }

            //
            if(yearnumber>=1900 && isOK){

                if(args.Length>1){
                    for(int i=1; i<args.Length;i++){
                        name = "_"+args[i]+name;
                        argParse(args[i]);
                    }
                }

                if(SplitInput!= null){
                    foreach(String s in SplitInput){
                        argParse(s);
                    }
                }

                new TheYear(yearnumber, name, isWide);
                Console.WriteLine(@"HTML calendar for "+name+" for "+yearnumber);
            }
            else{
                Console.WriteLine("Cannot generate a calendar for year "+yearnumber);
            }
        }
    }
}
