class RiwayatNode
{
    public string NamaBarang;
    public int Jumlah;
    public RiwayatNode Next;

    public RiwayatNode(string namaBarang, int jumlah)
    {
        NamaBarang = namaBarang;
        Jumlah = jumlah;
        Next = null;
    }
}

class RiwayatStack
{
    private RiwayatNode top;

    public void Push(RiwayatNode node)
    {
        node.Next = top;
        top = node;
    }

    public RiwayatNode Pop()
    {
        if (top == null) return null;
        RiwayatNode temp = top;
        top = top.Next;
        return temp;
    }

    public void PrintAll()
    {
        RiwayatNode current = top;
        while (current != null)
        {
            Console.WriteLine($"{current.NamaBarang}: {current.Jumlah} pcs");
            current = current.Next;
        }
    }
}
