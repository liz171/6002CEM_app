using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace app.Services
{
    public class MyRecipeService
    {
        static SQLiteAsyncConnection Database;

        public static readonly LazyAsync<MyRecipeService> Instance = new LazyAsync<MyRecipeService>(async () =>
        {
            var instance = new MyRecipeService();
            CreateTableResult result = await Database.CreateTableAsync<RecipeItem>();
            return instance;
        });

        private MyRecipeService()
        {
            Database = new SQLiteAsyncConnection(Constants.DbPath, Constants.Flags);            
        }
        public Task<int> DeleteRecipe(string fuulname)
        {
            return Database.DeleteAsync(fuulname);
        }
        public Task<RecipeItem> GetTodo(string fullname)
        {
            return Database.Table<RecipeItem>().Where((todo) => todo.FullName == fullname).FirstOrDefaultAsync();
        }
        public Task<List<RecipeItem>> GetTodos()
        {
            return Database.Table<RecipeItem>().ToListAsync();
        }
        public Task<int> SaveRecipe(RecipeItem RecipeItem)
        {
            if (RecipeItem.FullName != null)
            {
                return Database.UpdateAsync(RecipeItem);
            }
            return Database.InsertAsync(RecipeItem);
        }
    }

    public class LazyAsync<T>
    {
        readonly Lazy<Task<T>> instance;
        public LazyAsync(Func<T> factory)
        {
            instance = new Lazy<Task<T>>(() => Task.Run(factory));
        }

        public LazyAsync(Func<Task<T>> factory)
        {
            instance = new Lazy<Task<T>>(() => Task.Run(factory));
        }

        public TaskAwaiter<T> GetAwaiter()
        {
            return instance.Value.GetAwaiter();
        }
    }
}
