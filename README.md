# SheinMagistracy

## Описание проекта

Этот проект представляет собой веб-приложение для управления учебным расписанием и заданиями. Реализовано на ASP.NET Core 5.0 MVC с использованием Entity Framework и базы данных MSSQL. Развёрнуто на VPS с использованием Nginx.

Сайт: https://sheinmag.ru/

Пользователь может:
- Просмотреть текущее расписание, ближайшее задание, весь список заданий или предметов;
- Создавать, удалять и обновлять задания или предметы.

## Основные странцы

### 1. Главная страница (Home)
Отображает:
- Текущую неделю (нижняя или верхняя);
- Таблицу с расписанием занятий на неделю;
- Карточку с ближайшим заданием.

### 2. Страница задач (Exercise)

Содержит таблицу задач, каждая из который имеет:
- Название;
- Описание; 
- Дату получения;
- Дату сдачи;
- Изображение;
- Ссылку на соответствующий предмет.

### 3. Страница предметов (Subject)

Содержит таблицу предметов с:
- Названием; 
- ФИО преподавателя. 

## Технологии

- **Backend:** ASP.NET Core 5.0
- **Frontend:** Razor Pages (cshtml)
- **ORM:** Entity Framework Core
- **База данных:** MSSQL
- **Файловое хранилище:** Локальное хранение на сервере
- **Сервер:** VPS с Nginx

## Запуск проекта локально

### 1. Установка зависимостей

```sh
 dotnet restore
```

### 2. Настройка базы данных

Настройте `appsettings.json`:

```json
 "ConnectionStrings": {
   "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DB;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
 }
```

Примените миграции:

```sh
 dotnet ef database update
```

### 3. Запуск 

```sh
 dotnet run
```
