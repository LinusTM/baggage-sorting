namespace baggage_sorting;
internal class Program {
    static void Main(string[] args) {
        Baggage bag = new Baggage("AMS");

        Counter klm = new KLM();
        klm.baggageBuffer.Enqueue(bag);

        Console.WriteLine(klm.baggageBuffer.Count());
    }
}
