using System;

namespace Kalender
{
    class Program
    {
        static String language = "de-DE";
        static string[] SplitInput;
        static string input = "";
        static string name = "";

        static void Main(string[] args)
        {
            int y=0; name = "";
            input="";
            
            if(args.Length == 0){
                Console.WriteLine("Usage: Kalender YYYY [optional: name]");
            }
            bool isOK = args.Length>0 && int.TryParse(args[0], out y);
            if(!isOK){
                Console.WriteLine("Please enter a year (four digits).");
                input = Console.ReadLine();
                SplitInput = input.Split(" ");
                isOK = int.TryParse(SplitInput[0], out y);
            }
            //
            if(y>=1900 && isOK){
                
                var Naming = input.Length>4 ? input.Substring(4).Trim() : "";
                if(Naming!=String.Empty) name+="_"+Naming;

                if(args.Length>1){
                    for (int i=1; i< args.Length; i++){
                        if(args[i].Contains("lang=") && args[i].Length >5) {
                            language = args[i].Substring(5);
                        }
                        monthnaming.Language = language;
                        name += "_"+args[i];
                    }
                }
                else {
                    if(SplitInput!=null)
                    foreach(String s in SplitInput){
                        if (s!= null && s.Contains("lang=")){ 
                            language = s.Substring(5); 
                            monthnaming.Language = language;
                        }
                    }
                }

                new TheYear(y, name);
                Console.WriteLine(@"HTML calendar for "+name+" for "+y);
            }
            else{
                Console.WriteLine("Cannot generate a calendar for year "+y);
            }
        }
    }
}
