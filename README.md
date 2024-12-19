  # Survivor #
  Bu proje, Survivor yarışması için bir Web API uygulaması geliştirmeyi amaçlamaktadır.
  Proje, Competitors (Yarışmacılar) ve Categories (Kategoriler) tabloları arasında bire çok (one-to-many) ilişki içermektedir.
  Bu API, kullanıcıların CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştirmelerine olanak tanır.

  ## 📂 Proje İçeriği
  
  ### 1. Competitors Tablosu

| Alan       | Veri Tipi | Açıklama                                   |
|------------|-----------|--------------------------------------------|
| Id         | int       | Birincil anahtar, otomatik artar.          |
| Name       | string    | Yarışmacının adı.                         |
| Age        | int       | Yarışmacının yaşı.                        |
| CategoryId | int       | Yarışmacının bağlı olduğu kategori kimliği.|

---

### 2. Category Tablosu

| Alan | Veri Tipi | Açıklama                  |
|------|-----------|---------------------------|
| Id   | int       | Birincil anahtar, otomatik artar. |
| Name | string    | Kategorinin adı.          |

# 🛠️ Kullanılan Teknolojiler
 * ASP.NET Core Web API
 * Entity Framework Core
 * PostgreSQL
 * Swagger (API dokümantasyonu)
   
# 🚀 Kurulum ve Çalıştırma
1. NuGet Paketlerini Yükleyin
Proje dizininde aşağıdaki komutları çalıştırarak gerekli NuGet paketlerini yükleyin:

````
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
````
2. Migration ve Veritabanı Güncelleme
EF Core kullanarak veritabanını oluşturun:
````
dotnet ef migrations add InitialCreate
dotnet ef database update

````

## 📌 CRUD Endpointleri
 - CompetitorController
   * GET /api/competitors - Tüm yarışmacıları listele
   * GET /api/competitors/{id} - Belirli bir yarışmacıyı getir
   * GET /api/competitors/categories/{CategoryId} - Belirli bir kategoriye ait yarışmacıları getir
   * POST /api/competitors - Yeni bir yarışmacı oluştur
   * PUT /api/competitors/{id} - Belirli bir yarışmacıyı güncelle
   * DELETE /api/competitors/{id} - Belirli bir yarışmacıyı sil
- CategoryController
   * GET /api/categories - Tüm kategorileri listele
   * GET /api/categories/{id} - Belirli bir kategoriyi getir
   * POST /api/categories - Yeni bir kategori oluştur
   * PUT /api/categories/{id} - Belirli bir kategoriyi güncelle
   * DELETE /api/categories/{id} - Belirli bir kategoriyi sil




