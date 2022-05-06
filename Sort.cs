using System.Diagnostics;

namespace baggage_sorting;
internal class Sort {
    internal Queue<Baggage> bagIn = new Queue<Baggage>();
    internal Queue<Baggage> bagOut = new Queue<Baggage>();
    
    internal Sort(Queue<Baggage> bagIn, Queue<Baggage> bagOut) {
        this.bagIn = bagIn;
        this.bagOut = bagOut;
    }

    internal void sortBaggage() {
        Baggage currentBag = new Baggage();

        while(true) {
            while(bagIn.Count == 0) {
                Thread.Sleep(100/15);
                Monitor.Wait(bagIn);
            }
            
            Monitor.Enter(bagIn);
            try {
                Monitor.Enter(bagOut);
                try {
                    bagOut.Enqueue(currentBag);
                    Debug.WriteLine($"SORTER: Moved baggage from {currentBag.Destination}");

                    Monitor.PulseAll(bagOut);
                }
                finally {
                    Monitor.Exit(bagOut);
                }
            }
            finally {
                Monitor.Exit(bagIn);
            }
        }
    }
}
