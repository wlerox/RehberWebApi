Projede kullanılanlar
  * Proje SOA yaklaşımı benimsenmiştir.
  * .Net Core 3.1
  * Entity Framework Core Code-first
  * Dependency Injection
  * Dto(data transfer object) and Mapper
  * Redis
  * Docker
  * Swagger

Proje docker çalıştıramadığım için normal sql server ve masaüstü redis kullanılarak geliştirildi. Eğerki çalıştırılacak bilgisayarda redis masaüstü ve sgl server var ise 
redis ve sql serverın connection stringlerini Proje içerisinde Rehber.API içerisinde appsettings.Development.json dosyasının içerinde olan ilgili yerlere eklenmesi gerekir.
Proje bu şekilde ayağa kaldırılırsa veri tabanını otomatik oluşturup https://localhost:5001/swagger/index.html adresinden ayağa kalkacaktır. Proje eger docker üzerinden 
çalıştırılmaya kalkarsa 
sgl server için connection string = "Server = sqlserver_Db,1433 ; Database = PersonDb; uid = sa; pwd = a123456!;Trusted_Connection=false;MultipleActiveResultSets=true;"
redis için  connection string = "redis_cache:6379,abortConnect=False"  şekilde ayarlanmalıdır.Docker dan ayağa kaltığında swagger gelmesi için gelen adresin yanına
/swagger yazmak gerekebilir. 
