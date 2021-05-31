using System;

namespace SwarmRobotics_Assignment2
{
    //Class Circle
    public class Circle 
    {
        public double center_x = 0, center_y = 0;
        public double radius;
        public double test_x, test_y;
        public double center_x_shifted, center_y_shifted;

        //Method to input Radius from User
        static double GetRadius()
        {
            double r= Convert.ToDouble(Console.ReadLine());
            if (r < 0)
            {
                Console.WriteLine("Please Enter a valid Radius ");
                double r1=GetRadius();
                return r1;
            }
            else
                return r;
        }

        //Method to Recieve  coordinates of Test Point from user

        //Recieve x coordinate
        static double GetTestPoint_x()
        {
            Console.WriteLine("x coordinate: ");
            double x = Convert.ToDouble(Console.ReadLine());
            return x;
        }

        //Recieve y coordinates
        static double GetTestPoint_y()
        {
            Console.WriteLine("y coordinate: ");
            double y = Convert.ToDouble(Console.ReadLine());
            return y;
        }

        //Method to check if Test Point lies inside or outside the Region
        static int CheckRegion(double x1,double x2,double y1,double y2,double r)
        {
            double d = ((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1));
            if (d - (r * r) <= 0.0001)
                return 1;
            else
                return 0;
        }

        //Method to Translate the Circular Region R to R1

        //Translate x coordinate of center
        static double Translate_x()
        {
            Console.WriteLine("1.Enter the new x coordinate of center after Translation: ");
            double x= Convert.ToDouble(Console.ReadLine());
            return x;
        }

        //Translate y coordinate of center
        static double Translate_y()
        {
            Console.WriteLine("2. Enter the new y coordinate of center after Translation: ");
            double y = Convert.ToDouble(Console.ReadLine());
            return y;
        }

        //Check Region after Shift

        static void CheckNewRegion(double r, double r1)
        {
            if (r== 1 && r1 == 1)
                Console.WriteLine("Point lies inside both region R and R1");
            else if (r== 1 && r1 == 0)
                Console.WriteLine("Point lies inside region R but outside region R1");
            else if (r== 0 && r1 == 1)
                Console.WriteLine("Point lies outside region R but inside R1");
            else if (r == 0 && r1 == 0)
                Console.WriteLine("Point Lies outside both region R and R1");
        }

        //Horizontal rule
        static void HorizontalRule()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------");
        }

        //Driver for Test
        static void Driver()
        {
            Console.WriteLine("                      Welcome User                 ");
            HorizontalRule();
            Console.WriteLine("Today We are running the Test on a Cirular Region R.");
            Console.WriteLine("The Region R is centered at the origin. Please enter desired Radius");
            Circle myObj = new Circle();
            myObj.radius = GetRadius();
            
            do
            {
                HorizontalRule();
                Console.WriteLine("Select Your choice:");
                Console.WriteLine("1.Check if a Test Point lies inside or outside region");
                Console.WriteLine("2.Translate Region R to R1, and check if a Test Point lies inside or outside original and translated region");
                Console.WriteLine("3.Resize circle (Enter New Radius)");
                int choice = Convert.ToInt32(Console.ReadLine());
                string decide;
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Please enter the Coordinates of the Test point");
                            myObj.test_x = GetTestPoint_x();
                            myObj.test_y = GetTestPoint_y();
                            if (CheckRegion(myObj.center_x, myObj.test_x, myObj.center_y, myObj.test_y, myObj.radius) == 1)
                                Console.WriteLine("This point lies in the Region R");
                            else
                                Console.WriteLine("Point lies Outside the Region R");
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Please enter the coordinates of the new Center");
                            myObj.center_x_shifted = Translate_x();
                            myObj.center_y_shifted = Translate_y();
                            double region = (CheckRegion(myObj.center_x, myObj.test_x, myObj.center_y, myObj.test_y, myObj.radius));
                            double region1 = (CheckRegion(myObj.center_x_shifted, myObj.test_x, myObj.center_y_shifted, myObj.test_y, myObj.radius));
                            CheckNewRegion(region, region1);
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Please enter new radius ");
                            myObj.radius = GetRadius();
                            Console.WriteLine("Circle has been resized");
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid choice");
                        }
                        break;
                }
                Console.WriteLine("Do You wish to Run more tests? (Y/N)");
                decide = Console.ReadLine();
                if (decide == "Y" || decide == "y")
                    continue;
                else break;
            } while (true);
        }
        //Main
        public static void Main(string[] args)
        {
            Driver();
        }
    }
    
}
