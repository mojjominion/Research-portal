using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResearchPortal.Data.Migrations
{
    public partial class ModelsAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<long>(nullable: true),
                    AuthorId1 = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    HtmlContent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers_AuthorId1",
                        column: x => x.AuthorId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<long>(nullable: true),
                    AuthorId1 = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AuthorId1",
                        column: x => x.AuthorId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResearchTopics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    HtmlContent = table.Column<string>(nullable: true),
                    AuthorId = table.Column<long>(nullable: true),
                    AuthorId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchTopics_AspNetUsers_AuthorId1",
                        column: x => x.AuthorId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResearcherArticleMappings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResearcherId = table.Column<string>(nullable: true),
                    ArticleId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearcherArticleMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearcherArticleMappings_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResearcherArticleMappings_AspNetUsers_ResearcherId",
                        column: x => x.ResearcherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCommentsMappings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentId = table.Column<long>(nullable: true),
                    ArticleId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCommentsMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleCommentsMappings_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleCommentsMappings_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResearcherCommentsMappings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentId = table.Column<long>(nullable: true),
                    ResearcherId = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearcherCommentsMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearcherCommentsMappings_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResearcherCommentsMappings_AspNetUsers_ResearcherId",
                        column: x => x.ResearcherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCommentsMappings_ArticleId",
                table: "ArticleCommentsMappings",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCommentsMappings_CommentId",
                table: "ArticleCommentsMappings",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId1",
                table: "Articles",
                column: "AuthorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId1",
                table: "Comments",
                column: "AuthorId1");

            migrationBuilder.CreateIndex(
                name: "IX_ResearcherArticleMappings_ArticleId",
                table: "ResearcherArticleMappings",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearcherArticleMappings_ResearcherId",
                table: "ResearcherArticleMappings",
                column: "ResearcherId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearcherCommentsMappings_CommentId",
                table: "ResearcherCommentsMappings",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearcherCommentsMappings_ResearcherId",
                table: "ResearcherCommentsMappings",
                column: "ResearcherId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchTopics_AuthorId1",
                table: "ResearchTopics",
                column: "AuthorId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCommentsMappings");

            migrationBuilder.DropTable(
                name: "ResearcherArticleMappings");

            migrationBuilder.DropTable(
                name: "ResearcherCommentsMappings");

            migrationBuilder.DropTable(
                name: "ResearchTopics");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
