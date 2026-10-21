//game
//genre : fighting
//Karakter : nama, kesehatan

using System;

namespace KerangkaGame
{
    class Karakter
    {
        public int totalsenjata, power;

        //enkapsulasi 
        public string nama { get; private set; }
        public int kesehatan { get; private set; }
        public int senjata { get; private set; }
        public int posisiSaatIni { get; private set; }

        //membuat konstruktor
        public Karakter(string nama, int kesehatan, int senjata)
        {
            this.nama = nama;
            this.kesehatan = kesehatan;
            this.senjata = senjata;
            this.posisiSaatIni = 0; // Posisi awal otomatis mulai dari 0
        }

        public void Serang(Karakter target)
        {
            Console.WriteLine("==> Mulai Serangan");
            target.TerimaSerangan(this.senjata);
        }

        public void TerimaSerangan(int jumlahSerangan)
        {
            kesehatan -= jumlahSerangan;
            Console.WriteLine($"{nama} diserang dengan {jumlahSerangan} . Sisa Kesehatan {kesehatan}");
        }

        public void HealDarah(int healing)
        {
            kesehatan += healing;
            Console.WriteLine($"{nama} Healing Sebanyak {healing} . Kesehatan Sekarang : {kesehatan}");
        }

        // Method Aksi untuk memproses perpindahan posisi
        public void Aksi(int posisiBaru)
        {

            if (posisiBaru < 0)
            {
                posisiBaru = 0;
            }

            int posisiAwal = this.posisiSaatIni;
            this.posisiSaatIni = posisiBaru;
            int jarak = (posisiBaru - posisiAwal);
            Console.WriteLine($"{nama} berpindah dari posisi {posisiAwal} ke posisi {posisiBaru} (Berpindah {jarak} langkah).");
        }

        public void getData()
        {
            Console.WriteLine($"Karakter : {nama}");
            Console.WriteLine($"Kesehatan : {kesehatan}");
            Console.WriteLine($"senjata : {senjata}");
            Console.WriteLine($"Posisi Sekarang : {posisiSaatIni}");
        }

        public void CekStatus()
        {
            if (kesehatan > 0)
            {
                Console.WriteLine($"{nama} masih hidup | Kesehatan: {kesehatan}");

                string pilihan = "";

                while (pilihan != "y" && pilihan != "n")
                {
                    Console.Write("Apakah ingin menyelamatkan Karakter ini? (y/n): ");
                    pilihan = Console.ReadLine()?.ToLower().Trim();

                    if (pilihan != "y" && pilihan != "n")
                    {
                        Console.WriteLine("Input salah! Harap masukkan hanya 'y' atau 'n'.");
                    }
                }

                if (pilihan == "y")
                {
                    HealDarah(20);
                }
                else
                {
                    Console.WriteLine($"{nama} tidak diselamatkan.");
                }
            }
            else
            {
                Console.WriteLine($"{nama} sudah mati!");
            }
        }
    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            Karakter player1 = new Karakter("Fahri", 100, 10);
            Karakter Musuh = new Karakter("Radit", 100, 100);

            player1.getData();

            Console.WriteLine("\n--- DENGAN INTERAKSI ---");
            Musuh.Serang(player1);
            player1.HealDarah(10);

            // Menerima input posisi dari pengguna (Kode awal kamu)
            Console.Write("Masukkan posisi tujuan " + player1.nama + ": ");
            int posisiTujuan = Convert.ToInt32(Console.ReadLine());
            player1.Aksi(posisiTujuan);

            Console.WriteLine();
            player1.CekStatus();
            Console.WriteLine();
            player1.getData();
            while (true)
            {
                ConsoleKeyInfo tombol = Console.ReadKey(true);

                if (tombol.Key == ConsoleKey.RightArrow)
                {
                    player1.Aksi(player1.posisiSaatIni + 2);
                }
                else if (tombol.Key == ConsoleKey.LeftArrow)
                {
                    player1.Aksi(player1.posisiSaatIni - 1);
                }
                else if (tombol.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\npermainan berakhir");
                    break;
                }
            }
        }
    }
}
