using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Factory
{
    public class Factorytest
    {
       public void DO()
        {
            IWeapon rifle = new Rifle();
            IWeapon sniper = new sniper();
            IWeapon shootgun = new shootgun();

            factory fac = new factory(sniper);
        }
    }


    class factory
    {
       public factory(IWeapon weabon)
        {
            weabon.shoot();       
        }
    }

    interface IWeapon
    {
        void shoot();
    }
    class Rifle: IWeapon
    {
        public void shoot()
        {
            Console.WriteLine("Rifle shooting");
        }
    }

    class sniper:IWeapon
    {
        public void shoot()
        {
            Console.WriteLine("sniper shooting");
        }
    }

    class shootgun:IWeapon
    {
        public void shoot()
        {
            Console.WriteLine("shootgun shooting");
        }
    }
}
