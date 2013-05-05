using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace LearningPlatform.Logic
{
    class Controller
    {
        static readonly Controller controller = new Controller();
        static public List<Chapter> AllChapters = new List<Chapter>();
        static public List<Lesson> AllLessons = new List<Lesson>();
        static public List<Instructor> AllInstructors = new List<Instructor>();
        static public Lesson selectedLesson = new Lesson();
        static public Lesson performanceSelectedLesson = new Lesson();
        static public Chapter selectedChapter = new Chapter();
        static public List<Lesson> finishedLessons = new List<Lesson>();
        static public List<CustomGraph> LessonsGraphs = new List<CustomGraph>();
        public static String currentUser_id;

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
                    chapters.Add(new Chapter(s.Chapter.Title, s.Chapter.Id));
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

        public static CustomGraph createGraph(String path)
        {
            if (getLessons().Count == 0)
                InitializeLessons();
            CustomGraph graph = new CustomGraph(path, "SIMPLE");

            //CustomGraph graph = new CustomGraph(@"..\..\Resources\assests\Matrices.txt", "SIMPLE");

            //CustomGraph graph = new CustomGraph(@"Resources\assests\Matrices.txt", "SIMPLE");
            return graph;
        }

        public static List<int> getPreReqsForLesson(int lesson_id)
        {
            List<int> adj_ids = new List<int>();
            CustomGraph g = new CustomGraph(@"..\..\Resources\assests\Matrices.txt", "SIMPLE");
            // CustomGraph g = Controller.GetLessonGraphs().ElementAt(0);
            // Console.WriteLine("tOTAL gRAPHS :"+Controller.GetLessonGraphs().Count);

            for (int i = 0; i < g.NumberNodes; i++)
            {
                if (g.AreAdjacent(lesson_id, i))
                {
                    adj_ids.Add(i);
                    LessonPreReq pre = getPreReq(i);
                    if (pre != null)
                        getLesson(lesson_id).PreReqs.Add((pre));
                    //Console.WriteLine("Oh Yes ADDED");
                }

            }
            //MessageBox.Show(adj_ids.Count + "");
            return adj_ids;
        }

        public static LessonPreReq getPreReq(int id)
        {
            foreach (Lesson l in Controller.getLessons())
            {
                if (l.Id == id)
                {
                    LessonPreReq p = new LessonPreReq(l);
                    p.RelativeImportance = 0.5;
                    p.MasteringLevel = 0.8;
                    return p;
                }

            }
            return null;
        }

        public static Lesson getLesson(int id)
        {
            foreach (Lesson l in Controller.getLessons())
            {
                if (l.Id == id)
                {
                    return l;
                }

            }
            return null;
        }


        public static List<CustomGraph> GetLessonGraphs()
        {
            if (Controller.LessonsGraphs.Count == 0)
            {
                string[] filePaths = Directory.GetFiles(@"..\..\Resources\assests\lessonPrereqs\", "*.txt");
                foreach (string path in filePaths)
                {
                    Console.WriteLine("Oh Graph created");
                    Controller.LessonsGraphs.Add(createGraph(path));
                }
            }
            //createGraph("");
            return Controller.LessonsGraphs;
        }



        public static List<Lesson> InitializeLessons()
        {
            List<Lesson> lessons = new List<Lesson>();
            Chapter ch1 = new Chapter("Matrices", 1);
            Chapter ch2 = new Chapter("Kinametics", 2);
            Chapter ch3 = new Chapter("Dynamics", 3);
            Chapter ch4 = new Chapter("Turning Effect of Force", 4);
            Chapter ch5 = new Chapter("Gravitation", 5);
            Chapter ch6 = new Chapter("Work and Energy", 6);
            Chapter ch7 = new Chapter("Properties of Matter", 7);
            Chapter ch8 = new Chapter("Thermal Properties of Matter", 8);
            Chapter ch9 = new Chapter("Transfer of Heat", 9);
            Instructor ph = new Instructor("Dr.Pervaiz HoodBhoy");


            lessons.Add(new Lesson(1, "1.Definition of Matrix", ph, ch1,0.8));
            lessons.Add(new Lesson(2, "2.Order of Matrix", ph, ch1, 0.8));
            lessons.Add(new Lesson(3, "3.Row Matrix and Coloumn Matrix", ph, ch1,0.6));
            lessons.Add(new Lesson(4, "4.Square and Rectangular Matrices", ph, ch1,0.8));
            lessons.Add(new Lesson(5, "5.Null or Zero Matrix", ph, ch1,0.8));
            lessons.Add(new Lesson(6, "6.Transpose of a Matrix", ph, ch1,0.7));
            lessons.Add(new Lesson(7, "7.Negative of a Matrix", ph, ch1, 0.6));
            lessons.Add(new Lesson(8, "8.Symmetric and Skew-symmetric Matrices", ph, ch1,0.7));
            lessons.Add(new Lesson(9, "9.Diagonal Matrix", ph, ch1, 0.4));
            lessons.Add(new Lesson(10, "10.Scalar Matrix", ph, ch1,0.5));
            lessons.Add(new Lesson(11, "11.Identity Matrix", ph, ch1, 0.4));
            lessons.Add(new Lesson(12, "12.Addition of Matrices", ph, ch1, 0.4));
            lessons.Add(new Lesson(13, "13.Subtraction of Matrices", ph, ch1,0.5));
            lessons.Add(new Lesson(14, "14.Multiplication of a Matrix by a Real number", ph, ch1, 0.5));
            lessons.Add(new Lesson(15, "15.Commutative Law under Addition of Matrices", ph, ch1, 0.3));
            lessons.Add(new Lesson(16, "16.Associative Law under Addition of Matrices", ph, ch1, 0.5));
            lessons.Add(new Lesson(17, "17.Additive Identity of a Matrix", ph, ch1, 0.3));
            lessons.Add(new Lesson(18, "18.Additive Inverse of a Matrix", ph, ch1,0.34));
            lessons.Add(new Lesson(19, "19.Multiplication of Matrices", ph, ch1, 0.4));
            lessons.Add(new Lesson(20, "20.Associative Law under Multiplication of Matrices", ph, ch1,0.35));
            lessons.Add(new Lesson(21, "21.Distributive Law of Multiplication over Addition for Matrices", ph, ch1, 0.54));
            lessons.Add(new Lesson(22, "22.Commutative Law of Multiplication of Matrices for Matrices", ph, ch1,0.2));

            lessons.Add(new Lesson(1, "Rest and Motion", ph, ch2, 0.2));
            lessons.Add(new Lesson(2, "Types of Motion", ph, ch2, 0.2));
            lessons.Add(new Lesson(3, "Terms associated with Motion", ph, ch2, 0.2));
            lessons.Add(new Lesson(4, "Scalars and Vectors", ph, ch2, 0.2));
            lessons.Add(new Lesson(5, "Graphical Analysis of Motion", ph, ch2, 0.2));
            lessons.Add(new Lesson(6, "Equations of Motions", ph, ch2, 0.2));
            lessons.Add(new Lesson(7, "Motion due to Gravity", ph, ch2, 0.2));

            lessons.Add(new Lesson(1, "Momentum", ph, ch3, 0.2));
            lessons.Add(new Lesson(2, "Newtons laws of motion", ph, ch3, 0.2));
            lessons.Add(new Lesson(3, "Friction", ph, ch3, 0.2));
            lessons.Add(new Lesson(4, "Uniform Circular Motion", ph, ch3, 0.2));

            lessons.Add(new Lesson(1, "Forces on Bodies", ph, ch4, 0.2));
            lessons.Add(new Lesson(2, "Addition of Forces", ph, ch4, 0.2));
            lessons.Add(new Lesson(3, "Resolution of Forces", ph, ch4, 0.2));
            lessons.Add(new Lesson(4, "Momentum of a Force", ph, ch4, 0.2));
            lessons.Add(new Lesson(5, "Principle of Moments", ph, ch4, 0.2));
            lessons.Add(new Lesson(6, "Center of Mass", ph, ch4, 0.2));
            lessons.Add(new Lesson(7, "Couple", ph, ch4, 0.2));
            lessons.Add(new Lesson(8, "Couple", ph, ch4, 0.2));
            lessons.Add(new Lesson(9, "Stability", ph, ch4, 0.2));

            lessons.Add(new Lesson(1, "Law of Gravitation", ph, ch5, 0.2));
            lessons.Add(new Lesson(2, "Measurment of mass of Erth", ph, ch5, 0.2));
            lessons.Add(new Lesson(3, "Variation of g with Altitude", ph, ch5, 0.2));
            lessons.Add(new Lesson(4, "Motion of Artificial satellites", ph, ch5, 0.2));

            lessons.Add(new Lesson(1, "Work", ph, ch6, 0.2));
            lessons.Add(new Lesson(2, "Energy", ph, ch6, 0.2));
            lessons.Add(new Lesson(3, "Kinetic Energy", ph, ch6, 0.2));
            lessons.Add(new Lesson(4, "Potential Energy", ph, ch6, 0.2));
            lessons.Add(new Lesson(5, "Forms of Energy", ph, ch6, 0.2));
            lessons.Add(new Lesson(6, "Interconversion of Energy", ph, ch6, 0.2));
            lessons.Add(new Lesson(7, "Major sources of Energy", ph, ch6, 0.2));
            lessons.Add(new Lesson(8, "Effiency", ph, ch6, 0.2));
            lessons.Add(new Lesson(9, "Power", ph, ch6, 0.2));

            lessons.Add(new Lesson(1, "Kinetic Molecular Model of Matter", ph, ch7, 0.2));
            lessons.Add(new Lesson(2, "Density", ph, ch7, 0.2));
            lessons.Add(new Lesson(3, "Pressure", ph, ch7, 0.2));
            lessons.Add(new Lesson(4, "Atmosphere Pressure", ph, ch7, 0.2));
            lessons.Add(new Lesson(5, "Pressure in Liquids", ph, ch7, 0.2));
            lessons.Add(new Lesson(6, "Upthrust", ph, ch7, 0.2));
            lessons.Add(new Lesson(7, "Principle of Floatation", ph, ch7, 0.2));
            lessons.Add(new Lesson(8, "Elasticity", ph, ch7, 0.2));
            lessons.Add(new Lesson(9, "Stress, Strain and Young Modulus", ph, ch7, 0.2));

            lessons.Add(new Lesson(1, "Temperature and Heat", ph, ch8, 0.2));
            lessons.Add(new Lesson(2, "Thermometer", ph, ch8, 0.2));
            lessons.Add(new Lesson(3, "Specific Heat Capacity", ph, ch8, 0.2));
            lessons.Add(new Lesson(4, "Latent heat of Fusion", ph, ch8, 0.2));
            lessons.Add(new Lesson(5, "Latent Heat of Vaporization", ph, ch8, 0.2));
            lessons.Add(new Lesson(6, "Evaporation", ph, ch8, 0.2));
            lessons.Add(new Lesson(7, "Thermal Expansion", ph, ch8, 0.2));

            lessons.Add(new Lesson(1, "The Three Processes of Heat Transfer", ph, ch9, 0.2));
            lessons.Add(new Lesson(2, "Conduction", ph, ch9, 0.2));
            lessons.Add(new Lesson(3, "Convection", ph, ch9, 0.2));
            lessons.Add(new Lesson(4, "Radiation", ph, ch9, 0.2));
            lessons.Add(new Lesson(5, "Consequences and everyday\nApplications of Heat Transfer", ph, ch9, 0.2));

            int i = 0;
            foreach (Lesson s in lessons)
            {
                s.VideoPath = getVideoPath(i);
                i++;
                //s.VideoPath = @"C:\videos\1.mp4";
                s.getQuizes();
                Console.WriteLine(s.VideoPath);
            }

            Controller.selectedLesson = lessons.ElementAt(0);

            return lessons;
        }

        public static string getVideoPath(int id)
        {

            FileStream ifs = new FileStream(@"..\..\Resources\assests\video_paths.txt", FileMode.Open);

            //FileStream ifs = new FileStream(@"Resources\assests\video_paths.txt", FileMode.Open);
            StreamReader sr = new StreamReader(ifs);
            string line = "";
            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (i == id)
                {
                    sr.Close(); ifs.Close();
                    return line;
                }
                i++;
            }
            sr.Close(); ifs.Close();
            return "";
        }


        public static void postToUrl()
        {
            WebRequest request = WebRequest.Create("http://192.168.0.1/PostAccepter.aspx ");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
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
