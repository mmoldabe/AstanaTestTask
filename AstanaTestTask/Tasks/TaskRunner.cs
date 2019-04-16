using System;
using System.Collections.Generic;

namespace AstanaTestTask.Tasks {
    public static class TaskRunner {
        public static void Run() {
            var tasks = new List<IProgram> {new FirstProgram(), new SecondProgram()};

            for (;;) {
                var breakLoop = false;

                Console.Write("\nВведите номер задачи (1, 2). 0 - для выхода: ");
                var consoleInput = Console.ReadLine();

                if (int.TryParse(consoleInput, out var input)) {
                    switch (input) {
                        case 0:
                            breakLoop = true;
                            break;
                        case 1:
                            tasks[0].Run();
                            break;
                        case 2:
                            tasks[1].Run();
                            break;
                        default:
                            Console.WriteLine("Введите корректное число (0, 1 или 2).");
                            break;
                    }

                    if (breakLoop) break;
                }
                else {
                    Console.WriteLine("Введите корректное число (0, 1 или 2).");
                }
            }
        }
    }
}