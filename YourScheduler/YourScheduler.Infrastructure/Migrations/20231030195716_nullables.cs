using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourScheduler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AM0GC8APd/YN0TfyDhvCdzO/bVr+YT1JDFKr2mvBm3pIL0UQGliA29UbD4Dc7rXm9Q==", "GYJAQ3CGNKZV3MLKYU4W3OE3EMBM4S2A" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AE+d+8r6vaBRs54hzzM3hWutcXasyR6BEV7f3TnWFd4fD0rd4i387f/AOkOqEeiYEQ==", "TZH6KC5MQFVMYO6CJLJCKHCBUME6ZL2L" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "ALyyWH2pyabIMNeIFdro1Fk+1JpU78ld9MUZNFElE0CNHf7rhynnhByHCk0DhPVbRQ==", "JIIALFRLZ246AYBNV23LAX7OAX7EYNMW" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "ANvQcMG51mqVFOss0WbFLpjd4n4bU31LjKhz5+nLK8Exq2k6sr5qEAx8kpIwqO8gzA==", "BLCXDMVL3TVF7Y6QUQ7D276KAM5DNNFD" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "ACI7imZpFp066nnKJg5pWRGMck2iRIfv8njTbbDGSjrVXG4UNGRegz1pgnbd2TWjFA==", "7VFYBGF2JDBWAE2XLU26MAN7UMLIW77Z" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AOGEA6dOTTEKEPZoUS7uiqem4IlfeEJxeYvjkWcE9dLMyNwD0++4ZbX440vYR/tlgQ==", "K6LK7DMAIJSPVJD335UHGD757DORBQC5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AMds+hn0dIXNV56JXcpFBMbvdn3/bYEr4581+58jL7Qw7eecwGMUvcX3EP1E4FnJWw==", "7O2RJ7MGEQI6YTM7FBLXFSUKPUCZGUF6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AP9v1Fc8p6IpUAlPqKRZyCWvxUmGTk642F2VBkJmozkU6uj36ZlM2HN4NpwGqPFolg==", "2VOAH5QVTMNKT4256N4FJXVCNEF5AK4N" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "ADwtRaIywLDAnQm92MdR0mqmyim4qVl4N3clYw+8egFnM9Uf5uTB2iocPH137uyPFQ==", "2PY7ZR64ZM45CWCTHXZYLNXK754MFH6T" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AGkF+JJIx7pbxQ9GboxMFP3f4DcGFD8ZapV3syPxiLevKSXeutWi3a4kMMW1M7+NeQ==", "7TVRBHMFRRRS44MYPTSMQQV5Y33CPOFR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AKZs3q9tqekgCDmI5dZ5OGEE4PKd4HxBfJ7xa7cjgBhluREgc5eVKNOUZeRXHI2wSQ==", "KPRORUKLNTN6S3AMKDTPWW4SMN6CRZPW" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "APhiQeJOt3Sm4WWGIAGKi7XjA8HbYxkKCLBCFUBcPA3DGfpcK27vMqLrUTOeleTPxw==", "HTOQUZTHA6X55TQJNFGDESE2MQ7Q5QDC" });
        }
    }
}
