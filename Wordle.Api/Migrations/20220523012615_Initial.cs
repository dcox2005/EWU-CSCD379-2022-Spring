using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wordle.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameCount = table.Column<int>(type: "int", nullable: false),
                    AverageAttempts = table.Column<double>(type: "float", nullable: false),
                    AverageSecondsPerGame = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "ScoreStats",
                columns: table => new
                {
                    ScoreStatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    AverageSeconds = table.Column<int>(type: "int", nullable: false),
                    TotalGames = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreStats", x => x.ScoreStatId);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    WordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.WordId);
                });

            migrationBuilder.CreateTable(
                name: "DateWords",
                columns: table => new
                {
                    DateWordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPlays = table.Column<int>(type: "int", nullable: false),
                    AverageScore = table.Column<double>(type: "float", nullable: false),
                    AverageTime = table.Column<double>(type: "float", nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateWords", x => x.DateWordId);
                    table.ForeignKey(
                        name: "FK_DateWords_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "WordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnded = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "WordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guess",
                columns: table => new
                {
                    GuessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guess", x => x.GuessId);
                    table.ForeignKey(
                        name: "FK_Guess_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ScoreStats",
                columns: new[] { "ScoreStatId", "AverageSeconds", "Score", "TotalGames" },
                values: new object[,]
                {
                    { 1, 0, 1, 0 },
                    { 2, 0, 2, 0 },
                    { 3, 0, 3, 0 },
                    { 4, 0, 4, 0 },
                    { 5, 0, 5, 0 },
                    { 6, 0, 6, 0 }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 1, "acorn" },
                    { 2, "acrid" },
                    { 3, "actor" },
                    { 4, "adept" },
                    { 5, "adobe" },
                    { 6, "adorn" },
                    { 7, "adult" },
                    { 8, "agent" },
                    { 9, "agony" },
                    { 10, "aisle" },
                    { 11, "alder" },
                    { 12, "alien" },
                    { 13, "alike" },
                    { 14, "alive" },
                    { 15, "alone" },
                    { 16, "aloud" },
                    { 17, "amber" },
                    { 18, "ample" },
                    { 19, "amuck" },
                    { 20, "angel" },
                    { 21, "angry" },
                    { 22, "ankle" },
                    { 23, "antic" },
                    { 24, "arise" },
                    { 25, "aspen" },
                    { 26, "aspic" },
                    { 27, "audio" },
                    { 28, "awful" },
                    { 29, "azure" },
                    { 30, "balmy" },
                    { 31, "bandy" },
                    { 32, "basic" },
                    { 33, "basin" },
                    { 34, "batch" },
                    { 35, "baton" },
                    { 36, "bawdy" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 37, "beady" },
                    { 38, "beamy" },
                    { 39, "beast" },
                    { 40, "being" },
                    { 41, "bight" },
                    { 42, "bigot" },
                    { 43, "binge" },
                    { 44, "bingo" },
                    { 45, "biped" },
                    { 46, "birch" },
                    { 47, "birth" },
                    { 48, "bison" },
                    { 49, "biter" },
                    { 50, "blame" },
                    { 51, "bland" },
                    { 52, "blank" },
                    { 53, "bleak" },
                    { 54, "bleat" },
                    { 55, "blind" },
                    { 56, "bloat" },
                    { 57, "blond" },
                    { 58, "blunt" },
                    { 59, "bodge" },
                    { 60, "bogie" },
                    { 61, "bogus" },
                    { 62, "boned" },
                    { 63, "bonus" },
                    { 64, "bound" },
                    { 65, "boxer" },
                    { 66, "braid" },
                    { 67, "brand" },
                    { 68, "brash" },
                    { 69, "brave" },
                    { 70, "brawl" },
                    { 71, "brawn" },
                    { 72, "brick" },
                    { 73, "brief" },
                    { 74, "brisk" },
                    { 75, "broad" },
                    { 76, "broke" },
                    { 77, "brute" },
                    { 78, "bugle" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 79, "built" },
                    { 80, "bulky" },
                    { 81, "burly" },
                    { 82, "bushy" },
                    { 83, "butch" },
                    { 84, "cadet" },
                    { 85, "cadre" },
                    { 86, "calyx" },
                    { 87, "camel" },
                    { 88, "caste" },
                    { 89, "cedar" },
                    { 90, "chaos" },
                    { 91, "chard" },
                    { 92, "cheap" },
                    { 93, "chest" },
                    { 94, "chief" },
                    { 95, "china" },
                    { 96, "chirp" },
                    { 97, "chive" },
                    { 98, "choir" },
                    { 99, "choky" },
                    { 100, "chore" },
                    { 101, "churl" },
                    { 102, "clave" },
                    { 103, "cleft" },
                    { 104, "clerk" },
                    { 105, "clove" },
                    { 106, "clown" },
                    { 107, "clung" },
                    { 108, "comer" },
                    { 109, "conga" },
                    { 110, "coral" },
                    { 111, "corny" },
                    { 112, "corps" },
                    { 113, "corse" },
                    { 114, "court" },
                    { 115, "couth" },
                    { 116, "cover" },
                    { 117, "covey" },
                    { 118, "crake" },
                    { 119, "cramp" },
                    { 120, "craps" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 121, "crash" },
                    { 122, "crawl" },
                    { 123, "crazy" },
                    { 124, "cream" },
                    { 125, "crime" },
                    { 126, "crimp" },
                    { 127, "croup" },
                    { 128, "crown" },
                    { 129, "crude" },
                    { 130, "cruel" },
                    { 131, "cruet" },
                    { 132, "crump" },
                    { 133, "crypt" },
                    { 134, "curia" },
                    { 135, "curst" },
                    { 136, "curve" },
                    { 137, "daily" },
                    { 138, "datum" },
                    { 139, "delta" },
                    { 140, "demon" },
                    { 141, "depth" },
                    { 142, "diary" },
                    { 143, "dicky" },
                    { 144, "dinar" },
                    { 145, "diner" },
                    { 146, "dinge" },
                    { 147, "disco" },
                    { 148, "diver" },
                    { 149, "dogma" },
                    { 150, "doing" },
                    { 151, "dough" },
                    { 152, "downy" },
                    { 153, "dowry" },
                    { 154, "dozen" },
                    { 155, "draft" },
                    { 156, "drake" },
                    { 157, "drift" },
                    { 158, "drove" },
                    { 159, "drunk" },
                    { 160, "ducat" },
                    { 161, "dumpy" },
                    { 162, "dusky" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 163, "dusty" },
                    { 164, "dwarf" },
                    { 165, "dying" },
                    { 166, "debut" },
                    { 167, "early" },
                    { 168, "elfin" },
                    { 169, "entry" },
                    { 170, "envoy" },
                    { 171, "epoch" },
                    { 172, "equal" },
                    { 173, "ergot" },
                    { 174, "ethic" },
                    { 175, "exact" },
                    { 176, "exist" },
                    { 177, "extra" },
                    { 178, "faint" },
                    { 179, "fairy" },
                    { 180, "faker" },
                    { 181, "fakir" },
                    { 182, "false" },
                    { 183, "fancy" },
                    { 184, "fated" },
                    { 185, "feint" },
                    { 186, "felon" },
                    { 187, "femur" },
                    { 188, "feral" },
                    { 189, "field" },
                    { 190, "fiend" },
                    { 191, "fiery" },
                    { 192, "filet" },
                    { 193, "final" },
                    { 194, "finch" },
                    { 195, "first" },
                    { 196, "fishy" },
                    { 197, "fitch" },
                    { 198, "fiver" },
                    { 199, "fixed" },
                    { 200, "fixer" },
                    { 201, "flair" },
                    { 202, "flaky" },
                    { 203, "flank" },
                    { 204, "flask" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 205, "flesh" },
                    { 206, "flint" },
                    { 207, "flirt" },
                    { 208, "flora" },
                    { 209, "fluid" },
                    { 210, "fluke" },
                    { 211, "flush" },
                    { 212, "forte" },
                    { 213, "forum" },
                    { 214, "fount" },
                    { 215, "frail" },
                    { 216, "frank" },
                    { 217, "frisk" },
                    { 218, "frond" },
                    { 219, "fusil" },
                    { 220, "fusty" },
                    { 221, "gamut" },
                    { 222, "gaper" },
                    { 223, "garth" },
                    { 224, "gaunt" },
                    { 225, "gauze" },
                    { 226, "genus" },
                    { 227, "getup" },
                    { 228, "giant" },
                    { 229, "glade" },
                    { 230, "gland" },
                    { 231, "glare" },
                    { 232, "gloat" },
                    { 233, "gnome" },
                    { 234, "grail" },
                    { 235, "grand" },
                    { 236, "grate" },
                    { 237, "grave" },
                    { 238, "gravy" },
                    { 239, "great" },
                    { 240, "grief" },
                    { 241, "groat" },
                    { 242, "group" },
                    { 243, "grove" },
                    { 244, "guild" },
                    { 245, "gumbo" },
                    { 246, "hardy" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 247, "haver" },
                    { 248, "hawse" },
                    { 249, "hazel" },
                    { 250, "heady" },
                    { 251, "heavy" },
                    { 252, "hoary" },
                    { 253, "honey" },
                    { 254, "horde" },
                    { 255, "hover" },
                    { 256, "human" },
                    { 257, "husky" },
                    { 258, "idler" },
                    { 259, "inert" },
                    { 260, "inlet" },
                    { 261, "irony" },
                    { 262, "ivory" },
                    { 263, "jerky" },
                    { 264, "jihad" },
                    { 265, "joust" },
                    { 266, "juicy" },
                    { 267, "jumbo" },
                    { 268, "knave" },
                    { 269, "labor" },
                    { 270, "laity" },
                    { 271, "laker" },
                    { 272, "large" },
                    { 273, "laser" },
                    { 274, "later" },
                    { 275, "latex" },
                    { 276, "laver" },
                    { 277, "leafy" },
                    { 278, "leaky" },
                    { 279, "lemon" },
                    { 280, "letch" },
                    { 281, "limbo" },
                    { 282, "lined" },
                    { 283, "liner" },
                    { 284, "lithe" },
                    { 285, "liver" },
                    { 286, "loath" },
                    { 287, "locus" },
                    { 288, "lofty" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 289, "logic" },
                    { 290, "lotus" },
                    { 291, "lover" },
                    { 292, "lower" },
                    { 293, "lucid" },
                    { 294, "lucky" },
                    { 295, "lumen" },
                    { 296, "lurid" },
                    { 297, "lusty" },
                    { 298, "lying" },
                    { 299, "lyric" },
                    { 300, "macro" },
                    { 301, "madly" },
                    { 302, "magus" },
                    { 303, "maize" },
                    { 304, "major" },
                    { 305, "manes" },
                    { 306, "mango" },
                    { 307, "manly" },
                    { 308, "manor" },
                    { 309, "manse" },
                    { 310, "maybe" },
                    { 311, "mealy" },
                    { 312, "meaty" },
                    { 313, "media" },
                    { 314, "medic" },
                    { 315, "midge" },
                    { 316, "miner" },
                    { 317, "minor" },
                    { 318, "mirth" },
                    { 319, "miser" },
                    { 320, "misty" },
                    { 321, "mixed" },
                    { 322, "mixer" },
                    { 323, "mocha" },
                    { 324, "modal" },
                    { 325, "model" },
                    { 326, "moist" },
                    { 327, "molar" },
                    { 328, "monad" },
                    { 329, "moral" },
                    { 330, "morel" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 331, "mould" },
                    { 332, "mousy" },
                    { 333, "mover" },
                    { 334, "movie" },
                    { 335, "mufti" },
                    { 336, "murky" },
                    { 337, "mushy" },
                    { 338, "music" },
                    { 339, "musty" },
                    { 340, "nadir" },
                    { 341, "naive" },
                    { 342, "naked" },
                    { 343, "nasty" },
                    { 344, "nates" },
                    { 345, "navel" },
                    { 346, "neigh" },
                    { 347, "nervy" },
                    { 348, "night" },
                    { 349, "noble" },
                    { 350, "noisy" },
                    { 351, "north" },
                    { 352, "noted" },
                    { 353, "nymph" },
                    { 354, "oared" },
                    { 355, "ocean" },
                    { 356, "ocher" },
                    { 357, "odium" },
                    { 358, "often" },
                    { 359, "olive" },
                    { 360, "omega" },
                    { 361, "opera" },
                    { 362, "optic" },
                    { 363, "ounce" },
                    { 364, "outer" },
                    { 365, "ovary" },
                    { 366, "ovine" },
                    { 367, "palsy" },
                    { 368, "panic" },
                    { 369, "pants" },
                    { 370, "party" },
                    { 371, "pasty" },
                    { 372, "paten" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 373, "peach" },
                    { 374, "pecan" },
                    { 375, "pedal" },
                    { 376, "penal" },
                    { 377, "phony" },
                    { 378, "piano" },
                    { 379, "piety" },
                    { 380, "piker" },
                    { 381, "pilot" },
                    { 382, "pinch" },
                    { 383, "pinky" },
                    { 384, "pious" },
                    { 385, "pithy" },
                    { 386, "plain" },
                    { 387, "plumb" },
                    { 388, "plush" },
                    { 389, "poker" },
                    { 390, "pokey" },
                    { 391, "polar" },
                    { 392, "polka" },
                    { 393, "porch" },
                    { 394, "porgy" },
                    { 395, "poser" },
                    { 396, "prawn" },
                    { 397, "prime" },
                    { 398, "primo" },
                    { 399, "privy" },
                    { 400, "prize" },
                    { 401, "prone" },
                    { 402, "prose" },
                    { 403, "proud" },
                    { 404, "proxy" },
                    { 405, "pubes" },
                    { 406, "pylon" },
                    { 407, "quack" },
                    { 408, "qualm" },
                    { 409, "quart" },
                    { 410, "quick" },
                    { 411, "quiet" },
                    { 412, "quint" },
                    { 413, "quirk" },
                    { 414, "quite" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 415, "quota" },
                    { 416, "rabid" },
                    { 417, "radix" },
                    { 418, "rapid" },
                    { 419, "ratio" },
                    { 420, "raven" },
                    { 421, "rayon" },
                    { 422, "ready" },
                    { 423, "regal" },
                    { 424, "reign" },
                    { 425, "reins" },
                    { 426, "relax" },
                    { 427, "relay" },
                    { 428, "relic" },
                    { 429, "rheum" },
                    { 430, "right" },
                    { 431, "rocky" },
                    { 432, "rogue" },
                    { 433, "roman" },
                    { 434, "rouge" },
                    { 435, "rough" },
                    { 436, "royal" },
                    { 437, "runic" },
                    { 438, "rusty" },
                    { 439, "sable" },
                    { 440, "sabre" },
                    { 441, "salon" },
                    { 442, "salty" },
                    { 443, "salvo" },
                    { 444, "sandy" },
                    { 445, "satin" },
                    { 446, "satyr" },
                    { 447, "saucy" },
                    { 448, "scald" },
                    { 449, "scaly" },
                    { 450, "scant" },
                    { 451, "scape" },
                    { 452, "scary" },
                    { 453, "scion" },
                    { 454, "scrim" },
                    { 455, "scrip" },
                    { 456, "setup" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 457, "shady" },
                    { 458, "shaky" },
                    { 459, "shank" },
                    { 460, "shard" },
                    { 461, "shine" },
                    { 462, "shiny" },
                    { 463, "shire" },
                    { 464, "shlep" },
                    { 465, "shoal" },
                    { 466, "shock" },
                    { 467, "short" },
                    { 468, "showy" },
                    { 469, "sigma" },
                    { 470, "siren" },
                    { 471, "skate" },
                    { 472, "skein" },
                    { 473, "skimp" },
                    { 474, "slate" },
                    { 475, "slave" },
                    { 476, "slick" },
                    { 477, "slimy" },
                    { 478, "sloth" },
                    { 479, "smock" },
                    { 480, "smoky" },
                    { 481, "snail" },
                    { 482, "snake" },
                    { 483, "snaky" },
                    { 484, "snowy" },
                    { 485, "soapy" },
                    { 486, "sober" },
                    { 487, "solar" },
                    { 488, "solid" },
                    { 489, "sough" },
                    { 490, "south" },
                    { 491, "spare" },
                    { 492, "spate" },
                    { 493, "spelt" },
                    { 494, "spent" },
                    { 495, "sperm" },
                    { 496, "spick" },
                    { 497, "spicy" },
                    { 498, "spiny" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 499, "splat" },
                    { 500, "splay" },
                    { 501, "split" },
                    { 502, "spore" },
                    { 503, "sport" },
                    { 504, "sprat" },
                    { 505, "sprue" },
                    { 506, "spume" },
                    { 507, "spunk" },
                    { 508, "squab" },
                    { 509, "squat" },
                    { 510, "squid" },
                    { 511, "stair" },
                    { 512, "stale" },
                    { 513, "stang" },
                    { 514, "stark" },
                    { 515, "steam" },
                    { 516, "stern" },
                    { 517, "stich" },
                    { 518, "stile" },
                    { 519, "stock" },
                    { 520, "stoic" },
                    { 521, "stole" },
                    { 522, "stoma" },
                    { 523, "stone" },
                    { 524, "straw" },
                    { 525, "stria" },
                    { 526, "stuck" },
                    { 527, "suite" },
                    { 528, "sulky" },
                    { 529, "sumac" },
                    { 530, "super" },
                    { 531, "swain" },
                    { 532, "swale" },
                    { 533, "swank" },
                    { 534, "sward" },
                    { 535, "swart" },
                    { 536, "swing" },
                    { 537, "sworn" },
                    { 538, "sylph" },
                    { 539, "synod" },
                    { 540, "syrup" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 541, "tache" },
                    { 542, "talon" },
                    { 543, "talus" },
                    { 544, "tango" },
                    { 545, "tawny" },
                    { 546, "teary" },
                    { 547, "tempo" },
                    { 548, "tenor" },
                    { 549, "thick" },
                    { 550, "thief" },
                    { 551, "thing" },
                    { 552, "think" },
                    { 553, "thong" },
                    { 554, "throb" },
                    { 555, "thunk" },
                    { 556, "tiger" },
                    { 557, "tiler" },
                    { 558, "timer" },
                    { 559, "tipsy" },
                    { 560, "tired" },
                    { 561, "topaz" },
                    { 562, "topic" },
                    { 563, "torus" },
                    { 564, "tough" },
                    { 565, "trace" },
                    { 566, "trial" },
                    { 567, "trice" },
                    { 568, "tripe" },
                    { 569, "trope" },
                    { 570, "truck" },
                    { 571, "truly" },
                    { 572, "trunk" },
                    { 573, "tuber" },
                    { 574, "tulip" },
                    { 575, "tumid" },
                    { 576, "tumor" },
                    { 577, "tuner" },
                    { 578, "tunic" },
                    { 579, "twice" },
                    { 580, "twink" },
                    { 581, "ultra" },
                    { 582, "umber" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 583, "umbra" },
                    { 584, "unfit" },
                    { 585, "unite" },
                    { 586, "upset" },
                    { 587, "urban" },
                    { 588, "valor" },
                    { 589, "velar" },
                    { 590, "velum" },
                    { 591, "venal" },
                    { 592, "video" },
                    { 593, "vinyl" },
                    { 594, "viola" },
                    { 595, "viper" },
                    { 596, "vista" },
                    { 597, "vital" },
                    { 598, "vixen" },
                    { 599, "vizor" },
                    { 600, "vocal" },
                    { 601, "vogue" },
                    { 602, "wader" },
                    { 603, "washy" },
                    { 604, "waste" },
                    { 605, "waver" },
                    { 606, "waxen" },
                    { 607, "weald" },
                    { 608, "weary" },
                    { 609, "weird" },
                    { 610, "welsh" },
                    { 611, "wench" },
                    { 612, "wheat" },
                    { 613, "whelk" },
                    { 614, "whist" },
                    { 615, "white" },
                    { 616, "wight" },
                    { 617, "wince" },
                    { 618, "windy" },
                    { 619, "wiper" },
                    { 620, "wired" },
                    { 621, "wizen" },
                    { 622, "world" },
                    { 623, "wormy" },
                    { 624, "worse" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 625, "worth" },
                    { 626, "wound" },
                    { 627, "woven" },
                    { 628, "wrath" },
                    { 629, "wrong" },
                    { 630, "yacht" },
                    { 631, "zebra" }
                });

            migrationBuilder.InsertData(
                table: "DateWords",
                columns: new[] { "DateWordId", "AverageScore", "AverageTime", "Date", "NumberOfPlays", "WordId" },
                values: new object[,]
                {
                    { 1, 1.54, 78.0, new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 1 },
                    { 2, 4.25, 180.0, new DateTime(2022, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 2 },
                    { 3, 5.2999999999999998, 96.0, new DateTime(2022, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 3 },
                    { 5, 5.3099999999999996, 65.0, new DateTime(2022, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 5 },
                    { 6, 3.25, 87.0, new DateTime(2022, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 758, 6 },
                    { 7, 5.3399999999999999, 78.0, new DateTime(2022, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 58, 7 },
                    { 8, 3.5099999999999998, 98.0, new DateTime(2022, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 456, 8 },
                    { 9, 3.54, 45.0, new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 543, 9 },
                    { 10, 1.5600000000000001, 254.0, new DateTime(2022, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 456, 10 },
                    { 11, 1.3500000000000001, 148.0, new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 876, 11 },
                    { 12, 2.1299999999999999, 92.0, new DateTime(2022, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 12 },
                    { 13, 3.0099999999999998, 35.0, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateWords_WordId",
                table: "DateWords",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerId",
                table: "Games",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WordId",
                table: "Games",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_Guess_GameId",
                table: "Guess",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateWords");

            migrationBuilder.DropTable(
                name: "Guess");

            migrationBuilder.DropTable(
                name: "ScoreStats");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
