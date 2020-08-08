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
                    { new Guid("dcb23f20-0187-427d-bb58-c46d6c6f4fb4"), "Voluntariat" },
                    { new Guid("c83e643f-53c7-4335-a2ff-a946af32d3b6"), "Work&Travel" },
                    { new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), "Pub&Restaurants" },
                    { new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Turism" },
                    { new Guid("e31d26ad-998c-4bd3-8e9a-7f5e470804bc"), "Sporturi" },
                    { new Guid("8fed68be-b82c-47f5-8436-171f9d612a8c"), "Sport" },
                    { new Guid("019cfb1c-efa6-4dd5-ba44-e3c92a66442b"), "Festivaluri" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Iași" },
                    { new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Cluj" },
                    { new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Timișoara" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("9c5df616-78c3-49bc-b793-0858e4add3cc"), "Full access", "Admin" },
                    { new Guid("5faf81f7-12d3-4816-9227-9b54a8378163"), "Normal access", "Normal user" }
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "Id", "ActivityTypeId", "Address", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("2b68283f-a6e0-4d59-9db9-fdc407c9db97"), new Guid("dcb23f20-0187-427d-bb58-c46d6c6f4fb4"), "Universitatea Alexandru Ioan Cuza, Corp B, Bulevardul Carol I 22, Iași 700505", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "AIESEC este o platformă internațională de dezvoltare pentru tineri, care are ca scop descoperirea şi dezvoltarea potențialului acestora, pentru a avea un impact pozitiv în societate. Înființată în 1948 ca organizație non-politică și non-profit, AIESEC permite indivizilor să-şi modeleze şi să-şi îmbogățească propria experiență printr-un sistem complex de oportunități.AIESEC:  shorturl.at/qyDIZ", "AIESEC" },
                    { new Guid("9b200e75-64d8-41df-9b58-dbcca5d39add"), new Guid("dcb23f20-0187-427d-bb58-c46d6c6f4fb4"), " Biblioteca Judeteana “Octavian Goga”, Calea Dorobanților 104, Cluj-Napoca, Sala de lectura de la etajul 2", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Ajungem MARI este singurul program demarat de Asociația Lindenfeld și susține educația copiilor din centre de plasament și medii defavorizate.", "Ajungem Mari" },
                    { new Guid("e7a5439c-fbcb-4c05-b3cf-509cd8b1c836"), new Guid("dcb23f20-0187-427d-bb58-c46d6c6f4fb4"), "Aleea Crivaia, Timișoara", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Proiecte create cu scopul de a contribui la o tara in care oamenii se implica si sunt parte din schimbarea pe care si-o doresc, devenind la randul lor inspiratie pentru ceilalt.Actiuni de educare a tinerilor, aplicatia LDIR,reamenajari de spatii destinate diverselor categorii sociale si alte proiecte create pentru a proteja mediul si a contribui la rezolvarea problemei deseurilor", "Let’s Do It, Romania!" },
                    { new Guid("091d05eb-d546-40e4-a1b1-772f235443d0"), new Guid("019cfb1c-efa6-4dd5-ba44-e3c92a66442b"), "Parcul Botanic, Timisoara", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Festivalul Acces Art – Festival organizat în aer liber, centrat pe ateliere de arte creative.", "Festivalul Acces Art" },
                    { new Guid("bbcdcdc2-a478-44d3-bb5c-c6e24b8c621f"), new Guid("019cfb1c-efa6-4dd5-ba44-e3c92a66442b"), "Piata Unirii, Cluj", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Este primul festival internațional de film de lungmetraj din România, se bazează pe lungmetraje sau scurtmetraje necomerciale produse în special în țările europene. Marele premiu al festivalului, Trofeul Transilvania, opera artistului Teo Mureșan, este o statuetă ce reprezintă un turn tăiat.", "TIFF" },
                    { new Guid("f97d11e1-bff9-46a8-b159-db4dc2bc1bc5"), new Guid("019cfb1c-efa6-4dd5-ba44-e3c92a66442b"), " Bánffy Castle, Cluj-Napoca", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Festivalul îmbină în lineup zone muzicale variate cum ar fi rock, reggae, hip hop, trap, muzică electronică sau indie cu tehnologia, cu arta alternativă, arta stradală și cultura.", "Electric Castle" },
                    { new Guid("5ef504c0-ff9f-4bac-b323-5682477539f8"), new Guid("019cfb1c-efa6-4dd5-ba44-e3c92a66442b"), "Untold Festival Arena, Cluj-Napoc", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Untold Festival este cel mai mare festival de muzică din România.[1][2] Acesta se desfășoară în fiecare an pe Cluj Arena", "UNTOLD" },
                    { new Guid("df7f370e-0ef4-4ee8-a524-26c76e6f046f"), new Guid("8fed68be-b82c-47f5-8436-171f9d612a8c"), @" 
                Dinias
                ,Timisoara", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Primul targa rally organizat in Romania. Toti banii adunati vor fi donati Spitalului de Copii ”Louis Turcanu”. ", "Memorialul Daniela Zaharie" },
                    { new Guid("7dc6e43a-a99c-44ab-8fcf-b20a912a84db"), new Guid("e31d26ad-998c-4bd3-8e9a-7f5e470804bc"), "trada Băii nr 17, Cluj-Napoca 400389", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Rafting, Parapanta, Tir cu arcul, Caiac, Paintball, Motoparapanta- organizate de Transilvania eXtreme Adventures  care o multime de activitati outdoor care te fac sa uiti de stresul zilnic si sa te reincarci cu energie. O modalitate frumoasa de a adauga in viata ta un plus de miscare si sanatate.", "Transilvania eXtreme Adventures" },
                    { new Guid("8757fd1f-7b69-4f3f-85ef-b75905f7a7f1"), new Guid("e31d26ad-998c-4bd3-8e9a-7f5e470804bc"), "In curtea interioara, Strada Berăriei nr. 6, Cluj-Napoca 400380", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Free Wall (Rock Climbing Gym).Sali  de escaladă&bouldering", "Free Wall Climbing" },
                    { new Guid("aeb8fccd-3b40-4d16-b765-a280d57129b3"), new Guid("e31d26ad-998c-4bd3-8e9a-7f5e470804bc"), "Bride's Veil Waterfall", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Runsilvania Wild Race. Runsilvania WILD RACE este o cursă de trail running, Traseul de alergare trece pe lângă Cascada Vălul Miresei, Peşterile Vârfuraşul şi Lespezi, ajunge la Pietrele Albe şi urcă pe Vf. Vlădeasa (la proba de Maraton), trece prin grote şi segmente tehnice asigurate cu lanţuri şi corzi, podeţe şi scări din lemn.", "Runsilvania Wild Race" },
                    { new Guid("85bcd3ca-a11f-4558-807f-6af2c0da5581"), new Guid("e31d26ad-998c-4bd3-8e9a-7f5e470804bc"), " Baza Sportivă Unirea, Cluj-Napoca ", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Făget Winter Race- Făget Winter Race este un primul concurs de alergare din an. Se desfaşoară în pădurea Făget din Cluj-Napoca, iarna, in al doilea week-end al lunii ianuarie.", "Făget Winter Race" },
                    { new Guid("40c54f5e-239f-4065-951e-8bf8fa4033c4"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Centrul Trimisoarei", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Centrul Timișoarei-Centrul este primul dintre locurile cu care vei dori să faci cunoștiință imediat ce ai ajuns și ți-ai lăsat bagajele în cameră. Începând cu Palatul Culturii și până la Catedrala Mitropolitană, centrul orașului cunoscut și sub numele de Piața Victoriei sau Piața Operei concentrează un număr impresionant de palate și clădiri care încă păstrează gloria și arhitectura spectaculoasă de pe vremuri.", "Centrul Timișoarei" },
                    { new Guid("5e1c7576-d7f3-42eb-b0c5-b7f760218dfb"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Aleea Durgăului 7, Turda 401106", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Salina Turda-A devenit celebră în ultimii ani în România, așa că ne este greu să credem că mai e cineva care să nu fi auzit de ea. Ca să nu mai vorbim că are și o poveste interesantă, trecând de la statutul de salină de renume a Transilvaniei, la începuturi, la o decădere neașteptată datorată concurenței, salina de la Ocna Mureș. Paradoxal, abia cel de-Al Doilea Război Mondial a readus-o în memoria colectivă, fiind folosită ca adăpost antiaerian.", "Salina Turda" },
                    { new Guid("115c1157-4f79-48c5-8b17-06a0eaf01db0"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Bd. 21 decembrie 1989 nr. 41, Cluj", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), " Biserica Reformată - Este una dintre cele mai masive construcții gotice din întreaga Transilvanie, având mai degrabă aspectul unei cetăți. Aici se organizează periodic tot felul de concerte și evenimente", " Biserica Reformată " },
                    { new Guid("42be77d5-83bf-4a18-b7f7-442c40b2739e"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), " Strada Baba Novac 2, Cluj-Napoca 400097", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Turnul Croitorilor - Turnul face parte din vechiul zid de apărare al orașului, care înconjura în vremuri de demult o suprafață de 45 hectare, cât măsura cetatea, și este unul dintre puținele care s-au păstrat într-o stare foarte bună până în zilele noastre (practic, turnul este astăzi intact", "Turnul Croitorilor " },
                    { new Guid("da1f78bd-e33b-4318-a621-c0fe28fa7bc2"), new Guid("c83e643f-53c7-4335-a2ff-a946af32d3b6"), "Strada Francesco Griselini 2, Timișoara 300054", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "GTS * GOTOSUA Work & Travel" },
                    { new Guid("46740ebd-0bb6-4927-bac2-720ae1c746e0"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Strada Emil Racoviță 60a, Cluj-Napoca 400124", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), " Cetățuia - De fapt, Cetățuia este un parc situat la o altitudine de 405 metri, de mici dimensiuni, ce-i drept, cu vedere asupra orașului, deci nu este deloc de ocolit.", " Cetățuia " },
                    { new Guid("9689dff9-a764-442d-9f39-c011e33a7d71"), new Guid("c83e643f-53c7-4335-a2ff-a946af32d3b6"), @"Parcare Caminele 12-17
                Complex Studentesc, Timisoara", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", "American Experience" },
                    { new Guid("a17b217e-b68e-445e-a0b5-d795480b47ff"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), "Strada George Coșbuc 1, Timișoara 300048", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "The Drunken Rat Pub", "The Drunken Rat Pub" },
                    { new Guid("cd314d79-471e-4875-b99b-44affaeba4bd"), new Guid("019cfb1c-efa6-4dd5-ba44-e3c92a66442b"), "Sala Barocă a Muzeului de Artă din Timișoara ", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Festivalul Internațional de Literatură de la Timișoara – Festivalul reunește autori români și străini, pentru două zile de lecturi și dialoguri deschise cu publicul.", "Festivalul Internațional de Literatură de la Timișoara " },
                    { new Guid("e03e7775-8597-422a-bf03-b6271e96e1fb"), new Guid("019cfb1c-efa6-4dd5-ba44-e3c92a66442b"), "Ambasada/Timisoara", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Festivalul Internațional de Tango Argentinian - Festivalul are loc anual, începând cu 2013, în ultima săptămână a lunii mai. Acest unic eveniment din vestul țării este organizat de Școala de Tango Argentinian „Tango Embrace”, din cadrul Asociației \"Art Embrace\".", "Festivalul Internațional de Tango Argentinian" },
                    { new Guid("55873360-2fab-425c-b7f3-366b06f50a1f"), new Guid("019cfb1c-efa6-4dd5-ba44-e3c92a66442b"), "Aeroclubul „Alexandru Matei” ,Iași", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Hangariada înseamnă 3 zile de fericire cu ½ muzică și ½ zbor. Privești cerul, saltă inima, îți strângi prietenii de mână, lași gândul să-ți zboare prin iarba cosită. Te întinzi pe spate, îți pui ochelarii de soare, „oare de ce nu m-am făcut pilot/cântăreț ca-n compunerea dintr-a patra?” Aplauze! Ridică-te, înverzește-ți tălpile pantofilor, cântă și dansează odată cu cei de pe scenă. Și-apoi, a doua zi, de la capăt.", "Hangariada" },
                    { new Guid("497840ca-932d-4f3d-8a88-4319c90b0a05"), new Guid("8fed68be-b82c-47f5-8436-171f9d612a8c"), " B-dul.Eroilor de la Tisa, Timisoara", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Vor participa dansatori din: Rusia, Bulgaria, Hungaria , France , Montenegro , Serbia , Moldova , Czech Republic si Romania ", "International Dance Open" },
                    { new Guid("6bfde90d-14f4-4bdf-8838-1ed258013034"), new Guid("8fed68be-b82c-47f5-8436-171f9d612a8c"), "Universitatea Politehnica Timişoara", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Chess Contest este un concurs de șah dedicat tuturor elevilor și studenților din toată țara, organizat de Liga AC (Liga Studenților din Facultatea de Automatică și Calculatoare) în colaborare cu Facultatea de Automatică și Calculatoare și Universitatea Politehnica Timișoara. Concursul se desfăşoară în perioada 17-19 noiembrie şi îşi propune să adune cât mai mulţi tineri în Timişoara pentru a-şi arăta strategia în această confruntare a minţii. ", "Chess Contest" },
                    { new Guid("eb6783cd-196c-45bf-959c-d0247189a9b0"), new Guid("8fed68be-b82c-47f5-8436-171f9d612a8c"), "Sala Constantin Jude (Olimpia), Timisoara", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Ne propunem ca prin evenimentele noastre sa aducem un nou concept dedicat boxului profesionist,sa imbinam sportul cu spectacolul si sa aducem in fata publicului unii dintre cei mai buni sportivi de box si kickboxing din Romania, fiecare dintre acestia confruntandu-se pe reguli de box cu adversari de valoare din Europa, Africa si America Latina intr-o serie de 3 evenimente pe an ", "Noaptea Spartanilor" },
                    { new Guid("417522cb-6f97-4e59-b74e-678cac8860ec"), new Guid("e31d26ad-998c-4bd3-8e9a-7f5e470804bc"), @"Enduro Ranch (Bârnova, Județul Iași)
                ", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Asaltul Lupilor- evenimentului te aşteaptă pe un teren accidentat de 6 Km, perfect ca să-ţi testeze limitele. Vei alerga prin pădure, te vei târî prin şanţuri, te vei căţăra pe funii, vei traversa râpe, vei sări peste garduri, te vei împiedica sau nu de rădacinile copacilor şi nu în ultimul rând te vei murdări de noroi … dar te vei distra ! ", "Asaltul Lupilor" },
                    { new Guid("6bef7796-d4d4-41e7-8e07-10e33156e059"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), " Strada Michelangelo - Strada 20 Decembrie 1989,Timisoara", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Parcul Rozelor. Situat în centrul oraşului, la doar câțiva pași de malul râului Bega, Parcul Rozelor reprezintă o altă atracție de renume a Timişoarei. De fapt, s-ar putea spune că faima Timişoarei de oraş al parcurilor sau oraş al trandafirilor este în mare măsură datorată acestui parc.", "Parcul Rozelor" },
                    { new Guid("dea05722-1bb3-45da-8bdb-3e07c3b48a05"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), " Strada Hector, Timișoara", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Bastionul Maria Theresia-Aflat în zona centrală, între Hotel Continental și Fântâna Punctelor Cardinale (pe strada Hector), Bastionul Maria Theresia este un monument în stil baroc de o mare însemnătate istorică, fiind cea mai mare bucată de zid păstrată din vechea cetate a Timișoarei.", "Bastionul Maria Theresia" },
                    { new Guid("543d7a8a-1f99-4c78-b93e-971fc4814b89"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Bulevardul Regele Ferdinand I, Timișoara", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Catedrala Mitropolitană din Timișoara marchează cealaltă intrare principală în centrul orașului, fiind dispusă în partea de sud a pieței. Catedrala este fără îndoială una dintre clădirile care îți va atrage privirea indiferent în ce parte a centrului te vei afla, doar este cel mai mare edificiu religios din oraș. Impresionează atât prin arhitectura somptuoasă care îmbină stilul bizantin cu cel moldovenesc cât și prin dimensiunile sale vaste", "Catedrala Mitropolitană din Timișoara" },
                    { new Guid("527473f7-ada0-4827-b273-6d7adc5bd6e9"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Strada Mărășești 2, Timișoara 300086", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Clădirea Palatului Culturii (cea care mărginește centrul în parte de nord) adăpostește astăzi Opera Națională Română și cele trei teatre de stat Teatrul National Mihai Eminescu, Teatrul Maghiar de Stat Csiky Gergely și Teatrul German de Stat (o situație unică și totodată o premieră în Europa). Dacă inițial clădirea avea exteriorul în stil Renaissance, în urma celor două mari incendii din 1880 și 1920, au mai rămas intacte doar aripile", "Palatului Culturii " },
                    { new Guid("083cf8f9-d831-4f66-8367-6458eebfcf2b"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), " Strada Vasile Alecsandri 3, Timișoara 300078", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Jack's Bistro", "Jack's Bistro" },
                    { new Guid("40788223-5d1e-4f91-aaf2-8162efd7dff2"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), "Joy Pub", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Joy Pub", "Joy Pub" },
                    { new Guid("9ab08592-f1e3-4ebd-836b-9234306b9959"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), " Strada Eugeniu de Savoya 11, Timișoara 300085", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Enoteca de Savoya", "Enoteca de Savoya" },
                    { new Guid("fb566daf-33bb-487a-98b4-5433c33f75b9"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), "Strada Eugeniu de Savoya 9, Timișoara", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "The Scotland Yard", "The Scotland Yard" },
                    { new Guid("9179f195-dad8-468d-aaf5-084f324ccc7b"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), " str.Aries, Nr.19(Casa Tineretului), 300736 Timisoara", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "The 80's Pub", "The 80's Pub" },
                    { new Guid("7397bdd0-6c29-4377-8e90-b33e77ebd627"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Strada Republicii 42, Cluj-Napoca 400015", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Grădina Botanică - Fondată în anul 1872 și considerată astăzi muzeul național, Grădina Botanică este una dintre primele, cele mai mari și cele mai complexe astfel de grădini din sud-estul Europei. Întinzându-se pe o suprafață de 14 hectare, are ca principale atracții grădina japoneză, grădina romană, serele cu plante tropicale și ecuatoriale.", "Grădina Botanică " },
                    { new Guid("221d546b-7bd9-4a4e-a94e-973601064e62"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Piața Unirii ", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Piața Unirii - Asemenea Pieței Muzeului, Piața Unirii se mândrește cu unele dintre cele mai importante ansambluri arhitectonice gotice, baroce și neo-baroce din Transilvania: Biserica Romano-Catolică Sf. Mihail, Muzeul de Artă, Muzeul Farmaciei, pe care nu am mai apucat să-l vizităm, statuia lui Matia Corvin, Strada în oglindă și vechile palate nobiliare.", "Piața Unirii " },
                    { new Guid("037faffd-dafe-4a02-ab9c-c2f92b05e1e2"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), " Piața Muzeului, Cluj-Napoca 400000", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Sax", "Sax" },
                    { new Guid("790ac0fa-17ce-437f-a79a-0b5e9dbaf149"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), " Bulevardul Ștefan cel Mare și Sfânt nr. 28, Iași 700259", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Mănăstirea Sfinții Trei Ierarhi din Iași- Considerat un monument arhitectural de mare valoare în Iași și în întreaga țară, Mănăstirea Sfinții Trei Ierarhi atrage atenția prin arhitectura sa impresionantă și datorită decorațiunilor sale unice din piatră, care împodobesc fațadele superioare. Aceasta a fost zidită inițial pentru a inaugura domnia marelui voievod de odinioară, Vasile Lupu. Aceasta a fost restaurată din punct de vedere arhitectural în perioada 1882 – 1887, amenajarea interiorului său și realizarea picturilor continuând până în anul 1898.", "Mănăstirea Sfinții Trei Ierarhi din Iași" },
                    { new Guid("f6eb38b1-1a68-4c66-8ecc-8e41123da3b7"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Strada Agatha Bârsescu nr. 18, Iași 700074", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Teatrul Național Vasile Alecsandri- Datând din anul 1896, Teatrul Național Vasile Alecsandri este cel mai vechi din țară și unul dintre cele mai frumoase din Europa. Interiorul său elegant și bogat decorat a fost inspirat din stilurile arhitecturale baroce și rococo, unul dintre plafoanele sale fiind pictate de celebrul pictor vienez Alexander Goltz. Cortina sa a fost, de asemenea, pictată manual, simbolizând cele trei etape ale vieții și fiind considerată o alegorie a Unificării României.", "Teatrul Național Vasile Alecsandri" },
                    { new Guid("1d266885-b574-4ce2-838e-7afdba6c0541"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Bulevardul Ștefan cel Mare și Sfânt 16, Iași 700064", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Mitropolia Moldovei și a Bucovinei- Aceasta este renumită pentru că adăpostește Moaștele Sfintei Cuvioase Parascheva, ocrotitoarea Moldovei. Monumentala catedrală ieșeană este marcată de patru turle masive, iar arhitectura sa este inspirată de stilul baroc, care marchează atât elementele decorative din exterior cât și cele din interiorul său.", "Mitropolia Moldovei și a Bucovinei" },
                    { new Guid("fa036cd9-28f0-4fc8-9ff2-eb0c3b1b7d29"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Bulevardul Carol I nr. 31, Iași 700462", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Parcul Copou- Amenajarea celebrului Parc Copou din Iași a început în perioada 1833-1834. Acesta adăpostește Monumentul Legilor Constituționale, cel mai vechi monument din țara noastră. Cunoscut și ca Obeliscul cu lei, acesta a fost creat de Mihail Singurov în anul 1834. Reprezentat de o coloană din piatră de 15 m înălțime și cu o greutate ce depășește 10 tone, celebrul monument reprezintă un simbol al celor patru puteri europene care au recunoscut independența Țărilor Române.", "Parcul Copou" },
                    { new Guid("779e41fe-a62a-42d6-890e-f992b9d8fc08"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Bulevardul Ștefan cel Mare și Sfânt 1, Iași 700028", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Palatul Culturii- Această clădire impresionantă este sediul a numeroase instituții culturale de prestigiu din acest oraș și a fost pusă în valoare prin recenta sa reabilitare. În cadrul Palatului Culturii din Iași vei descoperi patru muzee, care te vor ajuta să înțelegi mai bine istoria și cultura acestor meleaguri: Muzeul de Istorie al Moldovei, Muzeul Etnografic, Muzeul de Artă și Muzeul Științei și Tehnologiei Ștefan Procopiu.", "Palatul Culturii" },
                    { new Guid("f7d6332d-3168-4710-92cd-3144522e18d4"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), "Piața Unirii nr. 6, Iași 700055", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Cafeneaua Piața Unirii", "Cafeneaua Piața Unirii" },
                    { new Guid("64a47e4f-ce68-4343-a571-ced32d63c3a0"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), "Strada Moldovei 20, Iași 700046", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Vivo", "Vivo" },
                    { new Guid("82d3275d-86b3-487e-9ca4-efd99aa78399"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), " Bulevardul Ștefan cel Mare și Sfânt nr. 8, Iași 700063", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Bistro \"La noi\"", "Bistro \"La noi\"" },
                    { new Guid("72e46b97-f2cb-4dd8-bc2d-0bb4be14cf25"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), " Bulevardul Profesor Dimitrie Mangeron nr. 71, Iași 700050", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Kraft Pub & Restaurant", "Kraft Pub & Restaurant" },
                    { new Guid("3c79c9e2-a0e5-462b-a831-dfc3116442fe"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), "Strada Alexandru Lăpușneanu nr. 16, Iași 700057", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Beer Zone", "Beer Zone" },
                    { new Guid("3e120b4c-baa2-4b70-ad91-07d6bde32d3a"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), "Piața Unirii nr. 5, Iași 700056", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Panoramic", "Panoramic" },
                    { new Guid("dfb58bfa-756c-4beb-b988-afa7ac7ab933"), new Guid("c83e643f-53c7-4335-a2ff-a946af32d3b6"), "Bulevardul Carol I nr. 4, Iași 700505", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", " Student Travel" },
                    { new Guid("4c0f32bc-56a1-45e3-9d96-b2af52da8d7d"), new Guid("c83e643f-53c7-4335-a2ff-a946af32d3b6"), @"Copou
                Aleea Veronica Micle 8
                langa FEAA, dupa Teo's Cafe", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "American Experience" },
                    { new Guid("39dafbbd-a431-462a-9cf0-edcfb711cccc"), new Guid("dcb23f20-0187-427d-bb58-c46d6c6f4fb4"), "Strada Cloşca 9, Iași 700259", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Scopul organizatiei este promovarea credinţei şi a spiritualităţii ortodoxe în rândul tinerilor, cu prioritate în mediul univASCOR:  https://ascoriasi.ro/", "ASCOR" },
                    { new Guid("5622a9e9-8a57-4af7-8f4c-d86f2df9a283"), new Guid("dcb23f20-0187-427d-bb58-c46d6c6f4fb4"), "Cămin T11, Aleea Profesor Gheorghe Alexa, Iași 700259", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "BEST încearcă să ajute studenţii europeni să devină mai deschiși spre colaborarea internaţională, oferindu-le șansa de a se familiariza cu diversitatea culturală europeană, dezvoltându-le, în același timp, capacitatea de a lucra în medii internaționale.BEST:  https://bestis.ro/", "BEST" },
                    { new Guid("e29f94b3-1fa0-4ee9-88f9-3ad71f3e943d"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Bulevardul Ștefan cel Mare și Sfânt nr. 10, Iași 700063", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Biblioteca Gheorghe Asachi- Biblioteca Gheorghe Asachi din Iași a fost desemnată ca fiind cea mai frumoasă din lume, în cadrul unei competiții desfășurate online la care au participat nume celebre din întreaga lume, precum Biblioteca Colegiului Trinity din Dublin, Biblioteca Regală Portugheză din Buenos Aires și Biblioteca Națională din Praga.", "Biblioteca Gheorghe Asachi" },
                    { new Guid("0bc080e9-4944-424c-a17a-cafafa2c0150"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Str. Râpa Galbenă,Iași 700259", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Esplanada Elisabeta (Râpa Galbenă)- Râpa Galbenă din Iași, așa cum este cunoscută printre localnici, este o zonă importantă, localizată la baza Dealului Copou. Esplanada Elisabeta din Iași a fost construită la sfârșitul secolului al XIX-lea, scopul acesteia fiind acela de facilitare a circulației pietonilor către zona centrală a orașului.", "Esplanada Elisabeta " },
                    { new Guid("789cb588-e8e2-47ae-b24b-ca64efe529a3"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Corp AUniversitATEA Alexandru Ioan Cuza , Bulevardul Carol I 11, Iași 700506", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Sala Pașilor Pierduți- Dacă în cadrul periplului tău turistic te abați și pe la celebra Universitate “Alexandru Ioan Cuza” din Iași, trebuie să vizitezi și Sala Pașilor Pierduți. Picturile murale unice ale celebrului artist Sabin Bălașa te vor impresiona, acesta reușind să introducă acest spațiu pe harta locurilor de referință ale artei universale, prin măiestria sa artistică.", "Sala Pașilor Pierduți" },
                    { new Guid("218d394a-ac2f-4770-91be-54c8cacd10a9"), new Guid("97cd38ee-cb5c-4d8b-854d-68acd702cabb"), "Strada Dumbrava Roșie nr. 7-9, Iași 700487", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Grădina Botanică din Copou- Înființată în anul 1856, Grădina Botanică Anastasie Fătu poartă numele fondatorului său, un celebru medic și susținător al remediilor naturiste din acea perioadă. Aceasta este prima grădină universitară deschisă în țara noastră și cea mai mare din România în acest moment.", "Grădina Botanică din Copou" },
                    { new Guid("3341eae1-93c9-4a67-96e6-b919a905a5fc"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), " Cardinal Iuliu Hossu Street 3, Cluj-Napoca 400029", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Samsara Foodhouse", "Samsara Foodhouse" },
                    { new Guid("ae152fe4-900a-460a-845f-c5c8b2a87911"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), "Strada Universității 6, Cluj-Napoca 400091", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Casa TIFF", "Casa TIFF" },
                    { new Guid("c5e77e92-9bce-473a-a1c3-b080030d3361"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), "Strada Matei Corvin Nr 2, Cluj-Napoca 400000", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Old Shepherd", "Old Shepherd" },
                    { new Guid("175d7bb5-4c6c-434e-83ef-2152e3e18a21"), new Guid("47a71218-5ae8-4e97-a51b-ac6022a90c7f"), "Strada Vasile Goldiș 4, Cluj-Napoca 400112", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "O'Peter's Irish Pub &Grill", "O'Peter's Irish Pub &Grill" },
                    { new Guid("e4677e5d-b9b2-46c0-b205-8d94144e8d11"), new Guid("c83e643f-53c7-4335-a2ff-a946af32d3b6"), "Strada Moldovei 1, Cluj-Napoca 400380", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", "Adira Work & Travel" },
                    { new Guid("74dea087-700d-4a46-8d3f-cecb7c7b90db"), new Guid("c83e643f-53c7-4335-a2ff-a946af32d3b6"), "Strada Piezisa Nr 19", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "American Experience" },
                    { new Guid("c5c6e3b9-5eb1-40dc-abb7-6046fbb299b5"), new Guid("dcb23f20-0187-427d-bb58-c46d6c6f4fb4"), "Strada Frumoasă, Nr. 31, Cluj", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Și-au propus să aibă impact asupra mediului economic românesc, oferind acces la resurse de învățare care te vor ajuta să-ți dezvolți competențele profesionale, dar și sociale. Proiectele lor sunt practice, interactive și te aduc cu un pas mai aproape de cariera pe care ți-o dorești. ", "ASER" },
                    { new Guid("f72356eb-d7d4-4883-b3b2-328b8415c2a0"), new Guid("019cfb1c-efa6-4dd5-ba44-e3c92a66442b"), "Piata Victoriei, Timisoara", new Guid("46175d26-5748-4357-8190-0dfebef6740a"), "Festivalul Jazz TM este un festival de jazz care se desfășoară în aer liber, în Piața Victoriei, în luna iulie și aduce pe scenă artiști din scena internațională a muzicii Jazz.", "Festivalul Jazz TM" },
                    { new Guid("6daeba16-7798-401b-9415-61f4166b949f"), new Guid("dcb23f20-0187-427d-bb58-c46d6c6f4fb4"), "Strada Păstorului 11, Cluj-Napoca 400338", new Guid("048d80ea-5166-4c57-ac4b-62e395ff8d88"), "Organizația Studenților de la Universitatea Tehnică oferă un cadru informal în care viitorii ingineri pot construi fundația carierei lor.", "OSUBB" },
                    { new Guid("d630fbcb-aabc-4687-9e4f-0e149c194184"), new Guid("019cfb1c-efa6-4dd5-ba44-e3c92a66442b"), " Iași, str. V. Pogor, nr. 4, 700110.", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Festivalul Internațional de Literatură și Traducere Iași (FILIT) este un festival internațional care are loc anual în octombrie, în Iași. Festivalul reunește la Iași profesioniști din domeniul cărții, atât din țară, cât și din străinătate. Scriitori, traducători, editori, organizatori de festival, critici literari, librari, distribuitori de carte, manageri și jurnaliști culturali – cu toții se află, de-a lungul celor cinci zile de festival, în centrul unor evenimente destinate, pe de o parte, publicului larg, pe de altă parte, specialiștilor din domeniu.", "FILIT" },
                    { new Guid("05beeaad-6d67-4713-a9be-a466e3adb114"), new Guid("019cfb1c-efa6-4dd5-ba44-e3c92a66442b"), "Strada Vasile Lupu 78A, Iași 700350", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Afterhills este cel mai tânăr festival de muzică de anvergură din România, desfășurat în județul Iași, fiind cel mai mare și important festival din regiunea Moldova.", "Afterhills " },
                    { new Guid("9f7b75c7-1c25-4562-90e6-8bb0ef4522b6"), new Guid("019cfb1c-efa6-4dd5-ba44-e3c92a66442b"), @"Piața Unirii 5
                Iași", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Se organizeaza seri de film in diferite locatii, unde sunt invitati oameni importanti ai filmului romanesc.", "Serile de Film Romanesc" },
                    { new Guid("e2d29faa-140c-47ca-9e34-9f77f5319b72"), new Guid("e31d26ad-998c-4bd3-8e9a-7f5e470804bc"), "Start/Stop: Cluj Arena, Cluj", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Maratonul de Ciclism International din nou la Cluj(Perioada Mai-Iunie)- evenimentul sportiv  aduce la Cluj cel mai mare număr de cicliști din România, într-un context nou și plin de surprize. Vor exista competiții de ciclism și alergare pentru adulți, competiții pentru copii, competiție de spinning, o zonă culinară și una de camping cu foc de tabără precum și alte activități de petrecere a timpului liber.", "Maratonul de Ciclism International din nou la Cluj" },
                    { new Guid("1e3f13c5-894e-4333-8fed-953877ace5c4"), new Guid("e31d26ad-998c-4bd3-8e9a-7f5e470804bc"), "Strat/Stop: Palatul Culturii, Iasi", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Maratonul International Iasi- Maratonul International Iasi isi propune sa fie un eveniment sportiv de referinta pentru Municipiul Iasi, dar si la nivel regional, national si international. Obiectivul principal este unul social, fondurile rezultate in urma organizarii evenimentului fiind destinate finantarii proiectului de Infiintare si functionare a punctelor de prim ajutor si interventie in caz de dezastre in principalele cartiere ale Iasului", "Maratonul International Iasi" },
                    { new Guid("9fa15026-6112-43d6-8558-040e695c64d4"), new Guid("e31d26ad-998c-4bd3-8e9a-7f5e470804bc"), "Strada Pantelimon Halipa 6B, Iași", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Întreținere corporală- săli de sport cu prețuri speciale pentru student: Oxygen, Let’ s move", "Întreținere corporală" },
                    { new Guid("3af1ee78-8b4b-45cf-adbc-d23ef332b1a2"), new Guid("e31d26ad-998c-4bd3-8e9a-7f5e470804bc"), "Strada Stihii 2, Iași 700083", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Pilates- Pilates este o metodă de întărire a mușchilor profunzi, care sunt responsabili cu menținerea posturii. (Tonus Plus- sală )", "Pilates" },
                    { new Guid("3c15f7b9-674d-4b22-9d52-055febf1d067"), new Guid("019cfb1c-efa6-4dd5-ba44-e3c92a66442b"), "Smida, 18, Smida 407082, Cluj", new Guid("035e914c-7ebc-4eaa-a523-0e4e118a105e"), "Smida Jazz, festival dedicat jazz-ului de avangardă ce se desfășoară an de an în pitorescul sat Smida (comuna Beliș, județul Cluj - în mijlocul Parcului Natural Apuseni). Pe parcursul a 3 zile, vom petrece o vacanță în Apuseni, cu tot felul de activități în aer liber și concerte ale grupurilor internaționale și din România. ", "Smida Jazz" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "PasswordHash", "StudentId", "UserTypeId", "Username" },
                values: new object[] { new Guid("3752502f-11de-4efb-b839-6de0a2959b0a"), "DoFestAdmin@gmail.com", "Cg4EHY+2WxM8UQOwA22Rdg==.LctRWNsdYokRkAr/kxlw/KGbvVISK2TfW/UHsevSzzc=", null, new Guid("9c5df616-78c3-49bc-b793-0858e4add3cc"), "DoFestAdmin" });

            migrationBuilder.InsertData(
                table: "BucketList",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { new Guid("123b9fef-b831-4e59-8e4f-a0f7cb47e304"), "Admin bucketList", new Guid("3752502f-11de-4efb-b839-6de0a2959b0a") });

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
