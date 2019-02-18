using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sup.Migrations
{
    public partial class Initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Events_EventsId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_AspNetUsers_UsersId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventUser",
                table: "EventUser");

            migrationBuilder.RenameTable(
                name: "EventUser",
                newName: "EventUsers");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_UsersId",
                table: "EventUsers",
                newName: "IX_EventUsers_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_EventsId",
                table: "EventUsers",
                newName: "IX_EventUsers_EventsId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Published",
                table: "Events",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Published",
                table: "AspNetUsers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventUsers",
                table: "EventUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUsers_Events_EventsId",
                table: "EventUsers",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUsers_AspNetUsers_UsersId",
                table: "EventUsers",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUsers_Events_EventsId",
                table: "EventUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUsers_AspNetUsers_UsersId",
                table: "EventUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventUsers",
                table: "EventUsers");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "EventUsers",
                newName: "EventUser");

            migrationBuilder.RenameIndex(
                name: "IX_EventUsers_UsersId",
                table: "EventUser",
                newName: "IX_EventUser_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUsers_EventsId",
                table: "EventUser",
                newName: "IX_EventUser_EventsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventUser",
                table: "EventUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Events_EventsId",
                table: "EventUser",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_AspNetUsers_UsersId",
                table: "EventUser",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
