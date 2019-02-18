# Sustav udruge poduzetnika

- članovi: tvrtke
  - aktivni član: koji je uredno platio članarinu
  - članstvo traje onoliko dana/mjeseci/godina koliko je plaćeno
- tvrtka radi unos informacija o svojoj djelatnostii
  - neke su informacije javno dostupne
  - neke su dostupne samo članovima udruge
- tražilica koja je javno dostupna svima
  - po traženim uvjetima pretražuje samo aktivne članove udruge
- javno dostupan prikaz općih informacija o tvrtkama
- grupiranje članova prema djelatnosti ili kako god žele
- internu komunikaciju između članova (porukama) 
- slanje obavijesti svim članovima ili samo nekim grupama (najave određenih događanja od zajedničkog interesa za sve članove ili samo neke članove i grupe)
- *NEJASNO:* dakle imamo u sustavu i poruke i obavijesti?

## Uloge u sustavu (autorizacija)

### Vlasnik sustava (uloga `Owner`)
- samo jedan vlasnik
- upisuje podatke o udruzi
- kontakt podatke udruge
- predviđene djelatnosti tvrtki koja će biti članovi (List of `Industry`)
- gradove i države

Podaci:
- ime (`Name`)
- prezime (`Surname`)
- korisničko ime tj. adresa elektroničke pošte (`Email`)
- lozinka (`Password`)

- podatke upisuje informatička kuća (`Medvjedi GMbH`) koja je radila sustav

Mogućnosti:
- vlasnik sustava definira i administratore sustava s njihovim ovlastima
- mijenjati, brisati i/ili dodavati informacije o sebi
- mijenjati, brisati i/ili dodavati informacije o svim registriranim korisnicima (`User`)

### Administrator (uloga `Admin`)
- postoje samo dva administratora
- *NEJASNO:* zašto ne bi bilo više administratora?

Podaci:
- ime (`Name`)
- prezime (`Surname`)
- korisničko ime tj. adresa elektroničke pošte (`Email`)
- lozinka (`Password`)
- broj telefona (`Phone`)

Mogućnosti:
- mijenjati, brisati i/ili dodavati informacije o sebi
- mijenjati, brisati i/ili dodavati informacije o svim registriranim korisnicima (`User`)

### Registrirani korisnik (uloga `User`)

Obavezni podaci:
- ime (`Name`)
- prezime (`Surname`)
- korisničko ime tj. adresa elektroničke pošte (`Email`)
- lozinka (`Password`)
- naziv poduzeća (`CompanyName`)
- adresu (ulica i kućni broj, grad, država) (`Address`, `City`, `Country`)
- broj telefona (`Phone`)
- osnovnu djelatnost poduzeća (`Industry`)
- *NEJASNO:* s obzirom da je obavezni podatak ime i prezime pretpostavljamo da se registriraju predstavnici tvrtki? Imaju li tvrtke više predstavnika u sustavu? Postoji li dakle entitet u bazi `tvrtka` i entitet `predstavnik` ili je to sljepljeno u jedno?

Dodatni podaci:
- svoju sliku (`UserPhoto`)
- logo poduzeća (`CompanyLogo`)
- detaljan opis svoje djelatnosti (`Description`)
- link na web stranicu poduzeća (`Website`)
- ključne riječi po kojima će biti pretraživano u tražilici (List of `Keyword`)

Mogućnosti: 
- upisivati podatke o sebi
- slati obavijesti i/ili poruke ostalim registriranim korisnicima (`User`)
- formirati grupu (`Group`)
- organiziranje sastanaka (`Event`)
- stavljanje obavijesti na internu oglasnu ploču (`Announcement`)

### Neregistrirani korisnik (uloga `Public`)

Mogućnosti:
- može vidjeti samo osnovne informacije o udruzi
- *NEJASNO:* s obzirom da imamo tražilicu, trebaju li onda moći vidjeti i članove udruge? Tj. mogu li
vidjeti podatke o pojedinim tvrtkama?

## Funkcionalnosti sustava

### Registracija i prijava (autentikacija)
- korisničko ime je ujedno adresa elektorničke pošte

### Dva dijela sustava
- vlasnik (`Owner`) i administratori (`Admin`) imaju pristup na stranicu i svoj poseban sustav
  - poseban sustav prikazuje: izvještaje, sve korisnike (`User`), grafove itd.
- registrirani korisnik (`User`) ima pristup samo na stranicu

### Grupe korisnika (`Group`)
- korisnik pravi svoju grup/e/u
- *NEJASNO:* može li korisnik imati više svojih grupa?
- realizira se preko pozivnica koje se šalju na elektroničku poštu
- pozvani korisnik mora prihvatiti poziv da bi bio stavljen u grupu

Podaci:
- naziv (`Title`)
- korisnici (List of `User`)

### Slanje obavijesti (`Announcement`)
- svaki registrirani korisnik (`User`) može poslati obavijest
- odabir kome se šalje (svima, samo odabranoj grupi, pojedinačno)
- *NEJASNO:* bolje da se ovo zove "poruke", a ne "obavijesti" jer tako više ima
smisla? Osim ako imamo i poruke i obavijesti.

Podaci:
- korisnik (`UserId`)
- vrsta (`Type` - `everybody`, `group`, `single_user`)
- identifikator vrste (`TypeId` - null ili group_id ili user_id)

### Organiziranje sastanaka (`Event`)
- svaki registrirani korisnik (`User`) može sazvati sastanak
- potvrda dolaska slanjem maila
- vidi se lista ljudi koji dolaze (vide ju samo oni koji dolaze)

Podaci:
- organizator (`UserId`)
- naziv (`Title`)
- datum i vrijeme (`Date`, `Time`)
- ljudi koji su potvrdili dolazak (List of `User`)

### Interna oglasna ploča udruge
- svi registrirani korisnici (`User`) mogu stavljati na oglasnu ploču
- vide ju svi članovi udruge
- obavijest mailom kada se stavi nešto na oglasnu ploču
- *NEJASNO:* Je li interna oglasna ploča ista stvar kao skup obavijesti ili se
još posebno stavlja? Stavljaju li se i poruke na oglasnu ploču? Je li ipak slučaj
da poruke se šalju kao na FB?

Podaci:
- korisnik koji je objavio (`UserId`)
- sadržaj (`Text`)

### Praćenje plaćanja članarina (`Payment`)
- administrator (`Admin`) dobiva podatke koje unosi (npr. o uplatama na žiro račun udruge)
- članstvo traje ovisno ovisno o iznosu uplate (vlasnik udruge definira članarinu i kako se plaća
(mjesečno, godišnje) - po tome vidimo koliko dugo će netko biti član)
- sustav šalje obavijesti o nepodmirenim troškovima članu i vlasniku sustava putem elektroničke
pošte

Podaci:
- tvrtka koja je platila (`UserId`)
- kada je platila (`Date`)
- koliko je platila (`Amount`)

### Izvještaji
- vlasnik i administratori mogu pratiti kada se netko prijavio (`LoginActivity`)
  - registrirani korisnici (`User`) (Tvrtka XY se prijavila u XX:YY:ZZ)
  - administratori (`Admin`) (Administrator XY se prijavio u XX:YY:ZZ)
- broj poruka / objava svakog člana
- *NEJASNO:* dakle imamo poruke i obavijesti. Koja je razlika?
- analiza svih registriranih korisnika prema djelatnosti (`Industry`), gradu (`City`), državi (`Country`)
- analiza dolaznog prometa (neregistiranih korisnika)
  - pretraga (`SearchLog`) (koje djelatnosti (`Industry`), koje ključne riječi (`Keyword`)) 
  - država i grad odakle dolaze (`Visits`) (o. a. pri tome bismo trebali korisniti geolokcijaske
  servise koji iz IP adrese zaključuju) 
  - koje su tvrtke (`User`) neregistirani korisnici pregledavali (pamtimo sve što su posjetili)


