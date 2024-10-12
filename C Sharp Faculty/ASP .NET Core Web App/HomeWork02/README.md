# Практическое задание

Необходимо реализовать ASP.NET Core MVC приложение с разделением логики на уровень контроллеров, сервисов и репозиториев.
Для уровня сервисов и репозиториев нужно использовать интерфейсы.
Приветствуется соблюдение принципов SOLID а также применение Dependency Injection встроенными средствами платформы ASP.NET Core.


Предлагаем создать api для работы с коллекцией persons:
* GET /persons/{id} — получение человека по идентификатору
* GET /persons/search?searchTerm={term} — поиск человека по имени
* GET /persons/?skip={5}&take={10} — получение списка людей с пагинацией
* POST /persons — добавление новой персоны в коллекцию
* PUT /persons — обновление существующей персоны в коллекции
* DELETE /persons/{id} — удаление персоны из коллекции

Класс Person:

```csharp
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Company { get; set; }
    public int Age { get; set; } 
}
```