using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportBedrijf
{
    class Program
    {
        static void Main(string[] args)
        {
            double toeslagBuitenland = 1.45;
            double douaneKostenPer = 0.035;
            double douaneKostenMin = 45;

            double nVolumePrijs = 0.80;     // volume in m^3
            double nGewichtPrijs = 0.55;    // gewicht in kg, absurd duur, mischien zou het prijs per ton moeten zijn?
            double vVolumePrijs = 1.25;
            double vGewichtPrijs = 0.45;

            double nVolume, nGewicht, vVolume, vGewicht, waarde, nederlandKM, buitenlandKM, ritKosten, douaneKosten;

            Console.WriteLine("m^3 niet-vloeibare lading:");
            nVolume = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("kg niet-vloeibare lading:");
            nGewicht = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("m^3 vloeibare lading:");
            vVolume = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("kg vloeibare lading:");
            vGewicht = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Waarde lading:");
            waarde = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("In Nederland gereden kilometers:");
            nederlandKM = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("In het buitenland gereden kilometers:");
            buitenlandKM = Convert.ToDouble(Console.ReadLine());

            ritKosten = (nVolume * nVolumePrijs + nGewicht * nGewichtPrijs + vVolume * vVolumePrijs + vGewicht * vGewichtPrijs) * nederlandKM;

            ritKosten += (nVolume * nVolumePrijs + nGewicht * nGewichtPrijs + vVolume * vVolumePrijs + vGewicht * vGewichtPrijs) * buitenlandKM * toeslagBuitenland;

            if(buitenlandKM > 0)
            {
                douaneKosten = waarde * douaneKostenPer;

                if (douaneKosten < douaneKostenMin)
                    douaneKosten = douaneKostenMin;

                ritKosten += douaneKosten;
            }

            Console.WriteLine("De ritprijs is {0:0.00}euro", ritKosten);

            Console.ReadLine();
        }
    }
}
