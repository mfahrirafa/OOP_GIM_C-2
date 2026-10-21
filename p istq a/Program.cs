using System;

namespace KerangkaGame
{
    class Karakter
    {
        public string nama { get; private set; }
        public int kesehatan { get; private set; }
        public int senjata { get; private set; }

        public Karakter(string nama, int kesehatan, int senjata)
        {
            this.nama = nama;
            this.kesehatan = kesehatan;
            this.senjata = senjata;
        }

        public void Serang(Karakter target)
        {
            Console.WriteLine("Mulai Serangan");
            target.TerimaSerangan(senjata);
        }

        public void TerimaSerangan(int jumlah)
        {
            kesehatan -= jumlah;
            Console.WriteLine($"{nama} diserang. Sisa HP: {kesehatan}");
        }

        public void Healing(int jumlah)
        {
            kesehatan += jumlah;
            Console.WriteLine($"{nama} healing {jumlah}. HP: {kesehatan}");
        }
    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            Karakter player1 = new Karakter("Fahri", 100, 10);
            Karakter musuh = new Karakter("keki rabies", 100, 70);

            player1.Serang(musuh);
            musuh.Serang(player1);

            if (player1.kesehatan > 0)
            {
                Console.WriteLine("Mau di-heal? (ya/tidak)");
                string pilihan = Console.ReadLine();

                if (pilihan == "ya")
                    player1.Healing(20);
                else if (pilihan == "tidak")
                    Console.WriteLine("Tidak di-heal");
                else
                    Console.WriteLine("Pilihan tidak tersedia");
            }
        }
    }
}
