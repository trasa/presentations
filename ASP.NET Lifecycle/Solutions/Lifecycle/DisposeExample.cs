using System;

namespace Lifecycle {
	/// <summary>
	/// From "Effective C#:  Implement the Standard Dispose Pattern"
	/// http://www.awprofessional.com/articles/article.asp?p=349041
	/// </summary>
	public class DisposeExample : IDisposable {

		/// <summary>
		/// Has this object been disposed already?
		/// </summary>
		private bool alreadyDisposed = false; 


		public DisposeExample() {
			//
			// TODO: Add constructor logic here
			//
		}

		
		~DisposeExample() {
			// finalizer logic here...

			// MUST have a finalizer if the class uses non-memory
			// resources.  this is a defensive mechanism for when
			// user forgets to call Dispose()
			//
			// call the Dispose mechanism, telling it that we're finalizing 
			// instead of merely Disposing.
			Dispose(false);
		}


		#region IDisposable Members

		/// <summary>
		/// The standard Disposable pattern...
		/// </summary>
		public void Dispose() {
			// call the Dispose Mechanism, telling it that we're being called
			// through IDisposable instead of finalization
			Dispose(true);
			
			// since we're disposed of, no need to involve the Finalizer thread.
			GC.SuppressFinalize(this);
		}

		#endregion

		/// <summary>
		/// Does the work of disposing this object safely.
		/// Supports both Dispose and Finalize.
		/// Virtual, so it can be overridden in derived classes that need to 
		/// add their own finalization (important!)
		/// </summary>
		/// <param name="isDisposing"></param>
		protected virtual void Dispose(bool isDisposing) {
			// never dispose more than once
			if (alreadyDisposed) { 
				return;
			}

			if (isDisposing) {
				// called from Disposable -- 
				// safe to free Managed Resources here.

				// TODO: free managed resources here
			}

			// TODO: free all unmanaged resources here
			
			// set disposed flag
			alreadyDisposed = true;
		}

		/**
		 * Remember:
		 * 
		 * ---	Disposal and Finalization are for releasing resources, ONLY.
		 *		Do not do further processing or access any other objects than you
		 *		strictly need to in here.  
		 * 
		 * "Objects are born when you construct them, and they die when Garbage Collection
		 * reclaims them.  You can consider them comatose when your program can no longer
		 * access [the object]. . . if a finalizer makes an object reachable again, it has
		 * been 'Resurrected'."  
		 * 
		 * This is a BAD THING.  
		 * 
		 * Do not create zombified comatose objects, they are an abhorrence to nature.
		 * 
		 * ---	Keep your disposal/finalization code simple.  
		 * 
		 * ---	Finalization of objects can happen in any order, at any time.
		 * 
		 * ---	There are no guarantees that Finalization will even happen, at all.
		 * 
		 * ---	Non-Deterministic Finalization
		 *		
		 */
	}
}
