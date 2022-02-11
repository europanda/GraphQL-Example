using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseInsensitiveGraphQL.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.Sql(@"INSERT INTO [users] (name) VALUES 
                ('Amos Erickson'), 
                ('Clark Roberson'), 
                ('Ursa Giles'), 
                ('Hedy Giles'), 
                ('Jasmine Santos');");

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    is_primary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_addresses", x => x.id);
                    table.ForeignKey(
                        name: "fk_addresses_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_addresses_user_id",
                table: "addresses",
                column: "user_id");

            migrationBuilder.Sql(@"INSERT INTO [addresses] (user_id, street) VALUES 
                (1, '221 Baker Street, London'),
                (1, '479-853 Risus. Rd.'),
                (2, 'Ap #256-3267 Massa. Ave'), 
                (3, '8492 Nibh. Rd.'), 
                (4, '806-1736 Tellus Rd.'), 
                (5, 'P.O. Box 374, 6675 Pharetra, Ave'); ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
