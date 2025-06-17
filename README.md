# ServiceDesk
Aplikacja webowa do zarządzania zgłoszeniami serwisowymi z rolami użytkowników i systemem zdarzeń.

## Funkcjonalności MVP (Minimum Viable Product)
### Role
- User – może zgłaszać i komentować zgłoszenia
- Technik – widzi przypisane zgłoszenia, może zmieniać status
- Admin – zarządza użytkownikami i kategoriami

### Zgłoszenia
- Tytuł, opis, załączniki (opcjonalnie)
- Priorytet (niski, średni, wysoki)
- Status: Nowe → W trakcie → Zakończone
- Historia zmian (z timestampem)

### Inne
- Filtrowanie i sortowanie
- Komentarze do zgłoszeń
- Panel administracyjny (kategorie, użytkownicy)

## Technologie
| Obszar      | Technologia                                   |
| ----------- | --------------------------------------------- |
| Backend     | ASP.NET Core 8, EF Core, REST API, AutoMapper |
| Frontend    | Vue 3, Pinia, TypeScript, Axios, Vite         |
| Baza danych | PostgreSQL                                    |
| Komunikacja | RabbitMQ (opcjonalnie – np. logi zdarzeń)     |
| CI/CD       | GitHub Actions / GitLab CI/CD                 |
| DevOps      | Docker, docker-compose, Swagger, PowerShell   |
| Testy       | XUnit / Playwright (opcjonalnie)              |
