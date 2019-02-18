using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sup.Migrations
{
    public partial class UpdateAnnouncementFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementUsers_Announcements_AnnouncementsId",
                table: "AnnouncementUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementUsers_AspNetUsers_UsersId",
                table: "AnnouncementUsers");

            migrationBuilder.DropIndex(
                name: "IX_AnnouncementUsers_AnnouncementsId",
                table: "AnnouncementUsers");

            migrationBuilder.DropIndex(
                name: "IX_AnnouncementUsers_UsersId",
                table: "AnnouncementUsers");

            migrationBuilder.DropColumn(
                name: "AnnouncementsId",
                table: "AnnouncementUsers");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "AnnouncementUsers");

            migrationBuilder.AddColumn<int>(
                name: "AnnouncementId",
                table: "AnnouncementUsers",
                type: "int4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AnnouncementUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecieverId",
                table: "Announcements",
                type: "text",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementUsers_AnnouncementId",
                table: "AnnouncementUsers",
                column: "AnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementUsers_UserId",
                table: "AnnouncementUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementUsers_Announcements_AnnouncementId",
                table: "AnnouncementUsers",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementUsers_AspNetUsers_UserId",
                table: "AnnouncementUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementUsers_Announcements_AnnouncementId",
                table: "AnnouncementUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnouncementUsers_AspNetUsers_UserId",
                table: "AnnouncementUsers");

            migrationBuilder.DropIndex(
                name: "IX_AnnouncementUsers_AnnouncementId",
                table: "AnnouncementUsers");

            migrationBuilder.DropIndex(
                name: "IX_AnnouncementUsers_UserId",
                table: "AnnouncementUsers");

            migrationBuilder.DropColumn(
                name: "AnnouncementId",
                table: "AnnouncementUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AnnouncementUsers");

            migrationBuilder.AddColumn<int>(
                name: "AnnouncementsId",
                table: "AnnouncementUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "AnnouncementUsers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecieverId",
                table: "Announcements",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementUsers_AnnouncementsId",
                table: "AnnouncementUsers",
                column: "AnnouncementsId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementUsers_UsersId",
                table: "AnnouncementUsers",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementUsers_Announcements_AnnouncementsId",
                table: "AnnouncementUsers",
                column: "AnnouncementsId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementUsers_AspNetUsers_UsersId",
                table: "AnnouncementUsers",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
