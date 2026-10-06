
// IF
int umur = 15;

//if (umur >= 17) // If digunakan untuk mengecek kondisi,
//                // Kondisi akan menghasilkan true atau false
//{
//    Console.WriteLine("Boleh membuat KTP"); // ini output jika hasilnya true
//}


// ELSE

if (umur >= 17) // If digunakan untuk mengecek kondisi,
                // Kondisi akan menghasilkan true atau false
{
    Console.WriteLine("Boleh membuat KTP"); // ini output jika hasilnya true
}
else // Else dijalankan jika kondisi False
     // Else digunakan sebagai alternatif ketika kondisi if tidak 
{
    Console.WriteLine("Belum Boleh membuat KTP");
}

// ELSE IF

int nilai = 91;

if(nilai >= 90)
{
    Console.WriteLine("Nilai A");
}
else if (nilai >= 75)
{
    Console.WriteLine("Nilai B");
}
else
{
    Console.WriteLine("Nilai C");
}

// Switch 
// Digunakan untuk memilih kondisi berdasarkan nilai tertentu

string hari = "Selasa";

switch (hari) // switch digunakan untuk memeriksa nilai variabel
{
    case "Senin": // case adalah pilihan kondisi
        Console.WriteLine("Hari Pertama");
        break; // break digunakan untuk menghentikan switch

    case "Minggu";
        Console.WriteLine("Hari Ketujuh");
        break;

    default: // default dijalankan jika tidak ada kondisi yang cocok (mirip seperti false di Else IF)
        Console.WriteLine("Hari Lain");
        break;
}