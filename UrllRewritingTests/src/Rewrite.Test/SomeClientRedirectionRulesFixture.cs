using NUnit.Framework;
using Rewrite.Test;

namespace Rewrite.Test
{
    /// <summary>
    /// This is chained to the tests in CmsRedirectionRules, so if we add something to
    /// one Rules Xml block but it conflicts with another (hopefully) we'll find out about it.
    /// </summary>
    [TestFixture]
    public class SomeClientRedirectionRulesFixture : CmsRedirectionRulesFixture
    {

        public override string Rules
        {
            get { return @"
<rewriter>
		<register logger='Rewrite.Test.Log4NetRewriteLogger, Rewrite.Test' />
        <register transform='Rewrite.Test.AttachQueryStringTransform, Rewrite.Test' />

        <!-- Wiki gets ignored -->
        <rewrite url='/wikidemo(.+)' to='/wikidemo$1' processing='stop' />

        <!-- our library -->
		<rewrite url='/Library/(.+)' to='~/Portal/GetLibraryFile.aspx?Path=$1' />

		
		<!-- 'Donate' directory -->
		<rewrite url='/donate/(.+)' to='~/Portal/GetPortalPage.aspx?Requested=/SomeClient/donate/${attachQueryString($1)}' />

		<!-- visit us -->
		<rewrite url='/Visit_Us/(.+)' to='~/Portal/GetPortalPage.aspx?Requested=/SomeClient/Visit_Us/${attachQueryString($1)}' />

        <!-- site admin index -->
        <rewrite url='(/admin/index.aspx(.+)?)$' to='$1' processing='stop' />

		<!-- index page handling: -->
        <rewrite url='(/index.aspx)$' to='~/Portal/GetPortalPage.aspx?Requested=/SomeClient/index.aspx' />
		<rewrite url='/index.aspx(\?(.+))?$' to='~/Portal/GetPortalPage.aspx?Requested=/SomeClient/index.aspx&amp;$2' />
		
		<!-- handles default page request (should redirect to index.aspx) -->
		<rewrite url='^(.*)/(\?.+)?$' to='$1/index.aspx$2' processing='restart' />

        <!-- rules required for Cms Administration -->
        <rewrite url='~/ServerAdmin/membership/users(\?.+)?$' to='~/serveradmin/membership/users.aspx$1' />
        <rewrite url='~/ServerAdmin/membership/users/(.+)?$' to='~/serveradmin/membership/users_edit.aspx?action=$1' />
        <rewrite url='~/ServerAdmin/sites(\?.+)?$' to='~/serveradmin/default.aspx$1' />
        <rewrite url='~/ServerAdmin/libraries(\?.+)?$' to='~/serveradmin/libraries.aspx$1' />
        <rewrite url='~/ServerAdmin/libraries/(.+)?$' to='~/serveradmin/libraries_edit.aspx?action=$1' />
        <rewrite url='~/SiteAdmin/sites(\?.+)?$' to='~/siteadmin/default.aspx$1' />
        <rewrite url='~/SiteAdmin/sites/([A-Za-z]+)$' to='~/siteadmin/editsite.aspx?site=$1' />
		<rewrite url='~/SiteAdmin/sites/([A-Za-z]+)/Permissions' to='~/siteadmin/folderpermissions.aspx?site=$1' />
</rewriter>"; 
            }
        }


        [Test]
        public void WikiDemoRequest_default()
        {
            context.RawUrl = "http://www.SomeClient.org/wikidemo/";
            rewriter.Rewrite();
            Assert.AreEqual("/wikidemo/", context.Result);
        }

        [Test]
        public void WikiDemoRequest_Page()
        {
            context.RawUrl = "http://www.SomeClient.org/wikidemo/some/page.php";
            rewriter.Rewrite();
            Assert.AreEqual("/wikidemo/some/page.php", context.Result);
        }

        [Test]
        public void WikiDemoRequest_Page_QueryString()
        {
            context.RawUrl = "http://www.SomeClient.org/wikidemo/some/page.php?with=value&other=value";
            rewriter.Rewrite();
            Assert.AreEqual("/wikidemo/some/page.php?with=value&other=value", context.Result);
        }

        [Test]
        public void GetLibraryFile()
        {
            context.RawUrl = "http://www.SomeClient.org/library/some/path/to/file.pdf";
            rewriter.Rewrite();
            Assert.AreEqual("Portal/GetLibraryFile.aspx?Path=some/path/to/file.pdf", context.Result);
        }


        [Test]
        public void VisitUs()
        {
            context.RawUrl = "http://www.SomeClient.org/Visit_Us/Contact_Us.aspx";
            rewriter.Rewrite();
            Assert.AreEqual("Portal/GetPortalPage.aspx?Requested=/SomeClient/Visit_Us/Contact_Us.aspx", context.Result);
        }

      

        [Test]
        public void IndexDirectly()
        {
            context.RawUrl = "http://www.SomeClient.org/index.aspx";
            rewriter.Rewrite();
            Assert.AreEqual("Portal/GetPortalPage.aspx?Requested=/SomeClient/index.aspx&", context.Result);
        }

        [Test]
        public void IndexDirectly_Edit()
        {
            context.RawUrl = "http://www.SomeClient.org/index.aspx?mode=EditStructure";
            rewriter.Rewrite();
            Assert.AreEqual("Portal/GetPortalPage.aspx?Requested=/SomeClient/index.aspx&mode=EditStructure", context.Result);
        }


        [Test]
        public void IndexIndirectly()
        {
            // the case http://www.SomeClient.org (no slash) is dealt for us by the browser.
            context.RawUrl = "http://www.SomeClient.org/";
            rewriter.Rewrite();
            Assert.AreEqual("Portal/GetPortalPage.aspx?Requested=/SomeClient/index.aspx&", context.Result);
        }

        [Test]
        public void SiteAdminIndex()
        {
            context.RawUrl = "http://www.SomeClient.org/admin/index.aspx";
            rewriter.Rewrite();
            Assert.AreEqual("/admin/index.aspx", context.Result);
        }
    }
}