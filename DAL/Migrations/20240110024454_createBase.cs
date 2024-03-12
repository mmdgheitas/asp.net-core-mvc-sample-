using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class createBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    family = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    post = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seller = table.Column<bool>(type: "bit", nullable: false),
                    seller_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_melli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sells = table.Column<int>(type: "int", nullable: false),
                    shomare_cart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pris = table.Column<int>(type: "int", nullable: false),
                    code_mahsoul = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fieInBox = table.Column<int>(type: "int", nullable: false),
                    warranty = table.Column<bool>(type: "bit", nullable: false),
                    warrantyTime = table.Column<int>(type: "int", nullable: false),
                    img_src = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sellerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    exist = table.Column<bool>(type: "bit", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percent = table.Column<int>(type: "int", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "itemsDelete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pris = table.Column<int>(type: "int", nullable: false),
                    code_mahsoul = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fieInBox = table.Column<int>(type: "int", nullable: false),
                    warranty = table.Column<bool>(type: "bit", nullable: false),
                    warrantyTime = table.Column<int>(type: "int", nullable: false),
                    img_src = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sellerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    exist = table.Column<bool>(type: "bit", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percent = table.Column<int>(type: "int", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemsDelete", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "index",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    banner1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    src_banner1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    banner2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    src_banner2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    banner3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    src_banner3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    footer1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    src_footer1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    footer2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    src_footer2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vec1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vec2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vec3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vec4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vec5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vec6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_index", x => x.id);
                    table.ForeignKey(
                        name: "FK_index_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    create_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notification_AspNetUsers_usersId",
                        column: x => x.usersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotificationDelete",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    create_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationDelete", x => x.id);
                    table.ForeignKey(
                        name: "FK_NotificationDelete_AspNetUsers_usersId",
                        column: x => x.usersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "soldsDelete",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trans_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_get = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_mahsoul = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tedad = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_posti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    pay = table.Column<bool>(type: "bit", nullable: false),
                    customerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    seller_idId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_soldsDelete", x => x.id);
                    table.ForeignKey(
                        name: "FK_soldsDelete_AspNetUsers_customerId",
                        column: x => x.customerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_soldsDelete_AspNetUsers_seller_idId",
                        column: x => x.seller_idId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartDelete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ItemsId = table.Column<int>(type: "int", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDelete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartDelete_AspNetUsers_usersId",
                        column: x => x.usersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartDelete_items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "codeTakhfif",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    itemsId = table.Column<int>(type: "int", nullable: true),
                    create_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_codeTakhfif", x => x.id);
                    table.ForeignKey(
                        name: "FK_codeTakhfif_AspNetUsers_usersId",
                        column: x => x.usersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_codeTakhfif_items_itemsId",
                        column: x => x.itemsId,
                        principalTable: "items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "codeTakhfifDelete",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    itemsId = table.Column<int>(type: "int", nullable: true),
                    create_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_codeTakhfifDelete", x => x.id);
                    table.ForeignKey(
                        name: "FK_codeTakhfifDelete_AspNetUsers_usersId",
                        column: x => x.usersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_codeTakhfifDelete_items_itemsId",
                        column: x => x.itemsId,
                        principalTable: "items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "likesDelete",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    item = table.Column<int>(type: "int", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_likesDelete", x => x.id);
                    table.ForeignKey(
                        name: "FK_likesDelete_AspNetUsers_usersId",
                        column: x => x.usersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_likesDelete_items_item",
                        column: x => x.item,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "solds",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trans_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_get = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tedad = table.Column<int>(type: "int", nullable: false),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_posti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    pay = table.Column<bool>(type: "bit", nullable: false),
                    itemsId = table.Column<int>(type: "int", nullable: true),
                    customerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    seller_idId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solds", x => x.id);
                    table.ForeignKey(
                        name: "FK_solds_AspNetUsers_customerId",
                        column: x => x.customerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_solds_AspNetUsers_seller_idId",
                        column: x => x.seller_idId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_solds_items_itemsId",
                        column: x => x.itemsId,
                        principalTable: "items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "votesDelete",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ok = table.Column<bool>(type: "bit", nullable: false),
                    admin = table.Column<bool>(type: "bit", nullable: false),
                    votesId = table.Column<int>(type: "int", nullable: true),
                    ItemsId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_votesDelete", x => x.id);
                    table.ForeignKey(
                        name: "FK_votesDelete_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_votesDelete_items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ItemsId = table.Column<int>(type: "int", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Items_deleteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_AspNetUsers_usersId",
                        column: x => x.usersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cart_items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_itemsDelete_Items_deleteId",
                        column: x => x.Items_deleteId,
                        principalTable: "itemsDelete",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "likes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    item = table.Column<int>(type: "int", nullable: false),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Items_deleteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_likes", x => x.id);
                    table.ForeignKey(
                        name: "FK_likes_AspNetUsers_usersId",
                        column: x => x.usersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_likes_items_item",
                        column: x => x.item,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_likes_itemsDelete_Items_deleteId",
                        column: x => x.Items_deleteId,
                        principalTable: "itemsDelete",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "votes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ok = table.Column<bool>(type: "bit", nullable: false),
                    admin = table.Column<bool>(type: "bit", nullable: false),
                    seen = table.Column<bool>(type: "bit", nullable: false),
                    votesId = table.Column<int>(type: "int", nullable: true),
                    ItemsId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    createTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Items_deleteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_votes", x => x.id);
                    table.ForeignKey(
                        name: "FK_votes_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_votes_items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_votes_itemsDelete_Items_deleteId",
                        column: x => x.Items_deleteId,
                        principalTable: "itemsDelete",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Items_deleteId",
                table: "Cart",
                column: "Items_deleteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ItemsId",
                table: "Cart",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_usersId",
                table: "Cart",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDelete_ItemsId",
                table: "CartDelete",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDelete_usersId",
                table: "CartDelete",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_codeTakhfif_itemsId",
                table: "codeTakhfif",
                column: "itemsId");

            migrationBuilder.CreateIndex(
                name: "IX_codeTakhfif_usersId",
                table: "codeTakhfif",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_codeTakhfifDelete_itemsId",
                table: "codeTakhfifDelete",
                column: "itemsId");

            migrationBuilder.CreateIndex(
                name: "IX_codeTakhfifDelete_usersId",
                table: "codeTakhfifDelete",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_index_userId",
                table: "index",
                column: "userId",
                unique: true,
                filter: "[userId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_likes_item",
                table: "likes",
                column: "item");

            migrationBuilder.CreateIndex(
                name: "IX_likes_Items_deleteId",
                table: "likes",
                column: "Items_deleteId");

            migrationBuilder.CreateIndex(
                name: "IX_likes_usersId",
                table: "likes",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_likesDelete_item",
                table: "likesDelete",
                column: "item");

            migrationBuilder.CreateIndex(
                name: "IX_likesDelete_usersId",
                table: "likesDelete",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_usersId",
                table: "Notification",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationDelete_usersId",
                table: "NotificationDelete",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_solds_customerId",
                table: "solds",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_solds_itemsId",
                table: "solds",
                column: "itemsId");

            migrationBuilder.CreateIndex(
                name: "IX_solds_seller_idId",
                table: "solds",
                column: "seller_idId");

            migrationBuilder.CreateIndex(
                name: "IX_soldsDelete_customerId",
                table: "soldsDelete",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_soldsDelete_seller_idId",
                table: "soldsDelete",
                column: "seller_idId");

            migrationBuilder.CreateIndex(
                name: "IX_votes_Items_deleteId",
                table: "votes",
                column: "Items_deleteId");

            migrationBuilder.CreateIndex(
                name: "IX_votes_ItemsId",
                table: "votes",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_votes_userId",
                table: "votes",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_votesDelete_ItemsId",
                table: "votesDelete",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_votesDelete_userId",
                table: "votesDelete",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "CartDelete");

            migrationBuilder.DropTable(
                name: "codeTakhfif");

            migrationBuilder.DropTable(
                name: "codeTakhfifDelete");

            migrationBuilder.DropTable(
                name: "index");

            migrationBuilder.DropTable(
                name: "likes");

            migrationBuilder.DropTable(
                name: "likesDelete");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "NotificationDelete");

            migrationBuilder.DropTable(
                name: "solds");

            migrationBuilder.DropTable(
                name: "soldsDelete");

            migrationBuilder.DropTable(
                name: "votes");

            migrationBuilder.DropTable(
                name: "votesDelete");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "itemsDelete");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "items");
        }
    }
}
