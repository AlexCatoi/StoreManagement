using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperMarket.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bon",
                columns: table => new
                {
                    BonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEliberarii = table.Column<DateOnly>(type: "date", nullable: false),
                    NumeCasier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SumaTotala = table.Column<float>(type: "real", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bon", x => x.BonId);
                });

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.CategorieId);
                });

            migrationBuilder.CreateTable(
                name: "Producator",
                columns: table => new
                {
                    ProducatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<int>(type: "int", nullable: false),
                    NumeProducator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaraProducator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producator", x => x.ProducatorId);
                });

            migrationBuilder.CreateTable(
                name: "Stoc",
                columns: table => new
                {
                    StocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StocName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantitate = table.Column<int>(type: "int", nullable: false),
                    UnitateMasura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAprovizionarii = table.Column<DateOnly>(type: "date", nullable: false),
                    DataExpirarii = table.Column<DateOnly>(type: "date", nullable: false),
                    NumeProd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PretAchizitie = table.Column<float>(type: "real", nullable: false),
                    PretVanzare = table.Column<float>(type: "real", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoc", x => x.StocId);
                });

            migrationBuilder.CreateTable(
                name: "Utilizator",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeUtilizator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipUser = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizator", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Produs",
                columns: table => new
                {
                    ProdusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeProdus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodBare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    ProducatorId = table.Column<int>(type: "int", nullable: false),
                    StocId = table.Column<int>(type: "int", nullable: false),
                    PretProdus = table.Column<float>(type: "real", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produs", x => x.ProdusId);
                    table.ForeignKey(
                        name: "FK_Produs_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produs_Producator_ProducatorId",
                        column: x => x.ProducatorId,
                        principalTable: "Producator",
                        principalColumn: "ProducatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produs_Stoc_StocId",
                        column: x => x.StocId,
                        principalTable: "Stoc",
                        principalColumn: "StocId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdusePeBons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdusId = table.Column<int>(type: "int", nullable: false),
                    cantitate = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<float>(type: "real", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false),
                    BonuriBonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdusePeBons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdusePeBons_Bon_BonuriBonId",
                        column: x => x.BonuriBonId,
                        principalTable: "Bon",
                        principalColumn: "BonId");
                    table.ForeignKey(
                        name: "FK_ProdusePeBons_Produs_ProdusId",
                        column: x => x.ProdusId,
                        principalTable: "Produs",
                        principalColumn: "ProdusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produs_CategorieId",
                table: "Produs",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Produs_ProducatorId",
                table: "Produs",
                column: "ProducatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Produs_StocId",
                table: "Produs",
                column: "StocId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdusePeBons_BonuriBonId",
                table: "ProdusePeBons",
                column: "BonuriBonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdusePeBons_ProdusId",
                table: "ProdusePeBons",
                column: "ProdusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdusePeBons");

            migrationBuilder.DropTable(
                name: "Utilizator");

            migrationBuilder.DropTable(
                name: "Bon");

            migrationBuilder.DropTable(
                name: "Produs");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Producator");

            migrationBuilder.DropTable(
                name: "Stoc");
        }
    }
}
