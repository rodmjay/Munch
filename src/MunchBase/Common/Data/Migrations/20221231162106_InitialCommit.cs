using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MunchBase.Common.Data.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "IdentityServer");

            migrationBuilder.CreateTable(
                name: "ApiResource",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AllowedAccessTokenSigningAlgorithms = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShowInDiscoveryDocument = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NonEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiScope",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    Emphasize = table.Column<bool>(type: "bit", nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScope", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Capability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capability", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Channel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProtocolType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RequireClientSecret = table.Column<bool>(type: "bit", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ClientUri = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    LogoUri = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    RequireConsent = table.Column<bool>(type: "bit", nullable: false),
                    AllowRememberConsent = table.Column<bool>(type: "bit", nullable: false),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(type: "bit", nullable: false),
                    RequirePkce = table.Column<bool>(type: "bit", nullable: false),
                    AllowPlainTextPkce = table.Column<bool>(type: "bit", nullable: false),
                    RequireRequestObject = table.Column<bool>(type: "bit", nullable: false),
                    AllowAccessTokensViaBrowser = table.Column<bool>(type: "bit", nullable: false),
                    FrontChannelLogoutUri = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>(type: "bit", nullable: false),
                    BackChannelLogoutUri = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>(type: "bit", nullable: false),
                    AllowOfflineAccess = table.Column<bool>(type: "bit", nullable: false),
                    IdentityTokenLifetime = table.Column<int>(type: "int", nullable: false),
                    AllowedIdentityTokenSigningAlgorithms = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AccessTokenLifetime = table.Column<int>(type: "int", nullable: false),
                    AuthorizationCodeLifetime = table.Column<int>(type: "int", nullable: false),
                    ConsentLifetime = table.Column<int>(type: "int", nullable: true),
                    AbsoluteRefreshTokenLifetime = table.Column<int>(type: "int", nullable: false),
                    SlidingRefreshTokenLifetime = table.Column<int>(type: "int", nullable: false),
                    RefreshTokenUsage = table.Column<int>(type: "int", nullable: false),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(type: "bit", nullable: false),
                    RefreshTokenExpiration = table.Column<int>(type: "int", nullable: false),
                    AccessTokenType = table.Column<int>(type: "int", nullable: false),
                    EnableLocalLogin = table.Column<bool>(type: "bit", nullable: false),
                    IncludeJwtId = table.Column<bool>(type: "bit", nullable: false),
                    AlwaysSendClientClaims = table.Column<bool>(type: "bit", nullable: false),
                    ClientClaimsPrefix = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PairWiseSubjectSalt = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserSsoLifetime = table.Column<int>(type: "int", nullable: true),
                    UserCodeType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeviceCodeLifetime = table.Column<int>(type: "int", nullable: false),
                    NonEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Iso2 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CapsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iso3 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    NumberCode = table.Column<int>(type: "int", nullable: true),
                    PhoneCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Iso2);
                });

            migrationBuilder.CreateTable(
                name: "DeviceFlowCodes",
                schema: "IdentityServer",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceFlowCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResource",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    Emphasize = table.Column<bool>(type: "bit", nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NonEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityResource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Code3 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NativeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Code3);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                schema: "IdentityServer",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsumedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timezone",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timezone", x => new { x.Name, x.Code });
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceClaim",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiResourceId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceClaim_ApiResource_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalSchema: "IdentityServer",
                        principalTable: "ApiResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceProperty",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiResourceId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceProperty_ApiResource_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalSchema: "IdentityServer",
                        principalTable: "ApiResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceScope",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scope = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ApiResourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceScope", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceScope_ApiResource_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalSchema: "IdentityServer",
                        principalTable: "ApiResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceSecret",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiResourceId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceSecret", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceSecret_ApiResource_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalSchema: "IdentityServer",
                        principalTable: "ApiResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiScopeClaim",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScopeId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScopeClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiScopeClaim_ApiScope_ScopeId",
                        column: x => x.ScopeId,
                        principalSchema: "IdentityServer",
                        principalTable: "ApiScope",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiScopeProperty",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScopeId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScopeProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiScopeProperty_ApiScope_ScopeId",
                        column: x => x.ScopeId,
                        principalSchema: "IdentityServer",
                        principalTable: "ApiScope",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientClaim",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientClaim_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientCorsOrigin",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCorsOrigin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCorsOrigin_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientGrantType",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrantType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientGrantType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientGrantType_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientIdPRestriction",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provider = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientIdPRestriction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientIdPRestriction_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientPostLogoutRedirectUri",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostLogoutRedirectUri = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPostLogoutRedirectUri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientPostLogoutRedirectUri_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientProperty",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientProperty_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientRedirectUri",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedirectUri = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRedirectUri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientRedirectUri_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientScopes",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scope = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientScopes_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientSecret",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSecret", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientSecret_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnabledCountry",
                columns: table => new
                {
                    Iso2 = table.Column<string>(type: "nvarchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnabledCountry", x => x.Iso2);
                    table.ForeignKey(
                        name: "FK_EnabledCountry_Country_Iso2",
                        column: x => x.Iso2,
                        principalTable: "Country",
                        principalColumn: "Iso2",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StateProvince",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iso2 = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbrev = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateProvince", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateProvince_Country_Iso2",
                        column: x => x.Iso2,
                        principalTable: "Country",
                        principalColumn: "Iso2",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResourceClaim",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityResourceId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityResourceClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityResourceClaim_IdentityResource_IdentityResourceId",
                        column: x => x.IdentityResourceId,
                        principalSchema: "IdentityServer",
                        principalTable: "IdentityResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResourceProperty",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityResourceId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityResourceProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityResourceProperty_IdentityResource_IdentityResourceId",
                        column: x => x.IdentityResourceId,
                        principalSchema: "IdentityServer",
                        principalTable: "IdentityResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageCountry",
                columns: table => new
                {
                    Iso2 = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    Code3 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageCountry", x => new { x.Iso2, x.Code3 });
                    table.ForeignKey(
                        name: "FK_LanguageCountry_Country_Iso2",
                        column: x => x.Iso2,
                        principalTable: "Country",
                        principalColumn: "Iso2",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageCountry_Language_Code3",
                        column: x => x.Code3,
                        principalTable: "Language",
                        principalColumn: "Code3",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code3 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Iso2 = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Country_Iso2",
                        column: x => x.Iso2,
                        principalTable: "Country",
                        principalColumn: "Iso2",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Language_Code3",
                        column: x => x.Code3,
                        principalTable: "Language",
                        principalColumn: "Code3",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChannelProvider",
                columns: table => new
                {
                    ChannelId = table.Column<int>(type: "int", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelProvider", x => new { x.ChannelId, x.ProviderId });
                    table.ForeignKey(
                        name: "FK_ChannelProvider_Channel_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChannelProvider_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProviderCapability",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    CapabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderCapability", x => new { x.ProviderId, x.CapabilityId });
                    table.ForeignKey(
                        name: "FK_ProviderCapability_Capability_CapabilityId",
                        column: x => x.CapabilityId,
                        principalTable: "Capability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProviderCapability_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskType = table.Column<int>(type: "int", nullable: false),
                    Recurrence = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskMaster_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumer_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Editor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Editor_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producer_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.UserId, x.ProviderKey, x.LoginProvider });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChannelSubscription",
                columns: table => new
                {
                    ChannelId = table.Column<int>(type: "int", nullable: false),
                    ConsumerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelSubscription", x => new { x.ChannelId, x.ConsumerId });
                    table.ForeignKey(
                        name: "FK_ChannelSubscription_Channel_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChannelSubscription_Consumer_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EditSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditorId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditSession_Editor_EditorId",
                        column: x => x.EditorId,
                        principalTable: "Editor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditorModel",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditorModel", x => new { x.ModelId, x.EditorId });
                    table.ForeignKey(
                        name: "FK_EditorModel_Editor_EditorId",
                        column: x => x.EditorId,
                        principalTable: "Editor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EditorModel_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeaturedModel",
                columns: table => new
                {
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturedModel", x => new { x.Year, x.Month, x.Place });
                    table.ForeignKey(
                        name: "FK_FeaturedModel_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModelExcludedCountry",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Iso2 = table.Column<string>(type: "nvarchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelExcludedCountry", x => new { x.ModelId, x.Iso2 });
                    table.ForeignKey(
                        name: "FK_ModelExcludedCountry_Country_Iso2",
                        column: x => x.Iso2,
                        principalTable: "Country",
                        principalColumn: "Iso2",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelExcludedCountry_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelProvider",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelProvider", x => new { x.ModelId, x.ProviderId });
                    table.ForeignKey(
                        name: "FK_ModelProvider_Model_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelProvider_Provider_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelSubscription",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    ConsumerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelSubscription", x => new { x.ModelId, x.ConsumerId });
                    table.ForeignKey(
                        name: "FK_ModelSubscription_Consumer_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModelSubscription_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskMasterId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_TaskMaster_TaskMasterId",
                        column: x => x.TaskMasterId,
                        principalTable: "TaskMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dump",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditorId = table.Column<int>(type: "int", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    ProducerId = table.Column<int>(type: "int", nullable: true),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dump", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dump_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dump_Editor_EditorId",
                        column: x => x.EditorId,
                        principalTable: "Editor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dump_Producer_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteEditor",
                columns: table => new
                {
                    ProducerId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteEditor", x => new { x.ProducerId, x.EditorId });
                    table.ForeignKey(
                        name: "FK_FavoriteEditor_Editor_EditorId",
                        column: x => x.EditorId,
                        principalTable: "Editor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoriteEditor_Producer_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MediaSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditorId = table.Column<int>(type: "int", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaSet_Editor_EditorId",
                        column: x => x.EditorId,
                        principalTable: "Editor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaSet_Producer_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProducerModel",
                columns: table => new
                {
                    ProducerId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducerModel", x => new { x.ProducerId, x.ModelId });
                    table.ForeignKey(
                        name: "FK_ProducerModel_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProducerModel_Producer_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChannelIntent",
                columns: table => new
                {
                    ContentDumpId = table.Column<int>(type: "int", nullable: false),
                    ChannelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelIntent", x => new { x.ContentDumpId, x.ChannelId });
                    table.ForeignKey(
                        name: "FK_ChannelIntent_Channel_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelIntent_Dump_ContentDumpId",
                        column: x => x.ContentDumpId,
                        principalTable: "Dump",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentDumpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content_Dump_ContentDumpId",
                        column: x => x.ContentDumpId,
                        principalTable: "Dump",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DumpModel",
                columns: table => new
                {
                    DumpId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DumpModel", x => new { x.DumpId, x.ModelId });
                    table.ForeignKey(
                        name: "FK_DumpModel_Dump_DumpId",
                        column: x => x.DumpId,
                        principalTable: "Dump",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DumpModel_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DumpProvider",
                columns: table => new
                {
                    ContentDumpId = table.Column<int>(type: "int", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DumpProvider", x => new { x.ProviderId, x.ContentDumpId });
                    table.ForeignKey(
                        name: "FK_DumpProvider_Dump_ContentDumpId",
                        column: x => x.ContentDumpId,
                        principalTable: "Dump",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DumpProvider_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DumpSession",
                columns: table => new
                {
                    ContentDumpId = table.Column<int>(type: "int", nullable: false),
                    EditingSessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DumpSession", x => new { x.ContentDumpId, x.EditingSessionId });
                    table.ForeignKey(
                        name: "FK_DumpSession_Dump_ContentDumpId",
                        column: x => x.ContentDumpId,
                        principalTable: "Dump",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DumpSession_EditSession_EditingSessionId",
                        column: x => x.EditingSessionId,
                        principalTable: "EditSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChannelMediaSet",
                columns: table => new
                {
                    ChannelId = table.Column<int>(type: "int", nullable: false),
                    MediaSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelMediaSet", x => new { x.ChannelId, x.MediaSetId });
                    table.ForeignKey(
                        name: "FK_ChannelMediaSet_Channel_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelMediaSet_MediaSet_MediaSetId",
                        column: x => x.MediaSetId,
                        principalTable: "MediaSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaSetId = table.Column<int>(type: "int", nullable: false),
                    ConsumerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Consumer_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_MediaSet_MediaSetId",
                        column: x => x.MediaSetId,
                        principalTable: "MediaSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaSetId = table.Column<int>(type: "int", nullable: true),
                    IsExplicit = table.Column<bool>(type: "bit", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_MediaSet_MediaSetId",
                        column: x => x.MediaSetId,
                        principalTable: "MediaSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaSetProvider",
                columns: table => new
                {
                    MediaSetId = table.Column<int>(type: "int", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaSetProvider", x => new { x.ProviderId, x.MediaSetId });
                    table.ForeignKey(
                        name: "FK_MediaSetProvider_MediaSet_MediaSetId",
                        column: x => x.MediaSetId,
                        principalTable: "MediaSet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaSetProvider_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ModelMediaSet",
                columns: table => new
                {
                    MediaSetId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelMediaSet", x => new { x.MediaSetId, x.ModelId });
                    table.ForeignKey(
                        name: "FK_ModelMediaSet_MediaSet_MediaSetId",
                        column: x => x.MediaSetId,
                        principalTable: "MediaSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelMediaSet_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaApproval",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaApproval", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaApproval_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaApproval_Media_Id",
                        column: x => x.Id,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaTag",
                columns: table => new
                {
                    Tag = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTag", x => new { x.MediaId, x.Tag });
                    table.ForeignKey(
                        name: "FK_MediaTag_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Media_Id",
                        column: x => x.Id,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_Media_Id",
                        column: x => x.Id,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Capability",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Create Account" },
                    { 1, "Post Content" }
                });

            migrationBuilder.InsertData(
                table: "Channel",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Channel 2" },
                    { 1, "Channel 1" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Iso2", "CapsName", "Iso3", "Name", "NumberCode", "PhoneCode" },
                values: new object[,]
                {
                    { "SJ", "SVALBARD AND JAN MAYEN", "SJM", "Svalbard and Jan Mayen", 744, 47 },
                    { "MP", "NORTHERN MARIANA ISLANDS", "MNP", "Northern Mariana Islands", 580, 1670 },
                    { "NF", "NORFOLK ISLAND", "NFK", "Norfolk Island", 574, 672 },
                    { "NU", "NIUE", "NIU", "Niue", 570, 683 },
                    { "NG", "NIGERIA", "NGA", "Nigeria", 566, 234 },
                    { "NZ", "NEW ZEALAND", "NZL", "New Zealand", 554, 64 },
                    { "NO", "NORWAY", "NOR", "Norway", 578, 47 },
                    { "NC", "NEW CALEDONIA", "NCL", "New Caledonia", 540, 687 },
                    { "AN", "NETHERLANDS ANTILLES", "ANT", "Netherlands Antilles", 530, 599 },
                    { "NL", "NETHERLANDS", "NLD", "Netherlands", 528, 31 },
                    { "NP", "NEPAL", "NPL", "Nepal", 524, 977 },
                    { "NR", "NAURU", "NRU", "Nauru", 520, 674 },
                    { "NI", "NICARAGUA", "NIC", "Nicaragua", 558, 505 },
                    { "OM", "OMAN", "OMN", "Oman", 512, 968 },
                    { "PS", "PALESTINIAN TERRITORY, OCCUPIED", "", "Palestinian Territory, Occupied", null, 970 },
                    { "PW", "PALAU", "PLW", "Palau", 585, 680 },
                    { "NA", "NAMIBIA", "NAM", "Namibia", 516, 264 },
                    { "PA", "PANAMA", "PAN", "Panama", 591, 507 },
                    { "PG", "PAPUA NEW GUINEA", "PNG", "Papua New Guinea", 598, 675 },
                    { "PY", "PARAGUAY", "PRY", "Paraguay", 600, 595 },
                    { "PE", "PERU", "PER", "Peru", 604, 51 },
                    { "PH", "PHILIPPINES", "PHL", "Philippines", 608, 63 },
                    { "PN", "PITCAIRN", "PCN", "Pitcairn", 612, 0 },
                    { "PL", "POLAND", "POL", "Poland", 616, 48 },
                    { "PT", "PORTUGAL", "PRT", "Portugal", 620, 351 },
                    { "PR", "PUERTO RICO", "PRI", "Puerto Rico", 630, 1787 },
                    { "QA", "QATAR", "QAT", "Qatar", 634, 974 },
                    { "RE", "REUNION", "REU", "Reunion", 638, 262 },
                    { "PK", "PAKISTAN", "PAK", "Pakistan", 586, 92 },
                    { "MM", "MYANMAR", "MMR", "Myanmar", 104, 95 },
                    { "MA", "MOROCCO", "MAR", "Morocco", 504, 212 },
                    { "RO", "ROMANIA", "ROM", "Romania", 642, 40 },
                    { "LV", "LATVIA", "LVA", "Latvia", 428, 371 },
                    { "LB", "LEBANON", "LBN", "Lebanon", 422, 961 },
                    { "LS", "LESOTHO", "LSO", "Lesotho", 426, 266 },
                    { "LR", "LIBERIA", "LBR", "Liberia", 430, 231 },
                    { "LY", "LIBYAN ARAB JAMAHIRIYA", "LBY", "Libyan Arab Jamahiriya", 434, 218 },
                    { "LI", "LIECHTENSTEIN", "LIE", "Liechtenstein", 438, 423 }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Iso2", "CapsName", "Iso3", "Name", "NumberCode", "PhoneCode" },
                values: new object[,]
                {
                    { "LT", "LITHUANIA", "LTU", "Lithuania", 440, 370 },
                    { "LU", "LUXEMBOURG", "LUX", "Luxembourg", 442, 352 },
                    { "MO", "MACAO", "MAC", "Macao", 446, 853 },
                    { "MK", "MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF", "MKD", "Macedonia, the Former Yugoslav Republic of", 807, 389 },
                    { "MG", "MADAGASCAR", "MDG", "Madagascar", 450, 261 },
                    { "MW", "MALAWI", "MWI", "Malawi", 454, 265 },
                    { "MY", "MALAYSIA", "MYS", "Malaysia", 458, 60 },
                    { "MV", "MALDIVES", "MDV", "Maldives", 462, 960 },
                    { "ML", "MALI", "MLI", "Mali", 466, 223 },
                    { "MT", "MALTA", "MLT", "Malta", 470, 356 },
                    { "MH", "MARSHALL ISLANDS", "MHL", "Marshall Islands", 584, 692 },
                    { "MQ", "MARTINIQUE", "MTQ", "Martinique", 474, 596 },
                    { "MR", "MAURITANIA", "MRT", "Mauritania", 478, 222 },
                    { "MU", "MAURITIUS", "MUS", "Mauritius", 480, 230 },
                    { "YT", "MAYOTTE", "", "Mayotte", null, 269 },
                    { "MX", "MEXICO", "MEX", "Mexico", 484, 52 },
                    { "FM", "MICRONESIA, FEDERATED STATES OF", "FSM", "Micronesia, Federated States of", 583, 691 },
                    { "MD", "MOLDOVA, REPUBLIC OF", "MDA", "Moldova, Republic of", 498, 373 },
                    { "MC", "MONACO", "MCO", "Monaco", 492, 377 },
                    { "MN", "MONGOLIA", "MNG", "Mongolia", 496, 976 },
                    { "MS", "MONTSERRAT", "MSR", "Montserrat", 500, 1664 },
                    { "MZ", "MOZAMBIQUE", "MOZ", "Mozambique", 508, 258 },
                    { "RU", "RUSSIAN FEDERATION", "RUS", "Russian Federation", 643, 70 },
                    { "KN", "SAINT KITTS AND NEVIS", "KNA", "Saint Kitts and Nevis", 659, 1869 },
                    { "SH", "SAINT HELENA", "SHN", "Saint Helena", 654, 290 },
                    { "TG", "TOGO", "TGO", "Togo", 768, 228 },
                    { "TK", "TOKELAU", "TKL", "Tokelau", 772, 690 },
                    { "TO", "TONGA", "TON", "Tonga", 776, 676 },
                    { "TT", "TRINIDAD AND TOBAGO", "TTO", "Trinidad and Tobago", 780, 1868 },
                    { "TN", "TUNISIA", "TUN", "Tunisia", 788, 216 },
                    { "TR", "TURKEY", "TUR", "Turkey", 792, 90 },
                    { "TM", "TURKMENISTAN", "TKM", "Turkmenistan", 795, 7370 },
                    { "TC", "TURKS AND CAICOS ISLANDS", "TCA", "Turks and Caicos Islands", 796, 1649 },
                    { "TV", "TUVALU", "TUV", "Tuvalu", 798, 688 },
                    { "UG", "UGANDA", "UGA", "Uganda", 800, 256 },
                    { "UA", "UKRAINE", "UKR", "Ukraine", 804, 380 },
                    { "AE", "UNITED ARAB EMIRATES", "ARE", "United Arab Emirates", 784, 971 },
                    { "GB", "UNITED KINGDOM", "GBR", "United Kingdom", 826, 44 },
                    { "US", "UNITED STATES", "USA", "United States", 840, 1 },
                    { "UM", "UNITED STATES MINOR OUTLYING ISLANDS", "", "United States Minor Outlying Islands", null, 1 },
                    { "UY", "URUGUAY", "URY", "Uruguay", 858, 598 },
                    { "UZ", "UZBEKISTAN", "UZB", "Uzbekistan", 860, 998 }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Iso2", "CapsName", "Iso3", "Name", "NumberCode", "PhoneCode" },
                values: new object[,]
                {
                    { "VU", "VANUATU", "VUT", "Vanuatu", 548, 678 },
                    { "VE", "VENEZUELA", "VEN", "Venezuela", 862, 58 },
                    { "VN", "VIET NAM", "VNM", "Viet Nam", 704, 84 },
                    { "VG", "VIRGIN ISLANDS, BRITISH", "VGB", "Virgin Islands, British", 92, 1284 },
                    { "VI", "VIRGIN ISLANDS, U.S.", "VIR", "Virgin Islands, U.s.", 850, 1340 },
                    { "WF", "WALLIS AND FUTUNA", "WLF", "Wallis and Futuna", 876, 681 },
                    { "EH", "WESTERN SAHARA", "ESH", "Western Sahara", 732, 212 },
                    { "YE", "YEMEN", "YEM", "Yemen", 887, 967 },
                    { "ZM", "ZAMBIA", "ZMB", "Zambia", 894, 260 },
                    { "ZW", "ZIMBABWE", "ZWE", "Zimbabwe", 716, 263 },
                    { "TL", "TIMOR-LESTE", "", "Timor-Leste", null, 670 },
                    { "TH", "THAILAND", "THA", "Thailand", 764, 66 },
                    { "TZ", "TANZANIA, UNITED REPUBLIC OF", "TZA", "Tanzania, United Republic of", 834, 255 },
                    { "TJ", "TAJIKISTAN", "TJK", "Tajikistan", 762, 992 },
                    { "LA", "LAO PEOPLE'S DEMOCRATIC REPUBLIC", "LAO", "Lao People's Democratic Republic", 418, 856 },
                    { "LC", "SAINT LUCIA", "LCA", "Saint Lucia", 662, 1758 },
                    { "PM", "SAINT PIERRE AND MIQUELON", "SPM", "Saint Pierre and Miquelon", 666, 508 },
                    { "VC", "SAINT VINCENT AND THE GRENADINES", "VCT", "Saint Vincent and the Grenadines", 670, 1784 },
                    { "WS", "SAMOA", "WSM", "Samoa", 882, 684 },
                    { "SM", "SAN MARINO", "SMR", "San Marino", 674, 378 },
                    { "ST", "SAO TOME AND PRINCIPE", "STP", "Sao Tome and Principe", 678, 239 },
                    { "SA", "SAUDI ARABIA", "SAU", "Saudi Arabia", 682, 966 },
                    { "SN", "SENEGAL", "SEN", "Senegal", 686, 221 },
                    { "CS", "SERBIA AND MONTENEGRO", "", "Serbia and Montenegro", null, 381 },
                    { "SC", "SEYCHELLES", "SYC", "Seychelles", 690, 248 },
                    { "SL", "SIERRA LEONE", "SLE", "Sierra Leone", 694, 232 },
                    { "SG", "SINGAPORE", "SGP", "Singapore", 702, 65 },
                    { "RW", "RWANDA", "RWA", "Rwanda", 646, 250 },
                    { "SK", "SLOVAKIA", "SVK", "Slovakia", 703, 421 },
                    { "SB", "SOLOMON ISLANDS", "SLB", "Solomon Islands", 90, 677 },
                    { "SO", "SOMALIA", "SOM", "Somalia", 706, 252 },
                    { "ZA", "SOUTH AFRICA", "ZAF", "South Africa", 710, 27 },
                    { "GS", "SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS", "", "South Georgia and the South Sandwich Islands", null, 0 },
                    { "ES", "SPAIN", "ESP", "Spain", 724, 34 },
                    { "LK", "SRI LANKA", "LKA", "Sri Lanka", 144, 94 },
                    { "SD", "SUDAN", "SDN", "Sudan", 736, 249 },
                    { "SR", "SURINAME", "SUR", "Suriname", 740, 597 },
                    { "SZ", "SWAZILAND", "SWZ", "Swaziland", 748, 268 },
                    { "SE", "SWEDEN", "SWE", "Sweden", 752, 46 },
                    { "CH", "SWITZERLAND", "CHE", "Switzerland", 756, 41 },
                    { "SY", "SYRIAN ARAB REPUBLIC", "SYR", "Syrian Arab Republic", 760, 963 },
                    { "TW", "TAIWAN, PROVINCE OF CHINA", "TWN", "Taiwan, Province of China", 158, 886 }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Iso2", "CapsName", "Iso3", "Name", "NumberCode", "PhoneCode" },
                values: new object[,]
                {
                    { "SI", "SLOVENIA", "SVN", "Slovenia", 705, 386 },
                    { "KG", "KYRGYZSTAN", "KGZ", "Kyrgyzstan", 417, 996 },
                    { "NE", "NIGER", "NER", "Niger", 562, 227 },
                    { "KR", "KOREA, REPUBLIC OF", "KOR", "Korea, Republic of", 410, 82 },
                    { "BR", "BRAZIL", "BRA", "Brazil", 76, 55 },
                    { "IO", "BRITISH INDIAN OCEAN TERRITORY", "", "British Indian Ocean Territory", null, 246 },
                    { "BN", "BRUNEI DARUSSALAM", "BRN", "Brunei Darussalam", 96, 673 },
                    { "BG", "BULGARIA", "BGR", "Bulgaria", 100, 359 },
                    { "BF", "BURKINA FASO", "BFA", "Burkina Faso", 854, 226 },
                    { "BI", "BURUNDI", "BDI", "Burundi", 108, 257 },
                    { "KH", "CAMBODIA", "KHM", "Cambodia", 116, 855 },
                    { "CM", "CAMEROON", "CMR", "Cameroon", 120, 237 },
                    { "CA", "CANADA", "CAN", "Canada", 124, 1 },
                    { "CV", "CAPE VERDE", "CPV", "Cape Verde", 132, 238 },
                    { "KY", "CAYMAN ISLANDS", "CYM", "Cayman Islands", 136, 1345 },
                    { "CF", "CENTRAL AFRICAN REPUBLIC", "CAF", "Central African Republic", 140, 236 },
                    { "TD", "CHAD", "TCD", "Chad", 148, 235 },
                    { "CL", "CHILE", "CHL", "Chile", 152, 56 },
                    { "CN", "CHINA", "CHN", "China", 156, 86 },
                    { "CX", "CHRISTMAS ISLAND", "", "Christmas Island", null, 61 },
                    { "CC", "COCOS (KEELING) ISLANDS", "", "Cocos (Keeling) Islands", null, 672 },
                    { "CO", "COLOMBIA", "COL", "Colombia", 170, 57 },
                    { "KM", "COMOROS", "COM", "Comoros", 174, 269 },
                    { "CG", "CONGO", "COG", "Congo", 178, 242 },
                    { "CD", "CONGO, THE DEMOCRATIC REPUBLIC OF THE", "COD", "Congo, the Democratic Republic of the", 180, 242 },
                    { "CK", "COOK ISLANDS", "COK", "Cook Islands", 184, 682 },
                    { "CR", "COSTA RICA", "CRI", "Costa Rica", 188, 506 },
                    { "CI", "COTE D'IVOIRE", "CIV", "Cote D'Ivoire", 384, 225 },
                    { "HR", "CROATIA", "HRV", "Croatia", 191, 385 },
                    { "BV", "BOUVET ISLAND", "", "Bouvet Island", null, 0 },
                    { "CU", "CUBA", "CUB", "Cuba", 192, 53 },
                    { "BW", "BOTSWANA", "BWA", "Botswana", 72, 267 },
                    { "BO", "BOLIVIA", "BOL", "Bolivia", 68, 591 },
                    { "AF", "AFGHANISTAN", "AFG", "Afghanistan", 4, 93 },
                    { "AL", "ALBANIA", "ALB", "Albania", 8, 355 },
                    { "DZ", "ALGERIA", "DZA", "Algeria", 12, 213 },
                    { "AS", "AMERICAN SAMOA", "ASM", "American Samoa", 16, 1684 },
                    { "AD", "ANDORRA", "AND", "Andorra", 20, 376 },
                    { "AO", "ANGOLA", "AGO", "Angola", 24, 244 },
                    { "AI", "ANGUILLA", "AIA", "Anguilla", 660, 1264 },
                    { "AQ", "ANTARCTICA", "", "Antarctica", null, 0 },
                    { "AG", "ANTIGUA AND BARBUDA", "ATG", "Antigua and Barbuda", 28, 1268 }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Iso2", "CapsName", "Iso3", "Name", "NumberCode", "PhoneCode" },
                values: new object[,]
                {
                    { "AR", "ARGENTINA", "ARG", "Argentina", 32, 54 },
                    { "AM", "ARMENIA", "ARM", "Armenia", 51, 374 },
                    { "KW", "KUWAIT", "KWT", "Kuwait", 414, 965 },
                    { "AU", "AUSTRALIA", "AUS", "Australia", 36, 61 },
                    { "AT", "AUSTRIA", "AUT", "Austria", 40, 43 },
                    { "AZ", "AZERBAIJAN", "AZE", "Azerbaijan", 31, 994 },
                    { "BS", "BAHAMAS", "BHS", "Bahamas", 44, 1242 },
                    { "BH", "BAHRAIN", "BHR", "Bahrain", 48, 973 },
                    { "BD", "BANGLADESH", "BGD", "Bangladesh", 50, 880 },
                    { "BB", "BARBADOS", "BRB", "Barbados", 52, 1246 },
                    { "BY", "BELARUS", "BLR", "Belarus", 112, 375 },
                    { "BE", "BELGIUM", "BEL", "Belgium", 56, 32 },
                    { "BZ", "BELIZE", "BLZ", "Belize", 84, 501 },
                    { "BJ", "BENIN", "BEN", "Benin", 204, 229 },
                    { "BM", "BERMUDA", "BMU", "Bermuda", 60, 1441 },
                    { "BT", "BHUTAN", "BTN", "Bhutan", 64, 975 },
                    { "BA", "BOSNIA AND HERZEGOVINA", "BIH", "Bosnia and Herzegovina", 70, 387 },
                    { "CY", "CYPRUS", "CYP", "Cyprus", 196, 357 },
                    { "AW", "ARUBA", "ABW", "Aruba", 533, 297 },
                    { "DK", "DENMARK", "DNK", "Denmark", 208, 45 },
                    { "GT", "GUATEMALA", "GTM", "Guatemala", 320, 502 },
                    { "GN", "GUINEA", "GIN", "Guinea", 324, 224 },
                    { "GW", "GUINEA-BISSAU", "GNB", "Guinea-Bissau", 624, 245 },
                    { "GY", "GUYANA", "GUY", "Guyana", 328, 592 },
                    { "HT", "HAITI", "HTI", "Haiti", 332, 509 },
                    { "HM", "HEARD ISLAND AND MCDONALD ISLANDS", "", "Heard Island and Mcdonald Islands", null, 0 },
                    { "VA", "HOLY SEE (VATICAN CITY STATE)", "VAT", "Holy See (Vatican City State)", 336, 39 },
                    { "HN", "HONDURAS", "HND", "Honduras", 340, 504 },
                    { "HK", "HONG KONG", "HKG", "Hong Kong", 344, 852 },
                    { "HU", "HUNGARY", "HUN", "Hungary", 348, 36 },
                    { "IS", "ICELAND", "ISL", "Iceland", 352, 354 },
                    { "IN", "INDIA", "IND", "India", 356, 91 },
                    { "ID", "INDONESIA", "IDN", "Indonesia", 360, 62 },
                    { "IR", "IRAN, ISLAMIC REPUBLIC OF", "IRN", "Iran, Islamic Republic of", 364, 98 },
                    { "IQ", "IRAQ", "IRQ", "Iraq", 368, 964 },
                    { "IE", "IRELAND", "IRL", "Ireland", 372, 353 },
                    { "IL", "ISRAEL", "ISR", "Israel", 376, 972 },
                    { "IT", "ITALY", "ITA", "Italy", 380, 39 },
                    { "JP", "JAPAN", "JPN", "Japan", 392, 81 },
                    { "JO", "JORDAN", "JOR", "Jordan", 400, 962 },
                    { "KZ", "KAZAKHSTAN", "KAZ", "Kazakhstan", 398, 7 },
                    { "KE", "KENYA", "KEN", "Kenya", 404, 254 }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Iso2", "CapsName", "Iso3", "Name", "NumberCode", "PhoneCode" },
                values: new object[,]
                {
                    { "KI", "KIRIBATI", "KIR", "Kiribati", 296, 686 },
                    { "KP", "KOREA, DEMOCRATIC PEOPLE'S REPUBLIC OF", "PRK", "Korea, Democratic People's Republic of", 408, 850 },
                    { "CZ", "CZECH REPUBLIC", "CZE", "Czech Republic", 203, 420 },
                    { "GU", "GUAM", "GUM", "Guam", 316, 1671 },
                    { "GP", "GUADELOUPE", "GLP", "Guadeloupe", 312, 590 },
                    { "JM", "JAMAICA", "JAM", "Jamaica", 388, 1876 },
                    { "EG", "EGYPT", "EGY", "Egypt", 818, 20 },
                    { "DM", "DOMINICA", "DMA", "Dominica", 212, 1767 },
                    { "DO", "DOMINICAN REPUBLIC", "DOM", "Dominican Republic", 214, 1809 },
                    { "EC", "ECUADOR", "ECU", "Ecuador", 218, 593 },
                    { "SV", "EL SALVADOR", "SLV", "El Salvador", 222, 503 },
                    { "GQ", "EQUATORIAL GUINEA", "GNQ", "Equatorial Guinea", 226, 240 },
                    { "DJ", "DJIBOUTI", "DJI", "Djibouti", 262, 253 },
                    { "ER", "ERITREA", "ERI", "Eritrea", 232, 291 },
                    { "EE", "ESTONIA", "EST", "Estonia", 233, 372 },
                    { "ET", "ETHIOPIA", "ETH", "Ethiopia", 231, 251 },
                    { "FO", "FAROE ISLANDS", "FRO", "Faroe Islands", 234, 298 },
                    { "FJ", "FIJI", "FJI", "Fiji", 242, 679 },
                    { "FI", "FINLAND", "FIN", "Finland", 246, 358 },
                    { "FK", "FALKLAND ISLANDS (MALVINAS)", "FLK", "Falkland Islands (Malvinas)", 238, 500 },
                    { "GF", "FRENCH GUIANA", "GUF", "French Guiana", 254, 594 },
                    { "GL", "GREENLAND", "GRL", "Greenland", 304, 299 },
                    { "GR", "GREECE", "GRC", "Greece", 300, 30 },
                    { "GI", "GIBRALTAR", "GIB", "Gibraltar", 292, 350 },
                    { "FR", "FRANCE", "FRA", "France", 250, 33 },
                    { "GH", "GHANA", "GHA", "Ghana", 288, 233 },
                    { "DE", "GERMANY", "DEU", "Germany", 276, 49 },
                    { "GD", "GRENADA", "GRD", "Grenada", 308, 1473 },
                    { "GM", "GAMBIA", "GMB", "Gambia", 270, 220 },
                    { "GA", "GABON", "GAB", "Gabon", 266, 241 },
                    { "TF", "FRENCH SOUTHERN TERRITORIES", "", "French Southern Territories", null, 0 },
                    { "PF", "FRENCH POLYNESIA", "PYF", "French Polynesia", 258, 689 },
                    { "GE", "GEORGIA", "GEO", "Georgia", 268, 995 }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Code3", "Code2", "Name", "NativeName" },
                values: new object[,]
                {
                    { "iku", "iu", "Inuktitut", "ᐃᓄᒃᑎᑐᑦ" },
                    { "hin", "hi", "Hindi", "हिन्दी, हिंदी" },
                    { "hrv", "hr", "Croatian", "hrvatski jezik" },
                    { "hun", "hu", "Hungarian", "magyar" },
                    { "hye", "hy", "Armenian", "Հայերեն" },
                    { "ibo", "ig", "Igbo", "Asụsụ Igbo" },
                    { "ido", "io", "Ido", "Ido" },
                    { "iii", "ii", "Nuosu", "ꆈꌠ꒿ Nuosuhxop" },
                    { "hmo", "ho", "Hiri Motu", "Hiri Motu" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Code3", "Code2", "Name", "NativeName" },
                values: new object[,]
                {
                    { "dzo", "dz", "Dzongkha", "རྫོང་ཁ" },
                    { "ina", "ia", "Interlingua", "Interlingua" },
                    { "ind", "id", "Indonesian", "Bahasa Indonesia" },
                    { "ipk", "ik", "Inupiaq", "Iñupiaq, Iñupiatun" },
                    { "isl", "is", "Icelandic", "Íslenska" },
                    { "ita", "it", "Italian", "italiano" },
                    { "jav", "jv", "Javanese", "basa Jawa" },
                    { "jpn", "ja", "Japanese", "日本語 (にほんご)" },
                    { "her", "hz", "Herero", "Otjiherero" },
                    { "kal", "kl", "Kalaallisut, Greenlandic", "kalaallisut, kalaallit oqaasii" },
                    { "kan", "kn", "Kannada", "ಕನ್ನಡ" },
                    { "ile", "ie", "Interlingue", "Originally called Occidental; then Interlingue after WWII" },
                    { "heb", "he", "Hebrew (modern)", "עברית" },
                    { "fij", "fj", "Fijian", "vosa Vakaviti" },
                    { "hat", "ht", "Haitian; Haitian Creole", "Kreyòl ayisyen" },
                    { "div", "dv", "Divehi; Dhivehi; Maldivian;", "ދިވެހި" },
                    { "kas", "ks", "Kashmiri", "कश्मीरी, كشميري‎" },
                    { "ell", "el", "Greek, Modern", "ελληνικά" },
                    { "eng", "en", "English", "English" },
                    { "epo", "eo", "Esperanto", "Esperanto" },
                    { "est", "et", "Estonian", "eesti, eesti keel" },
                    { "eus", "eu", "Basque", "euskara, euskera" },
                    { "ewe", "ee", "Ewe", "Eʋegbe" },
                    { "pol", "pl", "Polish", "język polski, polszczyzna" },
                    { "hau", "ha", "Hausa", "Hausa, هَوُسَ" },
                    { "fas", "fa", "Persian (Farsi)", "فارسی" },
                    { "fra", "fr", "French", "français, langue française" },
                    { "fry", "fy", "Western Frisian", "Frysk" },
                    { "ful", "ff", "Fula; Fulah; Pulaar; Pular", "Fulfulde, Pulaar, Pular" },
                    { "gla", "gd", "Scottish Gaelic; Gaelic", "Gàidhlig" },
                    { "gle", "ga", "Irish", "Gaeilge" },
                    { "glg", "gl", "Galician", "galego" },
                    { "glv", "gv", "Manx", "Gaelg, Gailck" },
                    { "grn", "gn", "Guaraní", "Avañe'ẽ" },
                    { "guj", "gu", "Gujarati", "ગુજરાતી" },
                    { "fin", "fi", "Finnish", "suomi, suomen kieli" },
                    { "kat", "ka", "Georgian", "ქართული" },
                    { "mri", "mi", "Māori", "te reo Māori" },
                    { "kaz", "kk", "Kazakh", "қазақ тілі" },
                    { "mon", "mn", "Mongolian", "монгол" },
                    { "msa", "ms", "Malay", "bahasa Melayu, بهاس ملايو‎" },
                    { "mya", "my", "Burmese", "ဗမာစာ" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Code3", "Code2", "Name", "NativeName" },
                values: new object[,]
                {
                    { "nau", "na", "Nauru", "Ekakairũ Naoero" },
                    { "nav", "nv", "Navajo, Navaho", "Diné bizaad, Dinékʼehǰí" },
                    { "nbl", "nr", "South Ndebele", "isiNdebele" },
                    { "nde", "nd", "North Ndebele", "isiNdebele" },
                    { "ndo", "ng", "Ndonga", "Owambo" },
                    { "nep", "ne", "Nepali", "नेपाली" },
                    { "mlt", "mt", "Maltese", "Malti" },
                    { "oss", "os", "Ossetian, Ossetic", "ирон æвзаг" },
                    { "ori", "or", "Oriya", "ଓଡ଼ିଆ" },
                    { "oji", "oj", "Ojibwe, Ojibwa", "ᐊᓂᔑᓈᐯᒧᐎᓐ" },
                    { "oci", "oc", "Occitan", "occitan, lenga d'òc" },
                    { "nya", "ny", "Chichewa; Chewa; Nyanja", "chiCheŵa, chinyanja" },
                    { "nor", "no", "Norwegian", "Norsk" },
                    { "nob", "nb", "Norwegian Bokmål", "Norsk bokmål" },
                    { "nno", "nn", "Norwegian Nynorsk", "Norsk nynorsk" },
                    { "nld", "nl", "Dutch", "Nederlands, Vlaams" },
                    { "deu", "de", "German", "Deutsch" },
                    { "orm", "om", "Oromo", "Afaan Oromoo" },
                    { "kau", "kr", "Kanuri", "Kanuri" },
                    { "mlg", "mg", "Malagasy", "fiteny malagasy" },
                    { "mar", "mr", "Marathi (Marāṭhī)", "मराठी" },
                    { "khm", "km", "Khmer", "ខ្មែរ, ខេមរភាសា, ភាសាខ្មែរ" },
                    { "kik", "ki", "Kikuyu, Gikuyu", "Gĩkũyũ" },
                    { "kin", "rw", "Kinyarwanda", "Ikinyarwanda" },
                    { "kir", "ky", "Kyrgyz", "Кыргызча, Кыргыз тили" },
                    { "kom", "kv", "Komi", "коми кыв" },
                    { "kon", "kg", "Kongo", "KiKongo" },
                    { "kor", "ko", "Korean", "한국어 (韓國語), 조선어 (朝鮮語)" },
                    { "kua", "kj", "Kwanyama, Kuanyama", "Kuanyama" },
                    { "kur", "ku", "Kurdish", "Kurdî, كوردی‎" },
                    { "mkd", "mk", "Macedonian", "македонски јазик" },
                    { "lao", "lo", "Lao", "ພາສາລາວ" },
                    { "lav", "lv", "Latvian", "latviešu valoda" },
                    { "lim", "li", "Limburgish, Limburgan, Limburger", "Limburgs" },
                    { "lin", "ln", "Lingala", "Lingála" },
                    { "lit", "lt", "Lithuanian", "lietuvių kalba" },
                    { "ltz", "lb", "Luxembourgish, Letzeburgesch", "Lëtzebuergesch" },
                    { "lub", "lu", "Luba-Katanga", "Tshiluba" },
                    { "lug", "lg", "Ganda", "Luganda" },
                    { "mah", "mh", "Marshallese", "Kajin M̧ajeļ" },
                    { "mal", "ml", "Malayalam", "മലയാളം" },
                    { "lat", "la", "Latin", "latine, lingua latina" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Code3", "Code2", "Name", "NativeName" },
                values: new object[,]
                {
                    { "dan", "da", "Danish", "dansk" },
                    { "fao", "fo", "Faroese", "føroyskt" },
                    { "cre", "cr", "Cree", "ᓀᐦᐃᔭᐍᐏᐣ" },
                    { "tha", "th", "Thai", "ไทย" },
                    { "tgl", "tl", "Tagalog", "Wikang Tagalog, ᜏᜒᜃᜅ᜔ ᜆᜄᜎᜓᜄ᜔" },
                    { "tgk", "tg", "Tajik", "тоҷикӣ, toğikī, تاجیکی‎" },
                    { "tel", "te", "Telugu", "తెలుగు" },
                    { "tat", "tt", "Tatar", "татар теле, tatar tele" },
                    { "tam", "ta", "Tamil", "தமிழ்" },
                    { "tah", "ty", "Tahitian", "Reo Tahiti" },
                    { "swe", "sv", "Swedish", "Svenska" },
                    { "tir", "ti", "Tigrinya", "ትግርኛ" },
                    { "swa", "sw", "Swahili", "Kiswahili" },
                    { "ssw", "ss", "Swati", "SiSwati" },
                    { "srp", "sr", "Serbian", "српски језик" },
                    { "srd", "sc", "Sardinian", "sardu" },
                    { "sqi", "sq", "Albanian", "gjuha shqipe" },
                    { "spa", "es", "Spanish; Castilian", "español, castellano" },
                    { "sot", "st", "Southern Sotho", "Sesotho" },
                    { "som", "so", "Somali", "Soomaaliga, af Soomaali" },
                    { "cym", "cy", "Welsh", "Cymraeg" },
                    { "sun", "su", "Sundanese", "Basa Sunda" },
                    { "ton", "to", "Tonga (Tonga Islands)", "faka Tonga" },
                    { "tsn", "tn", "Tswana", "Setswana" },
                    { "tso", "ts", "Tsonga", "Xitsonga" },
                    { "zul", "zu", "Zulu", "isiZulu" },
                    { "zho", "zh", "Chinese", "中文 (Zhōngwén), 汉语, 漢語" },
                    { "zha", "za", "Zhuang, Chuang", "Saɯ cueŋƅ, Saw cuengh" },
                    { "yor", "yo", "Yoruba", "Yorùbá" },
                    { "pan", "pa", "Panjabi, Punjabi", "ਪੰਜਾਬੀ, پنجابی‎" },
                    { "yid", "yi", "Yiddish", "ייִדיש" },
                    { "xho", "xh", "Xhosa", "isiXhosa" },
                    { "wol", "wo", "Wolof", "Wollof" },
                    { "wln", "wa", "Walloon", "walon" },
                    { "vol", "vo", "Volapük", "Volapük" },
                    { "vie", "vi", "Vietnamese", "Tiếng Việt" },
                    { "ven", "ve", "Venda", "Tshivenḓa" },
                    { "uzb", "uz", "Uzbek", "O‘zbek, Ўзбек, أۇزبېك‎" },
                    { "urd", "ur", "Urdu", "اردو" },
                    { "ukr", "uk", "Ukrainian", "українська мова" },
                    { "uig", "ug", "Uyghur, Uighur", "Uyƣurqə, ئۇيغۇرچە‎" },
                    { "twi", "tw", "Twi", "Twi" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Code3", "Code2", "Name", "NativeName" },
                values: new object[,]
                {
                    { "tur", "tr", "Turkish", "Türkçe" },
                    { "tuk", "tk", "Turkmen", "Türkmen, Түркмен" },
                    { "sna", "sn", "Shona", "chiShona" },
                    { "smo", "sm", "Samoan", "gagana fa'a Samoa" },
                    { "snd", "sd", "Sindhi", "सिन्धी, سنڌي، سندھی‎" },
                    { "slv", "sl", "Slovene", "slovenski jezik, slovenščina" },
                    { "sme", "se", "Northern Sami", "Davvisámegiella" },
                    { "bak", "ba", "Bashkir", "башҡорт теле" },
                    { "bam", "bm", "Bambara", "bamanankan" },
                    { "bel", "be", "Belarusian", "беларуская мова" },
                    { "ben", "bn", "Bengali; Bangla", "বাংলা" },
                    { "bih", "bh", "Bihari", "भोजपुरी" },
                    { "bis", "bi", "Bislama", "Bislama" },
                    { "bod", "bo", "Tibetan Standard, Tibetan, Central", "བོད་ཡིག" },
                    { "bos", "bs", "Bosnian", "bosanski jezik" },
                    { "bre", "br", "Breton", "brezhoneg" },
                    { "bul", "bg", "Bulgarian", "български език" },
                    { "cat", "ca", "Catalan; Valencian", "català, valencià" },
                    { "ces", "cs", "Czech", "čeština, český jazyk" },
                    { "cha", "ch", "Chamorro", "Chamoru" },
                    { "che", "ce", "Chechen", "нохчийн мотт" },
                    { "chu", "cu", "Old Church Slavonic, Church Slavonic, Old Bulgarian", "ѩзыкъ словѣньскъ" },
                    { "chv", "cv", "Chuvash", "чӑваш чӗлхи" },
                    { "cor", "kw", "Cornish", "Kernewek" },
                    { "cos", "co", "Corsican", "corsu, lingua corsa" },
                    { "azb", "az", "South Azerbaijani", "تورکجه‎" },
                    { "aym", "ay", "Aymara", "aymar aru" },
                    { "aze", "az", "Azerbaijani", "azərbaycan dili" },
                    { "ava", "av", "Avaric", "авар мацӀ, магӀарул мацӀ" },
                    { "slk", "sk", "Slovak", "slovenčina, slovenský jazyk" },
                    { "sin", "si", "Sinhala, Sinhalese", "සිංහල" },
                    { "san", "sa", "Sanskrit (Saṁskṛta)", "संस्कृतम्" },
                    { "sag", "sg", "Sango", "yângâ tî sängö" },
                    { "rus", "ru", "Russian", "русский язык" },
                    { "run", "rn", "Kirundi", "Ikirundi" },
                    { "ave", "ae", "Avestan", "avesta" },
                    { "roh", "rm", "Romansh", "rumantsch grischun" },
                    { "que", "qu", "Quechua", "Runa Simi, Kichwa" },
                    { "ron", "ro", "Romanian", "limba română" },
                    { "por", "pt", "Portuguese", "português" },
                    { "aar", "aa", "Afar", "Afaraf" },
                    { "abk", "ab", "Abkhaz", "аҧсуа бызшәа, аҧсшәа" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Code3", "Code2", "Name", "NativeName" },
                values: new object[,]
                {
                    { "afr", "af", "Afrikaans", "Afrikaans" },
                    { "aka", "ak", "Akan", "Akan" },
                    { "amh", "am", "Amharic", "አማርኛ" },
                    { "ara", "ar", "Arabic", "العربية" },
                    { "arg", "an", "Aragonese", "aragonés" },
                    { "asm", "as", "Assamese", "অসমীয়া" },
                    { "pus", "ps", "Pashto, Pushto", "پښتو" },
                    { "pli", "pi", "Pāli", "पाऴि" }
                });

            migrationBuilder.InsertData(
                table: "Provider",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "OnlyFans" },
                    { 2, "Instagram" },
                    { 3, "SnapChat" },
                    { 4, "Facebook" },
                    { 5, "TikTok" }
                });

            migrationBuilder.InsertData(
                table: "StateProvince",
                columns: new[] { "Id", "Abbrev", "Code", "Iso2", "Name" },
                values: new object[,]
                {
                    { 42, "S.D.", "SD", null, "South Dakota" },
                    { 51, "Wyo.", "WY", null, "Wyoming" },
                    { 23, "Mich.", "MI", null, "Michigan" },
                    { 22, "Mass.", "MA", null, "Massachusetts" },
                    { 21, "Md.", "MD", null, "Maryland" },
                    { 20, "Maine", "ME", null, "Maine" },
                    { 19, "La.", "LA", null, "Louisiana" },
                    { 18, "Ky.", "KY", null, "Kentucky" },
                    { 17, "Kans.", "KS", null, "Kansas" },
                    { 16, "Iowa", "IA", null, "Iowa" },
                    { 15, "Ind.", "IN", null, "Indiana" },
                    { 14, "Ill.", "IL", null, "Illinois" },
                    { 24, "Minn.", "MN", null, "Minnesota" },
                    { 13, "Idaho", "ID", null, "Idaho" },
                    { 11, "Ga.", "GA", null, "Georgia" },
                    { 10, "Fla.", "FL", null, "Florida" },
                    { 9, "D.C.", "DC", null, "District of Columbia" },
                    { 8, "Del.", "DE", null, "Delaware" },
                    { 7, "Conn.", "CT", null, "Connecticut" },
                    { 6, "Colo.", "CO", null, "Colorado" },
                    { 5, "Calif.", "CA", null, "California" },
                    { 4, "Ark.", "AR", null, "Arkansas" },
                    { 3, "Ariz.", "AZ", null, "Arizona" },
                    { 2, "Alaska", "AK", null, "Alaska" },
                    { 12, "Hawaii", "HI", null, "Hawaii" },
                    { 25, "Miss.", "MS", null, "Mississippi" },
                    { 1, "Ala.", "AL", null, "Alabama" },
                    { 27, "Mont.", "MT", null, "Montana" },
                    { 26, "Mo.", "MO", null, "Missouri" }
                });

            migrationBuilder.InsertData(
                table: "StateProvince",
                columns: new[] { "Id", "Abbrev", "Code", "Iso2", "Name" },
                values: new object[,]
                {
                    { 49, "W.Va.", "WV", null, "West Virginia" },
                    { 48, "Wash.", "WA", null, "Washington" },
                    { 47, "Va.", "VA", null, "Virginia" },
                    { 46, "Vt.", "VT", null, "Vermont" },
                    { 45, "Utah", "UT", null, "Utah" },
                    { 44, "Tex.", "TX", null, "Texas" },
                    { 43, "Tenn.", "TN", null, "Tennessee" },
                    { 41, "S.C.", "SC", null, "South Carolina" },
                    { 40, "R.I.", "RI", null, "Rhode Island" },
                    { 39, "Pa.", "PA", null, "Pennsylvania" },
                    { 50, "Wis.", "WI", null, "Wisconsin" },
                    { 37, "Okla.", "OK", null, "Oklahoma" },
                    { 36, "Ohio", "OH", null, "Ohio" },
                    { 28, "Nebr.", "NE", null, "Nebraska" },
                    { 35, "N.D.", "ND", null, "North Dakota" },
                    { 34, "N.C.", "NC", null, "North Carolina" },
                    { 33, "N.Y.", "NY", null, "New York" },
                    { 32, "N.M.", "NM", null, "New Mexico" },
                    { 31, "N.J.", "NJ", null, "New Jersey" },
                    { 30, "N.H.", "NH", null, "New Hampshire" },
                    { 29, "Nev.", "NV", null, "Nevada" },
                    { 38, "Ore.", "OR", null, "Oregon" }
                });

            migrationBuilder.InsertData(
                table: "Timezone",
                columns: new[] { "Code", "Name", "Value" },
                values: new object[,]
                {
                    { "MYT", "Malaysia Time", "+08" },
                    { "MVT", "Maldives Time", "+05" },
                    { "MUT", "Mauritius Time", "+04" },
                    { "MMT", "Myanmar Standard Time", "+06:30" },
                    { "MST", "Malaysia Standard Time", "+08" },
                    { "MSK", "Moscow Time", "+03" },
                    { "NCT", "New Caledonia Time", "+11" },
                    { "MIT", "Marquesas Islands Time", "-09:30" },
                    { "MST", "Mountain Standard Time (North America)", "-07" },
                    { "NDT", "Newfoundland Daylight Time", "-02:30" },
                    { "NUT", "Niue Time", "-11" },
                    { "NPT", "Nepal Time", "+05:45" },
                    { "NST", "Newfoundland Standard Time", "-03:30" },
                    { "NT", "Newfoundland Time", "-03:30" },
                    { "NZDT", "New Zealand Daylight Time", "+13" },
                    { "NZST", "New Zealand Standard Time", "+12" },
                    { "OMST", "Omsk Time", "+06" },
                    { "ORAT", "Oral Time", "+05" },
                    { "PDT", "Pacific Daylight Time (North America)", "-07" },
                    { "PET", "Peru Time", "-05" }
                });

            migrationBuilder.InsertData(
                table: "Timezone",
                columns: new[] { "Code", "Name", "Value" },
                values: new object[,]
                {
                    { "MIST", "Macquarie Island Station Time", "+11" },
                    { "PETT", "Kamchatka Time", "+12" },
                    { "NFT", "Norfolk Time", "+11" },
                    { "MHT", "Marshall Islands", "+12" },
                    { "KOST", "Kosrae Time", "+11" },
                    { "MET", "Middle European Time Same zone as CET", "+01" },
                    { "HOVST", "Khovd Summer Time", "+08" },
                    { "PGT", "Papua New Guinea Time", "+10" },
                    { "HOVT", "Khovd Standard Time", "+07" },
                    { "ICT", "Indochina Time", "+07" },
                    { "IDT", "Israel Daylight Time", "+03" },
                    { "IOT", "Indian Ocean Time", "+03" },
                    { "IRDT", "Iran Daylight Time", "+04:30" },
                    { "IRKT", "Irkutsk Time", "+08" },
                    { "IRST", "Iran Standard Time", "+03:30" },
                    { "IST", "Indian Standard Time", "+05:30" },
                    { "IST", "Irish Standard Time[6]", "+01" },
                    { "IST", "Israel Standard Time", "+02" },
                    { "JST", "Japan Standard Time", "+09" },
                    { "KGT", "Kyrgyzstan time", "+06" },
                    { "KRAT", "Krasnoyarsk Time", "+07" },
                    { "KST", "Korea Standard Time", "+09" },
                    { "LHST", "Lord Howe Standard Time", "+10:30" },
                    { "LHST", "Lord Howe Summer Time", "+11" },
                    { "LINT", "Line Islands Time", "+14" },
                    { "MAGT", "Magadan Time", "+12" },
                    { "MART", "Marquesas Islands Time", "-09:30" },
                    { "MAWT", "Mawson Station Time", "+05" },
                    { "MDT", "Mountain Daylight Time (North America)", "-06" },
                    { "MEST", "Middle European Summer Time Same zone as CEST", "+02" },
                    { "PHOT", "Phoenix Island Time", "+13" },
                    { "THA", "Thailand Standard Time", "+07" },
                    { "PKT", "Pakistan Standard Time", "+05" },
                    { "TMT", "Turkmenistan Time", "+05" },
                    { "TRT", "Turkey Time", "+03" },
                    { "TOT", "Tonga Time", "+13" },
                    { "TVT", "Tuvalu Time", "+12" },
                    { "ULAST", "Ulaanbaatar Summer Time", "+09" },
                    { "ULAT", "Ulaanbaatar Standard Time", "+08" },
                    { "USZ1", "Kaliningrad Time", "+02" },
                    { "", "Coordinated Universal Time", "±00" },
                    { "UYST", "Uruguay Summer Time", "-02" }
                });

            migrationBuilder.InsertData(
                table: "Timezone",
                columns: new[] { "Code", "Name", "Value" },
                values: new object[,]
                {
                    { "UYT", "Uruguay Standard Time", "-03" },
                    { "UZT", "Uzbekistan Time", "+05" },
                    { "WST", "Western Standard Time", "+08" },
                    { "WIT", "Western Indonesian Time", "+07" },
                    { "WET", "Western European Time", "±00" },
                    { "WEST", "Western European Summer Time", "+01" },
                    { "WAT", "West Africa Time", "+01" },
                    { "WAST", "West Africa Summer Time", "+02" },
                    { "WAKT", "Wake Island Time", "+12" },
                    { "VUT", "Vanuatu Time", "+11" },
                    { "VOST", "Vostok Station Time", "+06" },
                    { "VOLT", "Volgograd Time", "+04" },
                    { "VLAT", "Vladivostok Time", "+10" },
                    { "HMT", "Heard and McDonald Islands Time", "+05" },
                    { "TLT", "Timor Leste Time", "+09" },
                    { "PHT", "Philippine Time", "+08" },
                    { "TKT", "Tokelau Time", "+13" },
                    { "TFT", "Indian/Kerguelen", "+05" },
                    { "PMDT", "Saint Pierre and Miquelon Daylight time", "-02" },
                    { "PMST", "Saint Pierre and Miquelon Standard Time", "-03" },
                    { "PONT", "Pohnpei Standard Time", "+11" },
                    { "PST", "Pacific Standard Time (North America)", "-08" },
                    { "PST", "Philippine Standard Time", "+08" },
                    { "PYST", "Paraguay Summer Time (South America)[7]", "-03" },
                    { "PYT", "Paraguay Time (South America)[8]", "-04" },
                    { "RET", "Réunion Time", "+04" },
                    { "ROTT", "Rothera Research Station Time", "-03" },
                    { "SAKT", "Sakhalin Island time", "+11" },
                    { "SAMT", "Samara Time", "+04" },
                    { "SAST", "South African Standard Time", "+02" },
                    { "SBT", "Solomon Islands Time", "+11" },
                    { "SCT", "Seychelles Time", "+04" },
                    { "SGT", "Singapore Time", "+08" },
                    { "SLST", "Sri Lanka Standard Time", "+05:30" },
                    { "SRET", "Srednekolymsk Time", "+11" },
                    { "SRT", "Suriname Time", "-03" },
                    { "SST", "Samoa Standard Time", "-11" },
                    { "SST", "Singapore Standard Time", "+08" },
                    { "SYOT", "Showa Station Time", "+03" },
                    { "TAHT", "Tahiti Time", "-10" },
                    { "VET", "Venezuelan Standard Time", "-04" },
                    { "TJT", "Tajikistan Time", "+05" }
                });

            migrationBuilder.InsertData(
                table: "Timezone",
                columns: new[] { "Code", "Name", "Value" },
                values: new object[,]
                {
                    { "HKT", "Hong Kong Time", "+08" },
                    { "YEKT", "Yekaterinburg Time", "+05" },
                    { "HAEC", "Heure Avancée d'Europe Centrale francised name for CEST", "+02" },
                    { "BOT", "Bolivia Time", "-04" },
                    { "BRST", "Brasilia Summer Time", "-02" },
                    { "BRT", "Brasilia Time", "-03" },
                    { "BST", "Bangladesh Standard Time", "+06" },
                    { "BST", "Bougainville Standard Time[3]", "+11" },
                    { "BST", "British Summer Time (British Standard Time from Feb 1968 to Oct 1971)", "+01" },
                    { "BTT", "Bhutan Time", "+06" },
                    { "CAT", "Central Africa Time", "+02" },
                    { "CCT", "Cocos Islands Time", "+06:30" },
                    { "BIT", "Baker Island Time", "-12" },
                    { "CDT", "Central Daylight Time (North America)", "-05" },
                    { "CEST", "Central European Summer Time (Cf. HAEC)", "+02" },
                    { "CET", "Central European Time", "+01" },
                    { "CHADT", "Chatham Daylight Time", "+13:45" },
                    { "CHAST", "Chatham Standard Time", "+12:45" },
                    { "CHOT", "Choibalsan Standard Time", "+08" },
                    { "HAST", "Hawaii-Aleutian Standard Time", "-10" },
                    { "CHST", "Chamorro Standard Time", "+10" },
                    { "CHUT", "Chuuk Time", "+10" },
                    { "CIST", "Clipperton Island Standard Time", "-08" },
                    { "CDT", "Cuba Daylight Time[4]", "-04" },
                    { "CIT", "Central Indonesia Time", "+08" },
                    { "BIOT", "British Indian Ocean Time", "+06" },
                    { "AZT", "Azerbaijan Time", "+04" },
                    { "YAKT", "Yakutsk Time", "+09" },
                    { "ACDT", "Australian Central Daylight Savings Time", "+10:30" },
                    { "ACST", "Australian Central Standard Time", "+09:30" },
                    { "ACT", "Acre Time", "-05" },
                    { "ACT", "ASEAN Common Time", "+06:30 - +09" },
                    { "ADT", "Atlantic Daylight Time", "-03" },
                    { "AEDT", "Australian Eastern Daylight Savings Time", "+11" },
                    { "AEST", "Australian Eastern Standard Time", "+10" },
                    { "AFT", "Afghanistan Time", "+04:30" },
                    { "BDT", "Brunei Time", "+08" },
                    { "AKDT", "Alaska Daylight Time", "-08" },
                    { "AMST", "Amazon Summer Time (Brazil)[1]", "-03" },
                    { "AMT", "Amazon Time (Brazil)[2]", "-04" },
                    { "AMT", "Armenia Time", "+04" },
                    { "ART", "Argentina Time", "-03" }
                });

            migrationBuilder.InsertData(
                table: "Timezone",
                columns: new[] { "Code", "Name", "Value" },
                values: new object[,]
                {
                    { "AST", "Arabia Standard Time", "+03" },
                    { "AST", "Atlantic Standard Time", "-04" },
                    { "AWST", "Australian Western Standard Time", "+08" },
                    { "AZOST", "Azores Summer Time", "±00" },
                    { "AZOT", "Azores Standard Time", "-01" },
                    { "AKST", "Alaska Standard Time", "-09" },
                    { "CKT", "Cook Island Time", "-10" },
                    { "CHOST", "Choibalsan Summer Time", "+09" },
                    { "CLT", "Chile Standard Time", "-04" },
                    { "EGT", "Eastern Greenland Time", "-01" },
                    { "EIT", "Eastern Indonesian Time", "+09" },
                    { "EST", "Eastern Standard Time (North America)", "-05" },
                    { "CLST", "Chile Summer Time", "-03" },
                    { "FET", "Further-eastern European Time", "+03" },
                    { "FJT", "Fiji Time", "+12" },
                    { "FKST", "Falkland Islands Summer Time", "-03" },
                    { "FKT", "Falkland Islands Time", "-04" },
                    { "FNT", "Fernando de Noronha Time", "-02" },
                    { "EGST", "Eastern Greenland Summer Time", "±00" },
                    { "GALT", "Galapagos Time", "-06" },
                    { "GET", "Georgia Standard Time", "+04" },
                    { "GFT", "French Guiana Time", "-03" },
                    { "GILT", "Gilbert Island Time", "+12" },
                    { "GIT", "Gambier Island Time", "-09" },
                    { "GMT", "Greenwich Mean Time", "±00" },
                    { "GST", "South Georgia and the South Sandwich Islands", "-02" },
                    { "GST", "Gulf Standard Time", "+04" },
                    { "GYT", "Guyana Time", "-04" },
                    { "HADT", "Hawaii-Aleutian Daylight Time", "-09" },
                    { "GAMT", "Gambier Islands", "-09" },
                    { "EET", "Eastern European Time", "+02" },
                    { "AEST", "Eastern Standard Time (Australia)", "+10" },
                    { "AEDT", "Eastern Summer Time (Australia)", "+11" },
                    { "COST", "Colombia Summer Time", "-04" },
                    { "COT", "Colombia Time", "-05" },
                    { "CST", "Central Standard Time (North America)", "-06" },
                    { "CST", "China Standard Time", "+08" },
                    { "EEST", "Eastern European Summer Time", "+03" },
                    { "ACDT", "Central Summer Time (Australia)", "+10:30" },
                    { "CST", "Cuba Standard Time", "-05" },
                    { "CT", "China time", "+08" },
                    { "CVT", "Cape Verde Time", "-01" }
                });

            migrationBuilder.InsertData(
                table: "Timezone",
                columns: new[] { "Code", "Name", "Value" },
                values: new object[,]
                {
                    { "CWST", "Central Western Standard Time (Australia) unofficial", "+08:45" },
                    { "ACST", "Central Standard Time (Australia)", "+09:30" },
                    { "DAVT", "Davis Time", "+07" },
                    { "DDUT", "Dumont d'Urville Time", "+10" },
                    { "DFT", "AIX specific equivalent of Central European Time[5]", "+01" },
                    { "EASST", "Easter Island Summer Time", "-05" },
                    { "EAST", "Easter Island Standard Time", "-06" },
                    { "EAT", "East Africa Time", "+03" },
                    { "ECT", "Eastern Caribbean Time (does not recognise DST)", "-04" },
                    { "ECT", "Ecuador Time", "-05" },
                    { "EDT", "Eastern Daylight Time (North America)", "-04" },
                    { "CXT", "Christmas Island Time", "+07" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ApiScope",
                columns: new[] { "Id", "Description", "DisplayName", "Emphasize", "Enabled", "Name", "Required", "ShowInDiscoveryDocument" },
                values: new object[] { 1, null, "My API", false, true, "api1", false, true });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "Client",
                columns: new[] { "Id", "AbsoluteRefreshTokenLifetime", "AccessTokenLifetime", "AccessTokenType", "AllowAccessTokensViaBrowser", "AllowOfflineAccess", "AllowPlainTextPkce", "AllowRememberConsent", "AllowedIdentityTokenSigningAlgorithms", "AlwaysIncludeUserClaimsInIdToken", "AlwaysSendClientClaims", "AuthorizationCodeLifetime", "BackChannelLogoutSessionRequired", "BackChannelLogoutUri", "ClientClaimsPrefix", "ClientId", "ClientName", "ClientUri", "ConsentLifetime", "Created", "Description", "DeviceCodeLifetime", "EnableLocalLogin", "Enabled", "FrontChannelLogoutSessionRequired", "FrontChannelLogoutUri", "IdentityTokenLifetime", "IncludeJwtId", "LastAccessed", "LogoUri", "NonEditable", "PairWiseSubjectSalt", "ProtocolType", "RefreshTokenExpiration", "RefreshTokenUsage", "RequireClientSecret", "RequireConsent", "RequirePkce", "RequireRequestObject", "SlidingRefreshTokenLifetime", "UpdateAccessTokenClaimsOnRefresh", "Updated", "UserCodeType", "UserSsoLifetime" },
                values: new object[,]
                {
                    { 4, 2592000, 3600, 0, false, false, false, true, null, true, false, 300, true, null, "client_", "js", "JavaScript Client", null, null, new DateTime(2021, 9, 18, 13, 12, 13, 653, DateTimeKind.Unspecified).AddTicks(7956), null, 300, true, true, true, null, 300, true, null, null, false, null, "oidc", 1, 1, false, false, true, false, 1296000, false, null, null, null },
                    { 3, 2592000, 3600, 0, false, false, false, true, null, true, true, 300, true, null, "client_", "mvc", null, null, null, new DateTime(2021, 9, 18, 13, 12, 13, 645, DateTimeKind.Unspecified).AddTicks(5968), null, 300, true, true, true, null, 300, true, null, null, false, null, "oidc", 1, 1, true, false, true, false, 1296000, false, null, null, null },
                    { 2, 2592000, 3600, 0, false, false, false, true, null, true, true, 300, true, null, "client_", "client", null, null, null, new DateTime(2021, 9, 18, 13, 12, 13, 642, DateTimeKind.Unspecified).AddTicks(7421), null, 300, true, true, true, null, 300, true, null, null, false, null, "oidc", 1, 1, true, false, true, false, 1296000, false, null, null, null },
                    { 1, 2592000, 400000, 0, false, false, false, true, null, true, true, 300, true, null, "", "postman", null, null, null, new DateTime(2021, 9, 18, 13, 12, 13, 532, DateTimeKind.Unspecified).AddTicks(8105), null, 300, true, true, true, null, 300, true, null, null, false, null, "oidc", 1, 1, true, false, true, false, 1296000, false, null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "IdentityResource",
                columns: new[] { "Id", "Created", "Description", "DisplayName", "Emphasize", "Enabled", "Name", "NonEditable", "Required", "ShowInDiscoveryDocument", "Updated" },
                values: new object[,]
                {
                    { 5, new DateTime(2021, 9, 17, 3, 58, 20, 185, DateTimeKind.Unspecified).AddTicks(7082), null, "Consumer", false, true, "consumer", false, true, true, null },
                    { 4, new DateTime(2021, 9, 17, 3, 58, 20, 185, DateTimeKind.Unspecified).AddTicks(7082), null, "Producer", false, true, "producer", false, true, true, null },
                    { 3, new DateTime(2021, 9, 17, 3, 58, 20, 185, DateTimeKind.Unspecified).AddTicks(7082), null, "Admin", false, true, "admin", false, true, true, null },
                    { 2, new DateTime(2021, 9, 17, 3, 58, 20, 185, DateTimeKind.Unspecified).AddTicks(7082), null, "Your user identifier", false, true, "openid", false, true, true, null },
                    { 1, new DateTime(2021, 9, 17, 3, 58, 20, 206, DateTimeKind.Unspecified).AddTicks(3232), "Your user profile information (first name, last name, etc.)", "User profile", true, true, "profile", false, false, true, null },
                    { 7, new DateTime(2021, 9, 17, 3, 58, 20, 185, DateTimeKind.Unspecified).AddTicks(7082), null, "Editor", false, true, "editor", false, true, true, null },
                    { 6, new DateTime(2021, 9, 17, 3, 58, 20, 185, DateTimeKind.Unspecified).AddTicks(7082), null, "Model", false, true, "model", false, true, true, null }
                });

            migrationBuilder.InsertData(
                table: "EnabledCountry",
                column: "Iso2",
                value: "US");

            migrationBuilder.InsertData(
                table: "LanguageCountry",
                columns: new[] { "Code3", "Iso2", "Default" },
                values: new object[] { "eng", "US", true });

            migrationBuilder.InsertData(
                table: "ProviderCapability",
                columns: new[] { "CapabilityId", "ProviderId" },
                values: new object[,]
                {
                    { 2, 5 },
                    { 2, 4 },
                    { 1, 4 },
                    { 2, 3 },
                    { 1, 3 },
                    { 2, 2 },
                    { 1, 2 },
                    { 2, 1 },
                    { 1, 1 },
                    { 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "TaskMaster",
                columns: new[] { "Id", "Description", "ProviderId", "Recurrence", "TaskType", "Title" },
                values: new object[] { 1, "Description Here...", 1, "", 1, "Verify your OnlyFans Account" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "Code3", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Iso2", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "eng", "20f1b6e7-64b7-4658-9f5a-ca9b73da374e", "admin@admin.com", true, "Rod", "US", "Johnson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEIVVeEi6VZ2YB3JUwyExMUFOL9E6rS4Px8AHXK0osa6ncEsGkS0mFtBesBmGurNFuA==", "123-123-1234", false, "", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientCorsOrigin",
                columns: new[] { "Id", "ClientId", "Origin" },
                values: new object[] { 1, 4, "https://localhost:5003" });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientGrantType",
                columns: new[] { "Id", "ClientId", "GrantType" },
                values: new object[,]
                {
                    { 2, 4, "authorization_code" },
                    { 1, 1, "password" },
                    { 3, 2, "client_credentials" },
                    { 4, 3, "authorization_code" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri",
                columns: new[] { "Id", "ClientId", "PostLogoutRedirectUri" },
                values: new object[,]
                {
                    { 1, 3, "https://localhost:5002/signout-callback-oidc" },
                    { 2, 4, "https://localhost:5003/index.html" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientRedirectUri",
                columns: new[] { "Id", "ClientId", "RedirectUri" },
                values: new object[,]
                {
                    { 1, 3, "https://localhost:5002/signin-oidc" },
                    { 2, 4, "https://localhost:5003/callback.html" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientScopes",
                columns: new[] { "Id", "ClientId", "Scope" },
                values: new object[,]
                {
                    { 3, 3, "api1" },
                    { 1, 3, "openid" },
                    { 15, 1, "consumer" },
                    { 14, 1, "editor" },
                    { 13, 1, "producer" },
                    { 12, 1, "model" },
                    { 11, 1, "admin" },
                    { 4, 1, "api1" },
                    { 5, 1, "profile" },
                    { 2, 2, "api1" },
                    { 9, 4, "api1" },
                    { 8, 4, "profile" },
                    { 7, 4, "openid" },
                    { 10, 3, "profile" },
                    { 6, 1, "openid" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientSecret",
                columns: new[] { "Id", "ClientId", "Created", "Description", "Expiration", "Type", "Value" },
                values: new object[,]
                {
                    { 3, 3, new DateTime(2021, 9, 17, 13, 19, 6, 568, DateTimeKind.Unspecified).AddTicks(1345), null, null, "SharedSecret", "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=" },
                    { 1, 1, new DateTime(2021, 9, 17, 13, 19, 6, 414, DateTimeKind.Unspecified).AddTicks(3771), null, null, "SharedSecret", "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=" },
                    { 2, 2, new DateTime(2021, 9, 17, 13, 19, 6, 564, DateTimeKind.Unspecified).AddTicks(8731), null, null, "SharedSecret", "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "IdentityResourceClaim",
                columns: new[] { "Id", "IdentityResourceId", "Type" },
                values: new object[] { 10, 1, "gender" });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "IdentityResourceClaim",
                columns: new[] { "Id", "IdentityResourceId", "Type" },
                values: new object[,]
                {
                    { 14, 1, "updated_at" },
                    { 13, 1, "locale" },
                    { 12, 1, "zoneinfo" },
                    { 11, 1, "birthdate" },
                    { 9, 1, "name" },
                    { 8, 1, "family_name" },
                    { 7, 1, "given_name" },
                    { 6, 1, "middle_name" },
                    { 5, 1, "nickname" },
                    { 4, 1, "preferred_username" },
                    { 3, 1, "profile" },
                    { 2, 1, "picture" },
                    { 15, 2, "sub" },
                    { 1, 1, "website" }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Consumer",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Editor",
                columns: new[] { "Id", "DisplayName" },
                values: new object[] { 1, null });

            migrationBuilder.InsertData(
                table: "Model",
                columns: new[] { "Id", "Description", "DisplayName" },
                values: new object[] { 1, "Test Description", "Rod Johnson" });

            migrationBuilder.InsertData(
                table: "Producer",
                column: "Id",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_ApiResource_Name",
                schema: "IdentityServer",
                table: "ApiResource",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceClaim_ApiResourceId",
                schema: "IdentityServer",
                table: "ApiResourceClaim",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceProperty_ApiResourceId",
                schema: "IdentityServer",
                table: "ApiResourceProperty",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceScope_ApiResourceId",
                schema: "IdentityServer",
                table: "ApiResourceScope",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceSecret_ApiResourceId",
                schema: "IdentityServer",
                table: "ApiResourceSecret",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiScope_Name",
                schema: "IdentityServer",
                table: "ApiScope",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiScopeClaim_ScopeId",
                schema: "IdentityServer",
                table: "ApiScopeClaim",
                column: "ScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiScopeProperty_ScopeId",
                schema: "IdentityServer",
                table: "ApiScopeProperty",
                column: "ScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelIntent_ChannelId",
                table: "ChannelIntent",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelMediaSet_MediaSetId",
                table: "ChannelMediaSet",
                column: "MediaSetId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelProvider_ProviderId",
                table: "ChannelProvider",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelSubscription_ConsumerId",
                table: "ChannelSubscription",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClientId",
                schema: "IdentityServer",
                table: "Client",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientClaim_ClientId",
                schema: "IdentityServer",
                table: "ClientClaim",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCorsOrigin_ClientId",
                schema: "IdentityServer",
                table: "ClientCorsOrigin",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientGrantType_ClientId",
                schema: "IdentityServer",
                table: "ClientGrantType",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientIdPRestriction_ClientId",
                schema: "IdentityServer",
                table: "ClientIdPRestriction",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPostLogoutRedirectUri_ClientId",
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientProperty_ClientId",
                schema: "IdentityServer",
                table: "ClientProperty",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientRedirectUri_ClientId",
                schema: "IdentityServer",
                table: "ClientRedirectUri",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientScopes_ClientId",
                schema: "IdentityServer",
                table: "ClientScopes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientSecret_ClientId",
                schema: "IdentityServer",
                table: "ClientSecret",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ConsumerId",
                table: "Comment",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_MediaSetId",
                table: "Comment",
                column: "MediaSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Content_ContentDumpId",
                table: "Content",
                column: "ContentDumpId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Iso2",
                table: "Country",
                column: "Iso2");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Iso3",
                table: "Country",
                column: "Iso3");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceFlowCodes_DeviceCode",
                schema: "IdentityServer",
                table: "DeviceFlowCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceFlowCodes_Expiration",
                schema: "IdentityServer",
                table: "DeviceFlowCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_Dump_AdminId",
                table: "Dump",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Dump_EditorId",
                table: "Dump",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Dump_ProducerId",
                table: "Dump",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_DumpModel_ModelId",
                table: "DumpModel",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DumpProvider_ContentDumpId",
                table: "DumpProvider",
                column: "ContentDumpId");

            migrationBuilder.CreateIndex(
                name: "IX_DumpSession_EditingSessionId",
                table: "DumpSession",
                column: "EditingSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_EditorModel_EditorId",
                table: "EditorModel",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_EditSession_EditorId",
                table: "EditSession",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteEditor_EditorId",
                table: "FavoriteEditor",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedModel_ModelId",
                table: "FeaturedModel",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResource_Name",
                schema: "IdentityServer",
                table: "IdentityResource",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResourceClaim_IdentityResourceId",
                schema: "IdentityServer",
                table: "IdentityResourceClaim",
                column: "IdentityResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResourceProperty_IdentityResourceId",
                schema: "IdentityServer",
                table: "IdentityResourceProperty",
                column: "IdentityResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageCountry_Code3",
                table: "LanguageCountry",
                column: "Code3");

            migrationBuilder.CreateIndex(
                name: "IX_Media_MediaSetId",
                table: "Media",
                column: "MediaSetId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaApproval_AdminId",
                table: "MediaApproval",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaSet_EditorId",
                table: "MediaSet",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaSet_ProducerId",
                table: "MediaSet",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaSetProvider_MediaSetId",
                table: "MediaSetProvider",
                column: "MediaSetId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelExcludedCountry_Iso2",
                table: "ModelExcludedCountry",
                column: "Iso2");

            migrationBuilder.CreateIndex(
                name: "IX_ModelMediaSet_ModelId",
                table: "ModelMediaSet",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelProvider_ProviderId",
                table: "ModelProvider",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelSubscription_ConsumerId",
                table: "ModelSubscription",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                schema: "IdentityServer",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                schema: "IdentityServer",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                schema: "IdentityServer",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_ProducerModel_ModelId",
                table: "ProducerModel",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderCapability_CapabilityId",
                table: "ProviderCapability",
                column: "CapabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_StateProvince_Iso2",
                table: "StateProvince",
                column: "Iso2");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ModelId",
                table: "Task",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskMasterId",
                table: "Task",
                column: "TaskMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskMaster_ProviderId",
                table: "TaskMaster",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Code3",
                table: "User",
                column: "Code3");

            migrationBuilder.CreateIndex(
                name: "IX_User_Iso2",
                table: "User",
                column: "Iso2");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "ApiResourceClaim",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ApiResourceProperty",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ApiResourceScope",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ApiResourceSecret",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ApiScopeClaim",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ApiScopeProperty",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ChannelIntent");

            migrationBuilder.DropTable(
                name: "ChannelMediaSet");

            migrationBuilder.DropTable(
                name: "ChannelProvider");

            migrationBuilder.DropTable(
                name: "ChannelSubscription");

            migrationBuilder.DropTable(
                name: "ClientClaim",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientCorsOrigin",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientGrantType",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientIdPRestriction",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientPostLogoutRedirectUri",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientProperty",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientRedirectUri",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientScopes",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientSecret",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "DeviceFlowCodes",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "DumpModel");

            migrationBuilder.DropTable(
                name: "DumpProvider");

            migrationBuilder.DropTable(
                name: "DumpSession");

            migrationBuilder.DropTable(
                name: "EditorModel");

            migrationBuilder.DropTable(
                name: "EnabledCountry");

            migrationBuilder.DropTable(
                name: "FavoriteEditor");

            migrationBuilder.DropTable(
                name: "FeaturedModel");

            migrationBuilder.DropTable(
                name: "IdentityResourceClaim",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "IdentityResourceProperty",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "LanguageCountry");

            migrationBuilder.DropTable(
                name: "MediaApproval");

            migrationBuilder.DropTable(
                name: "MediaSetProvider");

            migrationBuilder.DropTable(
                name: "MediaTag");

            migrationBuilder.DropTable(
                name: "ModelExcludedCountry");

            migrationBuilder.DropTable(
                name: "ModelMediaSet");

            migrationBuilder.DropTable(
                name: "ModelProvider");

            migrationBuilder.DropTable(
                name: "ModelSubscription");

            migrationBuilder.DropTable(
                name: "PersistedGrants",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "ProducerModel");

            migrationBuilder.DropTable(
                name: "ProviderCapability");

            migrationBuilder.DropTable(
                name: "StateProvince");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Timezone");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "ApiResource",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ApiScope",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "Channel");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "Dump");

            migrationBuilder.DropTable(
                name: "EditSession");

            migrationBuilder.DropTable(
                name: "IdentityResource",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "Consumer");

            migrationBuilder.DropTable(
                name: "Capability");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "TaskMaster");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "MediaSet");

            migrationBuilder.DropTable(
                name: "Editor");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
