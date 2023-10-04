namespace FilmesApi.Migrations;

/// <summary>
/// Migração para criar a tabela de filmes no banco de dados.
/// </summary>
public partial class CriandoTabelaDeFilme : Migration
{
    /// <summary>
    /// Aplica as alterações necessárias para criar a tabela de filmes.
    /// </summary>
    /// <param name="migrationBuilder">O construtor de migrações.</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterDatabase()
            .Annotation("MySql:CharSet", "utf8mb4");

        migrationBuilder.CreateTable(
            name: "Filmes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Titulo = table.Column<string>(type: "longtext", nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Genero = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                    .Annotation("MySql:CharSet", "utf8mb4"),
                Duracao = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Filmes", x => x.Id);
            })
            .Annotation("MySql:CharSet", "utf8mb4");
    }

    /// <summary>
    /// Reverte as alterações realizadas pela migração, excluindo a tabela de filmes.
    /// </summary>
    /// <param name="migrationBuilder">O construtor de migrações.</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Filmes");
    }
}
