using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace nexTwitter.Data.SqlServer.Migrations
{
    public partial class FirstMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "User",
                columns: table => new
                {
                    Country = table.Column(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column(type: "datetime2", nullable: false),
                    Email = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    IsActive = table.Column(type: "bit", nullable: false),
                    IsDeleted = table.Column(type: "bit", nullable: false),
                    LastModified = table.Column(type: "datetime2", nullable: false),
                    Password = table.Column(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column(type: "nvarchar(max)", nullable: true),
                    Username = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
            migration.CreateTable(
                name: "UserWithFollower",
                columns: table => new
                {
                    CreatedBy = table.Column(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column(type: "datetime2", nullable: false),
                    FollowerId = table.Column(type: "int", nullable: false),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    IsActive = table.Column(type: "bit", nullable: false),
                    IsDeleted = table.Column(type: "bit", nullable: false),
                    LastModified = table.Column(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWithFollower", x => x.Id);
                });
            migration.CreateTable(
                name: "Tweet",
                columns: table => new
                {
                    CreatedBy = table.Column(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column(type: "datetime2", nullable: false),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    IsActive = table.Column(type: "bit", nullable: false),
                    IsDeleted = table.Column(type: "bit", nullable: false),
                    LastModified = table.Column(type: "datetime2", nullable: false),
                    Text = table.Column(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tweet_User_UserId",
                        columns: x => x.UserId,
                        referencedTable: "User",
                        referencedColumn: "Id");
                });
            migration.CreateTable(
                name: "UserWithTweet",
                columns: table => new
                {
                    CreatedBy = table.Column(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column(type: "datetime2", nullable: false),
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    IsActive = table.Column(type: "bit", nullable: false),
                    IsDeleted = table.Column(type: "bit", nullable: false),
                    LastModified = table.Column(type: "datetime2", nullable: false),
                    TweetId = table.Column(type: "int", nullable: false),
                    UpdatedBy = table.Column(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWithTweet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWithTweet_Tweet_TweetId",
                        columns: x => x.TweetId,
                        referencedTable: "Tweet",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserWithTweet_User_UserId",
                        columns: x => x.UserId,
                        referencedTable: "User",
                        referencedColumn: "Id");
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Tweet");
            migration.DropTable("User");
            migration.DropTable("UserWithFollower");
            migration.DropTable("UserWithTweet");
        }
    }
}
