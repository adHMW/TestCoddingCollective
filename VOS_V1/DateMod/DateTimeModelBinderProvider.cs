using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Linq;
using VOS_V1.DateMod;

namespace VOS_V1.Utility
{
    public class DateTimeModelBinderProvider : IModelBinderProvider

    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (DateTimeModelBinder.SUPPORTED_TYPES.Contains(context.Metadata.ModelType))
            {
                return new BinderTypeModelBinder(typeof(DateTimeModelBinder));
            }

            return null;
        }
    }
}
