using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Diagnostics;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using check1;
using System.Data;
using System.Linq.Expressions;
using static check1.Program;
using System.Threading;
using System.Security;
using System.Collections;
using static OOtest.M;
using static check1.CodeWars_ObservedPin;

namespace CovarianceProblem
{
    internal class Prog
    {
        public class MyStack<T> : IPushable<T>, IPoppable<T>
        {
            int position;
            T[] data = new T[100];
            public void Push(T obj) => data[position++] = obj;
            public T Pop() => data[--position];
        }

        public class Animals
        {
            public virtual void Voice()
            {
                Console.WriteLine("Animal voice");
            }
        }

        public class Bear : Animals
        {
            public override sealed void Voice()
            {
                Console.WriteLine("Bear voice");
            }
        }

        public class Rabbit : Animals
        {
            public override sealed void Voice()
            {
                Console.WriteLine("Rabbit voice");
            }
        }


        public interface IPushable<in T>
        {
            void Push(T obj);
        }

        public interface IPoppable<out T>
        {
            T Pop();
        }


        static void Main(string[] args)
        {
            ////
            var animals = new MyStack<Animals>();

            animals.Push(new Rabbit());
            animals.Push(new Bear());
            ////

            //--------------

            ////
            var bearstack = new MyStack<Bear>();
            bearstack.Push(new Bear());
            ////

            //--------------

            ////
            var rabbitstack = new MyStack<Rabbit>();
            rabbitstack.Push(new Rabbit());
            ////

            //--------------

            IPushable<Animals> pushableAnimals = new MyStack<Animals>();
            IPushable<Bear> bears = bearstack;

            pushableAnimals.Push(new Rabbit());
            pushableAnimals.Push(new Bear());

            bears = pushableAnimals;

            pushableAnimals.Push(new Bear());


            //--------------

            IPoppable<Animals> poppableAnimals = new MyStack<Animals>();
            //IPoppable<Bear> poppableBears = bears;



        }
    }
}


namespace check1
{
    //int c = 5;
    //int a = c++ + c; 
    internal class Program
    {
        public interface IWashable<T>
        {

        }

        public class VehicleCleaner
        {
            public static void Wash<T>(Stack<T> vehicles) where T : Vehicles { }

            public static void Wash(IWashable<Vehicles> vehicles)
            {

            }
        }

        public class VehicleCleaner1
        {
            public static void Wash(Stack<Vehicles> vehicles) { }
        }

        static void Main(string[] args)
        {
            var stack = new Stack<Vehicles>();

            var byci = new Stack<Bicycle>();
            byci.Push(new Bicycle() { Name = "1" });
            byci.Push(new Bicycle() { Name = "2" });

            ////////stack = byci; compiler error 
            //но я могу копировать по одиночке, потом вставить че нить другое, типа:
            //foreach (var item in byci)
            //{
            //    stack.Push(item);
            //}

            //var boat = new Stack<Boat>();

            //stack.Push(new Boat());
            ////////// и вот в стаке уже велики и лодки

            Vehicles.PushInto(byci, stack);


            stack.Push(new Bicycle());
            stack.Push(new Boat());

            //VehicleCleaner1.Wash(byci); //error

            VehicleCleaner1.Wash(stack);

            VehicleCleaner.Wash(stack);

            IWashable<Vehicles> byciForWash = (IWashable<Vehicles>)byci;
            VehicleCleaner.Wash(byciForWash);


            //var xx = CodeWars_NextBiggerNumber.NextBiggerNumber(144);

            var animal = new Animal() { age = 1 };

            var cat = new Cat() { age = 5, Name = "kitty" };
            cat.GetAgeName();

            var dog = new Dog() { age = 3, Name = "doggy" };
            dog.GetAgeName();

            animal = dog;
            if (animal is Dog d) //cast to Dog
                d.GetAgeName();

            //without cast animal.GetAgeName() will return base.GetAgeName()



            var ts = new Asset() { Liability = 12 };
            var ts1 = new Test();

            var nt = ts1.foo();

            if (nt is Test tst)
                tst.Name = "23";

            var carr1 = new Carr() { Name = "bmw", SomeSh = 1 };
            var carr2 = new Carr();

            var carr3 = new Carr2() { Name = "volga" };

            var car1 = new Car("a1");
            var car2 = new Car("a2");

            var i1 = 0x1;
            var i2 = 0x9;
            var i22 = 0x10;
            var i221 = 0x20;
            var i3 = 0x32432432;

            var t = Car.amountOfCars;

            float f = 4.5F;

            BitOperations.RotateLeft(12312, 1);

            string s = null;

            var sslen = s?.Length ?? -1;

            var xswitch = sslen switch
            {
                1 => "one",
                2 => "two",
                _ => "none"
            };

        }

        public class Car
        {
            public int number;

            private string _name;

            public static int amountOfCars;

            public Car(string name)
            {
                _name = name;
                amountOfCars++;
            }

            public string GetName()
            {
                return _name;
            }

            public int GetAmountOfCarsCreated()
            {
                return amountOfCars;
            }
        }

        public class Carr
        {
            private int somesh;

            public Carr()
            {
                somesh = 0;
            }
            public String Name
            {
                get; init;
            } = "volvo";

            public int SomeSh
            {
                get { return somesh; }
                set { somesh = value; }
            }
        }

        public class Carr2 : Carr
        {
            private readonly string name;

            private int somesh;

            public Carr2()
            {
                somesh = -2;
            }
            public new String Name
            {
                get { return name; }
                init
                {
                    name = value;
                }
            }

            public int SomeSh
            {
                get { return somesh; }
                set { somesh = value; }
            }
        }


        public class Asset
        {
            public string Name;
            private decimal liability = 2;
            //public virtual decimal Liability => 2;

            public virtual decimal Liability { get { return liability; } init { liability = value; } }
        }

        public class Test : Asset
        {
            public override decimal Liability => base.Liability + 1;

            public Test()
            {
                Name = "rofl";
            }

            public object foo()
            {
                return this.MemberwiseClone();
            }

        }


        public class Animal
        {
            public string Name { get; set; }

            public int age { get; set; }

            public virtual void GetAgeName()
            {
                Console.WriteLine($"{age} and {Name}");
            }
        }

        public class Cat : Animal
        {
            private readonly int allCats;

            public Cat() : base()
            {
                allCats++;
            }
            public override void GetAgeName()
            {
                Console.Write("Cat"); base.GetAgeName();
            }
        }

        public class Dog : Animal
        {
            public new void GetAgeName()
            {
                Console.Write("Dog");
            }
        }

        public class Vehicles : IWashable<Vehicles>
        {
            public string Name { get; set; }

            public static void PushInto<T>(Stack<T> source, Stack<Vehicles> destination) where T : Vehicles
            {
                foreach (var item in source)
                {
                    destination.Push(item);
                }
            }

        }

        public class Bicycle : Vehicles
        {

        }

        public class Boat : Vehicles
        {

        }



    }
}


namespace OOtest
{
    public interface ICapableBehavior
    {
        public void Move();
    }

    public class FloatingBehavior : ICapableBehavior
    {
        public void Move()
        {
            Console.WriteLine("I am floating");
        }

    }

    public class MovableBehavior : ICapableBehavior
    {
        public void Move()
        {
            Console.WriteLine("I am moving on a ground");
        }
    }

    abstract class Vehicle
    {
        protected string numberPlate;
        protected string vehicleType;
        protected ICapableBehavior capableBehavior;
        public abstract void SetBehavior(ICapableBehavior capableBehavior);

        public virtual void Act() { capableBehavior.Move(); }
    }

    class Car : Vehicle
    {
        public Car(string num)
        {
            this.numberPlate = num;
            this.vehicleType = "Car";
            this.capableBehavior = new MovableBehavior();
        }

        public override void SetBehavior(ICapableBehavior capableBehavior)
        {
            this.capableBehavior = capableBehavior;
        }

    }

    class Boat : Vehicle
    {
        public Boat(string num)
        {
            this.numberPlate = num;
            this.vehicleType = "Boat";
            this.capableBehavior = new FloatingBehavior();
        }

        public override void SetBehavior(ICapableBehavior capableBehavior)
        {
            this.capableBehavior = capableBehavior;
        }

    }

    #region decorator2
    interface IPrice
    {
        public double GetPrice();
    }

    abstract class Home : IPrice
    {
        public double basePrice = 100000;
        public double AdditionalCost { get; set; }
        public abstract void BuildHome();

        public virtual double GetPrice()
        {
            return basePrice + AdditionalCost;
        }
    }
    class BasicHome : Home
    {
        public BasicHome()
        {
            AdditionalCost = 0;
        }

        public override void BuildHome()
        {
            Console.WriteLine("A home with basic facilities is made.");
            Console.WriteLine($"It costs ${GetPrice()}.");
        }
    }
    class AdvancedHome : Home
    {
        public AdvancedHome()
        {
            AdditionalCost = 25000;
        }

        public override void BuildHome()
        {
            Console.WriteLine("A home with advanced facilities is made.");
            Console.WriteLine($"It costs ${GetPrice()}.");
        }
    }
    abstract class Luxury : Home
    {
        protected Home home;
        public double LuxuryCost { get; set; }
        public Luxury(Home home)
        {
            this.home = home;
        }
        public override void BuildHome()
        {
            home.BuildHome();
        }

        public override double GetPrice()
        {
            return home.GetPrice() + LuxuryCost;
        }
    }
    class PlayGround : Luxury
    {
        public PlayGround(Home home) : base(home)
        {
            this.LuxuryCost = 20000;
        }
        public override void BuildHome()
        {
            base.BuildHome();
            AddPlayGround();
        }
        private void AddPlayGround()
        {
            Console.WriteLine($"For a playground, you pay anextra ${this.LuxuryCost}.");
            Console.WriteLine($"Now the total cost is ${GetPrice()}.");
        }

    }
    class SwimmingPool : Luxury
    {
        public SwimmingPool(Home home) : base(home)
        {
            this.LuxuryCost = 55000;
        }
        public override void BuildHome()
        {
            base.BuildHome();
            AddSwimmingPool();
        }
        private void AddSwimmingPool()
        {
            Console.WriteLine($"For a swimming pool, you pay an extra ${this.LuxuryCost}.");
            Console.WriteLine($"Now the total cost is ${GetPrice()}.");
        }
    }
    #endregion

    #region decorator1
    public abstract class Notifier
    {
        public abstract void Send();
    }

    public class EmailNotifier : Notifier
    {
        public override void Send()
        {
            Console.WriteLine("EmailSender");
        }
    }

    public abstract class Decorator : Notifier
    {
        protected Notifier notify;

        public Decorator(Notifier notify)
        {
            this.notify = notify;
        }

        public void SetNotifier(Notifier notifier)
        {
            this.notify = notifier;
        }

        public override void Send()
        {
            if (this.notify != null)
            {
                this.notify.Send();
            }
        }

    }

    public class PhoneNotifier : Decorator
    {
        public PhoneNotifier(Notifier notify) : base(notify)
        {
        }

        public override void Send()
        {
            Console.WriteLine("Phone call");
            base.Send();
        }
    }

    public class SmsNotifier : Decorator
    {
        public SmsNotifier(Notifier notify) : base(notify)
        {
        }

        public override void Send()
        {
            Console.WriteLine("SmS");
            base.Send();
        }
    }

    public class Clinet
    {
        public void ClinetUsage(Notifier notifier)
        {
            Console.WriteLine(" using:");
            notifier.Send();
        }
    }
    #endregion

    public class M
    {
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        static void Main()
        {
            var xx = CodeWars_HighestScoringRecord.High("aaaaaa bbb c");

            var solv = CodeWars_NextBiggerNumber.NextBiggerNumber(531);

            CodeWars_BooleanOrder.BooleanOrder order = new CodeWars_BooleanOrder.BooleanOrder("ttftff", "|&^&&");
            var x = order.Solve();

            Clinet clinet = new Clinet();

            var start = new EmailNotifier();

            clinet.ClinetUsage(start);

            var notifier1 = new PhoneNotifier(start);
            var notifier2 = new SmsNotifier(notifier1);

            clinet.ClinetUsage(notifier2);


            //Vehicle vehicle = new Car("123");
            //vehicle.SetBehavior(new FloatingBehavior());
            //vehicle.Act();
            //vehicle.SetBehavior(new MovableBehavior());
            //vehicle.Act();


            var driver = new Driver();

            var car = new Auto();
            var fish = new Fish();

            var adapter = new AnimalToCarAdapter(fish);

            driver.Travel(car);
            driver.Travel(adapter);

        }
    }

    interface ITransport
    {
        void Drive();
    }

    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Машина едет по дороге");
        }
    }

    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }

    interface IAnimal
    {
        public void Move();
    }
    class Fish : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("I can dive");
        }
    }

    class AnimalToCarAdapter : ITransport
    {
        private readonly IAnimal animal;

        public AnimalToCarAdapter(IAnimal animal)
        {
            this.animal = animal;
        }

        public void Drive()
        {
            animal.Move();
        }
    }
}
