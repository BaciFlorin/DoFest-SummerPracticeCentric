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
                    Image = table.Column<byte[]>(nullable: false)
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
                    { new Guid("fa3ba189-cc19-4dbf-a9f0-0fb7afe34c5e"), "Voluntariat" },
                    { new Guid("21402ed0-84a5-4e70-bb07-db71b230e99d"), "Work&Travel" },
                    { new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), "Pub&Restaurants" },
                    { new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Turism" },
                    { new Guid("74e902eb-61dd-43df-a610-76a6423bd53a"), "Sporturi" },
                    { new Guid("3615a2fc-cd4c-4e1b-9de5-71c2fb5681ae"), "Sport" },
                    { new Guid("f2f9d527-039d-4868-a6bb-cab2ff13d42d"), "Festivaluri" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Iași" },
                    { new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Cluj" },
                    { new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Timișoara" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0b58945c-c1d7-4692-90c9-c8f4cdd7cb3a"), "Full access", "Admin" },
                    { new Guid("72cf108d-3114-4823-97e2-34ce410515f2"), "Normal access", "Normal user" }
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "Id", "ActivityTypeId", "Address", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("d5be5366-9e28-44ac-9e17-40a2ce9f5635"), new Guid("fa3ba189-cc19-4dbf-a9f0-0fb7afe34c5e"), "Universitatea Alexandru Ioan Cuza, Corp B, Bulevardul Carol I 22, Iași 700505", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "AIESEC este o platformă internațională de dezvoltare pentru tineri, care are ca scop descoperirea şi dezvoltarea potențialului acestora, pentru a avea un impact pozitiv în societate. Înființată în 1948 ca organizație non-politică și non-profit, AIESEC permite indivizilor să-şi modeleze şi să-şi îmbogățească propria experiență printr-un sistem complex de oportunități.AIESEC:  shorturl.at/qyDIZ", "AIESEC" },
                    { new Guid("a5a34cba-8cb5-4710-9c20-79b53d02e004"), new Guid("fa3ba189-cc19-4dbf-a9f0-0fb7afe34c5e"), " Biblioteca Judeteana “Octavian Goga”, Calea Dorobanților 104, Cluj-Napoca, Sala de lectura de la etajul 2", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Ajungem MARI este singurul program demarat de Asociația Lindenfeld și susține educația copiilor din centre de plasament și medii defavorizate.", "Ajungem Mari" },
                    { new Guid("4475fde7-8720-40cb-ba17-bc7a33e7b2c1"), new Guid("fa3ba189-cc19-4dbf-a9f0-0fb7afe34c5e"), "Aleea Crivaia, Timișoara", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Proiecte create cu scopul de a contribui la o tara in care oamenii se implica si sunt parte din schimbarea pe care si-o doresc, devenind la randul lor inspiratie pentru ceilalt.Actiuni de educare a tinerilor, aplicatia LDIR,reamenajari de spatii destinate diverselor categorii sociale si alte proiecte create pentru a proteja mediul si a contribui la rezolvarea problemei deseurilor", "Let’s Do It, Romania!" },
                    { new Guid("7d250b81-f024-4998-88b8-f066aef429ff"), new Guid("f2f9d527-039d-4868-a6bb-cab2ff13d42d"), "Parcul Botanic, Timisoara", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Festivalul Acces Art – Festival organizat în aer liber, centrat pe ateliere de arte creative.", "Festivalul Acces Art" },
                    { new Guid("54e0806e-e961-4609-9741-f0ecb3e9538c"), new Guid("f2f9d527-039d-4868-a6bb-cab2ff13d42d"), "Piata Unirii, Cluj", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Este primul festival internațional de film de lungmetraj din România, se bazează pe lungmetraje sau scurtmetraje necomerciale produse în special în țările europene. Marele premiu al festivalului, Trofeul Transilvania, opera artistului Teo Mureșan, este o statuetă ce reprezintă un turn tăiat.", "TIFF" },
                    { new Guid("eb9241a4-ff7d-4590-ad10-39b3fe9f3b68"), new Guid("f2f9d527-039d-4868-a6bb-cab2ff13d42d"), " Bánffy Castle, Cluj-Napoca", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Festivalul îmbină în lineup zone muzicale variate cum ar fi rock, reggae, hip hop, trap, muzică electronică sau indie cu tehnologia, cu arta alternativă, arta stradală și cultura.", "Electric Castle" },
                    { new Guid("1f29877b-ba6a-4c89-9efe-5a482d8f0a60"), new Guid("f2f9d527-039d-4868-a6bb-cab2ff13d42d"), "Untold Festival Arena, Cluj-Napoc", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Untold Festival este cel mai mare festival de muzică din România.[1][2] Acesta se desfășoară în fiecare an pe Cluj Arena", "UNTOLD" },
                    { new Guid("ff059593-c1af-41ce-9bf3-a66305f0184e"), new Guid("3615a2fc-cd4c-4e1b-9de5-71c2fb5681ae"), @" 
                Dinias
                ,Timisoara", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Primul targa rally organizat in Romania. Toti banii adunati vor fi donati Spitalului de Copii ”Louis Turcanu”. ", "Memorialul Daniela Zaharie" },
                    { new Guid("5316e9f0-f2c2-4654-840d-ca854aa9f75f"), new Guid("74e902eb-61dd-43df-a610-76a6423bd53a"), "trada Băii nr 17, Cluj-Napoca 400389", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Rafting, Parapanta, Tir cu arcul, Caiac, Paintball, Motoparapanta- organizate de Transilvania eXtreme Adventures  care o multime de activitati outdoor care te fac sa uiti de stresul zilnic si sa te reincarci cu energie. O modalitate frumoasa de a adauga in viata ta un plus de miscare si sanatate.", "Transilvania eXtreme Adventures" },
                    { new Guid("0626475a-6c45-4c4f-a9bc-f2512f98a3e0"), new Guid("74e902eb-61dd-43df-a610-76a6423bd53a"), "In curtea interioara, Strada Berăriei nr. 6, Cluj-Napoca 400380", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Free Wall (Rock Climbing Gym).Sali  de escaladă&bouldering", "Free Wall Climbing" },
                    { new Guid("d5402f68-52c5-4938-8749-a9834a167813"), new Guid("74e902eb-61dd-43df-a610-76a6423bd53a"), "Bride's Veil Waterfall", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Runsilvania Wild Race. Runsilvania WILD RACE este o cursă de trail running, Traseul de alergare trece pe lângă Cascada Vălul Miresei, Peşterile Vârfuraşul şi Lespezi, ajunge la Pietrele Albe şi urcă pe Vf. Vlădeasa (la proba de Maraton), trece prin grote şi segmente tehnice asigurate cu lanţuri şi corzi, podeţe şi scări din lemn.", "Runsilvania Wild Race" },
                    { new Guid("9f3c6d79-a6ed-41f1-bd19-4f78f2517ee2"), new Guid("74e902eb-61dd-43df-a610-76a6423bd53a"), " Baza Sportivă Unirea, Cluj-Napoca ", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Făget Winter Race- Făget Winter Race este un primul concurs de alergare din an. Se desfaşoară în pădurea Făget din Cluj-Napoca, iarna, in al doilea week-end al lunii ianuarie.", "Făget Winter Race" },
                    { new Guid("419040e8-c6b5-4335-83d6-973f29494275"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Centrul Trimisoarei", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Centrul Timișoarei-Centrul este primul dintre locurile cu care vei dori să faci cunoștiință imediat ce ai ajuns și ți-ai lăsat bagajele în cameră. Începând cu Palatul Culturii și până la Catedrala Mitropolitană, centrul orașului cunoscut și sub numele de Piața Victoriei sau Piața Operei concentrează un număr impresionant de palate și clădiri care încă păstrează gloria și arhitectura spectaculoasă de pe vremuri.", "Centrul Timișoarei" },
                    { new Guid("3478fc51-e8b2-409e-9123-66b55c855009"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Aleea Durgăului 7, Turda 401106", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Salina Turda-A devenit celebră în ultimii ani în România, așa că ne este greu să credem că mai e cineva care să nu fi auzit de ea. Ca să nu mai vorbim că are și o poveste interesantă, trecând de la statutul de salină de renume a Transilvaniei, la începuturi, la o decădere neașteptată datorată concurenței, salina de la Ocna Mureș. Paradoxal, abia cel de-Al Doilea Război Mondial a readus-o în memoria colectivă, fiind folosită ca adăpost antiaerian.", "Salina Turda" },
                    { new Guid("6a665a68-8cba-4468-905e-5b6061bfde50"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Bd. 21 decembrie 1989 nr. 41, Cluj", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), " Biserica Reformată - Este una dintre cele mai masive construcții gotice din întreaga Transilvanie, având mai degrabă aspectul unei cetăți. Aici se organizează periodic tot felul de concerte și evenimente", " Biserica Reformată " },
                    { new Guid("4fd25ec2-7939-41a0-a292-d14cef717d27"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), " Strada Baba Novac 2, Cluj-Napoca 400097", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Turnul Croitorilor - Turnul face parte din vechiul zid de apărare al orașului, care înconjura în vremuri de demult o suprafață de 45 hectare, cât măsura cetatea, și este unul dintre puținele care s-au păstrat într-o stare foarte bună până în zilele noastre (practic, turnul este astăzi intact", "Turnul Croitorilor " },
                    { new Guid("361b209e-855a-429d-a280-9b4c6dd81d0a"), new Guid("21402ed0-84a5-4e70-bb07-db71b230e99d"), "Strada Francesco Griselini 2, Timișoara 300054", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "GTS * GOTOSUA Work & Travel" },
                    { new Guid("30f12399-099a-4ab0-8c47-cf029b0de9f5"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Strada Emil Racoviță 60a, Cluj-Napoca 400124", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), " Cetățuia - De fapt, Cetățuia este un parc situat la o altitudine de 405 metri, de mici dimensiuni, ce-i drept, cu vedere asupra orașului, deci nu este deloc de ocolit.", " Cetățuia " },
                    { new Guid("3f2487e2-bdf6-4df6-93aa-e1f5851f43f7"), new Guid("21402ed0-84a5-4e70-bb07-db71b230e99d"), @"Parcare Caminele 12-17
                Complex Studentesc, Timisoara", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", "American Experience" },
                    { new Guid("0a4bd69f-83ee-4c13-9781-08924198b90a"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), "Strada George Coșbuc 1, Timișoara 300048", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "The Drunken Rat Pub", "The Drunken Rat Pub" },
                    { new Guid("15670cb6-7138-46a0-81d4-1a80044cdb37"), new Guid("f2f9d527-039d-4868-a6bb-cab2ff13d42d"), "Sala Barocă a Muzeului de Artă din Timișoara ", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Festivalul Internațional de Literatură de la Timișoara – Festivalul reunește autori români și străini, pentru două zile de lecturi și dialoguri deschise cu publicul.", "Festivalul Internațional de Literatură de la Timișoara " },
                    { new Guid("6bab8e0f-2558-451e-8e79-e5463e054b44"), new Guid("f2f9d527-039d-4868-a6bb-cab2ff13d42d"), "Ambasada/Timisoara", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Festivalul Internațional de Tango Argentinian - Festivalul are loc anual, începând cu 2013, în ultima săptămână a lunii mai. Acest unic eveniment din vestul țării este organizat de Școala de Tango Argentinian „Tango Embrace”, din cadrul Asociației \"Art Embrace\".", "Festivalul Internațional de Tango Argentinian" },
                    { new Guid("880b45d0-298c-49f9-a29e-ed155b267ced"), new Guid("f2f9d527-039d-4868-a6bb-cab2ff13d42d"), "Aeroclubul „Alexandru Matei” ,Iași", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Hangariada înseamnă 3 zile de fericire cu ½ muzică și ½ zbor. Privești cerul, saltă inima, îți strângi prietenii de mână, lași gândul să-ți zboare prin iarba cosită. Te întinzi pe spate, îți pui ochelarii de soare, „oare de ce nu m-am făcut pilot/cântăreț ca-n compunerea dintr-a patra?” Aplauze! Ridică-te, înverzește-ți tălpile pantofilor, cântă și dansează odată cu cei de pe scenă. Și-apoi, a doua zi, de la capăt.", "Hangariada" },
                    { new Guid("87de37db-e855-4368-9b09-d0d1c4fc9a5f"), new Guid("3615a2fc-cd4c-4e1b-9de5-71c2fb5681ae"), " B-dul.Eroilor de la Tisa, Timisoara", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Vor participa dansatori din: Rusia, Bulgaria, Hungaria , France , Montenegro , Serbia , Moldova , Czech Republic si Romania ", "International Dance Open" },
                    { new Guid("c06ae0dd-bba4-44bf-984c-2bca8a855765"), new Guid("3615a2fc-cd4c-4e1b-9de5-71c2fb5681ae"), "Universitatea Politehnica Timişoara", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Chess Contest este un concurs de șah dedicat tuturor elevilor și studenților din toată țara, organizat de Liga AC (Liga Studenților din Facultatea de Automatică și Calculatoare) în colaborare cu Facultatea de Automatică și Calculatoare și Universitatea Politehnica Timișoara. Concursul se desfăşoară în perioada 17-19 noiembrie şi îşi propune să adune cât mai mulţi tineri în Timişoara pentru a-şi arăta strategia în această confruntare a minţii. ", "Chess Contest" },
                    { new Guid("c3897f95-a99b-4a1b-9f62-f7ce164a2c2f"), new Guid("3615a2fc-cd4c-4e1b-9de5-71c2fb5681ae"), "Sala Constantin Jude (Olimpia), Timisoara", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Ne propunem ca prin evenimentele noastre sa aducem un nou concept dedicat boxului profesionist,sa imbinam sportul cu spectacolul si sa aducem in fata publicului unii dintre cei mai buni sportivi de box si kickboxing din Romania, fiecare dintre acestia confruntandu-se pe reguli de box cu adversari de valoare din Europa, Africa si America Latina intr-o serie de 3 evenimente pe an ", "Noaptea Spartanilor" },
                    { new Guid("3895f2cc-ac90-4c24-a1c3-082dbb650340"), new Guid("74e902eb-61dd-43df-a610-76a6423bd53a"), @"Enduro Ranch (Bârnova, Județul Iași)
                ", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Asaltul Lupilor- evenimentului te aşteaptă pe un teren accidentat de 6 Km, perfect ca să-ţi testeze limitele. Vei alerga prin pădure, te vei târî prin şanţuri, te vei căţăra pe funii, vei traversa râpe, vei sări peste garduri, te vei împiedica sau nu de rădacinile copacilor şi nu în ultimul rând te vei murdări de noroi … dar te vei distra ! ", "Asaltul Lupilor" },
                    { new Guid("17de615a-daa1-485c-a20b-9c42a0eb4096"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), " Strada Michelangelo - Strada 20 Decembrie 1989,Timisoara", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Parcul Rozelor. Situat în centrul oraşului, la doar câțiva pași de malul râului Bega, Parcul Rozelor reprezintă o altă atracție de renume a Timişoarei. De fapt, s-ar putea spune că faima Timişoarei de oraş al parcurilor sau oraş al trandafirilor este în mare măsură datorată acestui parc.", "Parcul Rozelor" },
                    { new Guid("20ace6d3-3953-43da-8e47-7313a7f676be"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), " Strada Hector, Timișoara", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Bastionul Maria Theresia-Aflat în zona centrală, între Hotel Continental și Fântâna Punctelor Cardinale (pe strada Hector), Bastionul Maria Theresia este un monument în stil baroc de o mare însemnătate istorică, fiind cea mai mare bucată de zid păstrată din vechea cetate a Timișoarei.", "Bastionul Maria Theresia" },
                    { new Guid("70c3b5fb-3c45-42d7-afa7-2741556c9c7f"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Bulevardul Regele Ferdinand I, Timișoara", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Catedrala Mitropolitană din Timișoara marchează cealaltă intrare principală în centrul orașului, fiind dispusă în partea de sud a pieței. Catedrala este fără îndoială una dintre clădirile care îți va atrage privirea indiferent în ce parte a centrului te vei afla, doar este cel mai mare edificiu religios din oraș. Impresionează atât prin arhitectura somptuoasă care îmbină stilul bizantin cu cel moldovenesc cât și prin dimensiunile sale vaste", "Catedrala Mitropolitană din Timișoara" },
                    { new Guid("a44ad553-196e-4e93-afd6-760892b5c671"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Strada Mărășești 2, Timișoara 300086", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Clădirea Palatului Culturii (cea care mărginește centrul în parte de nord) adăpostește astăzi Opera Națională Română și cele trei teatre de stat Teatrul National Mihai Eminescu, Teatrul Maghiar de Stat Csiky Gergely și Teatrul German de Stat (o situație unică și totodată o premieră în Europa). Dacă inițial clădirea avea exteriorul în stil Renaissance, în urma celor două mari incendii din 1880 și 1920, au mai rămas intacte doar aripile", "Palatului Culturii " },
                    { new Guid("b8290d69-1b75-4aa4-a925-f46e7217616f"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), " Strada Vasile Alecsandri 3, Timișoara 300078", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Jack's Bistro", "Jack's Bistro" },
                    { new Guid("3d3279ef-82b7-4d35-8f46-9cb057c6457f"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), "Joy Pub", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Joy Pub", "Joy Pub" },
                    { new Guid("0f1a3573-30e4-477d-8d53-db84c295c0bd"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), " Strada Eugeniu de Savoya 11, Timișoara 300085", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Enoteca de Savoya", "Enoteca de Savoya" },
                    { new Guid("e88c2b9c-ed9e-46e3-8596-eb5a9000c036"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), "Strada Eugeniu de Savoya 9, Timișoara", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "The Scotland Yard", "The Scotland Yard" },
                    { new Guid("87230bef-76d5-475a-bcde-2e38cdcee53f"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), " str.Aries, Nr.19(Casa Tineretului), 300736 Timisoara", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "The 80's Pub", "The 80's Pub" },
                    { new Guid("8b91d344-58bd-4b72-aadf-87d22392aa39"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Strada Republicii 42, Cluj-Napoca 400015", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Grădina Botanică - Fondată în anul 1872 și considerată astăzi muzeul național, Grădina Botanică este una dintre primele, cele mai mari și cele mai complexe astfel de grădini din sud-estul Europei. Întinzându-se pe o suprafață de 14 hectare, are ca principale atracții grădina japoneză, grădina romană, serele cu plante tropicale și ecuatoriale.", "Grădina Botanică " },
                    { new Guid("ecadc6fd-bc13-4725-a228-d3e21dda305d"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Piața Unirii ", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Piața Unirii - Asemenea Pieței Muzeului, Piața Unirii se mândrește cu unele dintre cele mai importante ansambluri arhitectonice gotice, baroce și neo-baroce din Transilvania: Biserica Romano-Catolică Sf. Mihail, Muzeul de Artă, Muzeul Farmaciei, pe care nu am mai apucat să-l vizităm, statuia lui Matia Corvin, Strada în oglindă și vechile palate nobiliare.", "Piața Unirii " },
                    { new Guid("71bea718-3ad3-415d-927f-92646c8e69a0"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), " Piața Muzeului, Cluj-Napoca 400000", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Sax", "Sax" },
                    { new Guid("60e34075-e985-4e41-a688-fd9c3065514c"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), " Bulevardul Ștefan cel Mare și Sfânt nr. 28, Iași 700259", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Mănăstirea Sfinții Trei Ierarhi din Iași- Considerat un monument arhitectural de mare valoare în Iași și în întreaga țară, Mănăstirea Sfinții Trei Ierarhi atrage atenția prin arhitectura sa impresionantă și datorită decorațiunilor sale unice din piatră, care împodobesc fațadele superioare. Aceasta a fost zidită inițial pentru a inaugura domnia marelui voievod de odinioară, Vasile Lupu. Aceasta a fost restaurată din punct de vedere arhitectural în perioada 1882 – 1887, amenajarea interiorului său și realizarea picturilor continuând până în anul 1898.", "Mănăstirea Sfinții Trei Ierarhi din Iași" },
                    { new Guid("89de34b7-cb5f-4a97-938b-d7dc935e4cbf"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Strada Agatha Bârsescu nr. 18, Iași 700074", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Teatrul Național Vasile Alecsandri- Datând din anul 1896, Teatrul Național Vasile Alecsandri este cel mai vechi din țară și unul dintre cele mai frumoase din Europa. Interiorul său elegant și bogat decorat a fost inspirat din stilurile arhitecturale baroce și rococo, unul dintre plafoanele sale fiind pictate de celebrul pictor vienez Alexander Goltz. Cortina sa a fost, de asemenea, pictată manual, simbolizând cele trei etape ale vieții și fiind considerată o alegorie a Unificării României.", "Teatrul Național Vasile Alecsandri" },
                    { new Guid("4302b1fd-11ae-4a72-9b94-67920a3f2181"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Bulevardul Ștefan cel Mare și Sfânt 16, Iași 700064", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Mitropolia Moldovei și a Bucovinei- Aceasta este renumită pentru că adăpostește Moaștele Sfintei Cuvioase Parascheva, ocrotitoarea Moldovei. Monumentala catedrală ieșeană este marcată de patru turle masive, iar arhitectura sa este inspirată de stilul baroc, care marchează atât elementele decorative din exterior cât și cele din interiorul său.", "Mitropolia Moldovei și a Bucovinei" },
                    { new Guid("77e3cad2-d52c-45b7-9d38-2db840316dd2"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Bulevardul Carol I nr. 31, Iași 700462", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Parcul Copou- Amenajarea celebrului Parc Copou din Iași a început în perioada 1833-1834. Acesta adăpostește Monumentul Legilor Constituționale, cel mai vechi monument din țara noastră. Cunoscut și ca Obeliscul cu lei, acesta a fost creat de Mihail Singurov în anul 1834. Reprezentat de o coloană din piatră de 15 m înălțime și cu o greutate ce depășește 10 tone, celebrul monument reprezintă un simbol al celor patru puteri europene care au recunoscut independența Țărilor Române.", "Parcul Copou" },
                    { new Guid("bad2a3a3-2250-4e52-ae9e-215cac617094"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Bulevardul Ștefan cel Mare și Sfânt 1, Iași 700028", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Palatul Culturii- Această clădire impresionantă este sediul a numeroase instituții culturale de prestigiu din acest oraș și a fost pusă în valoare prin recenta sa reabilitare. În cadrul Palatului Culturii din Iași vei descoperi patru muzee, care te vor ajuta să înțelegi mai bine istoria și cultura acestor meleaguri: Muzeul de Istorie al Moldovei, Muzeul Etnografic, Muzeul de Artă și Muzeul Științei și Tehnologiei Ștefan Procopiu.", "Palatul Culturii" },
                    { new Guid("1e3c4210-e242-49bd-b9e3-d80c7894b1f9"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), "Piața Unirii nr. 6, Iași 700055", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Cafeneaua Piața Unirii", "Cafeneaua Piața Unirii" },
                    { new Guid("16738e7f-2857-4c49-9671-72ef487d832c"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), "Strada Moldovei 20, Iași 700046", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Vivo", "Vivo" },
                    { new Guid("a364183e-9437-429c-9a0c-bcf084f89fbf"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), " Bulevardul Ștefan cel Mare și Sfânt nr. 8, Iași 700063", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Bistro \"La noi\"", "Bistro \"La noi\"" },
                    { new Guid("52a5f1e2-a421-46ee-96dc-b7d45cb7dfc1"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), " Bulevardul Profesor Dimitrie Mangeron nr. 71, Iași 700050", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Kraft Pub & Restaurant", "Kraft Pub & Restaurant" },
                    { new Guid("1846eb68-621e-4918-a39a-3785c9a38a1c"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), "Strada Alexandru Lăpușneanu nr. 16, Iași 700057", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Beer Zone", "Beer Zone" },
                    { new Guid("80616ed8-4855-434a-90a1-9ac28fe58668"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), "Piața Unirii nr. 5, Iași 700056", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Panoramic", "Panoramic" },
                    { new Guid("1e2279d1-18a2-4f32-bfc8-44b891f83c13"), new Guid("21402ed0-84a5-4e70-bb07-db71b230e99d"), "Bulevardul Carol I nr. 4, Iași 700505", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", " Student Travel" },
                    { new Guid("03774606-38a5-4e4d-9a87-e015578a66d6"), new Guid("21402ed0-84a5-4e70-bb07-db71b230e99d"), @"Copou
                Aleea Veronica Micle 8
                langa FEAA, dupa Teo's Cafe", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "American Experience" },
                    { new Guid("ff24b9c2-0cc1-4cb0-9fb7-2b4496f3f3e2"), new Guid("fa3ba189-cc19-4dbf-a9f0-0fb7afe34c5e"), "Strada Cloşca 9, Iași 700259", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Scopul organizatiei este promovarea credinţei şi a spiritualităţii ortodoxe în rândul tinerilor, cu prioritate în mediul univASCOR:  https://ascoriasi.ro/", "ASCOR" },
                    { new Guid("626c19e9-f7c9-4114-8486-af2fb287c715"), new Guid("fa3ba189-cc19-4dbf-a9f0-0fb7afe34c5e"), "Cămin T11, Aleea Profesor Gheorghe Alexa, Iași 700259", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "BEST încearcă să ajute studenţii europeni să devină mai deschiși spre colaborarea internaţională, oferindu-le șansa de a se familiariza cu diversitatea culturală europeană, dezvoltându-le, în același timp, capacitatea de a lucra în medii internaționale.BEST:  https://bestis.ro/", "BEST" },
                    { new Guid("85f1da48-070f-4fcf-bfff-04b947784923"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Bulevardul Ștefan cel Mare și Sfânt nr. 10, Iași 700063", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Biblioteca Gheorghe Asachi- Biblioteca Gheorghe Asachi din Iași a fost desemnată ca fiind cea mai frumoasă din lume, în cadrul unei competiții desfășurate online la care au participat nume celebre din întreaga lume, precum Biblioteca Colegiului Trinity din Dublin, Biblioteca Regală Portugheză din Buenos Aires și Biblioteca Națională din Praga.", "Biblioteca Gheorghe Asachi" },
                    { new Guid("b11862ca-4f55-4386-a281-8877f9e61240"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Str. Râpa Galbenă,Iași 700259", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Esplanada Elisabeta (Râpa Galbenă)- Râpa Galbenă din Iași, așa cum este cunoscută printre localnici, este o zonă importantă, localizată la baza Dealului Copou. Esplanada Elisabeta din Iași a fost construită la sfârșitul secolului al XIX-lea, scopul acesteia fiind acela de facilitare a circulației pietonilor către zona centrală a orașului.", "Esplanada Elisabeta " },
                    { new Guid("825f8c0c-df7b-468f-9268-ea2c9817f696"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Corp AUniversitATEA Alexandru Ioan Cuza , Bulevardul Carol I 11, Iași 700506", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Sala Pașilor Pierduți- Dacă în cadrul periplului tău turistic te abați și pe la celebra Universitate “Alexandru Ioan Cuza” din Iași, trebuie să vizitezi și Sala Pașilor Pierduți. Picturile murale unice ale celebrului artist Sabin Bălașa te vor impresiona, acesta reușind să introducă acest spațiu pe harta locurilor de referință ale artei universale, prin măiestria sa artistică.", "Sala Pașilor Pierduți" },
                    { new Guid("b06fde77-5ede-4963-9339-5c3da4eb807f"), new Guid("bb2a0390-4a42-4689-ae6b-633e9953a373"), "Strada Dumbrava Roșie nr. 7-9, Iași 700487", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Grădina Botanică din Copou- Înființată în anul 1856, Grădina Botanică Anastasie Fătu poartă numele fondatorului său, un celebru medic și susținător al remediilor naturiste din acea perioadă. Aceasta este prima grădină universitară deschisă în țara noastră și cea mai mare din România în acest moment.", "Grădina Botanică din Copou" },
                    { new Guid("2a3d98e9-7175-4baa-9850-43952291a504"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), " Cardinal Iuliu Hossu Street 3, Cluj-Napoca 400029", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Samsara Foodhouse", "Samsara Foodhouse" },
                    { new Guid("6e9ed443-e8f3-494d-8fec-c398c516b619"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), "Strada Universității 6, Cluj-Napoca 400091", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Casa TIFF", "Casa TIFF" },
                    { new Guid("113c698f-e61c-4623-8b5e-bd9accc43c49"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), "Strada Matei Corvin Nr 2, Cluj-Napoca 400000", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Old Shepherd", "Old Shepherd" },
                    { new Guid("b3948bab-3ba0-45ba-9b4d-28ad7fb924f8"), new Guid("f436065d-b9bf-4a2c-99f7-6410d0b0808a"), "Strada Vasile Goldiș 4, Cluj-Napoca 400112", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "O'Peter's Irish Pub &Grill", "O'Peter's Irish Pub &Grill" },
                    { new Guid("6b60d2a5-1f90-463f-98ea-4a25f27f1cd1"), new Guid("21402ed0-84a5-4e70-bb07-db71b230e99d"), "Strada Moldovei 1, Cluj-Napoca 400380", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", "Adira Work & Travel" },
                    { new Guid("5cc9595c-8a69-404f-82d7-67c4deeb7ba8"), new Guid("21402ed0-84a5-4e70-bb07-db71b230e99d"), "Strada Piezisa Nr 19", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "American Experience" },
                    { new Guid("b9e29c89-feda-474b-bc43-4319466569a5"), new Guid("fa3ba189-cc19-4dbf-a9f0-0fb7afe34c5e"), "Strada Frumoasă, Nr. 31, Cluj", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Și-au propus să aibă impact asupra mediului economic românesc, oferind acces la resurse de învățare care te vor ajuta să-ți dezvolți competențele profesionale, dar și sociale. Proiectele lor sunt practice, interactive și te aduc cu un pas mai aproape de cariera pe care ți-o dorești. ", "ASER" },
                    { new Guid("1db3af39-dc1a-47c4-b914-b09ef614e212"), new Guid("f2f9d527-039d-4868-a6bb-cab2ff13d42d"), "Piata Victoriei, Timisoara", new Guid("9031a47d-3e8b-4f07-8107-26e0f33e9469"), "Festivalul Jazz TM este un festival de jazz care se desfășoară în aer liber, în Piața Victoriei, în luna iulie și aduce pe scenă artiști din scena internațională a muzicii Jazz.", "Festivalul Jazz TM" },
                    { new Guid("43900ceb-9c8c-4edb-81e3-5ae9cb2a4e01"), new Guid("fa3ba189-cc19-4dbf-a9f0-0fb7afe34c5e"), "Strada Păstorului 11, Cluj-Napoca 400338", new Guid("6d86bf5a-b668-4eb9-a2ca-67219b40b0b5"), "Organizația Studenților de la Universitatea Tehnică oferă un cadru informal în care viitorii ingineri pot construi fundația carierei lor.", "OSUBB" },
                    { new Guid("8311f941-0d23-4d94-a4f8-bb73bbeb238b"), new Guid("f2f9d527-039d-4868-a6bb-cab2ff13d42d"), " Iași, str. V. Pogor, nr. 4, 700110.", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Festivalul Internațional de Literatură și Traducere Iași (FILIT) este un festival internațional care are loc anual în octombrie, în Iași. Festivalul reunește la Iași profesioniști din domeniul cărții, atât din țară, cât și din străinătate. Scriitori, traducători, editori, organizatori de festival, critici literari, librari, distribuitori de carte, manageri și jurnaliști culturali – cu toții se află, de-a lungul celor cinci zile de festival, în centrul unor evenimente destinate, pe de o parte, publicului larg, pe de altă parte, specialiștilor din domeniu.", "FILIT" },
                    { new Guid("d64fa065-679d-4556-81a7-6343e1739844"), new Guid("f2f9d527-039d-4868-a6bb-cab2ff13d42d"), "Strada Vasile Lupu 78A, Iași 700350", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Afterhills este cel mai tânăr festival de muzică de anvergură din România, desfășurat în județul Iași, fiind cel mai mare și important festival din regiunea Moldova.", "Afterhills " },
                    { new Guid("d2866195-4195-4aa7-a143-b7e71da9c141"), new Guid("f2f9d527-039d-4868-a6bb-cab2ff13d42d"), @"Piața Unirii 5
                Iași", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Se organizeaza seri de film in diferite locatii, unde sunt invitati oameni importanti ai filmului romanesc.", "Serile de Film Romanesc" },
                    { new Guid("42d03f8e-4e52-48d1-a5dc-1a4888b4ae57"), new Guid("74e902eb-61dd-43df-a610-76a6423bd53a"), "Start/Stop: Cluj Arena, Cluj", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Maratonul de Ciclism International din nou la Cluj(Perioada Mai-Iunie)- evenimentul sportiv  aduce la Cluj cel mai mare număr de cicliști din România, într-un context nou și plin de surprize. Vor exista competiții de ciclism și alergare pentru adulți, competiții pentru copii, competiție de spinning, o zonă culinară și una de camping cu foc de tabără precum și alte activități de petrecere a timpului liber.", "Maratonul de Ciclism International din nou la Cluj" },
                    { new Guid("910a1074-a9e6-4172-a359-0a7fabd0ed5a"), new Guid("74e902eb-61dd-43df-a610-76a6423bd53a"), "Strat/Stop: Palatul Culturii, Iasi", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Maratonul International Iasi- Maratonul International Iasi isi propune sa fie un eveniment sportiv de referinta pentru Municipiul Iasi, dar si la nivel regional, national si international. Obiectivul principal este unul social, fondurile rezultate in urma organizarii evenimentului fiind destinate finantarii proiectului de Infiintare si functionare a punctelor de prim ajutor si interventie in caz de dezastre in principalele cartiere ale Iasului", "Maratonul International Iasi" },
                    { new Guid("f98fb483-a695-4ed8-aea5-1a3c8a0d524e"), new Guid("74e902eb-61dd-43df-a610-76a6423bd53a"), "Strada Pantelimon Halipa 6B, Iași", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Întreținere corporală- săli de sport cu prețuri speciale pentru student: Oxygen, Let’ s move", "Întreținere corporală" },
                    { new Guid("18d6a7b0-ac7c-417d-b611-d3151199d49b"), new Guid("74e902eb-61dd-43df-a610-76a6423bd53a"), "Strada Stihii 2, Iași 700083", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Pilates- Pilates este o metodă de întărire a mușchilor profunzi, care sunt responsabili cu menținerea posturii. (Tonus Plus- sală )", "Pilates" },
                    { new Guid("2b96f3c4-2e7c-49ed-8d3d-d088eb4a28e5"), new Guid("f2f9d527-039d-4868-a6bb-cab2ff13d42d"), "Smida, 18, Smida 407082, Cluj", new Guid("d8c67179-499c-42b3-bc7a-551633ed36f5"), "Smida Jazz, festival dedicat jazz-ului de avangardă ce se desfășoară an de an în pitorescul sat Smida (comuna Beliș, județul Cluj - în mijlocul Parcului Natural Apuseni). Pe parcursul a 3 zile, vom petrece o vacanță în Apuseni, cu tot felul de activități în aer liber și concerte ale grupurilor internaționale și din România. ", "Smida Jazz" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "PasswordHash", "StudentId", "UserTypeId", "Username" },
                values: new object[] { new Guid("cb4e2b14-c2d5-4c8c-a3cf-15b80c6ed715"), "DoFestAdmin@gmail.com", "L1iWBjwilqq4U3nDYPMDZQ==.VB8+bk5++NULkwC44r3pnSoIOgDrVucf+VKNGznNRxk=", null, new Guid("0b58945c-c1d7-4692-90c9-c8f4cdd7cb3a"), "DoFestAdmin" });

            migrationBuilder.InsertData(
                table: "BucketList",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { new Guid("80b74011-20f1-475e-9afb-c41eb94b28fc"), "Admin bucketList", new Guid("cb4e2b14-c2d5-4c8c-a3cf-15b80c6ed715") });

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
