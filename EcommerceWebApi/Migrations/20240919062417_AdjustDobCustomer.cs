using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AdjustDobCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "Dob",
                table: "Customers",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Shop");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_Email",
                table: "Accounts");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Dob",
                table: "Customers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt", "VerifiedAt" },
                values: new object[] { new DateTime(2024, 9, 7, 16, 8, 42, 949, DateTimeKind.Local).AddTicks(6713), "$2a$11$NjJom1FqpljTknRVHFCv9./sUqUZgCpdfpRAn2TpIVLSwBBKw3BqO", new DateTime(2024, 9, 17, 16, 8, 42, 949, DateTimeKind.Local).AddTicks(6722), new DateTime(2024, 9, 9, 16, 8, 42, 949, DateTimeKind.Local).AddTicks(6723) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 28, 16, 8, 43, 84, DateTimeKind.Local).AddTicks(4936), "$2a$11$5yceO/ulTBfsUKYJQuFjROfZd8ycqbrCDniaCZYWzOBdyrMDYq6bq", new DateTime(2024, 9, 17, 16, 8, 43, 84, DateTimeKind.Local).AddTicks(4977) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt", "VerifiedAt" },
                values: new object[] { new DateTime(2024, 9, 2, 16, 8, 43, 210, DateTimeKind.Local).AddTicks(3593), "$2a$11$8skXuGXLKMrbLMcqGw8E4eFPjhNu56GeTdf7485/.Tyu5sW2a/pd2", new DateTime(2024, 9, 17, 16, 8, 43, 210, DateTimeKind.Local).AddTicks(3601), new DateTime(2024, 9, 7, 16, 8, 43, 210, DateTimeKind.Local).AddTicks(3602) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 12, 16, 8, 43, 336, DateTimeKind.Local).AddTicks(4114), "$2a$11$ts5nMXEqiDJqmMrE.RY29ebzGW8XCNPDpOiyliUPAbFkPreX0TB4S", new DateTime(2024, 9, 17, 16, 8, 43, 336, DateTimeKind.Local).AddTicks(4122) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt", "VerifiedAt" },
                values: new object[] { new DateTime(2024, 8, 18, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(1246), "$2a$11$AUsO4PdBIgHAhhVdqxGCcOk5/aNWTn8l6CjT6qiA1J7xzkCZvxAyG", new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(1256), new DateTime(2024, 8, 23, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(1258) });

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 15, 58, 43, 468, DateTimeKind.Local).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 15, 48, 43, 468, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 16, 3, 43, 468, DateTimeKind.Local).AddTicks(3722));

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 16, 5, 43, 468, DateTimeKind.Local).AddTicks(3726));

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 1, 8 },
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 15, 56, 43, 468, DateTimeKind.Local).AddTicks(3729));

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 2, 5 },
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 15, 58, 43, 468, DateTimeKind.Local).AddTicks(3727));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 15, 58, 43, 468, DateTimeKind.Local).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 15, 59, 43, 468, DateTimeKind.Local).AddTicks(2267));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 16, 0, 43, 468, DateTimeKind.Local).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 16, 1, 43, 468, DateTimeKind.Local).AddTicks(2309));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 16, 2, 43, 468, DateTimeKind.Local).AddTicks(2313));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 16, 3, 43, 468, DateTimeKind.Local).AddTicks(2315));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 16, 4, 43, 468, DateTimeKind.Local).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 16, 5, 43, 468, DateTimeKind.Local).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 16, 6, 43, 468, DateTimeKind.Local).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2768));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 16, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 15, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 12, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2982), new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2983) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 14, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2986), new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2986) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 7, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2991), new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2991) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 16, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2994), new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2994) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3416), new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3417) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3419), new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3419) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 1, 2, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3421), new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3422) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 2, 3, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3424), new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3424) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4, 4 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3426), new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3427) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4, 5 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3429), new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3429) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Seller");
        }
    }
}
