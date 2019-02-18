# Upute za instalaciju

Za instalaciju korisnik će treba sljedeće radne okvira i programe:
- .Net Core 2.0
- PostgreSQL bazu podatka

Instalacijske upute će se bazirati na Linux platformu zbog raširenosti servera
koji su bazirani na Linux platformi. Pretpostavljana distribucija Linuxa će biti
Ubuntu 16.04 zbog svoje jednostavnosti. Sličnim analognim postupcima korisnik
može instalirati programsko rješenje i na Windows platformi, međutim u ovim
uputama se nećemo time baviti.

## .Net Core 2.0

Preporučujemo pročitati upute na sljedećoj stranici radi stjecanja dodatnog znanja:
https://www.microsoft.com/net/learn/get-started/linuxubuntu.

Slijedi minimalno potreban niz koraka za instalaciju na Ubuntu 16.04.

### 1. Potrebano ja za početak dodati GPG ključ radi verifikacije instalacijskog postupka.

`curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg`

`sudo mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg`

### 2. Dodavanje potrebnih PPA repozitorija za instalaciju

`sudo sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-xenial-prod xenial main" > /etc/apt/sources.list.d/dotnetdev.list'`

### 3. Instalacija potrebnih programa

`sudo apt-get apt-transport-https`

`sudo apt-get update`

`sudo apt-get install dotnet-sdk-2.1.4`

Sada smo spremi koristiti program `dotnet` u naredbenom retku koji će nam služiti
za razvoj i za stvaranje izvršne datoteke.

## PostgreSQL

Ubuntu 16.04 već ima potrebne veze na programske pakete u svojim repozitorijama
pa je instalacija nešto jednostavnija. Postupak namještanja, međutim je malo duži.

### 1. Instalacija potrebnih programa

`sudo apt-get update`

`sudo apt-get install postgresql postgresql-contrib`

### 2. Izrada novog korisnika za spajanje

Za početak ćemo se prebaciti u način rada kao korisnik `postgres`.

`sudo -i -u postgres`

Kreiramo novog korisnika za spajanje na bazu. {ime} zamijeniti sa željenim imenom
korisnika:

`createuser --interactive`

Unesemo {ime} kao ime korisnika i odaberemo da je korisnik `superuser`.

### 3. Izrada nove baze podataka

Kreiramo bazu podataka s imenom {ime_baze}:

`createdb {ime_baze}`

Prijavimo se u bazu podataka:

`psql`

Izvršimo sljedeću naredbu kako bismo promijenili lozinku na {lozinka}:

`ALTER USER sup WITH PASSWORD '{lozinka}';`

### 4. Izlazak iz korisnika `postgres`

`exit`

## Izmjena postavki

Potrebno je urediti datoteku `appsettings.json` i postaviti ključ `ConnectionString`
na prikladnu vrijednost. Pri tome mislimo na postavljanje odabranog imena baze
podataka, korisnika baze podataka i lozinke za tog korisnika.

## Pokretanje razvojnog načina i izrada izvršne datoteke

Prvi puta nakon namještanja naše aplikacije potrebno je skinuti sve vezane biblioteke
pokretanje sljedeće naredbe:

`dotnet restore`

Prvi puta nakon namještanja baze podataka potrebno je pokrenuti sljedeću
naredbu kako bi se baza podataka stvorila:

`dotnet ef database update`

Našu aplikaciju možemo razvijati pokretanje sljedećih naredbi:

`dotnet run`

Našu aplikaciju možemo izraditi u izvršnu datoteku pomoću:

`dotnet build`

