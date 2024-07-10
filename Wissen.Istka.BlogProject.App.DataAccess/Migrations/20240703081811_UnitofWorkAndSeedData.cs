using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wissen.Istka.BlogProject.App.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UnitofWorkAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#.Net Introduction", false, "C#.Net Core Programming" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entity Framework Core ile ORM Teknolojileri", false, "Entity Framework Core" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asp.Net Core Mvc ile Web Programlama", false, "Asp.Net Core MVC" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedDate", "IsDeleted", "PictureUrl", "Summary", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Visual Studio.Net ortamında C#.Net Core ile temel seviyeden (veri türleri, değişkenler, if-else, döngüler, diziler) ileri seviyeye (nesneye dayalı programlama-oop, collections, generic collections, interfaces, linq) eğitim programı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "~/themes/images/7.jpg", "Visual Studio.Net ortamında C#.Net Core ile temel seviyeden (veri türleri, değişkenler, if-else, döngüler, diziler) ileri seviyeye (nesneye dayalı programlama-oop, collections, generic collections, interfaces, linq) eğitim programı...", "C#.Net Core Introduction", 1 },
                    { 2, 2, "Visual Studio.Net ortamında Entity Framework Core ORM teknolojisini kullanarak veritabanı varlıklarının nesnel olarak yazılım tarafına aktarılması ve yönetilmesini gösteren eğitim programı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "~/themes/images/6.jpg", "Visual Studio.Net ortamında Entity Framework Core ORM teknolojisini kullanarak veritabanı varlıklarının nesnel olarak yazılım tarafına aktarılması ve yönetilmesi...", "Entity Framework Core ile ORM", 2 },
                    { 3, 3, "Visual Studio.Net ortamında Asp.Net Core Mvc ile temel düzeyden ileri seviyeye web programlama eğitimi, Asp.Net Restfull APIs", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "~/themes/images/2.jpg", "Visual Studio.Net ortamında Asp.Net Core Mvc ile temel düzeyden ileri seviyeye web programlama eğitimi, Asp.Net Restfull APIs", "Asp.Net Core Mvc ile Web Programlama", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
