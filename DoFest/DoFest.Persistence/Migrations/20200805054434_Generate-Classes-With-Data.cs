using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoFest.Persistence.Migrations
{
    public partial class GenerateClassesWithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActivityTypeId = table.Column<Guid>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Address = table.Column<string>(maxLength: 1000, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_ActivityType_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "ActivityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    CityId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActivityId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    UserTypeId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_User_UserType_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BucketList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BucketList_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActivityId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActivityId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Photo_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActivityId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Stars = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BucketListActivity",
                columns: table => new
                {
                    BucketListId = table.Column<Guid>(nullable: false),
                    ActivityId = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketListActivity", x => new { x.BucketListId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_BucketListActivity_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BucketListActivity_BucketList_BucketListId",
                        column: x => x.BucketListId,
                        principalTable: "BucketList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActivityType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00e143ca-47e2-42d9-8293-d698eb035179"), "Voluntariat" },
                    { new Guid("ee57c933-6107-44af-a085-4c86d756f7dc"), "Work&Travel" },
                    { new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), "Pub&Restaurants" },
                    { new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Turism" },
                    { new Guid("b35467f7-1c4d-43d7-bfcf-23c3eb136359"), "Sporturi" },
                    { new Guid("8461cb61-03b4-4a6b-859a-45de15ecca4b"), "Sport" },
                    { new Guid("363db996-073a-4b90-a165-44b1019338dc"), "Festivaluri" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Iași" },
                    { new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Cluj" },
                    { new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Timișoara" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("6d98dbc3-0cb5-45c4-a73f-f94597c8d078"), "Full access", "Admin" },
                    { new Guid("0ba8cde7-7749-42ae-8ca7-eb71e1808346"), "Normal access", "Normal user" }
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "Id", "ActivityTypeId", "Address", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("c205dba0-f95a-4c3f-84b8-7b32e0076a09"), new Guid("00e143ca-47e2-42d9-8293-d698eb035179"), "Universitatea Alexandru Ioan Cuza, Corp B, Bulevardul Carol I 22, Iași 700505", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "AIESEC este o platformă internațională de dezvoltare pentru tineri, care are ca scop descoperirea şi dezvoltarea potențialului acestora, pentru a avea un impact pozitiv în societate. Înființată în 1948 ca organizație non-politică și non-profit, AIESEC permite indivizilor să-şi modeleze şi să-şi îmbogățească propria experiență printr-un sistem complex de oportunități.AIESEC:  shorturl.at/qyDIZ", "AIESEC" },
                    { new Guid("73a9434d-5ae5-48fc-b573-d26f7fe7e4a4"), new Guid("00e143ca-47e2-42d9-8293-d698eb035179"), " Biblioteca Judeteana “Octavian Goga”, Calea Dorobanților 104, Cluj-Napoca, Sala de lectura de la etajul 2", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Ajungem MARI este singurul program demarat de Asociația Lindenfeld și susține educația copiilor din centre de plasament și medii defavorizate.", "Ajungem Mari" },
                    { new Guid("bbf0ee70-0e32-432e-8c96-cbfc487a4004"), new Guid("00e143ca-47e2-42d9-8293-d698eb035179"), "Aleea Crivaia, Timișoara", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Proiecte create cu scopul de a contribui la o tara in care oamenii se implica si sunt parte din schimbarea pe care si-o doresc, devenind la randul lor inspiratie pentru ceilalt.Actiuni de educare a tinerilor, aplicatia LDIR,reamenajari de spatii destinate diverselor categorii sociale si alte proiecte create pentru a proteja mediul si a contribui la rezolvarea problemei deseurilor", "Let’s Do It, Romania!" },
                    { new Guid("a59c6873-8126-44c7-bb52-c7232c76975b"), new Guid("363db996-073a-4b90-a165-44b1019338dc"), "Parcul Botanic, Timisoara", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Festivalul Acces Art – Festival organizat în aer liber, centrat pe ateliere de arte creative.", "Festivalul Acces Art" },
                    { new Guid("d09c842e-256d-4c5b-a0db-cd92128d82e5"), new Guid("363db996-073a-4b90-a165-44b1019338dc"), "Piata Unirii, Cluj", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Este primul festival internațional de film de lungmetraj din România, se bazează pe lungmetraje sau scurtmetraje necomerciale produse în special în țările europene. Marele premiu al festivalului, Trofeul Transilvania, opera artistului Teo Mureșan, este o statuetă ce reprezintă un turn tăiat.", "TIFF" },
                    { new Guid("f7366ae4-df81-45a4-9982-1618c262b119"), new Guid("363db996-073a-4b90-a165-44b1019338dc"), " Bánffy Castle, Cluj-Napoca", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Festivalul îmbină în lineup zone muzicale variate cum ar fi rock, reggae, hip hop, trap, muzică electronică sau indie cu tehnologia, cu arta alternativă, arta stradală și cultura.", "Electric Castle" },
                    { new Guid("21e9d2ad-dc8d-4b8f-b31d-09e7d1315198"), new Guid("363db996-073a-4b90-a165-44b1019338dc"), "Untold Festival Arena, Cluj-Napoc", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Untold Festival este cel mai mare festival de muzică din România.[1][2] Acesta se desfășoară în fiecare an pe Cluj Arena", "UNTOLD" },
                    { new Guid("d0a64a2b-55bc-4097-a3ea-2743de6e6b99"), new Guid("8461cb61-03b4-4a6b-859a-45de15ecca4b"), @" 
                Dinias
                ,Timisoara", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Primul targa rally organizat in Romania. Toti banii adunati vor fi donati Spitalului de Copii ”Louis Turcanu”. ", "Memorialul Daniela Zaharie" },
                    { new Guid("c1976ebc-2cc9-4cb4-a0e2-b39d48b9344a"), new Guid("b35467f7-1c4d-43d7-bfcf-23c3eb136359"), "trada Băii nr 17, Cluj-Napoca 400389", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Rafting, Parapanta, Tir cu arcul, Caiac, Paintball, Motoparapanta- organizate de Transilvania eXtreme Adventures  care o multime de activitati outdoor care te fac sa uiti de stresul zilnic si sa te reincarci cu energie. O modalitate frumoasa de a adauga in viata ta un plus de miscare si sanatate.", "Transilvania eXtreme Adventures" },
                    { new Guid("fa511937-dd7f-40e5-ace5-6f6668e55d99"), new Guid("b35467f7-1c4d-43d7-bfcf-23c3eb136359"), "In curtea interioara, Strada Berăriei nr. 6, Cluj-Napoca 400380", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Free Wall (Rock Climbing Gym).Sali  de escaladă&bouldering", "Free Wall Climbing" },
                    { new Guid("9790292b-5733-4c67-ab37-0f092fdddebe"), new Guid("b35467f7-1c4d-43d7-bfcf-23c3eb136359"), "Bride's Veil Waterfall", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Runsilvania Wild Race. Runsilvania WILD RACE este o cursă de trail running, Traseul de alergare trece pe lângă Cascada Vălul Miresei, Peşterile Vârfuraşul şi Lespezi, ajunge la Pietrele Albe şi urcă pe Vf. Vlădeasa (la proba de Maraton), trece prin grote şi segmente tehnice asigurate cu lanţuri şi corzi, podeţe şi scări din lemn.", "Runsilvania Wild Race" },
                    { new Guid("57f083e0-0899-4434-958c-fd78e1be3816"), new Guid("b35467f7-1c4d-43d7-bfcf-23c3eb136359"), " Baza Sportivă Unirea, Cluj-Napoca ", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Făget Winter Race- Făget Winter Race este un primul concurs de alergare din an. Se desfaşoară în pădurea Făget din Cluj-Napoca, iarna, in al doilea week-end al lunii ianuarie.", "Făget Winter Race" },
                    { new Guid("badff660-d31e-4e3f-8bdf-566085d28824"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Centrul Trimisoarei", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Centrul Timișoarei-Centrul este primul dintre locurile cu care vei dori să faci cunoștiință imediat ce ai ajuns și ți-ai lăsat bagajele în cameră. Începând cu Palatul Culturii și până la Catedrala Mitropolitană, centrul orașului cunoscut și sub numele de Piața Victoriei sau Piața Operei concentrează un număr impresionant de palate și clădiri care încă păstrează gloria și arhitectura spectaculoasă de pe vremuri.", "Centrul Timișoarei" },
                    { new Guid("740eaeb4-2ae8-4a0d-b824-16b1733bec55"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Aleea Durgăului 7, Turda 401106", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Salina Turda-A devenit celebră în ultimii ani în România, așa că ne este greu să credem că mai e cineva care să nu fi auzit de ea. Ca să nu mai vorbim că are și o poveste interesantă, trecând de la statutul de salină de renume a Transilvaniei, la începuturi, la o decădere neașteptată datorată concurenței, salina de la Ocna Mureș. Paradoxal, abia cel de-Al Doilea Război Mondial a readus-o în memoria colectivă, fiind folosită ca adăpost antiaerian.", "Salina Turda" },
                    { new Guid("5036a50b-f539-4eff-bcab-6e9df79bcb02"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Bd. 21 decembrie 1989 nr. 41, Cluj", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), " Biserica Reformată - Este una dintre cele mai masive construcții gotice din întreaga Transilvanie, având mai degrabă aspectul unei cetăți. Aici se organizează periodic tot felul de concerte și evenimente", " Biserica Reformată " },
                    { new Guid("a4681844-689b-40bb-a75a-4155b3aa345c"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), " Strada Baba Novac 2, Cluj-Napoca 400097", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Turnul Croitorilor - Turnul face parte din vechiul zid de apărare al orașului, care înconjura în vremuri de demult o suprafață de 45 hectare, cât măsura cetatea, și este unul dintre puținele care s-au păstrat într-o stare foarte bună până în zilele noastre (practic, turnul este astăzi intact", "Turnul Croitorilor " },
                    { new Guid("a6a3aae4-b279-41da-8ed1-4918712d21e7"), new Guid("ee57c933-6107-44af-a085-4c86d756f7dc"), "Strada Francesco Griselini 2, Timișoara 300054", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "GTS * GOTOSUA Work & Travel" },
                    { new Guid("2aa8c17d-18f6-4144-94da-45e6a2a39fa6"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Strada Emil Racoviță 60a, Cluj-Napoca 400124", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), " Cetățuia - De fapt, Cetățuia este un parc situat la o altitudine de 405 metri, de mici dimensiuni, ce-i drept, cu vedere asupra orașului, deci nu este deloc de ocolit.", " Cetățuia " },
                    { new Guid("bfa7c0e4-cd29-45cb-9295-a515ab9a0749"), new Guid("ee57c933-6107-44af-a085-4c86d756f7dc"), @"Parcare Caminele 12-17
                Complex Studentesc, Timisoara", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", "American Experience" },
                    { new Guid("7ac6a747-9076-4bbc-a9e4-6dd0e829de5e"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), "Strada George Coșbuc 1, Timișoara 300048", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "The Drunken Rat Pub", "The Drunken Rat Pub" },
                    { new Guid("072a5d8f-5a87-4a3a-ba2c-bfce701dca5d"), new Guid("363db996-073a-4b90-a165-44b1019338dc"), "Sala Barocă a Muzeului de Artă din Timișoara ", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Festivalul Internațional de Literatură de la Timișoara – Festivalul reunește autori români și străini, pentru două zile de lecturi și dialoguri deschise cu publicul.", "Festivalul Internațional de Literatură de la Timișoara " },
                    { new Guid("11f43bca-9810-4274-b5ae-08df2cc08c89"), new Guid("363db996-073a-4b90-a165-44b1019338dc"), "Ambasada/Timisoara", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Festivalul Internațional de Tango Argentinian - Festivalul are loc anual, începând cu 2013, în ultima săptămână a lunii mai. Acest unic eveniment din vestul țării este organizat de Școala de Tango Argentinian „Tango Embrace”, din cadrul Asociației \"Art Embrace\".", "Festivalul Internațional de Tango Argentinian" },
                    { new Guid("49bb0b75-dfbd-4588-93ca-0879ce7e613b"), new Guid("363db996-073a-4b90-a165-44b1019338dc"), "Aeroclubul „Alexandru Matei” ,Iași", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Hangariada înseamnă 3 zile de fericire cu ½ muzică și ½ zbor. Privești cerul, saltă inima, îți strângi prietenii de mână, lași gândul să-ți zboare prin iarba cosită. Te întinzi pe spate, îți pui ochelarii de soare, „oare de ce nu m-am făcut pilot/cântăreț ca-n compunerea dintr-a patra?” Aplauze! Ridică-te, înverzește-ți tălpile pantofilor, cântă și dansează odată cu cei de pe scenă. Și-apoi, a doua zi, de la capăt.", "Hangariada" },
                    { new Guid("6939f8f9-10cd-4ca5-b898-8c6ba7508bea"), new Guid("8461cb61-03b4-4a6b-859a-45de15ecca4b"), " B-dul.Eroilor de la Tisa, Timisoara", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Vor participa dansatori din: Rusia, Bulgaria, Hungaria , France , Montenegro , Serbia , Moldova , Czech Republic si Romania ", "International Dance Open" },
                    { new Guid("24a257b5-76b6-4e48-a931-27b61117ae3a"), new Guid("8461cb61-03b4-4a6b-859a-45de15ecca4b"), "Universitatea Politehnica Timişoara", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Chess Contest este un concurs de șah dedicat tuturor elevilor și studenților din toată țara, organizat de Liga AC (Liga Studenților din Facultatea de Automatică și Calculatoare) în colaborare cu Facultatea de Automatică și Calculatoare și Universitatea Politehnica Timișoara. Concursul se desfăşoară în perioada 17-19 noiembrie şi îşi propune să adune cât mai mulţi tineri în Timişoara pentru a-şi arăta strategia în această confruntare a minţii. ", "Chess Contest" },
                    { new Guid("2daebd42-3643-4f7f-923d-28ac3d342c08"), new Guid("8461cb61-03b4-4a6b-859a-45de15ecca4b"), "Sala Constantin Jude (Olimpia), Timisoara", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Ne propunem ca prin evenimentele noastre sa aducem un nou concept dedicat boxului profesionist,sa imbinam sportul cu spectacolul si sa aducem in fata publicului unii dintre cei mai buni sportivi de box si kickboxing din Romania, fiecare dintre acestia confruntandu-se pe reguli de box cu adversari de valoare din Europa, Africa si America Latina intr-o serie de 3 evenimente pe an ", "Noaptea Spartanilor" },
                    { new Guid("e0c6efdd-3156-42f3-8b4a-acbbdb3fe5c4"), new Guid("b35467f7-1c4d-43d7-bfcf-23c3eb136359"), @"Enduro Ranch (Bârnova, Județul Iași)
                ", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Asaltul Lupilor- evenimentului te aşteaptă pe un teren accidentat de 6 Km, perfect ca să-ţi testeze limitele. Vei alerga prin pădure, te vei târî prin şanţuri, te vei căţăra pe funii, vei traversa râpe, vei sări peste garduri, te vei împiedica sau nu de rădacinile copacilor şi nu în ultimul rând te vei murdări de noroi … dar te vei distra ! ", "Asaltul Lupilor" },
                    { new Guid("93416432-fc7d-41e9-8a79-f65ff1b4151c"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), " Strada Michelangelo - Strada 20 Decembrie 1989,Timisoara", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Parcul Rozelor. Situat în centrul oraşului, la doar câțiva pași de malul râului Bega, Parcul Rozelor reprezintă o altă atracție de renume a Timişoarei. De fapt, s-ar putea spune că faima Timişoarei de oraş al parcurilor sau oraş al trandafirilor este în mare măsură datorată acestui parc.", "Parcul Rozelor" },
                    { new Guid("2960c6cd-305f-423b-8124-45c429bc79c1"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), " Strada Hector, Timișoara", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Bastionul Maria Theresia-Aflat în zona centrală, între Hotel Continental și Fântâna Punctelor Cardinale (pe strada Hector), Bastionul Maria Theresia este un monument în stil baroc de o mare însemnătate istorică, fiind cea mai mare bucată de zid păstrată din vechea cetate a Timișoarei.", "Bastionul Maria Theresia" },
                    { new Guid("f3cb5f99-18b4-46a8-9d74-7ab9f1a9af89"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Bulevardul Regele Ferdinand I, Timișoara", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Catedrala Mitropolitană din Timișoara marchează cealaltă intrare principală în centrul orașului, fiind dispusă în partea de sud a pieței. Catedrala este fără îndoială una dintre clădirile care îți va atrage privirea indiferent în ce parte a centrului te vei afla, doar este cel mai mare edificiu religios din oraș. Impresionează atât prin arhitectura somptuoasă care îmbină stilul bizantin cu cel moldovenesc cât și prin dimensiunile sale vaste", "Catedrala Mitropolitană din Timișoara" },
                    { new Guid("9b7d5a70-8d0a-411a-acd3-d4413411848a"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Strada Mărășești 2, Timișoara 300086", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Clădirea Palatului Culturii (cea care mărginește centrul în parte de nord) adăpostește astăzi Opera Națională Română și cele trei teatre de stat Teatrul National Mihai Eminescu, Teatrul Maghiar de Stat Csiky Gergely și Teatrul German de Stat (o situație unică și totodată o premieră în Europa). Dacă inițial clădirea avea exteriorul în stil Renaissance, în urma celor două mari incendii din 1880 și 1920, au mai rămas intacte doar aripile", "Palatului Culturii " },
                    { new Guid("340edcc8-312f-4a48-bc08-c1b351a88d56"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), " Strada Vasile Alecsandri 3, Timișoara 300078", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Jack's Bistro", "Jack's Bistro" },
                    { new Guid("6fcdad24-b205-49f0-8fc0-57cf7f516fad"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), "Joy Pub", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Joy Pub", "Joy Pub" },
                    { new Guid("0479d5d1-c1f6-4914-9ff7-c90eed2c33b1"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), " Strada Eugeniu de Savoya 11, Timișoara 300085", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Enoteca de Savoya", "Enoteca de Savoya" },
                    { new Guid("c9585a8d-54c9-472c-81a4-7cabe33a0618"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), "Strada Eugeniu de Savoya 9, Timișoara", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "The Scotland Yard", "The Scotland Yard" },
                    { new Guid("932f3e36-dc6e-4c53-b68c-c19a62af0174"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), " str.Aries, Nr.19(Casa Tineretului), 300736 Timisoara", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "The 80's Pub", "The 80's Pub" },
                    { new Guid("8a575cfc-674a-405e-967c-fe4f2a3ec21e"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Strada Republicii 42, Cluj-Napoca 400015", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Grădina Botanică - Fondată în anul 1872 și considerată astăzi muzeul național, Grădina Botanică este una dintre primele, cele mai mari și cele mai complexe astfel de grădini din sud-estul Europei. Întinzându-se pe o suprafață de 14 hectare, are ca principale atracții grădina japoneză, grădina romană, serele cu plante tropicale și ecuatoriale.", "Grădina Botanică " },
                    { new Guid("36c639f0-c2a9-444b-9c2d-2cecac40345b"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Piața Unirii ", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Piața Unirii - Asemenea Pieței Muzeului, Piața Unirii se mândrește cu unele dintre cele mai importante ansambluri arhitectonice gotice, baroce și neo-baroce din Transilvania: Biserica Romano-Catolică Sf. Mihail, Muzeul de Artă, Muzeul Farmaciei, pe care nu am mai apucat să-l vizităm, statuia lui Matia Corvin, Strada în oglindă și vechile palate nobiliare.", "Piața Unirii " },
                    { new Guid("b64e4ad7-1d31-41bb-b94b-57c9cf75d4b9"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), " Piața Muzeului, Cluj-Napoca 400000", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Sax", "Sax" },
                    { new Guid("090a5fdd-13c9-44f2-9eae-a729c8708bcc"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), " Bulevardul Ștefan cel Mare și Sfânt nr. 28, Iași 700259", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Mănăstirea Sfinții Trei Ierarhi din Iași- Considerat un monument arhitectural de mare valoare în Iași și în întreaga țară, Mănăstirea Sfinții Trei Ierarhi atrage atenția prin arhitectura sa impresionantă și datorită decorațiunilor sale unice din piatră, care împodobesc fațadele superioare. Aceasta a fost zidită inițial pentru a inaugura domnia marelui voievod de odinioară, Vasile Lupu. Aceasta a fost restaurată din punct de vedere arhitectural în perioada 1882 – 1887, amenajarea interiorului său și realizarea picturilor continuând până în anul 1898.", "Mănăstirea Sfinții Trei Ierarhi din Iași" },
                    { new Guid("854c5bc5-17f2-4c18-b094-c9c4be517a2e"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Strada Agatha Bârsescu nr. 18, Iași 700074", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Teatrul Național Vasile Alecsandri- Datând din anul 1896, Teatrul Național Vasile Alecsandri este cel mai vechi din țară și unul dintre cele mai frumoase din Europa. Interiorul său elegant și bogat decorat a fost inspirat din stilurile arhitecturale baroce și rococo, unul dintre plafoanele sale fiind pictate de celebrul pictor vienez Alexander Goltz. Cortina sa a fost, de asemenea, pictată manual, simbolizând cele trei etape ale vieții și fiind considerată o alegorie a Unificării României.", "Teatrul Național Vasile Alecsandri" },
                    { new Guid("8f512baf-4f5e-4878-8b2e-2b59a4488ec3"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Bulevardul Ștefan cel Mare și Sfânt 16, Iași 700064", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Mitropolia Moldovei și a Bucovinei- Aceasta este renumită pentru că adăpostește Moaștele Sfintei Cuvioase Parascheva, ocrotitoarea Moldovei. Monumentala catedrală ieșeană este marcată de patru turle masive, iar arhitectura sa este inspirată de stilul baroc, care marchează atât elementele decorative din exterior cât și cele din interiorul său.", "Mitropolia Moldovei și a Bucovinei" },
                    { new Guid("9dd99397-cf01-47bb-8264-11b77ba570e9"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Bulevardul Carol I nr. 31, Iași 700462", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Parcul Copou- Amenajarea celebrului Parc Copou din Iași a început în perioada 1833-1834. Acesta adăpostește Monumentul Legilor Constituționale, cel mai vechi monument din țara noastră. Cunoscut și ca Obeliscul cu lei, acesta a fost creat de Mihail Singurov în anul 1834. Reprezentat de o coloană din piatră de 15 m înălțime și cu o greutate ce depășește 10 tone, celebrul monument reprezintă un simbol al celor patru puteri europene care au recunoscut independența Țărilor Române.", "Parcul Copou" },
                    { new Guid("e0ce83a9-0f84-4094-ac2f-597bb11cfbcf"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Bulevardul Ștefan cel Mare și Sfânt 1, Iași 700028", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Palatul Culturii- Această clădire impresionantă este sediul a numeroase instituții culturale de prestigiu din acest oraș și a fost pusă în valoare prin recenta sa reabilitare. În cadrul Palatului Culturii din Iași vei descoperi patru muzee, care te vor ajuta să înțelegi mai bine istoria și cultura acestor meleaguri: Muzeul de Istorie al Moldovei, Muzeul Etnografic, Muzeul de Artă și Muzeul Științei și Tehnologiei Ștefan Procopiu.", "Palatul Culturii" },
                    { new Guid("9f3c4c8d-e707-4390-bcdc-45941dcfd1f2"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), "Piața Unirii nr. 6, Iași 700055", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Cafeneaua Piața Unirii", "Cafeneaua Piața Unirii" },
                    { new Guid("162ebbac-37ab-449e-881f-15fc449129a4"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), "Strada Moldovei 20, Iași 700046", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Vivo", "Vivo" },
                    { new Guid("3e7e9d23-6b6c-43d2-a711-37ce29f49390"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), " Bulevardul Ștefan cel Mare și Sfânt nr. 8, Iași 700063", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Bistro \"La noi\"", "Bistro \"La noi\"" },
                    { new Guid("c39163da-68e2-4499-9bad-09ac6a13f821"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), " Bulevardul Profesor Dimitrie Mangeron nr. 71, Iași 700050", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Kraft Pub & Restaurant", "Kraft Pub & Restaurant" },
                    { new Guid("34478e5a-11c2-41f8-95e7-1ba5e599f78e"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), "Strada Alexandru Lăpușneanu nr. 16, Iași 700057", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Beer Zone", "Beer Zone" },
                    { new Guid("c8984ee3-f446-4a47-bd4b-bbd8d1357f4f"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), "Piața Unirii nr. 5, Iași 700056", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Panoramic", "Panoramic" },
                    { new Guid("80f3afd4-49ad-411d-9e64-4cf951e62e7a"), new Guid("ee57c933-6107-44af-a085-4c86d756f7dc"), "Bulevardul Carol I nr. 4, Iași 700505", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", " Student Travel" },
                    { new Guid("2f4ac1bf-228d-487e-9410-1cdfde028578"), new Guid("ee57c933-6107-44af-a085-4c86d756f7dc"), @"Copou
                Aleea Veronica Micle 8
                langa FEAA, dupa Teo's Cafe", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "American Experience" },
                    { new Guid("9ce8717e-4c1d-45aa-85b5-ac282af61b08"), new Guid("00e143ca-47e2-42d9-8293-d698eb035179"), "Strada Cloşca 9, Iași 700259", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Scopul organizatiei este promovarea credinţei şi a spiritualităţii ortodoxe în rândul tinerilor, cu prioritate în mediul univASCOR:  https://ascoriasi.ro/", "ASCOR" },
                    { new Guid("b7aaae3a-397a-4377-b0aa-989b94bcf440"), new Guid("00e143ca-47e2-42d9-8293-d698eb035179"), "Cămin T11, Aleea Profesor Gheorghe Alexa, Iași 700259", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "BEST încearcă să ajute studenţii europeni să devină mai deschiși spre colaborarea internaţională, oferindu-le șansa de a se familiariza cu diversitatea culturală europeană, dezvoltându-le, în același timp, capacitatea de a lucra în medii internaționale.BEST:  https://bestis.ro/", "BEST" },
                    { new Guid("5ec035fe-a24b-4299-8cae-1fb0cd5b90e0"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Bulevardul Ștefan cel Mare și Sfânt nr. 10, Iași 700063", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Biblioteca Gheorghe Asachi- Biblioteca Gheorghe Asachi din Iași a fost desemnată ca fiind cea mai frumoasă din lume, în cadrul unei competiții desfășurate online la care au participat nume celebre din întreaga lume, precum Biblioteca Colegiului Trinity din Dublin, Biblioteca Regală Portugheză din Buenos Aires și Biblioteca Națională din Praga.", "Biblioteca Gheorghe Asachi" },
                    { new Guid("bdda963e-570e-4db3-94f1-019e91d9fb51"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Str. Râpa Galbenă,Iași 700259", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Esplanada Elisabeta (Râpa Galbenă)- Râpa Galbenă din Iași, așa cum este cunoscută printre localnici, este o zonă importantă, localizată la baza Dealului Copou. Esplanada Elisabeta din Iași a fost construită la sfârșitul secolului al XIX-lea, scopul acesteia fiind acela de facilitare a circulației pietonilor către zona centrală a orașului.", "Esplanada Elisabeta " },
                    { new Guid("8ed5d269-f37f-4730-8495-59ac11123050"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Corp AUniversitATEA Alexandru Ioan Cuza , Bulevardul Carol I 11, Iași 700506", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Sala Pașilor Pierduți- Dacă în cadrul periplului tău turistic te abați și pe la celebra Universitate “Alexandru Ioan Cuza” din Iași, trebuie să vizitezi și Sala Pașilor Pierduți. Picturile murale unice ale celebrului artist Sabin Bălașa te vor impresiona, acesta reușind să introducă acest spațiu pe harta locurilor de referință ale artei universale, prin măiestria sa artistică.", "Sala Pașilor Pierduți" },
                    { new Guid("ca5a2d10-b7eb-4aa6-a734-c926c8a17442"), new Guid("6c8d8876-4af0-425f-9930-9e99ad5b5e8f"), "Strada Dumbrava Roșie nr. 7-9, Iași 700487", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Grădina Botanică din Copou- Înființată în anul 1856, Grădina Botanică Anastasie Fătu poartă numele fondatorului său, un celebru medic și susținător al remediilor naturiste din acea perioadă. Aceasta este prima grădină universitară deschisă în țara noastră și cea mai mare din România în acest moment.", "Grădina Botanică din Copou" },
                    { new Guid("df13164b-d13b-425d-beca-bdaf17ee0d78"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), " Cardinal Iuliu Hossu Street 3, Cluj-Napoca 400029", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Samsara Foodhouse", "Samsara Foodhouse" },
                    { new Guid("7922828d-0821-43b2-8929-71db5de7c268"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), "Strada Universității 6, Cluj-Napoca 400091", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Casa TIFF", "Casa TIFF" },
                    { new Guid("4c4065e5-0047-4511-ba0b-d506b8a43970"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), "Strada Matei Corvin Nr 2, Cluj-Napoca 400000", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Old Shepherd", "Old Shepherd" },
                    { new Guid("97a80a4c-de10-47fb-a008-7cbc0802abc3"), new Guid("d387efef-32e9-4d4b-9b0c-dc591cffb1b4"), "Strada Vasile Goldiș 4, Cluj-Napoca 400112", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "O'Peter's Irish Pub &Grill", "O'Peter's Irish Pub &Grill" },
                    { new Guid("1a248a90-47e4-4260-952d-47521797d8d4"), new Guid("ee57c933-6107-44af-a085-4c86d756f7dc"), "Strada Moldovei 1, Cluj-Napoca 400380", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", "Adira Work & Travel" },
                    { new Guid("4aebc7a6-3387-4464-9b5b-cc693a614bc1"), new Guid("ee57c933-6107-44af-a085-4c86d756f7dc"), "Strada Piezisa Nr 19", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "American Experience" },
                    { new Guid("8a38bef7-5115-4612-b632-19d5f587153a"), new Guid("00e143ca-47e2-42d9-8293-d698eb035179"), "Strada Frumoasă, Nr. 31, Cluj", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Și-au propus să aibă impact asupra mediului economic românesc, oferind acces la resurse de învățare care te vor ajuta să-ți dezvolți competențele profesionale, dar și sociale. Proiectele lor sunt practice, interactive și te aduc cu un pas mai aproape de cariera pe care ți-o dorești. ", "ASER" },
                    { new Guid("dd88aa49-3325-40dc-8b30-f3eb29262c37"), new Guid("363db996-073a-4b90-a165-44b1019338dc"), "Piata Victoriei, Timisoara", new Guid("4ecc2eb5-e5d7-4082-83a5-78bf451fe31f"), "Festivalul Jazz TM este un festival de jazz care se desfășoară în aer liber, în Piața Victoriei, în luna iulie și aduce pe scenă artiști din scena internațională a muzicii Jazz.", "Festivalul Jazz TM" },
                    { new Guid("a3dfccbd-623c-4789-b775-12f6e83bb4ea"), new Guid("00e143ca-47e2-42d9-8293-d698eb035179"), "Strada Păstorului 11, Cluj-Napoca 400338", new Guid("83ec2f8f-e155-4bf9-9ac4-76677ab3cb04"), "Organizația Studenților de la Universitatea Tehnică oferă un cadru informal în care viitorii ingineri pot construi fundația carierei lor.", "OSUBB" },
                    { new Guid("1ab6a103-fa4c-433e-8f07-c0f2aa94867f"), new Guid("363db996-073a-4b90-a165-44b1019338dc"), " Iași, str. V. Pogor, nr. 4, 700110.", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Festivalul Internațional de Literatură și Traducere Iași (FILIT) este un festival internațional care are loc anual în octombrie, în Iași. Festivalul reunește la Iași profesioniști din domeniul cărții, atât din țară, cât și din străinătate. Scriitori, traducători, editori, organizatori de festival, critici literari, librari, distribuitori de carte, manageri și jurnaliști culturali – cu toții se află, de-a lungul celor cinci zile de festival, în centrul unor evenimente destinate, pe de o parte, publicului larg, pe de altă parte, specialiștilor din domeniu.", "FILIT" },
                    { new Guid("5dd7c151-b99f-413f-9934-281ad0651fe8"), new Guid("363db996-073a-4b90-a165-44b1019338dc"), "Strada Vasile Lupu 78A, Iași 700350", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Afterhills este cel mai tânăr festival de muzică de anvergură din România, desfășurat în județul Iași, fiind cel mai mare și important festival din regiunea Moldova.", "Afterhills " },
                    { new Guid("82e7cc0d-3284-4607-b7bb-d3dbf34dcf36"), new Guid("363db996-073a-4b90-a165-44b1019338dc"), @"Piața Unirii 5
                Iași", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Se organizeaza seri de film in diferite locatii, unde sunt invitati oameni importanti ai filmului romanesc.", "Serile de Film Romanesc" },
                    { new Guid("09f38498-4851-4d9a-893f-0c9ac19e9867"), new Guid("b35467f7-1c4d-43d7-bfcf-23c3eb136359"), "Start/Stop: Cluj Arena, Cluj", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Maratonul de Ciclism International din nou la Cluj(Perioada Mai-Iunie)- evenimentul sportiv  aduce la Cluj cel mai mare număr de cicliști din România, într-un context nou și plin de surprize. Vor exista competiții de ciclism și alergare pentru adulți, competiții pentru copii, competiție de spinning, o zonă culinară și una de camping cu foc de tabără precum și alte activități de petrecere a timpului liber.", "Maratonul de Ciclism International din nou la Cluj" },
                    { new Guid("9a4ad246-eeb4-4cc5-bdc2-1bdbdf9d6d9d"), new Guid("b35467f7-1c4d-43d7-bfcf-23c3eb136359"), "Strat/Stop: Palatul Culturii, Iasi", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Maratonul International Iasi- Maratonul International Iasi isi propune sa fie un eveniment sportiv de referinta pentru Municipiul Iasi, dar si la nivel regional, national si international. Obiectivul principal este unul social, fondurile rezultate in urma organizarii evenimentului fiind destinate finantarii proiectului de Infiintare si functionare a punctelor de prim ajutor si interventie in caz de dezastre in principalele cartiere ale Iasului", "Maratonul International Iasi" },
                    { new Guid("956f6304-7057-4ed2-ac93-f8474ad834a8"), new Guid("b35467f7-1c4d-43d7-bfcf-23c3eb136359"), "Strada Pantelimon Halipa 6B, Iași", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Întreținere corporală- săli de sport cu prețuri speciale pentru student: Oxygen, Let’ s move", "Întreținere corporală" },
                    { new Guid("5ab07d7d-192e-4f73-8a50-dba12c88dae2"), new Guid("b35467f7-1c4d-43d7-bfcf-23c3eb136359"), "Strada Stihii 2, Iași 700083", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Pilates- Pilates este o metodă de întărire a mușchilor profunzi, care sunt responsabili cu menținerea posturii. (Tonus Plus- sală )", "Pilates" },
                    { new Guid("e7a54de8-aa20-4e8e-8143-e9ccefcfabf8"), new Guid("363db996-073a-4b90-a165-44b1019338dc"), "Smida, 18, Smida 407082, Cluj", new Guid("5cba7fff-8bfd-450c-b4f8-5e90ca399df4"), "Smida Jazz, festival dedicat jazz-ului de avangardă ce se desfășoară an de an în pitorescul sat Smida (comuna Beliș, județul Cluj - în mijlocul Parcului Natural Apuseni). Pe parcursul a 3 zile, vom petrece o vacanță în Apuseni, cu tot felul de activități în aer liber și concerte ale grupurilor internaționale și din România. ", "Smida Jazz" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "PasswordHash", "StudentId", "UserTypeId", "Username" },
                values: new object[] { new Guid("e017652f-94a3-4c3c-95a7-5b17619bdd8d"), "DoFestAdmin@gmail.com", "2JistaLQHypzhoUDoZ2fjQ==.p3ZQMuXpBDjbCzTn0NYrOOGMn2CYqZOpsOTmnwyVYzk=", null, new Guid("6d98dbc3-0cb5-45c4-a73f-f94597c8d078"), "DoFestAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivityTypeId",
                table: "Activity",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_CityId",
                table: "Activity",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketList_UserId",
                table: "BucketList",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BucketListActivity_ActivityId",
                table: "BucketListActivity",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ActivityId",
                table: "Comment",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ActivityId",
                table: "Notification",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_ActivityId",
                table: "Photo",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_UserId",
                table: "Photo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ActivityId",
                table: "Rating",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CityId",
                table: "Student",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_StudentId",
                table: "User",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeId",
                table: "User",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BucketListActivity");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "BucketList");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ActivityType");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
