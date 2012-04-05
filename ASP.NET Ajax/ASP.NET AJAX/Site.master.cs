using System;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

public partial class Site_master : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //
        // Disable ExpandDepth if the TreeView's expand/collapse state is stored in session.
        //
        if (Session["TreeViewState"] != null)
            TreeView1.ExpandDepth = -1;
    }

    protected void TreeView1_DataBound(object sender, EventArgs e)
    {
        if (Session["TreeViewState"] == null)
        {
            //
            // Record the TreeView's current expand/collapse state.
            //
            List<string> list = new List<string>(16);
            SaveTreeViewState(TreeView1.Nodes, list);
            Session["TreeViewState"] = list;
        }
        else
        {
            //
            // Apply the recorded expand/collapse state to the TreeView.
            //
            List<string> list = (List<string>)Session["TreeViewState"];
            RestoreTreeViewState(TreeView1.Nodes, list);
        }
    }

    protected void TreeView1_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
    {
        if (IsPostBack)
        {
            List<string> list = new List<string>(16);
            SaveTreeViewState(TreeView1.Nodes, list);
            Session["TreeViewState"] = list;
        }
    }

    protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
    {
        if (IsPostBack)
        {
            List<string> list = new List<string>(16);
            SaveTreeViewState(TreeView1.Nodes, list);
            Session["TreeViewState"] = list;
        }
    }

    private void SaveTreeViewState(TreeNodeCollection nodes, List<string> list)
    {
        //
        // Recursivley record all expanded nodes in the List.
        //
        foreach (TreeNode node in nodes)
        {
            if (node.ChildNodes != null && node.ChildNodes.Count != 0)
            {
                if (node.Expanded.HasValue && node.Expanded == true && !String.IsNullOrEmpty(node.Text))
                    list.Add(node.Text);
                SaveTreeViewState(node.ChildNodes, list);
            }
        }
    }

    private void RestoreTreeViewState(TreeNodeCollection nodes, List<string> list)
    {
        foreach (TreeNode node in nodes)
        {
            //
            // Restore the state of one node.
            //
            if (list.Contains(node.Text))
            {
                if (node.ChildNodes != null && node.ChildNodes.Count != 0 && node.Expanded.HasValue && node.Expanded == false)
                    node.Expand();
            }
            else
            {
                if (node.ChildNodes != null && node.ChildNodes.Count != 0 && node.Expanded.HasValue && node.Expanded == true)
                    node.Collapse();
            }

            //
            // If the node has child nodes, restore their state, too.
            //
            if (node.ChildNodes != null && node.ChildNodes.Count != 0)
                RestoreTreeViewState(node.ChildNodes, list);
        }
    }
}
