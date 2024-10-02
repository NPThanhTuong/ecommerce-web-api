using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addIllustrationToSaleEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Illustration",
                table: "SaleEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt", "VerifiedAt" },
                values: new object[] { new DateTime(2024, 9, 22, 15, 19, 36, 276, DateTimeKind.Local).AddTicks(7567), "$2a$11$zNDfovrHzLPw.Tmz0hUgHuzfshGFsyjZcZLC.dGw7oj4WKx.Zd4B6", new DateTime(2024, 10, 2, 15, 19, 36, 276, DateTimeKind.Local).AddTicks(7597), new DateTime(2024, 9, 24, 15, 19, 36, 276, DateTimeKind.Local).AddTicks(7599) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 12, 15, 19, 36, 405, DateTimeKind.Local).AddTicks(203), "$2a$11$SZeVeRZjVtOyBcZyuXHbiuS5RAb7XYfMLqQPJ7yopJG834DaGRhne", new DateTime(2024, 10, 2, 15, 19, 36, 405, DateTimeKind.Local).AddTicks(232) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt", "VerifiedAt" },
                values: new object[] { new DateTime(2024, 9, 17, 15, 19, 36, 530, DateTimeKind.Local).AddTicks(8242), "$2a$11$Cgx8R87e.a6J7CzFwpwe6uC.nC9BUZcAC1RY7XkcwuY67GtVCPNpW", new DateTime(2024, 10, 2, 15, 19, 36, 530, DateTimeKind.Local).AddTicks(8250), new DateTime(2024, 9, 22, 15, 19, 36, 530, DateTimeKind.Local).AddTicks(8251) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 27, 15, 19, 36, 656, DateTimeKind.Local).AddTicks(1045), "$2a$11$pYfrjXML7EP3tXJxjkJ4eewiAW/00NujR/Rjg.kQPIcUmRc.2.L6u", new DateTime(2024, 10, 2, 15, 19, 36, 656, DateTimeKind.Local).AddTicks(1055) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt", "VerifiedAt" },
                values: new object[] { new DateTime(2024, 9, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(3098), "$2a$11$ucNgjpUBo8MI7/OqMsaUROXJKzVW/PhHWShFiSZr/uWKlhBbVmnqm", new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(3168), new DateTime(2024, 9, 7, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(3168) });

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 9, 36, 782, DateTimeKind.Local).AddTicks(3811));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 14, 59, 36, 782, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 14, 36, 782, DateTimeKind.Local).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 16, 36, 782, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 1, 8 },
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 7, 36, 782, DateTimeKind.Local).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 2, 5 },
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 9, 36, 782, DateTimeKind.Local).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 9, 36, 782, DateTimeKind.Local).AddTicks(3862));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 10, 36, 782, DateTimeKind.Local).AddTicks(3864));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 11, 36, 782, DateTimeKind.Local).AddTicks(3865));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 12, 36, 782, DateTimeKind.Local).AddTicks(3867));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 13, 36, 782, DateTimeKind.Local).AddTicks(3967));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 14, 36, 782, DateTimeKind.Local).AddTicks(3975));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 15, 36, 782, DateTimeKind.Local).AddTicks(3977));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 16, 36, 782, DateTimeKind.Local).AddTicks(3978));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 17, 36, 782, DateTimeKind.Local).AddTicks(3980));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4291));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4293));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 1, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4295));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 30, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4297));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 27, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4448), new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4449) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 29, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4452), new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4453) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 22, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4457), new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4457) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 1, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4460), new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4460) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4697), new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4697) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4700), new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4700) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 1, 2, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4702), new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4702) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 2, 3, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4704), new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4705) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4707), new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4707) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4, 5 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4709), new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4710) });

            migrationBuilder.UpdateData(
                table: "SaleEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Illustration",
                value: "image1.jpg");

            migrationBuilder.UpdateData(
                table: "SaleEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Illustration",
                value: "image2.jpg");

            migrationBuilder.UpdateData(
                table: "SaleEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Illustration",
                value: "image3.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Illustration",
                table: "SaleEvents");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt", "VerifiedAt" },
                values: new object[] { new DateTime(2024, 9, 9, 13, 24, 16, 607, DateTimeKind.Local).AddTicks(9), "$2a$11$69iM7ZOm/L8FawMjdrJlfudilA.72jNQl9s60GbpzNdZOiaoqi7qa", new DateTime(2024, 9, 19, 13, 24, 16, 607, DateTimeKind.Local).AddTicks(20), new DateTime(2024, 9, 11, 13, 24, 16, 607, DateTimeKind.Local).AddTicks(21) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 30, 13, 24, 16, 734, DateTimeKind.Local).AddTicks(7517), "$2a$11$ajcpiRK/BmqL3ESWT3vEUOtw2s7UDi4RQL.y.bggw8DqVNRd19rwK", new DateTime(2024, 9, 19, 13, 24, 16, 734, DateTimeKind.Local).AddTicks(7530) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt", "VerifiedAt" },
                values: new object[] { new DateTime(2024, 9, 4, 13, 24, 16, 869, DateTimeKind.Local).AddTicks(5692), "$2a$11$znppotZP7tojp6BxS06R1ujlFYG.YGms6a.mBKFS7iK0K/muscm5e", new DateTime(2024, 9, 19, 13, 24, 16, 869, DateTimeKind.Local).AddTicks(5723), new DateTime(2024, 9, 9, 13, 24, 16, 869, DateTimeKind.Local).AddTicks(5724) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 14, 13, 24, 16, 995, DateTimeKind.Local).AddTicks(2389), "$2a$11$FY3Okv0xg.duJxIDRl87IevEUsw4tilY3xUYnt5MzntJLp0GbUTeC", new DateTime(2024, 9, 19, 13, 24, 16, 995, DateTimeKind.Local).AddTicks(2410) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt", "VerifiedAt" },
                values: new object[] { new DateTime(2024, 8, 20, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(1992), "$2a$11$QDWiIvr1c5NZJnEthqhkPOkCD7MTwKLf0/YYf8E5cJ/NVPHSuO6QW", new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(2005), new DateTime(2024, 8, 25, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(2006) });

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 14, 17, 121, DateTimeKind.Local).AddTicks(2760));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 4, 17, 121, DateTimeKind.Local).AddTicks(2763));

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 19, 17, 121, DateTimeKind.Local).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 21, 17, 121, DateTimeKind.Local).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 1, 8 },
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 12, 17, 121, DateTimeKind.Local).AddTicks(4071));

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 2, 5 },
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 14, 17, 121, DateTimeKind.Local).AddTicks(4069));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 14, 17, 121, DateTimeKind.Local).AddTicks(2820));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 15, 17, 121, DateTimeKind.Local).AddTicks(2822));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 16, 17, 121, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 17, 17, 121, DateTimeKind.Local).AddTicks(2856));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 18, 17, 121, DateTimeKind.Local).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 19, 17, 121, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 20, 17, 121, DateTimeKind.Local).AddTicks(2861));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 21, 17, 121, DateTimeKind.Local).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 22, 17, 121, DateTimeKind.Local).AddTicks(2867));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3216));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 18, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3219));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3222));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 14, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3457), new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3458) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3461), new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3462) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 9, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3466), new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3466) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 18, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3469), new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3469) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3791), new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3791) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3793), new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3794) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 1, 2, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3796), new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3796) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 2, 3, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3798), new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3799) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3801), new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3801) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4, 5 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3803), new DateTime(2024, 9, 19, 13, 24, 17, 121, DateTimeKind.Local).AddTicks(3804) });
        }
    }
}
