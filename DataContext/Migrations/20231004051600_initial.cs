using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContext.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryBonus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            // Stored Procedure for Adding Employee
            migrationBuilder.Sql(@"
            CREATE PROCEDURE AddEmployee
                @Name NVARCHAR(MAX),
                @Salary INT,
                @PositionId INT
            AS
            BEGIN
                INSERT INTO Employees (Name, Salary, PositionId)
                VALUES (@Name, @Salary, @PositionId);
            END
        ");

            // Stored Procedure for Updating Employee
            migrationBuilder.Sql(@"
            CREATE PROCEDURE UpdateEmployee
                @EmployeeId INT,
                @Name NVARCHAR(MAX),
                @Salary INT,
                @PositionId INT
            AS
            BEGIN
                UPDATE Employees
                SET Name = @Name,
                    Salary = @Salary,
                    PositionId = @PositionId
                WHERE Id = @EmployeeId;
            END
        ");

            // Stored Procedure for Deleting Employee
            migrationBuilder.Sql(@"
            CREATE PROCEDURE DeleteEmployee
                @EmployeeId INT
            AS
            BEGIN
                DELETE FROM Employees
                WHERE Id = @EmployeeId;
            END
        ");

            // Stored Procedure for Listing Employees
            migrationBuilder.Sql(@"
            CREATE PROCEDURE GetEmployees
            AS
            BEGIN
                SELECT Id, Name, Salary, PositionId
                FROM Employees;
            END
        ");

            // Stored Procedure for Adding Position
            migrationBuilder.Sql(@"
            CREATE PROCEDURE AddPosition
                @JobTitle NVARCHAR(MAX),
                @SalaryBonus INT
            AS
            BEGIN
                INSERT INTO Positions (JobTitle, SalaryBonus)
                VALUES (@JobTitle, @SalaryBonus);
            END
        ");

            // Stored Procedure for Updating Position
            migrationBuilder.Sql(@"
            CREATE PROCEDURE UpdatePosition
                @PositionId INT,
                @JobTitle NVARCHAR(MAX),
                @SalaryBonus INT
            AS
            BEGIN
                UPDATE Positions
                SET JobTitle = @JobTitle,
                    SalaryBonus = @SalaryBonus
                WHERE Id = @PositionId;
            END
        ");

            // Stored Procedure for Deleting Position
            migrationBuilder.Sql(@"
            CREATE PROCEDURE DeletePosition
                @PositionId INT
            AS
            BEGIN
                DELETE FROM Positions
                WHERE Id = @PositionId;
            END
        ");

            // Stored Procedure for Listing Positions
            migrationBuilder.Sql(@"
            CREATE PROCEDURE GetPositions
            AS
            BEGIN
                SELECT Id, JobTitle, SalaryBonus
                FROM Positions;
            END
        ");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.Sql(@"
            DROP PROCEDURE AddEmployee;
            DROP PROCEDURE UpdateEmployee;
            DROP PROCEDURE DeleteEmployee;
            DROP PROCEDURE GetEmployee;

            DROP PROCEDURE AddPosition;
            DROP PROCEDURE UpdatePosition;
            DROP PROCEDURE DeletePosition;
            DROP PROCEDURE GetPosition;
        ");
        }
    }
}
