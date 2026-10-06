// Materi Array Dan Koleksi dasar

// Array
// List
// serta Menyimpan banyak data dalam satu tempat

// 1. Array
// Digunakan untuk menyimpan banyak daat dalam satu variabel
// Array biasanya digunakan ketika data memiliki tipe yang sama

// Array dapat menyimpan banyak data dengan tipe data yang sama

string[] namaBuah = { "Apel", "Mangga", "Jeruk" }; // Array string untuk menyimpan beberapa nama buah

// penjelasan struktur Array
// string[]     <- tanda [] menunjukkan bahwa variabel adalah array


// Mengambil data Array
//Console.WriteLine(namaBuah[0]); // Hasilnya akan menampilkan apel (Isi pertama dari array) karena index array dimulai dari angka 0
//Console.WriteLine(namaBuah[2]);


// Array juga sering digunakan bersama dengan perulangan foreach

foreach (string buah in namaBuah)
{
    Console.WriteLine(buah);
}

// Dengan pengulangan, kita dapat menghemat penulisan array tanpa harus menulis satu persatu

// 2. Koleksi Dasar: List
// List adalah koleksi yang dapat menampung banyak data dengan tipe data yang sama ( Lebih fleksibel dibanding array)

List<String> namaSiswa = new List<string>(); // Membuat List untuk menyimpan data siswa

// Menambahkan data ke List
namaSiswa.Add("Budi"); // .Add digunakan untuk menambahkan data ke list
namaSiswa.Add("Anton");
namaSiswa.Add("Siti");

// Coba Kita tampilkan hasil dari list
foreach (string siswa in namaSiswa)
{
    Console.WriteLine(siswa);
}

// Bedanya dengan array, ukuran dari List lebih fleksibel dibandingkan dengan Array yang memiliki ukuran tetap
// dan cocok untuk data yang sering berubah-ubah (Dinamis)