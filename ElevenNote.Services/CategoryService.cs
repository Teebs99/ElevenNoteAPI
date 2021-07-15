using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        private readonly Guid _userId;

        public CategoryService(Guid id)
        {
            _userId = id;
        }

        public bool CreateCategory(Category model)
        {
            Category category = new Category() { Name = model.Name };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(category);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CategoryListItem> GetCategories()
        {
            List<Category> categories = new List<Category>();
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Categories.Where(c => c.OwnerId == _userId).Select(c => new CategoryListItem() { Name = c.Name }).ToArray();
                return query;

            }
        }
        public bool UpdateCategory(Category model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.Id == model.Id);
                entity.Name = model.Name;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCategory(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var model = ctx.Categories.Find(id);
                ctx.Categories.Remove(model);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
