using System;

namespace Kalender
{
    class Program
    {
        static void Main(string[] args)
        {
            int y=0; string name = "";
            if(args.Length == 0){
                Console.WriteLine("Usage: Kalender YYYY [optional: name]");
            }
            bool isOK = args.Length>0 && int.TryParse(args[0], out y);
            if(!isOK){
                Console.WriteLine("Please enter a year (four digits).");
                isOK = int.TryParse(Console.ReadLine(), out y);
            }
            //
            if(y>=1900 && isOK){
                if(args.Length>1){
                    for (int i=1; i< args.Length; i++){
                        name += "_"+args[i];
                    }
                    Console.WriteLine(@"HTML calendar for "+name+" for "+y);
                    new TheYear(y, name);
                }
                else {
                    Console.WriteLine("HTML calendar for "+y);
                    new TheYear(y);
                }
            }
            else{
                Console.WriteLine("Cannot generate a calendar for year "+y);
            }
        }
    }
}
