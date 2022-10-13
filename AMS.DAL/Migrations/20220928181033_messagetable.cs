﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS.DAL.Migrations
{
    public partial class messagetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    ReceiverId = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewMessages_Writer_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Writer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewMessages_Writer_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Writer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewMessages_ReceiverId",
                table: "NewMessages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_NewMessages_SenderId",
                table: "NewMessages",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewMessages");
        }
    }
}
