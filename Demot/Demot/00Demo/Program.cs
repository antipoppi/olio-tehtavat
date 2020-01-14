using System;

namespace _00Demo
{
    //a very simple Dog class
    class Dog
    {
        //ominaisuudet (properties)
        public string Name { get; set; }
        //konstruktorit (constructors)
        //HUOM: luokalla on olemassa ns. oletuskonstruktori
        //mutta oletuskonstruktori häviää, kun määritellään omia konstruktoreita
        public Dog()
        { 
        }
        public Dog(string name)
        {
            Name = name;
        }
        //metodit (methods)
        public string Growl()
        {
            //some interesting growling action happens here...
            return "Murrr";
        }
        public string Bark(int times)
        {
            string bark = "";
            for (int i = 0; i < times; i++)
            {
                bark += "vuh ";
            }
            return bark;
        }
    }

    //DogDemo class
    class DogDemo
    {
        //Main method
        static void Main(string[] args)
        {
            //luodaan olio eli instanssi luokasta Dog. (create a new Dog object instance)
            Dog dog = new Dog();
            //set dog's name
            dog.Name = "Murre";
            //show object's property and make him growl and bark calling method
            Console.WriteLine("Koirani nimi on {0} ja se sanoo {1} {2}", dog.Name, dog.Growl(), dog.Bark(10));
            //luodaan toinenkin koira
            Dog puppy = new Dog("Ressu"); //viitattiin Dog(string name) konstruktoriin.
            Console.WriteLine("Naapurillani on koira nimeltä {0} ja se sanoo {1} {2}", puppy.Name, puppy.Growl(), puppy.Bark(3));
            //testataan taulukon (array) luonti ja käyttö
            Dog[] dogs = new Dog[2];
            dogs[0] = dog; //Murre ensimmäiseen muistipaikkaan
            dogs[1] = puppy; //Ressu toiseen muistipaikkaan
            //näytetään taulukon koirien tiedot
            foreach (Dog item in dogs)
            {
                Console.WriteLine(item.Name + " " + item.Bark(2));
            }
        }
    }
}
