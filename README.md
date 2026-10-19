# 📚 Online Kütüphane Yönetim Sistemi (WebApplicationProject)

Bu proje, **ASP.NET Core MVC** ve **Entity Framework Core (Code First)** mimarisi kullanılarak geliştirilmekte olan bir web tabanlı kütüphane ve kitap yönetim sistemidir.

> 📌 **Eğitim Durumu:** Kurs eğitimi bu aşamada geçici olarak duraklatılmıştır. Projeye bir süre sonra tekrar devam edilecektir.

---

## 🚀 Kullanılan Teknolojiler ve Kütüphaneler

- **Framework:** .NET 10.0 (ASP.NET Core MVC)
- **ORM / Veritabanı:** Entity Framework Core 10.0 (Code First), Microsoft SQL Server (MSSQL)
- **Tasarım Deseni:** Generic Repository Pattern & Entity-Specific Repositories
- **Dependency Injection:** ASP.NET Core yerleşik DI konteyneri
- **Frontend / UI:** Bootstrap 5, Razor Views (.cshtml), HTML5, CSS3, JavaScript
- **Veri Doğrulama:** DataAnnotations & Unobtrusive Client-Side Validation

---

## 📁 Proje Mimarisi

```
WebApplicationProject/
│
├── WebApplicationProject/
│   ├── Controllers/
│   │   ├── BookCategoryController.cs     # Kitap türleri CRUD operasyonları
│   │   ├── BookController.cs             # Kitap CRUD (Ekle/Güncelle, Sil, Listeleme)
│   │   └── HomeController.cs             # Ana sayfa ve genel yönlendirmeler
│   │
│   ├── Models/
│   │   ├── Context/
│   │   │   └── Context.cs                # EF Core DbContext sınıfı
│   │   ├── Entities/
│   │   │   ├── BookCategory.cs           # Kitap türü entity sınıfı
│   │   │   └── Book.cs                   # Kitap entity sınıfı (Foreign Key ilişkili)
│   │   └── Repository/
│   │       ├── IRepository.cs            # Generic Repository interface
│   │       ├── Repository.cs             # Generic Repository implementasyonu
│   │       ├── IBookCategoryRepository.cs# Kategoriye özel repository interface
│   │       ├── BookCategoryRepository.cs # Kategori repository sınıfı
│   │       ├── IBookRepository.cs        # Kitap repository interface
│   │       └── BookRepository.cs         # Kitap repository sınıfı
│   │
│   ├── Migrations/                       # EF Core Migration geçmişi
│   │   ├── 20261011154446_mig1.cs        # BookCategories tablosu oluşturuldu
│   │   ├── 20261018132807_mig2.cs        # Books tablosu oluşturuldu
│   │   └── 20261018141832_mig3.cs        # Books - BookCategories Foreign Key ilişkisi
│   │
│   ├── Views/
│   │   ├── Book/
│   │   │   ├── Index.cshtml              # Kitap listesi, kapak görselleri ve kategori rozetleri
│   │   │   ├── EkleGuncelle.cshtml       # Birleşik kitap ekleme/güncelleme (Upsert) formu
│   │   │   └── Sil.cshtml                # Kitap silme onay ekranı
│   │   ├── BookCategory/
│   │   │   ├── Index.cshtml              # Kategori listesi
│   │   │   ├── CategoryAdd.cshtml        # Kategori ekleme formu
│   │   │   ├── Guncelle.cshtml           # Kategori güncelleme formu
│   │   │   └── Sil.cshtml                # Kategori silme ekranı
│   │   └── Shared/
│   │       ├── _Layout.cshtml            # Ana şablon ve menü (navbar)
│   │       └── _ValidationScriptsPartial.cshtml
│   │
│   └── wwwroot/
│       ├── img/                          # Kitap kapak görselleri
│       ├── css/                          # site.css ve tema stilleri
│       └── lib/                          # Bootstrap & jQuery kütüphaneleri
│
├── WebApplicationProject.slnx            # Çözüm dosyası
└── README.md                             # Proje dökümantasyonu
```

---

## ✅ Tamamlanan Modüller ve Özellikler

1. **Kitap Türü (Kategori) Yönetimi:**
   - Kitap türü ekleme, güncelleme, silme ve listeleme operasyonları tamamlandı.
   - Validasyon kuralları (`[Required]`, `[StringLength]`) uygulandı.
   - `TempData` mekanizması ile başarılı işlem bildirimleri sağlandı.

2. **Kitap Yönetimi:**
   - Kitap ekleme, güncelleme, silme ve listeleme operasyonları tamamlandı.
   - Tek ekranda birleşik **Ekle / Güncelle (Upsert)** yapısı kurgulandı.
   - 10 adet klasik eser için özel kapak görseli (`wwwroot/img/`) entegre edildi.

3. **Veritabanı İlişkileri (Foreign Key - 1:N):**
   - `Book` tablosu ile `BookCategories` tablosu `CategoryId` üzerinden bağlandı.
   - `IRepository` ve `Repository` sınıflarına `includeProperties` desteği eklendi; Eager Loading ile kitap listesinde ilişkili kategori adı (`BookCategory.CategoryName`) dinamik olarak görüntülendi.
   - Kitap ekleme ve güncelleme formuna kategorileri listeleyen dinamik dropdown (`<select asp-for="CategoryId">`) entegre edildi.

4. **Mimari Altyapı:**
   - Generic Repository Pattern uygulanarak veri erişim katmanı soyutlandı.
   - Dependency Injection ile servisler `Program.cs` üzerinde yapılandırıldı.

---

## ⏳ Gelecek Adımlar (Eğitim Devam Ettiğinde Yapılacaklar)

- [ ] **Kullanıcı Rol ve Yetkilendirme (Identity):** Admin ve Öğrenci rolleri, `_LoginPartial` ve kimlik doğrulama modülü.
- [ ] **Kitap İşlemleri & Kiralama:** Kullanıcıların kitap ödünç alma / kiralama süreçleri.
- [ ] **Dinamik Dosya Yükleme:** Form üzerinden `IFormFile` ile fiziksel resim yükleme ve wwwroot'a kaydetme.
- [ ] **Arama ve Filtreleme:** Kategoriye veya yazar adına göre kitap filtreleme.

---

## 🛠️ Kurulum ve Çalıştırma

1. **Projeyi klonlayın:**
   ```bash
   git clone https://github.com/enesduvan/WebApplicationProject.git
   cd WebApplicationProject/WebApplicationProject
   ```

2. **Bağlantı dizesini kontrol edin:**
   [appsettings.json](file:///C:/Users/enes/Desktop/ders/asp.net/WebApplicationProject/WebApplicationProject/appsettings.json) içerisindeki `DefaultConnection` bağlantı dizesinin yerel MSSQL sunucunuza uygun olduğunu doğrulayın.

3. **Veritabanı migration'larını uygulayın:**
   ```bash
   dotnet ef database update
   ```

4. **Projeyi çalıştırın:**
   ```bash
   dotnet run
   ```

5. Tarayıcınızdan `http://localhost:5277` adresine giderek uygulamayı görüntüleyebilirsiniz.
