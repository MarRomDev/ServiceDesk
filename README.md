# 🛠️ ServiceDesk

**ServiceDesk** to system zgłoszeń serwisowych typu HelpDesk stworzony w architekturze Clean/CQRS. Projekt służy jako demonstracja wiedzy z zakresu projektowania nowoczesnych aplikacji backendowych w .NET 8.

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)
![Status](https://img.shields.io/badge/status-in%20development-yellow)

---

## 📦 Stack technologiczny

| Warstwa        | Technologie |
|----------------|-------------|
| Backend        | ASP.NET Core 8 |
| Messaging      | RabbitMQ |
| Architektura   | Clean Architecture + CQRS + MediatR |
| Baza danych    | PostgreSQL + EF Core 8 |
| Mapowanie      | AutoMapper |
| Konteneryzacja | Docker (planowane) |

---

## 📁 Struktura projektu

```
ServiceDesk.sln
├── ServiceDesk.Api              # Warstwa prezentacji (kontrolery HTTP)
├── ServiceDesk.Application      # CQRS, Handlery, DTO, mapping
├── ServiceDesk.Domain           # Logika biznesowa i encje
├── ServiceDesk.Infrastructure   # Integracje z RabbitMQ itp.
├── ServiceDesk.Persistence      # EF Core + konfiguracja bazy danych
├── ServiceDesk.Shared           # Rozszerzenia i interfejsy wspólne
```

---

## ✅ Funkcje już zaimplementowane

- [x] Tworzenie zgłoszenia (`POST /api/tickets`)
- [x] Pobieranie zgłoszenia po ID (`GET /api/tickets/{id}`)
- [x] CQRS + MediatR + Handlery
- [x] Mapowanie encji do DTO
- [x] Integracja z RabbitMQ (Consumer)
- [x] Konfiguracja EF Core i PostgreSQL
- [ ] Aktualizacja appsettings w celu ustawienia Seriloga
- [ ] Dodanie interfejsu do połączenia projektu Application z bazą
- [ ] Publikacja eventów do RabbitMQ (w trakcie)
- [ ] Frontend w React (planowany)

---

## 📬 Przykładowe zapytania HTTP

### Tworzenie zgłoszenia

```
POST /api/tickets
Content-Type: application/json

{
  "title": "Problem z drukarką",
  "description": "Nie drukuje od rana"
}
```

### Pobieranie zgłoszenia

```
GET /api/tickets/{id}
```

---

## 🔮 Roadmapa

- [ ] 🔧 CRUD dla zgłoszeń
- [ ] ⏳ Obsługa statusów (open, closed, in-progress)
- [ ] ✅ Logowanie z Serilog
- [ ] ⏳ Rejestracja użytkowników
- [ ] ⏳ Frontend w React (Next.js)
- [ ] 🔧 Docker Compose + PostgreSQL + RabbitMQ

---

## 🧪 Testowanie (planowane)

- [ ] Testy jednostkowe handlerów
- [ ] Testy integracyjne endpointów
- [ ] Testy komunikacji RabbitMQ

---

## 🚀 Jak uruchomić projekt lokalnie

1. Skonfiguruj bazę danych PostgreSQL:

   ```
   Host: localhost
   Port: 5432
   Username: postgres
   Password: postgres
   ```

2. Uruchom migracje EF Core (jeśli już dodane):

   ```bash
   dotnet ef database update --project ServiceDesk.Persistence
   ```

3. Uruchom projekt API:

   ```bash
   dotnet run --project ServiceDesk.Api
   ```

4. Domyślny adres:

   ```
   https://localhost:5001/api/tickets
   ```

---

## 🔗 Przydatne linki

- [Swagger UI](https://localhost:5001/swagger/index.html)
- [RabbitMQ Management UI](http://localhost:15672)

---

## 💡 Dlaczego ten projekt?

Projekt został stworzony w celu:
- utrwalenia dobrych praktyk architektury (Clean, CQRS),
- opanowania MediatR i Messagingu z RabbitMQ,
- lepszego przygotowania pod rozwiązania produkcyjne,
- jako część portfolio programisty .NET.

---

## 🧠 Autor

**Marcin Romanowski**  
Mid .NET Developer / Fullstack  
Email: marcin.romanowski.developer@gmail.com

---

## 📄 Licencja

Projekt dostępny na licencji MIT.