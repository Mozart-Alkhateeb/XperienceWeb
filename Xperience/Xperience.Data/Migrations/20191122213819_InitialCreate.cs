using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Xperience.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hashtags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashtags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reaction_Icons",
                columns: table => new
                {
                    Reaction_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reaction_Icons", x => x.Reaction_id);
                });

            migrationBuilder.CreateTable(
                name: "Religions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Category_id = table.Column<int>(nullable: false),
                    Location_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sites_Categories_Category_id",
                        column: x => x.Category_id,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sites_Locations_Location_id",
                        column: x => x.Location_id,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Biography = table.Column<string>(nullable: true),
                    Phone_number = table.Column<string>(nullable: true),
                    Profile_pic = table.Column<string>(nullable: true),
                    Connector_status = table.Column<bool>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    Location_id = table.Column<int>(nullable: false),
                    Religion_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Locations_Location_id",
                        column: x => x.Location_id,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Religions_Religion_id",
                        column: x => x.Religion_id,
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Blocker_id = table.Column<int>(nullable: false),
                    Blocked_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => new { x.Blocked_id, x.Blocker_id });
                    table.ForeignKey(
                        name: "FK_Blocks_Users_Blocked_id",
                        column: x => x.Blocked_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blocks_Users_Blocker_id",
                        column: x => x.Blocker_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Connection_Requests",
                columns: table => new
                {
                    Connector_id = table.Column<int>(nullable: false),
                    Connected_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection_Requests", x => new { x.Connected_id, x.Connector_id });
                    table.ForeignKey(
                        name: "FK_Connection_Requests_Users_Connected_id",
                        column: x => x.Connected_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Connection_Requests_Users_Connector_id",
                        column: x => x.Connector_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    Connector_id = table.Column<int>(nullable: false),
                    Connected_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => new { x.Connector_id, x.Connected_id });
                    table.UniqueConstraint("AK_Connections_Connected_id_Connector_id", x => new { x.Connected_id, x.Connector_id });
                    table.ForeignKey(
                        name: "FK_Connections_Users_Connected_id",
                        column: x => x.Connected_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Connections_Users_Connector_id",
                        column: x => x.Connector_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Connector_Sites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Location_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connector_Sites", x => new { x.Id, x.Location_id });
                    table.ForeignKey(
                        name: "FK_Connector_Sites_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Connector_Sites_Locations_Location_id",
                        column: x => x.Location_id,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConnectorInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Info = table.Column<string>(nullable: false),
                    id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectorInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConnectorInfos_Users_id",
                        column: x => x.id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConnectorInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Category_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectorInterests", x => new { x.Id, x.Category_id });
                    table.UniqueConstraint("AK_ConnectorInterests_Category_id_Id", x => new { x.Category_id, x.Id });
                    table.ForeignKey(
                        name: "FK_ConnectorInterests_Categories_Category_id",
                        column: x => x.Category_id,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConnectorInterests_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FollowedSites",
                columns: table => new
                {
                    Follower_id = table.Column<int>(nullable: false),
                    Followed_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowedSites", x => new { x.Follower_id, x.Followed_id });
                    table.UniqueConstraint("AK_FollowedSites_Followed_id_Follower_id", x => new { x.Followed_id, x.Follower_id });
                    table.ForeignKey(
                        name: "FK_FollowedSites_Sites_Followed_id",
                        column: x => x.Followed_id,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollowedSites_Users_Follower_id",
                        column: x => x.Follower_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FollowedUsers",
                columns: table => new
                {
                    Follower_id = table.Column<int>(nullable: false),
                    Followed_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowedUsers", x => new { x.Followed_id, x.Follower_id });
                    table.ForeignKey(
                        name: "FK_FollowedUsers_Users_Followed_id",
                        column: x => x.Followed_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollowedUsers_Users_Follower_id",
                        column: x => x.Follower_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    User_id = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.User_id);
                    table.ForeignKey(
                        name: "FK_Languages_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    User_id = table.Column<int>(nullable: false),
                    Nationality = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.User_id);
                    table.ForeignKey(
                        name: "FK_Nationalities_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(nullable: false),
                    Post = table.Column<string>(nullable: false),
                    Caption = table.Column<string>(nullable: true),
                    Site_id = table.Column<int>(nullable: false),
                    Hashtag_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Hashtags_Hashtag_id",
                        column: x => x.Hashtag_id,
                        principalTable: "Hashtags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Sites_Site_id",
                        column: x => x.Site_id,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Rater_id = table.Column<int>(nullable: false),
                    Rated_id = table.Column<int>(nullable: false),
                    Rating = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => new { x.Rater_id, x.Rated_id });
                    table.UniqueConstraint("AK_Ratings_Rated_id_Rater_id", x => new { x.Rated_id, x.Rater_id });
                    table.ForeignKey(
                        name: "FK_Ratings_Users_Rated_id",
                        column: x => x.Rated_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_Rater_id",
                        column: x => x.Rater_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reported_Sites",
                columns: table => new
                {
                    Reported_id = table.Column<int>(nullable: false),
                    Reporter_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reported_Sites", x => new { x.Reporter_id, x.Reported_id });
                    table.UniqueConstraint("AK_Reported_Sites_Reported_id_Reporter_id", x => new { x.Reported_id, x.Reporter_id });
                    table.ForeignKey(
                        name: "FK_Reported_Sites_Sites_Reported_id",
                        column: x => x.Reported_id,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reported_Sites_Users_Reporter_id",
                        column: x => x.Reporter_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportedUsers",
                columns: table => new
                {
                    Reported_id = table.Column<int>(nullable: false),
                    Reporter_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedUsers", x => new { x.Reporter_id, x.Reported_id });
                    table.UniqueConstraint("AK_ReportedUsers_Reported_id_Reporter_id", x => new { x.Reported_id, x.Reporter_id });
                    table.ForeignKey(
                        name: "FK_ReportedUsers_Users_Reported_id",
                        column: x => x.Reported_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportedUsers_Users_Reporter_id",
                        column: x => x.Reporter_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Site_Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reviewer_id = table.Column<int>(nullable: false),
                    Site_id = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Site_Reviews_Users_Reviewer_id",
                        column: x => x.Reviewer_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Site_Reviews_Sites_Site_id",
                        column: x => x.Site_id,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Site_Votes",
                columns: table => new
                {
                    User_id = table.Column<int>(nullable: false),
                    Site_id = table.Column<int>(nullable: false),
                    Vote = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_Votes", x => new { x.User_id, x.Site_id });
                    table.UniqueConstraint("AK_Site_Votes_Site_id_User_id", x => new { x.Site_id, x.User_id });
                    table.ForeignKey(
                        name: "FK_Site_Votes_Sites_Site_id",
                        column: x => x.Site_id,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Site_Votes_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reviewer_id = table.Column<int>(nullable: false),
                    Reviewed_id = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Reviews_Users_Reviewed_id",
                        column: x => x.Reviewed_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Reviews_Users_Reviewer_id",
                        column: x => x.Reviewer_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(nullable: false),
                    Post_id = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_Post_id",
                        column: x => x.Post_id,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    User_id = table.Column<int>(nullable: false),
                    Post_id = table.Column<int>(nullable: false),
                    Reaction_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => new { x.User_id, x.Post_id });
                    table.UniqueConstraint("AK_Reactions_Post_id_User_id", x => new { x.Post_id, x.User_id });
                    table.ForeignKey(
                        name: "FK_Reactions_Posts_Post_id",
                        column: x => x.Post_id,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reactions_Reaction_Icons_Reaction_id",
                        column: x => x.Reaction_id,
                        principalTable: "Reaction_Icons",
                        principalColumn: "Reaction_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reactions_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportedPosts",
                columns: table => new
                {
                    Reporter_id = table.Column<int>(nullable: false),
                    Post_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedPosts", x => new { x.Reporter_id, x.Post_id });
                    table.UniqueConstraint("AK_ReportedPosts_Post_id_Reporter_id", x => new { x.Post_id, x.Reporter_id });
                    table.ForeignKey(
                        name: "FK_ReportedPosts_Posts_Post_id",
                        column: x => x.Post_id,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportedPosts_Users_Reporter_id",
                        column: x => x.Reporter_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tagger_id = table.Column<int>(nullable: false),
                    Tagged_id = table.Column<int>(nullable: false),
                    Post_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Posts_Post_id",
                        column: x => x.Post_id,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tags_Users_Tagged_id",
                        column: x => x.Tagged_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tags_Users_Tagger_id",
                        column: x => x.Tagger_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_Blocker_id",
                table: "Blocks",
                column: "Blocker_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Post_id",
                table: "Comments",
                column: "Post_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_User_id",
                table: "Comments",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_Requests_Connector_id",
                table: "Connection_Requests",
                column: "Connector_id");

            migrationBuilder.CreateIndex(
                name: "IX_Connector_Sites_Location_id",
                table: "Connector_Sites",
                column: "Location_id");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectorInfos_id",
                table: "ConnectorInfos",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_FollowedUsers_Follower_id",
                table: "FollowedUsers",
                column: "Follower_id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Hashtag_id",
                table: "Posts",
                column: "Hashtag_id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Site_id",
                table: "Posts",
                column: "Site_id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_User_id",
                table: "Posts",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_Reaction_id",
                table: "Reactions",
                column: "Reaction_id");

            migrationBuilder.CreateIndex(
                name: "IX_Site_Reviews_Reviewer_id",
                table: "Site_Reviews",
                column: "Reviewer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Site_Reviews_Site_id",
                table: "Site_Reviews",
                column: "Site_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_Category_id",
                table: "Sites",
                column: "Category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_Location_id",
                table: "Sites",
                column: "Location_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Post_id",
                table: "Tags",
                column: "Post_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Tagged_id",
                table: "Tags",
                column: "Tagged_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Tagger_id",
                table: "Tags",
                column: "Tagger_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Reviews_Reviewed_id",
                table: "User_Reviews",
                column: "Reviewed_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Reviews_Reviewer_id",
                table: "User_Reviews",
                column: "Reviewer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Location_id",
                table: "Users",
                column: "Location_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Religion_id",
                table: "Users",
                column: "Religion_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Connection_Requests");

            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.DropTable(
                name: "Connector_Sites");

            migrationBuilder.DropTable(
                name: "ConnectorInfos");

            migrationBuilder.DropTable(
                name: "ConnectorInterests");

            migrationBuilder.DropTable(
                name: "FollowedSites");

            migrationBuilder.DropTable(
                name: "FollowedUsers");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Reported_Sites");

            migrationBuilder.DropTable(
                name: "ReportedPosts");

            migrationBuilder.DropTable(
                name: "ReportedUsers");

            migrationBuilder.DropTable(
                name: "Site_Reviews");

            migrationBuilder.DropTable(
                name: "Site_Votes");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "User_Reviews");

            migrationBuilder.DropTable(
                name: "Reaction_Icons");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Hashtags");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Religions");
        }
    }
}
