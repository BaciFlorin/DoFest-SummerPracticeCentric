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
                    { new Guid("189e7b41-2da9-44f8-83ff-b7eb2f9eddbb"), "Voluntariat" },
                    { new Guid("feba6c01-179d-4772-99b3-8987e84448f3"), "Work&Travel" },
                    { new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), "Pub&Restaurants" },
                    { new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Turism" },
                    { new Guid("89ecab70-8733-4f16-8577-a21c6486263a"), "Sporturi" },
                    { new Guid("243d24af-18b8-4aba-94ab-20e884fe1e44"), "Sport" },
                    { new Guid("5d175560-d13a-41ae-aead-05f3eec15db4"), "Festivaluri" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Iași" },
                    { new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Cluj" },
                    { new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Timișoara" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("bfc94fb5-7dfb-4b27-a36c-960327642c38"), "Full access", "Admin" },
                    { new Guid("0a7540b5-4ce8-4881-9849-e87065cc521e"), "Normal access", "Normal user" }
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "Id", "ActivityTypeId", "Address", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("08b96074-1e91-4bb4-aed8-6cc659c03fe2"), new Guid("189e7b41-2da9-44f8-83ff-b7eb2f9eddbb"), "Universitatea Alexandru Ioan Cuza, Corp B, Bulevardul Carol I 22, Iași 700505", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "AIESEC este o platformă internațională de dezvoltare pentru tineri, care are ca scop descoperirea şi dezvoltarea potențialului acestora, pentru a avea un impact pozitiv în societate. Înființată în 1948 ca organizație non-politică și non-profit, AIESEC permite indivizilor să-şi modeleze şi să-şi îmbogățească propria experiență printr-un sistem complex de oportunități.AIESEC:  shorturl.at/qyDIZ", "AIESEC" },
                    { new Guid("bb80b047-c22a-4064-a580-588719171eb8"), new Guid("189e7b41-2da9-44f8-83ff-b7eb2f9eddbb"), "Aleea Crivaia, Timișoara", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Proiecte create cu scopul de a contribui la o tara in care oamenii se implica si sunt parte din schimbarea pe care si-o doresc, devenind la randul lor inspiratie pentru ceilalt.Actiuni de educare a tinerilor, aplicatia LDIR,reamenajari de spatii destinate diverselor categorii sociale si alte proiecte create pentru a proteja mediul si a contribui la rezolvarea problemei deseurilor", "Let’s Do It, Romania!" },
                    { new Guid("8d7b7ab3-57a2-48da-b7fe-01444018752c"), new Guid("5d175560-d13a-41ae-aead-05f3eec15db4"), "Parcul Botanic, Timisoara", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Festivalul Acces Art – Festival organizat în aer liber, centrat pe ateliere de arte creative.", "Festivalul Acces Art" },
                    { new Guid("20484be6-2871-4f2e-9fd0-85735168ee03"), new Guid("5d175560-d13a-41ae-aead-05f3eec15db4"), "Piata Unirii, Cluj", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Este primul festival internațional de film de lungmetraj din România, se bazează pe lungmetraje sau scurtmetraje necomerciale produse în special în țările europene. Marele premiu al festivalului, Trofeul Transilvania, opera artistului Teo Mureșan, este o statuetă ce reprezintă un turn tăiat.", "TIFF" },
                    { new Guid("0998ebe9-7f13-4d46-9062-93b998ac2b71"), new Guid("5d175560-d13a-41ae-aead-05f3eec15db4"), " Bánffy Castle, Cluj-Napoca", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Festivalul îmbină în lineup zone muzicale variate cum ar fi rock, reggae, hip hop, trap, muzică electronică sau indie cu tehnologia, cu arta alternativă, arta stradală și cultura.", "Electric Castle" },
                    { new Guid("71e2f0e7-7b51-485a-8b0c-5a307b09d4b8"), new Guid("5d175560-d13a-41ae-aead-05f3eec15db4"), "Untold Festival Arena, Cluj-Napoc", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Untold Festival este cel mai mare festival de muzică din România.[1][2] Acesta se desfășoară în fiecare an pe Cluj Arena", "UNTOLD" },
                    { new Guid("1ee60ea4-2203-4a8e-876b-7a3042b2ecbf"), new Guid("243d24af-18b8-4aba-94ab-20e884fe1e44"), @" 
                Dinias
                ,Timisoara", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Primul targa rally organizat in Romania. Toti banii adunati vor fi donati Spitalului de Copii ”Louis Turcanu”. ", "Memorialul Daniela Zaharie" },
                    { new Guid("dd60f8fd-c83e-4324-9f83-6b911544c8c4"), new Guid("89ecab70-8733-4f16-8577-a21c6486263a"), "trada Băii nr 17, Cluj-Napoca 400389", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Rafting, Parapanta, Tir cu arcul, Caiac, Paintball, Motoparapanta- organizate de Transilvania eXtreme Adventures  care o multime de activitati outdoor care te fac sa uiti de stresul zilnic si sa te reincarci cu energie. O modalitate frumoasa de a adauga in viata ta un plus de miscare si sanatate.", "Transilvania eXtreme Adventures" },
                    { new Guid("307039d0-3b0f-494b-9711-edc30f8f01dc"), new Guid("89ecab70-8733-4f16-8577-a21c6486263a"), "In curtea interioara, Strada Berăriei nr. 6, Cluj-Napoca 400380", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Free Wall (Rock Climbing Gym).Sali  de escaladă&bouldering", "Free Wall Climbing" },
                    { new Guid("be3450a6-eed2-4169-8eea-59ccb20e39fb"), new Guid("89ecab70-8733-4f16-8577-a21c6486263a"), "Bride's Veil Waterfall", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Runsilvania Wild Race. Runsilvania WILD RACE este o cursă de trail running, Traseul de alergare trece pe lângă Cascada Vălul Miresei, Peşterile Vârfuraşul şi Lespezi, ajunge la Pietrele Albe şi urcă pe Vf. Vlădeasa (la proba de Maraton), trece prin grote şi segmente tehnice asigurate cu lanţuri şi corzi, podeţe şi scări din lemn.", "Runsilvania Wild Race" },
                    { new Guid("98af1001-af5d-44f0-b9f6-847eacf9e39f"), new Guid("89ecab70-8733-4f16-8577-a21c6486263a"), " Baza Sportivă Unirea, Cluj-Napoca ", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Făget Winter Race- Făget Winter Race este un primul concurs de alergare din an. Se desfaşoară în pădurea Făget din Cluj-Napoca, iarna, in al doilea week-end al lunii ianuarie.", "Făget Winter Race" },
                    { new Guid("26577e93-7750-4a7f-9bed-9f636b6abcd8"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Centrul Trimisoarei", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Centrul Timișoarei-Centrul este primul dintre locurile cu care vei dori să faci cunoștiință imediat ce ai ajuns și ți-ai lăsat bagajele în cameră. Începând cu Palatul Culturii și până la Catedrala Mitropolitană, centrul orașului cunoscut și sub numele de Piața Victoriei sau Piața Operei concentrează un număr impresionant de palate și clădiri care încă păstrează gloria și arhitectura spectaculoasă de pe vremuri.", "Centrul Timișoarei" },
                    { new Guid("990d0260-0b4d-4ee6-8b74-a343aa42a115"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Aleea Durgăului 7, Turda 401106", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Salina Turda-A devenit celebră în ultimii ani în România, așa că ne este greu să credem că mai e cineva care să nu fi auzit de ea. Ca să nu mai vorbim că are și o poveste interesantă, trecând de la statutul de salină de renume a Transilvaniei, la începuturi, la o decădere neașteptată datorată concurenței, salina de la Ocna Mureș. Paradoxal, abia cel de-Al Doilea Război Mondial a readus-o în memoria colectivă, fiind folosită ca adăpost antiaerian.", "Salina Turda" },
                    { new Guid("38f2e1ea-3cd3-4a1f-b355-1e2dfc64aec0"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Bd. 21 decembrie 1989 nr. 41, Cluj", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), " Biserica Reformată - Este una dintre cele mai masive construcții gotice din întreaga Transilvanie, având mai degrabă aspectul unei cetăți. Aici se organizează periodic tot felul de concerte și evenimente", " Biserica Reformată " },
                    { new Guid("a23e51ce-c7a5-459b-81d7-92de03d02686"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), " Strada Baba Novac 2, Cluj-Napoca 400097", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Turnul Croitorilor - Turnul face parte din vechiul zid de apărare al orașului, care înconjura în vremuri de demult o suprafață de 45 hectare, cât măsura cetatea, și este unul dintre puținele care s-au păstrat într-o stare foarte bună până în zilele noastre (practic, turnul este astăzi intact", "Turnul Croitorilor " },
                    { new Guid("36c58505-159c-4084-b3ba-b1aaa69185d3"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Strada Emil Racoviță 60a, Cluj-Napoca 400124", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), " Cetățuia - De fapt, Cetățuia este un parc situat la o altitudine de 405 metri, de mici dimensiuni, ce-i drept, cu vedere asupra orașului, deci nu este deloc de ocolit.", " Cetățuia " },
                    { new Guid("8cb994d5-31e1-4179-ad5c-91f719c3f91b"), new Guid("189e7b41-2da9-44f8-83ff-b7eb2f9eddbb"), " Biblioteca Judeteana “Octavian Goga”, Calea Dorobanților 104, Cluj-Napoca, Sala de lectura de la etajul 2", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Ajungem MARI este singurul program demarat de Asociația Lindenfeld și susține educația copiilor din centre de plasament și medii defavorizate.", "Ajungem Mari" },
                    { new Guid("72525fdf-da7e-42b9-abd9-6239a700f07f"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Strada Republicii 42, Cluj-Napoca 400015", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Grădina Botanică - Fondată în anul 1872 și considerată astăzi muzeul național, Grădina Botanică este una dintre primele, cele mai mari și cele mai complexe astfel de grădini din sud-estul Europei. Întinzându-se pe o suprafață de 14 hectare, are ca principale atracții grădina japoneză, grădina romană, serele cu plante tropicale și ecuatoriale.", "Grădina Botanică " },
                    { new Guid("d2bf1d0c-467a-49fd-80fa-c2847749ec79"), new Guid("feba6c01-179d-4772-99b3-8987e84448f3"), "Strada Francesco Griselini 2, Timișoara 300054", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "GTS * GOTOSUA Work & Travel" },
                    { new Guid("308e9b62-fc5a-4618-926d-f63666012e37"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), " str.Aries, Nr.19(Casa Tineretului), 300736 Timisoara", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "The 80's Pub", "The 80's Pub" },
                    { new Guid("6c76eab9-d5de-45fc-9d2c-23f723ea9ae9"), new Guid("5d175560-d13a-41ae-aead-05f3eec15db4"), "Ambasada/Timisoara", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Festivalul Internațional de Tango Argentinian - Festivalul are loc anual, începând cu 2013, în ultima săptămână a lunii mai. Acest unic eveniment din vestul țării este organizat de Școala de Tango Argentinian „Tango Embrace”, din cadrul Asociației \"Art Embrace\".", "Festivalul Internațional de Tango Argentinian" },
                    { new Guid("ad1037fb-13ba-4be3-b84f-e6fa0ccaf427"), new Guid("5d175560-d13a-41ae-aead-05f3eec15db4"), "Aeroclubul „Alexandru Matei” ,Iași", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Hangariada înseamnă 3 zile de fericire cu ½ muzică și ½ zbor. Privești cerul, saltă inima, îți strângi prietenii de mână, lași gândul să-ți zboare prin iarba cosită. Te întinzi pe spate, îți pui ochelarii de soare, „oare de ce nu m-am făcut pilot/cântăreț ca-n compunerea dintr-a patra?” Aplauze! Ridică-te, înverzește-ți tălpile pantofilor, cântă și dansează odată cu cei de pe scenă. Și-apoi, a doua zi, de la capăt.", "Hangariada" },
                    { new Guid("727eaa90-49a8-4246-91b2-eee0f9b5904c"), new Guid("243d24af-18b8-4aba-94ab-20e884fe1e44"), " B-dul.Eroilor de la Tisa, Timisoara", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Vor participa dansatori din: Rusia, Bulgaria, Hungaria , France , Montenegro , Serbia , Moldova , Czech Republic si Romania ", "International Dance Open" },
                    { new Guid("09c7d8e4-e8d3-4ac9-8595-2339ec3dd06c"), new Guid("243d24af-18b8-4aba-94ab-20e884fe1e44"), "Universitatea Politehnica Timişoara", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Chess Contest este un concurs de șah dedicat tuturor elevilor și studenților din toată țara, organizat de Liga AC (Liga Studenților din Facultatea de Automatică și Calculatoare) în colaborare cu Facultatea de Automatică și Calculatoare și Universitatea Politehnica Timișoara. Concursul se desfăşoară în perioada 17-19 noiembrie şi îşi propune să adune cât mai mulţi tineri în Timişoara pentru a-şi arăta strategia în această confruntare a minţii. ", "Chess Contest" },
                    { new Guid("8c042931-3145-4754-825f-2fe4c1633648"), new Guid("243d24af-18b8-4aba-94ab-20e884fe1e44"), "Sala Constantin Jude (Olimpia), Timisoara", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Ne propunem ca prin evenimentele noastre sa aducem un nou concept dedicat boxului profesionist,sa imbinam sportul cu spectacolul si sa aducem in fata publicului unii dintre cei mai buni sportivi de box si kickboxing din Romania, fiecare dintre acestia confruntandu-se pe reguli de box cu adversari de valoare din Europa, Africa si America Latina intr-o serie de 3 evenimente pe an ", "Noaptea Spartanilor" },
                    { new Guid("f4a2ae66-8b2e-40ae-a26c-a1591b810e26"), new Guid("89ecab70-8733-4f16-8577-a21c6486263a"), @"Enduro Ranch (Bârnova, Județul Iași)
                ", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Asaltul Lupilor- evenimentului te aşteaptă pe un teren accidentat de 6 Km, perfect ca să-ţi testeze limitele. Vei alerga prin pădure, te vei târî prin şanţuri, te vei căţăra pe funii, vei traversa râpe, vei sări peste garduri, te vei împiedica sau nu de rădacinile copacilor şi nu în ultimul rând te vei murdări de noroi … dar te vei distra ! ", "Asaltul Lupilor" },
                    { new Guid("2a552749-98f5-4e06-afe0-f039eb6090cc"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), " Strada Michelangelo - Strada 20 Decembrie 1989,Timisoara", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Parcul Rozelor. Situat în centrul oraşului, la doar câțiva pași de malul râului Bega, Parcul Rozelor reprezintă o altă atracție de renume a Timişoarei. De fapt, s-ar putea spune că faima Timişoarei de oraş al parcurilor sau oraş al trandafirilor este în mare măsură datorată acestui parc.", "Parcul Rozelor" },
                    { new Guid("78b04964-6a66-4b5f-9412-5c5c7eace887"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), " Strada Hector, Timișoara", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Bastionul Maria Theresia-Aflat în zona centrală, între Hotel Continental și Fântâna Punctelor Cardinale (pe strada Hector), Bastionul Maria Theresia este un monument în stil baroc de o mare însemnătate istorică, fiind cea mai mare bucată de zid păstrată din vechea cetate a Timișoarei.", "Bastionul Maria Theresia" },
                    { new Guid("f3362985-20e3-4291-a84f-14ce902781a7"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Bulevardul Regele Ferdinand I, Timișoara", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Catedrala Mitropolitană din Timișoara marchează cealaltă intrare principală în centrul orașului, fiind dispusă în partea de sud a pieței. Catedrala este fără îndoială una dintre clădirile care îți va atrage privirea indiferent în ce parte a centrului te vei afla, doar este cel mai mare edificiu religios din oraș. Impresionează atât prin arhitectura somptuoasă care îmbină stilul bizantin cu cel moldovenesc cât și prin dimensiunile sale vaste", "Catedrala Mitropolitană din Timișoara" },
                    { new Guid("9986d2c5-6234-45a3-8f94-60a7270b84ca"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Strada Mărășești 2, Timișoara 300086", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Clădirea Palatului Culturii (cea care mărginește centrul în parte de nord) adăpostește astăzi Opera Națională Română și cele trei teatre de stat Teatrul National Mihai Eminescu, Teatrul Maghiar de Stat Csiky Gergely și Teatrul German de Stat (o situație unică și totodată o premieră în Europa). Dacă inițial clădirea avea exteriorul în stil Renaissance, în urma celor două mari incendii din 1880 și 1920, au mai rămas intacte doar aripile", "Palatului Culturii " },
                    { new Guid("04c62b8c-3368-4e11-895f-12dde159f90f"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), " Strada Vasile Alecsandri 3, Timișoara 300078", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Jack's Bistro", "Jack's Bistro" },
                    { new Guid("7d996476-8862-4114-9c35-ae1815a62506"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), "Joy Pub", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Joy Pub", "Joy Pub" },
                    { new Guid("e0e379f9-249f-4378-af00-c39fd3eeff03"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), " Strada Eugeniu de Savoya 11, Timișoara 300085", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Enoteca de Savoya", "Enoteca de Savoya" },
                    { new Guid("b21e1e09-28da-4e92-b1f6-357111514e1d"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), "Strada Eugeniu de Savoya 9, Timișoara", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "The Scotland Yard", "The Scotland Yard" },
                    { new Guid("0fd838df-6310-4fbe-bfa6-7e5cc66c27c6"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), "Strada George Coșbuc 1, Timișoara 300048", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "The Drunken Rat Pub", "The Drunken Rat Pub" },
                    { new Guid("772ec4f9-44b4-4636-9ba3-228318285e5c"), new Guid("feba6c01-179d-4772-99b3-8987e84448f3"), @"Parcare Caminele 12-17
                Complex Studentesc, Timisoara", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", "American Experience" },
                    { new Guid("d0462fca-9d3e-4ea5-99b1-7b7628b69904"), new Guid("5d175560-d13a-41ae-aead-05f3eec15db4"), "Sala Barocă a Muzeului de Artă din Timișoara ", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Festivalul Internațional de Literatură de la Timișoara – Festivalul reunește autori români și străini, pentru două zile de lecturi și dialoguri deschise cu publicul.", "Festivalul Internațional de Literatură de la Timișoara " },
                    { new Guid("2ebca04b-2a41-417f-9603-3e23cb5a248a"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Piața Unirii ", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Piața Unirii - Asemenea Pieței Muzeului, Piața Unirii se mândrește cu unele dintre cele mai importante ansambluri arhitectonice gotice, baroce și neo-baroce din Transilvania: Biserica Romano-Catolică Sf. Mihail, Muzeul de Artă, Muzeul Farmaciei, pe care nu am mai apucat să-l vizităm, statuia lui Matia Corvin, Strada în oglindă și vechile palate nobiliare.", "Piața Unirii " },
                    { new Guid("13198ae2-efcf-440c-b51e-24132ed5c015"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), " Cardinal Iuliu Hossu Street 3, Cluj-Napoca 400029", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Samsara Foodhouse", "Samsara Foodhouse" },
                    { new Guid("11421ef2-6b1b-43fa-a515-d0f9acfe67ed"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), " Bulevardul Ștefan cel Mare și Sfânt nr. 28, Iași 700259", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Mănăstirea Sfinții Trei Ierarhi din Iași- Considerat un monument arhitectural de mare valoare în Iași și în întreaga țară, Mănăstirea Sfinții Trei Ierarhi atrage atenția prin arhitectura sa impresionantă și datorită decorațiunilor sale unice din piatră, care împodobesc fațadele superioare. Aceasta a fost zidită inițial pentru a inaugura domnia marelui voievod de odinioară, Vasile Lupu. Aceasta a fost restaurată din punct de vedere arhitectural în perioada 1882 – 1887, amenajarea interiorului său și realizarea picturilor continuând până în anul 1898.", "Mănăstirea Sfinții Trei Ierarhi din Iași" },
                    { new Guid("aec860fd-ead5-4d45-9037-17dc562098cd"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Strada Agatha Bârsescu nr. 18, Iași 700074", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Teatrul Național Vasile Alecsandri- Datând din anul 1896, Teatrul Național Vasile Alecsandri este cel mai vechi din țară și unul dintre cele mai frumoase din Europa. Interiorul său elegant și bogat decorat a fost inspirat din stilurile arhitecturale baroce și rococo, unul dintre plafoanele sale fiind pictate de celebrul pictor vienez Alexander Goltz. Cortina sa a fost, de asemenea, pictată manual, simbolizând cele trei etape ale vieții și fiind considerată o alegorie a Unificării României.", "Teatrul Național Vasile Alecsandri" },
                    { new Guid("a81a5ea5-2ac3-47f1-821b-c34a26d89983"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Bulevardul Ștefan cel Mare și Sfânt 16, Iași 700064", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Mitropolia Moldovei și a Bucovinei- Aceasta este renumită pentru că adăpostește Moaștele Sfintei Cuvioase Parascheva, ocrotitoarea Moldovei. Monumentala catedrală ieșeană este marcată de patru turle masive, iar arhitectura sa este inspirată de stilul baroc, care marchează atât elementele decorative din exterior cât și cele din interiorul său.", "Mitropolia Moldovei și a Bucovinei" },
                    { new Guid("42be1ada-c3ed-4d90-a36b-5cf5df5bff82"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Bulevardul Carol I nr. 31, Iași 700462", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Parcul Copou- Amenajarea celebrului Parc Copou din Iași a început în perioada 1833-1834. Acesta adăpostește Monumentul Legilor Constituționale, cel mai vechi monument din țara noastră. Cunoscut și ca Obeliscul cu lei, acesta a fost creat de Mihail Singurov în anul 1834. Reprezentat de o coloană din piatră de 15 m înălțime și cu o greutate ce depășește 10 tone, celebrul monument reprezintă un simbol al celor patru puteri europene care au recunoscut independența Țărilor Române.", "Parcul Copou" },
                    { new Guid("4b7219c3-8e03-4dac-8389-23d221797e8a"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Bulevardul Ștefan cel Mare și Sfânt 1, Iași 700028", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Palatul Culturii- Această clădire impresionantă este sediul a numeroase instituții culturale de prestigiu din acest oraș și a fost pusă în valoare prin recenta sa reabilitare. În cadrul Palatului Culturii din Iași vei descoperi patru muzee, care te vor ajuta să înțelegi mai bine istoria și cultura acestor meleaguri: Muzeul de Istorie al Moldovei, Muzeul Etnografic, Muzeul de Artă și Muzeul Științei și Tehnologiei Ștefan Procopiu.", "Palatul Culturii" },
                    { new Guid("d371c318-6920-46fa-82b1-619c7636c1b0"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), "Piața Unirii nr. 6, Iași 700055", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Cafeneaua Piața Unirii", "Cafeneaua Piața Unirii" },
                    { new Guid("412cf1d4-3885-4864-89e5-1cd56cfcb790"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), "Strada Moldovei 20, Iași 700046", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Vivo", "Vivo" },
                    { new Guid("c553bf68-357e-49a1-b034-e992a0b3d3b0"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), " Bulevardul Ștefan cel Mare și Sfânt nr. 8, Iași 700063", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Bistro \"La noi\"", "Bistro \"La noi\"" },
                    { new Guid("80284e4c-2b39-462d-8956-0f3cae09a127"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), " Bulevardul Profesor Dimitrie Mangeron nr. 71, Iași 700050", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Kraft Pub & Restaurant", "Kraft Pub & Restaurant" },
                    { new Guid("912dbb82-c469-4d3e-84d0-6845b28b8419"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), "Strada Alexandru Lăpușneanu nr. 16, Iași 700057", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Beer Zone", "Beer Zone" },
                    { new Guid("5bcca602-1dd7-42df-a21e-70472eca13ba"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), "Piața Unirii nr. 5, Iași 700056", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Panoramic", "Panoramic" },
                    { new Guid("d0df2ade-a013-4318-9229-993b14c483e6"), new Guid("feba6c01-179d-4772-99b3-8987e84448f3"), "Bulevardul Carol I nr. 4, Iași 700505", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", " Student Travel" },
                    { new Guid("3ac40d31-e89f-4e99-bfff-6cc32fc346f6"), new Guid("feba6c01-179d-4772-99b3-8987e84448f3"), @"Copou
                Aleea Veronica Micle 8
                langa FEAA, dupa Teo's Cafe", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "American Experience" },
                    { new Guid("e95ef40f-d5dc-43df-b3fb-7f2d207904a8"), new Guid("189e7b41-2da9-44f8-83ff-b7eb2f9eddbb"), "Strada Cloşca 9, Iași 700259", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Scopul organizatiei este promovarea credinţei şi a spiritualităţii ortodoxe în rândul tinerilor, cu prioritate în mediul univASCOR:  https://ascoriasi.ro/", "ASCOR" },
                    { new Guid("ee47f693-5813-4041-ae2d-92251700f688"), new Guid("189e7b41-2da9-44f8-83ff-b7eb2f9eddbb"), "Cămin T11, Aleea Profesor Gheorghe Alexa, Iași 700259", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "BEST încearcă să ajute studenţii europeni să devină mai deschiși spre colaborarea internaţională, oferindu-le șansa de a se familiariza cu diversitatea culturală europeană, dezvoltându-le, în același timp, capacitatea de a lucra în medii internaționale.BEST:  https://bestis.ro/", "BEST" },
                    { new Guid("cb2bb64c-6a8d-4321-a904-fc10c59f2464"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Bulevardul Ștefan cel Mare și Sfânt nr. 10, Iași 700063", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Biblioteca Gheorghe Asachi- Biblioteca Gheorghe Asachi din Iași a fost desemnată ca fiind cea mai frumoasă din lume, în cadrul unei competiții desfășurate online la care au participat nume celebre din întreaga lume, precum Biblioteca Colegiului Trinity din Dublin, Biblioteca Regală Portugheză din Buenos Aires și Biblioteca Națională din Praga.", "Biblioteca Gheorghe Asachi" },
                    { new Guid("7ff93ce3-accc-4390-9fff-42f4908f5561"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), " Piața Muzeului, Cluj-Napoca 400000", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Sax", "Sax" },
                    { new Guid("c4181a47-c387-4d6f-9549-b16d9db13e0e"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Str. Râpa Galbenă,Iași 700259", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Esplanada Elisabeta (Râpa Galbenă)- Râpa Galbenă din Iași, așa cum este cunoscută printre localnici, este o zonă importantă, localizată la baza Dealului Copou. Esplanada Elisabeta din Iași a fost construită la sfârșitul secolului al XIX-lea, scopul acesteia fiind acela de facilitare a circulației pietonilor către zona centrală a orașului.", "Esplanada Elisabeta " },
                    { new Guid("ffa64efe-664d-40c9-b394-9f4ec1f2adcd"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Strada Dumbrava Roșie nr. 7-9, Iași 700487", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Grădina Botanică din Copou- Înființată în anul 1856, Grădina Botanică Anastasie Fătu poartă numele fondatorului său, un celebru medic și susținător al remediilor naturiste din acea perioadă. Aceasta este prima grădină universitară deschisă în țara noastră și cea mai mare din România în acest moment.", "Grădina Botanică din Copou" },
                    { new Guid("cd19ca8d-3397-4096-9721-5c60ff99d8cc"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), "Strada Universității 6, Cluj-Napoca 400091", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Casa TIFF", "Casa TIFF" },
                    { new Guid("f5b22cac-0a84-4d25-bb29-38b5d1a437c7"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), "Strada Matei Corvin Nr 2, Cluj-Napoca 400000", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Old Shepherd", "Old Shepherd" },
                    { new Guid("ddfdbff3-cc2e-48cb-80ee-4f61c668cb1d"), new Guid("c475dd7f-6bc1-48df-afa2-1cf40279553f"), "Strada Vasile Goldiș 4, Cluj-Napoca 400112", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "O'Peter's Irish Pub &Grill", "O'Peter's Irish Pub &Grill" },
                    { new Guid("076a6257-44e7-4bd1-8ea0-76c90ff039db"), new Guid("feba6c01-179d-4772-99b3-8987e84448f3"), "Strada Moldovei 1, Cluj-Napoca 400380", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", "Adira Work & Travel" },
                    { new Guid("f07e3fc4-f78c-44bd-9fb9-51ab37006c13"), new Guid("feba6c01-179d-4772-99b3-8987e84448f3"), "Strada Piezisa Nr 19", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "American Experience" },
                    { new Guid("351cb20f-1a70-4bb3-9885-296fb1175d5d"), new Guid("189e7b41-2da9-44f8-83ff-b7eb2f9eddbb"), "Strada Frumoasă, Nr. 31, Cluj", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Și-au propus să aibă impact asupra mediului economic românesc, oferind acces la resurse de învățare care te vor ajuta să-ți dezvolți competențele profesionale, dar și sociale. Proiectele lor sunt practice, interactive și te aduc cu un pas mai aproape de cariera pe care ți-o dorești. ", "ASER" },
                    { new Guid("f5de4d66-1ae7-41de-8df5-faf51b3e43bb"), new Guid("189e7b41-2da9-44f8-83ff-b7eb2f9eddbb"), "Strada Păstorului 11, Cluj-Napoca 400338", new Guid("11d93701-373e-46b5-87f7-ac6e2e22d548"), "Organizația Studenților de la Universitatea Tehnică oferă un cadru informal în care viitorii ingineri pot construi fundația carierei lor.", "OSUBB" },
                    { new Guid("175a401b-5465-47b7-9a1c-e5b5ee4962b1"), new Guid("5d175560-d13a-41ae-aead-05f3eec15db4"), "Smida, 18, Smida 407082, Cluj", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Smida Jazz, festival dedicat jazz-ului de avangardă ce se desfășoară an de an în pitorescul sat Smida (comuna Beliș, județul Cluj - în mijlocul Parcului Natural Apuseni). Pe parcursul a 3 zile, vom petrece o vacanță în Apuseni, cu tot felul de activități în aer liber și concerte ale grupurilor internaționale și din România. ", "Smida Jazz" },
                    { new Guid("096f6bd4-a63e-45a5-ba9a-44ba61dcd8a7"), new Guid("5d175560-d13a-41ae-aead-05f3eec15db4"), " Iași, str. V. Pogor, nr. 4, 700110.", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Festivalul Internațional de Literatură și Traducere Iași (FILIT) este un festival internațional care are loc anual în octombrie, în Iași. Festivalul reunește la Iași profesioniști din domeniul cărții, atât din țară, cât și din străinătate. Scriitori, traducători, editori, organizatori de festival, critici literari, librari, distribuitori de carte, manageri și jurnaliști culturali – cu toții se află, de-a lungul celor cinci zile de festival, în centrul unor evenimente destinate, pe de o parte, publicului larg, pe de altă parte, specialiștilor din domeniu.", "FILIT" },
                    { new Guid("bf8e7021-7ba3-4153-8d5a-218f997af8d5"), new Guid("5d175560-d13a-41ae-aead-05f3eec15db4"), "Strada Vasile Lupu 78A, Iași 700350", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Afterhills este cel mai tânăr festival de muzică de anvergură din România, desfășurat în județul Iași, fiind cel mai mare și important festival din regiunea Moldova.", "Afterhills " },
                    { new Guid("5f9287d1-f37c-4541-9435-960bb343d34a"), new Guid("5d175560-d13a-41ae-aead-05f3eec15db4"), @"Piața Unirii 5
                Iași", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Se organizeaza seri de film in diferite locatii, unde sunt invitati oameni importanti ai filmului romanesc.", "Serile de Film Romanesc" },
                    { new Guid("e0b90db8-34ad-459b-ae5b-2c51431ee81c"), new Guid("89ecab70-8733-4f16-8577-a21c6486263a"), "Start/Stop: Cluj Arena, Cluj", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Maratonul de Ciclism International din nou la Cluj(Perioada Mai-Iunie)- evenimentul sportiv  aduce la Cluj cel mai mare număr de cicliști din România, într-un context nou și plin de surprize. Vor exista competiții de ciclism și alergare pentru adulți, competiții pentru copii, competiție de spinning, o zonă culinară și una de camping cu foc de tabără precum și alte activități de petrecere a timpului liber.", "Maratonul de Ciclism International din nou la Cluj" },
                    { new Guid("238fec93-f336-490b-baa3-a5d9e0e544d4"), new Guid("89ecab70-8733-4f16-8577-a21c6486263a"), "Strat/Stop: Palatul Culturii, Iasi", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Maratonul International Iasi- Maratonul International Iasi isi propune sa fie un eveniment sportiv de referinta pentru Municipiul Iasi, dar si la nivel regional, national si international. Obiectivul principal este unul social, fondurile rezultate in urma organizarii evenimentului fiind destinate finantarii proiectului de Infiintare si functionare a punctelor de prim ajutor si interventie in caz de dezastre in principalele cartiere ale Iasului", "Maratonul International Iasi" },
                    { new Guid("e834e417-3050-4806-a77d-36d56c5217b0"), new Guid("89ecab70-8733-4f16-8577-a21c6486263a"), "Strada Pantelimon Halipa 6B, Iași", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Întreținere corporală- săli de sport cu prețuri speciale pentru student: Oxygen, Let’ s move", "Întreținere corporală" },
                    { new Guid("9296ef40-1cdc-4ffd-bf00-5a6aece0d082"), new Guid("89ecab70-8733-4f16-8577-a21c6486263a"), "Strada Stihii 2, Iași 700083", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Pilates- Pilates este o metodă de întărire a mușchilor profunzi, care sunt responsabili cu menținerea posturii. (Tonus Plus- sală )", "Pilates" },
                    { new Guid("3e0f17e3-85a9-4c59-ace0-658cfeed115a"), new Guid("92519d61-c291-4a7a-801a-96a1fb27ee66"), "Corp AUniversitATEA Alexandru Ioan Cuza , Bulevardul Carol I 11, Iași 700506", new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"), "Sala Pașilor Pierduți- Dacă în cadrul periplului tău turistic te abați și pe la celebra Universitate “Alexandru Ioan Cuza” din Iași, trebuie să vizitezi și Sala Pașilor Pierduți. Picturile murale unice ale celebrului artist Sabin Bălașa te vor impresiona, acesta reușind să introducă acest spațiu pe harta locurilor de referință ale artei universale, prin măiestria sa artistică.", "Sala Pașilor Pierduți" },
                    { new Guid("7ad9db36-ab49-4e67-a44e-a000b38fbe24"), new Guid("5d175560-d13a-41ae-aead-05f3eec15db4"), "Piata Victoriei, Timisoara", new Guid("e2f2c7fa-c583-4014-a336-1988c772fb58"), "Festivalul Jazz TM este un festival de jazz care se desfășoară în aer liber, în Piața Victoriei, în luna iulie și aduce pe scenă artiști din scena internațională a muzicii Jazz.", "Festivalul Jazz TM" }
                });

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
