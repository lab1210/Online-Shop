using Online_Shopping.Models;
using Online_Shopping.Service;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Online_Shopping.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Online_Shopping.Models.ShoppingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Online_Shopping.Models.ShoppingContext context)
        {

            if (!context.Registers.Any())
            {
                context.Registers.AddOrUpdate(
                new Register() { LastName = "Oladeji", Email = "oladejiomolabake14@gmail.com", Password = "Admin1234", Role = "Admin", FirstName = "Omolabake" ,ConfirmPassword="Admin1234"}

               );
            }


        }
    }
}
