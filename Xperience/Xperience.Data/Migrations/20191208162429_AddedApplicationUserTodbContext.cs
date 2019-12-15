using Microsoft.EntityFrameworkCore.Migrations;

namespace Xperience.Data.Migrations
{
    public partial class AddedApplicationUserTodbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_AspNetUsers_Id",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Locations_LocationId",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Religions_ReligionId",
                table: "ApplicationUser");

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
                name: "FK_Comments_Posts_PostId",
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
                name: "FK_ConnectorLocations_Locations_LocationId",
                table: "ConnectorLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowedSites_ApplicationUser_ApplicationUserId",
                table: "FollowedSites");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowedSites_Sites_SiteId",
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
                name: "FK_Posts_Sites_SiteId",
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
                name: "FK_ReportedPosts_Posts_PostId",
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
                name: "FK_Tags_Posts_PostId",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "ApplicationUsers");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_ReligionId",
                table: "ApplicationUsers",
                newName: "IX_ApplicationUsers_ReligionId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_LocationId",
                table: "ApplicationUsers",
                newName: "IX_ApplicationUsers_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUsers",
                table: "ApplicationUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_AspNetUsers_Id",
                table: "ApplicationUsers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Locations_LocationId",
                table: "ApplicationUsers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Religions_ReligionId",
                table: "ApplicationUsers",
                column: "ReligionId",
                principalTable: "Religions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ApplicationUsers_ApplicationUserId",
                table: "AspNetUsers",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_ApplicationUsers_ApplicationUserId",
                table: "Blocks",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_ApplicationUsers_BlockedId",
                table: "Blocks",
                column: "BlockedId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ApplicationUsers_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionRequests_ApplicationUsers_ApplicationUserId",
                table: "ConnectionRequests",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionRequests_ApplicationUsers_ReceiverId",
                table: "ConnectionRequests",
                column: "ReceiverId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_ApplicationUsers_ApplicationUserId",
                table: "Connections",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_ApplicationUsers_ConnectedId",
                table: "Connections",
                column: "ConnectedId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectorLocations_ApplicationUsers_ApplicationUserId",
                table: "ConnectorLocations",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectorLocations_Locations_LocationId",
                table: "ConnectorLocations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedSites_ApplicationUsers_ApplicationUserId",
                table: "FollowedSites",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedSites_Sites_SiteId",
                table: "FollowedSites",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedUsers_ApplicationUsers_ApplicationUserId",
                table: "FollowedUsers",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedUsers_ApplicationUsers_FollowerId",
                table: "FollowedUsers",
                column: "FollowerId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReactions_ApplicationUsers_ApplicationUserId",
                table: "PostReactions",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_ApplicationUsers_ApplicationUserId",
                table: "Posts",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Sites_SiteId",
                table: "Posts",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_ApplicationUsers_ApplicationUserId",
                table: "Ratings",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_ApplicationUsers_RatedId",
                table: "Ratings",
                column: "RatedId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportedPosts_ApplicationUsers_ApplicationUserId",
                table: "ReportedPosts",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportedPosts_Posts_PostId",
                table: "ReportedPosts",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportedSites_ApplicationUsers_ApplicationUserId",
                table: "ReportedSites",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportedUsers_ApplicationUsers_ApplicationUserId",
                table: "ReportedUsers",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportedUsers_ApplicationUsers_ReportedId",
                table: "ReportedUsers",
                column: "ReportedId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteVotes_ApplicationUsers_ApplicationUserId",
                table: "SiteVotes",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_ApplicationUsers_ApplicationUserId",
                table: "Tags",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Posts_PostId",
                table: "Tags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_ApplicationUsers_TaggedId",
                table: "Tags",
                column: "TaggedId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterests_ApplicationUsers_ApplicationUserId",
                table: "UserInterests",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguages_ApplicationUsers_ApplicationUserId",
                table: "UserLanguages",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNationalities_ApplicationUsers_ApplicationUserId",
                table: "UserNationalities",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_ApplicationUsers_ApplicationUserId",
                table: "UserReviews",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_ApplicationUsers_ReviewedId",
                table: "UserReviews",
                column: "ReviewedId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSiteReviews_ApplicationUsers_ApplicationUserId",
                table: "UserSiteReviews",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_AspNetUsers_Id",
                table: "ApplicationUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Locations_LocationId",
                table: "ApplicationUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Religions_ReligionId",
                table: "ApplicationUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ApplicationUsers_ApplicationUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_ApplicationUsers_ApplicationUserId",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_ApplicationUsers_BlockedId",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ApplicationUsers_ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionRequests_ApplicationUsers_ApplicationUserId",
                table: "ConnectionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionRequests_ApplicationUsers_ReceiverId",
                table: "ConnectionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_ApplicationUsers_ApplicationUserId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_Connections_ApplicationUsers_ConnectedId",
                table: "Connections");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectorLocations_ApplicationUsers_ApplicationUserId",
                table: "ConnectorLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectorLocations_Locations_LocationId",
                table: "ConnectorLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowedSites_ApplicationUsers_ApplicationUserId",
                table: "FollowedSites");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowedSites_Sites_SiteId",
                table: "FollowedSites");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowedUsers_ApplicationUsers_ApplicationUserId",
                table: "FollowedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowedUsers_ApplicationUsers_FollowerId",
                table: "FollowedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReactions_ApplicationUsers_ApplicationUserId",
                table: "PostReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_ApplicationUsers_ApplicationUserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Sites_SiteId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_ApplicationUsers_ApplicationUserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_ApplicationUsers_RatedId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportedPosts_ApplicationUsers_ApplicationUserId",
                table: "ReportedPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportedPosts_Posts_PostId",
                table: "ReportedPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportedSites_ApplicationUsers_ApplicationUserId",
                table: "ReportedSites");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportedUsers_ApplicationUsers_ApplicationUserId",
                table: "ReportedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportedUsers_ApplicationUsers_ReportedId",
                table: "ReportedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteVotes_ApplicationUsers_ApplicationUserId",
                table: "SiteVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_ApplicationUsers_ApplicationUserId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Posts_PostId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_ApplicationUsers_TaggedId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInterests_ApplicationUsers_ApplicationUserId",
                table: "UserInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguages_ApplicationUsers_ApplicationUserId",
                table: "UserLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNationalities_ApplicationUsers_ApplicationUserId",
                table: "UserNationalities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_ApplicationUsers_ApplicationUserId",
                table: "UserReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_ApplicationUsers_ReviewedId",
                table: "UserReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSiteReviews_ApplicationUsers_ApplicationUserId",
                table: "UserSiteReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUsers",
                table: "ApplicationUsers");

            migrationBuilder.RenameTable(
                name: "ApplicationUsers",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsers_ReligionId",
                table: "ApplicationUser",
                newName: "IX_ApplicationUser_ReligionId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsers_LocationId",
                table: "ApplicationUser",
                newName: "IX_ApplicationUser_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_AspNetUsers_Id",
                table: "ApplicationUser",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Locations_LocationId",
                table: "ApplicationUser",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Religions_ReligionId",
                table: "ApplicationUser",
                column: "ReligionId",
                principalTable: "Religions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_ConnectorLocations_Locations_LocationId",
                table: "ConnectorLocations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedSites_ApplicationUser_ApplicationUserId",
                table: "FollowedSites",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedSites_Sites_SiteId",
                table: "FollowedSites",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Posts_Sites_SiteId",
                table: "Posts",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_ReportedPosts_Posts_PostId",
                table: "ReportedPosts",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Tags_Posts_PostId",
                table: "Tags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
