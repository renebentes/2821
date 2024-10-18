using System;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BlazingShop.Layouts;

public partial class MainLayout : LayoutComponentBase
{

    private IEnumerable<NavItem> _navItems = default!;

    public Sidebar _sidebar = default!;

    private IEnumerable<NavItem> GetNavItems()
    {
        _navItems = new List<NavItem>
        {
            new() { Id = "1", Href = "/", IconName = IconName.HouseDoorFill, Text = "Home", Match=NavLinkMatch.All},
            new() { Id = "3", Href = "/categories", IconName = IconName.Table, Text = "Categories"},
            new() { Id = "2", Href = "/products", IconName = IconName.PlusSquareFill, Text = "Products"}
        };

        return _navItems;
    }

    private async Task<SidebarDataProviderResult> SidebarDataProvider(SidebarDataProviderRequest request)
    {
        _navItems ??= GetNavItems();
        return await Task.FromResult(request.ApplyTo(_navItems));
    }

}
