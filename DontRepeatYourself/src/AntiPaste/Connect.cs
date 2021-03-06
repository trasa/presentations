using System;
using System.Windows.Forms;
using Extensibility;
using EnvDTE;
namespace AntiPaste
{
	/// <summary>The object for implementing an Add-in.</summary>
	/// <seealso class='IDTExtensibility2' />
	public class Connect : IDTExtensibility2
	{
		/// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
		/// <param term='application'>Root object of the host application.</param>
		/// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
		/// <param term='addInInst'>Object representing this Add-in.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
		{
			_applicationObject = (DTE)application;
		    
            // hook into the Paste Command
		    Command cmd = _applicationObject.Commands.Item("Edit.Paste", 0);
		    events = _applicationObject.Events.get_CommandEvents(cmd.Guid, cmd.ID);

		    events.BeforeExecute += OnPaste;
		}

        /// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
        /// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
        {
            if (events != null)
            {
                events.BeforeExecute -= OnPaste;
            }
        }




        // if this falls out of scope your event registration disappears...
        CommandEvents events;

        private static void OnPaste(string Guid, int ID, object CustomIn, object CustomOut, ref bool CancelDefault)
        {
            DialogResult result = new PasteWarningDialog().ShowDialog();
            if (result == DialogResult.Cancel)
            {
                CancelDefault = true;
            }
            // else do it...
        }

        #region other IDTExtensibility2 stuff...

		/// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />		
		public void OnAddInsUpdate(ref Array custom)
		{
		}

		/// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref Array custom)
		{
		}

		/// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref Array custom)
		{
        }

        private DTE _applicationObject;
        
        #endregion
	}
}