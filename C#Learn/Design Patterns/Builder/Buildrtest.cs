using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Builder
{
    public class Buildrtest
    {

        public void DO()
        {
            Car car = new CarBuilder().
            setWheels(6)
           .setEngine("V8")
           .setSeats(2)
           .build();
            car.show();
        }
    }


    class Car
    {
        private int wheels;
        private String engine;
        private int seats;

        public Car(int wheels, String engine, int seats)
        {
            this.wheels = wheels;
            this.engine = engine;
            this.seats = seats;
        }
        public void show()
        {
            Console.WriteLine("Car with " + wheels + " wheels, " + engine + "engine, " + seats + " seats");
        }
    }



    class CarBuilder
    {
        private int wheels = 4;
        private String engine = "V6";
        private int seats = 4;

        public CarBuilder setWheels(int wheels)
        {
            this.wheels = wheels;
            return this;
        }
        public CarBuilder setEngine(String engine)
        {
            this.engine = engine;
            return this;
        }
        public CarBuilder setSeats(int seats)
        {
            this.seats = seats;
            return this;
        }
        public Car build()
        {
            return new Car(wheels, engine, seats);
        }
    }
}
