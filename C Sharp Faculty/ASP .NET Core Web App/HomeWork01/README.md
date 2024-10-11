# Практическое задание

Представим, что мы работаем с api системы блогов. Перед нами поставлена задача получить
несколько постов сразу, обработать содержимое ответа и записать результат в текстовый файл.
Метод получения поста представлен следующим образом: __GET /posts/{id}__, где id - идентификатор
поста.

Формат ответа:

```
{
"userId": 2,
"id": 14,
"title": "voluptatem eligendi optio",
"body": "fuga et accusamus dolorum perferendis illo"
}

```

Необходимо написать консольное приложение, которое выполнит асинхронно 10 HTTP-запросов на
получение постов из блога, по целочисленному идентификатору, начиная с id=4 по id=13. Для
выполнения запросов необходимо использовать HttpClient (см.
https://docs.microsoft.com/ru-ru/dotnet/api/system.net.http.httpclient?view=net-5.0).

В результате работы программы должен получиться текстовый файл под названием result.txt, в
котором сохранена полученная информация о постах в следующем формате:

```
userId
id
title
body
```

Между постами присутствует пробел. Так, содержимое файла может выглядеть следующим образом:

```
1
4
eum et est occaecati
ullam et saepe reiciendis voluptatem adipisci\nsit amet autem assumenda provident rerum culpa\nquis hic
commodi nesciunt rem tenetur doloremque ipsam iure\nquis sunt voluptatem rerum illo velit

1
5
nesciunt quas odio
repudiandae veniam quaerat sunt sed\nalias aut fugiat sit
```

Всего в файле должно оказаться 10 постов.

[Документация к api](https://jsonplaceholder.typicode.com/)

[Метод получения поста по id](https://jsonplaceholder.typicode.com/posts/1)