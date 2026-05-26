using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieHub.API.Migrations
{
    /// <inheritdoc />
    public partial class HydrateMembershipTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Sql(@"insert into MembershipType 
                (SignUpFee, DurationInMonth, DiscountRate)
                values 
                (1, 0, 0, 0),
                (2, 30, 1, 10),
                (3, 90, 3, 15),
                (4, 300, 12, 15)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            Sql("delete * from MemberShipType");
        }
    }
}
