class PermintaanNode
{
    public string NamaBarang;
    public int Jumlah;
    public PermintaanNode Next;

    public PermintaanNode(string namaBarang, int jumlah)
    {
        NamaBarang = namaBarang;
        Jumlah = jumlah;
        Next = null;
    }
}

class PermintaanQueue
{
    private PermintaanNode head, tail;

    public void Enqueue(PermintaanNode node)
    {
        if (tail == null)
        {
            head = tail = node;
        }
        else
        {
            tail.Next = node;
            tail = node;
        }
    }

    public PermintaanNode Dequeue()
    {
        if (head == null) return null;
        PermintaanNode temp = head;
        head = head.Next;
        if (head == null) tail = null;
        return temp;
    }

    public void PrintAll()
    {
        PermintaanNode current = head;
        while (current != null)
        {
            Console.WriteLine($"{current.NamaBarang}: {current.Jumlah} pcs");
            current = current.Next;
        }
    }
}
