using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageExt.Common;

namespace ProjectF.Pos.Pages.Tables
{
    public partial class Tables : ComponentBase
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        public TableItem[] GetTableItems()
        {
            return Enumerable.Range(1, 40)
                .Map(c => new TableItem(new Random().Next(0, 2) > 0
                              , $"Mesa {c}"
                              , new Random().Next(1, 20)))
                .ToArray();
        }

        public void OpenPos() => NavigationManager.NavigateTo("/pos");
    }

    public record TableItem (bool IsBusy
        , string Name
        , int NumberOfItemSelected);
}
