using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Xperience.Data.Migrations
{
    public partial class removedId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ApplicationUser_ApplicationUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_ApplicationUser_ApplicationUserId",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_ApplicationUser_BlockedId",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ApplicationUser_ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionRequests_ApplicationUser_ApplicationUserId",
                table: "ConnectionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionRequests_ApplicationUser_ReceiverId",
                table: "ConnectionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_ApplicationUser_ApplicationUserId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_ApplicationUser_ConnectedId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectorLocations_ApplicationUser_ApplicationUserId",
                table: "ConnectorLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowedSites_ApplicationUser_ApplicationUserId",
                table: "FollowedSites");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowedUsers_ApplicationUser_ApplicationUserId",
                table: "FollowedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowedUsers_ApplicationUser_FollowerId",
                table: "FollowedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReactions_ApplicationUser_ApplicationUserId",
                table: "PostReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_ApplicationUser_ApplicationUserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_ApplicationUser_ApplicationUserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_ApplicationUser_RatedId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportedPosts_ApplicationUser_ApplicationUserId",
                table: "ReportedPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportedSites_ApplicationUser_ApplicationUserId",
                table: "ReportedSites");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportedUsers_ApplicationUser_ApplicationUserId",
                table: "ReportedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportedUsers_ApplicationUser_ReportedId",
                table: "ReportedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteVotes_ApplicationUser_ApplicationUserId",
                table: "SiteVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_ApplicationUser_ApplicationUserId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_ApplicationUser_TaggedId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInterests_ApplicationUser_ApplicationUserId",
                table: "UserInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguages_ApplicationUser_ApplicationUserId",
                table: "UserLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNationalities_ApplicationUser_ApplicationUserId",
                table: "UserNationalities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_ApplicationUser_ApplicationUserId",
                table: "UserReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_ApplicationUser_ReviewedId",
                table: "UserReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSiteReviews_ApplicationUser_ApplicationUserId",
                table: "UserSiteReviews");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ConnectorStatus",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReligionId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ReligionId",
                table: "AspNetUsers",
                column: "ReligionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Locations_LocationId",
                table: "AspNetUsers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Religions_ReligionId",
                table: "AspNetUsers",
                column: "ReligionId",
                principalTable: "Religions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_AspNetUsers_ApplicationUserId",
                table: "Blocks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_AspNetUsers_BlockedId",
                table: "Blocks",
                column: "BlockedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionRequests_AspNetUsers_ApplicationUserId",
                table: "ConnectionRequests",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionRequests_AspNetUsers_ReceiverId",
                table: "ConnectionRequests",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_AspNetUsers_ApplicationUserId",
                table: "Connections",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_AspNetUsers_ConnectedId",
                table: "Connections",
                column: "ConnectedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectorLocations_AspNetUsers_ApplicationUserId",
                table: "ConnectorLocations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedSites_AspNetUsers_ApplicationUserId",
                table: "FollowedSites",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedUsers_AspNetUsers_ApplicationUserId",
                table: "FollowedUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedUsers_AspNetUsers_FollowerId",
                table: "FollowedUsers",
                column: "FollowerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReactions_AspNetUsers_ApplicationUserId",
                table: "PostReactions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_ApplicationUserId",
                table: "Posts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_ApplicationUserId",
                table: "Ratings",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_RatedId",
                table: "Ratings",
                column: "RatedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportedPosts_AspNetUsers_ApplicationUserId",
                table: "ReportedPosts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportedSites_AspNetUsers_ApplicationUserId",
                table: "ReportedSites",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportedUsers_AspNetUsers_ApplicationUserId",
                table: "ReportedUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportedUsers_AspNetUsers_ReportedId",
                table: "ReportedUsers",
                column: "ReportedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteVotes_AspNetUsers_ApplicationUserId",
                table: "SiteVotes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_AspNetUsers_ApplicationUserId",
                table: "Tags",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_AspNetUsers_TaggedId",
                table: "Tags",
                column: "TaggedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterests_AspNetUsers_ApplicationUserId",
                table: "UserInterests",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguages_AspNetUsers_ApplicationUserId",
                table: "UserLanguages",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNationalities_AspNetUsers_ApplicationUserId",
                table: "UserNationalities",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_AspNetUsers_ApplicationUserId",
                table: "UserReviews",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_AspNetUsers_ReviewedId",
                table: "UserReviews",
                column: "ReviewedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSiteReviews_AspNetUsers_ApplicationUserId",
                table: "UserSiteReviews",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Locations_LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Religions_ReligionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_AspNetUsers_ApplicationUserId",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_AspNetUsers_BlockedId",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionRequests_AspNetUsers_ApplicationUserId",
                table: "ConnectionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionRequests_AspNetUsers_ReceiverId",
                table: "ConnectionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_AspNetUsers_ApplicationUserId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_AspNetUsers_ConnectedId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectorLocations_AspNetUsers_ApplicationUserId",
                table: "ConnectorLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowedSites_AspNetUsers_ApplicationUserId",
                table: "FollowedSites");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowedUsers_AspNetUsers_ApplicationUserId",
                table: "FollowedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowedUsers_AspNetUsers_FollowerId",
                table: "FollowedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReactions_AspNetUsers_ApplicationUserId",
                table: "PostReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_ApplicationUserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_ApplicationUserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_RatedId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportedPosts_AspNetUsers_ApplicationUserId",
                table: "ReportedPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportedSites_AspNetUsers_ApplicationUserId",
                table: "ReportedSites");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportedUsers_AspNetUsers_ApplicationUserId",
                table: "ReportedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportedUsers_AspNetUsers_ReportedId",
                table: "ReportedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteVotes_AspNetUsers_ApplicationUserId",
                table: "SiteVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_AspNetUsers_ApplicationUserId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_AspNetUsers_TaggedId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInterests_AspNetUsers_ApplicationUserId",
                table: "UserInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguages_AspNetUsers_ApplicationUserId",
                table: "UserLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNationalities_AspNetUsers_ApplicationUserId",
                table: "UserNationalities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_AspNetUsers_ApplicationUserId",
                table: "UserReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_AspNetUsers_ReviewedId",
                table: "UserReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSiteReviews_AspNetUsers_ApplicationUserId",
                table: "UserSiteReviews");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ReligionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Biography",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConnectorStatus",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReligionId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConnectorStatus = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReligionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Religions_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_LocationId",
                table: "ApplicationUser",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_ReligionId",
                table: "ApplicationUser",
                column: "ReligionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ApplicationUser_ApplicationUserId",
                table: "AspNetUsers",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_ApplicationUser_ApplicationUserId",
                table: "Blocks",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_ApplicationUser_BlockedId",
                table: "Blocks",
                column: "BlockedId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ApplicationUser_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionRequests_ApplicationUser_ApplicationUserId",
                table: "ConnectionRequests",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionRequests_ApplicationUser_ReceiverId",
                table: "ConnectionRequests",
                column: "ReceiverId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_ApplicationUser_ApplicationUserId",
                table: "Connections",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_ApplicationUser_ConnectedId",
                table: "Connections",
                column: "ConnectedId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectorLocations_ApplicationUser_ApplicationUserId",
                table: "ConnectorLocations",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedSites_ApplicationUser_ApplicationUserId",
                table: "FollowedSites",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedUsers_ApplicationUser_ApplicationUserId",
                table: "FollowedUsers",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedUsers_ApplicationUser_FollowerId",
                table: "FollowedUsers",
                column: "FollowerId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReactions_ApplicationUser_ApplicationUserId",
                table: "PostReactions",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_ApplicationUser_ApplicationUserId",
                table: "Posts",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_ApplicationUser_ApplicationUserId",
                table: "Ratings",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_ApplicationUser_RatedId",
                table: "Ratings",
                column: "RatedId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportedPosts_ApplicationUser_ApplicationUserId",
                table: "ReportedPosts",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportedSites_ApplicationUser_ApplicationUserId",
                table: "ReportedSites",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportedUsers_ApplicationUser_ApplicationUserId",
                table: "ReportedUsers",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportedUsers_ApplicationUser_ReportedId",
                table: "ReportedUsers",
                column: "ReportedId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteVotes_ApplicationUser_ApplicationUserId",
                table: "SiteVotes",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_ApplicationUser_ApplicationUserId",
                table: "Tags",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_ApplicationUser_TaggedId",
                table: "Tags",
                column: "TaggedId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterests_ApplicationUser_ApplicationUserId",
                table: "UserInterests",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguages_ApplicationUser_ApplicationUserId",
                table: "UserLanguages",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNationalities_ApplicationUser_ApplicationUserId",
                table: "UserNationalities",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_ApplicationUser_ApplicationUserId",
                table: "UserReviews",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_ApplicationUser_ReviewedId",
                table: "UserReviews",
                column: "ReviewedId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSiteReviews_ApplicationUser_ApplicationUserId",
                table: "UserSiteReviews",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
