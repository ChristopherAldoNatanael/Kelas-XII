-- =============================================================
-- SEED DUMMY DATA - BromoAirlines (untuk testing)
-- Aman dijalankan ulang: data master dicek duplikat dulu
-- (berdasarkan KodeIATA / Nama / Username / Kode).
-- Data transaksi & status hanya diisi jika tabelnya masih kosong.
-- =============================================================

-- ============ 1. NEGARA (+10) ============
IF NOT EXISTS (SELECT 1 FROM Negara WHERE Nama = 'Vietnam')
    INSERT INTO Negara (Nama, IbukotaNegara) VALUES ('Vietnam', 'Hanoi');
IF NOT EXISTS (SELECT 1 FROM Negara WHERE Nama = 'Filipina')
    INSERT INTO Negara (Nama, IbukotaNegara) VALUES ('Filipina', 'Manila');
IF NOT EXISTS (SELECT 1 FROM Negara WHERE Nama = 'Myanmar')
    INSERT INTO Negara (Nama, IbukotaNegara) VALUES ('Myanmar', 'Naypyidaw');
IF NOT EXISTS (SELECT 1 FROM Negara WHERE Nama = 'Kamboja')
    INSERT INTO Negara (Nama, IbukotaNegara) VALUES ('Kamboja', 'Phnom Penh');
IF NOT EXISTS (SELECT 1 FROM Negara WHERE Nama = 'Laos')
    INSERT INTO Negara (Nama, IbukotaNegara) VALUES ('Laos', 'Vientiane');
IF NOT EXISTS (SELECT 1 FROM Negara WHERE Nama = 'Brunei')
    INSERT INTO Negara (Nama, IbukotaNegara) VALUES ('Brunei', 'Bandar Seri Begawan');
IF NOT EXISTS (SELECT 1 FROM Negara WHERE Nama = 'Timor Leste')
    INSERT INTO Negara (Nama, IbukotaNegara) VALUES ('Timor Leste', 'Dili');
IF NOT EXISTS (SELECT 1 FROM Negara WHERE Nama = 'Turki')
    INSERT INTO Negara (Nama, IbukotaNegara) VALUES ('Turki', 'Ankara');
IF NOT EXISTS (SELECT 1 FROM Negara WHERE Nama = 'Qatar')
    INSERT INTO Negara (Nama, IbukotaNegara) VALUES ('Qatar', 'Doha');
IF NOT EXISTS (SELECT 1 FROM Negara WHERE Nama = 'Perancis')
    INSERT INTO Negara (Nama, IbukotaNegara) VALUES ('Perancis', 'Paris');
GO

-- ============ 2. AKUN dummy customer (+6) ============
IF NOT EXISTS (SELECT 1 FROM Akun WHERE Username = 'dummy1')
    INSERT INTO Akun (Username, Password, Nama, TanggalLahir, NomorTelepon, MerupakanAdmin)
    VALUES ('dummy1', 'password123', 'Budi Santoso', '1998-05-12', '081234567801', 0);
IF NOT EXISTS (SELECT 1 FROM Akun WHERE Username = 'dummy2')
    INSERT INTO Akun (Username, Password, Nama, TanggalLahir, NomorTelepon, MerupakanAdmin)
    VALUES ('dummy2', 'password123', 'Siti Rahayu', '2000-02-20', '081234567802', 0);
IF NOT EXISTS (SELECT 1 FROM Akun WHERE Username = 'dummy3')
    INSERT INTO Akun (Username, Password, Nama, TanggalLahir, NomorTelepon, MerupakanAdmin)
    VALUES ('dummy3', 'password123', 'Andi Pratama', '1995-11-03', '081234567803', 0);
IF NOT EXISTS (SELECT 1 FROM Akun WHERE Username = 'dummy4')
    INSERT INTO Akun (Username, Password, Nama, TanggalLahir, NomorTelepon, MerupakanAdmin)
    VALUES ('dummy4', 'password123', 'Dewi Lestari', '2002-07-15', '081234567804', 0);
IF NOT EXISTS (SELECT 1 FROM Akun WHERE Username = 'dummy5')
    INSERT INTO Akun (Username, Password, Nama, TanggalLahir, NomorTelepon, MerupakanAdmin)
    VALUES ('dummy5', 'password123', 'Rizky Ramadhan', '1999-09-25', '081234567805', 0);
IF NOT EXISTS (SELECT 1 FROM Akun WHERE Username = 'dummy6')
    INSERT INTO Akun (Username, Password, Nama, TanggalLahir, NomorTelepon, MerupakanAdmin)
    VALUES ('dummy6', 'password123', 'Putri Ayu', '2001-12-30', '081234567806', 0);
GO

-- ============ 3. BANDARA (+30) ============
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'KNO')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Kualanamu', 'KNO', 'Medan', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 2, 'Jl. Bandara Kualanamu No. 1, Deli Serdang');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'PLM')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Sultan Mahmud Badaruddin II', 'PLM', 'Palembang', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 2, 'Jl. Bandara SMB II No. 1, Palembang');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'BTH')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Hang Nadim', 'BTH', 'Batam', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara Hang Nadim No. 1, Batam');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'BDO')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Husein Sastranegara', 'BDO', 'Bandung', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Pajajaran No. 156, Bandung');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'YIA')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Yogyakarta International', 'YIA', 'Kulon Progo', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Wates-Purworejo KM 10, Kulon Progo');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'LOP')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Zainuddin Abdul Madjid', 'LOP', 'Praya', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara Lombok No. 1, Praya');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'BPN')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Sepinggan', 'BPN', 'Balikpapan', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 2, 'Jl. Marsma R. Iswahyudi No. 1, Balikpapan');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'UPG')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Sultan Hasanuddin', 'UPG', 'Makassar', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 2, 'Jl. Bandara Sultan Hasanuddin No. 1, Maros');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'MDC')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Sam Ratulangi', 'MDC', 'Manado', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. A. A. Maramis No. 1, Manado');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'DJJ')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Sentani', 'DJJ', 'Jayapura', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara Sentani No. 1, Jayapura');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'AMQ')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Pattimura', 'AMQ', 'Ambon', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara Pattimura No. 1, Ambon');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'BDJ')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Syamsudin Noor', 'BDJ', 'Banjarmasin', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara Syamsudin Noor No. 1, Banjarbaru');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'PKU')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Sultan Syarif Kasim II', 'PKU', 'Pekanbaru', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara SSK II No. 1, Pekanbaru');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'PDG')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Minangkabau', 'PDG', 'Padang', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara Minangkabau No. 1, Padang Pariaman');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'BKS')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Fatmawati Soekarno', 'BKS', 'Bengkulu', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara Fatmawati No. 1, Bengkulu');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'TKG')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Radin Inten', 'TKG', 'Bandar Lampung', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara Radin Inten No. 1, Lampung Selatan');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'KDI')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Haluoleo', 'KDI', 'Kendari', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara Haluoleo No. 1, Kendari');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'GTO')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Jalaluddin', 'GTO', 'Gorontalo', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara Jalaluddin No. 1, Gorontalo');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'PLW')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Mutiara Sis Al-Jufri', 'PLW', 'Palu', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara Mutiara No. 1, Palu');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'BIK')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Frans Kaisiepo', 'BIK', 'Biak', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara Frans Kaisiepo No. 1, Biak');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'TRK')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Juwata', 'TRK', 'Tarakan', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara Juwata No. 1, Tarakan');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'KOE')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('El Tari', 'KOE', 'Kupang', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara El Tari No. 1, Kupang');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'MOF')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Frans Seda', 'MOF', 'Maumere', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara Frans Seda No. 1, Maumere');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'LBJ')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Komodo', 'LBJ', 'Labuan Bajo', (SELECT ID FROM Negara WHERE Nama = 'Indonesia'), 1, 'Jl. Bandara Komodo No. 1, Labuan Bajo');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'SIN')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Changi', 'SIN', 'Singapura', (SELECT ID FROM Negara WHERE Nama = 'Singapura'), 4, 'Airport Blvd, Singapura');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'KUL')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Kuala Lumpur International', 'KUL', 'Sepang', (SELECT ID FROM Negara WHERE Nama = 'Malaysia'), 2, 'Jalan KLIA, Sepang');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'BKK')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Suvarnabhumi', 'BKK', 'Bangkok', (SELECT ID FROM Negara WHERE Nama = 'Thailand'), 2, 'Soi Lat Krabang, Bangkok');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'NRT')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Narita', 'NRT', 'Tokyo', (SELECT ID FROM Negara WHERE Nama = 'Jepang'), 3, '1-1 Furugome, Narita');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'ICN')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Incheon', 'ICN', 'Seoul', (SELECT ID FROM Negara WHERE Nama = 'Korea Selatan'), 2, '272 Gonghang-ro, Incheon');
IF NOT EXISTS (SELECT 1 FROM Bandara WHERE KodeIATA = 'SYD')
    INSERT INTO Bandara (Nama, KodeIATA, Kota, NegaraID, JumlahTerminal, Alamat)
    VALUES ('Kingsford Smith', 'SYD', 'Sydney', (SELECT ID FROM Negara WHERE Nama = 'Australia'), 3, 'Keith Smith Ave, Sydney');
GO

-- ============ 4. MASKAPAI (+12) ============
IF NOT EXISTS (SELECT 1 FROM Maskapai WHERE Nama = 'Sriwijaya Air')
    INSERT INTO Maskapai (Nama, Perusahaan, JumlahKru, Deskripsi)
    VALUES ('Sriwijaya Air', 'PT Sriwijaya Air', 8, 'Maskapai swasta Indonesia melayani rute domestik dan regional.');
IF NOT EXISTS (SELECT 1 FROM Maskapai WHERE Nama = 'Super Air Jet')
    INSERT INTO Maskapai (Nama, Perusahaan, JumlahKru, Deskripsi)
    VALUES ('Super Air Jet', 'PT Super Air Jet Indonesia', 6, 'Maskapai bertarif rendah dengan armada Airbus A320.');
IF NOT EXISTS (SELECT 1 FROM Maskapai WHERE Nama = 'Indonesia AirAsia')
    INSERT INTO Maskapai (Nama, Perusahaan, JumlahKru, Deskripsi)
    VALUES ('Indonesia AirAsia', 'PT Indonesia AirAsia', 6, 'Maskapai bertarif rendah bagian dari grup AirAsia.');
IF NOT EXISTS (SELECT 1 FROM Maskapai WHERE Nama = 'Wings Air')
    INSERT INTO Maskapai (Nama, Perusahaan, JumlahKru, Deskripsi)
    VALUES ('Wings Air', 'PT Wings Abadi Airlines', 5, 'Maskapai feeder Lion Group untuk rute perintis dan pendek.');
IF NOT EXISTS (SELECT 1 FROM Maskapai WHERE Nama = 'Susi Air')
    INSERT INTO Maskapai (Nama, Perusahaan, JumlahKru, Deskripsi)
    VALUES ('Susi Air', 'PT ASI Pudjiastuti Aviation', 4, 'Maskapai perintis melayani daerah terpencil.');
IF NOT EXISTS (SELECT 1 FROM Maskapai WHERE Nama = 'Trigana Air')
    INSERT INTO Maskapai (Nama, Perusahaan, JumlahKru, Deskripsi)
    VALUES ('Trigana Air', 'PT Trigana Air Service', 5, 'Maskapai kargo dan penumpang untuk wilayah timur Indonesia.');
IF NOT EXISTS (SELECT 1 FROM Maskapai WHERE Nama = 'Kalstar Aviation')
    INSERT INTO Maskapai (Nama, Perusahaan, JumlahKru, Deskripsi)
    VALUES ('Kalstar Aviation', 'PT Kalstar Aviation', 5, 'Maskapai regional berbasis di Kalimantan.');
IF NOT EXISTS (SELECT 1 FROM Maskapai WHERE Nama = 'Xpress Air')
    INSERT INTO Maskapai (Nama, Perusahaan, JumlahKru, Deskripsi)
    VALUES ('Xpress Air', 'PT Express Air', 5, 'Maskapai regional melayani Papua dan sekitarnya.');
IF NOT EXISTS (SELECT 1 FROM Maskapai WHERE Nama = 'TransNusa')
    INSERT INTO Maskapai (Nama, Perusahaan, JumlahKru, Deskripsi)
    VALUES ('TransNusa', 'PT TransNusa Aviation Mandiri', 5, 'Maskapai regional dengan basis Nusa Tenggara.');
IF NOT EXISTS (SELECT 1 FROM Maskapai WHERE Nama = 'NAM Air')
    INSERT INTO Maskapai (Nama, Perusahaan, JumlahKru, Deskripsi)
    VALUES ('NAM Air', 'PT NAM Air', 6, 'Anak perusahaan Sriwijaya Air untuk rute domestik.');
IF NOT EXISTS (SELECT 1 FROM Maskapai WHERE Nama = 'Kartika Airlines')
    INSERT INTO Maskapai (Nama, Perusahaan, JumlahKru, Deskripsi)
    VALUES ('Kartika Airlines', 'PT Kartika Airlines', 6, 'Maskapai layanan penuh rute domestik utama.');
IF NOT EXISTS (SELECT 1 FROM Maskapai WHERE Nama = 'Riau Airlines')
    INSERT INTO Maskapai (Nama, Perusahaan, JumlahKru, Deskripsi)
    VALUES ('Riau Airlines', 'PT Riau Airlines', 5, 'Maskapai regional berbasis di Sumatera.');
GO

-- ============ 5. KODE PROMO (+11) ============
IF NOT EXISTS (SELECT 1 FROM KodePromo WHERE Kode = 'HEMAT10')
    INSERT INTO KodePromo (Kode, PersentaseDiskon, MaksimumDiskon, BerlakuSampai, Deskripsi)
    VALUES ('HEMAT10', 10, 50000, DATEADD(month, 1, GETDATE()), 'Diskon 10 persen maksimal Rp 50.000 untuk semua rute.');
IF NOT EXISTS (SELECT 1 FROM KodePromo WHERE Kode = 'HEMAT20')
    INSERT INTO KodePromo (Kode, PersentaseDiskon, MaksimumDiskon, BerlakuSampai, Deskripsi)
    VALUES ('HEMAT20', 20, 100000, DATEADD(month, 2, GETDATE()), 'Diskon 20 persen maksimal Rp 100.000 minimal transaksi Rp 500.000.');
IF NOT EXISTS (SELECT 1 FROM KodePromo WHERE Kode = 'TERBANG25')
    INSERT INTO KodePromo (Kode, PersentaseDiskon, MaksimumDiskon, BerlakuSampai, Deskripsi)
    VALUES ('TERBANG25', 25, 200000, DATEADD(month, 3, GETDATE()), 'Diskon 25 persen maksimal Rp 200.000 untuk penerbangan jarak jauh.');
IF NOT EXISTS (SELECT 1 FROM KodePromo WHERE Kode = 'LIBURAN15')
    INSERT INTO KodePromo (Kode, PersentaseDiskon, MaksimumDiskon, BerlakuSampai, Deskripsi)
    VALUES ('LIBURAN15', 15, 75000, DATEADD(month, 2, GETDATE()), 'Promo liburan diskon 15 persen maksimal Rp 75.000.');
IF NOT EXISTS (SELECT 1 FROM KodePromo WHERE Kode = 'AKHIRTAHUN30')
    INSERT INTO KodePromo (Kode, PersentaseDiskon, MaksimumDiskon, BerlakuSampai, Deskripsi)
    VALUES ('AKHIRTAHUN30', 30, 250000, DATEADD(month, 4, GETDATE()), 'Promo akhir tahun diskon 30 persen maksimal Rp 250.000.');
IF NOT EXISTS (SELECT 1 FROM KodePromo WHERE Kode = 'PROMO50')
    INSERT INTO KodePromo (Kode, PersentaseDiskon, MaksimumDiskon, BerlakuSampai, Deskripsi)
    VALUES ('PROMO50', 50, 500000, DATEADD(month, 5, GETDATE()), 'Promo spesial diskon 50 persen maksimal Rp 500.000 kuota terbatas.');
IF NOT EXISTS (SELECT 1 FROM KodePromo WHERE Kode = 'BROMOMURAH')
    INSERT INTO KodePromo (Kode, PersentaseDiskon, MaksimumDiskon, BerlakuSampai, Deskripsi)
    VALUES ('BROMOMURAH', 5, 25000, DATEADD(month, 6, GETDATE()), 'Diskon 5 persen maksimal Rp 25.000 tanpa minimal transaksi.');
IF NOT EXISTS (SELECT 1 FROM KodePromo WHERE Kode = 'NAIKHAJI12')
    INSERT INTO KodePromo (Kode, PersentaseDiskon, MaksimumDiskon, BerlakuSampai, Deskripsi)
    VALUES ('NAIKHAJI12', 12, 120000, DATEADD(month, 3, GETDATE()), 'Diskon 12 persen maksimal Rp 120.000 untuk semua maskapai.');
IF NOT EXISTS (SELECT 1 FROM KodePromo WHERE Kode = 'WEEKEND10')
    INSERT INTO KodePromo (Kode, PersentaseDiskon, MaksimumDiskon, BerlakuSampai, Deskripsi)
    VALUES ('WEEKEND10', 10, 60000, DATEADD(month, 1, GETDATE()), 'Diskon akhir pekan 10 persen maksimal Rp 60.000.');
IF NOT EXISTS (SELECT 1 FROM KodePromo WHERE Kode = 'MEMBER20')
    INSERT INTO KodePromo (Kode, PersentaseDiskon, MaksimumDiskon, BerlakuSampai,Deskripsi)
    VALUES ('MEMBER20', 20, 150000, DATEADD(month, 7, GETDATE()), 'Diskon member 20 persen maksimal Rp 150.000.');
IF NOT EXISTS (SELECT 1 FROM KodePromo WHERE Kode = 'JADUL10')
    INSERT INTO KodePromo (Kode, PersentaseDiskon, MaksimumDiskon, BerlakuSampai, Deskripsi)
    VALUES ('JADUL10', 10, 50000, DATEADD(day, -10, GETDATE()), 'Promo lama yang sudah kedaluwarsa untuk testing validasi.');
GO

-- ============ 6. STATUS PENERBANGAN (+3) ============
IF NOT EXISTS (SELECT 1 FROM StatusPenerbangan WHERE Nama = 'Boarding')
    INSERT INTO StatusPenerbangan (Nama) VALUES ('Boarding');
IF NOT EXISTS (SELECT 1 FROM StatusPenerbangan WHERE Nama = 'Berangkat')
    INSERT INTO StatusPenerbangan (Nama) VALUES ('Berangkat');
IF NOT EXISTS (SELECT 1 FROM StatusPenerbangan WHERE Nama = 'Tiba')
    INSERT INTO StatusPenerbangan (Nama) VALUES ('Tiba');
GO

-- ============ 7. JADWAL PENERBANGAN (+60) ============
CREATE TABLE #Rute (N INT IDENTITY(1,1), Dari CHAR(3), Ke CHAR(3), Durasi INT, HMin INT, HMax INT);
INSERT INTO #Rute (Dari, Ke, Durasi, HMin, HMax) VALUES
('CGK','SUB',90,600000,1500000),('SUB','CGK',90,600000,1500000),
('CGK','DPS',110,700000,1800000),('DPS','CGK',110,700000,1800000),
('CGK','KNO',150,900000,2200000),('CGK','UPG',150,900000,2200000),
('CGK','YIA',70,500000,1200000),('CGK','BPN',140,850000,2000000),
('DPS','SUB',60,450000,1000000),('CGK','SRG',70,500000,1200000),
('CGK','PLM',70,500000,1200000),('CGK','BTH',100,650000,1600000),
('CGK','BDO',40,350000,800000),('SUB','DPS',60,450000,1000000),
('SUB','UPG',120,750000,1700000),('CGK','SIN',110,800000,2500000),
('CGK','KUL',120,800000,2500000),('SUB','SIN',130,900000,2600000),
('DPS','SIN',170,1000000,3000000),('CGK','BKK',210,1500000,4000000);

CREATE TABLE #Mk (N INT IDENTITY(1,1), Nama VARCHAR(200), Prefix VARCHAR(5));
INSERT INTO #Mk (Nama, Prefix) VALUES
('Adam Air','KI'),('Aviastar','MV'),('Batavia Air','Y6'),('Batik Air','ID'),
('Bourag Indonesia','BO'),('Citilink','QG'),('Garuda Indonesia','GA'),
('Lion Air','JT'),('Pelita Airr','IP'),('Sriwijaya Air','SJ'),
('Super Air Jet','IU'),('Indonesia AirAsia','QZ'),('Wings Air','IW'),
('Susi Air','SI'),('Trigana Air','IL'),('Kalstar Aviation','KD'),
('Xpress Air','XN'),('TransNusa','8B'),('NAM Air','IN'),
('Kartika Airlines','KX'),('Riau Airlines','RI');

DECLARE @i INT = 0;
DECLARE @RC INT = (SELECT COUNT(*) FROM #Rute);
DECLARE @MC INT = (SELECT COUNT(*) FROM #Mk);
WHILE @i < 60
BEGIN
    DECLARE @rn INT = (@i % @RC) + 1;
    DECLARE @mn INT = ((@i * 7 + 3) % @MC) + 1;
    DECLARE @dari CHAR(3), @ke CHAR(3), @dur INT, @hmin INT, @hmax INT;
    DECLARE @pfx VARCHAR(5), @mNama VARCHAR(200);
    SELECT @dari = Dari, @ke = Ke, @dur = Durasi, @hmin = HMin, @hmax = HMax FROM #Rute WHERE N = @rn;
    SELECT @pfx = Prefix, @mNama = Nama FROM #Mk WHERE N = @mn;
    DECLARE @kode VARCHAR(10) = @pfx + '-' + CAST(101 + @i AS VARCHAR(4));
    DECLARE @tgl DATETIME = DATEADD(minute, ((@i * 13) % 4) * 15,
        DATEADD(hour, 5 + ((@i * 37) % 16), CAST(DATEADD(day, 1 + (@i % 30), GETDATE()) AS DATETIME)));
    DECLARE @harga FLOAT = @hmin + ((@i * 7919) % (@hmax - @hmin));
    IF NOT EXISTS (SELECT 1 FROM JadwalPenerbangan WHERE KodePenerbangan = @kode)
        INSERT INTO JadwalPenerbangan (KodePenerbangan, BandaraKeberangkatanID, BandaraTujuanID, MaskapaiID, TanggalWaktuKeberangkatan, DurasiPenerbangan, HargaPerTiket)
        VALUES (@kode,
            (SELECT ID FROM Bandara WHERE KodeIATA = @dari),
            (SELECT ID FROM Bandara WHERE KodeIATA = @ke),
            (SELECT ID FROM Maskapai WHERE Nama = @mNama),
            @tgl, @dur, @harga);
    SET @i = @i + 1;
END
DROP TABLE #Rute;
DROP TABLE #Mk;
GO

-- ============ 8. PERUBAHAN STATUS (riwayat tiap jadwal) ============
DECLARE @stJadwal INT = (SELECT ID FROM StatusPenerbangan WHERE Nama = 'Sesuai Jadwal');
DECLARE @stDelay INT = (SELECT ID FROM StatusPenerbangan WHERE Nama = 'Delay');
INSERT INTO PerubahanStatusJadwalPenerbangan (JadwalPenerbanganID, StatusPenerbanganID, WaktuPerubahanTerjadi, PerkiraanDurasiDelay)
SELECT j.ID, @stJadwal, DATEADD(day, -1, j.TanggalWaktuKeberangkatan), NULL
FROM JadwalPenerbangan j
WHERE NOT EXISTS (SELECT 1 FROM PerubahanStatusJadwalPenerbangan p WHERE p.JadwalPenerbanganID = j.ID);
INSERT INTO PerubahanStatusJadwalPenerbangan (JadwalPenerbanganID, StatusPenerbanganID, WaktuPerubahanTerjadi, PerkiraanDurasiDelay)
SELECT j.ID, @stDelay, DATEADD(hour, -3, j.TanggalWaktuKeberangkatan), 30 + ((j.ID % 3) * 15)
FROM JadwalPenerbangan j
WHERE j.ID % 3 = 0
  AND NOT EXISTS (SELECT 1 FROM PerubahanStatusJadwalPenerbangan p WHERE p.JadwalPenerbanganID = j.ID AND p.StatusPenerbanganID = @stDelay);
GO

-- ============ 9. TRANSAKSI (40 header + detail) ============
-- Hanya diisi jika tabel masih kosong agar aman dijalankan ulang.
IF NOT EXISTS (SELECT 1 FROM TransaksiHeader)
BEGIN
    CREATE TABLE #Ak (N INT IDENTITY(1,1), ID INT);
    INSERT INTO #Ak SELECT ID FROM Akun WHERE MerupakanAdmin = 0 ORDER BY ID;
    CREATE TABLE #Jd (N INT IDENTITY(1,1), ID INT, Harga FLOAT);
    INSERT INTO #Jd SELECT ID, HargaPerTiket FROM JadwalPenerbangan ORDER BY ID;
    CREATE TABLE #Pr (N INT IDENTITY(1,1), ID INT, Pct FLOAT, Cap FLOAT);
    INSERT INTO #Pr SELECT ID, PersentaseDiskon, MaksimumDiskon FROM KodePromo WHERE BerlakuSampai >= CAST(GETDATE() AS DATE) ORDER BY ID;
    CREATE TABLE #Nm (N INT IDENTITY(1,1), Nama VARCHAR(200));
    INSERT INTO #Nm (Nama) VALUES
    ('Budi Santoso'),('Siti Rahayu'),('Andi Pratama'),('Dewi Lestari'),
    ('Rizky Ramadhan'),('Putri Ayu'),('Agus Wijaya'),('Rina Marlina'),
    ('Dedi Kurniawan'),('Maya Anggraini'),('Fajar Nugroho'),('Intan Permata');

    DECLARE @t INT = 0;
    DECLARE @AC INT = (SELECT COUNT(*) FROM #Ak);
    DECLARE @JC INT = (SELECT COUNT(*) FROM #Jd);
    DECLARE @PC INT = (SELECT COUNT(*) FROM #Pr);
    WHILE @t < 40
    BEGIN
        DECLARE @akId INT, @jdId INT, @hrg FLOAT;
        SELECT @akId = ID FROM #Ak WHERE N = ((@t % @AC) + 1);
        SELECT @jdId = ID, @hrg = Harga FROM #Jd WHERE N = (((@t * 5 + 1) % @JC) + 1);
        DECLARE @qty INT = 1 + (@t % 3);
        DECLARE @prId INT = NULL;
        DECLARE @total FLOAT = @hrg * @qty;
        IF (@t % 3 = 0 AND @PC > 0)
        BEGIN
            DECLARE @pct FLOAT, @cap FLOAT;
            SELECT @prId = ID, @pct = Pct, @cap = Cap FROM #Pr WHERE N = ((@t % @PC) + 1);
            DECLARE @disc FLOAT = @total * @pct / 100;
            IF (@disc > @cap) SET @disc = @cap;
            SET @total = @total - @disc;
        END
        INSERT INTO TransaksiHeader (AkunID, TanggalTransaksi, JadwalPenerbanganID, JumlahPenumpang, TotalHarga, KodePromoID)
        VALUES (@akId, DATEADD(day, -(@t % 10), GETDATE()), @jdId, @qty, @total, @prId);
        DECLARE @hid INT = SCOPE_IDENTITY();
        DECLARE @k INT = 0;
        WHILE @k < @qty
        BEGIN
            DECLARE @titel VARCHAR(20) = CASE WHEN ((@t + @k) % 2) = 0 THEN 'Tuan' ELSE 'Nyonya' END;
            DECLARE @nm VARCHAR(200);
            SELECT @nm = Nama FROM #Nm WHERE N = (((@t * 3 + @k) % 12) + 1);
            INSERT INTO TransaksiDetail (TransaksiHeaderID, TitelPenumpang, NamaLengkapPenumpang)
            VALUES (@hid, @titel, @nm);
            SET @k = @k + 1;
        END
        SET @t = @t + 1;
    END
    DROP TABLE #Ak;
    DROP TABLE #Jd;
    DROP TABLE #Pr;
    DROP TABLE #Nm;
END
GO
