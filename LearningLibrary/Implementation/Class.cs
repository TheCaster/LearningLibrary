using LearningLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningLibrary.Implementation
{
    public class Class : TaskClass, IClass
    {            
        /// <summary>
        /// Ruft zwei Tasks auf und startet diese, wartet aber bis beide beendet sind.
        /// </summary>
        public void DoParallel()
        {
            // Parallelisierung mit Tasks
            var t1 = Write("A");
            var t2 = Write("B");

            // "Echte" Parallele Ausführung     
            Task.WaitAll(t1, t2);
        }

        /// <summary>
        /// Ruft die Tasks nacheinander auf und erwartet das Ergebnis. Synchrone Ausführung!
        /// </summary>
        public void DoWait()
        {
            // Task wird aufgerufen und gestartet. 
            Write("A").Wait();
            Write("B").Wait();            
        }

        /// <summary>
        /// Dieser Task ruft beide Write-Tasks auf. Jedoch geben die Tasks KEINE Werte zurück. 
        /// Das heißt das Ergebnis wird für keinen anderen Task benötigt, weshalb nach der ersten Ausführung 
        /// Der Returnwert bereits zurück gegeben wird.  
        /// Achtung! Hier gibt es die Gefahr für DeadLocks, vor allem wenn die Tasks auf einen geteilten Wert zugreifen. 
        /// </summary>
        /// <returns></returns>        
        public async Task<int> DontWait()
        {
            await WriteAsync("A");
            await WriteAsync("B");
            return await Task.FromResult(0);
        }

        /// <summary>
        /// Dieser Task ruft beide Write-Tasks auf. Die Tasks geben Werte zurück. 
        /// Das Ergebnis wird jedoch nicht verwendet, weshalb der Task ausgeführt wird nachdem die return Werte bereits zurückgegeben wurden.
        /// Achtung! Auch hier gibt es Gefahr für DeadLocks. Geteilte werte sollten über einen Mutex besitzen oder als volatile 
        /// gekenntzeichnet sein.
        /// </summary>
        /// <returns></returns>
        public async Task<int> DontWaitWithResult()
        {
            Console.Write("T8");
            var count1 = await WriteWithResultAsync("A");
            var count2 = await WriteWithResultAsync("B");
            return 0;
        }

        /// <summary>
        /// Dieser Task ruft beide Write-Tasks auf. Die Tasks geben Werte zurück. 
        /// Das Ergebnis wird verwendet, weshalb beide Tasks parallel ausgeführt werden. Durch die Nötigkeit des Ergebnis, 
        /// wird der Returnwert beim erwarten des Tasks nach Ausführung angegeben. Achtung! Wird auf diesen Task nicht gewartet
        /// oder seine Rückgabe verwendet, verlagert sich das Problem lediglich um eine Ebene höher.
        /// </summary>
        /// <returns></returns>
        public async Task<int> WaitForResult()
        {
            Console.Write("T9");
            var count1 = await WriteWithResultAsync("A");
            var count2 = await WriteWithResultAsync("B");
            return count1 + count2;
        }
    }
}
