-- =============================================================
-- SEED JADWAL PADAT OKTOBER 2026 - BromoAirlines (testing)
-- Mengisi 8-31 Oktober 2026: ±24 rute x 6 penerbangan/hari.
-- Aman dijalankan ulang (dicek duplikat KodePenerbangan).
-- =============================================================

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
('DPS','SIN',170,1000000,3000000),('CGK','BKK',210,1500000,4000000),
('SUB','KNO',160,950000,2300000),('DPS','UPG',120,750000,1700000),
('CGK','MDC',180,1100000,2800000),('CGK','LOP',110,700000,1800000);

CREATE TABLE #Mk (N INT IDENTITY(1,1), Nama VARCHAR(200), Prefix VARCHAR(5));
INSERT INTO #Mk (Nama, Prefix) VALUES
('Adam Air','KI'),('Aviastar','MV'),('Batavia Air','Y6'),('Batik Air','ID'),
('Bourag Indonesia','BO'),('Citilink','QG'),('Garuda Indonesia','GA'),
('Lion Air','JT'),('Pelita Airr','IP'),('Sriwijaya Air','SJ'),
('Super Air Jet','IU'),('Indonesia AirAsia','QZ'),('Wings Air','IW'),
('Susi Air','SI'),('Trigana Air','IL'),('Kalstar Aviation','KD'),
('Xpress Air','XN'),('TransNusa','8B'),('NAM Air','IN'),
('Kartika Airlines','KX'),('Riau Airlines','RI');

DECLARE @RC INT = (SELECT COUNT(*) FROM #Rute);
DECLARE @MC INT = (SELECT COUNT(*) FROM #Mk);
-- Hari Oktober yang diisi: dari besok s/d 31 Okt 2026 (tanggal lampau dilewati).
DECLARE @d INT = CASE
    WHEN CAST(GETDATE() AS DATE) < '2026-10-08' THEN 8
    WHEN CAST(GETDATE() AS DATE) > '2026-10-31' THEN 32
    ELSE DAY(GETDATE()) + 1 END;
DECLARE @ctr INT = 1001;

WHILE @d <= 31
BEGIN
    DECLARE @r INT = 1;
    WHILE @r <= @RC
    BEGIN
        DECLARE @s INT = 0;
        WHILE @s < 6
        BEGIN
            DECLARE @dari CHAR(3), @ke CHAR(3), @dur INT, @hmin INT, @hmax INT;
            DECLARE @pfx VARCHAR(5), @mNama VARCHAR(200);
            SELECT @dari = Dari, @ke = Ke, @dur = Durasi, @hmin = HMin, @hmax = HMax
            FROM #Rute WHERE N = @r;
            SELECT @pfx = Prefix, @mNama = Nama FROM #Mk WHERE N = (((@r + @d + @s * 5) % @MC) + 1);
            DECLARE @kode VARCHAR(10) = @pfx + '-' + CAST(@ctr AS VARCHAR(4));
            DECLARE @tgl DATETIME = DATEADD(minute, (((@r * 7 + @d * 3 + @s * 17) % 4) * 15),
                DATEADD(hour, 5 + (((@r + @d + @s * 3) % 16)),
                CAST(CAST('2026-10-' + RIGHT('0' + CAST(@d AS VARCHAR(2)), 2) AS DATETIME) AS DATETIME)));
            DECLARE @harga FLOAT = @hmin + ((@ctr * 7919) % (@hmax - @hmin));
            IF NOT EXISTS (SELECT 1 FROM JadwalPenerbangan WHERE KodePenerbangan = @kode)
                INSERT INTO JadwalPenerbangan (KodePenerbangan, BandaraKeberangkatanID, BandaraTujuanID, MaskapaiID, TanggalWaktuKeberangkatan, DurasiPenerbangan, HargaPerTiket)
                VALUES (@kode,
                    (SELECT ID FROM Bandara WHERE KodeIATA = @dari),
                    (SELECT ID FROM Bandara WHERE KodeIATA = @ke),
                    (SELECT ID FROM Maskapai WHERE Nama = @mNama),
                    @tgl, @dur, @harga);
            SET @ctr = @ctr + 1;
            SET @s = @s + 1;
        END
        SET @r = @r + 1;
    END
    SET @d = @d + 1;
END
DROP TABLE #Rute;
DROP TABLE #Mk;
GO

-- Riwayat status untuk jadwal baru (Delay untuk sebagian, buat bahan tes Ubah Status).
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
