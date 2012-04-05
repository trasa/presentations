
using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace RobotArmy.Core.Extensions
{
    public static class ActionLinkExtensions
    {
        public static string ActionLink<TController>(this HtmlHelper htmlHelper, string linkText, Expression<Func<TController, object>> actionExpression)
        {
            return ActionLink(htmlHelper,
                              linkText,
                              actionExpression,
                              null);
        }

        public static string ActionLink<TController>(this HtmlHelper htmlHelper,  string linkText, Expression<Func<TController, object>> actionExpression, object values)
        {
            return htmlHelper.ActionLink(linkText,
                     actionExpression.GetActionName(),
                     typeof(TController).GetControllerName(),
                     values,
                     null);
        }
    }
}
