
using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace RobotArmy.Core.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcForm BeginForm<TController>(this HtmlHelper helper, Expression<Func<TController, object>> actionExpression)
        {
            return BeginForm(helper, actionExpression, null, FormMethod.Post, null);
        }


        public static MvcForm BeginForm<TController>(this HtmlHelper helper, Expression<Func<TController, object>> actionExpression, object routeValues)
        {
            return BeginForm(helper, actionExpression, routeValues, FormMethod.Post, null);
        }


        public static MvcForm BeginForm<TController>(this HtmlHelper helper, Expression<Func<TController, object>> actionExpression, object routeValues, object x)
        {
            return BeginForm(helper, actionExpression, routeValues, FormMethod.Post, null);
        }


        public static MvcForm BeginForm<TController>(this HtmlHelper helper, Expression<Func<TController, object>> actionExpression, object routeValues, FormMethod formMethod, object htmlAttributes)
        {
            string controllerName = typeof(TController).GetControllerName();
            string actionName = actionExpression.GetActionName();
            return helper.BeginForm(actionName, controllerName, routeValues, formMethod, htmlAttributes);
        }
    }
}
