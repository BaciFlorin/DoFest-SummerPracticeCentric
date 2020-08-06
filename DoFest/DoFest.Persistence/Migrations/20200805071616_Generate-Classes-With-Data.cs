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
                    { new Guid("ed3d227a-d359-4a55-987b-43bdbddd219f"), "Voluntariat" },
                    { new Guid("8a04435f-240d-4e48-bd77-a371af266275"), "Work&Travel" },
                    { new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), "Pub&Restaurants" },
                    { new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Turism" },
                    { new Guid("2a5b112b-aad2-462e-9759-a8db16d8fcde"), "Sporturi" },
                    { new Guid("18d0a9ff-89aa-4528-a536-8ffa82c198ac"), "Sport" },
                    { new Guid("0b73e5ba-7290-45e8-b97b-0d6cebda7a38"), "Festivaluri" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Iași" },
                    { new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Cluj" },
                    { new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Timișoara" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("62840b02-d31e-4e91-968b-f26f75e91ac3"), "Full access", "Admin" },
                    { new Guid("85fde161-0a1b-4bb7-9945-d3987e8a508c"), "Normal access", "Normal user" }
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "Id", "ActivityTypeId", "Address", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("dcae28a4-4789-4830-b908-ddd7d0dc088a"), new Guid("ed3d227a-d359-4a55-987b-43bdbddd219f"), "Universitatea Alexandru Ioan Cuza, Corp B, Bulevardul Carol I 22, Iași 700505", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "AIESEC este o platformă internațională de dezvoltare pentru tineri, care are ca scop descoperirea şi dezvoltarea potențialului acestora, pentru a avea un impact pozitiv în societate. Înființată în 1948 ca organizație non-politică și non-profit, AIESEC permite indivizilor să-şi modeleze şi să-şi îmbogățească propria experiență printr-un sistem complex de oportunități.AIESEC:  shorturl.at/qyDIZ", "AIESEC" },
                    { new Guid("03b71b9b-2f36-4138-84c0-bb818d885d9d"), new Guid("ed3d227a-d359-4a55-987b-43bdbddd219f"), " Biblioteca Judeteana “Octavian Goga”, Calea Dorobanților 104, Cluj-Napoca, Sala de lectura de la etajul 2", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Ajungem MARI este singurul program demarat de Asociația Lindenfeld și susține educația copiilor din centre de plasament și medii defavorizate.", "Ajungem Mari" },
                    { new Guid("f4feab4d-9c52-49b8-88ab-60a75a210508"), new Guid("ed3d227a-d359-4a55-987b-43bdbddd219f"), "Aleea Crivaia, Timișoara", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Proiecte create cu scopul de a contribui la o tara in care oamenii se implica si sunt parte din schimbarea pe care si-o doresc, devenind la randul lor inspiratie pentru ceilalt.Actiuni de educare a tinerilor, aplicatia LDIR,reamenajari de spatii destinate diverselor categorii sociale si alte proiecte create pentru a proteja mediul si a contribui la rezolvarea problemei deseurilor", "Let’s Do It, Romania!" },
                    { new Guid("f79499bf-870d-4e97-b4a6-f54cd5aa2dd3"), new Guid("0b73e5ba-7290-45e8-b97b-0d6cebda7a38"), "Parcul Botanic, Timisoara", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Festivalul Acces Art – Festival organizat în aer liber, centrat pe ateliere de arte creative.", "Festivalul Acces Art" },
                    { new Guid("4f095745-b528-4984-b201-82b3be48da24"), new Guid("0b73e5ba-7290-45e8-b97b-0d6cebda7a38"), "Piata Unirii, Cluj", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Este primul festival internațional de film de lungmetraj din România, se bazează pe lungmetraje sau scurtmetraje necomerciale produse în special în țările europene. Marele premiu al festivalului, Trofeul Transilvania, opera artistului Teo Mureșan, este o statuetă ce reprezintă un turn tăiat.", "TIFF" },
                    { new Guid("dafe81df-7051-4f48-a4d9-7e535837ef9c"), new Guid("0b73e5ba-7290-45e8-b97b-0d6cebda7a38"), " Bánffy Castle, Cluj-Napoca", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Festivalul îmbină în lineup zone muzicale variate cum ar fi rock, reggae, hip hop, trap, muzică electronică sau indie cu tehnologia, cu arta alternativă, arta stradală și cultura.", "Electric Castle" },
                    { new Guid("6ad7e125-ae62-4720-800e-73bce5429a5b"), new Guid("0b73e5ba-7290-45e8-b97b-0d6cebda7a38"), "Untold Festival Arena, Cluj-Napoc", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Untold Festival este cel mai mare festival de muzică din România.[1][2] Acesta se desfășoară în fiecare an pe Cluj Arena", "UNTOLD" },
                    { new Guid("1adbe8cc-c8cd-467a-825e-18409889c5b4"), new Guid("18d0a9ff-89aa-4528-a536-8ffa82c198ac"), @" 
                Dinias
                ,Timisoara", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Primul targa rally organizat in Romania. Toti banii adunati vor fi donati Spitalului de Copii ”Louis Turcanu”. ", "Memorialul Daniela Zaharie" },
                    { new Guid("de95b100-87a1-405b-a6e7-01770c59dff2"), new Guid("2a5b112b-aad2-462e-9759-a8db16d8fcde"), "trada Băii nr 17, Cluj-Napoca 400389", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Rafting, Parapanta, Tir cu arcul, Caiac, Paintball, Motoparapanta- organizate de Transilvania eXtreme Adventures  care o multime de activitati outdoor care te fac sa uiti de stresul zilnic si sa te reincarci cu energie. O modalitate frumoasa de a adauga in viata ta un plus de miscare si sanatate.", "Transilvania eXtreme Adventures" },
                    { new Guid("32efee1d-c466-42aa-94cd-0d73ff829900"), new Guid("2a5b112b-aad2-462e-9759-a8db16d8fcde"), "In curtea interioara, Strada Berăriei nr. 6, Cluj-Napoca 400380", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Free Wall (Rock Climbing Gym).Sali  de escaladă&bouldering", "Free Wall Climbing" },
                    { new Guid("1853c1f3-82ea-4dca-b177-ffb4f72c1cc5"), new Guid("2a5b112b-aad2-462e-9759-a8db16d8fcde"), "Bride's Veil Waterfall", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Runsilvania Wild Race. Runsilvania WILD RACE este o cursă de trail running, Traseul de alergare trece pe lângă Cascada Vălul Miresei, Peşterile Vârfuraşul şi Lespezi, ajunge la Pietrele Albe şi urcă pe Vf. Vlădeasa (la proba de Maraton), trece prin grote şi segmente tehnice asigurate cu lanţuri şi corzi, podeţe şi scări din lemn.", "Runsilvania Wild Race" },
                    { new Guid("8412569f-47f1-464b-b650-68f990e8835c"), new Guid("2a5b112b-aad2-462e-9759-a8db16d8fcde"), " Baza Sportivă Unirea, Cluj-Napoca ", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Făget Winter Race- Făget Winter Race este un primul concurs de alergare din an. Se desfaşoară în pădurea Făget din Cluj-Napoca, iarna, in al doilea week-end al lunii ianuarie.", "Făget Winter Race" },
                    { new Guid("589e83f6-a1fe-4442-9ec6-0fd269da5fc0"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Centrul Trimisoarei", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Centrul Timișoarei-Centrul este primul dintre locurile cu care vei dori să faci cunoștiință imediat ce ai ajuns și ți-ai lăsat bagajele în cameră. Începând cu Palatul Culturii și până la Catedrala Mitropolitană, centrul orașului cunoscut și sub numele de Piața Victoriei sau Piața Operei concentrează un număr impresionant de palate și clădiri care încă păstrează gloria și arhitectura spectaculoasă de pe vremuri.", "Centrul Timișoarei" },
                    { new Guid("d8a3727b-81f9-4018-8e6f-183b332df995"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Aleea Durgăului 7, Turda 401106", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Salina Turda-A devenit celebră în ultimii ani în România, așa că ne este greu să credem că mai e cineva care să nu fi auzit de ea. Ca să nu mai vorbim că are și o poveste interesantă, trecând de la statutul de salină de renume a Transilvaniei, la începuturi, la o decădere neașteptată datorată concurenței, salina de la Ocna Mureș. Paradoxal, abia cel de-Al Doilea Război Mondial a readus-o în memoria colectivă, fiind folosită ca adăpost antiaerian.", "Salina Turda" },
                    { new Guid("2f148a5a-a70f-41d4-a1ec-ef25bf298cff"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Bd. 21 decembrie 1989 nr. 41, Cluj", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), " Biserica Reformată - Este una dintre cele mai masive construcții gotice din întreaga Transilvanie, având mai degrabă aspectul unei cetăți. Aici se organizează periodic tot felul de concerte și evenimente", " Biserica Reformată " },
                    { new Guid("80a00b41-c8b5-485f-9082-f55a21240893"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), " Strada Baba Novac 2, Cluj-Napoca 400097", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Turnul Croitorilor - Turnul face parte din vechiul zid de apărare al orașului, care înconjura în vremuri de demult o suprafață de 45 hectare, cât măsura cetatea, și este unul dintre puținele care s-au păstrat într-o stare foarte bună până în zilele noastre (practic, turnul este astăzi intact", "Turnul Croitorilor " },
                    { new Guid("f2c7217a-1a78-491b-bf4f-533f6e284392"), new Guid("8a04435f-240d-4e48-bd77-a371af266275"), "Strada Francesco Griselini 2, Timișoara 300054", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "GTS * GOTOSUA Work & Travel" },
                    { new Guid("c5d44707-53e6-429d-a647-c586eda7d589"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Strada Emil Racoviță 60a, Cluj-Napoca 400124", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), " Cetățuia - De fapt, Cetățuia este un parc situat la o altitudine de 405 metri, de mici dimensiuni, ce-i drept, cu vedere asupra orașului, deci nu este deloc de ocolit.", " Cetățuia " },
                    { new Guid("c5bcb261-22b8-4754-8284-dfeb57e96d1b"), new Guid("8a04435f-240d-4e48-bd77-a371af266275"), @"Parcare Caminele 12-17
                Complex Studentesc, Timisoara", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", "American Experience" },
                    { new Guid("737f6a28-55c7-4254-889a-ded13bbf09f9"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), "Strada George Coșbuc 1, Timișoara 300048", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "The Drunken Rat Pub", "The Drunken Rat Pub" },
                    { new Guid("248bdaee-1a03-4609-9708-073623dc83fd"), new Guid("0b73e5ba-7290-45e8-b97b-0d6cebda7a38"), "Sala Barocă a Muzeului de Artă din Timișoara ", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Festivalul Internațional de Literatură de la Timișoara – Festivalul reunește autori români și străini, pentru două zile de lecturi și dialoguri deschise cu publicul.", "Festivalul Internațional de Literatură de la Timișoara " },
                    { new Guid("78421889-180a-4c5b-b214-7e49b3c13a7c"), new Guid("0b73e5ba-7290-45e8-b97b-0d6cebda7a38"), "Ambasada/Timisoara", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Festivalul Internațional de Tango Argentinian - Festivalul are loc anual, începând cu 2013, în ultima săptămână a lunii mai. Acest unic eveniment din vestul țării este organizat de Școala de Tango Argentinian „Tango Embrace”, din cadrul Asociației \"Art Embrace\".", "Festivalul Internațional de Tango Argentinian" },
                    { new Guid("ae9fc220-2855-48fc-aafa-33f35a1603f7"), new Guid("0b73e5ba-7290-45e8-b97b-0d6cebda7a38"), "Aeroclubul „Alexandru Matei” ,Iași", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Hangariada înseamnă 3 zile de fericire cu ½ muzică și ½ zbor. Privești cerul, saltă inima, îți strângi prietenii de mână, lași gândul să-ți zboare prin iarba cosită. Te întinzi pe spate, îți pui ochelarii de soare, „oare de ce nu m-am făcut pilot/cântăreț ca-n compunerea dintr-a patra?” Aplauze! Ridică-te, înverzește-ți tălpile pantofilor, cântă și dansează odată cu cei de pe scenă. Și-apoi, a doua zi, de la capăt.", "Hangariada" },
                    { new Guid("2d56a52e-2c43-4891-b2af-ecc6779513b9"), new Guid("18d0a9ff-89aa-4528-a536-8ffa82c198ac"), " B-dul.Eroilor de la Tisa, Timisoara", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Vor participa dansatori din: Rusia, Bulgaria, Hungaria , France , Montenegro , Serbia , Moldova , Czech Republic si Romania ", "International Dance Open" },
                    { new Guid("7243db67-7a71-49a4-85f8-3b4a5a8ef8a7"), new Guid("18d0a9ff-89aa-4528-a536-8ffa82c198ac"), "Universitatea Politehnica Timişoara", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Chess Contest este un concurs de șah dedicat tuturor elevilor și studenților din toată țara, organizat de Liga AC (Liga Studenților din Facultatea de Automatică și Calculatoare) în colaborare cu Facultatea de Automatică și Calculatoare și Universitatea Politehnica Timișoara. Concursul se desfăşoară în perioada 17-19 noiembrie şi îşi propune să adune cât mai mulţi tineri în Timişoara pentru a-şi arăta strategia în această confruntare a minţii. ", "Chess Contest" },
                    { new Guid("45c1dac2-3b29-4835-a1ce-25e3c0072280"), new Guid("18d0a9ff-89aa-4528-a536-8ffa82c198ac"), "Sala Constantin Jude (Olimpia), Timisoara", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Ne propunem ca prin evenimentele noastre sa aducem un nou concept dedicat boxului profesionist,sa imbinam sportul cu spectacolul si sa aducem in fata publicului unii dintre cei mai buni sportivi de box si kickboxing din Romania, fiecare dintre acestia confruntandu-se pe reguli de box cu adversari de valoare din Europa, Africa si America Latina intr-o serie de 3 evenimente pe an ", "Noaptea Spartanilor" },
                    { new Guid("216e7205-ef38-474c-91e9-c33ade87a1ce"), new Guid("2a5b112b-aad2-462e-9759-a8db16d8fcde"), @"Enduro Ranch (Bârnova, Județul Iași)
                ", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Asaltul Lupilor- evenimentului te aşteaptă pe un teren accidentat de 6 Km, perfect ca să-ţi testeze limitele. Vei alerga prin pădure, te vei târî prin şanţuri, te vei căţăra pe funii, vei traversa râpe, vei sări peste garduri, te vei împiedica sau nu de rădacinile copacilor şi nu în ultimul rând te vei murdări de noroi … dar te vei distra ! ", "Asaltul Lupilor" },
                    { new Guid("1db71d00-5428-4f64-b736-5bac3cbc6f1f"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), " Strada Michelangelo - Strada 20 Decembrie 1989,Timisoara", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Parcul Rozelor. Situat în centrul oraşului, la doar câțiva pași de malul râului Bega, Parcul Rozelor reprezintă o altă atracție de renume a Timişoarei. De fapt, s-ar putea spune că faima Timişoarei de oraş al parcurilor sau oraş al trandafirilor este în mare măsură datorată acestui parc.", "Parcul Rozelor" },
                    { new Guid("1a327f10-7525-4738-847e-a6f6e90b6d19"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), " Strada Hector, Timișoara", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Bastionul Maria Theresia-Aflat în zona centrală, între Hotel Continental și Fântâna Punctelor Cardinale (pe strada Hector), Bastionul Maria Theresia este un monument în stil baroc de o mare însemnătate istorică, fiind cea mai mare bucată de zid păstrată din vechea cetate a Timișoarei.", "Bastionul Maria Theresia" },
                    { new Guid("11d6fd7a-f3f0-449d-9d12-dc15ca7b5d70"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Bulevardul Regele Ferdinand I, Timișoara", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Catedrala Mitropolitană din Timișoara marchează cealaltă intrare principală în centrul orașului, fiind dispusă în partea de sud a pieței. Catedrala este fără îndoială una dintre clădirile care îți va atrage privirea indiferent în ce parte a centrului te vei afla, doar este cel mai mare edificiu religios din oraș. Impresionează atât prin arhitectura somptuoasă care îmbină stilul bizantin cu cel moldovenesc cât și prin dimensiunile sale vaste", "Catedrala Mitropolitană din Timișoara" },
                    { new Guid("bf683c8a-85fb-4665-b4ba-ad0e062e6ff6"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Strada Mărășești 2, Timișoara 300086", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Clădirea Palatului Culturii (cea care mărginește centrul în parte de nord) adăpostește astăzi Opera Națională Română și cele trei teatre de stat Teatrul National Mihai Eminescu, Teatrul Maghiar de Stat Csiky Gergely și Teatrul German de Stat (o situație unică și totodată o premieră în Europa). Dacă inițial clădirea avea exteriorul în stil Renaissance, în urma celor două mari incendii din 1880 și 1920, au mai rămas intacte doar aripile", "Palatului Culturii " },
                    { new Guid("84e8ec2f-1ba4-4e9d-a04a-67992e5dc843"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), " Strada Vasile Alecsandri 3, Timișoara 300078", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Jack's Bistro", "Jack's Bistro" },
                    { new Guid("b16dc2f6-2807-4d11-86ff-e0a70cc02de9"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), "Joy Pub", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Joy Pub", "Joy Pub" },
                    { new Guid("0b9bce32-f40c-48af-a681-348c7589fcc5"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), " Strada Eugeniu de Savoya 11, Timișoara 300085", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Enoteca de Savoya", "Enoteca de Savoya" },
                    { new Guid("8a0f4f85-294a-4c3c-b6ad-8f08011b86ef"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), "Strada Eugeniu de Savoya 9, Timișoara", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "The Scotland Yard", "The Scotland Yard" },
                    { new Guid("4c621b05-2fa7-4506-98d2-536f38820fd7"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), " str.Aries, Nr.19(Casa Tineretului), 300736 Timisoara", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "The 80's Pub", "The 80's Pub" },
                    { new Guid("c7a98d8d-5cf3-42fe-86f0-32f99892abb8"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Strada Republicii 42, Cluj-Napoca 400015", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Grădina Botanică - Fondată în anul 1872 și considerată astăzi muzeul național, Grădina Botanică este una dintre primele, cele mai mari și cele mai complexe astfel de grădini din sud-estul Europei. Întinzându-se pe o suprafață de 14 hectare, are ca principale atracții grădina japoneză, grădina romană, serele cu plante tropicale și ecuatoriale.", "Grădina Botanică " },
                    { new Guid("ee4b8a93-87c2-4454-88d7-1716be51aa42"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Piața Unirii ", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Piața Unirii - Asemenea Pieței Muzeului, Piața Unirii se mândrește cu unele dintre cele mai importante ansambluri arhitectonice gotice, baroce și neo-baroce din Transilvania: Biserica Romano-Catolică Sf. Mihail, Muzeul de Artă, Muzeul Farmaciei, pe care nu am mai apucat să-l vizităm, statuia lui Matia Corvin, Strada în oglindă și vechile palate nobiliare.", "Piața Unirii " },
                    { new Guid("155b448a-fd2e-4933-aa22-84ac4ed08c68"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), " Piața Muzeului, Cluj-Napoca 400000", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Sax", "Sax" },
                    { new Guid("81e6f805-0698-45d7-b41f-1bcd290c8013"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), " Bulevardul Ștefan cel Mare și Sfânt nr. 28, Iași 700259", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Mănăstirea Sfinții Trei Ierarhi din Iași- Considerat un monument arhitectural de mare valoare în Iași și în întreaga țară, Mănăstirea Sfinții Trei Ierarhi atrage atenția prin arhitectura sa impresionantă și datorită decorațiunilor sale unice din piatră, care împodobesc fațadele superioare. Aceasta a fost zidită inițial pentru a inaugura domnia marelui voievod de odinioară, Vasile Lupu. Aceasta a fost restaurată din punct de vedere arhitectural în perioada 1882 – 1887, amenajarea interiorului său și realizarea picturilor continuând până în anul 1898.", "Mănăstirea Sfinții Trei Ierarhi din Iași" },
                    { new Guid("4ad62c6f-3c63-40dc-b5b0-4cc59d572465"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Strada Agatha Bârsescu nr. 18, Iași 700074", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Teatrul Național Vasile Alecsandri- Datând din anul 1896, Teatrul Național Vasile Alecsandri este cel mai vechi din țară și unul dintre cele mai frumoase din Europa. Interiorul său elegant și bogat decorat a fost inspirat din stilurile arhitecturale baroce și rococo, unul dintre plafoanele sale fiind pictate de celebrul pictor vienez Alexander Goltz. Cortina sa a fost, de asemenea, pictată manual, simbolizând cele trei etape ale vieții și fiind considerată o alegorie a Unificării României.", "Teatrul Național Vasile Alecsandri" },
                    { new Guid("5048e743-18fc-47ca-8e09-c0c739999b59"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Bulevardul Ștefan cel Mare și Sfânt 16, Iași 700064", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Mitropolia Moldovei și a Bucovinei- Aceasta este renumită pentru că adăpostește Moaștele Sfintei Cuvioase Parascheva, ocrotitoarea Moldovei. Monumentala catedrală ieșeană este marcată de patru turle masive, iar arhitectura sa este inspirată de stilul baroc, care marchează atât elementele decorative din exterior cât și cele din interiorul său.", "Mitropolia Moldovei și a Bucovinei" },
                    { new Guid("556f9f36-3ec8-4782-996d-d15962635fd4"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Bulevardul Carol I nr. 31, Iași 700462", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Parcul Copou- Amenajarea celebrului Parc Copou din Iași a început în perioada 1833-1834. Acesta adăpostește Monumentul Legilor Constituționale, cel mai vechi monument din țara noastră. Cunoscut și ca Obeliscul cu lei, acesta a fost creat de Mihail Singurov în anul 1834. Reprezentat de o coloană din piatră de 15 m înălțime și cu o greutate ce depășește 10 tone, celebrul monument reprezintă un simbol al celor patru puteri europene care au recunoscut independența Țărilor Române.", "Parcul Copou" },
                    { new Guid("ce4426e2-a79f-40a5-b5a5-3f51adf05c0d"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Bulevardul Ștefan cel Mare și Sfânt 1, Iași 700028", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Palatul Culturii- Această clădire impresionantă este sediul a numeroase instituții culturale de prestigiu din acest oraș și a fost pusă în valoare prin recenta sa reabilitare. În cadrul Palatului Culturii din Iași vei descoperi patru muzee, care te vor ajuta să înțelegi mai bine istoria și cultura acestor meleaguri: Muzeul de Istorie al Moldovei, Muzeul Etnografic, Muzeul de Artă și Muzeul Științei și Tehnologiei Ștefan Procopiu.", "Palatul Culturii" },
                    { new Guid("a026432d-87b7-46be-9eb2-1fa2d61c4a66"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), "Piața Unirii nr. 6, Iași 700055", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Cafeneaua Piața Unirii", "Cafeneaua Piața Unirii" },
                    { new Guid("9fbc6e81-7221-4e25-ae78-d7c97086212a"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), "Strada Moldovei 20, Iași 700046", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Vivo", "Vivo" },
                    { new Guid("465d5149-1e40-41c5-8cea-84a80ab5db64"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), " Bulevardul Ștefan cel Mare și Sfânt nr. 8, Iași 700063", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Bistro \"La noi\"", "Bistro \"La noi\"" },
                    { new Guid("3c53c7a8-b8ce-4503-914d-e21ed478ca16"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), " Bulevardul Profesor Dimitrie Mangeron nr. 71, Iași 700050", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Kraft Pub & Restaurant", "Kraft Pub & Restaurant" },
                    { new Guid("293d1f52-9a3f-4204-8b4d-9c302f1cc151"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), "Strada Alexandru Lăpușneanu nr. 16, Iași 700057", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Beer Zone", "Beer Zone" },
                    { new Guid("204d0932-3517-45a7-b3c4-5e785150e541"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), "Piața Unirii nr. 5, Iași 700056", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Panoramic", "Panoramic" },
                    { new Guid("5339ce4b-2430-4124-ac7f-139ab9921396"), new Guid("8a04435f-240d-4e48-bd77-a371af266275"), "Bulevardul Carol I nr. 4, Iași 700505", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", " Student Travel" },
                    { new Guid("2c981e89-f4a6-439b-930c-3081ffbd6840"), new Guid("8a04435f-240d-4e48-bd77-a371af266275"), @"Copou
                Aleea Veronica Micle 8
                langa FEAA, dupa Teo's Cafe", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "American Experience" },
                    { new Guid("e65056a9-280c-4138-8f78-26ace3cd5f84"), new Guid("ed3d227a-d359-4a55-987b-43bdbddd219f"), "Strada Cloşca 9, Iași 700259", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Scopul organizatiei este promovarea credinţei şi a spiritualităţii ortodoxe în rândul tinerilor, cu prioritate în mediul univASCOR:  https://ascoriasi.ro/", "ASCOR" },
                    { new Guid("252fa196-d41b-4846-9ceb-dd8b06057946"), new Guid("ed3d227a-d359-4a55-987b-43bdbddd219f"), "Cămin T11, Aleea Profesor Gheorghe Alexa, Iași 700259", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "BEST încearcă să ajute studenţii europeni să devină mai deschiși spre colaborarea internaţională, oferindu-le șansa de a se familiariza cu diversitatea culturală europeană, dezvoltându-le, în același timp, capacitatea de a lucra în medii internaționale.BEST:  https://bestis.ro/", "BEST" },
                    { new Guid("095bbf71-79cc-4686-a1c7-ea79226419dd"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Bulevardul Ștefan cel Mare și Sfânt nr. 10, Iași 700063", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Biblioteca Gheorghe Asachi- Biblioteca Gheorghe Asachi din Iași a fost desemnată ca fiind cea mai frumoasă din lume, în cadrul unei competiții desfășurate online la care au participat nume celebre din întreaga lume, precum Biblioteca Colegiului Trinity din Dublin, Biblioteca Regală Portugheză din Buenos Aires și Biblioteca Națională din Praga.", "Biblioteca Gheorghe Asachi" },
                    { new Guid("9370b984-1a40-46d3-b144-9ed1309e595a"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Str. Râpa Galbenă,Iași 700259", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Esplanada Elisabeta (Râpa Galbenă)- Râpa Galbenă din Iași, așa cum este cunoscută printre localnici, este o zonă importantă, localizată la baza Dealului Copou. Esplanada Elisabeta din Iași a fost construită la sfârșitul secolului al XIX-lea, scopul acesteia fiind acela de facilitare a circulației pietonilor către zona centrală a orașului.", "Esplanada Elisabeta " },
                    { new Guid("007fba32-4163-480b-8ab9-83aa933dfca9"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Corp AUniversitATEA Alexandru Ioan Cuza , Bulevardul Carol I 11, Iași 700506", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Sala Pașilor Pierduți- Dacă în cadrul periplului tău turistic te abați și pe la celebra Universitate “Alexandru Ioan Cuza” din Iași, trebuie să vizitezi și Sala Pașilor Pierduți. Picturile murale unice ale celebrului artist Sabin Bălașa te vor impresiona, acesta reușind să introducă acest spațiu pe harta locurilor de referință ale artei universale, prin măiestria sa artistică.", "Sala Pașilor Pierduți" },
                    { new Guid("dcdd77fd-f010-4261-a2dc-f658acf4ce84"), new Guid("bc7a9f79-8b97-4efc-acfc-cd3e96668fa0"), "Strada Dumbrava Roșie nr. 7-9, Iași 700487", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Grădina Botanică din Copou- Înființată în anul 1856, Grădina Botanică Anastasie Fătu poartă numele fondatorului său, un celebru medic și susținător al remediilor naturiste din acea perioadă. Aceasta este prima grădină universitară deschisă în țara noastră și cea mai mare din România în acest moment.", "Grădina Botanică din Copou" },
                    { new Guid("b8bcce50-557c-4f74-b623-163c7bfd6531"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), " Cardinal Iuliu Hossu Street 3, Cluj-Napoca 400029", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Samsara Foodhouse", "Samsara Foodhouse" },
                    { new Guid("87f64301-a85a-4bda-a949-99d03c78c35a"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), "Strada Universității 6, Cluj-Napoca 400091", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Casa TIFF", "Casa TIFF" },
                    { new Guid("cf70e1a8-6cc1-4fea-bd47-fcba888dd143"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), "Strada Matei Corvin Nr 2, Cluj-Napoca 400000", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Old Shepherd", "Old Shepherd" },
                    { new Guid("8cff84aa-2451-4690-8349-e0be447320eb"), new Guid("6c0bcf63-01aa-47f3-af0a-5665352ff3ca"), "Strada Vasile Goldiș 4, Cluj-Napoca 400112", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "O'Peter's Irish Pub &Grill", "O'Peter's Irish Pub &Grill" },
                    { new Guid("147ce209-4e6d-4032-8a0a-4ce27f0e86d3"), new Guid("8a04435f-240d-4e48-bd77-a371af266275"), "Strada Moldovei 1, Cluj-Napoca 400380", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", "Adira Work & Travel" },
                    { new Guid("9a4b6ef8-5298-4978-a6b1-646a053ac958"), new Guid("8a04435f-240d-4e48-bd77-a371af266275"), "Strada Piezisa Nr 19", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "American Experience" },
                    { new Guid("cc3e59c5-86f3-4c02-9e8f-ec6b39cb388b"), new Guid("ed3d227a-d359-4a55-987b-43bdbddd219f"), "Strada Frumoasă, Nr. 31, Cluj", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Și-au propus să aibă impact asupra mediului economic românesc, oferind acces la resurse de învățare care te vor ajuta să-ți dezvolți competențele profesionale, dar și sociale. Proiectele lor sunt practice, interactive și te aduc cu un pas mai aproape de cariera pe care ți-o dorești. ", "ASER" },
                    { new Guid("150df9da-a2f8-4dd3-96d0-e332bcc35bd3"), new Guid("0b73e5ba-7290-45e8-b97b-0d6cebda7a38"), "Piata Victoriei, Timisoara", new Guid("803c27ab-9b34-4b2c-8c9f-cb6759ff3ff0"), "Festivalul Jazz TM este un festival de jazz care se desfășoară în aer liber, în Piața Victoriei, în luna iulie și aduce pe scenă artiști din scena internațională a muzicii Jazz.", "Festivalul Jazz TM" },
                    { new Guid("ffa71fe0-bf7b-4bde-8270-1f4c2747ef20"), new Guid("ed3d227a-d359-4a55-987b-43bdbddd219f"), "Strada Păstorului 11, Cluj-Napoca 400338", new Guid("ad02ed5f-6549-4695-ba64-3fa71778df08"), "Organizația Studenților de la Universitatea Tehnică oferă un cadru informal în care viitorii ingineri pot construi fundația carierei lor.", "OSUBB" },
                    { new Guid("341bfa2f-dffa-4a70-90db-48ac3de3a0b1"), new Guid("0b73e5ba-7290-45e8-b97b-0d6cebda7a38"), " Iași, str. V. Pogor, nr. 4, 700110.", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Festivalul Internațional de Literatură și Traducere Iași (FILIT) este un festival internațional care are loc anual în octombrie, în Iași. Festivalul reunește la Iași profesioniști din domeniul cărții, atât din țară, cât și din străinătate. Scriitori, traducători, editori, organizatori de festival, critici literari, librari, distribuitori de carte, manageri și jurnaliști culturali – cu toții se află, de-a lungul celor cinci zile de festival, în centrul unor evenimente destinate, pe de o parte, publicului larg, pe de altă parte, specialiștilor din domeniu.", "FILIT" },
                    { new Guid("a11c9ea5-9e64-4ae4-ba84-d32996f083e2"), new Guid("0b73e5ba-7290-45e8-b97b-0d6cebda7a38"), "Strada Vasile Lupu 78A, Iași 700350", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Afterhills este cel mai tânăr festival de muzică de anvergură din România, desfășurat în județul Iași, fiind cel mai mare și important festival din regiunea Moldova.", "Afterhills " },
                    { new Guid("ca67d5a3-c7e1-40c8-ba70-2a066790f657"), new Guid("0b73e5ba-7290-45e8-b97b-0d6cebda7a38"), @"Piața Unirii 5
                Iași", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Se organizeaza seri de film in diferite locatii, unde sunt invitati oameni importanti ai filmului romanesc.", "Serile de Film Romanesc" },
                    { new Guid("38050c49-f290-4a7c-8974-0d7a7c216d00"), new Guid("2a5b112b-aad2-462e-9759-a8db16d8fcde"), "Start/Stop: Cluj Arena, Cluj", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Maratonul de Ciclism International din nou la Cluj(Perioada Mai-Iunie)- evenimentul sportiv  aduce la Cluj cel mai mare număr de cicliști din România, într-un context nou și plin de surprize. Vor exista competiții de ciclism și alergare pentru adulți, competiții pentru copii, competiție de spinning, o zonă culinară și una de camping cu foc de tabără precum și alte activități de petrecere a timpului liber.", "Maratonul de Ciclism International din nou la Cluj" },
                    { new Guid("3729c14a-c998-4f22-a97e-f3a5ceb3e957"), new Guid("2a5b112b-aad2-462e-9759-a8db16d8fcde"), "Strat/Stop: Palatul Culturii, Iasi", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Maratonul International Iasi- Maratonul International Iasi isi propune sa fie un eveniment sportiv de referinta pentru Municipiul Iasi, dar si la nivel regional, national si international. Obiectivul principal este unul social, fondurile rezultate in urma organizarii evenimentului fiind destinate finantarii proiectului de Infiintare si functionare a punctelor de prim ajutor si interventie in caz de dezastre in principalele cartiere ale Iasului", "Maratonul International Iasi" },
                    { new Guid("2eddb5f7-ac96-4104-81c0-ae3dc53d32f7"), new Guid("2a5b112b-aad2-462e-9759-a8db16d8fcde"), "Strada Pantelimon Halipa 6B, Iași", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Întreținere corporală- săli de sport cu prețuri speciale pentru student: Oxygen, Let’ s move", "Întreținere corporală" },
                    { new Guid("2f4f89a0-db80-49e2-94e4-fab76c013ff8"), new Guid("2a5b112b-aad2-462e-9759-a8db16d8fcde"), "Strada Stihii 2, Iași 700083", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Pilates- Pilates este o metodă de întărire a mușchilor profunzi, care sunt responsabili cu menținerea posturii. (Tonus Plus- sală )", "Pilates" },
                    { new Guid("efe8d802-35da-4b06-9937-c44a733d1082"), new Guid("0b73e5ba-7290-45e8-b97b-0d6cebda7a38"), "Smida, 18, Smida 407082, Cluj", new Guid("ef0af697-604e-4bcb-8eec-a7280db8c3ef"), "Smida Jazz, festival dedicat jazz-ului de avangardă ce se desfășoară an de an în pitorescul sat Smida (comuna Beliș, județul Cluj - în mijlocul Parcului Natural Apuseni). Pe parcursul a 3 zile, vom petrece o vacanță în Apuseni, cu tot felul de activități în aer liber și concerte ale grupurilor internaționale și din România. ", "Smida Jazz" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "PasswordHash", "StudentId", "UserTypeId", "Username" },
                values: new object[] { new Guid("d9b3c616-8022-4605-ba14-8d0ff1dcdb40"), "DoFestAdmin@gmail.com", "XYbN1Iih6zj4OmdDaK65LA==.Pj1aiXHEF1fzFD1S14SMpncKZI7cVuqSjS7ElIgqqOY=", null, new Guid("62840b02-d31e-4e91-968b-f26f75e91ac3"), "DoFestAdmin" });

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
