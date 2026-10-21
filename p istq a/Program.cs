//16/09/26

using System;
using System.Collections.Generic;

namespace KerangkaGame
{
    class Karakter
    {
        public int totalSenjata, kekuatan;

        //enskapsulasi
        public string nama { get; private set; }
        public int kesehatan { get; private set; }
        public int senjata { get; private set; }

        public int heal { get; private set; }
        public int posisi;

        public Karakter(string nama, int kesehatan, int senjata, int heal, int posisi) //Membuat constructor
        {
            this.nama = nama;
            this.kesehatan = kesehatan;
            this.senjata = senjata;
            this.heal = heal;
            this.posisi = posisi;
        }

        public void Serang(Karakter target)
        {
            Console.WriteLine($"==> Mulai serangan oleh {nama}");
            target.TerimaSerangan(this.senjata);
        }

        public void TerimaSerangan(int jumlahSerangan)
        {
            kesehatan -= jumlahSerangan;
            Console.WriteLine($"{nama}, Diserang dengan {jumlahSerangan}," +
                $" Sisa kesehatan {kesehatan}");
        }

        public void Healing(int heal)
        {
            kesehatan += heal;
            if (kesehatan < 0)
            {
                Console.WriteLine(kesehatan += heal);
            }
            else if (kesehatan <= 0)
            {
                Console.WriteLine($"{nama} telah mati");
            }
            else
            {

                Console.WriteLine($"{nama} telah disembuhkan sebanyak {heal}");
            }
        }
        public void getData()
        {
            Console.WriteLine($"Karakter: {nama}, KesehatanMu: {kesehatan}, Senjata: {senjata}, Posisi saat ini: {posisi} ");
        }
        public void ubahPosisiAngka()
        {
            while (true)
            {
                Console.WriteLine("Masukkan posisi karakter: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int posisiBaru))
                {
                    Console.WriteLine("Input harus berupa angka!");
                    continue;
                }


                posisi = posisiBaru;

                Console.WriteLine($"{nama} berpindah ke posisi {posisi}");
                Console.WriteLine($"posisi saat ini: {posisi}");
                Console.WriteLine("Tekan ESC untuk berhenti, atau Enter untuk lanjut.");

                ConsoleKeyInfo tombol = Console.ReadKey(true);

                if (tombol.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Permainan berhenti");
                    break;
                }
            }
        }
        public void ubahPosisiTombol()
        {
            Console.WriteLine("Tekan Panah Kanan untuk maju 2 posisi");
            Console.WriteLine("Tekan Panah Kiri untuk mundur 1 posisi");
            Console.WriteLine("Tekan ESC untuk berhenti");
            Console.WriteLine($"Posisi awal {nama}: {posisi}");

            while (true)
            {
                ConsoleKeyInfo tombol = Console.ReadKey(true);

                if (tombol.Key == ConsoleKey.RightArrow)
                {
                    posisi += 2;
                    Console.WriteLine($"{nama} bergerak ke kanan.");
                    Console.WriteLine($"Posisi saat ini: {posisi}");
                }
                else if (tombol.Key == ConsoleKey.LeftArrow)
                {
                    posisi -= 1;

                    if (posisi < 0)
                    {
                        Console.WriteLine("Logika game salah!");
                        Console.WriteLine("Posisi tidak boleh kurang dari 0.");
                        Console.WriteLine("Permainan berhenti");
                        break;
                    }

                    Console.WriteLine($"{nama} bergerak ke kiri.");
                    Console.WriteLine($"Posisi saat ini: {posisi}");
                }
                else if (tombol.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Permainan berhenti");
                    break;
                }
                else if (tombol.Key == ConsoleKey.UpArrow)
                {
                    posisi += 4;
                    Console.WriteLine($"{nama} bergerak ke atas");
                    Console.WriteLine($"Posisi saat ini {posisi}");
                }
            }
        }
    }
    class MainProgram
    {
        static void Main(string[] args)
        {
            Karakter player1 = new Karakter("Fahri", 100, 50, 20, 0); //membuat objek

            Karakter musuh = new Karakter("Iblis", 100, 50, 10, 0);

            Console.WriteLine("PILIH METODE GERAK");
            Console.WriteLine("1. Perpindahan angka");
            Console.WriteLine("2. Tombol keyboard");
            Console.Write("Pilihanmu: ");

            string pilihan = Console.ReadLine();

            if (pilihan == "1")
            {
                player1.getData();
                player1.ubahPosisiAngka();
            }
            else if (pilihan == "2")
            {
                player1.getData();
                player1.ubahPosisiTombol();
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid!");
            }

            player1.getData();
            //interaksi
            //player1.ubahPosisi();
            //player1.getData();
            //player1.Serang(musuh);
            //musuh.Serang(player1);
            //player1.TerimaSerangan(50);
            //player1.Healing(20);
            //player1.getData();



        }
    }
}
