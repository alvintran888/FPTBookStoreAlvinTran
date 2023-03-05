using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPTBookStore.Data.Migrations
{
    public partial class intialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A",
                column: "ConcurrencyStamp",
                value: "facfa931-247a-4490-9991-a411de547b77");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B",
                column: "ConcurrencyStamp",
                value: "3e63ac4d-527b-49cd-8b89-3811e0797ab4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "O",
                column: "ConcurrencyStamp",
                value: "8af4f6e9-0581-4b97-846d-68451b119c5e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2acd5c4d-18df-4ded-a2f7-536c59f16cc3", "AQAAAAEAACcQAAAAEMQxUKLYUTwNP72mlDB0SoUI0rpg62dWmEju1DJHpoz5vV+8ft3Q0r/yycTknp1vRg==", "730a343f-a07e-446a-8d92-47f439814650" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55b380db-782e-4172-bc01-2110f6744aa0", "AQAAAAEAACcQAAAAECPSdpRl6vaClkCu/6qE6qoy9RzpEw0mp7fZAYxUm5/HyS/wxkGuSt/N1dlDyRW7yw==", "17651d68-5f67-44fa-a690-2de2b46d886c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c98eea3-384d-418e-a1e6-66584b0c96e4", "AQAAAAEAACcQAAAAEM6hCsdXm/wBDkWkighO3Z5+3OPPyBchFsgwJEcHGvUetTGDCJTesAD3cTgjMUpvpw==", "56513d47-c8e7-4319-ae80-06d850407e8f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af56f230-4446-4a75-9ed0-cba201795d8c", "AQAAAAEAACcQAAAAEIiL9wcxTIS2vFMLJMg5oA+zKtaIKuIpo4GY2WgCbkt42Uh1ZnOqq82y6Hv2dWBoig==", "111b7aa1-28d0-409b-82ca-34e42c9c3984" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ade33727-44c0-4cac-9bc7-dfbb0e405825", "AQAAAAEAACcQAAAAENJu235DX3iKOr+HSEVGLhIptxtNdakKjn1LvYTU9B2MvmdWvhwEKaftga2Yj78jRQ==", "c8284144-4870-472b-b70c-643ff772e5cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9227e4ed-420f-4449-acad-0a3e03b8f55b", "AQAAAAEAACcQAAAAEMVZqMulcx/ikTHxKilM89Rvy1bsfF0/rpQOPanEfqAt8IH998n0GvzCXdz6CQENSw==", "db0e75b7-f238-427f-9ca5-016f9ad99b21" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A",
                column: "ConcurrencyStamp",
                value: "b928dda7-2bba-40a1-91df-85fa5febd18d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B",
                column: "ConcurrencyStamp",
                value: "ff7b6271-de4e-4c59-8c51-0e6730fdef56");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "O",
                column: "ConcurrencyStamp",
                value: "106feaee-7ece-4751-aa47-99d7adb8b7d9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8391a69-f91c-46d3-b575-42c992313c9e", "AQAAAAEAACcQAAAAEKTeRNsxckiBShT1p9RlQfy1cDmg9FB+o/08FxMGkD5wwmMkuvIoCrsaxTq5AKKwMw==", "56f48c51-f94d-4357-bd0b-2d70b9a5ed09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "567d7f3c-3151-4ed9-a6e5-51ec1cbbd0a8", "AQAAAAEAACcQAAAAEM+WtYRVgrwjnvoU1bWiKTR8fpZKVOYAQr0Sd8EypkZspcuAbeXy7qaUn65rdBLPFA==", "22f87684-7153-486a-ad02-b33123e30121" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70000aae-e48c-463b-859f-1e3e0cb85e34", "AQAAAAEAACcQAAAAECTO00EgR6dLIcL5kyw7o3HBjPnsLHxQUjqdsKFlzsT1gjs06OYXRNypJafYQEiL/g==", "66529560-67c6-4224-a23c-05742eb9c697" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e609817-9871-4742-9114-46140c3ab410", "AQAAAAEAACcQAAAAEB6BMzGk6lBmPvam4ej6xBFMDybYWV6WwvWHmntkeO8w6+zmVNq27BAJSTTmc+BxPA==", "aa4865eb-837c-4dee-8a1e-e34c7a4ff3ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1c4d75c-3629-4560-8ee4-50f2465804d4", "AQAAAAEAACcQAAAAENuszzHRy3Su3efmHBVL1Smk3p8rR8pYSyUHKVQWtMOPNWBtr5F6bhPSVId8eJRAWw==", "07ee1adc-e65d-427a-b0f5-6fe1a1d37b3f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b24f6da6-8699-43c8-a72b-735e6ecb971d", "AQAAAAEAACcQAAAAEJeqkjaMsYLnBgjtPvGl/7EnstKeVEiuDJJQ1HgNJpxtg6zyNyMYSx6SL1FT3v9wTQ==", "e9162e3f-99d0-4c43-aaff-8ad23c790a17" });
        }
    }
}
