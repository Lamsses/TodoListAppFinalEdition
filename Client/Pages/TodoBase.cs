using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using TodoListAppFinalEdition.Client.Services;
using TodoListAppFinalEdition.Shared;

namespace TodoListAppFinalEdition.Client.Pages
{
    public class TodoBase : ComponentBase
    {
        private readonly HttpContext _httpContext;
        [Inject]
        public ITodoService? TodoService { get; set; }
        public IEnumerable<TodoItem> Items { get; set; }
        protected string additem;
        protected override async Task OnInitializedAsync()
        {
            Items = await TodoService.GetItems();
        }
        [Inject]
        public  NavigationManager NavigationManager { get; set; }

        protected void Edit(TodoItem item)
        {
            TodoService.UpdateItem(item);
            NavigationManager.NavigateTo("/todoChanges");


        }
        protected void Delete(int id)
        {
            TodoService.DeleteItem(id);
            Items = Items.Where(x => x.Id != id);
        }
        

        protected void Add()
        {

            TodoService.CreateItem(new TodoItem() { Title = additem, IsDone = false });
            additem = "";
            NavigationManager.NavigateTo("/todoChanges");


        }
        //protected void IsDone()
        //{
        //    TodoService.UpdateItem(TodoItem.IsDone = true );
        //}

    }
}
