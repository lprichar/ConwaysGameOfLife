# Front-end Best Practices

- Keep page logic in WebUI/Pages and use code-behind files for state and behavior.
- Avoid @code blocks when a partial class can hold the page logic cleanly.
- Keep the UI focused on presentation; put board updates, rendering transforms, and pattern loading in ConwaysGameOfLife.Lib when possible.
- Use the existing Blazor WebAssembly stack rather than adding third-party UI libraries unless there is a clear need.
- Keep interactions clear and accessible: label controls, make board state visible, and avoid confusing gestures.
- Keep styling in wwwroot/css/app.css and use it to make the board readable on different screen sizes.

## Naming

- Pages should describe the route or screen they own.
- Components should describe the reusable UI they render.
- Keep file names aligned with the component or page name.

## Current Examples

- Main page: ConwaysGameOfLife.WebUI/Pages/Index.razor and Index.razor.cs
- App shell: ConwaysGameOfLife.WebUI/MainLayout.razor
- Bootstrapping: ConwaysGameOfLife.WebUI/App.razor
