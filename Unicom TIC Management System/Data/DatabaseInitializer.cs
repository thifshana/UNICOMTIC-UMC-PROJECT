using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management_System.Database;

namespace Unicom_TIC_Management_System.Data
{
    public static class DatabaseInitializer
    {
        public static void CreateTable()
        {
          using (var conn = DbConfig.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    
                    CREATE TABLE IF NOT EXISTS Course (
                        CourseID INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseName TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Exam (
                        ExamID INTEGER PRIMARY KEY AUTOINCREMENT,
                        ExamName TEXT NOT NULL,
                        SubjectID INTEGER NOT NULL,
                        PRIMARY KEY (ExamID),
                        FOREIGN KEY (SubjectID) REFERENCES Subject(SubjectID)
                    );
                    
                    CREATE TABLE IF NOT EXISTS Mark (
                        MarkID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentID INTEGER NOT NULL,
                        ExamID INTEGER NOT NULL,
                        Score INTEGER NOT NULL,
                        PRIMARY KEY (MarkID),
                        FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
                        FOREIGN KEY (ExamID) REFERENCES Exam(ExamID)
                    );
                    
                 CREATE TABLE IF NOT EXISTS Room (
                        RoomID INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoomName TEXT NOT NULL,
                        RoomType TEXT NOT NULL
                    );

                CREATE TABLE IF NOT EXISTS Student (
                        StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        CourseID INTEGER NOT NULL,
                        PRIMARY KEY (StudentID),
                        FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
                    );

                 CREATE TABLE IF NOT EXISTS Subject (
                        SubjectID INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectName TEXT NOT NULL,
                        CourseID INTEGER NOT NULL,
                        PRIMARY KEY (SubjectID),
                        FOREIGN KEY (CourseID) REFERENCES Course(CourseID)

                    );

                 CREATE TABLE IF NOT EXISTS Timetable (
                        TimetableID INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectID INTEGER NOT NULL,
                        TimeSlot TEXT NOT NULL,
                        RoomID INTEGER NOT NULL,
                        PRIMARY KEY (TimetableID),
                        FOREIGN KEY (SubjectID) REFERENCES Subject(SubjectID),
                        FOREIGN KEY (RoomID) REFERENCES Room(RoomID)

                    );
                  CREATE TABLE IF NOT EXISTS User (
                        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        Password TEXT NOT NULL,
                        Role TEXT NOT NULL
                    );


                ";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
