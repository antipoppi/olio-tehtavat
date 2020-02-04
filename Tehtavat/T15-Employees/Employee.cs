using System;
using System.Collections.Generic;
using System.Text;

namespace T15_Employees
{
    class Employee
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        public float Salary { get; set; }
        // korvataan ToString-metodi omalla toteutuksella
        public override string ToString()
        {
            return $"Työntekijä: {Name}, {Profession}, Palkka: {Salary}€"; 
            // dollarimerkki=merkkijono jota "koostetaan" (class System.String)
        }
    }
    class Boss : Employee
    {
        public string Car { get; set; }
        public float Bonus { get; set; }
        // korvataan ToString-metodi omalla toteutuksella
        public override string ToString()
        {
            return base.ToString() + ", Bonus " + Bonus + "€, Auto: " + Car;
        }
    }
}
