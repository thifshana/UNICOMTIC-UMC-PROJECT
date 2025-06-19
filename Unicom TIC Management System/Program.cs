using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management_System.Data;
using Unicom_TIC_Management_System.View;

namespace Unicom_TIC_Management_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DatabaseInitializer.CreateTable();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new LoginForm());
            //Application.Run(new UserForm());
            //Application.Run(new courseForm1());
            //Application.Run(new RoomForm());
            //Application.Run(new StudentForm());
            //Application.Run(new ExamForm());
            //Application.Run(new TimetableForm());
            //Application.Run(new MarkForm());
            //Application.Run(new SubjectForm());
        }
    }
}
