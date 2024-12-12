namespace TasksTrackingApp.API.Controllers
{
    public static class CardListsController
    {
        public static void CardListsRoutes(this WebApplication app)
        {
            var group = app.MapGroup("cardlists").WithTags("CardLists");
        }
    }
}
