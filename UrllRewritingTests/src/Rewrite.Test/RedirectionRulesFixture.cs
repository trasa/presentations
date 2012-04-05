using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Intelligencia.UrlRewriter;
using Intelligencia.UrlRewriter.Configuration;
using NUnit.Framework;
using Rewrite.Test;

namespace Rewrite.Test
{
    public abstract class RedirectionRulesFixture
    {
        protected RewriterEngine rewriter;
        protected ContextFacadeStub context;

        /// <summary>
        /// The rules we're parsing.
        /// </summary>
        public abstract string Rules { get; }

        [SetUp]
        public void SetUp()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Rules);
            context = new ContextFacadeStub();
            rewriter = new RewriterEngine(context, RewriterConfiguration.LoadFromNode(doc.SelectSingleNode("rewriter")));
        }
    }
}