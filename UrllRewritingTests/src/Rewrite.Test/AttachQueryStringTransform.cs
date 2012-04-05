using System;
using System.Reflection;
using Intelligencia.UrlRewriter;
using log4net;

namespace Rewrite.Test
{
    /// <summary>
    /// Converts ? into &amp;, used to translate QueryStrings for dynamic pages.
    /// </summary>
    public class AttachQueryStringTransform : IRewriteTransform
    {
       
        /// <summary>
        /// Applies a transformation to the input string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The transformed string.</returns>
        public string ApplyTransform(string input)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            return input.Replace('?', '&');
        }

        /// <summary>
        /// The name of the transform.
        /// </summary>
        /// <value></value>
        public string Name
        {
            get { return "attachQueryString"; }
        }
    }
}