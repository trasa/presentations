using System.Reflection;
using System.Xml;
using Intelligencia.UrlRewriter;
using Intelligencia.UrlRewriter.Configuration;
using log4net;
using NUnit.Framework;
using Rewrite.Test;

namespace Rewrite.Test
{
    [TestFixture]
    public class UrlRedirectionFixture
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        private RewriterEngine rewriter;
        private ContextFacadeStub context;


        [SetUp]
        public void SetUp()
        {
            string rawXml = @"
<rewriter>
		<register logger='Rewrite.Test.Log4NetRewriteLogger, Rewrite.Test' />
		
		<!-- our library -->
		<rewrite url='/Library/(.+)' to='~/Portal/GetLibraryFile.aspx?Path=$1' />
		
		<!-- once the library files have been dealt with, ignore these files: -->
		<rewrite url='^(/.+(\.gif|\.png|\.jpg|\.ico|\.pdf|\.css|\.js)(\?.+)?)$' to='$1' processing='stop' />
		
		<!-- the 'sample' site -->
		<rewrite url='/sample/(.+)' to='~/Portal/GetPortalPage.aspx?Requested=Sample/$1' />
        
        <!-- client site -->
        <rewrite url='/site/(.+)' to='~/Portal/DisplayPortalPage.aspx?Requested=site/$1' />

        <!-- index page rewritten -->
        <rewrite url='/index.aspx' to='~/Portal/DisplayPortalPage.aspx?Requested=site/index.aspx' />		

		<!-- handles default page request (should redirect to index.aspx, then reprocess) -->
		<rewrite url='^(.*)/(\?.+)?$' to='$1/index.aspx$2?' processing='restart' />
	</rewriter>
";
            
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(rawXml);
            //redirInstance = new UrlRedirection(doc, DebugLogEnabled);
            context = new ContextFacadeStub();
            rewriter = new RewriterEngine(context, RewriterConfiguration.LoadFromNode(doc.SelectSingleNode("rewriter")));
        }

        [Test]
        public void MatchLibraryRequest()
        {
            context.RawUrl = "http://cms.blackfintech.com/library/some/path/to/file.pdf";
            rewriter.Rewrite();
            Assert.AreEqual("Portal/GetLibraryFile.aspx?Path=some/path/to/file.pdf", context.Result);
        }

        [Test]
        public void MatchDciSiteRequest()
        {
            context.RawUrl = "http://www.AlanSmithee.org/site/some/path/to/file.pdf";
            rewriter.Rewrite();
            Assert.AreEqual("Portal/DisplayPortalPage.aspx?Requested=site/some/path/to/file.pdf", context.Result);
        }

        [Test]
        public void CaseInsensitiveUrls()
        {
            // all rules are case-insensitive
            context.RawUrl = "http://blah/library/test/file.aspx";
            rewriter.Rewrite();
            Assert.AreEqual("Portal/GetLibraryFile.aspx?Path=test/file.aspx", context.Result);

            context.RawUrl = "http://blah/Library/test/file.aspx";
            rewriter.Rewrite();
            Assert.AreEqual("Portal/GetLibraryFile.aspx?Path=test/file.aspx", context.Result);

            context.RawUrl = "http://blah/LIBRARY/TEST/FILE.ASPX";
            rewriter.Rewrite();
            Assert.AreEqual("Portal/GetLibraryFile.aspx?Path=TEST/FILE.ASPX", context.Result);
        }

        [Test]
        public void AppendInfoToEndOfUrl()
        {
            context.RawUrl = "http://blah/site/about_us.aspx";
            rewriter.Rewrite();
            Assert.AreEqual("Portal/DisplayPortalPage.aspx?Requested=site/about_us.aspx", context.Result);
        }

        [Test]
        public void NoPartialMatches()
        {
            context.RawUrl = "http://localhost/images/site.jpg";
            rewriter.Rewrite();
            // no match = null
            Assert.IsNull(context.Result, "shouldn't have found a match");
        }

        [Test]
        public void RewriteIndexRequest()
        {
            context.RawUrl = "http://www.server.com/";
            rewriter.Rewrite();
            Assert.AreEqual("Portal/DisplayPortalPage.aspx?Requested=site/index.aspx", context.Result);
        }


        [Test]
        public void RewriteScIdahoIndexRequest() 
        {
            context.RawUrl = "http://www.AlanSmithee.org/";
            rewriter.Rewrite();
            Assert.AreEqual("Portal/DisplayPortalPage.aspx?Requested=site/index.aspx", context.Result);
        }
    }
}