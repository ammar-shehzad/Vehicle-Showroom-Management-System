using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicle_Showroom_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class recreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin_Registers",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_password = table.Column<int>(type: "int", nullable: false),
                    admin_image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin_Registers", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    branch_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    branch_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.branch_id);
                });

            migrationBuilder.CreateTable(
                name: "car_Brands",
                columns: table => new
                {
                    Brand_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand_Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_Brands", x => x.Brand_Id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Customer_id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    vehicle_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vehicle_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vehicle_model_number = table.Column<int>(type: "int", nullable: false),
                    vehicle_price = table.Column<int>(type: "int", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false),
                    car_brand_id = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    branch_id = table.Column<int>(type: "int", nullable: false),
                    vehicle_image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.vehicle_id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Branches_branch_id",
                        column: x => x.branch_id,
                        principalTable: "Branches",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_car_Brands_car_brand_id",
                        column: x => x.car_brand_id,
                        principalTable: "car_Brands",
                        principalColumn: "Brand_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cust_id = table.Column<int>(type: "int", nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zip_code = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payment_method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order_note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order_status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_orders_customers_cust_id",
                        column: x => x.cust_id,
                        principalTable: "customers",
                        principalColumn: "Customer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle_Registrations",
                columns: table => new
                {
                    registration_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    registration_vehicle_id = table.Column<int>(type: "int", nullable: false),
                    registration_branch_id = table.Column<int>(type: "int", nullable: true),
                    registration_brand_id = table.Column<int>(type: "int", nullable: true),
                    registration_chassis_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registration_Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_Registrations", x => x.registration_id);
                    table.ForeignKey(
                        name: "FK_vehicle_Registrations_Branches_registration_branch_id",
                        column: x => x.registration_branch_id,
                        principalTable: "Branches",
                        principalColumn: "branch_id");
                    table.ForeignKey(
                        name: "FK_vehicle_Registrations_Vehicles_registration_vehicle_id",
                        column: x => x.registration_vehicle_id,
                        principalTable: "Vehicles",
                        principalColumn: "vehicle_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicle_Registrations_car_Brands_registration_brand_id",
                        column: x => x.registration_brand_id,
                        principalTable: "car_Brands",
                        principalColumn: "Brand_Id");
                });

            migrationBuilder.CreateTable(
                name: "cart_Items",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: true),
                    vehicle_id = table.Column<int>(type: "int", nullable: true),
                    product_quantity = table.Column<int>(type: "int", nullable: true),
                    order_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart_Items", x => x.cart_id);
                    table.ForeignKey(
                        name: "FK_cart_Items_Vehicles_vehicle_id",
                        column: x => x.vehicle_id,
                        principalTable: "Vehicles",
                        principalColumn: "vehicle_id");
                    table.ForeignKey(
                        name: "FK_cart_Items_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "Customer_id");
                    table.ForeignKey(
                        name: "FK_cart_Items_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cart_Items_customer_id",
                table: "cart_Items",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_cart_Items_order_id",
                table: "cart_Items",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_cart_Items_vehicle_id",
                table: "cart_Items",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_cust_id",
                table: "orders",
                column: "cust_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_Registrations_registration_branch_id",
                table: "vehicle_Registrations",
                column: "registration_branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_Registrations_registration_brand_id",
                table: "vehicle_Registrations",
                column: "registration_brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_Registrations_registration_vehicle_id",
                table: "vehicle_Registrations",
                column: "registration_vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_branch_id",
                table: "Vehicles",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_car_brand_id",
                table: "Vehicles",
                column: "car_brand_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin_Registers");

            migrationBuilder.DropTable(
                name: "cart_Items");

            migrationBuilder.DropTable(
                name: "vehicle_Registrations");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "car_Brands");
        }
    }
}
