Proje veritabanı -'db_riseTechnology' klasörü altında- restore edilir.
Proje dosyaları içindeki PersonAPI.sln ile proje açılıp çalıştırılır.

Solution içinde iki API(personAPI-> rehberdeki kişiler için, ReportService -> arkaplan servis), bir unit test projesi ve bir web projesi bulunmaktadır.

Web üzerinden ilk ekranda kişi listesi görüntülenmektedir. Kişi silme, kişi güncelleme ve yeni bir kişi eklenebilmektedir.
Kişiler üzerindeki işlemler için unit testler yazıldı.
Aynı zamanda Report menüsünden raporlar listelenmektedir.

ReportAPI tarafında Kafka ile rapor oluşturmak istedim ancak bu kısım eksik kaldı.
