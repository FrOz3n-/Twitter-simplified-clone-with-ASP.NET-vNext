using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace nexTwitter.Data.SqlServer.Migrations
{
    public partial class UpdatedRelations25MAY2015 : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateSequence(
                name: "DefaultSequence",
                type: "bigint",
                startWith: 1L,
                incrementBy: 10);
            migration.AlterColumn(
                name: "Id",
                table: "Tweet",
                type: "int",
                nullable: false);
            migration.AlterColumn(
                name: "Id",
                table: "User",
                type: "int",
                nullable: false);
            migration.AlterColumn(
                name: "Id",
                table: "UserWithFollower",
                type: "int",
                nullable: false);
            migration.AddColumn(
                name: "UserFollowerId",
                table: "UserWithFollower",
                type: "int",
                nullable: true);
            migration.AddForeignKey(
                name: "FK_UserWithFollower_User_UserFollowerId",
                table: "UserWithFollower",
                column: "UserFollowerId",
                referencedTable: "User",
                referencedColumn: "Id");
            migration.AddForeignKey(
                name: "FK_UserWithFollower_User_UserId",
                table: "UserWithFollower",
                column: "UserId",
                referencedTable: "User",
                referencedColumn: "Id");
            migration.AlterColumn(
                name: "Id",
                table: "UserWithTweet",
                type: "int",
                nullable: false);
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropForeignKey(name: "FK_UserWithFollower_User_UserFollowerId", table: "UserWithFollower");
            migration.DropForeignKey(name: "FK_UserWithFollower_User_UserId", table: "UserWithFollower");
            migration.DropSequence("DefaultSequence");
            migration.DropColumn(name: "UserFollowerId", table: "UserWithFollower");
            migration.AlterColumn(
                name: "Id",
                table: "Tweet",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:ValueGeneration", "Identity");
            migration.AlterColumn(
                name: "Id",
                table: "User",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:ValueGeneration", "Identity");
            migration.AlterColumn(
                name: "Id",
                table: "UserWithFollower",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:ValueGeneration", "Identity");
            migration.AlterColumn(
                name: "Id",
                table: "UserWithTweet",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:ValueGeneration", "Identity");
        }
    }
}
