#
[![wakatime](https://wakatime.com/badge/user/928d8e72-2751-489c-8fd4-04b452024ef1/project/e76e05ac-30a0-4c47-999c-29c9119c215f.svg)](https://wakatime.com/badge/user/928d8e72-2751-489c-8fd4-04b452024ef1/project/e76e05ac-30a0-4c47-999c-29c9119c215f)
#
## 1.	Opis wybranego tematu, funkcjonalności systemu.
Aplikacja webowa umożliwiająca tworzenie własnych półek w celu dodania książek. Również umożliwia przeglądanie listy książek oraz listy autorów oraz przeglądanie informacji o nich.       
## 2.	Opis wybranego stosu technologicznego

•	C#: Jest to język programowania ogólnego przeznaczenia, rozwijany przez firmę Micro-soft. C# jest często wykorzystywany do tworzenia aplikacji dla platformy .NET.

•	.NET Core: To wieloplatformowy framework open-source, również opracowany przez Microsoft. .NET Core umożliwia tworzenie aplikacji na różne systemy operacyjne, takie jak Windows, macOS i Linux.

•	Angular: Jest to framework JavaScript stworzony przez firmę Google. Angular umożli-wia tworzenie aplikacji internetowych i mobilnych. Jest często wykorzystywany w połą-czeniu z HTML i CSS.

•	HTML: Jest to język znaczników wykorzystywany do tworzenia struktur i treści stron internetowych. HTML definiuje elementy strony, takie jak nagłówki, akapity, obrazy itp.

•	CSS: Jest to język arkuszy stylów, który służy do określania wyglądu i formatowania stron internetowych. CSS definiuje style, takie jak kolory, czcionki, marginesy itp.

•	Bootstrap: Jest to framework CSS, który ułatwia tworzenie responsywnych i estetycz-nych stron internetowych. Bootstrap oferuje gotowe komponenty i stylizację, które moż-na łatwo włączyć do projektu.

•	MariaDB: Jest to system zarządzania bazą danych oparty na MySQL. MariaDB jest rozwinięciem MySQL i oferuje wiele funkcji i ulepszeń w porównaniu z oryginalnym sys-temem.

## Oraz krótki opis większości użytych bibliotek:

•	FluentValidation: biblioteka do walidacji danych w aplikacjach .NET. Zapewnia bar-dziej ekspresywny i deklaratywny sposób definiowania reguł walidacji. Może być uży-wana wraz z różnymi frameworkami, takimi jak ASP.NET Core, MVC itp.

•	MediatR: biblioteka do implementacji wzorca mediatora w aplikacjach .NET. Wzorzec mediatora pomaga w odseparowaniu logiki biznesowej od komunikacji między kompo-nentami. MediatR ułatwia obsługę żądań, zapytań i zdarzeń, umożliwiając łatwą komu-nikację między różnymi częściami aplikacji.

•	IdentityServer: biblioteka do uwierzytelniania i autoryzacji w aplikacjach .NET. Identi-tyServer to narzędzie open-source, które umożliwia implementację protokołów uwierzy-telniania, takich jak OAuth 2.0 i OpenID Connect. Może być wykorzystywane do bu-dowania bezpiecznych systemów uwierzytelniania jednoznakowego (SSO) i zarządzania tożsamością.

•	Diagnostics.EntityFrameworkCore: zawiera zestaw narzędzi i funkcji diagnostycz-nych dla Entity Framework Core. Umożliwia monitorowanie wydajności, debugowanie i śledzenie zapytań SQL, rejestrowanie zdarzeń i wiele innych narzędzi, które mogą po-móc w analizie i optymalizacji działania aplikacji opartych na Entity Framework Core.

•	Identity.EntityFrameworkCore: biblioteka dostarczająca funkcjonalności zarządzania tożsamością, takie jak uwierzytelnianie, autoryzacja, role i uprawnienia w aplikacjach opartych na Entity Framework Core. Umożliwia przechowywanie i zarządzanie użyt-kownikami, rolami, hasłami i innymi informacjami związanymi z tożsamością w bazie danych.

•	Pomelo.EntityFrameworkCore.MySql: Biblioteka rozszerzająca funkcjonalności Entity Framework Core w celu umożliwienia komunikacji z bazą danych w systemie MariaDB.

•	Identity.UI: biblioteka dostarczająca gotowe widoki i interfejs użytkownika dla funk-cjonalności zarządzania tożsamością dostarczanych przez bibliotekę Identi-ty.EntityFrameworkCore. Umożliwia szybkie wdrożenie panelu administracyjnego, w którym można zarządzać użytkownikami, rolami, hasłami itp.

•	SpaProxy: biblioteka służąca do tworzenia interfejsu API (Application Programming In-terface) dla aplikacji jednostronicowych (Single Page Applications - SPA). Umożliwia komunikację między front-endem aplikacji SPA a backendem poprzez automatyczne ge-nerowanie kodu proxy, co upraszcza proces integracji między dwoma warstwami.

•	EntityFrameworkCore.Relational: część Entity Framework Core, która zapewnia na-rzędzia i funkcje dla baz danych

## 3.	Opis jak uruchomić aplikację 
Aby uruchomić projekt należy wykonać następujące kroki:
1.	Zainstalować wymagane oprogramowanie:
a.	Visual Studio
b.	.Net 7.0
c.	Node.js
d.	Angular cli
2.	Należy zaktualizować plik appsettings.json w którym znajduję się connection string do bazy danych MariaDb utworzonej na allwaysdata.com.
3.	Należy uruchomić projekt klikając kompilacje.
4.	Zostanie uruchomiony backend z proxy które będzie oczekiwało na włączenie frontendu który uruchomi się po chwili.
5.	Aplikacja jest gotowa do działania.
 



