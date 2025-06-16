class BarangNode
{
    public string Nama;
    public int Stok;
    public BarangNode Next;

    public BarangNode(string nama, int stok)
    {
        Nama = nama;
        Stok = stok;
        Next = null;
    }
}

class BarangList
{
    private BarangNode head;

    public void AddLast(BarangNode node)
    {
        if (head == null) head = node;
        else
        {
            BarangNode current = head;
            while (current.Next != null) current = current.Next;
            current.Next = node;
        }
    }

    public BarangNode Find(string nama)
    {
        BarangNode current = head;
        while (current != null)
        {
            if (current.Nama == nama) return current;
            current = current.Next;
        }
        return null;
    }

    public void PrintAll()
    {
        BarangNode current = head;
        while (current != null)
        {
            Console.WriteLine($"{current.Nama}: {current.Stok} pcs");
            current = current.Next;
        }
    }
}
