using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningLibrary.Interfaces
{
    public interface IClass: IDisposable
    {
        // Diese Funktion ruft zwei Tasks auf, und erwaret das Ergebnis.         
        void DoParallel();

        // Diese Funktion ruft zwei Tasks auf, und erwaret das Ergebnis. 
        // Es entspricht einem normalen Funktionsaufruf
        void DoWait();

        // Dieser Task ruft beide Write-Tasks auf. Jedoch geben die Tasks KEINE Werte zurück. 
        // Das heißt das Ergebnis wird für keinen anderen Task benötigt, weshalb nach der ersten Ausführung 
        // Der Returnwert bereits zurück gegeben wird. 
        Task<int> DontWait();

        // Dieser Task ruft beide Write-Tasks auf. Die Tasks geben Werte zurück. 
        // Das Ergebnis wird jedoch nicht verwendet, weshalb nach der ersten Ausführung 
        // Der Returnwert bereits zurück gegeben wird. 
        Task<int> DontWaitWithResult();

        // Dieser Task ruft beide Write-Tasks auf. Die Tasks geben Werte zurück. 
        // Das Ergebnis wird verwendet, weshalb beide Tasks parallel ausgeführt werden. Die Parallellität hängt jedoch auch vom 
        // Compiler ab, der die Lasten "sinnvoll" zu verteilen versucht. Zu beachten ist, dass vorherige Tasks NICHT automatisch abgeschlossen 
        // werden
        Task<int> WaitForResult();
    }
}
