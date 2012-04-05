using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using Intelligencia.UrlRewriter;
using Intelligencia.UrlRewriter.Utilities;
using NUnit.Framework;

namespace Rewrite.Test
{
    /// <summary>
    /// Used for testing the url rewriter module w/out providing an actual asp.net site to run context.
    /// </summary>
    public class ContextFacadeStub : IContextFacade
    {
        Dictionary<object, object> items = new Dictionary<object, object>();
        private string rawUrl;
        private int statusCode;
        private string rewritePath;
        private string redirLocation;


        /// <summary>
        /// Gets or sets the raw URL (which is fed into the Rewriter)
        /// </summary>
        /// <value>The raw URL.</value>
        public string RawUrl
        {
            get { return rawUrl; }
            set { rawUrl = value; }
        }

        public int StatusCode { get { return statusCode; } }


        /// <summary>
        /// Our resulting value
        /// </summary>
        public string Result { get { return rewritePath; } }


        public string RedirectLocation { get { return redirLocation; } }

        #region IContextFacade implementation


        /// <summary>
        /// Retrieves the application path.
        /// </summary>
        /// <returns>The application path.</returns>
        public string GetApplicationPath()
        {
            return "";
        }

        /// <summary>
        /// Retrieves the raw url.
        /// </summary>
        /// <returns>The raw url.</returns>
        public string GetRawUrl()
        {
            // used by the writer
            return rawUrl;
        }

        

        /// <summary>
        /// Retrieves the current request url.
        /// </summary>
        /// <returns>The request url.</returns>
        public Uri GetRequestUrl()
        {
            return new Uri(rawUrl);
        }

        /// <summary>
        /// Sets the status code for the response.
        /// </summary>
        /// <param name="code">The status code.</param>
        public void SetStatusCode(int code)
        {
            statusCode = code;
        }

        /// <summary>
        /// Rewrites the request to the new url.
        /// </summary>
        /// <param name="url">The new url to rewrite to.</param>
        public void RewritePath(string url)
        {
            rewritePath = url;
        }

        /// <summary>
        /// Sets the redirection location to the given url.
        /// </summary>
        /// <param name="url">The url of the redirection location.</param>
        public void SetRedirectLocation(string url)
        {
            redirLocation = url;
        }

        /// <summary>
        /// Appends a header to the response.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="value">The header value.</param>
        public void AppendHeader(string name, string value)
        {
            // blah blah don't care.
        }

        /// <summary>
        /// Adds a cookie to the response.
        /// </summary>
        /// <param name="cookie">The cookie to add.</param>
        public void AppendCookie(HttpCookie cookie)
        {
            // blah blah don't care.
        }

        /// <summary>
        /// Handles an error with the error handler.
        /// </summary>
        /// <param name="handler">The error handler to use.</param>
        public void HandleError(IRewriteErrorHandler handler)
        {
            Assert.Fail("Error!  Ohe Noes!");
        }

        /// <summary>
        /// Sets a context item.
        /// </summary>
        /// <param name="item">The item key</param>
        /// <param name="value">The item value</param>
        public void SetItem(object item, object value)
        {
            if (items.ContainsKey(item))
                items[item] = value;
            else
                items.Add(item, value);
        }

        /// <summary>
        /// Retrieves a context item.
        /// </summary>
        /// <param name="item">The item key.</param>
        /// <returns>The item value.</returns>
        public object GetItem(object item)
        {
            object value;
            items.TryGetValue(item, out value);
            return value;
        }

        /// <summary>
        /// Retrieves the HTTP method used by the request.
        /// </summary>
        /// <returns>The HTTP method.</returns>
        public string GetHttpMethod()
        {
            return "POST";
        }

        /// <summary>
        /// Gets a collection of server variables.
        /// </summary>
        /// <returns></returns>
        public NameValueCollection GetServerVariables()
        {
            return new NameValueCollection();
        }

        /// <summary>
        /// Gets a collection of headers.
        /// </summary>
        /// <returns></returns>
        public NameValueCollection GetHeaders()
        {
            return new NameValueCollection();
        }

        /// <summary>
        /// Gets a collection of cookies.
        /// </summary>
        /// <returns></returns>
        public HttpCookieCollection GetCookies()
        {
            return new HttpCookieCollection();
        }

        /// <summary>
        /// Delegate to use for mapping paths.
        /// </summary>
        /// <value></value>
        public MapPath MapPath
        {
            get { return InternalMapPath; }
        }

        #endregion

        private string InternalMapPath(string url)
        {
            // something that we know will always exist...?
            return "C:\\boot.ini";
        }


    }
}