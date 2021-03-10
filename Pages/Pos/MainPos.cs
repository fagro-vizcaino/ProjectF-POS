using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectF.Pos.Pages.Pos
{
    public partial class MainPos : ComponentBase
    {
        private ImmutableList<Category> CategoryItems = ImmutableList<Category>.Empty;
        private ImmutableList<MenuItem> MenuItems = ImmutableList<MenuItem>.Empty;

        protected override Task OnInitializedAsync()
        {
            CategoryItems = GetCategoryItems().ToImmutableList();
            MenuItems = GetMenuItems().ToImmutableList();
            return base.OnInitializedAsync();
        }

        public Category[] GetCategoryItems()
            => new Category[]
            {
                new("Bebida alcoholicas", new Random().Next(1, 100), "#"),
                new( "Postres", new Random().Next(1, 100), "#"),
                new( "Caldos", new Random().Next(1, 100), "#"),
                new( "Almuerzos", new Random().Next(1, 100), "#"),
                new( "Desayunos", new Random().Next(1, 100), "#"),
                new( "Mariscos", new Random().Next(1, 100), "#"),
                new( "Jugos", new Random().Next(1, 100), "#"),
                new( "Entradas", new Random().Next(1, 100), "#")
            };

        public MenuItem[] GetMenuItems()
            => new MenuItem[]
            {
                new("Guineito con Huevo", 155.00m, 0, ImmutableList<ItemException>.Empty),
                new("3 Golpes", 175.00m, 0, ImmutableList<ItemException>.Empty),
                new("Sandwich de Queso", 120.00m, 0, ImmutableList<ItemException>.Empty),
                new("Arroz Maiz, Carne Cerdo", 170.00m, 0, ImmutableList<ItemException>.Empty),
                new("Arroz Blanco, Pollo Honeado", 175.00m, 0, ImmutableList<ItemException>.Empty),
                new("Deditos de queso", 110.00m, 0, ImmutableList<ItemException>.Empty),
                new("Chuleta de cerdo", 155.00m, 0, ImmutableList<ItemException>.Empty),
                new("Mero a la plancha", 175.00m, 0, ImmutableList<ItemException>.Empty),
                new("Sanchoco de habichuelas", 280.00m, 0, ImmutableList<ItemException>.Empty),
                new("Pataymongo", 280.00m, 0, ImmutableList<ItemException>.Empty),
                new("Mofongo camarones", 330.00m, 0, ImmutableList<ItemException>.Empty),
                new("Mofongo Pollo", 320.00m, 0, ImmutableList<ItemException>.Empty),
                new("Mofongo Tres Golpe", 350.00m, 0, ImmutableList<ItemException>.Empty),
                new("Chillo al vapor", 340.00m, 0, ImmutableList<ItemException>.Empty),
                new("Cafe expresso", 40.00m, 0, ImmutableList<ItemException>.Empty),
                new("Cafe cappuccino", 65.00m, 0, ImmutableList<ItemException>.Empty),
                new("Chivo Guisado", 245.00m, 0, ImmutableList<ItemException>.Empty),
                new("Jugo de Fresa, Natural", 85.00m, 0, ImmutableList<ItemException>.Empty),
                new("Jugo de Limon, Natural", 80.00m, 0, ImmutableList<ItemException>.Empty),
                new("Jugo de Chinola, Natural", 65.00m, 0, ImmutableList<ItemException>.Empty),
                new("Linguini Alfredo", 120.00m, 0, ImmutableList<ItemException>.Empty),
                new("Jugo de Ceresa, Natural", 80.00m, 0, ImmutableList<ItemException>.Empty),
                new("Jugo de Piña, Natural", 75.00m, 0, ImmutableList<ItemException>.Empty),
                new("Jugo de fresa, Natural", 120.00m, 0, ImmutableList<ItemException>.Empty),
            };

        public MenuItem[] GetTableItems()
            => GetMenuItems()
            .Select(c =>
            {
                return c with
                {
                    QtySelected = new Random().Next(1, 30),
                    Exceptions = GetItemExceptions()
                    .Take(new Random().Next(0, GetItemExceptions().Count)).ToImmutableList()
                };
            }).ToArray();

        public string GetItemColor()
            => new List<string>()
            {
                "1d2d50",
                "133b5c",
                "ff7844",
                "1e5f74",
                "000272",
                "341677",
                "ff6363",
                "a32f80",
                "413c69",
                "4a47a3",
                "202040",
                "202060",
                "602080",
                "b030b0",
                "543864",
                "ff6363",
                "ffbd69",
                "639cd9",
                "5454c5",
                "342056"
            }[new Random().Next(1, 20)];

        public ImmutableList<ItemException> GetItemExceptions()
            => ImmutableList.Create<ItemException>(new("", 0)
                , new("Con Rusa", 25)
                , new("Con Ensalada", 15)
                , new("Con Tostones", 50)
                , new("Sin Mayonesa", 0)
                , new("Con katchup", 5)
                , new("Con Tostones Maduros", 55)
                , new("Con habichuela", 25)
                , new("Con gandul", 20)
                , new("Con habichuelas negra", 26)
                , new("Con salsa tar", 15)
                , new("Con salchica italiana", 55)
                , new("Con Papa frita", 25)
                , new("Con Pure de papa", 15))
            .Filter(c => c.Price > 0)
            .ToImmutableList();

    }


    public record Category(string Name, int NumberOfProducts, string Color);

    public record MenuItem(string Name
        , decimal Price
        , int QtySelected
        , ImmutableList<ItemException> Exceptions);

    public record ItemException(string Name, decimal Price);


}
