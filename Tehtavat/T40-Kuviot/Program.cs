/* T40-Kuviot
 * Tehtävänanto:
 * 
 * Toteuta sovellus, jolla voidaan käsitellä erilaisia kuviota (esim. Circle ja Rectangle).
 * Laadi erillinen abstrakti Shape-luokka, josta muut kuviot peryityvät.
 * Määrittele Shape-luokan ominaisuutena kuvion nimi (Name) ja abstraktit Area- ja Circumference-metodit (pinta-ala ja ympärysmitta). 
 * Peri Circle- ja Rectangle-luokat Shape-luokasta ja toteuta Area- ja Circumference-metodit. 
 * Luo Shapes-luokka ja sen sisälle List-tietorakenne, jonne voit aina lisätä kuvioita. 
 * Toteuta pääohjelma, jossa käytät Shapes-luokkaa, luo muutamia eri kuviota ja lisää ne Shapes-luokassa olevaan List-tietorakenteeseen.
 * 
 * Käy pääohjelmassa lopuksi läpi Shapes-luokan List-tietorakenne ja tulosta kaikki sen sisältämät kuviot.
 */

using System;
using System.Collections.Generic;

namespace T40_Kuviot
{
    public abstract class Shape
    {
        public string Name { get; set; }
        public abstract double Area(); // pinta-ala
        public abstract double Circumference(); // ympärysmitta
        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
    public class Circle : Shape
    {
        public double Radius { get; }
        public double CircleArea { get; }
        public double CircleCircumference { get; }
        public Circle(double radius)
        {
            Name = "Circle";
            Radius = radius;
            CircleArea = Area();
            CircleCircumference = Circumference();
        }
        public override double Area()
        {
            double a = Math.PI * Math.Pow(Radius, 2);
            return a;
        }
        public override double Circumference()
        {
            double c = 2 * Math.PI * Radius;
            return c;
        }
        public override string ToString()
        {
            return base.ToString() + $"\n- Radius: {Radius}m\n- Area: {CircleArea.ToString("0.00")}m^2" +
                $"\n- Circumference: {CircleCircumference.ToString("0.00")}m\n";
        }
    }
    public class Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }
        public double RectangleArea { get; }
        public double RectangleCircumference { get; }
        public Rectangle(double x, double y)
        {
            Name = "Rectangle";
            Width = x;
            Height = y;
            RectangleArea = Area();
            RectangleCircumference = Circumference();
        }
        public override double Area()
        {
            double a = Width * Height;
            return a;
        }
        public override double Circumference()
        {
            double c = Width * 2 + Height * 2;
            return c;
        }
        public override string ToString()
        {
            return base.ToString() + $"\n- Width: {Width}m\n- Height: {Height}m\n- Area: {RectangleArea.ToString("0.00")}m^2," +
                $"\n- Circumference: {RectangleCircumference.ToString("0.00")}m\n";
        }
    }
    public class Shapes
    {
        public List<Shape> MyShapes { get; }
        public Shapes()
        {
            MyShapes = new List<Shape>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shapes shapes = new Shapes();
            shapes.MyShapes.Add(new Circle(5));
            shapes.MyShapes.Add(new Circle(3.2));
            shapes.MyShapes.Add(new Rectangle(5,3));
            shapes.MyShapes.Add(new Rectangle(2.4,3.8));
            PrintShapes(shapes);
        }
        public static void PrintShapes(Shapes shapes)
        {
            foreach (var item in shapes.MyShapes)
            {
                Console.WriteLine(item.ToString()); ;
            }
        }
    }
}
