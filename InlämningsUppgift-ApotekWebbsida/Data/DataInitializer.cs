using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InlämningsUppgift_ApotekWebbsida.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            dbContext.Database.Migrate();
            SeedRoles(dbContext);
            SeedUsers(userManager);
            SeedCategory(dbContext);
            SeedProducts(dbContext);
        }
        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("zoo123@hotmail.com").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "zoo123@hotmail.com";
                user.Email = "zoo123@hotmail.com";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "123ABCabc#").Result;
                userManager.AddToRoleAsync(user, "Admin").Wait();

            }
            if (userManager.FindByEmailAsync("sam.sam@system.se").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "sam.sam@system.se";
                user.Email = "sam.sam@system.se";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "Hejsan123#").Result;
                userManager.AddToRoleAsync(user, "Product Manager").Wait();

            }

        }
        private static void SeedRoles(ApplicationDbContext dbContext)
        {
            if (!dbContext.Roles.Any(r => r.Name == "Admin"))
            {
                dbContext.Roles.Add(new IdentityRole
                {
                    NormalizedName = "Admin",
                    Name = "Admin"
                });
            }
            if (!dbContext.Roles.Any(r => r.Name == "Product Manager"))
            {
                dbContext.Roles.Add(new IdentityRole
                {
                    NormalizedName = "Product Manager",
                    Name = "Product Manager"
                });
            }

            dbContext.SaveChanges();
        }
        private static void SeedProducts(ApplicationDbContext dbContext)
        {
            if (dbContext.Products.Count(r => r.Namn == "Vichy Liftactiv Supreme Day Normal hud") == 0)
            {
                var product1 = new Product()
                {
                    Namn = "Vichy Liftactiv Supreme Day Normal hud",
                    Beskrivning = "Dagkräm, 50ml, för kvinnor + 40år",
                    Pris =209,
                    Varumärke="Vichy"
                };
                var categoryItem1 = dbContext.Categories.First(category => category.Namn == "Ansikte");
                categoryItem1.Products.Add(product1);
            }
            if (dbContext.Products.Count(r => r.Namn == "Eucerin Aquaporin Active Dry Skin") == 0)
            {
                var product2 = new Product()
                {
                    Namn = "Eucerin Aquaporin Active Dry Skin",
                    Beskrivning = "Ansiktskräm, 50ml, Ger intensiv fukt/fuktighet i 24 timmar.",
                    Pris = 169,
                    Varumärke = "Eucerin"
                };
                var categoryItem2 = dbContext.Categories.First(category => category.Namn == "Ansikte");
                categoryItem2.Products.Add(product2);
            }


            if (dbContext.Products.Count(r => r.Namn == "Twistshake AntiColic") == 0)
            {
                var product3 = new Product()
                {
                    Namn = "Twistshake AntiColic",
                    Beskrivning = "Vit. Nappflaska 180 ml",
                    Pris = 99,
                    Varumärke = "Twistshake"
                };
                var categoryItem3 = dbContext.Categories.First(category => category.Namn == "Barn");
                categoryItem3.Products.Add(product3);
            }
            if (dbContext.Products.Count(r => r.Namn == "Twistshake AntiColic") == 0)
            {
                var product4 = new Product()
                {
                    Namn = "Twistshake AntiColic",
                    Beskrivning = "Vit. Djup tallrik 6+ mån",
                    Pris = 119,
                    Varumärke = "Twistshake"
                };
                var categoryItem4 = dbContext.Categories.First(category => category.Namn == "Barn");
                categoryItem4.Products.Add(product4);
            }

            if (dbContext.Products.Count(r => r.Namn == "Eucerin pH5 Hand Cream") == 0)
            {
                var product5 = new Product()
                {
                    Namn = "Eucerin pH5 Hand Cream",
                    Beskrivning = "Handkräm 100 ml, Mild men effektiv.",
                    Pris = 89,
                    Varumärke = "Eucerin"
                };
                var categoryItem5 = dbContext.Categories.First(category => category.Namn == "Hudvård");
                categoryItem5.Products.Add(product5);
            }
            if (dbContext.Products.Count(r => r.Namn == "ACO Hand Cream Rich") == 0)
            {
                var product6 = new Product()
                {
                    Namn = "ACO Hand Cream Rich",
                    Beskrivning = "Handkräm rich 75 ml, en återfuktande hudkräm.",
                    Pris = 69,
                    Varumärke = "ACO"
                };
                var categoryItem6 = dbContext.Categories.First(category => category.Namn == "Hudvård");
                categoryItem6.Products.Add(product6);
            }
            if (dbContext.Products.Count(r => r.Namn == "Pronaxen") == 0)
            {
                var product7 = new Product()
                {
                    Namn = "Pronaxen",
                    Beskrivning = "Tabllett 250 mg Naproxen 10 tabletter",
                    Pris = 69,
                    Varumärke = "Pronaxen"
                };
                var categoryItem7 = dbContext.Categories.First(category => category.Namn == "Förkylning och feber");
                categoryItem7.Products.Add(product7);
            }
            if (dbContext.Products.Count(r => r.Namn == "Alvedon 500 mg") == 0)
            {
                var product8 = new Product()
                {
                    Namn = "Alvedon 500 mg",
                    Beskrivning = "Paracetamol, munsönderfallande tablett, 16 st, Raceptfritt läkmedel.",
                    Pris = 69,
                    Varumärke = "Alvedon"
                };
                var categoryItem8 = dbContext.Categories.First(category => category.Namn == "Förkylning och feber");
                categoryItem8.Products.Add(product8);
            }

            dbContext.SaveChanges();
        }

        private static void SeedCategory(ApplicationDbContext dbContext)
        {
            if (dbContext.Categories.Count(r => r.Namn == "Ansikte") == 0)
            {
                var category1 = new Category { Namn = "Ansikte" };
                dbContext.Categories.Add(category1);
            }

            if (dbContext.Categories.Count(r => r.Namn == "Barn") == 0)
            {
                var category2 = new Category { Namn = "Barn" };
                dbContext.Categories.Add(category2);
            }

            if (dbContext.Categories.Count(r => r.Namn == "Förkylning och feber") == 0)
            {
                var category3 = new Category { Namn = "Förkylning och feber" };
                dbContext.Categories.Add(category3);
            }

            if (dbContext.Categories.Count(r => r.Namn == "Hudvård") == 0)
            {
                var category4 = new Category { Namn = "Hudvård" };
                dbContext.Categories.Add(category4);
            }

            dbContext.SaveChanges();

        }

    }
}
