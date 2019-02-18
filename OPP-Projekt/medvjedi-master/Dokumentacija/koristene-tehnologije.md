# Korištene tehnologije

Za izradu implementacije koristili smo objektno orijentirani jezik C#. S obzirom
na mogućnost da radi na Linux operativnom sustavu odabrali smo .Net Core kao
radni okvir za naš projekt. Naša aplikacija je web aplikacija i dominantni
radni okvir za C# razvojne inženjere je Asp.Net, konkretno Asp.Net MVC Core.

Naša aplikacija je zahtijevala trajno smještanje podataka i stoga smo odlučili
se koristiti i bazu podataka. Na predmetu Baze podataka smo se upoznali pobliže
s PostgreSQL bazom podataka i ona je bila logičan izbor za nas. U svijetu
modernog razvoja web aplikacija često se koriste alati koji olakšavaju
posao i smanjuju količinu grešaka. Jedan od takvih alata je ORM tj. sustav koji
omogućava da s bazom komuniciramo
korištenjem C# klasa.

ORM koji je neslužbeni standard unutar Asp.Net MVC Core je Entity Framework Core.
On nam je omogućio da bazu podataka sinkroniziramo međusobno putem sustava
migracija. Uvelike je pomogao i da lakše izgradimo kompleksne veze između tablica
unutar baze podataka. Za potrebe autentikacija smo posegnuli za Identity bibliotekom
koja se odlično uklapa unutar Asp.Net MVC Core radnog okvira.
Biblioteka Identity nam je omogućila brži rad i bolje i jače sigurnosne značajke.

Sučelje naše aplikacija je izgrađeno pomoću HTML5, CSS3 i JavaScript jezika.
Kao bazu našega dizajna smo koristili Bootstrap 4 radni okvir koji nam je
uvelike ubrzao izradu implementacije. Također je omogućio i responzivni
dizajn bez puno truda. Uz sami JavaScript koristili smo i biblioteku
jQuery koja je olakšala manipulacijom HTML-a.

Kod smo većinom pisali u dva alata:
- Visual Studio Code je alat koji radi na više platformi i
  besplatan je
- Rider je klasični IDE za koji kao studenti smo imali besplatnu licencu.

Suradnju među članovima tima nam je olakšao alat za verzioniranje programske potpore, Git.
Koristili smo Git uz poslužitelj na GitLabu. Međusobno smo komunicirali putem
alata Slack te koristili SMS za dojavljivanje termina sastanaka.
Prekrasne i precizne dijagrame smo izradili pomoću alata Astah Professional.