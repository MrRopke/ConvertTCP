using System;

namespace ConvertComponent
{
    public class ConvertCompo
    {
        public double GramToOunces(double gram)
        {
            //m(oz) = m(g) / 28.3495231
            return gram / 28.3495231;
        }

        public double OuncesToGram(double ounces)
        {
            //m(g) = m(oz) × 28.3495231
            return ounces * 28.3495231;
        }

    }
}
