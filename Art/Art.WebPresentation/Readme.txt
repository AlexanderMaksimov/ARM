 https://docs.microsoft.com/ru-ru/ef/core/get-started/aspnetcore/existing-db
 https://www.entityframeworktutorial.net/efcore/entity-framework-core-console-application.aspx
 миграции для создания базы данных.
Visual Studio
Интерфейс командной строки .NET Core
Последовательно выберите пункты Средства > Диспетчер пакетов NuGet > Консоль диспетчера пакетов.
Выполните следующие команды:

Установите стартовый пакет на проект в котором будет осуществлена миграция
Add-Migration InitialCreate
EntityFrameworkCore\Add-Migration ArticleArt -Context ArticleDbContext

Update-Database
EntityFrameworkCore\Update-Database -Context ArticleDbContext

Если появляется сообщение об ошибке The term 'add-migration' is not recognized as the name of a cmdlet, закройте и снова откройте Visual Studio.
Команда Add-Migration формирует шаблон миграции для создания начального набора таблиц в модели. Команда Update-Database создает базу данных и применяет к ней созданную миграцию.