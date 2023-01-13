app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Expense}/{action=Index}");
});