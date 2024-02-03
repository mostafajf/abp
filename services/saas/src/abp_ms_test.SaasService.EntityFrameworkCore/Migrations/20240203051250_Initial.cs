using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace abp_ms_test.SaasService.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayPaymentRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    Gateway = table.Column<string>(type: "text", nullable: true),
                    FailReason = table.Column<string>(type: "text", nullable: true),
                    EmailSendDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExternalSubscriptionId = table.Column<string>(type: "text", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayPaymentRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaasEditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    PlanId = table.Column<Guid>(type: "uuid", nullable: true),
                    EntityVersion = table.Column<int>(type: "integer", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaasEditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaasTenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    EditionId = table.Column<Guid>(type: "uuid", nullable: true),
                    EditionEndDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActivationState = table.Column<byte>(type: "smallint", nullable: false),
                    ActivationEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EntityVersion = table.Column<int>(type: "integer", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaasTenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayPaymentRequestProducts",
                columns: table => new
                {
                    PaymentRequestId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UnitPrice = table.Column<float>(type: "real", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    PaymentType = table.Column<byte>(type: "smallint", nullable: false),
                    PlanId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayPaymentRequestProducts", x => new { x.PaymentRequestId, x.Code });
                    table.ForeignKey(
                        name: "FK_PayPaymentRequestProducts_PayPaymentRequests_PaymentRequest~",
                        column: x => x.PaymentRequestId,
                        principalTable: "PayPaymentRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayGatewayPlans",
                columns: table => new
                {
                    PlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    Gateway = table.Column<string>(type: "text", nullable: false),
                    ExternalId = table.Column<string>(type: "text", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayGatewayPlans", x => new { x.PlanId, x.Gateway });
                    table.ForeignKey(
                        name: "FK_PayGatewayPlans_PayPlans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "PayPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaasTenantConnectionStrings",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Value = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaasTenantConnectionStrings", x => new { x.TenantId, x.Name });
                    table.ForeignKey(
                        name: "FK_SaasTenantConnectionStrings_SaasTenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "SaasTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayPaymentRequests_CreationTime",
                table: "PayPaymentRequests",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_SaasEditions_DisplayName",
                table: "SaasEditions",
                column: "DisplayName");

            migrationBuilder.CreateIndex(
                name: "IX_SaasTenants_Name",
                table: "SaasTenants",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayGatewayPlans");

            migrationBuilder.DropTable(
                name: "PayPaymentRequestProducts");

            migrationBuilder.DropTable(
                name: "SaasEditions");

            migrationBuilder.DropTable(
                name: "SaasTenantConnectionStrings");

            migrationBuilder.DropTable(
                name: "PayPlans");

            migrationBuilder.DropTable(
                name: "PayPaymentRequests");

            migrationBuilder.DropTable(
                name: "SaasTenants");
        }
    }
}
