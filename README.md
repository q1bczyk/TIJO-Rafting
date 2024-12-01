Testowanie i Jakość Oprogramowania
=============
### **Autor**
##### **Bartosz Kubik**



# **Aplikacja do rezerwacji spływów kajakowych i pontonowych**

### Opis 
Aplikacja pozwala użytkownikom na szybkie i łatwe zarezerwowanie spływu na kajaku bądź pontonie. Aplikacja składa się z dwóch częsci, części prywatnej przeznaczonej dla administratora systemu, pozwalającej na konfigurowanie usług np na dodawanie sprzętu na podstawie, którego system określa dostępność spływu w danym terminie. Kolejna część przeznaczona jest dla klientów, którzy chcą skorzystać z usług. Część zawiera kilku etapowy formualrz do rezerwacji spływu oraz wyboru sprzętu.


### Uruchamianie aplikacji
1. Pobrac pliki z repozytorium
2. Wypakować aplikacje
3. Uruchomić konsolę, przejść do folderu zawierającego apliakcje
4. Przy pierwszym uruchomieniu wpisać komendę "docker build"
5. Wpisać komendę "docker compose-up"
6. Aplikacja będzie dostępna w przeglądarce na ścieżce localhost:4200

### Testy
Testy w późniejszej fazie projektu

### Dokumentacja API
Dokumentacja swagger dołaczona zostanie później

### Przypadki testowania dla testera maualnego

Późniejsza faza projektu

### Technologie użyte w Projekcie 

##### 1. .NET
Platforma programistyczna opracowana przez Microsoft, obejmująca środowisko uruchomieniowe oraz biblioteki klas dostarczające standardowe funkcjonalności dla aplikacji. Środowisko wspiera kilka języków programowania, projekt napisany jest w języku C#.

##### 2. PostgreSql
PostgreSQL jest obiektowo-relacyjnym systemem do zarządzania bazą danych wykorzystującą język SQL. System udostępnia wiele funkcji pozwalających między innymi na wykonywanie oraz optymalizowanie zapytań SQL, tworzenie i wykonywanie procedur, wykonywanie transakcji.

##### 3. Angular
Angular to framework zaprojektowany przez Google, który korzysta z języka TypeScript. Angular pozwala na szybkie budowanie aplikacji webowych. Początkowo Angular pozwalal na budowanie aplikacji jednostronicowe ale ostatnie aktualizacje wzbogaciły framweork w renderowanie po stronie serwera. 


3. **Angular:** Frontend odpowiada za interfejs użytkownika, wysyła żądania do backendu (Express.js) i wyświetla dane użytkownikowi.
4. **Node.js:** Służy jako fundament dla Express.js i umożliwia obsługę serwera.

Ten stos technologiczny pozwala na pełne tworzenie aplikacji webowych od bazy danych po interfejs użytkownika.

