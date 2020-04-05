using System;
using System.IO;
//HEY you need to properly implement the inputPath argument in your functions so that the path variable used in your functions is actually the one used in the argument!!!
namespace Brogramming
{
    public class differentMethods
    {
        public void CreateTextFile(string inputPath)
        {
            string fileName; //This string adds onto the path string to allow the user to name their own .txt file
            string someText; //This string is the raw text that the user will input 
   
            bool fileExists = true;
            

            while (fileExists)
            {
                inputPath = @"C:\Users\Vipertoo\Desktop\TextFiles\";
                Console.WriteLine("Input new file name, or type '!exit'");
                fileName = Console.ReadLine();
                if (fileName == "!exit")
                {
                    return;
                }

                inputPath = inputPath + fileName + ".txt";
                if (!File.Exists(inputPath))
                {
                    fileExists = false;
                }
                else
                {
                    Console.WriteLine("That file already exists!");
                }
            }





            using (StreamWriter sw = File.CreateText(inputPath))
                    {
                        Console.WriteLine("Input some text");
                        someText = Console.ReadLine();
                        sw.WriteLine(someText);
                    }
                
            
        }
        public void ReadTextFile(string inputPath)
        {
            string fileName; //This string adds onto the path string to allow the program to find the file
            bool fileExists = true;
            

            while (fileExists)
            {
                
                Console.WriteLine("Input existing file name, or type '!exit'");
                fileName = Console.ReadLine();
                if(fileName == "!exit")
                {
                    return;
                }
                inputPath = inputPath + fileName + ".txt";
                if(File.Exists(inputPath))
                {
                    fileExists = false;
                }
                else
                {
                    Console.WriteLine("That file doesn't exist!");
                }
            }
            


               
            using (StreamReader sr = File.OpenText(inputPath))
            {
              string s;
              while ((s = sr.ReadLine()) != null)
              {
                  Console.WriteLine(s);
              }
            }
            
        }
        public void DeleteTextFile(string inputPath)
        {
            string fileName; //This string adds onto the path string to allow the program to find the file

            bool fileExists = true;
            

            while (fileExists)
            {
               
                Console.WriteLine("Input existing file name, or type '!exit'");
                fileName = Console.ReadLine();
                if (fileName == "!exit")
                {
                    return;
                }
                inputPath = inputPath + fileName + ".txt";
                if (File.Exists(inputPath))
                {
                    fileExists = false;
                }
                else
                {
                    Console.WriteLine("That file doesn't exist!");
                }
            }

            System.IO.File.Delete(inputPath);
            return;


        }
        public void ListFile(string inputPath)
        {
            string[] fileNames = Directory.GetFiles(inputPath);
            for (int i = 0; i < fileNames.Length; i++)
            {
                Console.WriteLine(fileNames[i]);
            }

        }
        public void CreatePath(string inputPath)//grants the user the option to create another folder to better organize text files
        {
            string newDirectory;
            Console.WriteLine("Name your new Directory");
            newDirectory = Console.ReadLine();
            inputPath = inputPath + newDirectory + "\\";

            Directory.CreateDirectory(inputPath);
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            differentMethods bro = new differentMethods();
            bool exitCon = true;
            int caseSwitch;
            string path = @"C:\Users\Vipertoo\Desktop\TextFiles\";//this path is a default you need to allow user to change the path manually

            //This loop allows the user to use the program multiple times in a single session
            while (exitCon)
            {
                //Showing the different options that the program has to offer
                Console.WriteLine("========== Main Menu ==========");
                Console.WriteLine("Input a number for what you would like to do." + " (Current file path: " + path + ")");
                Console.WriteLine("1: Create text files.");
                Console.WriteLine("2: Read text files.");
                Console.WriteLine("3: Delete File test");
                Console.WriteLine("4: List file names");
                Console.WriteLine("5: Create a new directory(under construction)");
                Console.WriteLine("6: Exit the program");


                caseSwitch = Convert.ToInt32(Console.ReadLine());
                switch (caseSwitch)
                {
                    case 1:
                        bro.CreateTextFile(path);
                        break;
                    case 2:
                        bro.ReadTextFile(path);
                        break;
                    case 3:
                        bro.DeleteTextFile(path);
                        break;
                    case 4:
                        bro.ListFile(path);
                        break;
                    case 5:
                        bro.CreatePath(path);
                        break;
                    case 6:
                        exitCon = false;
                        break;
                    default:
                        Console.WriteLine("You have to input a proper option!");
                        break;
                }
            }

        }
    }
}
