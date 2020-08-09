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
                    { new Guid("100f776b-9e14-4d5c-8385-4ab73ed4fd11"), "Voluntariat" },
                    { new Guid("aaeb6eed-024f-4cdd-97ea-bb8bd10096e1"), "Work&Travel" },
                    { new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), "Pub&Restaurants" },
                    { new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Turism" },
                    { new Guid("6497078e-f1a0-4142-9d03-b6182f292207"), "Sporturi" },
                    { new Guid("8a4ad907-37b5-4b93-bc29-c896f65585d9"), "Sport" },
                    { new Guid("25742ac9-916a-409b-a234-218801cf11c6"), "Festivaluri" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Iași" },
                    { new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Cluj" },
                    { new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Timișoara" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("52ec3370-b713-4369-8eb1-7eac667ef210"), "Full access", "Admin" },
                    { new Guid("d2362619-d87f-40d6-9825-6cf355576d80"), "Normal access", "Normal user" }
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "Id", "ActivityTypeId", "Address", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0d93d143-27ac-40e5-9603-c3fd92cf5acf"), new Guid("100f776b-9e14-4d5c-8385-4ab73ed4fd11"), "Universitatea Alexandru Ioan Cuza, Corp B, Bulevardul Carol I 22, Iași 700505", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "AIESEC este o platformă internațională de dezvoltare pentru tineri, care are ca scop descoperirea şi dezvoltarea potențialului acestora, pentru a avea un impact pozitiv în societate. Înființată în 1948 ca organizație non-politică și non-profit, AIESEC permite indivizilor să-şi modeleze şi să-şi îmbogățească propria experiență printr-un sistem complex de oportunități.AIESEC:  shorturl.at/qyDIZ", "AIESEC" },
                    { new Guid("30bbe969-e6d9-4d0b-848b-8ceb68014a26"), new Guid("100f776b-9e14-4d5c-8385-4ab73ed4fd11"), " Biblioteca Judeteana “Octavian Goga”, Calea Dorobanților 104, Cluj-Napoca, Sala de lectura de la etajul 2", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Ajungem MARI este singurul program demarat de Asociația Lindenfeld și susține educația copiilor din centre de plasament și medii defavorizate.", "Ajungem Mari" },
                    { new Guid("2d5c132a-3149-477e-addc-f95c9185516c"), new Guid("100f776b-9e14-4d5c-8385-4ab73ed4fd11"), "Aleea Crivaia, Timișoara", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Proiecte create cu scopul de a contribui la o tara in care oamenii se implica si sunt parte din schimbarea pe care si-o doresc, devenind la randul lor inspiratie pentru ceilalt.Actiuni de educare a tinerilor, aplicatia LDIR,reamenajari de spatii destinate diverselor categorii sociale si alte proiecte create pentru a proteja mediul si a contribui la rezolvarea problemei deseurilor", "Let’s Do It, Romania!" },
                    { new Guid("97e2fc9d-cbe0-4d3c-bbad-23f2b39e7e7d"), new Guid("25742ac9-916a-409b-a234-218801cf11c6"), "Parcul Botanic, Timisoara", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Festivalul Acces Art – Festival organizat în aer liber, centrat pe ateliere de arte creative.", "Festivalul Acces Art" },
                    { new Guid("c9477b29-860b-42fd-87bd-225ffd9d989e"), new Guid("25742ac9-916a-409b-a234-218801cf11c6"), "Piata Unirii, Cluj", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Este primul festival internațional de film de lungmetraj din România, se bazează pe lungmetraje sau scurtmetraje necomerciale produse în special în țările europene. Marele premiu al festivalului, Trofeul Transilvania, opera artistului Teo Mureșan, este o statuetă ce reprezintă un turn tăiat.", "TIFF" },
                    { new Guid("c9acfc80-4301-4bc5-82fc-a28b668ef839"), new Guid("25742ac9-916a-409b-a234-218801cf11c6"), " Bánffy Castle, Cluj-Napoca", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Festivalul îmbină în lineup zone muzicale variate cum ar fi rock, reggae, hip hop, trap, muzică electronică sau indie cu tehnologia, cu arta alternativă, arta stradală și cultura.", "Electric Castle" },
                    { new Guid("fda9ba0f-75de-46c9-a619-a23823079bdb"), new Guid("25742ac9-916a-409b-a234-218801cf11c6"), "Untold Festival Arena, Cluj-Napoc", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Untold Festival este cel mai mare festival de muzică din România.[1][2] Acesta se desfășoară în fiecare an pe Cluj Arena", "UNTOLD" },
                    { new Guid("d1a0a8c3-fbad-4c84-bc5e-fa4c137f9552"), new Guid("8a4ad907-37b5-4b93-bc29-c896f65585d9"), @" 
                Dinias
                ,Timisoara", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Primul targa rally organizat in Romania. Toti banii adunati vor fi donati Spitalului de Copii ”Louis Turcanu”. ", "Memorialul Daniela Zaharie" },
                    { new Guid("93ba0a03-d04e-4120-aba3-16a0d4e742df"), new Guid("6497078e-f1a0-4142-9d03-b6182f292207"), "trada Băii nr 17, Cluj-Napoca 400389", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Rafting, Parapanta, Tir cu arcul, Caiac, Paintball, Motoparapanta- organizate de Transilvania eXtreme Adventures  care o multime de activitati outdoor care te fac sa uiti de stresul zilnic si sa te reincarci cu energie. O modalitate frumoasa de a adauga in viata ta un plus de miscare si sanatate.", "Transilvania eXtreme Adventures" },
                    { new Guid("980b96d5-bb12-4fe0-a47b-742c90d3ea7d"), new Guid("6497078e-f1a0-4142-9d03-b6182f292207"), "In curtea interioara, Strada Berăriei nr. 6, Cluj-Napoca 400380", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Free Wall (Rock Climbing Gym).Sali  de escaladă&bouldering", "Free Wall Climbing" },
                    { new Guid("f4df4dc9-8045-4fc3-b1e1-4abc92203ad0"), new Guid("6497078e-f1a0-4142-9d03-b6182f292207"), "Bride's Veil Waterfall", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Runsilvania Wild Race. Runsilvania WILD RACE este o cursă de trail running, Traseul de alergare trece pe lângă Cascada Vălul Miresei, Peşterile Vârfuraşul şi Lespezi, ajunge la Pietrele Albe şi urcă pe Vf. Vlădeasa (la proba de Maraton), trece prin grote şi segmente tehnice asigurate cu lanţuri şi corzi, podeţe şi scări din lemn.", "Runsilvania Wild Race" },
                    { new Guid("cc97114a-1535-40fb-a798-ec4c8846c6a1"), new Guid("6497078e-f1a0-4142-9d03-b6182f292207"), " Baza Sportivă Unirea, Cluj-Napoca ", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Făget Winter Race- Făget Winter Race este un primul concurs de alergare din an. Se desfaşoară în pădurea Făget din Cluj-Napoca, iarna, in al doilea week-end al lunii ianuarie.", "Făget Winter Race" },
                    { new Guid("59ff4cd6-471b-41b3-9201-d202b0f31210"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Centrul Trimisoarei", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Centrul Timișoarei-Centrul este primul dintre locurile cu care vei dori să faci cunoștiință imediat ce ai ajuns și ți-ai lăsat bagajele în cameră. Începând cu Palatul Culturii și până la Catedrala Mitropolitană, centrul orașului cunoscut și sub numele de Piața Victoriei sau Piața Operei concentrează un număr impresionant de palate și clădiri care încă păstrează gloria și arhitectura spectaculoasă de pe vremuri.", "Centrul Timișoarei" },
                    { new Guid("581d1ce8-6313-42e5-b790-f418d2f54ade"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Aleea Durgăului 7, Turda 401106", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Salina Turda-A devenit celebră în ultimii ani în România, așa că ne este greu să credem că mai e cineva care să nu fi auzit de ea. Ca să nu mai vorbim că are și o poveste interesantă, trecând de la statutul de salină de renume a Transilvaniei, la începuturi, la o decădere neașteptată datorată concurenței, salina de la Ocna Mureș. Paradoxal, abia cel de-Al Doilea Război Mondial a readus-o în memoria colectivă, fiind folosită ca adăpost antiaerian.", "Salina Turda" },
                    { new Guid("4c15217c-4dc8-4a1f-bc9d-a6787027a539"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Bd. 21 decembrie 1989 nr. 41, Cluj", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), " Biserica Reformată - Este una dintre cele mai masive construcții gotice din întreaga Transilvanie, având mai degrabă aspectul unei cetăți. Aici se organizează periodic tot felul de concerte și evenimente", " Biserica Reformată " },
                    { new Guid("b7f7d0c3-9c87-4f3a-a465-eb5b20cac482"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), " Strada Baba Novac 2, Cluj-Napoca 400097", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Turnul Croitorilor - Turnul face parte din vechiul zid de apărare al orașului, care înconjura în vremuri de demult o suprafață de 45 hectare, cât măsura cetatea, și este unul dintre puținele care s-au păstrat într-o stare foarte bună până în zilele noastre (practic, turnul este astăzi intact", "Turnul Croitorilor " },
                    { new Guid("d132f8d7-407b-4179-b458-c75030a4a7a7"), new Guid("aaeb6eed-024f-4cdd-97ea-bb8bd10096e1"), "Strada Francesco Griselini 2, Timișoara 300054", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "GTS * GOTOSUA Work & Travel" },
                    { new Guid("409bc472-d9d4-4c8f-8371-485d570c26b4"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Strada Emil Racoviță 60a, Cluj-Napoca 400124", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), " Cetățuia - De fapt, Cetățuia este un parc situat la o altitudine de 405 metri, de mici dimensiuni, ce-i drept, cu vedere asupra orașului, deci nu este deloc de ocolit.", " Cetățuia " },
                    { new Guid("2d1e7319-b3c8-4370-b55f-f037f7430371"), new Guid("aaeb6eed-024f-4cdd-97ea-bb8bd10096e1"), @"Parcare Caminele 12-17
                Complex Studentesc, Timisoara", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", "American Experience" },
                    { new Guid("b95f51fc-00ef-45de-b9a4-79a5c3db87f5"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), "Strada George Coșbuc 1, Timișoara 300048", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "The Drunken Rat Pub", "The Drunken Rat Pub" },
                    { new Guid("acb32030-e5b6-4d24-acd7-77198aaa1fdf"), new Guid("25742ac9-916a-409b-a234-218801cf11c6"), "Sala Barocă a Muzeului de Artă din Timișoara ", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Festivalul Internațional de Literatură de la Timișoara – Festivalul reunește autori români și străini, pentru două zile de lecturi și dialoguri deschise cu publicul.", "Festivalul Internațional de Literatură de la Timișoara " },
                    { new Guid("3114f4ba-b4f9-4104-af29-cbcd81063aa9"), new Guid("25742ac9-916a-409b-a234-218801cf11c6"), "Ambasada/Timisoara", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Festivalul Internațional de Tango Argentinian - Festivalul are loc anual, începând cu 2013, în ultima săptămână a lunii mai. Acest unic eveniment din vestul țării este organizat de Școala de Tango Argentinian „Tango Embrace”, din cadrul Asociației \"Art Embrace\".", "Festivalul Internațional de Tango Argentinian" },
                    { new Guid("3061932a-ad7e-450f-a3ec-a1cadf30c52b"), new Guid("25742ac9-916a-409b-a234-218801cf11c6"), "Aeroclubul „Alexandru Matei” ,Iași", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Hangariada înseamnă 3 zile de fericire cu ½ muzică și ½ zbor. Privești cerul, saltă inima, îți strângi prietenii de mână, lași gândul să-ți zboare prin iarba cosită. Te întinzi pe spate, îți pui ochelarii de soare, „oare de ce nu m-am făcut pilot/cântăreț ca-n compunerea dintr-a patra?” Aplauze! Ridică-te, înverzește-ți tălpile pantofilor, cântă și dansează odată cu cei de pe scenă. Și-apoi, a doua zi, de la capăt.", "Hangariada" },
                    { new Guid("dc42c140-a746-46a0-a017-e8a11472109b"), new Guid("8a4ad907-37b5-4b93-bc29-c896f65585d9"), " B-dul.Eroilor de la Tisa, Timisoara", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Vor participa dansatori din: Rusia, Bulgaria, Hungaria , France , Montenegro , Serbia , Moldova , Czech Republic si Romania ", "International Dance Open" },
                    { new Guid("426cfd53-e3ef-45cd-9f9d-b7fd7d55ec68"), new Guid("8a4ad907-37b5-4b93-bc29-c896f65585d9"), "Universitatea Politehnica Timişoara", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Chess Contest este un concurs de șah dedicat tuturor elevilor și studenților din toată țara, organizat de Liga AC (Liga Studenților din Facultatea de Automatică și Calculatoare) în colaborare cu Facultatea de Automatică și Calculatoare și Universitatea Politehnica Timișoara. Concursul se desfăşoară în perioada 17-19 noiembrie şi îşi propune să adune cât mai mulţi tineri în Timişoara pentru a-şi arăta strategia în această confruntare a minţii. ", "Chess Contest" },
                    { new Guid("2367a791-b4a7-435e-8f06-0d768a5b9dbc"), new Guid("8a4ad907-37b5-4b93-bc29-c896f65585d9"), "Sala Constantin Jude (Olimpia), Timisoara", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Ne propunem ca prin evenimentele noastre sa aducem un nou concept dedicat boxului profesionist,sa imbinam sportul cu spectacolul si sa aducem in fata publicului unii dintre cei mai buni sportivi de box si kickboxing din Romania, fiecare dintre acestia confruntandu-se pe reguli de box cu adversari de valoare din Europa, Africa si America Latina intr-o serie de 3 evenimente pe an ", "Noaptea Spartanilor" },
                    { new Guid("a5e372b8-0d74-45e3-8ddc-2e4fe33b635e"), new Guid("6497078e-f1a0-4142-9d03-b6182f292207"), @"Enduro Ranch (Bârnova, Județul Iași)
                ", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Asaltul Lupilor- evenimentului te aşteaptă pe un teren accidentat de 6 Km, perfect ca să-ţi testeze limitele. Vei alerga prin pădure, te vei târî prin şanţuri, te vei căţăra pe funii, vei traversa râpe, vei sări peste garduri, te vei împiedica sau nu de rădacinile copacilor şi nu în ultimul rând te vei murdări de noroi … dar te vei distra ! ", "Asaltul Lupilor" },
                    { new Guid("593ae191-3506-4491-aa2c-a5d523bc52b3"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), " Strada Michelangelo - Strada 20 Decembrie 1989,Timisoara", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Parcul Rozelor. Situat în centrul oraşului, la doar câțiva pași de malul râului Bega, Parcul Rozelor reprezintă o altă atracție de renume a Timişoarei. De fapt, s-ar putea spune că faima Timişoarei de oraş al parcurilor sau oraş al trandafirilor este în mare măsură datorată acestui parc.", "Parcul Rozelor" },
                    { new Guid("27689185-8ac9-4150-9225-0a8f3dd174ba"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), " Strada Hector, Timișoara", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Bastionul Maria Theresia-Aflat în zona centrală, între Hotel Continental și Fântâna Punctelor Cardinale (pe strada Hector), Bastionul Maria Theresia este un monument în stil baroc de o mare însemnătate istorică, fiind cea mai mare bucată de zid păstrată din vechea cetate a Timișoarei.", "Bastionul Maria Theresia" },
                    { new Guid("65c68d9e-bf00-4939-a500-1debbd49a9cb"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Bulevardul Regele Ferdinand I, Timișoara", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Catedrala Mitropolitană din Timișoara marchează cealaltă intrare principală în centrul orașului, fiind dispusă în partea de sud a pieței. Catedrala este fără îndoială una dintre clădirile care îți va atrage privirea indiferent în ce parte a centrului te vei afla, doar este cel mai mare edificiu religios din oraș. Impresionează atât prin arhitectura somptuoasă care îmbină stilul bizantin cu cel moldovenesc cât și prin dimensiunile sale vaste", "Catedrala Mitropolitană din Timișoara" },
                    { new Guid("6d6463d8-cf19-4ed8-a8cb-ad5be4dee864"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Strada Mărășești 2, Timișoara 300086", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Clădirea Palatului Culturii (cea care mărginește centrul în parte de nord) adăpostește astăzi Opera Națională Română și cele trei teatre de stat Teatrul National Mihai Eminescu, Teatrul Maghiar de Stat Csiky Gergely și Teatrul German de Stat (o situație unică și totodată o premieră în Europa). Dacă inițial clădirea avea exteriorul în stil Renaissance, în urma celor două mari incendii din 1880 și 1920, au mai rămas intacte doar aripile", "Palatului Culturii " },
                    { new Guid("238daa84-548a-4048-89ed-1a0813f6d514"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), " Strada Vasile Alecsandri 3, Timișoara 300078", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Jack's Bistro", "Jack's Bistro" },
                    { new Guid("675899b1-2772-460b-95e4-d40f57295354"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), "Joy Pub", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Joy Pub", "Joy Pub" },
                    { new Guid("ae1d8439-4e2d-40e2-899b-28c11aef7bba"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), " Strada Eugeniu de Savoya 11, Timișoara 300085", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Enoteca de Savoya", "Enoteca de Savoya" },
                    { new Guid("cf36d04d-611d-4814-afca-f3015ce93e12"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), "Strada Eugeniu de Savoya 9, Timișoara", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "The Scotland Yard", "The Scotland Yard" },
                    { new Guid("ce95ea32-ee97-4c8e-a089-50b9a5d0a3be"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), " str.Aries, Nr.19(Casa Tineretului), 300736 Timisoara", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "The 80's Pub", "The 80's Pub" },
                    { new Guid("73b82ddb-8904-4bc4-87b5-0f300d6d0cee"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Strada Republicii 42, Cluj-Napoca 400015", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Grădina Botanică - Fondată în anul 1872 și considerată astăzi muzeul național, Grădina Botanică este una dintre primele, cele mai mari și cele mai complexe astfel de grădini din sud-estul Europei. Întinzându-se pe o suprafață de 14 hectare, are ca principale atracții grădina japoneză, grădina romană, serele cu plante tropicale și ecuatoriale.", "Grădina Botanică " },
                    { new Guid("f0d01952-cc61-4eb8-b690-874b6ad300ef"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Piața Unirii ", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Piața Unirii - Asemenea Pieței Muzeului, Piața Unirii se mândrește cu unele dintre cele mai importante ansambluri arhitectonice gotice, baroce și neo-baroce din Transilvania: Biserica Romano-Catolică Sf. Mihail, Muzeul de Artă, Muzeul Farmaciei, pe care nu am mai apucat să-l vizităm, statuia lui Matia Corvin, Strada în oglindă și vechile palate nobiliare.", "Piața Unirii " },
                    { new Guid("cf9e8c22-c383-40a5-b68e-619e07c66d06"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), " Piața Muzeului, Cluj-Napoca 400000", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Sax", "Sax" },
                    { new Guid("57aa3a50-15cc-46cb-8760-064a9cd9a546"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), " Bulevardul Ștefan cel Mare și Sfânt nr. 28, Iași 700259", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Mănăstirea Sfinții Trei Ierarhi din Iași- Considerat un monument arhitectural de mare valoare în Iași și în întreaga țară, Mănăstirea Sfinții Trei Ierarhi atrage atenția prin arhitectura sa impresionantă și datorită decorațiunilor sale unice din piatră, care împodobesc fațadele superioare. Aceasta a fost zidită inițial pentru a inaugura domnia marelui voievod de odinioară, Vasile Lupu. Aceasta a fost restaurată din punct de vedere arhitectural în perioada 1882 – 1887, amenajarea interiorului său și realizarea picturilor continuând până în anul 1898.", "Mănăstirea Sfinții Trei Ierarhi din Iași" },
                    { new Guid("11ed29cd-f544-4cb9-842d-e062d826e38c"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Strada Agatha Bârsescu nr. 18, Iași 700074", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Teatrul Național Vasile Alecsandri- Datând din anul 1896, Teatrul Național Vasile Alecsandri este cel mai vechi din țară și unul dintre cele mai frumoase din Europa. Interiorul său elegant și bogat decorat a fost inspirat din stilurile arhitecturale baroce și rococo, unul dintre plafoanele sale fiind pictate de celebrul pictor vienez Alexander Goltz. Cortina sa a fost, de asemenea, pictată manual, simbolizând cele trei etape ale vieții și fiind considerată o alegorie a Unificării României.", "Teatrul Național Vasile Alecsandri" },
                    { new Guid("cbe7ca3f-59fb-44cd-a744-2ff7c91ef6dc"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Bulevardul Ștefan cel Mare și Sfânt 16, Iași 700064", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Mitropolia Moldovei și a Bucovinei- Aceasta este renumită pentru că adăpostește Moaștele Sfintei Cuvioase Parascheva, ocrotitoarea Moldovei. Monumentala catedrală ieșeană este marcată de patru turle masive, iar arhitectura sa este inspirată de stilul baroc, care marchează atât elementele decorative din exterior cât și cele din interiorul său.", "Mitropolia Moldovei și a Bucovinei" },
                    { new Guid("29cb2c39-30eb-4a78-985b-65db4668bc23"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Bulevardul Carol I nr. 31, Iași 700462", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Parcul Copou- Amenajarea celebrului Parc Copou din Iași a început în perioada 1833-1834. Acesta adăpostește Monumentul Legilor Constituționale, cel mai vechi monument din țara noastră. Cunoscut și ca Obeliscul cu lei, acesta a fost creat de Mihail Singurov în anul 1834. Reprezentat de o coloană din piatră de 15 m înălțime și cu o greutate ce depășește 10 tone, celebrul monument reprezintă un simbol al celor patru puteri europene care au recunoscut independența Țărilor Române.", "Parcul Copou" },
                    { new Guid("fe5202c4-480f-45d5-a62c-f564bfbb8f43"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Bulevardul Ștefan cel Mare și Sfânt 1, Iași 700028", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Palatul Culturii- Această clădire impresionantă este sediul a numeroase instituții culturale de prestigiu din acest oraș și a fost pusă în valoare prin recenta sa reabilitare. În cadrul Palatului Culturii din Iași vei descoperi patru muzee, care te vor ajuta să înțelegi mai bine istoria și cultura acestor meleaguri: Muzeul de Istorie al Moldovei, Muzeul Etnografic, Muzeul de Artă și Muzeul Științei și Tehnologiei Ștefan Procopiu.", "Palatul Culturii" },
                    { new Guid("838b6afe-1bbb-4988-adb0-ebe5b3e2d7a8"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), "Piața Unirii nr. 6, Iași 700055", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Cafeneaua Piața Unirii", "Cafeneaua Piața Unirii" },
                    { new Guid("2e657443-a30d-4439-907b-30404aa1d8b2"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), "Strada Moldovei 20, Iași 700046", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Vivo", "Vivo" },
                    { new Guid("924c244d-1155-490e-8e35-b18730e5a0dc"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), " Bulevardul Ștefan cel Mare și Sfânt nr. 8, Iași 700063", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Bistro \"La noi\"", "Bistro \"La noi\"" },
                    { new Guid("f3ed29bb-f0e5-4b0e-9bab-90e6f2309021"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), " Bulevardul Profesor Dimitrie Mangeron nr. 71, Iași 700050", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Kraft Pub & Restaurant", "Kraft Pub & Restaurant" },
                    { new Guid("ebc54f11-14b8-44b9-98ae-6dfedbe427df"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), "Strada Alexandru Lăpușneanu nr. 16, Iași 700057", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Beer Zone", "Beer Zone" },
                    { new Guid("b792aff9-2e2f-406a-9d86-b318fa54b520"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), "Piața Unirii nr. 5, Iași 700056", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Panoramic", "Panoramic" },
                    { new Guid("d0476716-2e95-400b-a9a6-2e60494e88fb"), new Guid("aaeb6eed-024f-4cdd-97ea-bb8bd10096e1"), "Bulevardul Carol I nr. 4, Iași 700505", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", " Student Travel" },
                    { new Guid("af1ec0c8-71c4-4099-b961-fc05de10e64a"), new Guid("aaeb6eed-024f-4cdd-97ea-bb8bd10096e1"), @"Copou
                Aleea Veronica Micle 8
                langa FEAA, dupa Teo's Cafe", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "American Experience" },
                    { new Guid("27cc347f-cced-4545-bb54-05e7241e178e"), new Guid("100f776b-9e14-4d5c-8385-4ab73ed4fd11"), "Strada Cloşca 9, Iași 700259", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Scopul organizatiei este promovarea credinţei şi a spiritualităţii ortodoxe în rândul tinerilor, cu prioritate în mediul univASCOR:  https://ascoriasi.ro/", "ASCOR" },
                    { new Guid("5d737659-7a87-41a2-9edf-9f4f1779ff0a"), new Guid("100f776b-9e14-4d5c-8385-4ab73ed4fd11"), "Cămin T11, Aleea Profesor Gheorghe Alexa, Iași 700259", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "BEST încearcă să ajute studenţii europeni să devină mai deschiși spre colaborarea internaţională, oferindu-le șansa de a se familiariza cu diversitatea culturală europeană, dezvoltându-le, în același timp, capacitatea de a lucra în medii internaționale.BEST:  https://bestis.ro/", "BEST" },
                    { new Guid("c5299e16-d963-49ca-8b04-5a7f71bec294"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Bulevardul Ștefan cel Mare și Sfânt nr. 10, Iași 700063", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Biblioteca Gheorghe Asachi- Biblioteca Gheorghe Asachi din Iași a fost desemnată ca fiind cea mai frumoasă din lume, în cadrul unei competiții desfășurate online la care au participat nume celebre din întreaga lume, precum Biblioteca Colegiului Trinity din Dublin, Biblioteca Regală Portugheză din Buenos Aires și Biblioteca Națională din Praga.", "Biblioteca Gheorghe Asachi" },
                    { new Guid("f7de889f-b38f-4e55-b356-dc62043bde66"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Str. Râpa Galbenă,Iași 700259", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Esplanada Elisabeta (Râpa Galbenă)- Râpa Galbenă din Iași, așa cum este cunoscută printre localnici, este o zonă importantă, localizată la baza Dealului Copou. Esplanada Elisabeta din Iași a fost construită la sfârșitul secolului al XIX-lea, scopul acesteia fiind acela de facilitare a circulației pietonilor către zona centrală a orașului.", "Esplanada Elisabeta " },
                    { new Guid("06ce8df9-dfdf-4dde-ac79-65c60293d480"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Corp AUniversitATEA Alexandru Ioan Cuza , Bulevardul Carol I 11, Iași 700506", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Sala Pașilor Pierduți- Dacă în cadrul periplului tău turistic te abați și pe la celebra Universitate “Alexandru Ioan Cuza” din Iași, trebuie să vizitezi și Sala Pașilor Pierduți. Picturile murale unice ale celebrului artist Sabin Bălașa te vor impresiona, acesta reușind să introducă acest spațiu pe harta locurilor de referință ale artei universale, prin măiestria sa artistică.", "Sala Pașilor Pierduți" },
                    { new Guid("2832b7cd-a06e-4abb-a428-4b548090d5cd"), new Guid("290d113e-9958-46dc-b8d1-1e6088c02730"), "Strada Dumbrava Roșie nr. 7-9, Iași 700487", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Grădina Botanică din Copou- Înființată în anul 1856, Grădina Botanică Anastasie Fătu poartă numele fondatorului său, un celebru medic și susținător al remediilor naturiste din acea perioadă. Aceasta este prima grădină universitară deschisă în țara noastră și cea mai mare din România în acest moment.", "Grădina Botanică din Copou" },
                    { new Guid("d1f796fd-184f-400e-a620-80e6ffe1f75a"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), " Cardinal Iuliu Hossu Street 3, Cluj-Napoca 400029", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Samsara Foodhouse", "Samsara Foodhouse" },
                    { new Guid("05aed951-2b76-4f7f-be54-3c5bf0d6e7cf"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), "Strada Universității 6, Cluj-Napoca 400091", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Casa TIFF", "Casa TIFF" },
                    { new Guid("af18c8cb-ef34-488c-bb0c-38b7278cc02e"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), "Strada Matei Corvin Nr 2, Cluj-Napoca 400000", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Old Shepherd", "Old Shepherd" },
                    { new Guid("a3014df3-60c9-46c4-a43d-b03b37cb0b71"), new Guid("ac2c9cc7-ac7a-4347-8a82-ead6f5c477c8"), "Strada Vasile Goldiș 4, Cluj-Napoca 400112", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "O'Peter's Irish Pub &Grill", "O'Peter's Irish Pub &Grill" },
                    { new Guid("2ad4edbf-68b3-49b6-b656-868ad0818da8"), new Guid("aaeb6eed-024f-4cdd-97ea-bb8bd10096e1"), "Strada Moldovei 1, Cluj-Napoca 400380", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), @"CE OFERA PROGRAMUL:
                un loc de munca in domeniul hospitality pe toata perioada programului (minim 3 luni pana la maxim 7 luni);
                masa si cazarea gratuita;
                suport permanent 24h din 24 pe toata perioada derularii programului;
                salariul cuprins intre 300 si 500 Euro;Student Travel: shorturl.at/gilp9", "Adira Work & Travel" },
                    { new Guid("36c455fc-02bf-4981-97ac-04441ce0590d"), new Guid("aaeb6eed-024f-4cdd-97ea-bb8bd10096e1"), "Strada Piezisa Nr 19", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), @"Summer Work & Travel SUA – este un program de schimb cultural, reglementat de catre Departamentul de Stat
                al SUA. Pe durata acestui program studentii, masteranzii sau doctoranzii inscrisi la zi la cursurile
                unei facultati acreditate din Romania, au posibilitatea de a expermimenta legal culutra americana pe o perioada
                determinata de maxim 3 luni si jumatate, pe durata vacantei universitare.
                De asemenea programul le permite acestora sa viziteze teritoriul Statelor Unite ale Americii pentru o perioada determinata de maxim 1 luna. La terminarea programului trebuie sa se intoarca in tara de resedinta, unde isi vor continua studiile.American Experience:  shorturl.at/dEMN1", "American Experience" },
                    { new Guid("2a4890c5-50f6-400f-beca-16910feb3271"), new Guid("100f776b-9e14-4d5c-8385-4ab73ed4fd11"), "Strada Frumoasă, Nr. 31, Cluj", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Și-au propus să aibă impact asupra mediului economic românesc, oferind acces la resurse de învățare care te vor ajuta să-ți dezvolți competențele profesionale, dar și sociale. Proiectele lor sunt practice, interactive și te aduc cu un pas mai aproape de cariera pe care ți-o dorești. ", "ASER" },
                    { new Guid("4058a2f1-624c-4bda-8abd-f6fe680bb2f7"), new Guid("25742ac9-916a-409b-a234-218801cf11c6"), "Piata Victoriei, Timisoara", new Guid("fd6a7b48-a14c-4bca-a136-00f2a6011835"), "Festivalul Jazz TM este un festival de jazz care se desfășoară în aer liber, în Piața Victoriei, în luna iulie și aduce pe scenă artiști din scena internațională a muzicii Jazz.", "Festivalul Jazz TM" },
                    { new Guid("d6b9eeff-d6f8-497c-a3df-11bd338184ea"), new Guid("100f776b-9e14-4d5c-8385-4ab73ed4fd11"), "Strada Păstorului 11, Cluj-Napoca 400338", new Guid("ab48c80c-d6d6-44e3-ba69-edb16236e667"), "Organizația Studenților de la Universitatea Tehnică oferă un cadru informal în care viitorii ingineri pot construi fundația carierei lor.", "OSUBB" },
                    { new Guid("1594a166-f40b-479f-b5fb-bd2abc5f79db"), new Guid("25742ac9-916a-409b-a234-218801cf11c6"), " Iași, str. V. Pogor, nr. 4, 700110.", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Festivalul Internațional de Literatură și Traducere Iași (FILIT) este un festival internațional care are loc anual în octombrie, în Iași. Festivalul reunește la Iași profesioniști din domeniul cărții, atât din țară, cât și din străinătate. Scriitori, traducători, editori, organizatori de festival, critici literari, librari, distribuitori de carte, manageri și jurnaliști culturali – cu toții se află, de-a lungul celor cinci zile de festival, în centrul unor evenimente destinate, pe de o parte, publicului larg, pe de altă parte, specialiștilor din domeniu.", "FILIT" },
                    { new Guid("7c627e94-cb69-4972-a5c7-c1108cdf0bb8"), new Guid("25742ac9-916a-409b-a234-218801cf11c6"), "Strada Vasile Lupu 78A, Iași 700350", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Afterhills este cel mai tânăr festival de muzică de anvergură din România, desfășurat în județul Iași, fiind cel mai mare și important festival din regiunea Moldova.", "Afterhills " },
                    { new Guid("d8790815-04ed-40d9-a067-252b520ed622"), new Guid("25742ac9-916a-409b-a234-218801cf11c6"), @"Piața Unirii 5
                Iași", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Se organizeaza seri de film in diferite locatii, unde sunt invitati oameni importanti ai filmului romanesc.", "Serile de Film Romanesc" },
                    { new Guid("4cda871c-8bfb-4b3f-a264-f2f2f7ec2f75"), new Guid("6497078e-f1a0-4142-9d03-b6182f292207"), "Start/Stop: Cluj Arena, Cluj", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Maratonul de Ciclism International din nou la Cluj(Perioada Mai-Iunie)- evenimentul sportiv  aduce la Cluj cel mai mare număr de cicliști din România, într-un context nou și plin de surprize. Vor exista competiții de ciclism și alergare pentru adulți, competiții pentru copii, competiție de spinning, o zonă culinară și una de camping cu foc de tabără precum și alte activități de petrecere a timpului liber.", "Maratonul de Ciclism International din nou la Cluj" },
                    { new Guid("fb9034a0-373c-426c-9188-ff5951e5cf33"), new Guid("6497078e-f1a0-4142-9d03-b6182f292207"), "Strat/Stop: Palatul Culturii, Iasi", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Maratonul International Iasi- Maratonul International Iasi isi propune sa fie un eveniment sportiv de referinta pentru Municipiul Iasi, dar si la nivel regional, national si international. Obiectivul principal este unul social, fondurile rezultate in urma organizarii evenimentului fiind destinate finantarii proiectului de Infiintare si functionare a punctelor de prim ajutor si interventie in caz de dezastre in principalele cartiere ale Iasului", "Maratonul International Iasi" },
                    { new Guid("13761699-8142-49c4-b898-5f7c7045b916"), new Guid("6497078e-f1a0-4142-9d03-b6182f292207"), "Strada Pantelimon Halipa 6B, Iași", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Întreținere corporală- săli de sport cu prețuri speciale pentru student: Oxygen, Let’ s move", "Întreținere corporală" },
                    { new Guid("1d8b7967-6e4a-4b9f-993c-909c64208874"), new Guid("6497078e-f1a0-4142-9d03-b6182f292207"), "Strada Stihii 2, Iași 700083", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Pilates- Pilates este o metodă de întărire a mușchilor profunzi, care sunt responsabili cu menținerea posturii. (Tonus Plus- sală )", "Pilates" },
                    { new Guid("9f619efb-42f7-4060-9e98-ee87bada0b0a"), new Guid("25742ac9-916a-409b-a234-218801cf11c6"), "Smida, 18, Smida 407082, Cluj", new Guid("258b677e-a470-4d6c-a96a-311eb96ffa63"), "Smida Jazz, festival dedicat jazz-ului de avangardă ce se desfășoară an de an în pitorescul sat Smida (comuna Beliș, județul Cluj - în mijlocul Parcului Natural Apuseni). Pe parcursul a 3 zile, vom petrece o vacanță în Apuseni, cu tot felul de activități în aer liber și concerte ale grupurilor internaționale și din România. ", "Smida Jazz" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "PasswordHash", "StudentId", "UserTypeId", "Username" },
                values: new object[] { new Guid("3c9178c1-1012-4651-9d15-165f40e4b22d"), "DoFestAdmin@gmail.com", "mZH/NAc4eKaBQL077AcgPA==.6hjQwsJSL8P8jm7ipUWKY/4rIk2pOtTgK56CxoIfd7g=", null, new Guid("52ec3370-b713-4369-8eb1-7eac667ef210"), "DoFestAdmin" });

            migrationBuilder.InsertData(
                table: "BucketList",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { new Guid("5c5bb121-e3ed-426d-9889-b875a21b1531"), "Admin bucketList", new Guid("3c9178c1-1012-4651-9d15-165f40e4b22d") });

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
