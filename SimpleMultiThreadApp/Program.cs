using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SimpleMultiThreadApp
{
    class Printer
    {
        public void PrintNumbers()
        {
            // Вывести информацию о потоке.
            Console.WriteLine("-> {0} is.executing PrintNumbers()",
            Thread.CurrentThread.Name);
            // Вывести числа.
            Console.Write("Your numbers: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0}, ", i);
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** BackgroundThreads *****\n");
            Printer p = new Printer();
            Thread bgroundThread =
            new Thread(new ThreadStart(p.PrintNumbers));

            // Теперь это фоновый поток.
            bgroundThread.IsBackground = true;
            bgroundThread.Start();

            /*  Обратите внимание, что в этом методе Main() не производится вызов Console.
                ReadLine (), чтобы оставить окно консоли видимым, пока не будет нажата клавиша
                <Enter>. Таким образом, после запуска приложение прекращается немедленно, потому
                что объект Thread сконфигурирован как фоновый поток. Учитывая, что метод Main ()
                инициирует создание первичного потока переднего плана, как только логика метода
                Main () завершится, домен приложения будет выгружен, прежде чем вторичный поток
                сможет закончить свою работу.
                Однако если закомментировать строку, которая устанавливает в true свойство
                IsBackground, обнаружится, что все числа выводятся на консоль, т.к. все потоки пе¬
                реднего плана должны завершить свою работу перед тем, как домен приложения будет
                выгружен из размещающего процесса.
            */
        }
    }
}
