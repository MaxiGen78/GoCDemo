﻿using GoCDemoLibrary.DataAccess;
using GoCDemoLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace GoCDemoLibrary.DataAccess
{
    public static class DbInitialiser
    {
        public static void Initialise(ProductDataContext context)
        {
            //Ensures that the DB for the context exists. If it exists - no action taken
            context.Database.EnsureCreated();

            //If DB is populated, return without update
            if (context.Products.Any())
                return;

            //Create a new collection of listed entities
            var productTypes = new List<ProductType>
            {
                new ProductType{ProductTypeId=1, ProductTypeName="Outdoor"},
                new ProductType{ProductTypeId=2, ProductTypeName="Indoor"},
                new ProductType{ProductTypeId=3, ProductTypeName="Clothing"},
                new ProductType{ProductTypeId=4, ProductTypeName="Other"}
            };

            //Add collection to ProductType DbSet
            productTypes.ForEach(p => context.ProductTypes.Add(p));


            var products = new List<Product>
            {
                new Product{ProductName="SYNERGIE X5 MATCH NETBALL",
                    ProductDescription="Looking for the ultimate match ball of International Match quality? Look no further. The Synergie X5 match ball, is a high level match ball that is made for indoor use only." +
                    "The Synergie X5 has a pro-performance air loc bladder to ensure maximum air retention along with multi-laminate construction for optimum strength." +
                    "The ball also shows incredibly advanced grip patterns via the Synergie V2 grip which allows for increased surface area on the ball to enable players " +
                    "to have the optimum handling experience on court." +
                    "As well as this, Synergie X5 has hydrate technology to enhance performance and provide durability." +
                    "This one of a kind match ball is available in size 5 only and is available in the International Netball Federation colours." +
                    "Get yours now and never look back.", ProductImage=null, ProductTypeID=1,  ProductPrice= 21.5m
                },

                new Product{ProductName="SYNERGIE X5 MATCH NETBALL",
                    ProductDescription="Looking for the ultimate match ball of International Match quality? Look no further. The Synergie X5 match ball, is a high level match ball that is made for indoor use only." +
                    "The Synergie X5 has a pro-performance air loc bladder to ensure maximum air retention along with multi-laminate construction for optimum strength." +
                    "The ball also shows incredibly advanced grip patterns via the Synergie V2 grip which allows for increased surface area on the ball to enable players " +
                    "to have the optimum handling experience on court." +
                    "As well as this, Synergie X5 has hydrate technology to enhance performance and provide durability." +
                    "This one of a kind match ball is available in size 5 only and is available in the International Netball Federation colours." +
                    "Get yours now and never look back.", ProductImage=null, ProductTypeID=2,  ProductPrice= 21.5m
                },

                new Product{ProductName="KAIZEN X 1.1 POWER RUGBY BOOTS - 8 STUD",
                    ProductDescription="New for the 2020-21 is this absolutely stunning, sleek, sexy, all Black KAIZEN X 1.1 POWER." +
                    "If you are a forward or a powerful back looking to dominate your opposite number, and look great doing it, then this is the boot for you." +
                    "Offering superb grip, traction and stability via the bio - frame 8 stud outsole, we have not compromised on power by " +
                    "using the new pro- tip studs to reduce weight.", ProductImage=null, ProductTypeID=1,  ProductPrice= 99.99m
                },

                new Product{ProductName="KAIZEN X 1.1 POWER RUGBY BOOTS - 8 STUD",
                    ProductDescription="New for the 2020-21 is this absolutely stunning, sleek, sexy, all Black KAIZEN X 1.1 POWER." +
                    "If you are a forward or a powerful back looking to dominate your opposite number, and look great doing it, then this is the boot for you." +
                    "Offering superb grip, traction and stability via the bio - frame 8 stud outsole, we have not compromised on power by " +
                    "using the new pro- tip studs to reduce weight.", ProductImage=null, ProductTypeID=3,  ProductPrice= 99.99m
                },

                new Product{ProductName="XACT HOOPS MATCH SHIRT",
                    ProductDescription="When taking to the field, athletes need kit that not only stands out from their opponents but allows their " +
                    "passion and talent for the game to thrive. Shirts that are not only comfortable but tailor to the players needs are essential. " +
                    "This is why Gilbert have designed the perfect match shirt, introducing the Xact Hoops Match Shirt." +
                    "The 100% eyelet polyester fabric making up the entirety of the shirt allows moisture control and air " +
                    "flow close to the skin to draw heat away from the body. This stops players overheating in the toughest moments..",
                    ProductImage=null, ProductTypeID=3,  ProductPrice= 32.99m
                },

                new Product{ProductName="Outdoor Product 1",
                    ProductDescription="1-Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis viverra nibh cras pulvinar mattis nunc sed. Posuere urna nec tincidunt praesent semper feugiat nibh.",
                    ProductImage=null, ProductTypeID=1,  ProductPrice= 22.49m
                },

                new Product{ProductName="Outdoor Product 2",
                    ProductDescription="2-Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis viverra nibh cras pulvinar mattis nunc sed. Posuere urna nec tincidunt praesent semper feugiat nibh.",
                    ProductImage=null, ProductTypeID=1,  ProductPrice= 42.00m
                },

                new Product{ProductName="Outdoor Product 3",
                    ProductDescription="3-Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis viverra nibh cras pulvinar mattis nunc sed. Posuere urna nec tincidunt praesent semper feugiat nibh.",
                    ProductImage=null, ProductTypeID=1,  ProductPrice= 220.99m
                },

                new Product{ProductName="Outdoor/Indoor Product 1",
                    ProductDescription="OI-1-Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis viverra nibh cras pulvinar mattis nunc sed. Posuere urna nec tincidunt praesent semper feugiat nibh.",
                    ProductImage=null, ProductTypeID=1,  ProductPrice= 30.49m
                },

                new Product{ProductName="Outdoor/Indoor Product 1",
                    ProductDescription="OI-1-Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis viverra nibh cras pulvinar mattis nunc sed. Posuere urna nec tincidunt praesent semper feugiat nibh.",
                    ProductImage=null, ProductTypeID=2,  ProductPrice= 30.49m
                },

                new Product{ProductName="Outdoor/Indoor Product 2",
                    ProductDescription="OI-2-Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis viverra nibh cras pulvinar mattis nunc sed. Posuere urna nec tincidunt praesent semper feugiat nibh.",
                    ProductImage=null, ProductTypeID=1,  ProductPrice= 5.00m
                },

                new Product{ProductName="Outdoor/IndoorProduct 2",
                    ProductDescription="OI-2-Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis viverra nibh cras pulvinar mattis nunc sed. Posuere urna nec tincidunt praesent semper feugiat nibh.",
                    ProductImage=null, ProductTypeID=2,  ProductPrice= 5.00m
                },

                new Product{ProductName="Clothing Product 1",
                    ProductDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis viverra nibh cras pulvinar mattis nunc sed. Posuere urna nec tincidunt praesent semper feugiat nibh.",
                    ProductImage=null, ProductTypeID=3,  ProductPrice= 46.49m
                },

                new Product{ProductName="Other Product 1",
                    ProductDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis viverra nibh cras pulvinar mattis nunc sed. Posuere urna nec tincidunt praesent semper feugiat nibh.",
                    ProductImage=null, ProductTypeID=4,  ProductPrice= 999.49m
                }
            };
            products.ForEach(p => context.Products.Add(p));

            //Save changes to the DB
            context.SaveChanges();
        }
    }
}
