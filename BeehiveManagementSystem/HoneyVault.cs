using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    static class HoneyVault
    {
        public const float NECTAR_CONVERSION_RATIO = .19f;
        public const float LOW_LEVEL_WARNING = 10f;

        private static float honey = 25f;
        private static float nectar = 100f;

        public static void CollectNectar(float amount)
        {
            if (amount > 0)
                nectar += amount;
        }

        public static void ConvertNectarToHoney(float amount)
        {
            if (amount > nectar)
                amount = nectar;
            nectar -= amount;
            honey += amount * NECTAR_CONVERSION_RATIO;
        }

        public static bool ConsumeHoney(float amount)
        {
            if(honey >= amount)
            {
                honey -= amount;
                return true;
            }
            return false;
        }

        public static string StatusReport
        {
            get
            {
                return $"{PrintHoney()}\n{PrintNectar()}";
            }
        }

        static string PrintHoney()
        {
            if (honey < LOW_LEVEL_WARNING)
                return "LOW HONEY - ADD A HONEY MANUFACTURER";
            return honey.ToString();
        }

        static string PrintNectar()
        {
            if (nectar < LOW_LEVEL_WARNING)
                return "LOW NECTAR - ADD A NECTAR MANUFACTURER";
            return nectar.ToString();
        }
    }
}
