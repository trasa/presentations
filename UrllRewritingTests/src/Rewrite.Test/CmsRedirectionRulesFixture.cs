using NUnit.Framework;

namespace Rewrite.Test
{
    /// <summary>
    /// Test the basic Cms redirection rules, applicable to all Cms instances.
    /// </summary>
    [TestFixture]
    public class CmsRedirectionRulesFixture : RedirectionRulesFixture
    {
        public override string Rules
        {
            get {
                return @"	<rewriter>
		<register logger='Rewrite.Test.Log4NetRewriteLogger, Rewrite.Test' />
		<register transform='Rewrite.Test.AttachQueryStringTransform, Rewrite.Test' />

		<!-- the 'sample' site -->
		<rewrite url='^~/sample/(.+)' to='~/Portal/GetPortalPage.aspx?Requested=Sample/${attachQueryString($1)}'/>

		<!-- 'Local' site -->
		<rewrite url='^~/local/(.+)' to='~/Portal/GetPortalPage.aspx?Requested=Local/${attachQueryString($1)}'/>

		<!-- our library : this rule is required by Blackfin.Cms -->
		<rewrite url='^~/Library/(.+)' to='~/Portal/GetLibraryFile.aspx?Path=$1'/>

		<!-- Required Rule: once the library files have been dealt with, ignore these files: -->
		<rewrite url='^(/.+(\.gif|\.png|\.jpg|\.ico|\.pdf|\.css|\.js)(\?.+)?)$' to='$1' processing='stop'/>


		<rewrite url='^(.*)/(\?.+)?$' to='$1/index.aspx$2?'/>
		
		<!-- Required Rules for Cms Admin -->
		<rewrite url='~/ServerAdmin/membership/users(\?.+)?$' to='~/serveradmin/membership/users.aspx$1' />
		<rewrite url='~/ServerAdmin/membership/users/(.+)?' to='~/serveradmin/membership/users_edit.aspx?action=$1' />
		<rewrite url='~/ServerAdmin/sites(\?.+)?$' to='~/serveradmin/default.aspx$1' />
		<rewrite url='~/ServerAdmin/libraries(\?.+)?$' to='~/serveradmin/libraries.aspx$1' />
		<rewrite url='~/ServerAdmin/libraries/(.+)?' to='~/serveradmin/libraries_edit.aspx?action=$1' />
		<rewrite url='~/SiteAdmin/sites(\?.+)?$' to='~/siteadmin/default.aspx$1' />
        <rewrite url='~/SiteAdmin/sites/([A-Za-z]+)$' to='~/siteadmin/editsite.aspx?site=$1' />
		<rewrite url='~/SiteAdmin/sites/([A-Za-z]+)/Permissions' to='~/siteadmin/folderpermissions.aspx?site=$1' />
	</rewriter>
";
            }
        }



        [Test]
        public void Membership_Users()
        {
            context.RawUrl = "http://www.AlanSmithee.org/serveradmin/membership/users";
            rewriter.Rewrite();
            Assert.AreEqual("serveradmin/membership/users.aspx", context.Result);
        }

        [Test]
        public void Membership_Users_AddNew()
        {
            context.RawUrl = "http://www.AlanSmithee.org/serveradmin/membership/users/addnew";
            rewriter.Rewrite();
            Assert.AreEqual("serveradmin/membership/users_edit.aspx?action=addnew", context.Result);
        }

        [Test]
        public void Membership_Users_EditUser()
        {
            context.RawUrl = "http://www.AlanSmithee.org/serveradmin/membership/users/bsmith";
            rewriter.Rewrite();
            Assert.AreEqual("serveradmin/membership/users_edit.aspx?action=bsmith", context.Result);
        }



        [Test]
        public void ServerAdmin_SiteList()
        {
            context.RawUrl = "http://www.AlanSmithee.org/serveradmin/sites";
            rewriter.Rewrite();
            Assert.AreEqual("serveradmin/default.aspx", context.Result);
        }

        [Test]
        public void SiteAdmin_SiteList()
        {
            context.RawUrl = "http://www.AlanSmithee.org/siteadmin/sites";
            rewriter.Rewrite();
            Assert.AreEqual("siteadmin/default.aspx", context.Result);
        }

        [Test]
        public void SiteAdmin_SiteList_EditSite()
        {
            context.RawUrl = "http://www.AlanSmithee.org/siteadmin/sites/foo";
            rewriter.Rewrite();
            Assert.AreEqual("siteadmin/editsite.aspx?site=foo", context.Result);
        }

        [Test]
        public void SiteAdmin_SiteList_EditSite_Permissions()
        {
            context.RawUrl = "http://localhost:1337/siteadmin/sites/Local/Permissions";
            rewriter.Rewrite();
            Assert.AreEqual("siteadmin/folderpermissions.aspx?site=Local", context.Result);
        }


        [Test]
        public void LibraryList()
        {
            context.RawUrl = "http://www.AlanSmithee.org/serveradmin/libraries";
            rewriter.Rewrite();
            Assert.AreEqual("serveradmin/libraries.aspx", context.Result);
        }

        [Test]
        public void Library_AddNew()
        {
            context.RawUrl = "http://www.AlanSmithee.org/serveradmin/libraries/addnew";
            rewriter.Rewrite();
            Assert.AreEqual("serveradmin/libraries_edit.aspx?action=addnew", context.Result);
        }

        [Test]
        public void Library_Edit()
        {
            context.RawUrl = "http://www.AlanSmithee.org/serveradmin/libraries/foo";
            rewriter.Rewrite();
            Assert.AreEqual("serveradmin/libraries_edit.aspx?action=foo", context.Result);
        }
    }
}