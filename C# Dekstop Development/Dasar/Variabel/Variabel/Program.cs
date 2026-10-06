// Variabel, Tipe Data, dan Operator Sederhana

int umur = 17; // <- Ini adalah bentuk Variabel di C#

String // <- Ini adalah Tipe Data yang menentukan sebuah Variabel.
    nama = "Christopher Aldo Natanael"; // <- setelah itu diikuti dengan (Nama Variabel) = (Nilai Variabel)

// VARIABEL dan TIPE DATA
// Ada 5 Variabel yang sering digunakan di C#

// Interger, yaitu angka bulat
int tahun = 2008;

// Double atau float, yaitu angka decimal
double tinggi = 170.5;

// Char, yaitu satu karakter huruf (Tidak bisa lebih dari satu huruf)
char nilai = 'A'; // beda dengan String, Char menggunakan satu petik (' ')

// String, yaitu kumpulan dari karakter huruf, angka, symbol, bisa lebih dari beberapa huruf bahkan kalimat
String alamat = "Sidoarjo, Tulangan, Jawa Timur";

// Bool (Boolean) yaitu variabel yang terdiri dari dua nilai antara true atau false saja
bool gemarMembaca = true; // true berarti benar
bool sudahMakan = false; // false berarti salah

// Operator Sederhana
// Operasi sederhana untuk menjumlahkan, mengurangi, mengali, serta membagi bilangan, serta menampilkan nya.

int a = 10;
int b = 5;

// Cara 1 membuat Variabel terlebih dahulu
int hasilPenjumlahan = a + b;
Console.WriteLine(hasilPenjumlahan);

// Hasilnya akan keluar di dalam Console CMD

// Cara 2 langsung menulis di dalam WriteLine
Console.WriteLine(a + b);

// Hasilnya akan sama saja


// 2. Mengurangi
// sama seperti di atas, kita bisa menggunakan kedua cara tersebut

Console.WriteLine(a - b);


// 3. Mengali
// Untuk mengalikan, kita menggunakan symbol asteris (*)
Console.WriteLine(a * b);

// Pembagian
// untuk pembagian dengan hasil decimal, kita juga harus mempunyai variabel dengan tipe data decimal seperti Float atau Double.
// untuk pembagian, kita menggunakan simbol garis miring (/)

Console.WriteLine(a / b);

// hasil akan menjadi angka bulat dan tidak akurat, kita harus mengganti atau membuat variabel baru dengan tipe data double
// Biasanya tipe data double dilanjutkan dengan angka di belakangnya, namun jika hasilnya bulat biarkan kosong tanpa nilai koma di belakang

double c = 12.0;
double d = 7.0;

Console.WriteLine(c / d);