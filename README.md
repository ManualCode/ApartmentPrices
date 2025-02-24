# ApartmentPrices
Сервис, позволяющий следиить за изменением цены любой квартиры на prinzip.su.
API реализует два метода:
- HTTP POST(email, url): метод для подписки на изменение цены. На вход получает - email на который присылать уведомления и ссылку на
объявление.
- HTTP GET(email): метод возвращает актуальные цены квартир, для которых выполнена подписка, и
ссылки на эти квартиры. На вход получает - email с которого выполнялась подписка.

## Примерная схема архетиктура проекта:
![image](https://github.com/user-attachments/assets/b0c8fc55-9c30-4758-802b-733e98a035a0)

## Используемый стек:
- Backend: .NET Core 8, ASP.NET Core, Entity Framework, Quartz, MailKit, AutoMapper, MS SQL, Swagger, Docker.
