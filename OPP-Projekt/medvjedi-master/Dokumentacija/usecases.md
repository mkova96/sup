# Use case-ovi

## UC1 – registracija
Glavni sudionik: Neregistrirani korisnik
Cilj: Registrirati korisnika i uvesti u bazu podataka
Sudionici: Baza Podataka
Preduvjeti:
Rezultat: Registracija korisnika i njegovo uvođenje u bazu podataka
Željeni scenarij:
1) Neregistrirani korisnik unosi svoje podatke u sustav
2) Baza podataka ih sprema
Mogući drugi scenarij:
1) Neregistrirani korisnik unosi svoje podatke u sustav
2) U bazi podataka već postoji korisnik s istim podatcima te sustav odbija registraciju

## UC2 – prijava
Glavni sudionik: Registrirani korisnik
Cilj: Prijava na sustav
Sudionici: Baza podataka
Preduvjeti: Korisnik mora biti registriran
Rezultat: Korisnik dobiva veći spektar sadržaja i funkcionalnosti stranice
Željeni scenarij:
1) Registrirani korisnik unosi korisničko ime i lozinku
2) Sustav provjerava podatke s bazom podataka te prosljeđuje korisnika na početnu stranicu
Mogući drugi scenarij:
1) Registrirani korisnik unosi korisničko ime i lozinku
2) Ako korisničko ime ili lozinka nije točna, sustav mu dojavljuje

## UC3 – pregled obavijesti
Glavni sudionik: Prijavljeni korisnik
Cilj: Uvid u obavijesti
Sudionici: Baza podataka
Preduvjeti: Prijava na sustav
Rezultat: Otvara se prozor s listom obavijesti
Željeni scenarij:
1) Korisnik odabire ikonu s obavijestima
2) Otvara se prozor s obavijestima
Mogući drugi scenarij:

## UC4 – dodavanje nove obavijesti
Glavni sudionik: Prijavljeni korisnik
Cilj: Omogućiti korisniku opciju kreiranja obavijesti
Sudionici: Registrirani korisnici, baza podataka
Preduvjeti: Korisnik mora biti prijavljen
Rezultat: Dodana nova obavijest
Željeni scenarij:
1) Korisnik odabire opciju kreiranja obavijesti
2) Korisnik ispunjava tekst obavijesti
3) Korisnik odabire korisnike kojima će obavijest biti dostupna
4) Obavijest se kreira
Mogući drugi scenarij:
1) Obavijest ima grešaka, zahtijeva se uređivanje

## UC5 – uređivanje obavijesti
Glavni sudionik: Prijavljeni korisnik
Cilj: Omogućiti korisniku izmjenu obavijesti
Sudionici: Baza podataka
Preduvjeti: Obavijest je kreirana i korisnik je prijavljen
Rezultat: Izmjena obavijesti
Željeni scenarij:
1) Korisnik odabire opciju uređivanja obavijesti
2) Korisnik izmjenjuje željene pojedinosti
3) Korisnik potvrđuje izmjene
4) Izmjene se spremaju u bazu podataka
Mogući drugi scenarij:
1) Korisnik odabire opciju uređivanja obavijesti, ali ništa ne mijenja
2) Korisnik odabire opciju uređivanja obavijesti, mijenja, ali ne sprema izmjene

## UC6 – pregled grupa
Glavni sudionik: Prijavljeni korisnik
Cilj:Pregledati grupe u koje je korisnik učlanjen i grupe koje je formirao
Sudionici:Baza podataka
Preduvjeti:Korisnik je prijavljen i član barem jedne grupe
Rezultat: Otvara se prozor s popisom grupa koje su vezane za korisnika
Željeni scenarij:
1) Korisnik pregledava grupe i njihove članove
Mogući drugi scenarij:-

## UC7 – formiranje grupa
Glavni sudionik:Prijavljeni korisnik
Cilj: Stvaranje grupe korisnika bliskih djelatnosti
Sudionici:Baza podataka
Preduvjeti:Korisnik je prijavljen
Rezultat: Otvara se prozor s mogućnostima stvaranja nove grupe
i unosom određenih podataka vezanih za grupu
Željeni scenarij:
1) Korisnik unosi podatke vezane za grupu
2) Korisnik odabire ostale korisnike koje želi u grupi
Mogući drugi scenarij:-

## UC8 – uređivanje grupa
Glavni sudionik:Prijavljeni korisnik
Cilj:Uređivanje postojećih podataka o grupi
Sudionici:Baza podataka
Preduvjeti:Korisnik je prijavljen
Rezultat: Otvara se prozor s podacima o grupi koji se mogu izmjenjivati
Željeni scenarij:
1)Korisnik izmjenjuje željene podatke o grupi
2)Korisnik prihvaća promjene pritiskom na gumb "Potvrdi"
Mogući drugi scenarij:
1)Korisnik odustaje od promjena pritiskom na gumb "Odustani"

## UC9 – dodavanje članova u grupe
Glavni sudionik:Prijavljeni korisnik
Cilj:Slanje zahtjeva za pridruživanje grupi korisnika slične djelatnosti
Sudionici:Baza podataka
Preduvjeti:Korisnik je prijavljen
Rezultat:Otvara se prozor s mogućnostima dodavanja člana u grupu
Željeni scenarij:
1)Korisnik šalje zahtjev za pridruživanje grupi drugom korisniku
Mogući drugi scenarij:

## UC10 – odgovor na dodavanje u grupu
Glavni sudionik:Prijavljeni korisnik
Cilj:Odgovaranje na zahtjev o pridruživanju određenoj grupi
Sudionici:Prijavljeni korisnik, baza podataka
Preduvjeti:Korisnik je prijavljen
Rezultat:Korisnik koji je poslao zahtjev za ulazak u grupu dobiva povratnu
informaciju od strane drugog korisnika
Željeni scenarij:
1)Korisnik prihvaća zahtjev za ulazak u grupu
Mogući drugi scenarij:
1)Korisnik odbija zahtjev za ulazak u grupu


## UC11 – pregled sastanaka
Glavni sudionik: Prijavljeni korisnik
Cilj: Dobivanje informacija vezanih za sastanak.
Sudionici: Baza podataka
Preduvjeti: Prijavljeni korisnik se nalazi na stranici za sastanke te je potvrdio svoj dolazak na sastanak.
Rezultat: Otvara se prozor s informacijama o sastanku.
Željeni scenarij:
1) Sudionik odabire željeni sastanak.
2) Otvara se prozor s informacijama o sastanku.
Mogući drugi scenarij:-

## UC12 – formiranje sastanaka
Glavni sudionik: Prijavljeni korisnik
Cilj: Organizacija novog sastanka
Sudionici: Baza podataka
Preduvjeti: Korisnik je prijavljen i nalazi se na stranici za sastanke.
Rezultat: Stvaranje događaja u kalendaru na koji može pozvati druge članove.
Željeni scenarij:
1) Korisnik odabire opciju za organizaciju novog sastanka.
2) Korisnik upisuje naziv/temu sastanka.
3) Korisnik upisuje mjesto održavanja sastanka.
4) Korisnik odabire datum održavanja sastanka.
5) Korisnik unosi vremenski interval održavanja sastanka.
6) Korisnik odabire članove/tvrtku/grupu koje želi pozvati na sastanak.
7) Korisnik potvrđuje stvaranje sastanka.
Mogući drugi scenarij:
1) Korisnik je krivo unio parametre sastanka.
2) Korisnik je pozvao krive članove na sastanak.

## UC13 – uređivanje sastanaka
Glavni sudionik: Prijavljeni korisnik
Cilj: Omogućiti organizatoru sastanka izmjenu pojedinosti za sastanak.
Sudionici: Baza podataka
Preduvjeti: Korisnik je prijavljen, organizirao je sastanak i nalazi se na stranici za sastanke.
Rezultat: Promjena pojedinosti sastanka.
Željeni scenarij:
1) Korisnik odabire opciju izmjene pojedinosti sastanka.
2) Korisnik mijenja željene pojedinosti sastanka.
3) Korisnik potvrđuje svoju izmjenu.
4) Promjena se sprema u bazi podataka.
Mogući drugi scenarij:
1) Korisnik je krivo izmijenio pojedinosti sastanka.

//Naknadno pozivanje članova?
## UC14 – pozivanje članova na sastanak
Glavni sudionik: Prijavljeni korisnik
Cilj: Omogućiti organizatoru sastanka pozivanje drugih članova na sastanak.
Sudionici: Baza podataka
Preduvjeti: Korisnik je prijavljen i napravio je sastanak.
Rezultat: Drugi korisnici dobivaju pozivnicu za sastanak putem elektroničke pošte.
Željeni scenarij:
1) Korisnik odabire članove kojima želi poslati pozivnicu.
2) Šalje se pozivnica za sastanak na adresu elektroničke pošte odabranog člana.
Mogući drugi scenarij:
1) Korisnik je poslao pozivnicu pogrešnim članovima.

## UC15 – odgovor na sastanak
Glavni sudionik: Prijavljeni korisnik
Cilj: Saznati hoće li pozvani član nazočiti sastanku.
Sudionici: Baza podataka
Preduvjeti: Korisnik je dobio pozivnicu na adresu svoje elektroničke pošte.
Rezultat: Korisnik prihvaća ili odbija poziv na sastanak.
Željeni scenarij:
1) Korisnik je pročitao pozivnicu za sastanak.
2) Korisnik "klikom na link" potvrđuje svoju nazočnost ili
"klikom na drugi link" odbija poziv na sastanak.
Mogući drugi scenarij:
1) Korisnik je pritisnuo krivi link.


## UC16 – pregled profila korisnika
Glavni sudionik: Registrirani korisnik
Cilj: Dobivanje podataka o korisniku
Sudionici: Baza podataka
Preduvjeti: Korisnik je prijavljen
Rezultat: Otvara se prozor s podacima o korisniku
Željeni scenarij:
1) Korisnik pregledava prozor s podacima drugog korisnika ili sebe
Mogući drugi scenarij: -

## UC17 – uređivanje profila korisnika
Glavni sudionik: Registrirani korisnik
Cilj: Mogućnost promjene osobnih podataka korisnika
Sudionici: Baza podataka
Preduvjeti: Korisnik je prijavljen i nalazi se na stranici svog profila
Rezultat: Korisnik izmjenjuje svoje osobne podatke
Željeni scenarij:
1) Korisnik klikom na gumb "Uredi podatke" otvara prozor s mogućnošću promjene podataka
2) Korisnik upisuje/briše podatke u predviđene kućice
3) Klikom na gumb "Spremi promjene" u bazu se spremaju novi podaci o korisniku, stari se brišu
Mogući drugi scenarij:
1) Korisnik klikom na gumb "Uredi podatke" otvara prozor s mogućnošću promjene podataka
2) Korisnik upisuje/briše podatke u predviđene kućice
3) Nakon klika na gumb "Spremi promjene" sustav dojavljuje grešku jer su podaci neispravni

## UC18 – pregled profila tvrtke
Glavni sudionik: Registrirani korisnik, Neregistrirani korisnik
Cilj: Dobivanje podataka o tvrtki
Sudionici: Baza podataka
Preduvjeti: Korisnik se nalazi na stranici profila tvrtke
Rezultat: Korisnik dobiva uvid u podatke o tvrtki, ako je korisnik neregistriran ne može vidjeti sve podatke
Željeni scenarij:
1) Korisnik odabire željenu tvrtku
2) Otvara se prozor s podacima o tvrtki
Mogući drugi scenarij: -

## UC19 – uređivanje profila tvrtke
Glavni sudionik: Registrirani korisnik
Cilj: Mogućnost promjene podataka o tvrtki
Sudionici: Baza podataka
Preduvjeti: Korisnik je prijavljen i član je tvrtke
Rezultat: Korisnik mijenja podatke o tvrtki
Željeni scenarij:
1) Korisnik klikom na gumb "Uredi podatke" otvara prozor s mogućnošću promjene podataka
2) Korisnik upisuje/briše podatke u predviđene kućice
3) Klikom na gumb "Spremi promjene" u bazu se spremaju novi podaci o tvrtki, stari se brišu
Mogući drugi scenarij:
1) Korisnik klikom na gumb "Uredi podatke" otvara prozor s mogućnošću promjene podataka
2) Korisnik upisuje/briše podatke u predviđene kućice
3) Nakon klika na gumb "Spremi promjene" sustav dojavljuje grešku jer su podaci neispravni



## UC20 – uređivanje opcija
Glavni sudionik: Prijavljeni korisnik
Cilj: Prilagodba ponašanja web stranice vlastitim željama
Sudionici: Baza podataka
Preduvjeti: Korisnik je prijavljen i nalazi se na stranici za podešavanje opcija
Rezultat: Korisnik je podesio opcije prema vlastitim željama
Željeni scenarij:
1) Korisnik odabire opcije koje želi iz padajućeg izbornika
2) Provjerava ispravnost odabranih opcija
3) Potvrđuje promjene
4) Promjene se spremaju u bazu podataka
Mogući drugi scenarij:
1) Korisnik ne pronalazi željenu opciju
2) Odbacivanje novih opcija
3) Vraćanje na stare postavke
4) Nezadovoljstvo korisnika

## UC21 – pretraživanje
Glavni sudionik: Neregistrirani i registrirani korisnik, administrator, vlasnik udruge
Cilj: Pronalazak željene tvrtke ili člana unutar udruge
Sudionici: Baza podataka
Preduvjeti: -
Rezultat: Ispis rezultata pretrage na zaslon
Željeni scenarij:
1) Korisnik upisuje ključnu/e riječ/i u tražilicu
2) Odabire željene filtere pretrage
3) Podešava filtere sukladno željama
4) Klik na gumb "Pretraži"
5) Ispis rezultata koji zadovoljavaju zahtjeve na zaslon
Mogući drugi scenarij:
1) Korisnik ne pronalazi željenu tvrtku/člana na temelju postavljenih filtara
2) Nezadovoljstvo korisnika

## UC22 – slanje poruka
Glavni sudionik: Registrirani korisnik
Cilj: Uspostava komunikacije s drugim članom/vima
Sudionici: Baza podataka, Registrirani korisnici
Preduvjeti: Korisnik je prijavljen i pozicioniran na stranici za slanje nove poruke ili se nalazi u stranici poštanskog sandučića gdje ima otvorenu neku prošlu poruku
Rezultat: Slanje poruke željenom članu
Željeni scenarij:
1) U slučaju nove poruke, upisuje se primatelj
2) Pisanje teksta poruke
3) Dodavanje željenih privitaka, slika
4) Slanje poruke
5) Poruka dolazi do primatelja
Mogući drugi scenarij:
1) Gubitak poruke putem do primatelja
2) Odabir krivog primatelja

## UC23 - pregled poruka
Glavni sudionik: Registrirani korisnik
Cilj: Pregled primljenih poruka od strane članova udruge
Sudionici: Baza podataka
Preduvjeti: Korisnik je prijavljen u sustav i nalazi se na stranici za poruke
Rezultat: Primitak važne informacije od strane drugih članova
Željeni scenarij:
1) U sandučiću korisnik pronalazi nepročitanu poruku koju želi pročitati
2) Klikom na poruku na ekranu se ispisuje njen sadržaj
Mogući drugi scenarij:
1) Poruka je putem pokupila neku grešku, posljedično ne prikazuje dobar sadržaj


## UC24 - pregled administratora
Glavni sudionik: Vlasnik
Cilj: Imati pristup popisu kreiranih administratora
Sudionici: Baza podataka, Vlasnik
Preduvjeti: Vlasnik je prijavljen i nalazi se u prozoru za administraciju
Rezultat: Prikaz svih kreiranih administratora
Željeni scenarij:
1) Vlasnik se prijavljuje u sustav
2) Vidi popis trenutno kreiranih administratorskih računa
Mogući drugi scenarij:
1) Trenutno nema kreiranih administratorskih računa

## UC24.1 – prijava u admin panel
Glavni sudionik: Administrator
Cilj: Prijaviti se kao administrator u dio prozor za administraciju
Sudionici: Baza podataka, Administrator, Vlasnik
Preduvjeti: Administrator je prijavljen i nalazi se u prozoru za administraciju
Rezultat: Uspješna prijava u prozor za administraciju
Željeni scenarij:
1) Administrator pomoću korisničkog imena i lozinke radi zahtjev za prijavu
2) Sustav ga prepoznaje podatke kao ispravne
3) Administrator je prijavljen
Mogući drugi scenarij:
1) Podaci za prijavu nisu ispravni
2) Javljamo grešku

## UC24.2 – dodavanje i uređivanje administratora
Glavni sudionik: Vlasnik
Cilj: Omogućiti upravljanje administratorima
Sudionici: Vlasnik, Baza podataka
Preduvjeti: Vlasnik je prijavljen i nalazi se u prozoru za administraciju
Rezultat: Promjene podataka o administratorima
Željeni scenarij:
1) Vlasnik može dodati administratora
2) Vlasnik može urediti postojećeg administratora
Mogući drugi scenarij: -

## UC24.3 – dodavanje/brisanje/uređivanje korisnika
Glavni sudionik: Administrator
Cilj: Omogućiti upravljanje korisnicima
Sudionici: Baza podataka, Administrator
Preduvjeti: Administrator je prijavljen i nalazi se u prozoru za administraciju
Rezultat: Promjene podataka o korisnicima
Željeni scenarij:
1) Administrator može vidjeti popis korisnika
2) Administrator može dodati novog korisnika
3) Administrator može urediti podatke pojedinih korisnika
4) Administrator može obrisati pojedinog korisnika
Mogući drugi scenarij: -

## UC24.4 – dodavanje/brisanje/uređivanje tvrtke
Glavni sudionik: Administrator
Cilj: Omogućiti upravljanje tvrtkama
Sudionici: Baza podataka, Administrator
Preduvjeti: Administrator je prijavljen i nalazi se u prozoru za administraciju
Rezultat: Promjene podataka o tvrtkama
Željeni scenarij:
1) Administrator može vidjeti popis tvrtki
2) Administrator može dodati novog tvrtku
3) Administrator može urediti podatke pojedine tvrtke
4) Administrator može obrisati pojedinu tvrtku
Mogući drugi scenarij: -

## UC24.5 – dodavanje/brisanje/uređivanje grupe
Glavni sudionik: Administrator
Cilj: Stvoriti, obrisati ili urediti podatke grupe
Sudionici: Baza podataka, članovi grupe
Preduvjeti: Administrator je prijavljen i nalazi se u prozoru za upravljanje grupama
Rezultat: Promjene podataka o grupama
Željeni scenarij:
1) Otvara se prozor s popisom svih grupa
2) Klikom na grupu otvara se prozor s podacima o određenoj grupi i mogućnostima promjena kao UC8, UC9
Mogući drugi scenarij: -

## UC24.6 – dodavanje/brisanje/uređivanje sastanka
Glavni sudionik: Registrirani korisnik
Cilj: Obavijestiti željene sudionike sastanka o njegovom održavanju
Sudionici: Baza podataka, članovi udruge
Preduvjeti: Administrator je prijavljen i nalazi se u prozoru za definiranje sastanka
Rezultat: Željeni korisnici su obaviješteni o održavanju sastanka
Željeni scenarij:
1) Upisuje se tema sastanka
2) Definira se mjesto održavanja
3) Definira se datum održavanja
4) Definira se vrijeme održavanja
5) Odabire se iz padajućeg izbornika kojem članu/grupi/tvrtki se šalje obavijest o održavanju sastanka
6) Provjera ispravnosti unesenih podataka
7) Izrada sastanka, tj. slanje obavijesti odabranima
Mogući drugi scenarij:
1) Korisnik odustaje od izrade sastanka
2) Krivo definiran sastanak