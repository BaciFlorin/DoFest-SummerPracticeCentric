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
                    Name = table.Column<string>(maxLength: 150, nullable: false),
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
                    Email = table.Column<string>(maxLength: 200, nullable: false),
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
                    { new Guid("85a76a5c-322d-47b6-b516-6da385c50ac4"), "Voluntariat" },
                    { new Guid("0b62737d-cdf3-4dbc-916f-bacba53d78bf"), "Work&Travel" },
                    { new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), "Pub&Restaurants" },
                    { new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Turism" },
                    { new Guid("6fd24ed7-d10a-4617-879d-db4c529442fd"), "Sporturi" },
                    { new Guid("b29c0531-3a95-461f-a167-42c24f333515"), "Sport" },
                    { new Guid("22c6439b-bb98-4d4e-a69e-02fce41bfd15"), "Festivaluri" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Iași" },
                    { new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Cluj" },
                    { new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Timișoara" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("7af8f587-d5b2-4e34-b0a2-c0346b50ab82"), "Full access", "Admin" },
                    { new Guid("d3800ea6-d54c-4ac2-b6e6-10b9fc1db604"), "Normal access", "Normal user" }
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "Id", "ActivityTypeId", "Address", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("76ecb0fa-219f-4b6f-8c86-0f9cdd2788ec"), new Guid("85a76a5c-322d-47b6-b516-6da385c50ac4"), "Universitatea Alexandru Ioan Cuza, Corp B, Bulevardul Carol I 22, Iași 700505", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "AIESEC este o platformă internațională de dezvoltare pentru tineri, care are ca scop descoperirea şi dezvoltarea potențialului acestora, pentru a avea un impact pozitiv în societate. Înființată în 1948 ca organizație non-politică și non-profit, AIESEC permite indivizilor să-şi modeleze şi să-şi îmbogățească propria experiență printr-un sistem complex de oportunități.AIESEC:  shorturl.at/qyDIZ", "AIESEC" },
                    { new Guid("ba1b4719-a804-40c3-9262-f076575b00a7"), new Guid("85a76a5c-322d-47b6-b516-6da385c50ac4"), " Biblioteca Judeteana “Octavian Goga”, Calea Dorobanților 104, Cluj-Napoca, Sala de lectura de la etajul 2", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Ajungem MARI este singurul program demarat de Asociația Lindenfeld și susține educația copiilor din centre de plasament și medii defavorizate.", "Ajungem Mari" },
                    { new Guid("3a4f23c3-c898-4097-9902-f68e15a5a00d"), new Guid("85a76a5c-322d-47b6-b516-6da385c50ac4"), "Aleea Crivaia, Timișoara", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Proiecte create cu scopul de a contribui la o tara in care oamenii se implica si sunt parte din schimbarea pe care si-o doresc, devenind la randul lor inspiratie pentru ceilalt.Actiuni de educare a tinerilor, aplicatia LDIR,reamenajari de spatii destinate diverselor categorii sociale si alte proiecte create pentru a proteja mediul si a contribui la rezolvarea problemei deseurilor", "Let’s Do It, Romania!" },
                    { new Guid("249346fc-4984-4d87-ae31-db4f188d131b"), new Guid("22c6439b-bb98-4d4e-a69e-02fce41bfd15"), "Parcul Botanic, Timisoara", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Festivalul Acces Art – Festival organizat în aer liber, centrat pe ateliere de arte creative.", "Festivalul Acces Art" },
                    { new Guid("d19aa8b7-cc8e-4dee-a040-79a4c13ba81d"), new Guid("22c6439b-bb98-4d4e-a69e-02fce41bfd15"), "Piata Unirii, Cluj", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Este primul festival internațional de film de lungmetraj din România, se bazează pe lungmetraje sau scurtmetraje necomerciale produse în special în țările europene. Marele premiu al festivalului, Trofeul Transilvania, opera artistului Teo Mureșan, este o statuetă ce reprezintă un turn tăiat.", "TIFF" },
                    { new Guid("96e934fc-1376-4fc2-a27e-2204e83edae6"), new Guid("22c6439b-bb98-4d4e-a69e-02fce41bfd15"), " Bánffy Castle, Cluj-Napoca", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Festivalul îmbină în lineup zone muzicale variate cum ar fi rock, reggae, hip hop, trap, muzică electronică sau indie cu tehnologia, cu arta alternativă, arta stradală și cultura.", "Electric Castle" },
                    { new Guid("b265d5f0-9bbc-4650-bdc3-c21579dda365"), new Guid("22c6439b-bb98-4d4e-a69e-02fce41bfd15"), "Untold Festival Arena, Cluj-Napoc", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Untold Festival este cel mai mare festival de muzică din România.[1][2] Acesta se desfășoară în fiecare an pe Cluj Arena", "UNTOLD" },
                    { new Guid("4f6989d7-6455-4382-ae43-0f7aad7e040d"), new Guid("b29c0531-3a95-461f-a167-42c24f333515"), @" 
                Dinias
                ,Timisoara", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Primul targa rally organizat in Romania. Toti banii adunati vor fi donati Spitalului de Copii ”Louis Turcanu”. ", "Memorialul Daniela Zaharie" },
                    { new Guid("15e8ce36-dca8-4c66-b4d9-90b2d61bff2b"), new Guid("6fd24ed7-d10a-4617-879d-db4c529442fd"), "trada Băii nr 17, Cluj-Napoca 400389", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Rafting, Parapanta, Tir cu arcul, Caiac, Paintball, Motoparapanta- organizate de Transilvania eXtreme Adventures  care o multime de activitati outdoor care te fac sa uiti de stresul zilnic si sa te reincarci cu energie. O modalitate frumoasa de a adauga in viata ta un plus de miscare si sanatate.", "Transilvania eXtreme Adventures" },
                    { new Guid("7b3c8b62-3fca-4b0b-98da-552627b2bb40"), new Guid("6fd24ed7-d10a-4617-879d-db4c529442fd"), "In curtea interioara, Strada Berăriei nr. 6, Cluj-Napoca 400380", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Free Wall (Rock Climbing Gym).Sali  de escaladă&bouldering", "Free Wall Climbing" },
                    { new Guid("719da30d-ab57-441e-b6a6-da4b15965e1b"), new Guid("6fd24ed7-d10a-4617-879d-db4c529442fd"), "Bride's Veil Waterfall", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Runsilvania Wild Race. Runsilvania WILD RACE este o cursă de trail running, Traseul de alergare trece pe lângă Cascada Vălul Miresei, Peşterile Vârfuraşul şi Lespezi, ajunge la Pietrele Albe şi urcă pe Vf. Vlădeasa (la proba de Maraton), trece prin grote şi segmente tehnice asigurate cu lanţuri şi corzi, podeţe şi scări din lemn.", "Runsilvania Wild Race" },
                    { new Guid("a908e1cd-e854-4fbc-aae6-695f5ba7ede7"), new Guid("6fd24ed7-d10a-4617-879d-db4c529442fd"), " Baza Sportivă Unirea, Cluj-Napoca ", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Făget Winter Race- Făget Winter Race este un primul concurs de alergare din an. Se desfaşoară în pădurea Făget din Cluj-Napoca, iarna, in al doilea week-end al lunii ianuarie.", "Făget Winter Race" },
                    { new Guid("a170381a-070f-49e5-8f27-370e72e255ca"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Centrul Trimisoarei", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Centrul Timișoarei-Centrul este primul dintre locurile cu care vei dori să faci cunoștiință imediat ce ai ajuns și ți-ai lăsat bagajele în cameră. Începând cu Palatul Culturii și până la Catedrala Mitropolitană, centrul orașului cunoscut și sub numele de Piața Victoriei sau Piața Operei concentrează un număr impresionant de palate și clădiri care încă păstrează gloria și arhitectura spectaculoasă de pe vremuri.", "Centrul Timișoarei" },
                    { new Guid("e6b3b00b-cd7f-49bb-ad8a-7e16ede88a78"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Aleea Durgăului 7, Turda 401106", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Salina Turda-A devenit celebră în ultimii ani în România, așa că ne este greu să credem că mai e cineva care să nu fi auzit de ea. Ca să nu mai vorbim că are și o poveste interesantă, trecând de la statutul de salină de renume a Transilvaniei, la începuturi, la o decădere neașteptată datorată concurenței, salina de la Ocna Mureș. Paradoxal, abia cel de-Al Doilea Război Mondial a readus-o în memoria colectivă, fiind folosită ca adăpost antiaerian.", "Salina Turda" },
                    { new Guid("59048efd-6556-4ccc-a027-eab6a93a46a1"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Bd. 21 decembrie 1989 nr. 41, Cluj", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), " Biserica Reformată - Este una dintre cele mai masive construcții gotice din întreaga Transilvanie, având mai degrabă aspectul unei cetăți. Aici se organizează periodic tot felul de concerte și evenimente", " Biserica Reformată " },
                    { new Guid("758e8538-87c3-4441-802a-65da0a99f4e5"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), " Strada Baba Novac 2, Cluj-Napoca 400097", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Turnul Croitorilor - Turnul face parte din vechiul zid de apărare al orașului, care înconjura în vremuri de demult o suprafață de 45 hectare, cât măsura cetatea, și este unul dintre puținele care s-au păstrat într-o stare foarte bună până în zilele noastre (practic, turnul este astăzi intact", "Turnul Croitorilor " },
                    { new Guid("fabfcbc2-cbb7-4ca5-8a69-88565c0cfc9c"), new Guid("0b62737d-cdf3-4dbc-916f-bacba53d78bf"), "Strada Francesco Griselini 2, Timișoara 300054", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "GTS * GOTOSUA Work & Travel" },
                    { new Guid("42b30b53-91a9-4031-aa80-580e5c8dc4ab"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Strada Emil Racoviță 60a, Cluj-Napoca 400124", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), " Cetățuia - De fapt, Cetățuia este un parc situat la o altitudine de 405 metri, de mici dimensiuni, ce-i drept, cu vedere asupra orașului, deci nu este deloc de ocolit.", " Cetățuia " },
                    { new Guid("f2e29d59-1a93-4132-98b9-69b64747a6e1"), new Guid("0b62737d-cdf3-4dbc-916f-bacba53d78bf"), @"Parcare Caminele 12-17
                Complex Studentesc, Timisoara", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", "American Experience" },
                    { new Guid("2c144c74-ec2b-408a-bbbd-2e81d4beb711"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), "Strada George Coșbuc 1, Timișoara 300048", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "The Drunken Rat Pub", "The Drunken Rat Pub" },
                    { new Guid("465abfa1-38ad-46f5-a658-a3b8efe7cbf8"), new Guid("22c6439b-bb98-4d4e-a69e-02fce41bfd15"), "Sala Barocă a Muzeului de Artă din Timișoara ", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Festivalul Internațional de Literatură de la Timișoara – Festivalul reunește autori români și străini, pentru două zile de lecturi și dialoguri deschise cu publicul.", "Festivalul Internațional de Literatură de la Timișoara " },
                    { new Guid("4117e118-ffb9-4574-80eb-25bae2680905"), new Guid("22c6439b-bb98-4d4e-a69e-02fce41bfd15"), "Ambasada/Timisoara", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Festivalul Internațional de Tango Argentinian - Festivalul are loc anual, începând cu 2013, în ultima săptămână a lunii mai. Acest unic eveniment din vestul țării este organizat de Școala de Tango Argentinian „Tango Embrace”, din cadrul Asociației \"Art Embrace\".", "Festivalul Internațional de Tango Argentinian" },
                    { new Guid("c718f3da-bd8b-478f-99ad-088f2606407e"), new Guid("22c6439b-bb98-4d4e-a69e-02fce41bfd15"), "Aeroclubul „Alexandru Matei” ,Iași", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Hangariada înseamnă 3 zile de fericire cu ½ muzică și ½ zbor. Privești cerul, saltă inima, îți strângi prietenii de mână, lași gândul să-ți zboare prin iarba cosită. Te întinzi pe spate, îți pui ochelarii de soare, „oare de ce nu m-am făcut pilot/cântăreț ca-n compunerea dintr-a patra?” Aplauze! Ridică-te, înverzește-ți tălpile pantofilor, cântă și dansează odată cu cei de pe scenă. Și-apoi, a doua zi, de la capăt.", "Hangariada" },
                    { new Guid("f4cf901b-59c8-47e8-8b5d-6d82a18c6cce"), new Guid("b29c0531-3a95-461f-a167-42c24f333515"), " B-dul.Eroilor de la Tisa, Timisoara", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Vor participa dansatori din: Rusia, Bulgaria, Hungaria , France , Montenegro , Serbia , Moldova , Czech Republic si Romania ", "International Dance Open" },
                    { new Guid("3857a842-7982-4da6-84c4-857693c37835"), new Guid("b29c0531-3a95-461f-a167-42c24f333515"), "Universitatea Politehnica Timişoara", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Chess Contest este un concurs de șah dedicat tuturor elevilor și studenților din toată țara, organizat de Liga AC (Liga Studenților din Facultatea de Automatică și Calculatoare) în colaborare cu Facultatea de Automatică și Calculatoare și Universitatea Politehnica Timișoara. Concursul se desfăşoară în perioada 17-19 noiembrie şi îşi propune să adune cât mai mulţi tineri în Timişoara pentru a-şi arăta strategia în această confruntare a minţii. ", "Chess Contest" },
                    { new Guid("3f73b9aa-e8cf-4204-835f-ba002fc99591"), new Guid("b29c0531-3a95-461f-a167-42c24f333515"), "Sala Constantin Jude (Olimpia), Timisoara", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Ne propunem ca prin evenimentele noastre sa aducem un nou concept dedicat boxului profesionist,sa imbinam sportul cu spectacolul si sa aducem in fata publicului unii dintre cei mai buni sportivi de box si kickboxing din Romania, fiecare dintre acestia confruntandu-se pe reguli de box cu adversari de valoare din Europa, Africa si America Latina intr-o serie de 3 evenimente pe an ", "Noaptea Spartanilor" },
                    { new Guid("6a6d47f7-cf7f-45f7-8bcc-3df88e5f8724"), new Guid("6fd24ed7-d10a-4617-879d-db4c529442fd"), @"Enduro Ranch (Bârnova, Județul Iași)
                ", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Asaltul Lupilor- evenimentului te aşteaptă pe un teren accidentat de 6 Km, perfect ca să-ţi testeze limitele. Vei alerga prin pădure, te vei târî prin şanţuri, te vei căţăra pe funii, vei traversa râpe, vei sări peste garduri, te vei împiedica sau nu de rădacinile copacilor şi nu în ultimul rând te vei murdări de noroi … dar te vei distra ! ", "Asaltul Lupilor" },
                    { new Guid("5c68bd16-4522-4a58-b474-68460447fd9f"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), " Strada Michelangelo - Strada 20 Decembrie 1989,Timisoara", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Parcul Rozelor. Situat în centrul oraşului, la doar câțiva pași de malul râului Bega, Parcul Rozelor reprezintă o altă atracție de renume a Timişoarei. De fapt, s-ar putea spune că faima Timişoarei de oraş al parcurilor sau oraş al trandafirilor este în mare măsură datorată acestui parc.", "Parcul Rozelor" },
                    { new Guid("6975b9a6-fdcc-4147-b464-cda505bf3301"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), " Strada Hector, Timișoara", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Bastionul Maria Theresia-Aflat în zona centrală, între Hotel Continental și Fântâna Punctelor Cardinale (pe strada Hector), Bastionul Maria Theresia este un monument în stil baroc de o mare însemnătate istorică, fiind cea mai mare bucată de zid păstrată din vechea cetate a Timișoarei.", "Bastionul Maria Theresia" },
                    { new Guid("bde879ee-058e-43d1-b4a1-0b1ddab4096e"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Bulevardul Regele Ferdinand I, Timișoara", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Catedrala Mitropolitană din Timișoara marchează cealaltă intrare principală în centrul orașului, fiind dispusă în partea de sud a pieței. Catedrala este fără îndoială una dintre clădirile care îți va atrage privirea indiferent în ce parte a centrului te vei afla, doar este cel mai mare edificiu religios din oraș. Impresionează atât prin arhitectura somptuoasă care îmbină stilul bizantin cu cel moldovenesc cât și prin dimensiunile sale vaste", "Catedrala Mitropolitană din Timișoara" },
                    { new Guid("3d5124c4-604d-4e94-8be6-d12e561b9df3"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Strada Mărășești 2, Timișoara 300086", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Clădirea Palatului Culturii (cea care mărginește centrul în parte de nord) adăpostește astăzi Opera Națională Română și cele trei teatre de stat Teatrul National Mihai Eminescu, Teatrul Maghiar de Stat Csiky Gergely și Teatrul German de Stat (o situație unică și totodată o premieră în Europa). Dacă inițial clădirea avea exteriorul în stil Renaissance, în urma celor două mari incendii din 1880 și 1920, au mai rămas intacte doar aripile", "Palatului Culturii " },
                    { new Guid("2de0ef77-30c6-4368-b77a-1aeca56d766d"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), " Strada Vasile Alecsandri 3, Timișoara 300078", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Jack's Bistro", "Jack's Bistro" },
                    { new Guid("90454ed5-0745-4701-a871-632d27030cdd"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), "Joy Pub", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Joy Pub", "Joy Pub" },
                    { new Guid("03f004fc-fdd4-45d2-a287-ae16be8f005f"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), " Strada Eugeniu de Savoya 11, Timișoara 300085", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Enoteca de Savoya", "Enoteca de Savoya" },
                    { new Guid("6cf16e55-53a3-48ec-9171-506c70ae86b7"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), "Strada Eugeniu de Savoya 9, Timișoara", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "The Scotland Yard", "The Scotland Yard" },
                    { new Guid("21cfb433-f679-4b17-8588-3c9cb4269821"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), " str.Aries, Nr.19(Casa Tineretului), 300736 Timisoara", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "The 80's Pub", "The 80's Pub" },
                    { new Guid("46769690-115a-4f74-8351-05324b1d7300"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Strada Republicii 42, Cluj-Napoca 400015", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Grădina Botanică - Fondată în anul 1872 și considerată astăzi muzeul național, Grădina Botanică este una dintre primele, cele mai mari și cele mai complexe astfel de grădini din sud-estul Europei. Întinzându-se pe o suprafață de 14 hectare, are ca principale atracții grădina japoneză, grădina romană, serele cu plante tropicale și ecuatoriale.", "Grădina Botanică " },
                    { new Guid("947d24d0-95f8-4676-8d9e-ee2e40484d32"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Piața Unirii ", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Piața Unirii - Asemenea Pieței Muzeului, Piața Unirii se mândrește cu unele dintre cele mai importante ansambluri arhitectonice gotice, baroce și neo-baroce din Transilvania: Biserica Romano-Catolică Sf. Mihail, Muzeul de Artă, Muzeul Farmaciei, pe care nu am mai apucat să-l vizităm, statuia lui Matia Corvin, Strada în oglindă și vechile palate nobiliare.", "Piața Unirii " },
                    { new Guid("a92e7f20-f0e1-49eb-92ea-55818df70ef0"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), " Piața Muzeului, Cluj-Napoca 400000", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Sax", "Sax" },
                    { new Guid("9ed03a76-916f-4625-b5b9-624e1fe4429e"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), " Bulevardul Ștefan cel Mare și Sfânt nr. 28, Iași 700259", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Mănăstirea Sfinții Trei Ierarhi din Iași- Considerat un monument arhitectural de mare valoare în Iași și în întreaga țară, Mănăstirea Sfinții Trei Ierarhi atrage atenția prin arhitectura sa impresionantă și datorită decorațiunilor sale unice din piatră, care împodobesc fațadele superioare. Aceasta a fost zidită inițial pentru a inaugura domnia marelui voievod de odinioară, Vasile Lupu. Aceasta a fost restaurată din punct de vedere arhitectural în perioada 1882 – 1887, amenajarea interiorului său și realizarea picturilor continuând până în anul 1898.", "Mănăstirea Sfinții Trei Ierarhi din Iași" },
                    { new Guid("80f727bd-e502-4407-b5ea-6d04e516602b"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Strada Agatha Bârsescu nr. 18, Iași 700074", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Teatrul Național Vasile Alecsandri- Datând din anul 1896, Teatrul Național Vasile Alecsandri este cel mai vechi din țară și unul dintre cele mai frumoase din Europa. Interiorul său elegant și bogat decorat a fost inspirat din stilurile arhitecturale baroce și rococo, unul dintre plafoanele sale fiind pictate de celebrul pictor vienez Alexander Goltz. Cortina sa a fost, de asemenea, pictată manual, simbolizând cele trei etape ale vieții și fiind considerată o alegorie a Unificării României.", "Teatrul Național Vasile Alecsandri" },
                    { new Guid("0d851d8f-e66e-4057-a99b-a4ea567167c9"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Bulevardul Ștefan cel Mare și Sfânt 16, Iași 700064", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Mitropolia Moldovei și a Bucovinei- Aceasta este renumită pentru că adăpostește Moaștele Sfintei Cuvioase Parascheva, ocrotitoarea Moldovei. Monumentala catedrală ieșeană este marcată de patru turle masive, iar arhitectura sa este inspirată de stilul baroc, care marchează atât elementele decorative din exterior cât și cele din interiorul său.", "Mitropolia Moldovei și a Bucovinei" },
                    { new Guid("1669aebd-cf11-4bc8-ab80-21cd27996cff"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Bulevardul Carol I nr. 31, Iași 700462", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Parcul Copou- Amenajarea celebrului Parc Copou din Iași a început în perioada 1833-1834. Acesta adăpostește Monumentul Legilor Constituționale, cel mai vechi monument din țara noastră. Cunoscut și ca Obeliscul cu lei, acesta a fost creat de Mihail Singurov în anul 1834. Reprezentat de o coloană din piatră de 15 m înălțime și cu o greutate ce depășește 10 tone, celebrul monument reprezintă un simbol al celor patru puteri europene care au recunoscut independența Țărilor Române.", "Parcul Copou" },
                    { new Guid("cb78893a-ce4b-4312-be5b-0c764b6c9899"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Bulevardul Ștefan cel Mare și Sfânt 1, Iași 700028", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Palatul Culturii- Această clădire impresionantă este sediul a numeroase instituții culturale de prestigiu din acest oraș și a fost pusă în valoare prin recenta sa reabilitare. În cadrul Palatului Culturii din Iași vei descoperi patru muzee, care te vor ajuta să înțelegi mai bine istoria și cultura acestor meleaguri: Muzeul de Istorie al Moldovei, Muzeul Etnografic, Muzeul de Artă și Muzeul Științei și Tehnologiei Ștefan Procopiu.", "Palatul Culturii" },
                    { new Guid("a576f6e9-4762-4c5f-846f-afca970ab834"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), "Piața Unirii nr. 6, Iași 700055", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Cafeneaua Piața Unirii", "Cafeneaua Piața Unirii" },
                    { new Guid("e28e09a9-2753-400c-b443-0b69926e0b48"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), "Strada Moldovei 20, Iași 700046", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Vivo", "Vivo" },
                    { new Guid("80e52dcc-6ac2-43c0-83f5-5bae91afe8eb"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), " Bulevardul Ștefan cel Mare și Sfânt nr. 8, Iași 700063", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Bistro \"La noi\"", "Bistro \"La noi\"" },
                    { new Guid("a0ca8e8e-416e-4b27-bf28-0a514a3f1607"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), " Bulevardul Profesor Dimitrie Mangeron nr. 71, Iași 700050", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Kraft Pub & Restaurant", "Kraft Pub & Restaurant" },
                    { new Guid("60910ea6-723a-4b07-bb0f-c47c24e2b3da"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), "Strada Alexandru Lăpușneanu nr. 16, Iași 700057", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Beer Zone", "Beer Zone" },
                    { new Guid("8b6dfcec-9e55-4458-b38e-e226d90936ac"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), "Piața Unirii nr. 5, Iași 700056", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Panoramic", "Panoramic" },
                    { new Guid("d41a49bf-fbe5-48c5-a49d-2fbb754c5cf9"), new Guid("0b62737d-cdf3-4dbc-916f-bacba53d78bf"), "Bulevardul Carol I nr. 4, Iași 700505", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", " Student Travel" },
                    { new Guid("6ab578ee-f448-47be-90e0-a133d3cbf926"), new Guid("0b62737d-cdf3-4dbc-916f-bacba53d78bf"), @"Copou
                Aleea Veronica Micle 8
                langa FEAA, dupa Teo's Cafe", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "American Experience" },
                    { new Guid("e797bee1-94af-458b-8c7d-c9087d51bc88"), new Guid("85a76a5c-322d-47b6-b516-6da385c50ac4"), "Strada Cloşca 9, Iași 700259", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Scopul organizatiei este promovarea credinţei şi a spiritualităţii ortodoxe în rândul tinerilor, cu prioritate în mediul univASCOR:  https://ascoriasi.ro/", "ASCOR" },
                    { new Guid("970745f7-d607-4a98-88be-9698b6c29365"), new Guid("85a76a5c-322d-47b6-b516-6da385c50ac4"), "Cămin T11, Aleea Profesor Gheorghe Alexa, Iași 700259", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "BEST încearcă să ajute studenţii europeni să devină mai deschiși spre colaborarea internaţională, oferindu-le șansa de a se familiariza cu diversitatea culturală europeană, dezvoltându-le, în același timp, capacitatea de a lucra în medii internaționale.BEST:  https://bestis.ro/", "BEST" },
                    { new Guid("a94972ea-db5e-4ff4-b922-ba1ec0437a44"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Bulevardul Ștefan cel Mare și Sfânt nr. 10, Iași 700063", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Biblioteca Gheorghe Asachi- Biblioteca Gheorghe Asachi din Iași a fost desemnată ca fiind cea mai frumoasă din lume, în cadrul unei competiții desfășurate online la care au participat nume celebre din întreaga lume, precum Biblioteca Colegiului Trinity din Dublin, Biblioteca Regală Portugheză din Buenos Aires și Biblioteca Națională din Praga.", "Biblioteca Gheorghe Asachi" },
                    { new Guid("21be9e06-507e-49d5-a338-0ea56ed2f2a1"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Str. Râpa Galbenă,Iași 700259", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Esplanada Elisabeta (Râpa Galbenă)- Râpa Galbenă din Iași, așa cum este cunoscută printre localnici, este o zonă importantă, localizată la baza Dealului Copou. Esplanada Elisabeta din Iași a fost construită la sfârșitul secolului al XIX-lea, scopul acesteia fiind acela de facilitare a circulației pietonilor către zona centrală a orașului.", "Esplanada Elisabeta " },
                    { new Guid("73d14dff-59e9-4c0e-8d16-41baf40adf98"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Corp AUniversitATEA Alexandru Ioan Cuza , Bulevardul Carol I 11, Iași 700506", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Sala Pașilor Pierduți- Dacă în cadrul periplului tău turistic te abați și pe la celebra Universitate “Alexandru Ioan Cuza” din Iași, trebuie să vizitezi și Sala Pașilor Pierduți. Picturile murale unice ale celebrului artist Sabin Bălașa te vor impresiona, acesta reușind să introducă acest spațiu pe harta locurilor de referință ale artei universale, prin măiestria sa artistică.", "Sala Pașilor Pierduți" },
                    { new Guid("0ca21e03-0a01-4598-886a-deb367c4e762"), new Guid("ed76b22c-15d0-4777-97c3-affe4a5d3c50"), "Strada Dumbrava Roșie nr. 7-9, Iași 700487", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Grădina Botanică din Copou- Înființată în anul 1856, Grădina Botanică Anastasie Fătu poartă numele fondatorului său, un celebru medic și susținător al remediilor naturiste din acea perioadă. Aceasta este prima grădină universitară deschisă în țara noastră și cea mai mare din România în acest moment.", "Grădina Botanică din Copou" },
                    { new Guid("27d43b3e-1076-47a3-82b4-b4e2af909f78"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), " Cardinal Iuliu Hossu Street 3, Cluj-Napoca 400029", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Samsara Foodhouse", "Samsara Foodhouse" },
                    { new Guid("226919cc-58fc-4a56-aa06-32b6bf70f813"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), "Strada Universității 6, Cluj-Napoca 400091", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Casa TIFF", "Casa TIFF" },
                    { new Guid("4f0db822-1d61-40d9-9742-50c19179a4c0"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), "Strada Matei Corvin Nr 2, Cluj-Napoca 400000", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Old Shepherd", "Old Shepherd" },
                    { new Guid("cebd6255-3a33-41b4-aa97-52a834b1df07"), new Guid("dc82deba-47e5-472c-a97d-6c14cd2dd5c6"), "Strada Vasile Goldiș 4, Cluj-Napoca 400112", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "O'Peter's Irish Pub &Grill", "O'Peter's Irish Pub &Grill" },
                    { new Guid("3a55e8bb-e684-471b-aa55-81d20656cab4"), new Guid("0b62737d-cdf3-4dbc-916f-bacba53d78bf"), "Strada Moldovei 1, Cluj-Napoca 400380", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", "Adira Work & Travel" },
                    { new Guid("de78b66f-6754-4e46-9b1b-3eeb97a1c778"), new Guid("0b62737d-cdf3-4dbc-916f-bacba53d78bf"), "Strada Piezisa Nr 19", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "American Experience" },
                    { new Guid("55fe4f37-920c-4923-b81a-fb29c638b011"), new Guid("85a76a5c-322d-47b6-b516-6da385c50ac4"), "Strada Frumoasă, Nr. 31, Cluj", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Și-au propus să aibă impact asupra mediului economic românesc, oferind acces la resurse de învățare care te vor ajuta să-ți dezvolți competențele profesionale, dar și sociale. Proiectele lor sunt practice, interactive și te aduc cu un pas mai aproape de cariera pe care ți-o dorești. ", "ASER" },
                    { new Guid("6d1df314-ae9b-4bf8-ac75-de1e91b7d46a"), new Guid("22c6439b-bb98-4d4e-a69e-02fce41bfd15"), "Piata Victoriei, Timisoara", new Guid("0c91dac7-97b2-4599-818a-e597531d50fe"), "Festivalul Jazz TM este un festival de jazz care se desfășoară în aer liber, în Piața Victoriei, în luna iulie și aduce pe scenă artiști din scena internațională a muzicii Jazz.", "Festivalul Jazz TM" },
                    { new Guid("da550954-6ce0-4cba-812d-8c306e6234ae"), new Guid("85a76a5c-322d-47b6-b516-6da385c50ac4"), "Strada Păstorului 11, Cluj-Napoca 400338", new Guid("64893c57-50c2-4a84-a58a-7f1983214276"), "Organizația Studenților de la Universitatea Tehnică oferă un cadru informal în care viitorii ingineri pot construi fundația carierei lor.", "OSUBB" },
                    { new Guid("a12242e8-76f7-46ce-97aa-8400e43c5f77"), new Guid("22c6439b-bb98-4d4e-a69e-02fce41bfd15"), " Iași, str. V. Pogor, nr. 4, 700110.", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Festivalul Internațional de Literatură și Traducere Iași (FILIT) este un festival internațional care are loc anual în octombrie, în Iași. Festivalul reunește la Iași profesioniști din domeniul cărții, atât din țară, cât și din străinătate. Scriitori, traducători, editori, organizatori de festival, critici literari, librari, distribuitori de carte, manageri și jurnaliști culturali – cu toții se află, de-a lungul celor cinci zile de festival, în centrul unor evenimente destinate, pe de o parte, publicului larg, pe de altă parte, specialiștilor din domeniu.", "FILIT" },
                    { new Guid("987e9ed6-0dc5-41b1-a025-e672c540653f"), new Guid("22c6439b-bb98-4d4e-a69e-02fce41bfd15"), "Strada Vasile Lupu 78A, Iași 700350", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Afterhills este cel mai tânăr festival de muzică de anvergură din România, desfășurat în județul Iași, fiind cel mai mare și important festival din regiunea Moldova.", "Afterhills " },
                    { new Guid("12bbbc11-6289-4315-a373-0a5e16222140"), new Guid("22c6439b-bb98-4d4e-a69e-02fce41bfd15"), @"Piața Unirii 5
                Iași", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Se organizeaza seri de film in diferite locatii, unde sunt invitati oameni importanti ai filmului romanesc.", "Serile de Film Romanesc" },
                    { new Guid("641761e2-6aeb-44df-9f5b-b49872810e7c"), new Guid("6fd24ed7-d10a-4617-879d-db4c529442fd"), "Start/Stop: Cluj Arena, Cluj", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Maratonul de Ciclism International din nou la Cluj(Perioada Mai-Iunie)- evenimentul sportiv  aduce la Cluj cel mai mare număr de cicliști din România, într-un context nou și plin de surprize. Vor exista competiții de ciclism și alergare pentru adulți, competiții pentru copii, competiție de spinning, o zonă culinară și una de camping cu foc de tabără precum și alte activități de petrecere a timpului liber.", "Maratonul de Ciclism International din nou la Cluj" },
                    { new Guid("7e9a1a83-265d-4019-bb2e-86f0df28e3d9"), new Guid("6fd24ed7-d10a-4617-879d-db4c529442fd"), "Strat/Stop: Palatul Culturii, Iasi", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Maratonul International Iasi- Maratonul International Iasi isi propune sa fie un eveniment sportiv de referinta pentru Municipiul Iasi, dar si la nivel regional, national si international. Obiectivul principal este unul social, fondurile rezultate in urma organizarii evenimentului fiind destinate finantarii proiectului de Infiintare si functionare a punctelor de prim ajutor si interventie in caz de dezastre in principalele cartiere ale Iasului", "Maratonul International Iasi" },
                    { new Guid("90743fb9-228b-43bc-b49a-6d0fdd5da735"), new Guid("6fd24ed7-d10a-4617-879d-db4c529442fd"), "Strada Pantelimon Halipa 6B, Iași", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Întreținere corporală- săli de sport cu prețuri speciale pentru student: Oxygen, Let’ s move", "Întreținere corporală" },
                    { new Guid("22129b7d-8d34-4d87-8bf4-7dc165df21a4"), new Guid("6fd24ed7-d10a-4617-879d-db4c529442fd"), "Strada Stihii 2, Iași 700083", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Pilates- Pilates este o metodă de întărire a mușchilor profunzi, care sunt responsabili cu menținerea posturii. (Tonus Plus- sală )", "Pilates" },
                    { new Guid("0ed87b0c-ce08-40b2-b43e-4729e48ee238"), new Guid("22c6439b-bb98-4d4e-a69e-02fce41bfd15"), "Smida, 18, Smida 407082, Cluj", new Guid("448ba2ca-a744-47b2-93c0-e7c8a494a3c6"), "Smida Jazz, festival dedicat jazz-ului de avangardă ce se desfășoară an de an în pitorescul sat Smida (comuna Beliș, județul Cluj - în mijlocul Parcului Natural Apuseni). Pe parcursul a 3 zile, vom petrece o vacanță în Apuseni, cu tot felul de activități în aer liber și concerte ale grupurilor internaționale și din România. ", "Smida Jazz" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "PasswordHash", "StudentId", "UserTypeId", "Username" },
                values: new object[] { new Guid("dfa0726a-38cf-4a68-8175-3e45894130b0"), "DoFestAdmin@gmail.com", "16wXr0+4iPYC6l7W0vIPUQ==.icVdqbujnuVt5RA9BlqRIYAXwqfht7AzRQfimU6OMDs=", null, new Guid("7af8f587-d5b2-4e34-b0a2-c0346b50ab82"), "DoFestAdmin" });

            migrationBuilder.InsertData(
                table: "BucketList",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { new Guid("fcf236f1-bad2-40c2-8465-c0752c886fec"), "Admin bucketList", new Guid("dfa0726a-38cf-4a68-8175-3e45894130b0") });

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
