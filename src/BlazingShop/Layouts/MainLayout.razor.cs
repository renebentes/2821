using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BlazingShop.Layouts;

public partial class MainLayout : LayoutComponentBase
{
    public Sidebar Sidebar = default!;
    private IEnumerable<NavItem> _navItems = default!;

    private IEnumerable<NavItem> GetNavItems()
    {
        _navItems = new List<NavItem>
        {
            new() { Id = "1", Href = "/", IconName = IconName.HouseDoorFill, Text = "Home", Match=NavLinkMatch.All},
            new() { Id = "2", Href = "/categories", IconName = IconName.BookmarkFill, Text = "Categories"},
            new() { Id = "3", Href = "/products", IconName = IconName.Boxes, Text = "Products"}
        };

        return _navItems;
    }

    private async Task<SidebarDataProviderResult> SidebarDataProvider(SidebarDataProviderRequest request)
    {
        _navItems ??= GetNavItems();
        return await Task.FromResult(request.ApplyTo(_navItems));
    }
}
