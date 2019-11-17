using FluentMigrator;

namespace MerchMarket.Database.Migrations
{
  [Migration(1)]
  public class Initial : Migration
  {
    public override void Up()
    {
      Create.Table("ApplicationUser")
        .WithColumn("Id").AsInt64().PrimaryKey().Identity()
        .WithColumn("UserName").AsString().NotNullable()
        .WithColumn("NormalizedUserName").AsString().NotNullable()
        .WithColumn("Email").AsString().NotNullable()
        .WithColumn("NormalizedEmail").AsString().NotNullable()
        .WithColumn("EmailConfirmed").AsBoolean().NotNullable()
        .WithColumn("PasswordHash").AsString()
        .WithColumn("PhoneNumber").AsString()
        .WithColumn("PhoneNumberConfirmed").AsBoolean().NotNullable()
        .WithColumn("TwoFactorEnabled").AsBoolean().NotNullable();
      
      Create.Index("ApplicationUser_NormalizedUserName").OnTable("ApplicationUser").OnColumn("NormalizedUserName");
      Create.Index("ApplicationUser_NormalizedEmail").OnTable("ApplicationUser").OnColumn("NormalizedEmail");

      Create.Table("ApplicationRole")
        .WithColumn("Id").AsInt64().PrimaryKey().Identity()
        .WithColumn("Name").AsString().NotNullable()
        .WithColumn("NormalizedName").AsString().NotNullable();
      
      Create.Index("ApplicationRole_NormalizedName").OnTable("ApplicationRole").OnColumn("NormalizedName");
    }

    public override void Down()
    {
      Delete.Table("ApplicationUser");
      Delete.Table("ApplicationRole");
    }
  }
}