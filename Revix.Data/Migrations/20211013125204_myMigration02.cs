using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Revix.Data.Migrations
{
    public partial class myMigration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Price",
                table: "CryptoListings",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<long>(
                name: "MarketCap",
                table: "CryptoListings",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AddColumn<long>(
                name: "CoinDataId",
                table: "CryptoListings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CryptoListings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CryptoListings",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CryptoListings",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CryptoListings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "CryptoListings",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoinDataId",
                table: "CryptoListings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CryptoListings");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CryptoListings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CryptoListings");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CryptoListings");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "CryptoListings");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "CryptoListings",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<double>(
                name: "MarketCap",
                table: "CryptoListings",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER");
        }
    }
}
