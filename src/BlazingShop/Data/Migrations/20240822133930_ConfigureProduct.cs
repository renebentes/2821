using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingShop.Data.Migrations;

/// <inheritdoc />
public partial class ConfigureProduct : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<decimal>(
            name: "Price",
            table: "Product",
            type: "MONEY",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "TEXT"
        );

        migrationBuilder.AlterColumn<string>(
            name: "Image",
            table: "Product",
            type: "TEXT",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "TEXT"
        );

        migrationBuilder.AlterColumn<string>(
            name: "Description",
            table: "Product",
            type: "TEXT",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "TEXT"
        );
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<decimal>(
            name: "Price",
            table: "Product",
            type: "TEXT",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "MONEY"
        );

        migrationBuilder.AlterColumn<string>(
            name: "Image",
            table: "Product",
            type: "TEXT",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "TEXT",
            oldNullable: true
        );

        migrationBuilder.AlterColumn<string>(
            name: "Description",
            table: "Product",
            type: "TEXT",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "TEXT",
            oldNullable: true
        );
    }
}
