
//using System.Reflection.Metadata.Ecma335;

double a = 1488.994;
int x;
x = (int)a;
long y = x;

Console.WriteLine($"Implicit conversion of double {a} to int is {x}");
Console.WriteLine($"Explicit conversion of int  {x} to long is {y}");


Car ferrari = new Car();
ferrari.Model = "ferrari";
ferrari.Move();

Car bmw = new Car("X5","RED");
Console.WriteLine($"The car {bmw.Model} has {bmw.Color} color");

Car lamborgini = new Car("lambo", "red", 5.5);
lamborgini.RefillGas(4.2);

MotoBike suzuki = new MotoBike("b54", "black", 4.56);
suzuki.Model = lamborgini.Model;
suzuki.MaxSpeed = 5;
suzuki.Move();
Console.WriteLine(suzuki.Model);

AirCraft jet = new AirCraft("F-16");
Console.WriteLine($"Aircraft model is {jet.Model}");
jet.Model = "F-35";
jet.RefillGas(666);
jet.Move();
Console.WriteLine($"Aircraft model is {jet.Model}");

Vehicle Amphibian = new Vehicle("APC");
Amphibian.Move();
Vehicle AEWC = new AirCraft("Mainstay");

AEWC = Amphibian;
Console.WriteLine($"AEWC model is {AEWC.Model}"); // Implicit conversion, now AEWC bahaves like a base Vehicle

MotoBike Kawasaki = new MotoBike("Ninja 650");
Vehicle Audi = new Car("AudiTT");
Audi = (Vehicle)Kawasaki;
Audi.Move();
Console.WriteLine($"Audi model is {Audi.Model}");//   Explicit conversion, now Audi behaves like a MotoBike 


Console.ReadKey();


public interface IMovable 
{
    public void Move();
}



class Vehicle:IMovable
{
    protected internal string Model = "";
    protected internal string Color = "";

    private double baseTankVolume=5;
    protected internal double TankVolume
    {
        get { return baseTankVolume; }
        set
        {
            if (value > 0)
                baseTankVolume = value;
        }

    }
    private int maxSpeed;
    protected internal int MaxSpeed
    { get { return maxSpeed; }
      set
        { if (value > 0)
                maxSpeed = value; }


    }
    public Vehicle() { }
    public Vehicle(string model) {  Model = model; }
    public Vehicle(string model, string color) { Model = model; Color = color; }
    public Vehicle(string model, string color, double tank_volume) { Model = model; Color = color; TankVolume = tank_volume; }
    protected internal virtual void RefillGas(double liters)
    {
        
            if (liters <= 0) liters = 0;
            else if (liters >= TankVolume) liters = TankVolume;

            Console.WriteLine($"You refilled tank with {liters} liters ");
        
    }

    public virtual void Move()
    { Console.WriteLine("Moves somehow"); }


}

 class Car : Vehicle,IMovable
{
   
    public Car()
    { Console.WriteLine("The Car was created!"); }

    public Car(string model) : base(model) { }
    public Car(string model, string color) : base(model, color) { }/*{ Model = model; Color = color; }*/
    public Car(string model, string color, double tank_volume) : base(model, color, tank_volume) { }

    public override void Move()
    {
        Console.WriteLine("The Car is driving with 4 weels on the ground");
    }
 
   
}

class MotoBike : Vehicle, IMovable
{
    public MotoBike() 
    { Console.WriteLine("The MotoBike was created!"); }
    public MotoBike(string model) { Model = model; }
    public MotoBike(string model, string color) : base(model, color) { }
    public MotoBike(string model, string color, double tank_volume) : base(model, color, tank_volume) { }
    public override void Move()
    {
        Console.WriteLine("The MotoBike is driving with 2 weels on the ground");
    }
    
}
class AirCraft : Vehicle, IMovable
{
    public AirCraft()
    { Console.WriteLine("The AirCraft was created!"); }

    public AirCraft(string model) : base(model) { }
    public AirCraft(string model, string color, double tank_volume) : base(model, color, tank_volume) { }
    public override void Move()
    {
        Console.WriteLine("The AirCraft is flying with wings in the air");
    }
}

class Ship : Vehicle, IMovable
{
    public Ship()
    { Console.WriteLine("The Ship was created!"); }
    public Ship(string model, string color) : base(model, color) { }
    public override void Move()
    {
        Console.WriteLine("The Ship is sailing in the water");
    }
}
