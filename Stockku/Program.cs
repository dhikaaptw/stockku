using System;

class Program
{
    static BarangList daftarBarang = new BarangList();
    static PermintaanQueue antrian = new PermintaanQueue();
    static RiwayatStack riwayat = new RiwayatStack();

    static void Main()
    {
        while (true)
        {
            Console.Write("\nPerintah (add-item, add-request, process, undo, show, exit): ");
            string input = Console.ReadLine()?.Trim().ToLower();

            switch (input)
            {
                case "add-item": TambahBarang(); break;
                case "add-request": TambahPermintaan(); break;
                case "process": ProsesPermintaan(); break;
                case "undo": UndoProses(); break;
                case "show": ShowAll(); break;
                case "exit": return;
                default: Console.WriteLine("Perintah tidak dikenal."); break;
            }
        }
    }

    static void TambahBarang()
    {
        Console.Write("Nama barang: ");
        string nama = Console.ReadLine();
        Console.Write("Stok awal: ");
        if (int.TryParse(Console.ReadLine(), out int stok))
        {
            BarangNode existing = daftarBarang.Find(nama);
            if (existing != null)
            {
                existing.Stok += stok;
                Console.WriteLine("Stok barang diperbarui.");
            }
            else
            {
                daftarBarang.AddLast(new BarangNode(nama, stok));
                Console.WriteLine("Barang berhasil ditambahkan.");
            }
        }
        else Console.WriteLine("Input stok tidak valid.");
    }

    static void TambahPermintaan()
    {
        Console.Write("Nama barang: ");
        string nama = Console.ReadLine();
        Console.Write("Jumlah permintaan: ");
        if (int.TryParse(Console.ReadLine(), out int jumlah))
        {
            antrian.Enqueue(new PermintaanNode(nama, jumlah));
            Console.WriteLine("Permintaan berhasil ditambahkan ke antrian.");
        }
        else Console.WriteLine("Input jumlah tidak valid.");
    }

    static void ProsesPermintaan()
    {
        PermintaanNode req = antrian.Dequeue();
        if (req == null)
        {
            Console.WriteLine("Tidak ada permintaan.");
            return;
        }

        BarangNode barang = daftarBarang.Find(req.NamaBarang);
        if (barang == null || barang.Stok < req.Jumlah)
        {
            Console.WriteLine("Stok tidak mencukupi atau barang tidak ditemukan.");
            return;
        }

        barang.Stok -= req.Jumlah;
        riwayat.Push(new RiwayatNode(req.NamaBarang, req.Jumlah));
        Console.WriteLine($"Diproses: {req.NamaBarang} sebanyak {req.Jumlah} pcs");
    }

    static void UndoProses()
    {
        RiwayatNode undo = riwayat.Pop();
        if (undo == null)
        {
            Console.WriteLine("Tidak ada yang bisa di-undo.");
            return;
        }

        BarangNode barang = daftarBarang.Find(undo.NamaBarang);
        if (barang != null)
        {
            barang.Stok += undo.Jumlah;
            Console.WriteLine($"Undo berhasil: {undo.NamaBarang} dikembalikan {undo.Jumlah} pcs");
        }
        else
        {
            daftarBarang.AddLast(new BarangNode(undo.NamaBarang, undo.Jumlah));
            Console.WriteLine($"Undo berhasil: {undo.NamaBarang} ditambahkan kembali");
        }
    }

    static void ShowAll()
    {
        Console.WriteLine("\n== Barang ==");
        daftarBarang.PrintAll();
        Console.WriteLine("\n== Antrian Permintaan ==");
        antrian.PrintAll();
        Console.WriteLine("\n== Riwayat Pengeluaran ==");
        riwayat.PrintAll();
    }
}