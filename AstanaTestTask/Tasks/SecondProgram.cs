using System;
using System.Collections.Generic;
using System.Linq;

namespace AstanaTestTask.Tasks {
    public class SecondProgram : IProgram {
        private readonly List<int> _digits = new List<int>();
        private int _amount;
        private string[] _strDigits;

        public void Run() {
            Console.WriteLine("\nЗадача №2:\n");


            for (;;) {
                Console.Write("Введите количество температур для анализа: ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out var amount)) {
                    if (amount <= 0) {
                        Console.WriteLine("\nВведите корректное число.");
                    }
                    else {
                        _amount = amount;

                        InputData();

                        Console.WriteLine("Температура, ближайшая к нулю: {0}", _digits.FindTemperatureLinq());
                        _digits.Clear();
                        break;
                    }
                }
                else {
                    Console.WriteLine("\nВведите корректное число.");
                }
            }
        }

        private void InputData() {
            for (;;) {
                Console.Write("\nВведите значения {0} температур через пробел: ", _amount);
                var input = Console.ReadLine();
                _strDigits = input?.Split(' ');


                if (_strDigits != null && _strDigits.Length == _amount) {
                    foreach (var strDigit in _strDigits)
                        if (int.TryParse(strDigit, out var digit))
                            _digits.Add(digit);

                    if (_digits.Count == _amount && CheckRange(_digits)) break;
                }

                _digits.Clear();
                Console.WriteLine("Введены некорректные данные.");
            }
        }

        private bool CheckRange(List<int> digits) {
            var check = true;

            foreach (var digit in _digits)
                if (digit < -273 && digit > 5526) {
                    check = false;
                    break;
                }

            return check;
        }
    }

    public static partial class Extensions {
        /// <summary>
        ///     Как вариант, но итерации столько же
        /// </summary>
        public static int FindTemperature(this List<int> digits) {
            var closest = int.MaxValue;
            var minDifference = int.MaxValue;

            var number = 0.01;
            foreach (var digit in digits) {
                var diff = Math.Abs(number - digit);
                if (minDifference >= diff) {
                    minDifference = (int) diff;
                    closest = digit;
                }
            }

            //вариант решения для цифр с точкой
            /*if (closest < 0)
                foreach (var digit in digits)
                    if (digit == closest * -1) {
                        closest = digit;
                        break;
                    }*/

            return closest;
        }

        /// <summary>
        ///     Оптимальное решение
        /// </summary>
        /// <param name="digits">Array of integers~</param>
        /// <returns>Temperature closest to 0</returns>
        public static int FindTemperatureLinq(this List<int> digits) {
            var closest = digits.OrderBy(digit => Math.Abs(0.01 - digit)).First();

            return closest;
        }
    }
}