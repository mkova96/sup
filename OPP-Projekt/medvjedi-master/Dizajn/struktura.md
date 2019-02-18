# Struktura stranice - korisnički dio

## Početna
- za neregistrirane: 
  - pretraživanje
  - popis tvrtki u obliku kartica
  - gore:
    - prijavi se
    - učlani se u udrugu
- za registrirane (dizajn postoji)
  - gore:
    - pretraživanje
    - notifikacijska oznaka da je došla nova obavjest (ko na face-u)
    - prikaz korisnikova imena - pritiskom na korisnikovo ime otvara se popis opcija:
      - moji podaci
      - odjavi se
  - sa strane: popis dostupnih stranica:
    - Obavijesti (ili da se tu pojavi neka oznaka da ima neprocitanih obavjesti)
    - Moja tvrtka
    - Sastanci (kalendar da kojem su prikazani dogovoreni sastanci i možda tipa rođendani ili općenito neke obveze)
    - Grupe
    - Članarina
    - Opcije - nešto u vezi korisničkog računa tipa
  - glavni dio: sadržaj stranice
  - kut dolje desno:
    - popis aktivnih administratora i članova (nešto što se clickom expenda)

## Obavijesti (dizajn postoji)
- popis zadnjih obavijesti koji su vidljive tom korisniku
- u obliku kartica:
  - naslov obavijesti
  - tekst obavijesti
  - autor obavijesti

## Pretraživanje
- općenito: korisnik odabire djelatnost i/ili unosi tekst po kojem pretražuje
- za neregistrirane: rezultati pretraživanja su kartice s imenom tvrtke i pritiskom
na njih vodimo korisnika na prikaz informacija o pojedinačnoj tvrtci
- za registrirane korisnike: lista tvrtki i pritiskom na njih vodimo korisnika
na prikaz informacija o pojedinačnoj tvrtci

## Pojedinačna tvrtka (dizajn postoji)
- za neregistrirane:
  - logo
  - naziv
  - popis djelatnosti
  - popis ključnih riječi
- za registrirane prikazujemo sve kao i za neregistrirane i još
  - popis predstavnika i njihove kontakt podatke
  - u kojim je grupama tvrtka <-neznam kolko je ovo bas bitno za druge korisnike da vide, mislim da je ovo vise neka osobna stvar radi lakseg obavjestavanja
  - gumb 'Pošalji poruku' - vodi na ekran za slanje poruke toj tvrtci
  - gumb 'Pošalji obavijest' - vodi na ekran za slanje obavijesti toj tvrtci
  - gumb 'Dodaj u svoju grupu' - vodi na ekran za dodavanje novog člana u grupu

## Slanje poruke
- unosimo kome je šaljemo
  - odabir tvrtke ili člana tvrtke
- unos poruke

## Slanje obavijesti
- unosimo kome je šaljemo
  - odabir tvrtke ili više tvrtki, odabir grupe ili više grupi, svima ili pojedinačnom članu
- unos naslova obavijesti
- unos teksta obavijesti

## Grupe (dizajn postoji)
- popis svih dostupnih grupa (možda?) <- predlažem da ne iz istog razloga navedenog nešto ranije, eventualno da postoji mogučnost poslat "prijavu" za učlanjenje u grupu
- popis svih grupa u kojima je trenutno prijavljeni korisnik
- posebno istaknuta korisnikova grupa
- nudi se korisniku kreiranje nove grupe

## Stvaranje / uređivanje grupe (dizajn postoji)
- unosimo naziv grupe
- odabiremo koje ćemo sve tvrtke/članove pozvati u grupu:
  - unošenjem prvog slova nadopunjava se i prikazuje popis dostupnih tvrtki/članova
- dolje gumb 'Spremi'
- gumb 'Odustani'

## Prihvaćanje pozivnice na grupu (dizajn postoji)
- kada osoba bude pozvana u grupu dobiva elektroničkom poštom poziv
- pritiskom na poveznicu u elektroničkoj pošti dolazi na stranici gdje može prihvatiti
poziv
(- prikaz naziva i opisa grupe
- gumb 'Prihvaćam'
- gumb 'Ne prihvaćam') <- možda da tu ne kompliciramo stvari i radimo cijeli prozor za prihvaćanje bi mogli sam u tom mailu stavit dva linka, jedan za prihvat, jedan za odbiti ili možda uopće ne slati mail nego staviti to kao obavijest na oglasnoj ploći koja se cijelo vrijeme zadržava na vrhu stranice dok se ne prihvati ili odbije, kolko vidim u uputama nije detaljno specificirano bas za obavjesti o učlanjenju jel to treba biti na mail ili može ovako, ono da ljudi nemoraju puno skakat sa stranice na mail i obratno, znam da je meni to tlaka

## Sastanci (dizajn postoji)
- u obliku kalendara, radi preglednosti
- popis svih sastanaka na kojima korisnik sudjeluje
- popis svih sastanaka koje je korisnik organizirao

## Stvaranje / uređivanje sastanka (dizajn postoji)
- naziv sastanka
- opis sastanka
- odabir datuma
- odabir vremena od-do za lakšu organizaciju korisnikovog ostatka dana
- odabir tvrki/članova kojima se šalje pozivnica na sastanak:
  - unošenjem prvog slova nadopunjava se i prikazuje popis dostupnih tvrtki/članova
- dolje gumb 'Spremi'
- gumb 'Odustani'

## Prihvaćanje pozivnice na sastanak (dizajn postoji)
- kada osoba bude pozvana na sastanak dobiva elektroničkom poštom poziv
- pritiskom na poveznicu u elektroničkoj pošti dolazi na stranici gdje može prihvatiti
poziv
- prikaz naziva i opisa sastanaka
- gumb 'Dolazim'
- gumb 'Ne dolazim'
- pošto ovdje mora biti elektroničkom poštom onda samo predlažem foru s dva linka

## Moji podaci (dizajn postoji)
- prikaz u kojem korisnik uređuje svoje podatke:
  - ime
  - prezime
  - datum rođenja
  - broj telefona
  - e-mail adresa
  - bio
  - link do eksterne neke privatne stranice (?)
  - svoju profilnu sliku
  - tvrtka u kojoj je zaposlen
- dolje gumb 'Spremi'
- gumb 'Odustani

## Uređivanje svoje tvrtke
- može urediti sve podatke:
  - ime tvrtke
  - adresa tvrtke
  - grad tvrtke
  - država tvrtke
  - djelatnosti
  - ključne riječi
  - logo tvrtke
  - opis tvrtke
  - mrežna stranica tvrtke
- dolje gumb 'Spremi'
- gumb 'Odustani'

## Podaci o korisniku
- prikaz podataka iz `Moji podaci` i `Moja tvrtka`
- u biti izgled kada netko klikne na određenog korisnika pa da može vidjeti informacije o njemu i njegov dojam o tvrtci, također i koja je to tvrtka u kojoj radi

## Članarine
- obavijest o trenutnom stanju članarine (dani/mjeseci do isteka)
- ako je istekla, mogućnost plaćanja (podaci o uplatu na žiro račun)

## Opcije (dizajn postoji)
- uvijek dobro dođe
- uređivanje mail obavjesti, notifikacija
- koliko unaprijed se želi obavijest o isteku članarine
- deaktivacija računa
