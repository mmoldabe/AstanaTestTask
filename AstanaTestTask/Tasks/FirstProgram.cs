using System;

namespace AstanaTestTask.Tasks {
    public class FirstProgram : IProgram {
        public void Run() {
            Console.WriteLine("\nЗадача №1:\n");

            for (var i = 1; i <= 100; ++i) Console.WriteLine(i.Mod());
        }
    }

    public static partial class Extensions {
        public static string Mod(this int i) {
            var result = "";

            if (i % 3 == 0 && i % 5 == 0) {
                result = "AgroStream";

                return result;
            }

            if (i % 3 == 0) {
                result = "Agro";

                return result;
            }

            if (i % 5 == 0) {
                result = "Stream";

                return result;
            }

            result = i.ToString();

            return result;
        }
    }
}