using Microsoft.AspNetCore.Mvc.RazorPages;
using Frizerie.Data;

namespace Frizerie.Models
{
    public class ServiciuCategoriesPageModel : PageModel
    {
        public List<CategorieAtribuitaServiciu> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(FrizerieContext context,
        Serviciu serviciu)
        {
            var allCategories = context.Category;
            var serviciuCategories = new HashSet<int>(
            serviciu.ServiciuCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<CategorieAtribuitaServiciu>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new CategorieAtribuitaServiciu
                {
                    CategoryID = cat.ID,
                    Nume = cat.CategoryName,
                    Atribuire = serviciuCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateServiciuCategories(FrizerieContext context,
        string[] selectedCategories, Serviciu serviciuToUpdate)
        {
            if (selectedCategories == null)
            {
                serviciuToUpdate.ServiciuCategories = new List<ServiciuCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var serviciuCategories = new HashSet<int>
            (serviciuToUpdate.ServiciuCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!serviciuCategories.Contains(cat.ID))
                    {
                        serviciuToUpdate.ServiciuCategories.Add(
                        new ServiciuCategory
                        {
                            ServiciuID = serviciuToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (serviciuCategories.Contains(cat.ID))
                    {
                        ServiciuCategory courseToRemove
                        = serviciuToUpdate
                        .ServiciuCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
