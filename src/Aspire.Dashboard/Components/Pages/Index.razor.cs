// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspire.Dashboard.Model;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Aspire.Dashboard.Components.Pages;

public partial class Index : ResourcesListBase<ProjectViewModel>
{
    protected override ValueTask<List<ProjectViewModel>> GetResources(IDashboardViewModelService dashboardViewModelService)
        => dashboardViewModelService.GetProjectsAsync();

    protected override IAsyncEnumerable<ResourceChanged<ProjectViewModel>> WatchResources(
        IDashboardViewModelService dashboardViewModelService,
        IEnumerable<NamespacedName> initialList,
        CancellationToken cancellationToken)
        => dashboardViewModelService.WatchProjectsAsync(initialList, cancellationToken);

    protected override bool Filter(ProjectViewModel resource)
        => resource.Name.Contains(filter, StringComparison.CurrentCultureIgnoreCase)
        || resource.ProjectPath.Contains(filter, StringComparison.CurrentCultureIgnoreCase);

    private readonly GridSort<ProjectViewModel> _projectPathSort = GridSort<ProjectViewModel>.ByAscending(p => p.ProjectPath);
}
