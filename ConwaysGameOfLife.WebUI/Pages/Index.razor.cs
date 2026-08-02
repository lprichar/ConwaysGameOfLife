using ConwaysGameOfLife.Lib.Contracts;
using ConwaysGameOfLife.Lib.Services;
using Microsoft.AspNetCore.Components;

namespace ConwaysGameOfLife.WebUI.Pages;

public partial class Index
{
    [Inject]
    private IGameOfLifeService GameOfLifeService { get; set; } = default!;

    private RenderedBoard? RenderedBoard { get; set; }

    protected override void OnInitialized()
    {
        var board = GameOfLifeService.LoadShape("I-heptomino");
        var view = new BoardView(0, 0, 6, 4);
        RenderedBoard = GameOfLifeService.Render(board, view);

        base.OnInitialized();
    }
}
