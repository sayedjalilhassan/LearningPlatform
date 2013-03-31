using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningPlatform.Logic
{
    class Controller
    {
        static readonly Controller controller = new Controller();
        static public List<Chapter> AllChapters = new List<Chapter>();
        static public List<Lesson> AllLessons = new List<Lesson>();
        static public List<Instructor> AllInstructors = new List<Instructor>();
        static public Lesson selectedLesson = new Lesson();
        static public Chapter selectedChapter = new Chapter();


        public static List<Lesson> getLessons()
        {
            List<Lesson> lessons = new List<Lesson>();
            if (Controller.AllLessons.Count == 0)
                Controller.AllLessons = Controller.InitializeLessons();
            Console.WriteLine(AllLessons.Count);
            Console.WriteLine("Lessons initialized !!");
            return Controller.AllLessons;
        }

        public static List<Instructor> GetInstructors()
        {
            if (Controller.AllInstructors.Count == 0)
                Controller.AllInstructors = Controller.InitializeInstructors();
            return Controller.AllInstructors;
        }

        public static List<Chapter> GetChapters()
        {
            if (Controller.AllChapters.Count == 0)
                Controller.AllChapters = Controller.InitializeChapters();

            Console.WriteLine(AllChapters.Count);
            Console.WriteLine("Chapters initialized !!");
            return Controller.AllChapters;
        }


        public static List<Chapter> InitializeChapters()
        {
            Dictionary<string, bool> alreadySeen = new Dictionary<string, bool>();
            List<Chapter> chapters = new List<Chapter>();
            foreach (Lesson s in Controller.getLessons())
            {
                if (!alreadySeen.ContainsKey(s.Chapter.Title))
                {
                    alreadySeen[s.Chapter.Title] = true;
                    chapters.Add(new Chapter(s.Chapter.Title));
                }
            }
            return chapters;
        }

        public static List<Instructor> InitializeInstructors()
        {
            Dictionary<string, bool> alreadySeen = new Dictionary<string, bool>();
            List<Instructor> instructors = new List<Instructor>();
            foreach (Lesson s in Controller.getLessons())
            {
                if (!alreadySeen.ContainsKey(s.Instructor.Title))
                {
                    alreadySeen[s.Instructor.Title] = true;
                    instructors.Add(new Instructor(s.Instructor.Title));
                }
            }
            return instructors;
        }


        public static List<Lesson> InitializeLessons()
        {
            List<Lesson> lessons = new List<Lesson>();
            Chapter ch1 = new Chapter("Physical Quantities and Measurment");
            Chapter ch2 = new Chapter("Kinametics");
            Chapter ch3 = new Chapter("Dynamics");
            Chapter ch4 = new Chapter("Turning Effect of Force");
            Chapter ch5 = new Chapter("Gravitation");
            Chapter ch6 = new Chapter("Work and Energy");
            Chapter ch7 = new Chapter("Properties of Matter");
            Chapter ch8 = new Chapter("Thermal Properties of Matter");
            Chapter ch9 = new Chapter("Transfer of Heat");
            Instructor ph = new Instructor("Dr.Pervaiz HoodBhoy");


            lessons.Add(new Lesson("Introduction to Physics", ph, ch1, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Physical Quantities", ph, ch1, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("International System of Units", ph, ch1, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Prefixes", ph, ch1, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Scientific Notifications", ph, ch1, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Measuring Instruments", ph, ch1, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("An Introduction to Significant Figures", ph, ch1, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));

            lessons.Add(new Lesson("Rest and Motion", ph, ch2, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Types of Motion", ph, ch2, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Terms associated with Motion", ph, ch2, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Scalars and Vectors", ph, ch2, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Graphical Analysis of Motion", ph, ch2, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Equations of Motions", ph, ch2, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Motion due to Gravity", ph, ch2, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));

            lessons.Add(new Lesson("Momentum", ph, ch3, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Newtons laws of motion", ph, ch3, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Friction", ph, ch3, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Uniform Circular Motion", ph, ch3, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));

            lessons.Add(new Lesson("Forces on Bodies", ph, ch4, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Addition of Forces", ph, ch4, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Resolution of Forces", ph, ch4, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Momentum of a Force", ph, ch4, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Principle of Moments", ph, ch4, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Center of Mass", ph, ch4, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Couple", ph, ch4, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Couple", ph, ch4, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Stability", ph, ch4, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));

            lessons.Add(new Lesson("Law of Gravitation", ph, ch5, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Measurment of mass of Erth", ph, ch5, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Variation of g with Altitude", ph, ch5, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Motion of Artificial satellites", ph, ch5, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));

            lessons.Add(new Lesson("Work", ph, ch6, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Energy", ph, ch6, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Kinetic Energy", ph, ch6, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Potential Energy", ph, ch6, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Forms of Energy", ph, ch6, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Interconversion of Energy", ph, ch6, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Major sources of Energy", ph, ch6, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Effiency", ph, ch6, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Power", ph, ch6, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));

            lessons.Add(new Lesson("Kinetic Molecular Model of Matter", ph, ch7, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Density", ph, ch7, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Pressure", ph, ch7, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Atmosphere Pressure", ph, ch7, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Pressure in Liquids", ph, ch7, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Upthrust", ph, ch7, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Principle of Floatation", ph, ch7, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Elasticity", ph, ch7, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Stress, Strain and Young Modulus", ph, ch7, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));

            lessons.Add(new Lesson("Temperature and Heat", ph, ch8, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Thermometer", ph, ch8, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Specific Heat Capacity", ph, ch8, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Latent heat of Fusion", ph, ch8, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Latent Heat of Vaporization", ph, ch8, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Evaporation", ph, ch8, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Thermal Expansion", ph, ch8, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));

            lessons.Add(new Lesson("The Three Processes of Heat Transfer", ph, ch9, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Conduction", ph, ch9, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Convection", ph, ch9, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Radiation", ph, ch9, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            lessons.Add(new Lesson("Consequences and everyday\nApplications of Heat Transfer", ph, ch9, 5501234, new DateTime(2012, 11, 05, 5, 42, 0)));
            

            foreach (Lesson s in lessons)
            {
                s.VideoPath = @"C:\Users\Sayed_Jalil_Hassan\Desktop\types-of-motion-1.wmv";
                s.getQuizes();
                
                //Console.WriteLine(s.VideoPath);
            }

            return lessons;
        }





        /// <summary>
        /// return an instance of this class
        /// </summary>
        public static Controller Instance
        {
            get
            {
                return controller;
            }
        }

    }
}
