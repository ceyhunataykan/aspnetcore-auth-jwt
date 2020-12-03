using CA.ProductCoreApp.Business.Interfaces;
using CA.ProductCoreApp.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace CA.ProductCoreApp.WebApi.CustomFilters
{
    public class ValidId<TEntity> : IActionFilter where TEntity : class, ITable, new()
    {
        private readonly IGenericService<TEntity> _genericService;

        public ValidId(IGenericService<TEntity> genericService)
        {
            _genericService = genericService;
        }

        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictonary = context.ActionArguments.Where(I => I.Key == "id").FirstOrDefault();
            var checkedId = (int)dictonary.Value;

            var entity = _genericService.GetById(checkedId).Result;

            if (entity == null)
            {
                context.Result = new NotFoundObjectResult($"ID {checkedId} Bulunamadı!");
            }
        }
    }
}
