//using System;
//using System.IO;
//namespace FileCreation
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //Set the File Path where you want to Create the File in your Disk
//            string FilePath = @"D:\MyFile.txt";

//            //Create an Instance of FileStream Class By specifying the File Path and File Mode
//            //FileMode is going to be Create as we are going to create a New File
//            FileStream fileStream = new FileStream(FilePath, FileMode.Create);

//            //Finally close the fileStream Object
//            fileStream.Close();
//            Console.Write("File has been created and the Path is D:\\MyFile.txt");
//            Console.ReadKey();
//        }
//    }
//}