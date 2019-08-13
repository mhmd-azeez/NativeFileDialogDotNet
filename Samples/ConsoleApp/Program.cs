using NativeFileDialogDotNet;
using System;

namespace ConsoleApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var dialog = new FolderPickerDialog();
            dialog.DefaultPath = "D:\\hello.txt";
            //dialog.Filter = "jpg,png;pdf";

            var result = dialog.Show();
            if (result == NfdResult.Okay)
            {
                Console.WriteLine(dialog.Path);
            }
        }
    }
}
