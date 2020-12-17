using System;
using System.Collections.Generic;
using System.Linq;
using IChiba.Core;
using IChiba.Core.Domain;
using IChiba.Core.Infrastructure;
using IChiba.Services.Localization;

namespace IChiba.Services
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Convert to select list
        /// </summary>
        /// <typeparam name="TEnum">Enum type</typeparam>
        /// <param name="enumObj">Enum</param>
        /// <param name="markCurrentAsSelected">Mark current value as selected</param>
        /// <param name="valuesToExclude">Values to exclude</param>
        /// <param name="useLocalization">Localize</param>
        /// <returns>List of select items</returns>
        public static IList<IChibaListItem> ToSelectListItems<TEnum>(this TEnum enumObj,
            bool markCurrentAsSelected = true, int[] valuesToExclude = null, bool useLocalization = true) where TEnum : struct
        {
            var workContext = EngineContext.Current.Resolve<IWorkContext>();
            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();
            var values = from TEnum enumValue in Enum.GetValues(typeof(TEnum))
                where valuesToExclude == null || !valuesToExclude.Contains(Convert.ToInt32(enumValue))
                select new { Id = Convert.ToInt32(enumValue), Name = useLocalization ? localizationService.GetLocalizedEnum(enumValue, workContext.LanguageId) : CommonHelper.ConvertEnum(enumValue.ToString()) };
            object selectedValue = null;
            if (markCurrentAsSelected)
                selectedValue = Convert.ToInt32(enumObj);
            var result = values.Select(s => new IChibaListItem
            {
                Id = s.Id,
                Name = s.Name,
                Selected = selectedValue != null && s.Id == (int)selectedValue
            }).ToList();

            return result;
        }

        /// <summary>
        /// Convert to select list
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="objList">List of objects</param>
        /// <param name="selector">Selector for name</param>
        /// <returns>List of select items</returns>
        public static IList<IChibaListItem> ToSelectListItems<T>(this T objList, Func<BaseEntity, string> selector) where T : IEnumerable<BaseEntity>
        {
            var result = objList.Select(p => new IChibaListItem { Id = p.Id, Name = selector(p) }).ToList();

            return result;
        }
    }
}
