using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceWebApi.Migrations
{
    /// <inheritdoc />
    public partial class updateSeedDataOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DetailOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4, 4 });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt", "VerifiedAt" },
                values: new object[] { new DateTime(2024, 10, 5, 9, 44, 59, 404, DateTimeKind.Local).AddTicks(8825), "$2a$11$syyOCjjN40rTmNXl.iZpQ.WAgu/wjOfCG.VC19LBEwr6.Si9kFQK6", new DateTime(2024, 10, 15, 9, 44, 59, 404, DateTimeKind.Local).AddTicks(8839), new DateTime(2024, 10, 7, 9, 44, 59, 404, DateTimeKind.Local).AddTicks(8840) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 9, 25, 9, 44, 59, 535, DateTimeKind.Local).AddTicks(103), "$2a$11$4v2459dGwa.MTP.60UaJNOoLhfGsOcoKieO9.slM2omCw.yVb12KG", new DateTime(2024, 10, 15, 9, 44, 59, 535, DateTimeKind.Local).AddTicks(133) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt", "VerifiedAt" },
                values: new object[] { new DateTime(2024, 9, 30, 9, 44, 59, 661, DateTimeKind.Local).AddTicks(2462), "$2a$11$zsplIXhn3ub9UaD8Q.UByehC9yihVeH2StA09MTuIZvWAzYmj5Wk2", new DateTime(2024, 10, 15, 9, 44, 59, 661, DateTimeKind.Local).AddTicks(2471), new DateTime(2024, 10, 5, 9, 44, 59, 661, DateTimeKind.Local).AddTicks(2471) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 10, 9, 44, 59, 788, DateTimeKind.Local).AddTicks(1218), "$2a$11$f941tbwchfTBIFElrMYMw.uRT/bgwW2OQYrXuBbtDSMyG8WXrMZWG", new DateTime(2024, 10, 15, 9, 44, 59, 788, DateTimeKind.Local).AddTicks(1227) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt", "VerifiedAt" },
                values: new object[] { new DateTime(2024, 9, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(3571), "$2a$11$MzEi06NkZY/JtHILAXI6cuC5d/gfEktqUN3tPgkrzguO7lKeBnSz2", new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(3679), new DateTime(2024, 9, 20, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(3679) });

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 34, 59, 914, DateTimeKind.Local).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 24, 59, 914, DateTimeKind.Local).AddTicks(4483));

            migrationBuilder.InsertData(
                table: "DetailOrders",
                columns: new[] { "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[] { 4, 6, 6, 89.0m });

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 39, 59, 914, DateTimeKind.Local).AddTicks(7319));

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 41, 59, 914, DateTimeKind.Local).AddTicks(7322));

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 1, 8 },
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 32, 59, 914, DateTimeKind.Local).AddTicks(7325));

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 2, 5 },
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 34, 59, 914, DateTimeKind.Local).AddTicks(7324));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 34, 59, 914, DateTimeKind.Local).AddTicks(4539));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 35, 59, 914, DateTimeKind.Local).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 36, 59, 914, DateTimeKind.Local).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 37, 59, 914, DateTimeKind.Local).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 38, 59, 914, DateTimeKind.Local).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 39, 59, 914, DateTimeKind.Local).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 40, 59, 914, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 41, 59, 914, DateTimeKind.Local).AddTicks(4644));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 42, 59, 914, DateTimeKind.Local).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 14, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 13, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 10, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(6759), new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(6766) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 12, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(6769), new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(6770) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 5, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(6777), new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(6778) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 14, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(6781), new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(6782) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1, 1 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(7058), new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(7059) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1, 2 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(7061), new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(7061) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 1, 2, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(7063), new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(7063) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 2, 3, 3 },
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(7065), new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(7066) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4, 5 },
                columns: new[] { "Comment", "CreatedAt", "Score", "UpdatedAt" },
                values: new object[] { "Sản phẩm bị lỗi, không hài lòng.", new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(7068), 2, new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(7068) });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "CustomerId", "OrderId", "ProductId", "Comment", "CreatedAt", "Score", "UpdatedAt" },
                values: new object[] { 2, 4, 6, "Rất hài lòng với chất lượng và dịch vụ.", new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(7070), 5, new DateTime(2024, 10, 15, 9, 44, 59, 914, DateTimeKind.Local).AddTicks(7071) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DetailOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4, 6 });

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

            migrationBuilder.InsertData(
                table: "DetailOrders",
                columns: new[] { "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[] { 4, 4, 1, 3899.0m });

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
                keyValues: new object[] { 2, 4, 5 },
                columns: new[] { "Comment", "CreatedAt", "Score", "UpdatedAt" },
                values: new object[] { "Rất hài lòng với chất lượng và dịch vụ.", new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4709), 5, new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4710) });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "CustomerId", "OrderId", "ProductId", "Comment", "CreatedAt", "Score", "UpdatedAt" },
                values: new object[] { 2, 4, 4, "Sản phẩm bị lỗi, không hài lòng.", new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4707), 2, new DateTime(2024, 10, 2, 15, 19, 36, 782, DateTimeKind.Local).AddTicks(4707) });
        }
    }
}
