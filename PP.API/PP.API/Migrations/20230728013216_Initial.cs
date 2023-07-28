using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PP.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property8 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property9 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property10 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
